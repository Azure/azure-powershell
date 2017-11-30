using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class AsyncCmdletExtensions
    {
        /// <summary>
        /// Note: the function must be called in the main PowerShell thread.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="createAndStartTask"></param>
        public static void StartAndWait(this Cmdlet cmdlet, Func<IAsyncCmdlet, Task> createAndStartTask)
        {
            var asyncCmdlet = new AsyncCmdlet(cmdlet);
            asyncCmdlet.Scheduler.Wait(createAndStartTask(asyncCmdlet));
        }

        sealed class AsyncCmdlet : IAsyncCmdlet
        {
            public SyncTaskScheduler Scheduler { get; } = new SyncTaskScheduler();

            readonly Cmdlet _Cmdlet;

            public AsyncCmdlet(Cmdlet cmdlet)
            {
                _Cmdlet = cmdlet;
            }

            public void WriteVerbose(string message)
                => Scheduler.BeginInvoke(() => _Cmdlet.WriteVerbose(message));

            public Task<bool> ShouldProcessAsync(string target, string action)
                => Scheduler.Invoke(() => _Cmdlet.ShouldProcess(target, action));
        }
    }
}
