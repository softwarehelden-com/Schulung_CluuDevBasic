using System.Threading;
using System.Threading.Tasks;
using Cluu.CQL;

namespace SwhOnlineStreamingServiceManagement.Notifications
{
    public interface ISendAccountCredentialsService
    {
        Task SendAccountCredentialsAsync(CluuConstraint accountConstraint, CancellationToken cancellationToken);
    }
}
