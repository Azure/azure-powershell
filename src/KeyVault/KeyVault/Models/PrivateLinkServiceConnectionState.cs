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

namespace Microsoft.Azure.Management.KeyVault.Models
{
    using Newtonsoft.Json;

    using System.Linq;

    /// <summary>
    /// An object that represents the approval state of the private link
    /// connection.
    /// </summary>
    public partial class PrivateLinkServiceConnectionState
    {
        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceConnectionState
        /// class.
        /// </summary>
        public PrivateLinkServiceConnectionState()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceConnectionState
        /// class.
        /// </summary>
        /// <param name="status">Indicates whether the connection has been
        /// approved, rejected or removed by the key vault owner. Possible
        /// values include: 'Pending', 'Approved', 'Rejected',
        /// 'Disconnected'</param>
        /// <param name="description">The reason for approval or
        /// rejection.</param>
        /// <param name="actionsRequired">A message indicating if changes on
        /// the service provider require any updates on the consumer. Possible
        /// values include: 'None'</param>
        public PrivateLinkServiceConnectionState(string status = default(string), string description = default(string), string actionsRequired = default(string))
        {
            Status = status;
            Description = description;
            ActionsRequired = actionsRequired;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets indicates whether the connection has been approved,
        /// rejected or removed by the key vault owner. Possible values
        /// include: 'Pending', 'Approved', 'Rejected', 'Disconnected'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the reason for approval or rejection.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a message indicating if changes on the service
        /// provider require any updates on the consumer. Possible values
        /// include: 'None'
        /// </summary>
        [JsonProperty(PropertyName = "actionsRequired")]
        public string ActionsRequired { get; set; }

        public string ActionRequired
        {
            get
            {
                return ActionsRequired;
            }

            set
            {
                ActionsRequired = value;
            }
        }
    }
}