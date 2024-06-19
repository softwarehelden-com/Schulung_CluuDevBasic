using System;
using System.Threading;
using System.Threading.Tasks;
using Cluu.AddIn;
using SwhOnlineStreamingServiceManagement.Notifications;

namespace SwhOnlineStreamingServiceManagement.Actions
{
    /// <summary>Zugangsdaten als EMail versenden</summary>
    internal class SendAccountCredentialsAction : ISendAccountCredentialsAction
    {
        private readonly ISendAccountCredentialsService sendAccountCredentialsService;

        public SendAccountCredentialsAction(
            ISendAccountCredentialsService sendAccountCredentialsService
        )
        {
            this.sendAccountCredentialsService = sendAccountCredentialsService;
        }

        /// <inheritdoc/>
        async Task ICluuAction<SendAccountCredentialsRequest>.InvokeAsync(
            SendAccountCredentialsRequest request,
            CancellationToken cancellationToken
        )
        {
            await this.sendAccountCredentialsService.SendAccountCredentialsAsync(
                request.AccountConstraint,
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}
