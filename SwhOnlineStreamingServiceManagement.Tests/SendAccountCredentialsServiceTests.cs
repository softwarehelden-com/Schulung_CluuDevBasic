using System.Threading;
using System.Threading.Tasks;
using Cluu.Client.Mail;
using Cluu.CQL;
using Cluu.TestFramework;
using Microsoft.Extensions.DependencyInjection;
using SwhOnlineStreamingServiceManagement.EntityModel;
using SwhOnlineStreamingServiceManagement.Notifications;
using SwhOnlineStreamingServiceManagement.Tests.Services;
using Xunit;

namespace SwhOnlineStreamingServiceManagement.Tests
{
    public class SendAccountCredentialsServiceTests
        : OfflineBackboneTestBase<SendAccountCredentialsServiceTestFixture>, IClassFixture<SendAccountCredentialsServiceTestFixture>
    {
        private readonly AccountTestDataFactory accountTestDataFactory;
        private readonly MockCluuMailManager mailManager;
        private readonly ISendAccountCredentialsService sendAccountCredentialsService;

        public SendAccountCredentialsServiceTests(SendAccountCredentialsServiceTestFixture fixture)
            : base(fixture)
        {
            // Test Setup
            this.sendAccountCredentialsService = fixture.Host.Services.GetRequiredService<ISendAccountCredentialsService>();
            this.accountTestDataFactory = fixture.Host.Services.GetRequiredService<AccountTestDataFactory>();
            this.mailManager = (MockCluuMailManager)fixture.Host.Services.GetRequiredService<ICluuMailManager>();
        }

        [Fact]
        public async Task Ensure_mails_for_account_credentials_are_sent()
        {
            // ARRANGE
            var cancellationToken = CancellationToken.None;

            int accountId = await this.accountTestDataFactory.CreateAsync((ctx, account) =>
            {
                account.Caption = "Der Netflix Account";
                account.Description = "Der Account für Netflix";
                account.Username = "account_username";
                account.Password = "account_password";

                var person = ctx.New<IPerson>();

                person.FirstName = "Max";
                person.LastName = "Mustermann";
                person.EMail = "max.mustermann@softwarehelden.com";

                var share = ctx.New<AccountShare>();

                share.Person = person;

                account.AccountShares.Add(share);
            }, cancellationToken);

            var s = Account.CreateFieldSelector();

            var accountConstraint = CluuConstraint.Equal(s.Id, accountId);

            // ACT
            await this.sendAccountCredentialsService.SendAccountCredentialsAsync(accountConstraint, cancellationToken);

            // ASSERT
            var mail = Assert.Single(this.mailManager.Mails);
            Assert.NotNull(mail);
            Assert.Equal("Deine Zugangsdaten für 'Der Netflix Account'", mail.Subject);
            Assert.Equal("Hallo Max Mustermann, hier sind deine Zugangsdaten für 'Der Netflix Account'", mail.Content);

            var to = Assert.Single(mail.To);
            Assert.Equal("max.mustermann@softwarehelden.com", to.Address);
        }
    }
}
