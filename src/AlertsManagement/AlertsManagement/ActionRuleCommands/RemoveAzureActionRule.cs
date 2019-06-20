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
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule")]
    [OutputType(typeof(bool))]
    public class RemoveAzureActionRule : AlertsManagementBaseCmdlet
    {
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByNameParameterSet = "ByName";

        #region Parameters declarations

        /// <summary>
        /// Resource Group name
        /// </summary>
        [Parameter(Mandatory = true,
                    ParameterSetName = ByNameParameterSet,
                    HelpMessage = "Resource Group name")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Action Rule name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByNameParameterSet,
                   HelpMessage = "Name of action rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource Id of Action rule
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByResourceIdParameterSet,
                   HelpMessage = "Get Action rule by resoure id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet, 
                    Mandatory = true, 
                    ValueFromPipeline = true, 
                    HelpMessage = "The action rule resource")]
        public PSActionRule InputObject { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ByResourceIdParameterSet:
                    break;
                
                case ByInputObjectParameterSet:
                    break;
                
                case ByNameParameterSet:
                    var isDeleted = this.AlertsManagementClient.ActionRules.DeleteWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name)
                            .Result;
                    break;
            }
           
        }
    }
}
