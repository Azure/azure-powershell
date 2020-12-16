namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>GateKeeper for resource operations</summary>
    public partial class ResourceOperationGateKeeper :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeper,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperInternal
    {

        /// <summary>Backing field for <see cref="LastLockUpdateTime" /> property.</summary>
        private global::System.DateTime? _lastLockUpdateTime;

        /// <summary>LastTime ResourceOperationGateKeeper is updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? LastLockUpdateTime { get => this._lastLockUpdateTime; }

        /// <summary>Internal Acessors for LastLockUpdateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperInternal.LastLockUpdateTime { get => this._lastLockUpdateTime; set { {_lastLockUpdateTime = value;} } }

        /// <summary>Internal Acessors for Operation</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperInternal.Operation { get => this._operation; set { {_operation = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string[] _operation;

        /// <summary>
        /// {readonly} List of operations that can be protected by the ResourceOperationGateKeeper
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] Operation { get => this._operation; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ResourceOperationGateKeeper" /> instance.</summary>
        public ResourceOperationGateKeeper()
        {

        }
    }
    /// GateKeeper for resource operations
    public partial interface IResourceOperationGateKeeper :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>LastTime ResourceOperationGateKeeper is updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"LastTime ResourceOperationGateKeeper is updated",
        SerializedName = @"lastLockUpdateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastLockUpdateTime { get;  }
        /// <summary>
        /// {readonly} List of operations that can be protected by the ResourceOperationGateKeeper
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"{readonly} List of operations that can be protected by the ResourceOperationGateKeeper",
        SerializedName = @"operations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Operation { get;  }
        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get;  }

    }
    /// GateKeeper for resource operations
    internal partial interface IResourceOperationGateKeeperInternal

    {
        /// <summary>LastTime ResourceOperationGateKeeper is updated</summary>
        global::System.DateTime? LastLockUpdateTime { get; set; }
        /// <summary>
        /// {readonly} List of operations that can be protected by the ResourceOperationGateKeeper
        /// </summary>
        string[] Operation { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}