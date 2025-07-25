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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceStartStopSchedule",
        DefaultParameterSetName = DefaultParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceScheduleModel))]
    public class GetAzureSqlManagedInstanceSchedule : ManagedInstanceScheduleCmdletBase<IList<AzureSqlManagedInstanceScheduleModel>>
    {
        private const string DefaultParameterSet = "GetInstanceScheduleInputParameters";
        private const string InstanceModelParameterSet = "GetInstanceScheduleByInstanceModelInputParameters";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "The name of the Azure SQL Managed Instance", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance model.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InstanceModelParameterSet, ValueFromPipeline = true, HelpMessage = "Instance model input object.")]
        public AzureSqlManagedInstanceModel InstanceModel { get; set; }

        protected override IList<AzureSqlManagedInstanceScheduleModel> GetEntity()
        {
            if (ParameterSetName == InstanceModelParameterSet)
            {
                InstanceName = InstanceModel.ManagedInstanceName;
                ResourceGroupName = InstanceModel.ResourceGroupName;
            }

            return ModelAdapter.ListSchedule(ResourceGroupName, InstanceName);
        }
    }
}
