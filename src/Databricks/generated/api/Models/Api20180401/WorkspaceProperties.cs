namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The workspace properties.</summary>
    public partial class WorkspaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal
    {

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceIdType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string AmlWorkspaceIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceIdValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceIdValue = value ?? null; }

        /// <summary>Backing field for <see cref="Authorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[] _authorization;

        /// <summary>The workspace provider authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[] Authorization { get => this._authorization; set => this._authorization = value; }

        /// <summary>Backing field for <see cref="CreatedBy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy _createdBy;

        /// <summary>
        /// Indicates the Object ID, PUID and Application ID of entity that created the workspace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy CreatedBy { get => (this._createdBy = this._createdBy ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy()); set => this._createdBy = value; }

        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CreatedByApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).ApplicationId; }

        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CreatedByOid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Oid; }

        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CreatedByPuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Puid; }

        /// <summary>Backing field for <see cref="CreatedDateTime" /> property.</summary>
        private global::System.DateTime? _createdDateTime;

        /// <summary>Specifies the date and time when the workspace is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedDateTime { get => this._createdDateTime; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetNameType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPrivateSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetNameValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetNameValue = value ?? null; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetNameType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPublicSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetNameValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetNameValue = value ?? null; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkIdType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomVirtualNetworkIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkIdValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkIdValue = value ?? null; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIPType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? EnableNoPublicIPValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIPValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIPValue = value ?? default(bool); }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EncryptionType; }

        /// <summary>Backing field for <see cref="ManagedResourceGroupId" /> property.</summary>
        private string _managedResourceGroupId;

        /// <summary>The managed resource group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string ManagedResourceGroupId { get => this._managedResourceGroupId; set => this._managedResourceGroupId = value; }

        /// <summary>Internal Acessors for AmlWorkspaceIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceIdType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceIdType = value; }

        /// <summary>Internal Acessors for CreatedBy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CreatedBy { get => (this._createdBy = this._createdBy ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy()); set { {_createdBy = value;} } }

        /// <summary>Internal Acessors for CreatedByApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CreatedByApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).ApplicationId = value; }

        /// <summary>Internal Acessors for CreatedByOid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CreatedByOid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Oid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Oid = value; }

        /// <summary>Internal Acessors for CreatedByPuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CreatedByPuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Puid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)CreatedBy).Puid = value; }

        /// <summary>Internal Acessors for CreatedDateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CreatedDateTime { get => this._createdDateTime; set { {_createdDateTime = value;} } }

        /// <summary>Internal Acessors for CustomPrivateSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetNameType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetNameType = value; }

        /// <summary>Internal Acessors for CustomPublicSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetNameType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetNameType = value; }

        /// <summary>Internal Acessors for CustomVirtualNetworkIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkIdType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkIdType = value; }

        /// <summary>Internal Acessors for EnableNoPublicIPType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIPType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIPType = value; }

        /// <summary>Internal Acessors for EncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.EncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EncryptionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EncryptionType = value; }

        /// <summary>Internal Acessors for EncryptionValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.EncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EncryptionValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EncryptionValue = value; }

        /// <summary>Internal Acessors for Parameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.Parameter { get => (this._parameter = this._parameter ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters()); set { {_parameter = value;} } }

        /// <summary>Internal Acessors for ParameterAmlWorkspaceId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterAmlWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).AmlWorkspaceId = value; }

        /// <summary>Internal Acessors for ParameterCustomPrivateSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterCustomPrivateSubnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPrivateSubnetName = value; }

        /// <summary>Internal Acessors for ParameterCustomPublicSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterCustomPublicSubnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomPublicSubnetName = value; }

        /// <summary>Internal Acessors for ParameterCustomVirtualNetworkId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterCustomVirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).CustomVirtualNetworkId = value; }

        /// <summary>Internal Acessors for ParameterEnableNoPublicIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterEnableNoPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).EnableNoPublicIP = value; }

        /// <summary>Internal Acessors for ParameterEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).Encryption = value; }

        /// <summary>Internal Acessors for ParameterPrepareEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterPrepareEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryption = value; }

        /// <summary>Internal Acessors for ParameterRequireInfrastructureEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ParameterRequireInfrastructureEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryption = value; }

        /// <summary>Internal Acessors for PrepareEncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.PrepareEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryptionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryptionType = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RequireInfrastructureEncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.RequireInfrastructureEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryptionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryptionType = value; }

        /// <summary>Internal Acessors for StorageAccountIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfiguration Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.StorageAccountIdentity { get => (this._storageAccountIdentity = this._storageAccountIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ManagedIdentityConfiguration()); set { {_storageAccountIdentity = value;} } }

        /// <summary>Internal Acessors for StorageAccountIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.StorageAccountIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).PrincipalId = value; }

        /// <summary>Internal Acessors for StorageAccountIdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.StorageAccountIdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).TenantId = value; }

        /// <summary>Internal Acessors for StorageAccountIdentityType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.StorageAccountIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).Type = value; }

        /// <summary>Internal Acessors for UpdatedBy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.UpdatedBy { get => (this._updatedBy = this._updatedBy ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy()); set { {_updatedBy = value;} } }

        /// <summary>Internal Acessors for UpdatedByApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.UpdatedByApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).ApplicationId = value; }

        /// <summary>Internal Acessors for UpdatedByOid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.UpdatedByOid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Oid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Oid = value; }

        /// <summary>Internal Acessors for UpdatedByPuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.UpdatedByPuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Puid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Puid = value; }

        /// <summary>Internal Acessors for WorkspaceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.WorkspaceId { get => this._workspaceId; set { {_workspaceId = value;} } }

        /// <summary>Internal Acessors for WorkspaceUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspacePropertiesInternal.WorkspaceUrl { get => this._workspaceUrl; set { {_workspaceUrl = value;} } }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters _parameter;

        /// <summary>The workspace's custom parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters Parameter { get => (this._parameter = this._parameter ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomParameters()); set => this._parameter = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? PrepareEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryptionType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? PrepareEncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryptionValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).PrepareEncryptionValue = value ?? default(bool); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState? _provisioningState;

        /// <summary>The workspace provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RequireInfrastructureEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryptionType; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? RequireInfrastructureEncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryptionValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).RequireInfrastructureEncryptionValue = value ?? default(bool); }

        /// <summary>Backing field for <see cref="StorageAccountIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfiguration _storageAccountIdentity;

        /// <summary>The details of Managed Identity of Storage Account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfiguration StorageAccountIdentity { get => (this._storageAccountIdentity = this._storageAccountIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ManagedIdentityConfiguration()); set => this._storageAccountIdentity = value; }

        /// <summary>
        /// The objectId of the Managed Identity that is linked to the Managed Storage account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string StorageAccountIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).PrincipalId; }

        /// <summary>The tenant Id where the Managed Identity is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string StorageAccountIdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).TenantId; }

        /// <summary>The type of Identity created. It can be either SystemAssigned or UserAssigned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string StorageAccountIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfigurationInternal)StorageAccountIdentity).Type; }

        /// <summary>Backing field for <see cref="UiDefinitionUri" /> property.</summary>
        private string _uiDefinitionUri;

        /// <summary>The blob URI where the UI definition file is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string UiDefinitionUri { get => this._uiDefinitionUri; set => this._uiDefinitionUri = value; }

        /// <summary>Backing field for <see cref="UpdatedBy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy _updatedBy;

        /// <summary>
        /// Indicates the Object ID, PUID and Application ID of entity that last updated the workspace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy UpdatedBy { get => (this._updatedBy = this._updatedBy ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.CreatedBy()); set => this._updatedBy = value; }

        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string UpdatedByApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).ApplicationId; }

        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string UpdatedByOid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Oid; }

        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string UpdatedByPuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal)UpdatedBy).Puid; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyName = value ?? null; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeySource = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource)""); }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyVaultUri = value ?? null; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal)Parameter).ValueKeyVersion = value ?? null; }

        /// <summary>Backing field for <see cref="WorkspaceId" /> property.</summary>
        private string _workspaceId;

        /// <summary>The unique identifier of the databricks workspace in databricks control plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string WorkspaceId { get => this._workspaceId; }

        /// <summary>Backing field for <see cref="WorkspaceUrl" /> property.</summary>
        private string _workspaceUrl;

        /// <summary>
        /// The workspace URL which is of the format 'adb-{workspaceId}.{random}.azuredatabricks.net'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string WorkspaceUrl { get => this._workspaceUrl; }

        /// <summary>Creates an new <see cref="WorkspaceProperties" /> instance.</summary>
        public WorkspaceProperties()
        {

        }
    }
    /// The workspace properties.
    public partial interface IWorkspaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string AmlWorkspaceIdValue { get; set; }
        /// <summary>The workspace provider authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace provider authorizations.",
        SerializedName = @"authorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[] Authorization { get; set; }
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedByApplicationId { get;  }
        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Object ID that created the workspace.",
        SerializedName = @"oid",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedByOid { get;  }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Personal Object ID corresponding to the object ID above",
        SerializedName = @"puid",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedByPuid { get;  }
        /// <summary>Specifies the date and time when the workspace is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the date and time when the workspace is created.",
        SerializedName = @"createdDateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDateTime { get;  }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomPrivateSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomPublicSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string CustomVirtualNetworkIdValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableNoPublicIPValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EncryptionType { get;  }
        /// <summary>The managed resource group Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The managed resource group Id.",
        SerializedName = @"managedResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedResourceGroupId { get; set; }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? PrepareEncryptionType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PrepareEncryptionValue { get; set; }
        /// <summary>The workspace provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The workspace provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RequireInfrastructureEncryptionType { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RequireInfrastructureEncryptionValue { get; set; }
        /// <summary>
        /// The objectId of the Managed Identity that is linked to the Managed Storage account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The objectId of the Managed Identity that is linked to the Managed Storage account.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountIdentityPrincipalId { get;  }
        /// <summary>The tenant Id where the Managed Identity is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant Id where the Managed Identity is created.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountIdentityTenantId { get;  }
        /// <summary>The type of Identity created. It can be either SystemAssigned or UserAssigned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of Identity created. It can be either SystemAssigned or UserAssigned.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountIdentityType { get;  }
        /// <summary>The blob URI where the UI definition file is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The blob URI where the UI definition file is located.",
        SerializedName = @"uiDefinitionUri",
        PossibleTypes = new [] { typeof(string) })]
        string UiDefinitionUri { get; set; }
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedByApplicationId { get;  }
        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Object ID that created the workspace.",
        SerializedName = @"oid",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedByOid { get;  }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Personal Object ID corresponding to the object ID above",
        SerializedName = @"puid",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedByPuid { get;  }
        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of KeyVault key.",
        SerializedName = @"KeyName",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyName { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption keySource (provider). Possible values (case-insensitive):  Default, Microsoft.Keyvault",
        SerializedName = @"keySource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Uri of KeyVault.",
        SerializedName = @"keyvaulturi",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of KeyVault key.",
        SerializedName = @"keyversion",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVersion { get; set; }
        /// <summary>The unique identifier of the databricks workspace in databricks control plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The unique identifier of the databricks workspace in databricks control plane.",
        SerializedName = @"workspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceId { get;  }
        /// <summary>
        /// The workspace URL which is of the format 'adb-{workspaceId}.{random}.azuredatabricks.net'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The workspace URL which is of the format 'adb-{workspaceId}.{random}.azuredatabricks.net'",
        SerializedName = @"workspaceUrl",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceUrl { get;  }

    }
    /// The workspace properties.
    internal partial interface IWorkspacePropertiesInternal

    {
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string AmlWorkspaceIdValue { get; set; }
        /// <summary>The workspace provider authorizations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceProviderAuthorization[] Authorization { get; set; }
        /// <summary>
        /// Indicates the Object ID, PUID and Application ID of entity that created the workspace.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy CreatedBy { get; set; }
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        string CreatedByApplicationId { get; set; }
        /// <summary>The Object ID that created the workspace.</summary>
        string CreatedByOid { get; set; }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        string CreatedByPuid { get; set; }
        /// <summary>Specifies the date and time when the workspace is created.</summary>
        global::System.DateTime? CreatedDateTime { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPrivateSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPublicSubnetNameValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomVirtualNetworkIdValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? EnableNoPublicIPValue { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption EncryptionValue { get; set; }
        /// <summary>The managed resource group Id.</summary>
        string ManagedResourceGroupId { get; set; }
        /// <summary>The workspace's custom parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters Parameter { get; set; }
        /// <summary>The ID of a Azure Machine Learning workspace to link with Databricks workspace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter ParameterAmlWorkspaceId { get; set; }
        /// <summary>The name of the Private Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter ParameterCustomPrivateSubnetName { get; set; }
        /// <summary>The name of a Public Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter ParameterCustomPublicSubnetName { get; set; }
        /// <summary>The ID of a Virtual Network where this Databricks Cluster should be created</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter ParameterCustomVirtualNetworkId { get; set; }
        /// <summary>Should the Public IP be Disabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter ParameterEnableNoPublicIP { get; set; }
        /// <summary>
        /// Contains the encryption details for Customer-Managed Key (CMK) enabled workspace.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter ParameterEncryption { get; set; }
        /// <summary>
        /// Prepare the workspace for encryption. Enables the Managed Identity for managed storage account.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter ParameterPrepareEncryption { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the DBFS root file system will be enabled with secondary layer of encryption with
        /// platform managed keys for data at rest.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter ParameterRequireInfrastructureEncryption { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? PrepareEncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? PrepareEncryptionValue { get; set; }
        /// <summary>The workspace provisioning state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RequireInfrastructureEncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? RequireInfrastructureEncryptionValue { get; set; }
        /// <summary>The details of Managed Identity of Storage Account</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IManagedIdentityConfiguration StorageAccountIdentity { get; set; }
        /// <summary>
        /// The objectId of the Managed Identity that is linked to the Managed Storage account.
        /// </summary>
        string StorageAccountIdentityPrincipalId { get; set; }
        /// <summary>The tenant Id where the Managed Identity is created.</summary>
        string StorageAccountIdentityTenantId { get; set; }
        /// <summary>The type of Identity created. It can be either SystemAssigned or UserAssigned.</summary>
        string StorageAccountIdentityType { get; set; }
        /// <summary>The blob URI where the UI definition file is located.</summary>
        string UiDefinitionUri { get; set; }
        /// <summary>
        /// Indicates the Object ID, PUID and Application ID of entity that last updated the workspace.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy UpdatedBy { get; set; }
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        string UpdatedByApplicationId { get; set; }
        /// <summary>The Object ID that created the workspace.</summary>
        string UpdatedByOid { get; set; }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        string UpdatedByPuid { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string ValueKeyName { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string ValueKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string ValueKeyVersion { get; set; }
        /// <summary>The unique identifier of the databricks workspace in databricks control plane.</summary>
        string WorkspaceId { get; set; }
        /// <summary>
        /// The workspace URL which is of the format 'adb-{workspaceId}.{random}.azuredatabricks.net'
        /// </summary>
        string WorkspaceUrl { get; set; }

    }
}