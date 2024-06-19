using Cluu.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SwhOnlineStreamingServiceManagement.EntityModel;
using SwhOnlineStreamingServiceManagement.Notifications;

namespace SwhOnlineStreamingServiceManagement.Hosting
{
    public static class ICluuServiceConfigurationBuilderExtensions
    {
        public static void TryAddSwhOnlineStreamingServiceManagement(this ICluuServiceConfigurationBuilder cluu)
        {
            _ = cluu.TryAddEntityModel();

            cluu.Services.TryAddSingleton<ISendAccountCredentialsService, SendAccountCredentialsService>();
        }
    }
}
