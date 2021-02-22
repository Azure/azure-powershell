namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt container mapping input.</summary>
    public partial class VMwareCbtContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtContainerMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtContainerMappingInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput __replicationProviderSpecificContainerMappingInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificContainerMappingInput();

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal)__replicationProviderSpecificContainerMappingInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal)__replicationProviderSpecificContainerMappingInput).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="KeyVaultId" /> property.</summary>
        private string _keyVaultId;

        /// <summary>The target key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultId { get => this._keyVaultId; set => this._keyVaultId = value; }

        /// <summary>Backing field for <see cref="KeyVaultUri" /> property.</summary>
        private string _keyVaultUri;

        /// <summary>The target key vault URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultUri { get => this._keyVaultUri; set => this._keyVaultUri = value; }

        /// <summary>Backing field for <see cref="ServiceBusConnectionStringSecretName" /> property.</summary>
        private string _serviceBusConnectionStringSecretName;

        /// <summary>The secret name of the service bus connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServiceBusConnectionStringSecretName { get => this._serviceBusConnectionStringSecretName; set => this._serviceBusConnectionStringSecretName = value; }

        /// <summary>Backing field for <see cref="StorageAccountId" /> property.</summary>
        private string _storageAccountId;

        /// <summary>The storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StorageAccountId { get => this._storageAccountId; set => this._storageAccountId = value; }

        /// <summary>Backing field for <see cref="StorageAccountSasSecretName" /> property.</summary>
        private string _storageAccountSasSecretName;

        /// <summary>The secret name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StorageAccountSasSecretName { get => this._storageAccountSasSecretName; set => this._storageAccountSasSecretName = value; }

        /// <summary>Backing field for <see cref="TargetLocation" /> property.</summary>
        private string _targetLocation;

        /// <summary>The target location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetLocation { get => this._targetLocation; set => this._targetLocation = value; }

        /// <summary>Creates an new <see cref="VMwareCbtContainerMappingInput" /> instance.</summary>
        public VMwareCbtContainerMappingInput()
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
            await eventListener.AssertNotNull(nameof(__replicationProviderSpecificContainerMappingInput), __replicationProviderSpecificContainerMappingInput);
            await eventListener.AssertObjectIsValid(nameof(__replicationProviderSpecificContainerMappingInput), __replicationProviderSpecificContainerMappingInput);
        }
    }
    /// VMwareCbt container mapping input.
    public partial interface IVMwareCbtContainerMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInput
    {
        /// <summary>The target key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target key vault ARM Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultId { get; set; }
        /// <summary>The target key vault URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target key vault URL.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultUri { get; set; }
        /// <summary>The secret name of the service bus connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The secret name of the service bus connection string.",
        SerializedName = @"serviceBusConnectionStringSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusConnectionStringSecretName { get; set; }
        /// <summary>The storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The storage account ARM Id.",
        SerializedName = @"storageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountId { get; set; }
        /// <summary>The secret name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The secret name of the storage account.",
        SerializedName = @"storageAccountSasSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountSasSecretName { get; set; }
        /// <summary>The target location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target location.",
        SerializedName = @"targetLocation",
        PossibleTypes = new [] { typeof(string) })]
        string TargetLocation { get; set; }

    }
    /// VMwareCbt container mapping input.
    internal partial interface IVMwareCbtContainerMappingInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificContainerMappingInputInternal
    {
        /// <summary>The target key vault ARM Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>The target key vault URL.</summary>
        string KeyVaultUri { get; set; }
        /// <summary>The secret name of the service bus connection string.</summary>
        string ServiceBusConnectionStringSecretName { get; set; }
        /// <summary>The storage account ARM Id.</summary>
        string StorageAccountId { get; set; }
        /// <summary>The secret name of the storage account.</summary>
        string StorageAccountSasSecretName { get; set; }
        /// <summary>The target location.</summary>
        string TargetLocation { get; set; }

    }
}