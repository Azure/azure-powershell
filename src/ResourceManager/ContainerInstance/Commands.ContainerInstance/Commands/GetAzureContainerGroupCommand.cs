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
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// Get-AzureRmContainerGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ContainerGroupNoun, DefaultParameterSetName = ListAllContainerGroupParamSet)]
    [OutputType(typeof(PSContainerGroup))]
    public class GetAzureContainerGroupCommand : ContainerInstanceCmdletBase
    {
        protected const string GetContainerGroupInResourceGroupParamSet = "GetContainerGroupInResourceGroupParamSet";
        protected const string ListContainerGroupInResourceGroupParamSet = "ListContainerGroupInResourceGroupParamSet";
        protected const string ListAllContainerGroupParamSet = "ListAllContainerGroupParamSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ListAllContainerGroupParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = GetContainerGroupInResourceGroupParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ListContainerGroupInResourceGroupParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = GetContainerGroupInResourceGroupParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The container group Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName) && !string.IsNullOrEmpty(this.Name))
            {
                var psContainerGroup = PSContainerGroup.FromContainerGroup(
                    this.ContainerClient.ContainerGroups.Get(this.ResourceGroupName, this.Name));
                this.WriteObject(psContainerGroup);
            }
            else
            {
                var psContainerGroups = new List<PSContainerGroup>();
                var containerGroups = this.ListContainerGroups();
                foreach (var containerGroup in containerGroups)
                {
                    psContainerGroups.Add(PSContainerGroup.FromContainerGroup(containerGroup));
                }

                while (!string.IsNullOrEmpty(containerGroups.NextPageLink))
                {
                    containerGroups = this.ListContainerGroupsNext(containerGroups.NextPageLink);
                    foreach (var containerGroup in containerGroups)
                    {
                        psContainerGroups.Add(PSContainerGroup.FromContainerGroup(containerGroup));
                    }
                }

                this.WriteObject(psContainerGroups, true);
            }
        }

        private IPage<ContainerGroup> ListContainerGroups()
        {
            return string.IsNullOrEmpty(this.ResourceGroupName)
                ? this.ContainerClient.ContainerGroups.List()
                : this.ContainerClient.ContainerGroups.ListByResourceGroup(this.ResourceGroupName);
        }

        private IPage<ContainerGroup> ListContainerGroupsNext(string nextPageLink)
        {
            return string.IsNullOrEmpty(this.ResourceGroupName)
                ? this.ContainerClient.ContainerGroups.ListNext(nextPageLink)
                : this.ContainerClient.ContainerGroups.ListByResourceGroupNext(nextPageLink);
        }
    }
}
