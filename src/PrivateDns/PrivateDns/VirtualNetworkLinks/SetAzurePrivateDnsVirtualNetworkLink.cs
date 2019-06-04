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


namespace Microsoft.Azure.Commands.PrivateDns.VirtualNetworkLinks
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Updates an existing zone.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsVirtualNetworkLink", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName), OutputType(typeof(PSPrivateDnsVirtualNetworkLink))]
    public class SetAzurePrivateDnsVirtualNetworkLink : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ObjectParameterSetName = "Object";
        private const string ResourceParameterSetName = "ResourceId";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which the Private DNS zone/Virtual Network link exists.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the Private DNS zone (without a terminating dot).", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the virtual network link.", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones/virtualNetworkLinks", "ResourceGroupName", "ZoneName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The virtual network link object to set.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsVirtualNetworkLink InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones/virtualNetworkLinks")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Boolean that represents if registration is enabled on the virtual network link.")]
        [ValidateNotNullOrEmpty]
        public bool? IsRegistrationEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Switch parameter used to force update in case of mismatching Etags. Does not use the ETag field of the Link parameter for optimistic concurrency checks.", ParameterSetName = ObjectParameterSetName)]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            PSPrivateDnsVirtualNetworkLink result = null;
            PSPrivateDnsVirtualNetworkLink linkToUpdate = null;

            switch (this.ParameterSetName)
            {
                case FieldsParameterSetName:
                case ResourceParameterSetName:
                {
                    if (!string.IsNullOrEmpty(this.ResourceId))
                    {
                        PrivateDnsUtils.ParseVirtualNetworkId(this.ResourceId, out var resourceGroupName, out var zoneName, out var linkName);
                        this.ResourceGroupName = resourceGroupName;
                        this.ZoneName = zoneName;
                        this.Name = linkName;
                    }

                    this.ZoneName = TrimTrailingDotInZoneName(this.ZoneName);

                    linkToUpdate = this.PrivateDnsClient.GetPrivateDnsLink(this.Name, this.ResourceGroupName, this.ZoneName);
                    linkToUpdate.Etag = "*";
                    linkToUpdate.ZoneName = this.ZoneName;
                    break;
                }

                case ObjectParameterSetName when (string.IsNullOrWhiteSpace(this.InputObject.Etag) || this.InputObject.Etag == "*") && !this.Overwrite.IsPresent:
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsVirtualNetworkLink).Name));

                case ObjectParameterSetName:
                    linkToUpdate = this.InputObject;
                    break;
            }

            if (this.Tag != null)
            {
                linkToUpdate.Tags = this.Tag;
            }

            if (this.IsRegistrationEnabled != null)
            {
                linkToUpdate.RegistrationEnabled = this.IsRegistrationEnabled.Value;
            }

            ConfirmAction(
                ProjectResources.Progress_Modifying,
                linkToUpdate?.Name,
                () =>
                {
                    var overwrite = this.Overwrite.IsPresent || this.ParameterSetName != ObjectParameterSetName;
                    result = this.PrivateDnsClient.UpdatePrivateDnsLink(linkToUpdate, overwrite);

                    WriteVerbose(ProjectResources.Success);
                    WriteObject(result);
                });
        }
    }
}
