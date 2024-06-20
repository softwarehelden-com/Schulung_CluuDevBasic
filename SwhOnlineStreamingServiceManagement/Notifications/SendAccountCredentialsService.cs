using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cluu.Client.Mail;
using Cluu.CQL;
using Cluu.DataAccess;
using SwhOnlineStreamingServiceManagement.EntityModel;

namespace SwhOnlineStreamingServiceManagement.Notifications
{
    internal class SendAccountCredentialsService : ISendAccountCredentialsService
    {
        private readonly ICluuMailManager cluuMailManager;
        private readonly IDataContextFactory dataContextFactory;

        public SendAccountCredentialsService(
            ICluuMailManager cluuMailManager,
            IDataContextFactory dataContextFactory
        )
        {
            this.cluuMailManager = cluuMailManager;
            this.dataContextFactory = dataContextFactory;
        }

        async Task ISendAccountCredentialsService.SendAccountCredentialsAsync(
            CluuConstraint accountConstraint,
            CancellationToken cancellationToken
        )
        {
            using (var ctx = this.dataContextFactory.Create())
            {
                var accounts = await this.GetAccountsAsync(
                    ctx,
                    accountConstraint,
                    cancellationToken
                ).ConfigureAwait(false);

                foreach (var account in accounts)
                {
                    foreach (var share in account.AccountShares)
                    {
                        await this.TrySendMailAsync(account, share, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task<IReadOnlyList<Account>> GetAccountsAsync(
            IObjectContext ctx,
            CluuConstraint accountConstraint,
            CancellationToken cancellationToken
        )
        {
            var s = Account.CreateFieldSelector();

            string[] selectFields = new string[]
            {
                s.Id,
                s.Caption,
                s.AccountShares.Person.FirstName,
                s.AccountShares.Person.LastName,
                s.AccountShares.Person.EMail
            };

            return await ctx.GetByConstraintAsync<Account>(
                accountConstraint,
                selectFields,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task TrySendMailAsync(Account account, AccountShare share, CancellationToken cancellationToken)
        {
            string mailAddress = share.Person?.EMail;

            if (string.IsNullOrWhiteSpace(mailAddress))
            {
                return;
            }

            string firstName = share.Person.FirstName;
            string lastName = share.Person.LastName;

            var mail = new CluuMail(
                subject: $"Deine Zugangsdaten für '{account.Caption}'",
                content: $"Hallo {firstName} {lastName}, hier sind deine Zugangsdaten für '{account.Caption}'",
                isContentHtml: false,
                from: null,
                to: new CluuMailAddress[] { new CluuMailAddress(mailAddress) }
            );

            await this.cluuMailManager.SendMailAsync(mail, cancellationToken).ConfigureAwait(false);
        }
    }
}
