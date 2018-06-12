using Microsoft.Azure.Management.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobExecutionModel : AzureSqlElasticJobBaseModel
    {
        /// <summary>
        /// Gets or sets the job execution id
        /// </summary>
        public Guid? JobExecutionId { get; set; }

        /// <summary>
        /// Gets or sets the job version
        /// </summary>
        public int? JobVersion { get; set; }

        /// <summary>
        /// Gets or sets the lifecycle
        /// </summary>
        public string Lifecycle { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the create time
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the current attempts
        /// </summary>
        public int? CurrentAttempts { get; set; }

        /// <summary>
        /// Gets or sets the current attempt start time
        /// </summary>
        public DateTime? CurrentAttemptStartTime { get; set; }

        /// <summary>
        /// Gets or sets the last message
        /// </summary>
        public string LastMessage { get; set; }
    }
}
