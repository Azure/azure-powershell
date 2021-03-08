namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>HyperV replica Azure input to update replication protected item.</summary>
    public partial class HyperVReplicaAzureUpdateReplicationProtectedItemInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureUpdateReplicationProtectedItemInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureUpdateReplicationProtectedItemInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput __updateReplicationProtectedItemProviderInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateReplicationProtectedItemProviderInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal)__updateReplicationProtectedItemProviderInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal)__updateReplicationProtectedItemProviderInput).InstanceType = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureV1ResourceGroupId" /> property.</summary>
        private string _recoveryAzureV1ResourceGroupId;

        /// <summary>The recovery Azure resource group Id for classic deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureV1ResourceGroupId { get => this._recoveryAzureV1ResourceGroupId; set => this._recoveryAzureV1ResourceGroupId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureV2ResourceGroupId" /> property.</summary>
        private string _recoveryAzureV2ResourceGroupId;

        /// <summary>The recovery Azure resource group Id for resource manager deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureV2ResourceGroupId { get => this._recoveryAzureV2ResourceGroupId; set => this._recoveryAzureV2ResourceGroupId = value; }

        /// <summary>Backing field for <see cref="UseManagedDisk" /> property.</summary>
        private string _useManagedDisk;

        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UseManagedDisk { get => this._useManagedDisk; set => this._useManagedDisk = value; }

        /// <summary>
        /// Creates an new <see cref="HyperVReplicaAzureUpdateReplicationProtectedItemInput" /> instance.
        /// </summary>
        public HyperVReplicaAzureUpdateReplicationProtectedItemInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__updateReplicationProtectedItemProviderInput), __updateReplicationProtectedItemProviderInput);
            await eventListener.AssertObjectIsValid(nameof(__updateReplicationProtectedItemProviderInput), __updateReplicationProtectedItemProviderInput);
        }
    }
    /// HyperV replica Azure input to update replication protected item.
    public partial interface IHyperVReplicaAzureUpdateReplicationProtectedItemInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput
    {
        /// <summary>The recovery Azure resource group Id for classic deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery Azure resource group Id for classic deployment.",
        SerializedName = @"recoveryAzureV1ResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureV1ResourceGroupId { get; set; }
        /// <summary>The recovery Azure resource group Id for resource manager deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery Azure resource group Id for resource manager deployment.",
        SerializedName = @"recoveryAzureV2ResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureV2ResourceGroupId { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether managed disks should be used during failover.",
        SerializedName = @"useManagedDisks",
        PossibleTypes = new [] { typeof(string) })]
        string UseManagedDisk { get; set; }

    }
    /// HyperV replica Azure input to update replication protected item.
    internal partial interface IHyperVReplicaAzureUpdateReplicationProtectedItemInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal
    {
        /// <summary>The recovery Azure resource group Id for classic deployment.</summary>
        string RecoveryAzureV1ResourceGroupId { get; set; }
        /// <summary>The recovery Azure resource group Id for resource manager deployment.</summary>
        string RecoveryAzureV2ResourceGroupId { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        string UseManagedDisk { get; set; }

    }
}