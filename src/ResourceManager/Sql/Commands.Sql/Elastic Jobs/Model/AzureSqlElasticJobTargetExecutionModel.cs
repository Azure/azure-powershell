using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobTargetExecutionModel : AzureSqlElasticJobStepExecutionModel
    {
        /// <summary>
        ///  Gets or sets the target server name
        /// </summary>
        public string TargetServerName { get; set; }

        /// <summary>
        /// Gets or sets the target database name
        /// </summary>
        public string TargetDatabaseName { get; set; }
    }
}