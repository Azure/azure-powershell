using Microsoft.Azure.Commands.Common.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Strategies
{
    public interface ICmdletAdapter
    {
        /// <summary>
        /// Given the target and description of a change, determine if the change should occur
        /// </summary>
        /// <param name="target">The resource that is changing</param>
        /// <param name="action">A description fo the proposed change</param>
        /// <returns>True if the change should proceeed, false otherwise</returns>
        Task<bool> ShouldChangeAsync(string target, string action);

        /// <summary>
        /// Given the target and prompt information describing a special condition for a change, determine whether the change should proceed
        /// </summary>
        /// <param name="query">A textual description of the special circumstances that require special confirmation</param>
        /// <param name="caption">A summary description of the special condition that requires confirmation</param>
        /// <returns>True if the change shoudl proceed, false otherwise</returns>
        Task<bool> SHouldContinueChangeAsync(string query, string caption);

        /// <summary>
        /// Report an error
        /// </summary>
        /// <param name="exception">The exception descriging the error</param>
        /// <returns>nothing</returns>
        void WriteExceptionAsync(Exception exception);

        /// <summary>
        /// Log additional information
        /// </summary>
        /// <param name="verboseMessage">The additional information to log</param>
        /// <returns>nothing</returns>
        void WriteVerboseAsync(string verboseMessage);

        /// <summary>
        /// Log debugging information
        /// </summary>
        /// <param name="debugMessage">The debug information to log</param>
        /// <returns>nothing</returns>
        void WriteDebugAsync(string debugMessage);

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="warningMessage">The warning to log</param>
        /// <returns>nothing</returns>
        void WriteWarningAsync(string warningMessage);

        /// <summary>
        /// Log the beginning of an activity
        /// </summary>
        /// <param name="description">A description of the activity that is starting</param>
        /// <param name="initialStatus">The inbitial status of the activity</param>
        /// <returns>An activity tracker</returns>
        IActivity StartActivity(string description, string initialStatus, int secondsRemaining);

        /// <summary>
        /// Complete all processing
        /// </summary>
        /// <returns>nothing</returns>
        void Complete();
    }

    public interface IActivity
    {
        /// <summary>
        /// Identifier for the activity
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Summart description of the activity
        /// </summary>
        string Description  { get; }

        /// <summary>
        /// Summary description of the current activity status
        /// </summary>
        string StatusDescription { get; }

        /// <summary>
        /// Complete the given activity
        /// </summary>
        /// <returns>A task, which ends when completion is signaled</returns>
        void CompleteAsync();

        /// <summary>
        /// Repoprt progress on the activity
        /// </summary>
        /// <param name="statusDesscription">A summary description fo the current status</param>
        /// <param name="secondsRemaining">The number fo secodns until the activity is complete</param>
        /// <param name="percentComplete">The relative amount of activity complete, where 1 = 1%</param>
        /// <returns>A Task that ends when completion is signaled</returns>
        void ReportProgress(string statusDesscription, int secondsRemaining, int percentComplete);

        /// <summary>
        /// Start a sub-activity of the current activity
        /// </summary>
        /// <returns>The child activity</returns>
        IActivity StartChildActivity();

        void ReportProgress(ITaskProgress progress);
    }
}
