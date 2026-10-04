// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.WebSites.Models
{
    /// <summary>
    /// API version 2025-05-01 split the virtual network connection model into a bare VnetInfo
    /// contract plus a VnetInfoResource ARM resource, dropping the ProxyOnlyResource base that
    /// VnetInfo carried in 2021-01-15. Az.Websites still surfaces VnetInfo on PSSite, so keep
    /// those members and let the two models convert.
    /// </summary>
    public partial class VnetInfo : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the VnetInfo class from its ARM resource counterpart.
        /// </summary>
        public VnetInfo(VnetInfoResource resource)
            : base(resource.Id, resource.Name, resource.Kind, resource.Type)
        {
            this.VnetResourceId = resource.VnetResourceId;
            this.CertThumbprint = resource.CertThumbprint;
            this.CertBlob = resource.CertBlob;
            this.Routes = resource.Routes;
            this.ResyncRequired = resource.ResyncRequired;
            this.DnsServers = resource.DnsServers;
            this.IsSwift = resource.IsSwift;
            CustomInit();
        }
    }
}
