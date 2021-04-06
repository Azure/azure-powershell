using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Automation.Models
{

    /// <summary>
    /// Software update configuration run tasks model. 
    /// Added temporarily to avoid breaking change
    /// </summary>
    public partial class SoftareUpdateConfigurationRunTasks
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SoftwareUpdateConfigurationRunTasks class.
        /// </summary>
        public SoftareUpdateConfigurationRunTasks()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SoftwareUpdateConfigurationRunTasks class.
        /// </summary>
        /// <param name="preTask">Pre task properties.</param>
        /// <param name="postTask">Post task properties.</param>
        public SoftareUpdateConfigurationRunTasks(SoftwareUpdateConfigurationRunTaskProperties preTask = default(SoftwareUpdateConfigurationRunTaskProperties), SoftwareUpdateConfigurationRunTaskProperties postTask = default(SoftwareUpdateConfigurationRunTaskProperties))
        {
            PreTask = preTask;
            PostTask = postTask;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets pre task properties.
        /// </summary>
        public SoftwareUpdateConfigurationRunTaskProperties PreTask { get; set; }

        /// <summary>
        /// Gets or sets post task properties.
        /// </summary>
        public SoftwareUpdateConfigurationRunTaskProperties PostTask { get; set; }

    }
}
