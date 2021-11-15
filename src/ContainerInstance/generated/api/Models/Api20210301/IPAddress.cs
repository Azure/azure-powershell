namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>IP address for the container group.</summary>
    public partial class IPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal
    {

        /// <summary>Backing field for <see cref="DnsNameLabel" /> property.</summary>
        private string _dnsNameLabel;

        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string DnsNameLabel { get => this._dnsNameLabel; set => this._dnsNameLabel = value; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; }

        /// <summary>Backing field for <see cref="IP" /> property.</summary>
        private string _iP;

        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string IP { get => this._iP; set => this._iP = value; }

        /// <summary>Internal Acessors for Fqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal.Fqdn { get => this._fqdn; set { {_fqdn = value;} } }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] _port;

        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType _type;

        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="IPAddress" /> instance.</summary>
        public IPAddress()
        {

        }
    }
    /// IP address for the container group.
    public partial interface IIPAddress :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Dns name label for the IP.",
        SerializedName = @"dnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string DnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The FQDN for the IP.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get;  }
        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP exposed to the public internet.",
        SerializedName = @"ip",
        PossibleTypes = new [] { typeof(string) })]
        string IP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of ports exposed on the container group.",
        SerializedName = @"ports",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] Port { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies if the IP is exposed to the public internet or private VNET.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType Type { get; set; }

    }
    /// IP address for the container group.
    internal partial interface IIPAddressInternal

    {
        /// <summary>The Dns name label for the IP.</summary>
        string DnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        string Fqdn { get; set; }
        /// <summary>The IP exposed to the public internet.</summary>
        string IP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] Port { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType Type { get; set; }

    }
}