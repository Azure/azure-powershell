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


namespace Microsoft.Azure.Commands.PrivateDns.Models
{

    using System.Collections;

    public class PSPrivateDnsVirtualNetworkLink
    {
        /// <summary>
        /// Gets or sets the name of the virtual network link.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource Id of the virtual network link.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to which this zone belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the private zone that is associated with the virtual network link.
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// virtual network that is associated with the virtual network link.
        /// </summary>
        public string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the location to which this zone belongs.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Etag of this zone
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the tags of this resource
        /// </summary>
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets is auto-registration of virtual machine records in the
        /// virtual network in the Private DNS zone enabled?
        /// </summary>
        public bool RegistrationEnabled { get; set; }

        /// <summary>
        /// Gets the status of the virtual network link to the Private DNS
        /// zone. Possible values are 'InProgress' and 'Completed'. This is a
        /// read-only property and any attempt to set this value will be
        /// ignored. Possible values include: 'InProgress', 'Completed'
        /// </summary>
        public string VirtualNetworkLinkState { get; set; }

        /// <summary>
        /// Gets the provisioning state of the resource. This is a read-only
        /// property and any attempt to set this value will be ignored.
        /// Possible values include: 'Creating', 'Updating', 'Deleting',
        /// 'Succeeded', 'Failed', 'Canceled'
        /// </summary>
        public string ProvisioningState { get; set; }

    }
}
