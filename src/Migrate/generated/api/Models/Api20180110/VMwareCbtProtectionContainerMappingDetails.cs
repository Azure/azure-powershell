namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt provider specific container mapping details.</summary>
    public partial class VMwareCbtProtectionContainerMappingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails __protectionContainerMappingProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerMappingProviderSpecificDetails();

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType; }

        /// <summary>Backing field for <see cref="KeyVaultId" /> property.</summary>
        private string _keyVaultId;

        /// <summary>The target key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultId { get => this._keyVaultId; }

        /// <summary>Backing field for <see cref="KeyVaultUri" /> property.</summary>
        private string _keyVaultUri;

        /// <summary>The target key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string KeyVaultUri { get => this._keyVaultUri; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal)__protectionContainerMappingProviderSpecificDetails).InstanceType = value; }

        /// <summary>Internal Acessors for KeyVaultId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.KeyVaultId { get => this._keyVaultId; set { {_keyVaultId = value;} } }

        /// <summary>Internal Acessors for KeyVaultUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.KeyVaultUri { get => this._keyVaultUri; set { {_keyVaultUri = value;} } }

        /// <summary>Internal Acessors for ServiceBusConnectionStringSecretName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.ServiceBusConnectionStringSecretName { get => this._serviceBusConnectionStringSecretName; set { {_serviceBusConnectionStringSecretName = value;} } }

        /// <summary>Internal Acessors for StorageAccountId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.StorageAccountId { get => this._storageAccountId; set { {_storageAccountId = value;} } }

        /// <summary>Internal Acessors for StorageAccountSasSecretName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.StorageAccountSasSecretName { get => this._storageAccountSasSecretName; set { {_storageAccountSasSecretName = value;} } }

        /// <summary>Internal Acessors for TargetLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectionContainerMappingDetailsInternal.TargetLocation { get => this._targetLocation; set { {_targetLocation = value;} } }

        /// <summary>Backing field for <see cref="ServiceBusConnectionStringSecretName" /> property.</summary>
        private string _serviceBusConnectionStringSecretName;

        /// <summary>The secret name of the service bus connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServiceBusConnectionStringSecretName { get => this._serviceBusConnectionStringSecretName; }

        /// <summary>Backing field for <see cref="StorageAccountId" /> property.</summary>
        private string _storageAccountId;

        /// <summary>The storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StorageAccountId { get => this._storageAccountId; }

        /// <summary>Backing field for <see cref="StorageAccountSasSecretName" /> property.</summary>
        private string _storageAccountSasSecretName;

        /// <summary>The secret name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StorageAccountSasSecretName { get => this._storageAccountSasSecretName; }

        /// <summary>Backing field for <see cref="TargetLocation" /> property.</summary>
        private string _targetLocation;

        /// <summary>The target location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetLocation { get => this._targetLocation; }

        /// <summary>
        /// Creates an new <see cref="VMwareCbtProtectionContainerMappingDetails" /> instance.
        /// </summary>
        public VMwareCbtProtectionContainerMappingDetails()
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
            await eventListener.AssertNotNull(nameof(__protectionContainerMappingProviderSpecificDetails), __protectionContainerMappingProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__protectionContainerMappingProviderSpecificDetails), __protectionContainerMappingProviderSpecificDetails);
        }
    }
    /// VMwareCbt provider specific container mapping details.
    public partial interface IVMwareCbtProtectionContainerMappingDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails
    {
        /// <summary>The target key vault ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target key vault ARM Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultId { get;  }
        /// <summary>The target key vault URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target key vault URI.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultUri { get;  }
        /// <summary>The secret name of the service bus connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The secret name of the service bus connection string.",
        SerializedName = @"serviceBusConnectionStringSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusConnectionStringSecretName { get;  }
        /// <summary>The storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The storage account ARM Id.",
        SerializedName = @"storageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountId { get;  }
        /// <summary>The secret name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The secret name of the storage account.",
        SerializedName = @"storageAccountSasSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountSasSecretName { get;  }
        /// <summary>The target location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target location.",
        SerializedName = @"targetLocation",
        PossibleTypes = new [] { typeof(string) })]
        string TargetLocation { get;  }

    }
    /// VMwareCbt provider specific container mapping details.
    internal partial interface IVMwareCbtProtectionContainerMappingDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal
    {
        /// <summary>The target key vault ARM Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>The target key vault URI.</summary>
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