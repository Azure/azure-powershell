namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Failover details for a replication protected item.</summary>
    public partial class FailoverReplicationProtectedItemDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="NetworkConnectionStatus" /> property.</summary>
        private string _networkConnectionStatus;

        /// <summary>The network connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkConnectionStatus { get => this._networkConnectionStatus; set => this._networkConnectionStatus = value; }

        /// <summary>Backing field for <see cref="NetworkFriendlyName" /> property.</summary>
        private string _networkFriendlyName;

        /// <summary>The network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkFriendlyName { get => this._networkFriendlyName; set => this._networkFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryPointId" /> property.</summary>
        private string _recoveryPointId;

        /// <summary>The recovery point Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryPointId { get => this._recoveryPointId; set => this._recoveryPointId = value; }

        /// <summary>Backing field for <see cref="RecoveryPointTime" /> property.</summary>
        private global::System.DateTime? _recoveryPointTime;

        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? RecoveryPointTime { get => this._recoveryPointTime; set => this._recoveryPointTime = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private string _subnet;

        /// <summary>The network subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Subnet { get => this._subnet; set => this._subnet = value; }

        /// <summary>Backing field for <see cref="TestVMFriendlyName" /> property.</summary>
        private string _testVMFriendlyName;

        /// <summary>The test Vm friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestVMFriendlyName { get => this._testVMFriendlyName; set => this._testVMFriendlyName = value; }

        /// <summary>Backing field for <see cref="TestVMName" /> property.</summary>
        private string _testVMName;

        /// <summary>The test Vm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestVMName { get => this._testVMName; set => this._testVMName = value; }

        /// <summary>Creates an new <see cref="FailoverReplicationProtectedItemDetails" /> instance.</summary>
        public FailoverReplicationProtectedItemDetails()
        {

        }
    }
    /// Failover details for a replication protected item.
    public partial interface IFailoverReplicationProtectedItemDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The network connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network connection status.",
        SerializedName = @"networkConnectionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkConnectionStatus { get; set; }
        /// <summary>The network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network friendly name.",
        SerializedName = @"networkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkFriendlyName { get; set; }
        /// <summary>The recovery point Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point Id.",
        SerializedName = @"recoveryPointId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointId { get; set; }
        /// <summary>The recovery point time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery point time.",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecoveryPointTime { get; set; }
        /// <summary>The network subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network subnet.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(string) })]
        string Subnet { get; set; }
        /// <summary>The test Vm friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test Vm friendly name.",
        SerializedName = @"testVmFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string TestVMFriendlyName { get; set; }
        /// <summary>The test Vm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test Vm name.",
        SerializedName = @"testVmName",
        PossibleTypes = new [] { typeof(string) })]
        string TestVMName { get; set; }

    }
    /// Failover details for a replication protected item.
    internal partial interface IFailoverReplicationProtectedItemDetailsInternal

    {
        /// <summary>The friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The name.</summary>
        string Name { get; set; }
        /// <summary>The network connection status.</summary>
        string NetworkConnectionStatus { get; set; }
        /// <summary>The network friendly name.</summary>
        string NetworkFriendlyName { get; set; }
        /// <summary>The recovery point Id.</summary>
        string RecoveryPointId { get; set; }
        /// <summary>The recovery point time.</summary>
        global::System.DateTime? RecoveryPointTime { get; set; }
        /// <summary>The network subnet.</summary>
        string Subnet { get; set; }
        /// <summary>The test Vm friendly name.</summary>
        string TestVMFriendlyName { get; set; }
        /// <summary>The test Vm name.</summary>
        string TestVMName { get; set; }

    }
}