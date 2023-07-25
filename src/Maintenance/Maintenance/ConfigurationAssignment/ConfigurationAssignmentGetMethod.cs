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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ConfigurationAssignment", DefaultParameterSetName = "DefaultParameter")]
    [OutputType(typeof(PSConfigurationAssignment))]
    public partial class GetAzureRmConfigurationAssignment : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string providerName = this.ProviderName;
                string resourceParentType = this.ResourceParentType;
                string resourceParentName = this.ResourceParentName;
                string resourceType = this.ResourceType;
                string resourceName = this.ResourceName;

                var result = (!string.IsNullOrEmpty(resourceParentType) && !string.IsNullOrEmpty(resourceParentName)) ?
                    ConfigurationAssignmentsClient.ListParent(resourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName) :
                    ConfigurationAssignmentsClient.List(resourceGroupName, providerName, resourceType, resourceName);

                var psObject = new List<PSConfigurationAssignment>();

                foreach (var configurationAssignment in result)
                {
                    PSConfigurationAssignment psConfigurationAssignment = new PSConfigurationAssignment();
                    MaintenanceAutomationAutoMapperProfile.Mapper.Map<ConfigurationAssignment, PSConfigurationAssignment>(configurationAssignment, psConfigurationAssignment);
                    psObject.Add(psConfigurationAssignment);
                }

                WriteObject(psObject);
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            Mandatory = true,
            HelpMessage = "The resource Group Name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            HelpMessage = "The resource provider Name.",
            ValueFromPipelineByPropertyName = true)]
        public string ProviderName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false,
            HelpMessage = "The parent resource type.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false,
            HelpMessage = "The parent resource name.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            HelpMessage = "The resource type.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            HelpMessage = "The resource name.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceName { get; set; }
    }
}
