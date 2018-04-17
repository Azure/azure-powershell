using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class AsyncCmdletExtensions
    {
        public static void WriteVerbose(this IAsyncCmdlet cmdlet, string message, params object[] p)
            => cmdlet.WriteVerbose(string.Format(message, p));

        /// <summary>
        /// Note: the function must be called in the main PowerShell thread.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="createAndStartTask"></param>
        public static void StartAndWait(
            this IAsyncCmdlet asyncCmdlet, Func<IAsyncCmdlet, Task> createAndStartTask)
        {
            string previousX = null;
            string previousOperation = null;
            asyncCmdlet.Scheduler.Wait(
                createAndStartTask(asyncCmdlet),
                () =>
                {
                    if (asyncCmdlet.TaskProgressList.Any())
                    {
                        var progress = 0.0;
                        var activeTasks = new List<string>();
                        foreach (var taskProgress in asyncCmdlet.TaskProgressList)
                        {
                            if (!taskProgress.IsDone)
                            {
                                var config = taskProgress.Config;
                                activeTasks.Add(config.GetFullName());
                            }
                            progress += taskProgress.GetProgress();
                        }
                        var percent = (int)(progress * 100.0);
                        var r = new[] { "|", "/", "-", "\\" };
                        var x = r[DateTime.Now.Second % 4];
                        var operation = activeTasks.Count > 0
                            ? "Creating " + string.Join(", ", activeTasks) + "."
                            : null;

                        // write progress only if it's changed.
                        if (x != previousX || operation != previousOperation)
                        {
                            asyncCmdlet.WriteProgress(
                                activity: "Creating Azure resources",
                                statusDescription: percent + "% " + x,
                                currentOperation: operation,
                                percentComplete: percent);
                            previousX = x;
                            previousOperation = operation;
                        }
                    }
                });
        }
    }
}