using System.Threading;
using System.Threading.Tasks;
using Dotnet.Services.Email.Core.Models;

namespace Dotnet.Services.Email.Core.Interfaces
{
    public interface ISender
    {
        SendResponse Send(IEmail email, CancellationToken? token = null);
        Task<SendResponse> SendAsync(IEmail email, CancellationToken? token = null);
    }
}
