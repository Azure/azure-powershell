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
    using System.Management.Automation;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Deletes an existing zone.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsVirtualNetworkLink", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName),OutputType(typeof(bool))]
    public class RemoveAzurePrivateDnsVirtualNetworkLink : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ResourceParameterSetName = "ResourceId";
        private const string ObjectParameterSetName = "Object";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which the zone exists.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the zone associated with this virtual network link.", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the virtual network link.", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones/virtualNetworkLinks", "ResourceGroupName","ZoneName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The link object to remove.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsLink Link { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones/virtualNetworkLinks")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the Zone parameter for optimistic concurrency checks.", ParameterSetName = ObjectParameterSetName)]
        public SwitchParameter Overwrite { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            const bool deleted = true;
            var overwrite = this.Overwrite.IsPresent || this.ParameterSetName != ObjectParameterSetName;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                PrivateDnsUtils.GetResourceGroupNameZoneNameAndLinkNameFromLinkId(this.ResourceId, out var resourceGroupName, out var zoneName, out var linkName);
                this.ResourceGroupName = resourceGroupName;
                this.ZoneName = zoneName;
                this.Name = linkName;
            }

            if (!string.IsNullOrEmpty(this.ZoneName) && this.ZoneName.EndsWith("."))
            {
                this.ZoneName = this.ZoneName.TrimEnd('.');
                this.WriteWarning($"Modifying zone name to remove terminating '.'.  Zone name used is \"{this.ZoneName}\".");
            }

            var linkToDelete = (this.ParameterSetName != ObjectParameterSetName)
                ? this.PrivateDnsClient.GetLinkHandleNonExistentLink(this.ZoneName, this.ResourceGroupName, this.Name)
                : this.Link;

            if (linkToDelete == null)
            {
                this.WriteWarning(ProjectResources.Warning_InvalidLinkDetailsSpecified);
                return;
            }

            if ((string.IsNullOrWhiteSpace(linkToDelete.Etag) || linkToDelete.Etag == "*") && !overwrite)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsLink).Name));
            }

            if (linkToDelete.ZoneName != null && linkToDelete.ZoneName.EndsWith("."))
            {
                linkToDelete.ZoneName = linkToDelete.ZoneName.TrimEnd('.');
                this.WriteWarning($"Modifying zone name to remove terminating '.'.  Zone name used is \"{linkToDelete.ZoneName}\".");
            }

            ConfirmAction(
                ProjectResources.Progress_RemovingLink,
                linkToDelete.Name,
                () =>
                {
                    PrivateDnsClient.DeletePrivateDnsLink(linkToDelete, overwrite);

                    WriteVerbose(ProjectResources.Success);
                    WriteVerbose(string.Format(ProjectResources.Success_RemoveLink, linkToDelete.Name, linkToDelete.ResourceGroupName));

                    if (this.PassThru)
                    {
                        WriteObject(deleted);
                    }
                });
        }
    }
}
