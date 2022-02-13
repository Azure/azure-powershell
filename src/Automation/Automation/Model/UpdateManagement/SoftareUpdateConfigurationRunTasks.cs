using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Automation.Models
{

    /// <summary>
    /// Softare update configuration run tasks model. 
    /// Added temporarily to avoid breaking change
    /// </summary>
    public partial class SoftareUpdateConfigurationRunTasks
    {
        /// <summary>
        /// Initializes a new instance of the
        /// SoftareUpdateConfigurationRunTasks class.
        /// </summary>
        public SoftareUpdateConfigurationRunTasks()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// SoftareUpdateConfigurationRunTasks class.
        /// </summary>
        /// <param name="preTask">Pre task properties.</param>
        /// <param name="postTask">Post task properties.</param>
        public SoftareUpdateConfigurationRunTasks(SoftareUpdateConfigurationRunTaskProperties preTask = default(SoftareUpdateConfigurationRunTaskProperties), SoftareUpdateConfigurationRunTaskProperties postTask = default(SoftareUpdateConfigurationRunTaskProperties))
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
        public SoftareUpdateConfigurationRunTaskProperties PreTask { get; set; }

        /// <summary>
        /// Gets or sets post task properties.
        /// </summary>
        public SoftareUpdateConfigurationRunTaskProperties PostTask { get; set; }

    }
}
