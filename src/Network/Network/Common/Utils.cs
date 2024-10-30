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
using System.Globalization;
using System.Management.Automation;
using System.Net;

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

    public static class FirewallConstants
    {
        public static readonly System.Collections.Generic.List<string> RestrictedBasicSkuFirewallRegions = new System.Collections.Generic.List<string>()
        {
            "TaiwanNorth","CanadaEast","JioIndiaWest", "PolandCentral", "SpainCentral", "USSecWestCentral", "BelgiumCentral", "GermanyNorth", "SwedenSouth", "ChinaEast3"
        };
        public static bool IsRegionRestrictedForBasicFirewall(string region)
        {
            if (!string.IsNullOrEmpty(region))
            {
                foreach (var reg in RestrictedBasicSkuFirewallRegions)
                {
                    if (String.Compare(reg, region, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public static class NetworkValidationUtils
    {
        public static void ValidateIpAddress(string ipAddress)
        {
            IPAddress ipVal;

            if (!IPAddress.TryParse(ipAddress, out ipVal) || ipVal.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                throw new PSArgumentException(String.Format("\'{0}\' is not a valid IPv4 address", ipAddress));
            }
        }

        public static void ValidateSubnet(string ipAddress)
        {
            ValidateIPv4CidrNotation(ipAddress);
        }

        private static void ValidateIPv4CidrNotation(string ipv4Cidr)
        {
            var subnet = ipv4Cidr.Split('/');
            if (subnet.Length != 2)
                throw new PSArgumentException(String.Format("\'{0}\' is not a valid IPv4 subnet", ipv4Cidr)); // Recommend proper format? e.g. 192.168.1.0/24

            uint address;
            if (!TryParseIPv4Address(subnet[0], out address))
            {
                throw new PSArgumentException(String.Format("The network prefix for \'{0}\' is not a valid IPv4 address", ipv4Cidr));
            }

            int host;
            if (!TryParseIPv4HostIdentifier(subnet[1], out host))
            {
                throw new PSArgumentException(String.Format("\'{0}\' is not a valid IPv4 subnet. The network mask should be an integer from 0 to 32", ipv4Cidr));
            }


            if (!isIpAddressCorrectlyMaskByNetworkPrefixLength(address, host))
            {
                uint recommendedAddressBits;
                string explanation = $"The network prefix for the CIDR string '{ipv4Cidr}' should be masked according to the suffix '{host}'.";
                if (TryApplyMask(address, host, out recommendedAddressBits))
                {
                    string recommendation = $"Try using '{uintToIPv4AddressString(recommendedAddressBits)}' instead.";
                    throw new PSArgumentException($"{explanation} {recommendation}");
                }
                else
                {
                    throw new PSArgumentException($"{explanation}");
                }
            }
        }

        private static string uintToIPv4AddressString(uint address)
        {
            var bytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bytes[i] = (byte)(address >> (8 * (3 - i)));
            }

            return String.Join(".", bytes);
        }

        private static bool isValidHostIdentifier(int host)
        {
            return host >= 0 && host <= 32;
        }

        /// <summary>
        /// Checks to see if an IP address (192.168.10.0) is correctly masked by the host identifier in IPv4 CIDR notation.
        /// ex. 192.168.1.0/24 is correctly masked, but 192.168.1.0/23 is not correctly masked
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="networkPrefixLength"></param>
        /// <returns></returns>
        private static bool isIpAddressCorrectlyMaskByNetworkPrefixLength(uint ipAddress, int networkPrefixLength)
        {
            if (!isValidHostIdentifier(networkPrefixLength)) return false;
            if (networkPrefixLength == 32) return true; // Accept /32 in all cases

            return (ipAddress << networkPrefixLength) == 0;
        }

        /// <summary>
        /// Tries to mask the non-network bits with 0, according to the prefixLength (if the length is valid).
        /// ex. 192.168.111.234/16 -> 192.168.0.0
        /// </summary>
        /// <param name="address"></param>
        /// <param name="prefixLength"></param>
        /// <param name="maskedAddress"></param>
        /// <returns></returns>
        private static bool TryApplyMask(uint address, int prefixLength, out uint maskedAddress)
        {
            maskedAddress = 0;
            if (!isValidHostIdentifier(prefixLength)) return false;
            int shift = (32 - prefixLength);
            maskedAddress = (address >> shift) << shift;

            return true;
        }

        /// <summary>
        /// Try to parse an IPv4 address string into a UInt32
        /// </summary>
        /// <param name="address"></param>
        /// <param name="parsed"></param>
        /// <returns></returns>
        private static bool TryParseIPv4Address(string address, out uint parsed)
        {
            parsed = 0;
            if (!IPAddress.TryParse(address, out var addr)) return false;
            byte[] bytes = addr.GetAddressBytes();

            for (int i = 0; i < 4; i++)
            {
                int amountToShift = (8 * (3 - i)); // 24, 16, 8, 0
                parsed += ((uint)bytes[i] << amountToShift);
            }

            return true;
        }

        private static bool TryParseIPv4HostIdentifier(string host, out int parsed)
        {
            return Int32.TryParse(host, out parsed) && isValidHostIdentifier(parsed);
        }
    }
}
