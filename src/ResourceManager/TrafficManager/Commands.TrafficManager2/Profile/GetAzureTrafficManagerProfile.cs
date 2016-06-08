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

using Microsoft.Azure.Commands.TrafficManager.Models;
using Microsoft.Azure.Commands.TrafficManager.Utilities;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.TrafficManager.Properties.Resources;

namespace Microsoft.Azure.Commands.TrafficManager
{
    [Cmdlet(VerbsCommon.Get, "AzureRmTrafficManagerProfile"), OutputType(typeof(TrafficManagerProfile))]
    public class GetAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource group to which the profile belongs.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ResourceGroupName == null && this.Name != null)
            {
                // Throw an error
            }
            else if (this.ResourceGroupName != null && this.Name != null)
            {
                TrafficManagerProfile profile = this.TrafficManagerClient.GetTrafficManagerProfile(this.ResourceGroupName, this.Name);

                this.WriteVerbose(ProjectResources.Success);
                this.WriteObject(profile);
            }
            else
            {
                TrafficManagerProfile[] profiles = this.TrafficManagerClient.ListTrafficManagerProfiles(this.ResourceGroupName);

                this.WriteVerbose(ProjectResources.Success);
                this.WriteObject(profiles);
            }
        }
    }
}
