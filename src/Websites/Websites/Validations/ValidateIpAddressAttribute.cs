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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Sockets;

namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateIpAddressAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var ipAddressArgumentValue = arguments as string;

            if (ipAddressArgumentValue.Any(Char.IsWhiteSpace))
                throw new ValidationMetadataException("Ip address(es) cannot contain blank spaces.");

            var ipAddresses = ipAddressArgumentValue.Split(',');

            if (ipAddresses.Length > 8)
                throw new ValidationMetadataException("Only 8 ip addresses are allowed per rule");

            if (!ipAddresses.All(a => this.IsValidCIDR(a)))
            {
                throw new ValidationMetadataException("One or more ip addresses are invalid. Ip adresses must be in valid CIDR format. E.g. 192.168.0.0/24 (IPv4) or 2002::1234:abcd:ffff:c0a8:101/64 (IPv6). For single ip addresses, use /32 (IPv4) or /128 (IPv6)");
            }            
        }

        private bool IsValidCIDR(string cidr)
        {
            if (string.IsNullOrEmpty(cidr))
            {
                return false;
            }

            var parts = cidr.Split('/');
            if (parts.Length != 2)
            {
                return false;
            }

            IPAddress ipAddress;
            if (!IPAddress.TryParse(parts[0], out ipAddress))
            {
                return false;
            }

            int prefixLength;
            if (!int.TryParse(parts[1], out prefixLength))
            {
                return false;
            }

            if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                return prefixLength >= 0 && prefixLength <= 32;
            }
            else if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return prefixLength >= 0 && prefixLength <= 128;
            }
            else
            {
                return false;
            }
        }
    }
}
