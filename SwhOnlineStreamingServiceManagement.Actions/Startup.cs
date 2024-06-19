using Cluu.AddIn;
using Cluu.Hosting;
using Microsoft.Extensions.Hosting;
using SwhOnlineStreamingServiceManagement.Hosting;

namespace SwhOnlineStreamingServiceManagement.Actions
{
    /// <summary>
    /// Builds the service Provider used by the application.
    /// </summary>
    //[CluuAlwaysRunning]
    public class Startup : IStartup
    {
        ///<inheritdoc/>
        void IStartup.ConfigureServices(HostBuilderContext ctx, ICluuServiceConfigurationBuilder cluu)
        {
            // Services des generierten Codes hinzufügen
            _ = cluu.TryAddCluuAddInActions();

            _ = cluu.TryAddCluuMailManager();

            cluu.TryAddSwhOnlineStreamingServiceManagement();
        }
    }
}
