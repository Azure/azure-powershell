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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryManifest", DefaultParameterSetName = ListParameterSet)]
    [OutputType(typeof(PSManifestAttribute), typeof(PSAcrManifest))]
    public class GetAzureContainerRegistryManifest : ContainerRegistryDataPlaneCmdletBase
    {
        [Parameter(ParameterSetName = ListParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository Name.")]
        [Parameter(ParameterSetName = GetParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository Name.")]
        [ValidateNotNullOrEmpty]
        public string RepositoryName { get; set; }

        [Parameter(ParameterSetName = GetParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Manifest reference.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteChildCmdlet()
        {
            if (this.IsParameterBound(c => c.Name))
            {
                WriteObject(this.RegistryDataPlaneClient.GetManifest(RepositoryName, Name));
            }
            else
            {
                WriteObject(this.RegistryDataPlaneClient.ListManifest(RepositoryName), true);
            }
        }
    }
}