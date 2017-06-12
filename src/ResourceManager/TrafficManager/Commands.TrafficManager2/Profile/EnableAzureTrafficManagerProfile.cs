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
    [Cmdlet(VerbsLifecycle.Enable, "AzureRmTrafficManagerProfile"), OutputType(typeof(bool))]
    public class EnableAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the profile.", ParameterSetName = TrafficManagerBaseCmdlet.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.", ParameterSetName = TrafficManagerBaseCmdlet.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile.", ParameterSetName = TrafficManagerBaseCmdlet.ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroup = this.ParameterSetName == TrafficManagerBaseCmdlet.FieldsParameterSet ? this.ResourceGroupName : this.TrafficManagerProfile.ResourceGroupName;
            string profileName = this.ParameterSetName == TrafficManagerBaseCmdlet.FieldsParameterSet ? this.Name : this.TrafficManagerProfile.Name;

            bool enabled = this.TrafficManagerClient.EnableTrafficManagerProfile(resourceGroup, profileName);

            if (enabled)
            {
                this.WriteVerbose(ProjectResources.Success);
                this.WriteVerbose(string.Format(ProjectResources.Success_EnableProfile, profileName, resourceGroup));
            }

            this.WriteObject(enabled);
        }
    }
}
