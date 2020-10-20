namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Hyper V VM network input details.</summary>
    public partial class VMNicInputDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetailsInternal
    {

        /// <summary>
        /// Backing field for <see cref="EnableAcceleratedNetworkingOnRecovery" /> property.
        /// </summary>
        private bool? _enableAcceleratedNetworkingOnRecovery;

        /// <summary>Whether the NIC has accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableAcceleratedNetworkingOnRecovery { get => this._enableAcceleratedNetworkingOnRecovery; set => this._enableAcceleratedNetworkingOnRecovery = value; }

        /// <summary>Backing field for <see cref="NicId" /> property.</summary>
        private string _nicId;

        /// <summary>The nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicId { get => this._nicId; set => this._nicId = value; }

        /// <summary>Backing field for <see cref="RecoveryVMSubnetName" /> property.</summary>
        private string _recoveryVMSubnetName;

        /// <summary>Recovery VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryVMSubnetName { get => this._recoveryVMSubnetName; set => this._recoveryVMSubnetName = value; }

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

        /// <summary>Creates an new <see cref="VMNicInputDetails" /> instance.</summary>
        public VMNicInputDetails()
        {

        }
    }
    /// Hyper V VM network input details.
    public partial interface IVMNicInputDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Whether the NIC has accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the NIC has accelerated networking enabled.",
        SerializedName = @"enableAcceleratedNetworkingOnRecovery",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAcceleratedNetworkingOnRecovery { get; set; }
        /// <summary>The nic Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The nic Id.",
        SerializedName = @"nicId",
        PossibleTypes = new [] { typeof(string) })]
        string NicId { get; set; }
        /// <summary>Recovery VM subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recovery VM subnet name.",
        SerializedName = @"recoveryVMSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryVMSubnetName { get; set; }
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

    }
    /// Hyper V VM network input details.
    internal partial interface IVMNicInputDetailsInternal

    {
        /// <summary>Whether the NIC has accelerated networking enabled.</summary>
        bool? EnableAcceleratedNetworkingOnRecovery { get; set; }
        /// <summary>The nic Id.</summary>
        string NicId { get; set; }
        /// <summary>Recovery VM subnet name.</summary>
        string RecoveryVMSubnetName { get; set; }
        /// <summary>Replica nic static IP address.</summary>
        string ReplicaNicStaticIPAddress { get; set; }
        /// <summary>Selection type for failover.</summary>
        string SelectionType { get; set; }

    }
}