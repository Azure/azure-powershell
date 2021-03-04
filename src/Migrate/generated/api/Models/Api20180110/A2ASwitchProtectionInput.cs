namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>A2A specific switch protection input.</summary>
    public partial class A2ASwitchProtectionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput __switchProtectionProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.SwitchProtectionProviderSpecificInput();

        /// <summary>Backing field for <see cref="DiskEncryptionInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo _diskEncryptionInfo;

        /// <summary>The recovery disk encryption information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo DiskEncryptionInfo { get => (this._diskEncryptionInfo = this._diskEncryptionInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionInfo()); set => this._diskEncryptionInfo = value; }

        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DiskEncryptionKeyInfoKeyVaultResourceArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfoKeyVaultResourceArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfoKeyVaultResourceArmId = value ?? null; }

        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DiskEncryptionKeyInfoSecretIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfoSecretIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfoSecretIdentifier = value ?? null; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)__switchProtectionProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal)__switchProtectionProviderSpecificInput).InstanceType = value ?? null; }

        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyInfoKeyIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfoKeyIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfoKeyIdentifier = value ?? null; }

        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyInfoKeyVaultResourceArmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfoKeyVaultResourceArmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfoKeyVaultResourceArmId = value ?? null; }

        /// <summary>Internal Acessors for DiskEncryptionInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal.DiskEncryptionInfo { get => (this._diskEncryptionInfo = this._diskEncryptionInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskEncryptionInfo()); set { {_diskEncryptionInfo = value;} } }

        /// <summary>Internal Acessors for DiskEncryptionInfoDiskEncryptionKeyInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal.DiskEncryptionInfoDiskEncryptionKeyInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).DiskEncryptionKeyInfo = value; }

        /// <summary>Internal Acessors for DiskEncryptionInfoKeyEncryptionKeyInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2ASwitchProtectionInputInternal.DiskEncryptionInfoKeyEncryptionKeyInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfoInternal)DiskEncryptionInfo).KeyEncryptionKeyInfo = value; }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="RecoveryAvailabilitySetId" /> property.</summary>
        private string _recoveryAvailabilitySetId;

        /// <summary>The recovery availability set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAvailabilitySetId { get => this._recoveryAvailabilitySetId; set => this._recoveryAvailabilitySetId = value; }

        /// <summary>Backing field for <see cref="RecoveryBootDiagStorageAccountId" /> property.</summary>
        private string _recoveryBootDiagStorageAccountId;

        /// <summary>The boot diagnostic storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryBootDiagStorageAccountId { get => this._recoveryBootDiagStorageAccountId; set => this._recoveryBootDiagStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryCloudServiceId" /> property.</summary>
        private string _recoveryCloudServiceId;

        /// <summary>The recovery cloud service Id. Valid for V1 scenarios.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryCloudServiceId { get => this._recoveryCloudServiceId; set => this._recoveryCloudServiceId = value; }

        /// <summary>Backing field for <see cref="RecoveryContainerId" /> property.</summary>
        private string _recoveryContainerId;

        /// <summary>The recovery container Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryContainerId { get => this._recoveryContainerId; set => this._recoveryContainerId = value; }

        /// <summary>Backing field for <see cref="RecoveryResourceGroupId" /> property.</summary>
        private string _recoveryResourceGroupId;

        /// <summary>The recovery resource group Id. Valid for V2 scenarios.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryResourceGroupId { get => this._recoveryResourceGroupId; set => this._recoveryResourceGroupId = value; }

        /// <summary>Backing field for <see cref="VMDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[] _vMDisk;

        /// <summary>The list of vm disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[] VMDisk { get => this._vMDisk; set => this._vMDisk = value; }

        /// <summary>Backing field for <see cref="VMManagedDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[] _vMManagedDisk;

        /// <summary>The list of vm managed disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[] VMManagedDisk { get => this._vMManagedDisk; set => this._vMManagedDisk = value; }

        /// <summary>Creates an new <see cref="A2ASwitchProtectionInput" /> instance.</summary>
        public A2ASwitchProtectionInput()
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
            await eventListener.AssertNotNull(nameof(__switchProtectionProviderSpecificInput), __switchProtectionProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__switchProtectionProviderSpecificInput), __switchProtectionProviderSpecificInput);
        }
    }
    /// A2A specific switch protection input.
    public partial interface IA2ASwitchProtectionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput
    {
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for secret.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret url / identifier.",
        SerializedName = @"secretIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionKeyInfoSecretIdentifier { get; set; }
        /// <summary>The key url / identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key url / identifier.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyInfoKeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The KeyVault resource ARM id for key.",
        SerializedName = @"keyVaultResourceArmId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Policy Id.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>The recovery availability set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery availability set.",
        SerializedName = @"recoveryAvailabilitySetId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>The boot diagnostic storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The boot diagnostic storage account.",
        SerializedName = @"recoveryBootDiagStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryBootDiagStorageAccountId { get; set; }
        /// <summary>The recovery cloud service Id. Valid for V1 scenarios.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery cloud service Id. Valid for V1 scenarios.",
        SerializedName = @"recoveryCloudServiceId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryCloudServiceId { get; set; }
        /// <summary>The recovery container Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery container Id.",
        SerializedName = @"recoveryContainerId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryContainerId { get; set; }
        /// <summary>The recovery resource group Id. Valid for V2 scenarios.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery resource group Id. Valid for V2 scenarios.",
        SerializedName = @"recoveryResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryResourceGroupId { get; set; }
        /// <summary>The list of vm disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of vm disk details.",
        SerializedName = @"vmDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[] VMDisk { get; set; }
        /// <summary>The list of vm managed disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of vm managed disk details.",
        SerializedName = @"vmManagedDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[] VMManagedDisk { get; set; }

    }
    /// A2A specific switch protection input.
    internal partial interface IA2ASwitchProtectionInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal
    {
        /// <summary>The recovery disk encryption information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionInfo DiskEncryptionInfo { get; set; }
        /// <summary>The recovery KeyVault reference for secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskEncryptionKeyInfo DiskEncryptionInfoDiskEncryptionKeyInfo { get; set; }
        /// <summary>The recovery KeyVault reference for key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IKeyEncryptionKeyInfo DiskEncryptionInfoKeyEncryptionKeyInfo { get; set; }
        /// <summary>The KeyVault resource ARM id for secret.</summary>
        string DiskEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The secret url / identifier.</summary>
        string DiskEncryptionKeyInfoSecretIdentifier { get; set; }
        /// <summary>The key url / identifier.</summary>
        string KeyEncryptionKeyInfoKeyIdentifier { get; set; }
        /// <summary>The KeyVault resource ARM id for key.</summary>
        string KeyEncryptionKeyInfoKeyVaultResourceArmId { get; set; }
        /// <summary>The Policy Id.</summary>
        string PolicyId { get; set; }
        /// <summary>The recovery availability set.</summary>
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>The boot diagnostic storage account.</summary>
        string RecoveryBootDiagStorageAccountId { get; set; }
        /// <summary>The recovery cloud service Id. Valid for V1 scenarios.</summary>
        string RecoveryCloudServiceId { get; set; }
        /// <summary>The recovery container Id.</summary>
        string RecoveryContainerId { get; set; }
        /// <summary>The recovery resource group Id. Valid for V2 scenarios.</summary>
        string RecoveryResourceGroupId { get; set; }
        /// <summary>The list of vm disk details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails[] VMDisk { get; set; }
        /// <summary>The list of vm managed disk details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmManagedDiskInputDetails[] VMManagedDisk { get; set; }

    }
}