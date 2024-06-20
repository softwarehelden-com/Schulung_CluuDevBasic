using Cluu.Client.Mail;
using Cluu.TestFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SwhOnlineStreamingServiceManagement.Actions;
using SwhOnlineStreamingServiceManagement.Tests.Services;

namespace SwhOnlineStreamingServiceManagement.Tests
{
    public class SendAccountCredentialsServiceTestFixture : OfflineBackboneHostFixture
    {
        protected override OfflineBackboneHostOptions CreateOptions()
        {
            var options = base.CreateOptions();

            options.ValidateRequiredProperties = false;

            options.Startups.Add(new Startup());

            options.PostConfigureHost.Add((context, cluu) =>
            {
                cluu.Services.TryAddSingleton<AccountTestDataFactory>();

                _ = cluu.Services.RemoveAll<ICluuMailManager>();
                _ = cluu.Services.AddSingleton<ICluuMailManager, MockCluuMailManager>();
            });

            return options;
        }
    }
}
