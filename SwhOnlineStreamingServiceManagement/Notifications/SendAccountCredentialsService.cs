using System.Threading;
using System.Threading.Tasks;
using Cluu.CQL;

namespace SwhOnlineStreamingServiceManagement.Notifications
{
    internal class SendAccountCredentialsService : ISendAccountCredentialsService
    {
        Task ISendAccountCredentialsService.SendAccountCredentialsAsync(
            CluuConstraint accountConstraint,
            CancellationToken cancellationToken
        )
        {
            throw new System.NotImplementedException("muss wohl noch :-)");
        }
    }
}
