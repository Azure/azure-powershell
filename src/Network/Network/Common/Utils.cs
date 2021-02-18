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

using Microsoft.Azure.Commands.Network.Models;
using System;

namespace Microsoft.Azure.Commands.Network
{
    public class AddressTypeUtils
    {
        public static bool IsIpv4(string addressType)
        {
            if (string.Equals(addressType, "IPv4", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public static bool IsIpv6(string addressType)
        {
            if (string.Equals(addressType, "IPv6", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public static bool IsAll(string addressType)
        {
            if (string.Equals(addressType, "All", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }

    public class PeeringUtils
    {
        public static bool IsIpv4PrivatePeeringNull(PSPeering privatePeering)
        {
            if (privatePeering == null ||
                 (privatePeering.PrimaryPeerAddressPrefix == null &&
                  privatePeering.SecondaryPeerAddressPrefix == null))
            {
                return true;
            }
            return false;
        }
    }
}
