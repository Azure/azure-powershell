// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;

    // Development bridge for azure-rest-api-specs PR 46249. Replace with generated
    // support from the accepted specification before release.
    public partial class VirtualNetworkGatewayConnectionListEntityPropertiesFormat
    {
        /// <summary>
        /// Gets or sets whether FIPS compliance is enabled for this VPN connection.
        /// </summary>
        [JsonProperty(PropertyName = "enableFipsCompliance", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableFipsCompliance { get; set; }
    }
}