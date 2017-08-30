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
using Microsoft.Azure.Management.ContainerInstance;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// Get-AzureRmContainerGroupLogs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ContainerLogsNoun), OutputType(typeof(string))]
    public class GetAzureContainerGroupLogsCommand : ContainerInstanceCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The container group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the container to tail the log, by default it's the same as container group name.")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        public override void ExecuteCmdlet()
        {
            var containerName = this.ContainerName ?? this.Name;
            var log = this.ContainerClient.ContainerLogs.List(this.ResourceGroupName, this.Name, containerName)?.Content;
            this.WriteObject(log);
        }
    }
}
