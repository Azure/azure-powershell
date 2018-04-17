using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IAsyncCmdlet
    {
        void WriteVerbose(string message);

        Task<bool> ShouldProcessAsync(string target, string action);

        void WriteObject(object value);

        void ReportTaskProgress(ITaskProgress taskProgress);
    }
}
