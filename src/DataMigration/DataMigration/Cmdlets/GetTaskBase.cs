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

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public abstract class GetTaskBase : DataMigrationCmdlet
    {
        // Get parameter sets
        protected const string ListByComponent = "ListByComponent";
        protected const string GetByComponent = "GetByComponent";
        protected const string GetByComponentResultType = "GetByComponentResultType";
        protected const string ListByInputObject = "ListByInputObject";
        protected const string GetByInputObject = "GetByInputObject";
        protected const string GetByInputObjectResultType = "GetByInputObjectResultType";
        protected const string ListByResourceId = "ListByResourceId";
        protected const string GetByResourceId = "GetByResourceId";
        protected const string GetByResourceIdResultType = "GetByResourceIdResultType";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ListByComponent,
            HelpMessage = "The name of the resource group."
                )]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByComponent, Mandatory = true)]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ListByComponent,
            HelpMessage = "Database Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByComponent, Mandatory = true)]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        public string ServiceName { get; set; }

        [Parameter(
            ParameterSetName = GetByComponent,
            Mandatory = false,
            HelpMessage = "The name of the task.")]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ListByComponent,
            Mandatory = false,
            HelpMessage = "Filter by TaskType.")]
        [Parameter(ParameterSetName = ListByInputObject, Mandatory = false)]
        [Parameter(ParameterSetName = ListByResourceId, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public TaskTypeEnum? TaskType { get; set; }

        [Parameter(
            ParameterSetName = GetByComponent,
            Mandatory = false,
            HelpMessage = "Expand output")]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = false)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = false)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Expand { get; set; }

        [Parameter(
            ParameterSetName = GetByComponentResultType,
            Mandatory = true,
            HelpMessage = "Expand output of given result type.")]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ResultTypeEnum ResultType { get; set; }

        protected string ExpandFilter()
        {
            string expandFilter = null;

            if (Expand.IsPresent)
            {
                if (Expand && MyInvocation.BoundParameters.ContainsKey("ResultType"))
                {
                    if (ResultType.ToString().Equals(ResultTypeEnum.Command.ToString()))
                    {
                        expandFilter = "command";
                    }
                    else
                    {
                        expandFilter = string.Format("output($filter= ResultType eq '{0}')", ResultType.ToString());
                    }
                }
                else
                {
                    expandFilter = "output";
                }
            }

            return expandFilter;
        }
    }
}
