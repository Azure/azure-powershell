namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt NIC details.</summary>
    public partial class VMwareCbtNicDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetailsInternal
    {

        /// <summary>Backing field for <see cref="IsPrimaryNic" /> property.</summary>
        private string _isPrimaryNic;

        /// <summary>A value indicating whether this is the primary NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsPrimaryNic { get => this._isPrimaryNic; set => this._isPrimaryNic = value; }

        /// <summary>Backing field for <see cref="IsSelectedForMigration" /> property.</summary>
        private string _isSelectedForMigration;

        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsSelectedForMigration { get => this._isSelectedForMigration; set => this._isSelectedForMigration = value; }

        /// <summary>Internal Acessors for NicId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetailsInternal.NicId { get => this._nicId; set { {_nicId = value;} } }

        /// <summary>Internal Acessors for SourceIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetailsInternal.SourceIPAddress { get => this._sourceIPAddress; set { {_sourceIPAddress = value;} } }

        /// <summary>Internal Acessors for SourceIPAddressType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetailsInternal.SourceIPAddressType { get => this._sourceIPAddressType; set { {_sourceIPAddressType = value;} } }

        /// <summary>Internal Acessors for SourceNetworkId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicDetailsInternal.SourceNetworkId { get => this._sourceNetworkId; set { {_sourceNetworkId = value;} } }

        /// <summary>Backing field for <see cref="NicId" /> property.</summary>
        private string _nicId;

        /// <summary>The NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicId { get => this._nicId; }

        /// <summary>Backing field for <see cref="SourceIPAddress" /> property.</summary>
        private string _sourceIPAddress;

        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceIPAddress { get => this._sourceIPAddress; }

        /// <summary>Backing field for <see cref="SourceIPAddressType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? _sourceIPAddressType;

        /// <summary>The source IP address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? SourceIPAddressType { get => this._sourceIPAddressType; }

        /// <summary>Backing field for <see cref="SourceNetworkId" /> property.</summary>
        private string _sourceNetworkId;

        /// <summary>Source network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceNetworkId { get => this._sourceNetworkId; }

        /// <summary>Backing field for <see cref="TargetIPAddress" /> property.</summary>
        private string _targetIPAddress;

        /// <summary>The target IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetIPAddress { get => this._targetIPAddress; set => this._targetIPAddress = value; }

        /// <summary>Backing field for <see cref="TargetIPAddressType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? _targetIPAddressType;

        /// <summary>The target IP address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? TargetIPAddressType { get => this._targetIPAddressType; set => this._targetIPAddressType = value; }

        /// <summary>Backing field for <see cref="TargetSubnetName" /> property.</summary>
        private string _targetSubnetName;

        /// <summary>Target subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetSubnetName { get => this._targetSubnetName; set => this._targetSubnetName = value; }

        /// <summary>Creates an new <see cref="VMwareCbtNicDetails" /> instance.</summary>
        public VMwareCbtNicDetails()
        {

        }
    }
    /// VMwareCbt NIC details.
    public partial interface IVMwareCbtNicDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>A value indicating whether this is the primary NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether this is the primary NIC.",
        SerializedName = @"isPrimaryNic",
        PossibleTypes = new [] { typeof(string) })]
        string IsPrimaryNic { get; set; }
        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether this NIC is selected for migration.",
        SerializedName = @"isSelectedForMigration",
        PossibleTypes = new [] { typeof(string) })]
        string IsSelectedForMigration { get; set; }
        /// <summary>The NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The NIC Id.",
        SerializedName = @"nicId",
        PossibleTypes = new [] { typeof(string) })]
        string NicId { get;  }
        /// <summary>The source IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source IP address.",
        SerializedName = @"sourceIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string SourceIPAddress { get;  }
        /// <summary>The source IP address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source IP address type.",
        SerializedName = @"sourceIPAddressType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? SourceIPAddressType { get;  }
        /// <summary>Source network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Source network Id.",
        SerializedName = @"sourceNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNetworkId { get;  }
        /// <summary>The target IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target IP address.",
        SerializedName = @"targetIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string TargetIPAddress { get; set; }
        /// <summary>The target IP address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target IP address type.",
        SerializedName = @"targetIPAddressType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? TargetIPAddressType { get; set; }
        /// <summary>Target subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target subnet name.",
        SerializedName = @"targetSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSubnetName { get; set; }

    }
    /// VMwareCbt NIC details.
    internal partial interface IVMwareCbtNicDetailsInternal

    {
        /// <summary>A value indicating whether this is the primary NIC.</summary>
        string IsPrimaryNic { get; set; }
        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        string IsSelectedForMigration { get; set; }
        /// <summary>The NIC Id.</summary>
        string NicId { get; set; }
        /// <summary>The source IP address.</summary>
        string SourceIPAddress { get; set; }
        /// <summary>The source IP address type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? SourceIPAddressType { get; set; }
        /// <summary>Source network Id.</summary>
        string SourceNetworkId { get; set; }
        /// <summary>The target IP address.</summary>
        string TargetIPAddress { get; set; }
        /// <summary>The target IP address type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.EthernetAddressType? TargetIPAddressType { get; set; }
        /// <summary>Target subnet name.</summary>
        string TargetSubnetName { get; set; }

    }
}