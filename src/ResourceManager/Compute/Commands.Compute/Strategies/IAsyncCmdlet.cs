using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    interface IAsyncCmdlet
    {
        void WriteVerbose(string message);

        Task<bool> ShouldProcessAsync(string target, string action);
    }
}
