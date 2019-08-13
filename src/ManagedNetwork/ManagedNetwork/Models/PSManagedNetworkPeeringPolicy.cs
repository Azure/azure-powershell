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

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ManagedNetwork.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSManagedNetworkPeeringPolicy : PSProxyResource
    {
        /// <summary>
        /// Gets or sets an type of policy
        /// </summary>
        public string PeeringPolicyType { get; set; }

        /// <summary>
        /// Gets or sets an Id for a Hub Vnet
        /// </summary>
        public PSResourceId Hub { get; set; }

        /// <summary>
        /// Gets or sets a list of Spoke Groups
        /// </summary>
        public List<PSResourceId> Spokes { get; set; }

        /// <summary>
        /// Gets or sets a list of Mesh Groups
        /// </summary>
        public List<PSResourceId> Mesh { get; set; }
    }
}