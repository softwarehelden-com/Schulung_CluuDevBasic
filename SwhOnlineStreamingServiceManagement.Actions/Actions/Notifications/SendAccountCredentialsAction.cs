using System;
using System.Threading;
using System.Threading.Tasks;
using Cluu.AddIn;

namespace SwhOnlineStreamingServiceManagement.Actions
{
    /// <summary>Zugangsdaten als EMail versenden</summary>
    internal class SendAccountCredentialsAction : ISendAccountCredentialsAction
    {
        /// <inheritdoc/>
        async Task ICluuAction<SendAccountCredentialsRequest>.InvokeAsync(
            SendAccountCredentialsRequest request,
            CancellationToken cancellationToken
        )
        {
            // TODO: Implement SendAccountCredentialsAction
            throw new NotImplementedException("Muss ich noch machen");
        }
    }
}
