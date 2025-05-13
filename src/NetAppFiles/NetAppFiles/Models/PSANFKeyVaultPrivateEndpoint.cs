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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// Pairs of virtual network ID and private endpoint ID. Every virtual network that has volumes encrypted with customer-managed keys needs its own key vault private endpoint.
    /// </summary>
    public class PSANFKeyVaultPrivateEndpoint
    {
        /// <summary>
        /// Gets or sets the ARM resource identifier of the virtual network
        /// </summary>        
        public string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the ARM resource identifier of the private endpoint to reach the Azure Key Vault
        /// </summary>        
        public string PrivateEndpointId { get; set; }


    }
}
