using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Represents Azure resource specific job class.
    /// </summary>
    public class AzureJob : JobBase
    {
        /// <summary>
        /// Represents whether this job is cancellable.
        /// </summary>
        public bool IsCancellable { get; set; }

        /// <summary>
        /// Represents whether this job is retriable.
        /// </summary>
        public bool IsRetriable { get; set; }

        /// <summary>
        /// Error details associated with this job.
        /// </summary>
        public List<AzureJobErrorInfo> ErrorDetails { get; set; }
    }

    /// <summary>
    /// Azure resource specific job error info class.
    /// </summary>
    public class AzureJobErrorInfo : JobErrorInfoBase
    {
        /// <summary>
        /// Error code of this job's error.
        /// </summary>
        public int ErrorCode { get; set; }
    }

    /// <summary>
    /// Azure resource specific job sub-task class.
    /// </summary>
    public class AzureJobSubTask : JobSubTaskBase { }
}
