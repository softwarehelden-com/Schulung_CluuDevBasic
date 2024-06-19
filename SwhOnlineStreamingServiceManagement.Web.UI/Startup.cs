﻿using System.Reflection;
using Cluu.AddIn;
using Cluu.AddIn.Web.Plugins;
using Cluu.Hosting;
using Microsoft.Extensions.Hosting;

namespace SwhOnlineStreamingServiceManagement.Web.UI
{
    /// <summary>
    /// The plugin registrations informs the cluu framework about available javascripts, css, field renderers,...
    /// </summary>
    public class Startup : IStartup
    {
        void IStartup.ConfigureServices(HostBuilderContext ctx, ICluuServiceConfigurationBuilder cluu)
        {
            // Aktuelle Assembly ermitteln Alle Plugins sind eingebettete Ressourcen oder Typen dieser Assemmbly.
            var assembly = Assembly.GetExecutingAssembly();

        //cluu
        //    .AddFieldRenderer<FieldRenderer> ();

        //cluu
        //    .AddEmbeddedTranslationResource(assembly, "swhOnlineStreamingServiceManagement.web.ui.translations");

        cluu
            .AddEmbeddedLessResource(assembly, "swhOnlineStreamingServiceManagement");

            cluu
                .AddEmbeddedJavaScriptResource(assembly, "swhOnlineStreamingServiceManagement", components: this.CreateRequireJsPluginComponents());
        }

        private RequireJsPluginComponent[] CreateRequireJsPluginComponents()
        {
            return new[]{
                new RequireJsPluginComponent(
                    componentName: "swhOnlineStreamingServiceManagement.web.ui.actions.demoAction",
                    className: "DemoAction"
                )
            };
        }
    }
}
