namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper V VM network details.</summary>
    public partial class VMNicDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal
    {

        /// <summary>
        /// Backing field for <see cref="EnableAcceleratedNetworkingOnRecovery" /> property.
        /// </summary>
        private bool? _enableAcceleratedNetworkingOnRecovery;

        /// <summary>A value indicating whether the NIC has accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableAcceleratedNetworkingOnRecovery { get => this._enableAcceleratedNetworkingOnRecovery; set => this._enableAcceleratedNetworkingOnRecovery = value; }

        /// <summary>Backing field for <see cref="IPAddressType" /> property.</summary>
        private string _iPAddressType;

        /// <summary>Ip address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddressType { get => this._iPAddressType; set => this._iPAddressType = value; }

        /// <summary>Backing field for <see cref="NicId" /> property.</summary>
        private string _nicId;

        /// <summary>The nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicId { get => this._nicId; set => this._nicId = value; }

        /// <summary>Backing field for <see cref="PrimaryNicStaticIPAddress" /> property.</summary>
        private string _primaryNicStaticIPAddress;

        /// <summary>Primary nic static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryNicStaticIPAddress { get => this._primaryNicStaticIPAddress; set => this._primaryNicStaticIPAddress = value; }

        /// <summary>Backing field for <see cref="RecoveryNicIPAddressType" /> property.</summary>
        private string _recoveryNicIPAddressType;

        /// <summary>IP allocation type for recovery VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryNicIPAddressType { get => this._recoveryNicIPAddressType; set => this._recoveryNicIPAddressType = value; }

        /// <summary>Backing field for <see cref="RecoveryVMNetworkId" /> property.</summary>
        private string _recoveryVMNetworkId;

        /// <summary>Recovery VM network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryVMNetworkId { get => this._recoveryVMNetworkId; set => this._recoveryVMNetworkId = value; }

        /// <summary>Backing field for <see cref="RecoveryVMSubnetName" /> property.</summary>
        private string _recoveryVMSubnetName;

        /// <summary>Recovery VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryVMSubnetName { get => this._recoveryVMSubnetName; set => this._recoveryVMSubnetName = value; }

        /// <summary>Backing field for <see cref="ReplicaNicId" /> property.</summary>
        private string _replicaNicId;

        /// <summary>The replica nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaNicId { get => this._replicaNicId; set => this._replicaNicId = value; }

        /// <summary>Backing field for <see cref="ReplicaNicStaticIPAddress" /> property.</summary>
        private string _replicaNicStaticIPAddress;

        /// <summary>Replica nic static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ReplicaNicStaticIPAddress { get => this._replicaNicStaticIPAddress; set => this._replicaNicStaticIPAddress = value; }

        /// <summary>Backing field for <see cref="SelectionType" /> property.</summary>
        private string _selectionType;

        /// <summary>Selection type for failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SelectionType { get => this._selectionType; set => this._selectionType = value; }

        /// <summary>Backing field for <see cref="SourceNicArmId" /> property.</summary>
        private string _sourceNicArmId;

        /// <summary>The source nic ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceNicArmId { get => this._sourceNicArmId; set => this._sourceNicArmId = value; }

        /// <summary>Backing field for <see cref="VMNetworkName" /> property.</summary>
        private string _vMNetworkName;

        /// <summary>VM network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMNetworkName { get => this._vMNetworkName; set => this._vMNetworkName = value; }

        /// <summary>Backing field for <see cref="VMSubnetName" /> property.</summary>
        private string _vMSubnetName;

        /// <summary>VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMSubnetName { get => this._vMSubnetName; set => this._vMSubnetName = value; }

        /// <summary>Creates an new <see cref="VMNicDetails" /> instance.</summary>
        public VMNicDetails()
        {

        }
    }
    /// Hyper V VM network details.
    public partial interface IVMNicDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>A value indicating whether the NIC has accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the NIC has accelerated networking enabled.",
        SerializedName = @"enableAcceleratedNetworkingOnRecovery",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAcceleratedNetworkingOnRecovery { get; set; }
        /// <summary>Ip address type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ip address type.",
        SerializedName = @"ipAddressType",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressType { get; set; }
        /// <summary>The nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The nic Id.",
        SerializedName = @"nicId",
        PossibleTypes = new [] { typeof(string) })]
        string NicId { get; set; }
        /// <summary>Primary nic static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Primary nic static IP address.",
        SerializedName = @"primaryNicStaticIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryNicStaticIPAddress { get; set; }
        /// <summary>IP allocation type for recovery VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP allocation type for recovery VM.",
        SerializedName = @"recoveryNicIpAddressType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryNicIPAddressType { get; set; }
        /// <summary>Recovery VM network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery VM network Id.",
        SerializedName = @"recoveryVMNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryVMNetworkId { get; set; }
        /// <summary>Recovery VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery VM subnet name.",
        SerializedName = @"recoveryVMSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryVMSubnetName { get; set; }
        /// <summary>The replica nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replica nic Id.",
        SerializedName = @"replicaNicId",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaNicId { get; set; }
        /// <summary>Replica nic static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Replica nic static IP address.",
        SerializedName = @"replicaNicStaticIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicaNicStaticIPAddress { get; set; }
        /// <summary>Selection type for failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Selection type for failover.",
        SerializedName = @"selectionType",
        PossibleTypes = new [] { typeof(string) })]
        string SelectionType { get; set; }
        /// <summary>The source nic ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source nic ARM Id.",
        SerializedName = @"sourceNicArmId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceNicArmId { get; set; }
        /// <summary>VM network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM network name.",
        SerializedName = @"vMNetworkName",
        PossibleTypes = new [] { typeof(string) })]
        string VMNetworkName { get; set; }
        /// <summary>VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM subnet name.",
        SerializedName = @"vMSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VMSubnetName { get; set; }

    }
    /// Hyper V VM network details.
    internal partial interface IVMNicDetailsInternal

    {
        /// <summary>A value indicating whether the NIC has accelerated networking enabled.</summary>
        bool? EnableAcceleratedNetworkingOnRecovery { get; set; }
        /// <summary>Ip address type.</summary>
        string IPAddressType { get; set; }
        /// <summary>The nic Id.</summary>
        string NicId { get; set; }
        /// <summary>Primary nic static IP address.</summary>
        string PrimaryNicStaticIPAddress { get; set; }
        /// <summary>IP allocation type for recovery VM.</summary>
        string RecoveryNicIPAddressType { get; set; }
        /// <summary>Recovery VM network Id.</summary>
        string RecoveryVMNetworkId { get; set; }
        /// <summary>Recovery VM subnet name.</summary>
        string RecoveryVMSubnetName { get; set; }
        /// <summary>The replica nic Id.</summary>
        string ReplicaNicId { get; set; }
        /// <summary>Replica nic static IP address.</summary>
        string ReplicaNicStaticIPAddress { get; set; }
        /// <summary>Selection type for failover.</summary>
        string SelectionType { get; set; }
        /// <summary>The source nic ARM Id.</summary>
        string SourceNicArmId { get; set; }
        /// <summary>VM network name.</summary>
        string VMNetworkName { get; set; }
        /// <summary>VM subnet name.</summary>
        string VMSubnetName { get; set; }

    }
}