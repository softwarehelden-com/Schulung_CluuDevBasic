#pragma warning disable
// Cluu Version: 6.3.1

using Cluu.AddIn;
using Cluu.Hosting;

namespace SwhOnlineStreamingServiceManagement.Actions
{
    /// <summary>
    /// Adds the cluu add ins to the service configuration builder.
    /// </summary>
    internal static class CluuAddInActionServiceConfigurationBuilderExtensions
    {
        public static ICluuServiceConfigurationBuilder TryAddCluuAddInActions(this ICluuServiceConfigurationBuilder cluu)
        {
            cluu.TryAddCluuAction<ISendAccountCredentialsAction, SendAccountCredentialsAction, SendAccountCredentialsRequest>("SwhOnlineStreamingServiceManagement.AddIns.Notifications.SendAccountCredentials");

            return cluu;
        }
    }

    /// <summary>Zugangsdaten als EMail versenden</summary>
    internal interface ISendAccountCredentialsAction : ICluuAction<SendAccountCredentialsRequest>
    {
    }


    [System.Reflection.Obfuscation(Exclude = true)]
    internal partial class SendAccountCredentialsRequest
    {
        [System.Text.Json.Serialization.JsonPropertyName("accountConstraint")]
        public Cluu.CQL.CluuConstraint AccountConstraint { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }


}
#pragma warning restore
