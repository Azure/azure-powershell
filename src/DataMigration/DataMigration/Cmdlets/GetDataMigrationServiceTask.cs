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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationServiceTask", DefaultParameterSetName = ListByComponent), OutputType(typeof(PSProjectTask))]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsServiceTask")]
    public class GetDataMigrationServiceTask : GetTaskBase
    {
        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = ListByInputObject,
          ValueFromPipeline = true,
          HelpMessage = "PSDataMigrationService Object.")]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [ValidateNotNull]
        [Alias("Service")]
        public PSDataMigrationService InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ListByResourceId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Resource Id.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(GetByInputObject) ||
                this.ParameterSetName.Equals(ListByInputObject) ||
                this.ParameterSetName.Equals(GetByInputObjectResultType))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.ServiceName = InputObject.Name;
            }

            if (this.ParameterSetName.Equals(GetByResourceId) ||
                this.ParameterSetName.Equals(ListByResourceId) ||
                this.ParameterSetName.Equals(GetByResourceIdResultType))
            {
                DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = ids.ResourceGroupName;
                this.ServiceName = ids.ServiceName;
            }

            IList<PSProjectTask> results = new List<PSProjectTask>();

            if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(this.ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(this.ResourceGroupName))
                && (MyInvocation.BoundParameters.ContainsKey("Name") || !string.IsNullOrEmpty(this.Name)))
            {
                results.Add(new PSProjectTask(DataMigrationClient.ServiceTasks.Get(this.ResourceGroupName, this.ServiceName, this.Name, this.ExpandFilter())));
            }
            else if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(this.ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(this.ResourceGroupName)))
            {
                string taskType = TaskType?.ToString();
                DataMigrationClient.ServiceTasks.EnumerateServiceTaskByService(ResourceGroupName, ServiceName, taskType)
                    .ForEach(item =>
                    {
                        results.Add(new PSProjectTask(item));
                    });
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            WriteObject(results, true);
        }
    }
}
