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

using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    /// <summary>
    /// Represents network configuration for a NetInterface
    /// </summary>
    public class NetworkConfig
    {
        /// <summary>
        /// Is network interface iscsi enabled.
        /// </summary>
        public bool? IsIscsiEnabled { get; set; }

        /// <summary>
        /// Is network interface cloud enabled
        /// </summary>
        public bool? IsCloudEnabled { get; set; }

        /// <summary>
        /// Ip Address of Controller0. To be set only on Data0
        /// </summary>
        public IPAddress Controller0IPv4Address { get; set; }

        /// <summary>
        /// Ip Address of Controller1. To be set only on Data0
        /// </summary>
        public IPAddress Controller1IPv4Address { get; set; }

        /// <summary>
        /// IPv6 gateway
        /// </summary>
        public IPAddress IPv6Gateway { get; set; }

        /// <summary>
        /// IPv4Gateway
        /// </summary>
        public IPAddress IPv4Gateway { get; set; }

        /// <summary>
        /// IPv4 Address
        /// </summary>
        public IPAddress IPv4Address { get; set; }

        /// <summary>
        /// IPv6 prefix
        /// </summary>
        public string IPv6Prefix { get; set; }

        /// <summary>
        /// IPv4 netmask
        /// </summary>
        public IPAddress IPv4Netmask { get; set; }

        /// <summary>
        /// Id of NetInterface
        /// </summary>
        public NetInterfaceId InterfaceAlias { get; set; }
    }
}
