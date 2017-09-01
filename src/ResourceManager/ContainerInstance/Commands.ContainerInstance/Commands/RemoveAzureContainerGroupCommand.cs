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
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// Remove-AzureRmContainerGroup
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ContainerGroupNoun, SupportsShouldProcess = true), OutputType(typeof(PSContainerGroup))]
    public class RemoveAzureContainerGroupCommand : ContainerInstanceCmdletBase
    {
        protected const string RemoveContainerGroupByResourceGroupAndNameParamSet = "RemoveContainerGroupByResourceGroupAndNameParamSet";
        protected const string RemoveContainerGroupByPSContainerGroupParamSet = "RemoveContainerGroupByPSContainerGroupParamSet";
        protected const string RemoveContainerGroupByResourceIdParamSet = "RemoveContainerGroupByResourceIdParamSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = RemoveContainerGroupByResourceGroupAndNameParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = RemoveContainerGroupByResourceGroupAndNameParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The container group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = RemoveContainerGroupByPSContainerGroupParamSet,
            ValueFromPipeline = true,
            HelpMessage = "The container group to remove.")]
        [ValidateNotNullOrEmpty]
        public PSContainerGroup InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = RemoveContainerGroupByResourceIdParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "Remove Container Group"))
            {
                if (this.InputObject != null)
                {
                    this.ContainerClient.ContainerGroups.Delete(this.InputObject.ResourceGroupName, this.InputObject.Name);
                }
                else if (!string.IsNullOrEmpty(this.ResourceGroupName) && !string.IsNullOrEmpty(this.Name))
                {
                    this.ContainerClient.ContainerGroups.Delete(this.ResourceGroupName, this.Name);
                }
                else if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    this.ResourceClient.Resources.DeleteById(this.ResourceId, this.ResourceClient.ApiVersion);
                }
            }
        }
    }
}
