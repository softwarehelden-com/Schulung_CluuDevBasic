using Cluu.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SwhOnlineStreamingServiceManagement.Notifications;

namespace SwhOnlineStreamingServiceManagement.Hosting
{
    public static class ICluuServiceConfigurationBuilderExtensions
    {
        public static void TryAddSwhOnlineStreamingServiceManagement(this ICluuServiceConfigurationBuilder cluu)
        {
            cluu.Services.TryAddSingleton<ISendAccountCredentialsService, SendAccountCredentialsService>();
        }
    }
}
