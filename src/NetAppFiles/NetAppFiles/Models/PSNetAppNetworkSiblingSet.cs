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

using Microsoft.Azure.Management.NetApp.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppNetworkSiblingSet
    {
        /// <summary>
        /// Gets or sets network Sibling Set ID for a group of volumes sharing
        /// networking resources in a subnet.
        /// </summary>        
        public string NetworkSiblingSetId { get; set; }

        /// <summary>
        /// Gets or sets the Azure Resource URI for a delegated subnet. Must have the
        /// delegation Microsoft.NetApp/volumes. Example
        /// /subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/testVnet/subnets/{mySubnet}
        /// </summary>        
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets network sibling set state Id identifying the current state of
        /// the sibling set.
        /// </summary>        
        public string NetworkSiblingSetStateId { get; set; }

        /// <summary>
        /// Gets or sets network features available to the volume, or current state of
        /// update. Possible values include: &#39;Basic&#39;, &#39;Standard&#39;, &#39;Basic_Standard&#39;, &#39;Standard_Basic&#39;
        /// </summary>        
        public string NetworkFeatures { get; set; }

        /// <summary>
        /// Gets gets the status of the NetworkSiblingSet at the time the operation was
        /// called. Possible values include: &#39;Succeeded&#39;, &#39;Failed&#39;, &#39;Canceled&#39;, &#39;Updating&#39;
        /// </summary>        
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets list of NIC information
        /// </summary>        
        public List<PSNetAppNicInfo> NicInfoList { get; set; }

    }
}
