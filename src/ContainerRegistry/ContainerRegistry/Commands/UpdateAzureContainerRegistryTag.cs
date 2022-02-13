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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.Commands
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryTag", SupportsShouldProcess = true)]
    [OutputType(typeof(PSTagAttribute))]
    public class UpdateAzureContainerRegistryTag : ContainerRegistryDataPlaneCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository Name.")]
        [ValidateNotNullOrEmpty]
        public string RepositoryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Tag.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Delete enable.")]
        [ValidateNotNullOrEmpty]
        public bool? DeleteEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Write enable.")]
        [ValidateNotNullOrEmpty]
        public bool? WriteEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List enable.")]
        [ValidateNotNullOrEmpty]
        public bool? ListEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Read enable.")]
        [ValidateNotNullOrEmpty]
        public bool? ReadEnabled { get; set; }

        public override void ExecuteChildCmdlet()
        {
            PSChangeableAttribute attribute = new PSChangeableAttribute(DeleteEnabled, WriteEnabled, ListEnabled, ReadEnabled);
            if (this.ShouldProcess(string.Format("Update {0}:{1} under {2}", this.RepositoryName, this.Name, this.RegistryName)))
            {
                WriteObject(this.RegistryDataPlaneClient.UpdateTag(this.RepositoryName, this.Name, attribute));
            }
        }
    }
}
