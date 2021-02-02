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

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Utils;
using Microsoft.Azure.Management.ContainerService.Models;

namespace Microsoft.Azure.Commands.Aks.Commands
{
    [Cmdlet(VerbsLifecycle.Enable, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksAddOn", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class EnableAzureRmAddons : UpdateAddonsBase
    {
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Id of the workspace of Monitoring.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet name of VirtualNode.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        protected override IDictionary<string, ManagedClusterAddonProfile> UpdateAddonsProfile(IDictionary<string, ManagedClusterAddonProfile> addonProfiles)
        {
            return AddonUtils.EnableAddonsProfile(addonProfiles, Name, nameof(Name), WorkspaceResourceId, nameof(WorkspaceResourceId), SubnetName, nameof(SubnetName));
        }
    }
}
