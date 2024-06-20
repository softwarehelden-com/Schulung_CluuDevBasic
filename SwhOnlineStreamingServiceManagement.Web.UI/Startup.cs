using System.Reflection;
using Cluu.AddIn;
using Cluu.AddIn.Web.Plugins;
using Cluu.Hosting;
using Microsoft.Extensions.Hosting;

namespace SwhOnlineStreamingServiceManagement.Web.UI
{
    public class Startup : IStartup
    {
        void IStartup.ConfigureServices(HostBuilderContext ctx, ICluuServiceConfigurationBuilder cluu)
        {
            var assembly = Assembly.GetExecutingAssembly();

            _ = cluu
                .AddEmbeddedJavaScriptResource(
                    assembly,
                    "swhOnlineStreamingServiceManagement",
                    components: this.CreateRequireJsPluginComponents()
                );
        }

        private RequireJsPluginComponent[] CreateRequireJsPluginComponents()
        {
            return new[]{
                new RequireJsPluginComponent(
                    componentName: "swhOnlineStreamingServiceManagement.web.ui.actions.sendAccountCredentialsAction",
                    className: "SendAccountCredentialsAction"
                )
            };
        }
    }
}
