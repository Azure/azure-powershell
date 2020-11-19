namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Second level object represented in responses as part of Machine REST resource.</summary>
    public partial class HyperVNetworkAdapter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal
    {

        /// <summary>Backing field for <see cref="IPAddressList" /> property.</summary>
        private string[] _iPAddressList;

        /// <summary>IP addresses for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] IPAddressList { get => this._iPAddressList; }

        /// <summary>Backing field for <see cref="IPAddressType" /> property.</summary>
        private string _iPAddressType;

        /// <summary>Type of the IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddressType { get => this._iPAddressType; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; }

        /// <summary>Internal Acessors for IPAddressList</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.IPAddressList { get => this._iPAddressList; set { {_iPAddressList = value;} } }

        /// <summary>Internal Acessors for IPAddressType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.IPAddressType { get => this._iPAddressType; set { {_iPAddressType = value;} } }

        /// <summary>Internal Acessors for MacAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.MacAddress { get => this._macAddress; set { {_macAddress = value;} } }

        /// <summary>Internal Acessors for NetworkId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.NetworkId { get => this._networkId; set { {_networkId = value;} } }

        /// <summary>Internal Acessors for NetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.NetworkName { get => this._networkName; set { {_networkName = value;} } }

        /// <summary>Internal Acessors for NicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.NicId { get => this._nicId; set { {_nicId = value;} } }

        /// <summary>Internal Acessors for NicType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.NicType { get => this._nicType; set { {_nicType = value;} } }

        /// <summary>Internal Acessors for StaticIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.StaticIPAddress { get => this._staticIPAddress; set { {_staticIPAddress = value;} } }

        /// <summary>Internal Acessors for SubnetName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal.SubnetName { get => this._subnetName; set { {_subnetName = value;} } }

        /// <summary>Backing field for <see cref="NetworkId" /> property.</summary>
        private string _networkId;

        /// <summary>Network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkId { get => this._networkId; }

        /// <summary>Backing field for <see cref="NetworkName" /> property.</summary>
        private string _networkName;

        /// <summary>Network Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkName { get => this._networkName; }

        /// <summary>Backing field for <see cref="NicId" /> property.</summary>
        private string _nicId;

        /// <summary>NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicId { get => this._nicId; }

        /// <summary>Backing field for <see cref="NicType" /> property.</summary>
        private string _nicType;

        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicType { get => this._nicType; }

        /// <summary>Backing field for <see cref="StaticIPAddress" /> property.</summary>
        private string _staticIPAddress;

        /// <summary>Static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StaticIPAddress { get => this._staticIPAddress; }

        /// <summary>Backing field for <see cref="SubnetName" /> property.</summary>
        private string _subnetName;

        /// <summary>Name of the VM subnet within the virtual network the NIC is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SubnetName { get => this._subnetName; }

        /// <summary>Creates an new <see cref="HyperVNetworkAdapter" /> instance.</summary>
        public HyperVNetworkAdapter()
        {

        }
    }
    /// Second level object represented in responses as part of Machine REST resource.
    public partial interface IHyperVNetworkAdapter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>IP addresses for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"IP addresses for the machine.",
        SerializedName = @"ipAddressList",
        PossibleTypes = new [] { typeof(string) })]
        string[] IPAddressList { get;  }
        /// <summary>Type of the IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the IP address.",
        SerializedName = @"ipAddressType",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressType { get;  }
        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Mac address of the NIC.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get;  }
        /// <summary>Network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network Id.",
        SerializedName = @"networkId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkId { get;  }
        /// <summary>Network Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network Name.",
        SerializedName = @"networkName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkName { get;  }
        /// <summary>NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"NIC Id.",
        SerializedName = @"nicId",
        PossibleTypes = new [] { typeof(string) })]
        string NicId { get;  }
        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Mac address of the NIC.",
        SerializedName = @"nicType",
        PossibleTypes = new [] { typeof(string) })]
        string NicType { get;  }
        /// <summary>Static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Static IP address.",
        SerializedName = @"staticIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StaticIPAddress { get;  }
        /// <summary>Name of the VM subnet within the virtual network the NIC is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the VM subnet within the virtual network the NIC is attached to.",
        SerializedName = @"subnetName",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get;  }

    }
    /// Second level object represented in responses as part of Machine REST resource.
    internal partial interface IHyperVNetworkAdapterInternal

    {
        /// <summary>IP addresses for the machine.</summary>
        string[] IPAddressList { get; set; }
        /// <summary>Type of the IP address.</summary>
        string IPAddressType { get; set; }
        /// <summary>Mac address of the NIC.</summary>
        string MacAddress { get; set; }
        /// <summary>Network Id.</summary>
        string NetworkId { get; set; }
        /// <summary>Network Name.</summary>
        string NetworkName { get; set; }
        /// <summary>NIC Id.</summary>
        string NicId { get; set; }
        /// <summary>Mac address of the NIC.</summary>
        string NicType { get; set; }
        /// <summary>Static IP address.</summary>
        string StaticIPAddress { get; set; }
        /// <summary>Name of the VM subnet within the virtual network the NIC is attached to.</summary>
        string SubnetName { get; set; }

    }
}