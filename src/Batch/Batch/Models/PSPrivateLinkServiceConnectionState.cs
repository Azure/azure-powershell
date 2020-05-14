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

using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSPrivateLinkServiceConnectionState
    {
        /// <summary>
        /// Gets the status for the private endpoint connection of
        /// Batch account
        /// </summary>
        /// <remarks>
        /// Possible values include: 'Approved', 'Pending', 'Rejected',
        /// 'Disconnected'
        /// </remarks>
        public PrivateLinkServiceConnectionStatus Status { get; set; }

        /// <summary>
        /// Gets the description of the private Connection state
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the action required on the private connection state
        /// </summary>
        public string ActionRequired { get; }

        public PSPrivateLinkServiceConnectionState(PrivateLinkServiceConnectionStatus status, string description = default(string), string actionRequired = default(string))
        {
            Status = status;
            Description = description;
            ActionRequired = actionRequired;
        }

        internal static PSPrivateLinkServiceConnectionState CreateFromPrivateLinkServiceConnectionState(PrivateLinkServiceConnectionState privateLinkServiceConnectionState)
        {
            if (privateLinkServiceConnectionState == null)
            {
                return null;
            }

            return new PSPrivateLinkServiceConnectionState(
                privateLinkServiceConnectionState.Status,
                privateLinkServiceConnectionState.Description,
                privateLinkServiceConnectionState.ActionRequired);
        }
    }
}
