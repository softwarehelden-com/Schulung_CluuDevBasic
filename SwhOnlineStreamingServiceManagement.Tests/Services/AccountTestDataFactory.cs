using System;
using System.Threading;
using System.Threading.Tasks;
using Cluu.DataAccess;
using SwhOnlineStreamingServiceManagement.EntityModel;

namespace SwhOnlineStreamingServiceManagement.Tests.Services
{
    internal class AccountTestDataFactory
    {
        private readonly IDataContextFactory dataContextFactory;

        public AccountTestDataFactory(
            IDataContextFactory dataContextFactory
        )
        {
            this.dataContextFactory = dataContextFactory;
        }

        public async Task<int> CreateAsync(Action<IObjectContext, Account> init, CancellationToken cancellationToken)
        {
            using (var ctx = this.dataContextFactory.Create())
            {
                var account = ctx.New<Account>();

                init(ctx, account);

                ctx.Attach(account);

                await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return account.Id.Value;
            }
        }
    }
}
