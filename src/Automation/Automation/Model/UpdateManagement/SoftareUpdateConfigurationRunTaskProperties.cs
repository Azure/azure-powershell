using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// Task properties of the software update configuration.
    /// </summary>
    public partial class SoftareUpdateConfigurationRunTaskProperties
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SoftwareUpdateConfigurationRunTaskProperties class.
        /// </summary>
        public SoftareUpdateConfigurationRunTaskProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SoftwareUpdateConfigurationRunTaskProperties class.
        /// </summary>
        /// <param name="status">The status of the task.</param>
        /// <param name="source">The name of the source of the task.</param>
        /// <param name="jobId">The job id of the task.</param>
        public SoftareUpdateConfigurationRunTaskProperties(string status = default(string), string source = default(string), string jobId = default(string))
        {
            Status = status;
            Source = source;
            JobId = jobId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the name of the source of the task.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the job id of the task.
        /// </summary>
        public string JobId { get; set; }

    }
}
