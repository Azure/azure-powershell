// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;

    // Development bridge until the Network API specification and SDK generation
    // include this property. Confirm the supported API contract before release,
    // and remove this declaration when the generated model supplies it.
    public partial class VpnClientConfiguration
    {
        /// <summary>
        /// Gets or sets whether FIPS compliance is enabled for point-to-site VPN connections.
        /// </summary>
        [JsonProperty(PropertyName = "enableFipsCompliance", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableFipsCompliance { get; set; }
    }
}