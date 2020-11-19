namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Second level object represented in responses as part of Machine REST resource.</summary>
    public partial class VMwareNetworkAdapter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal
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

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>Label of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Label { get => this._label; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; }

        /// <summary>Internal Acessors for IPAddressList</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.IPAddressList { get => this._iPAddressList; set { {_iPAddressList = value;} } }

        /// <summary>Internal Acessors for IPAddressType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.IPAddressType { get => this._iPAddressType; set { {_iPAddressType = value;} } }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.Label { get => this._label; set { {_label = value;} } }

        /// <summary>Internal Acessors for MacAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.MacAddress { get => this._macAddress; set { {_macAddress = value;} } }

        /// <summary>Internal Acessors for NetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.NetworkName { get => this._networkName; set { {_networkName = value;} } }

        /// <summary>Internal Acessors for NicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapterInternal.NicId { get => this._nicId; set { {_nicId = value;} } }

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

        /// <summary>Creates an new <see cref="VMwareNetworkAdapter" /> instance.</summary>
        public VMwareNetworkAdapter()
        {

        }
    }
    /// Second level object represented in responses as part of Machine REST resource.
    public partial interface IVMwareNetworkAdapter :
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
        /// <summary>Label of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Label of the NIC.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get;  }
        /// <summary>Mac address of the NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Mac address of the NIC.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get;  }
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

    }
    /// Second level object represented in responses as part of Machine REST resource.
    internal partial interface IVMwareNetworkAdapterInternal

    {
        /// <summary>IP addresses for the machine.</summary>
        string[] IPAddressList { get; set; }
        /// <summary>Type of the IP address.</summary>
        string IPAddressType { get; set; }
        /// <summary>Label of the NIC.</summary>
        string Label { get; set; }
        /// <summary>Mac address of the NIC.</summary>
        string MacAddress { get; set; }
        /// <summary>Network Name.</summary>
        string NetworkName { get; set; }
        /// <summary>NIC Id.</summary>
        string NicId { get; set; }

    }
}