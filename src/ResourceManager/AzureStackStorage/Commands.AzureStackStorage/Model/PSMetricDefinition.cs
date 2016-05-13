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

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class PSMetricDefinition : PSMetricDefinitionNoDetails
    {
        /// <summary>
        /// Gets or sets the MetricAvailabilties of the metric
        /// </summary>
        public new PSAvailabilityCollection MetricAvailabilities { get; set; }

        /// <summary>
        /// Initializes an new instance of the PSMetricDefinition class
        /// </summary>
        /// <param name="metricDefinition">The MetricDefinition</param>
        public PSMetricDefinition(MetricDefinition metricDefinition) : base(metricDefinition)
        {
            this.MetricAvailabilities = new PSAvailabilityCollection(metricDefinition.MetricAvailabilities);
        }
    }
}
