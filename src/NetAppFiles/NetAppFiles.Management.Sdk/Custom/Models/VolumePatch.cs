// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Microsoft.Azure.Management.NetApp.Models
{
    using System.Linq;

    /// <summary>
    /// Backup patch
    /// </summary>    
    public partial class VolumePatch : Microsoft.Rest.Azure.IResource
    {
        /// <summary>
        /// Gets or sets set of protocol types, default NFSv3, CIFS for SMB protocol
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.protocolTypes")]
        public System.Collections.Generic.IList<string> ProtocolTypes { get; set; }

    }
}