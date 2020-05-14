namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetInfo resource specific properties</summary>
    public partial class VnetInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CertBlob" /> property.</summary>
        private string _certBlob;

        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CertBlob { get => this._certBlob; set => this._certBlob = value; }

        /// <summary>Backing field for <see cref="CertThumbprint" /> property.</summary>
        private string _certThumbprint;

        /// <summary>The client certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CertThumbprint { get => this._certThumbprint; }

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string _dnsServer;

        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Backing field for <see cref="IsSwift" /> property.</summary>
        private bool? _isSwift;

        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsSwift { get => this._isSwift; set => this._isSwift = value; }

        /// <summary>Internal Acessors for CertThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal.CertThumbprint { get => this._certThumbprint; set { {_certThumbprint = value;} } }

        /// <summary>Internal Acessors for ResyncRequired</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal.ResyncRequired { get => this._resyncRequired; set { {_resyncRequired = value;} } }

        /// <summary>Internal Acessors for Route</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal.Route { get => this._route; set { {_route = value;} } }

        /// <summary>Backing field for <see cref="ResyncRequired" /> property.</summary>
        private bool? _resyncRequired;

        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ResyncRequired { get => this._resyncRequired; }

        /// <summary>Backing field for <see cref="Route" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] _route;

        /// <summary>The routes that this Virtual Network connection uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get => this._route; }

        /// <summary>Backing field for <see cref="VnetResourceId" /> property.</summary>
        private string _vnetResourceId;

        /// <summary>The Virtual Network's resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetResourceId { get => this._vnetResourceId; set => this._vnetResourceId = value; }

        /// <summary>Creates an new <see cref="VnetInfoProperties" /> instance.</summary>
        public VnetInfoProperties()
        {

        }
    }
    /// VnetInfo resource specific properties
    public partial interface IVnetInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        Point-To-Site VPN connection.",
        SerializedName = @"certBlob",
        PossibleTypes = new [] { typeof(string) })]
        string CertBlob { get; set; }
        /// <summary>The client certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The client certificate thumbprint.",
        SerializedName = @"certThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string CertThumbprint { get;  }
        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string DnsServer { get; set; }
        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag that is used to denote if this is VNET injection",
        SerializedName = @"isSwift",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSwift { get; set; }
        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if a resync is required; otherwise, <code>false</code>.",
        SerializedName = @"resyncRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ResyncRequired { get;  }
        /// <summary>The routes that this Virtual Network connection uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The routes that this Virtual Network connection uses.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get;  }
        /// <summary>The Virtual Network's resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Network's resource ID.",
        SerializedName = @"vnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetResourceId { get; set; }

    }
    /// VnetInfo resource specific properties
    internal partial interface IVnetInfoPropertiesInternal

    {
        /// <summary>
        /// A certificate file (.cer) blob containing the public key of the private key used to authenticate a
        /// Point-To-Site VPN connection.
        /// </summary>
        string CertBlob { get; set; }
        /// <summary>The client certificate thumbprint.</summary>
        string CertThumbprint { get; set; }
        /// <summary>
        /// DNS servers to be used by this Virtual Network. This should be a comma-separated list of IP addresses.
        /// </summary>
        string DnsServer { get; set; }
        /// <summary>Flag that is used to denote if this is VNET injection</summary>
        bool? IsSwift { get; set; }
        /// <summary><code>true</code> if a resync is required; otherwise, <code>false</code>.</summary>
        bool? ResyncRequired { get; set; }
        /// <summary>The routes that this Virtual Network connection uses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[] Route { get; set; }
        /// <summary>The Virtual Network's resource ID.</summary>
        string VnetResourceId { get; set; }

    }
}