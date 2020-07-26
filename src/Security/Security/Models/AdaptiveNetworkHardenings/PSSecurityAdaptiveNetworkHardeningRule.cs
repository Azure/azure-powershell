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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening
{
    public class PSSecurityAdaptiveNetworkHardeningsRule
    {
        /// <summary>
        /// Gets the name of the rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the rule's direction.
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Gets the rule's destination port.
        /// </summary>
        public int? DestinationPort { get; set; }

        /// <summary>
        /// Gets the rule's transport protocols.
        /// </summary>
        public IList<string> Protocols { get; set; }

        /// <summary>
        /// Gets the remote IP addresses that should be able to communicate with the Azure resource on the rule's destination port and protocol.
        /// </summary>
        public IList<string> IpAddresses { get; set; }
    }
}
