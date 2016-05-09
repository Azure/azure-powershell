// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------


using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AdminMetricDefinitionCmdlet : AdminCmdlet
    {
        /// <summary>
        /// Gets or sets the metricnames parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] MetricNames { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter DetailedOutput { get; set; }

        /// <summary>
        /// Get Metrics definition result
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected abstract MetricDefinitionsResult GetMetricDefinitionsResult(string filter);

        /// <summary>
        /// 
        /// </summary>
        protected override void Execute()
        {
            string filter = Tools.GenerateFilter(MetricNames);
            bool fullDetails = this.DetailedOutput.IsPresent;

            MetricDefinitionsResult definitions = GetMetricDefinitionsResult(filter);
            var result = definitions.Value.Select(_ => fullDetails ? new PSMetricDefinition(_) : new PSMetricDefinitionNoDetails(_));
            WriteObject(result);
        }
    }
}
