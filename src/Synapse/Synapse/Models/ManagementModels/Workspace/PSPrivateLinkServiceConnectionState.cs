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

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPrivateLinkServiceConnectionState
    {
        public PSPrivateLinkServiceConnectionState(PrivateLinkServiceConnectionState privateLinkServiceConnectionState)
        {
            this.Status = privateLinkServiceConnectionState?.Status;
            this.Description = privateLinkServiceConnectionState?.Description;
            this.ActionsRequired = privateLinkServiceConnectionState?.ActionsRequired;
        }

        /// <summary>
        /// Gets or sets the private link service connection status. Possible
        /// values include: 'Approved', 'Pending', 'Rejected', 'Disconnected'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the private link service connection description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the actions required for private link service connection.
        /// </summary>
        public string ActionsRequired { get; set; }
    }
}