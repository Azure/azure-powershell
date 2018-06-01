using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobStepExecutionModel : AzureSqlElasticJobExecutionModel
    {
        /// <summary>
        /// Gets or sets the step name
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// Gets or sets the step id
        /// </summary>
        public int? StepId { get; set; }
    }
}