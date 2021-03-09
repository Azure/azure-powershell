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

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryRepository", DefaultParameterSetName = ListParameterSet)]
    [OutputType(typeof(string), typeof(PSRepositoryAttribute))]
    public class GetAzureContainerRegistryRepository : ContainerRegistryDataPlaneCmdletBase
    {
        [Parameter(ParameterSetName = GetParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ListParameterSet, Mandatory = false, HelpMessage = "First n results.")]
        [ValidateNotNullOrEmpty]
        public int? First { get; set; } = null;

        public override void ExecuteChildCmdlet()
        {
            if (this.IsParameterBound(c => c.Name))
            {
                WriteObject(this.RegistryDataPlaneClient.GetRepository(Name));
            }
            else
            {
                WriteObject(this.RegistryDataPlaneClient.ListRepository(First), true);
            }
        }
    }
}
