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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Numerics;

    using Microsoft.Azure.Commands.Peering.Properties;

    public class RoutePrefix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePrefix"/> class.
        /// </summary>
        /// <param name="routePrefix">route prefix as string</param>
        public RoutePrefix(string routePrefix)
        {
            if (string.IsNullOrEmpty(routePrefix))
            {
                throw new ArgumentNullException(nameof(routePrefix));
            }

            var parts = routePrefix.Split('/');

            if (parts.Length != 2)
            {
                throw new ArgumentException(
                    string.Format(Resources.Route_PrefixUnrecognized, routePrefix));
            }

            // get and validate the prefix length mask into a number
            if (!ushort.TryParse(parts[1], out var prefixLength))
            {
                throw new FormatException(
                    string.Format(
                        Resources.Route_NotProperCIDR,
                        routePrefix));
            }

            // get and validate the IP address part
            if (!IPAddress.TryParse(parts[0], out var address))
            {
                throw new FormatException(
                    string.Format(
                        Resources.Route_NotProperCIDR,
                        routePrefix));
            }

            // Init
            this.Init(address, prefixLength, true);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePrefix"/> class.
        /// </summary>
        /// <param name="address">IP Address</param>
        /// <param name="prefixLength">Length of prefix</param>
        public RoutePrefix(IPAddress address, ushort prefixLength)
        {
            // Init
            this.Init(address, prefixLength, true);
        }

        /// <summary>
        /// Gets start IPAddress
        /// </summary>
        public IPAddress StartIp { get; private set; }

        /// <summary>
        /// Gets mask width
        /// </summary>
        public ushort PrefixMaskWidth { get; private set; }

        /// <summary>
        /// Gets the address family.
        /// </summary>
        public AddressFamily PrefixAddressFamily => this.StartIp.AddressFamily;

        /// <summary>
        /// Gets number of IPAddress in the Prefix
        /// </summary>
        public BigInteger Length
        {
            get
            {
                switch (this.PrefixAddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        return BigInteger.Pow(2, 32 - this.PrefixMaskWidth);
                    case AddressFamily.InterNetworkV6:
                        return BigInteger.Pow(2, 128 - this.PrefixMaskWidth);
                }

                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Unrecognized Address family {0}",
                        this.PrefixAddressFamily));
            }
        }

        /// <summary>
        /// Gets or sets StartOfPrefixBigINT
        /// For internal use of compares
        /// </summary>
        public BigInteger StartOfPrefixBigInt { get; set; }

        /// <summary>
        /// Gets or sets the actual prefix big int.
        /// </summary>
        public BigInteger ActualPrefixBigInt { get; set; }

        /// <summary>
        /// Gets or sets EndOfPrefixBigINT
        /// For internal use of compares
        /// </summary>
        public BigInteger EndOfPrefixBigInt { get; set; }

        /// <summary>
        /// Gets Valid prefix from invalid prefix
        /// </summary>
        /// <param name="routePrefix">route prefix string</param>
        /// <returns></returns>
        public static RoutePrefix GetValidPrefix(string routePrefix)
        {
            if (string.IsNullOrEmpty(routePrefix))
            {
                throw new ArgumentNullException(nameof(routePrefix));
            }

            var parts = routePrefix.Split('/');

            if (parts.Length != 2)
            {
                throw new ArgumentException(
                    string.Format(Resources.Route_PrefixUnrecognized, routePrefix));
            }

            // get and validate the prefix length mask into a number
            if (!ushort.TryParse(parts[1], out var prefixLength))
            {
                throw new FormatException(
                    string.Format(
                        Resources.Route_NotProperCIDR,
                        routePrefix));
            }

            // get and validate the IP address part
            if (!IPAddress.TryParse(parts[0], out var address))
            {
                throw new FormatException(
                    string.Format(
                        Resources.Route_NotProperCIDR,
                        routePrefix));
            }

            var bitArray = address.BigUIntFromIpAddress().ToBitArray(address.AddressFamily);

            var startIndex = address.AddressFamily == AddressFamily.InterNetwork ? 32 : 128;

            for (var index = startIndex - 1; index >= prefixLength; index--)
            {
                bitArray[index] = false;
            }

            var routeReturnPrefix = new RoutePrefix(bitArray.ToIpAddress(), prefixLength);
            routeReturnPrefix.ActualPrefixBigInt = address.BigUIntFromIpAddress();

            return routeReturnPrefix;
        }

        /// <summary>
        /// Initialize properties
        /// </summary>
        /// <param name="address">IP Address</param>
        /// <param name="prefixLength">Length of prefix</param>
        /// <param name="validate">If true it will validate route prefix</param>
        private void Init(IPAddress address, ushort prefixLength, bool validate)
        {
            var length = BigInteger.Pow(
                2,
                address.AddressFamily == AddressFamily.InterNetwork ? (32 - prefixLength) : (128 - prefixLength));

            this.StartIp = address;
            this.PrefixMaskWidth = prefixLength;
            this.StartOfPrefixBigInt = address.BigUIntFromIpAddress();
            this.EndOfPrefixBigInt = this.StartOfPrefixBigInt + (length - 1);

            // Validate if true
            if (validate)
            {
                this.IsValid(this.StartOfPrefixBigInt, this.PrefixMaskWidth, address.AddressFamily);
            }
        }

        /// <summary>
        /// Check if the RoutePrefix is valid prefix or not
        /// </summary>
        /// <param name="startBigInt">Start of IPAddress in Bigint</param>
        /// <param name="prefixMask">Prefix Mask</param>
        /// <param name="addressFamily">Address family</param>
        /// <returns>None</returns>
        private void IsValid(BigInteger startBigInt, ushort prefixMask, AddressFamily addressFamily)
        {
            var bitArray = startBigInt.ToBitArray(addressFamily);

            for (var i = prefixMask; i < bitArray.Length; i++)
            {
                if (bitArray[i])
                {
                    throw new InvalidDataException(
                        string.Format(Resources.Route_PrefixUnrecognized, $"{startBigInt.ToIpAddress(addressFamily)}/{prefixMask}"));
                }
            }
        }
    }
}
