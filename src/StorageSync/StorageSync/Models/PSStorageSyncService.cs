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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    /// <summary>
    /// Class PSStorageSyncService.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Models.PSResourceBase" />
    public class PSStorageSyncService : PSResourceBase
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Ps1Xml(Label = "Location", Target = ViewControl.Table, Position = 4)]
        public string Location { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the storage sync service.
        /// </summary>
        /// <value>The name of the storage sync service.</value>
        [Ps1Xml(Label = "StorageSyncServiceName ", Target = ViewControl.Table, Position = 5)]
        public string StorageSyncServiceName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the incoming traffic policy.
        /// </summary>
        /// <value>The name of the incoming traffic policy.</value>
        [Ps1Xml(Label = "IncomingTrafficPolicy ", Target = ViewControl.Table, Position = 6)]
        public string IncomingTrafficPolicy { get; set; }
        
        /// <summary>
        /// Gets the private endpoint connections.
        /// </summary>
        /// <value>The private endpoint connections.</value>
        [Ps1Xml(Label = "PrivateEndpointConnections ", Target = ViewControl.Table, Position = 7)]
        public IList<PSPrivateEndpointConnection> PrivateEndpointConnections { get; set; }
        
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state.
        /// </summary>
        /// <value>The tags.</value>
        public string ProvisioningState { get; set; }
    }
}
