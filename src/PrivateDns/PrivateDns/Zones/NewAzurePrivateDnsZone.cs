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

namespace Microsoft.Azure.Commands.PrivateDns.Zones
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Creates a new zone.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZone", SupportsShouldProcess = true), OutputType(typeof(PSPrivateDnsZone))]
    public class NewAzurePrivateDnsZone : PrivateDnsBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The resource group in which to create the zone.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the zone (without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Name = TrimTrailingDotInZoneName(this.Name);

            ConfirmAction(
                ProjectResources.Progress_CreatingNewZone,
                this.Name,
                () =>
                {
                    var result = this.PrivateDnsClient.CreatePrivateDnsZone(
                        this.Name,
                        this.ResourceGroupName,
                        this.Tag);
                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteVerbose(string.Format(ProjectResources.Success_NewPrivateZone, this.Name, this.ResourceGroupName));
                    this.WriteObject(result);
                });
        }
    }
}
