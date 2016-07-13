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
    [Cmdlet(VerbsCommon.Remove, "AzureRmTrafficManagerProfile", SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
    public class RemoveAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the profile.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The profile.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public TrafficManagerProfile TrafficManagerProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            var deleted = false;
            TrafficManagerProfile profileToDelete = null;

            if (this.ParameterSetName == "Fields")
            {
                profileToDelete = new TrafficManagerProfile
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName
                };
            }
            else if (this.ParameterSetName == "Object")
            {
                profileToDelete = this.TrafficManagerProfile;
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(ProjectResources.Confirm_RemoveProfile, profileToDelete.Name),
                ProjectResources.Progress_RemovingProfile,
                this.Name,
                () =>
                {
                    deleted = this.TrafficManagerClient.DeleteTrafficManagerProfile(profileToDelete);
                    if (deleted)
                    {
                        this.WriteVerbose(ProjectResources.Success);
                        this.WriteVerbose(string.Format(ProjectResources.Success_RemoveProfile, profileToDelete.Name, profileToDelete.ResourceGroupName));
                    }

                    this.WriteObject(deleted);
                });
        }
    }
}
