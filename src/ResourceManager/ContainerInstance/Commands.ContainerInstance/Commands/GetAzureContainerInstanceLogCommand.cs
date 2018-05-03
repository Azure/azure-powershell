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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// Get-AzureRmContainerGroupLogs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ContainerInstanceLogNoun, DefaultParameterSetName = GetContainerInstanceLogByNamesParamSet)]
    [OutputType(typeof(string))]
    public class GetAzureContainerInstanceLogCommand : ContainerInstanceCmdletBase
    {
        protected const string GetContainerInstanceLogByNamesParamSet = "GetContainerInstanceLogByNamesParamSet";
        protected const string GetContainerInstanceLogByPSContainerGroupParamSet = "GetContainerInstanceLogByPSContainerGroupParamSet";
        protected const string GetContainerInstanceLogByResourceIdParamSet = "GetContainerInstanceLogByResourceIdParamSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = GetContainerInstanceLogByNamesParamSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetContainerInstanceLogByNamesParamSet,
            HelpMessage = "The container group name.")]
        [ValidateNotNullOrEmpty]
        public string ContainerGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetContainerInstanceLogByPSContainerGroupParamSet,
            ValueFromPipeline = true,
            HelpMessage = "The input container group object.")]
        [ValidateNotNullOrEmpty]
        public PSContainerGroup InputContainerGroup { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetContainerInstanceLogByResourceIdParamSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The container instance name in the container group. Default: the same as the container group name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of lines to tail the log. If not specify, the cmdlet will return up to 4MB tailed log")]
        [ValidateNotNullOrEmpty]
        public int? Tail { get; set; }

        public override void ExecuteCmdlet()
        {
            var resourceGroupName = this.InputContainerGroup?.ResourceGroupName ?? this.ResourceGroupName;
            var containerGroupName = this.InputContainerGroup?.Name ?? this.ContainerGroupName;

            if (string.IsNullOrWhiteSpace(resourceGroupName)
                && string.IsNullOrWhiteSpace(containerGroupName)
                && !string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var resource = this.ResourceClient.Resources.GetById(this.ResourceId, this.ContainerClient.ApiVersion);
                resourceGroupName = this.ParseResourceGroupFromResourceId(this.ResourceId);
                containerGroupName = resource?.Name;
            }

            var containerName = this.Name ?? containerGroupName;

            var log = this.ContainerClient.ContainerLogs.List(resourceGroupName, containerGroupName, containerName, this.Tail)?.Content;

            this.WriteObject(log);
        }
    }
}
