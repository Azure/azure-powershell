using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IAsyncCmdlet
    {
        SyncTaskScheduler Scheduler { get; }

        IEnumerable<ITaskProgress> TaskProgressList { get; }

        void WriteVerbose(string message);

        Task<bool> ShouldProcessAsync(string target, string action);

        void WriteObject(object value);

        void ReportTaskProgress(ITaskProgress taskProgress);

        /// <summary>
        /// Only for synchronous calls.
        /// </summary>
        void WriteProgress(
            string activity,
            string statusDescription,
            string currentOperation,
            int percentComplete);
    }
}
