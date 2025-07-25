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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryRepository", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDeletedRepository))]
    public class RemoveAzureContainerRegistryRepository : ContainerRegistryDataPlaneCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteChildCmdlet()
        {
            if (this.ShouldProcess(string.Format("Delete {0} under {1}", this.Name, this.RegistryName)))
            {
                WriteObject(this.RegistryDataPlaneClient.RemoveRepository(this.Name));
            }
        }
    }
}
