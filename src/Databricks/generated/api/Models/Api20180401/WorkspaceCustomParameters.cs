namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Custom Parameters used for Cluster Creation.</summary>
    public partial class WorkspaceCustomParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal
    {

        /// <summary>Backing field for <see cref="AmlWorkspaceId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _amlWorkspaceId;

        /// <summary>The ID of a Azure Machine Learning workspace to link with Databricks workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter AmlWorkspaceId { get => (this._amlWorkspaceId = this._amlWorkspaceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._amlWorkspaceId = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string AmlWorkspaceIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Value = value ?? null; }

        /// <summary>Backing field for <see cref="CustomPrivateSubnetName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customPrivateSubnetName;

        /// <summary>The name of the Private Subnet within the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPrivateSubnetName { get => (this._customPrivateSubnetName = this._customPrivateSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customPrivateSubnetName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPrivateSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Value = value ?? null; }

        /// <summary>Backing field for <see cref="CustomPublicSubnetName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customPublicSubnetName;

        /// <summary>The name of a Public Subnet within the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPublicSubnetName { get => (this._customPublicSubnetName = this._customPublicSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customPublicSubnetName = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomPublicSubnetNameValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Value = value ?? null; }

        /// <summary>Backing field for <see cref="CustomVirtualNetworkId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter _customVirtualNetworkId;

        /// <summary>The ID of a Virtual Network where this Databricks Cluster should be created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomVirtualNetworkId { get => (this._customVirtualNetworkId = this._customVirtualNetworkId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set => this._customVirtualNetworkId = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string CustomVirtualNetworkIdValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Value = value ?? null; }

        /// <summary>Backing field for <see cref="EnableNoPublicIP" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter _enableNoPublicIP;

        /// <summary>Should the Public IP be Disabled?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter EnableNoPublicIP { get => (this._enableNoPublicIP = this._enableNoPublicIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set => this._enableNoPublicIP = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? EnableNoPublicIPValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Value = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Encryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter _encryption;

        /// <summary>
        /// Contains the encryption details for Customer-Managed Key (CMK) enabled workspace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceEncryptionParameter()); set => this._encryption = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).Type; }

        /// <summary>Internal Acessors for AmlWorkspaceId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.AmlWorkspaceId { get => (this._amlWorkspaceId = this._amlWorkspaceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_amlWorkspaceId = value;} } }

        /// <summary>Internal Acessors for AmlWorkspaceIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.AmlWorkspaceIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)AmlWorkspaceId).Type = value; }

        /// <summary>Internal Acessors for CustomPrivateSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPrivateSubnetName { get => (this._customPrivateSubnetName = this._customPrivateSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customPrivateSubnetName = value;} } }

        /// <summary>Internal Acessors for CustomPrivateSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPrivateSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPrivateSubnetName).Type = value; }

        /// <summary>Internal Acessors for CustomPublicSubnetName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPublicSubnetName { get => (this._customPublicSubnetName = this._customPublicSubnetName ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customPublicSubnetName = value;} } }

        /// <summary>Internal Acessors for CustomPublicSubnetNameType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomPublicSubnetNameType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomPublicSubnetName).Type = value; }

        /// <summary>Internal Acessors for CustomVirtualNetworkId</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomVirtualNetworkId { get => (this._customVirtualNetworkId = this._customVirtualNetworkId ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomStringParameter()); set { {_customVirtualNetworkId = value;} } }

        /// <summary>Internal Acessors for CustomVirtualNetworkIdType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.CustomVirtualNetworkIdType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal)CustomVirtualNetworkId).Type = value; }

        /// <summary>Internal Acessors for EnableNoPublicIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EnableNoPublicIP { get => (this._enableNoPublicIP = this._enableNoPublicIP ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set { {_enableNoPublicIP = value;} } }

        /// <summary>Internal Acessors for EnableNoPublicIPType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EnableNoPublicIPType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)EnableNoPublicIP).Type = value; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceEncryptionParameter()); set { {_encryption = value;} } }

        /// <summary>Internal Acessors for EncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).Type = value; }

        /// <summary>Internal Acessors for EncryptionValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.EncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).Value = value; }

        /// <summary>Internal Acessors for PrepareEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.PrepareEncryption { get => (this._prepareEncryption = this._prepareEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set { {_prepareEncryption = value;} } }

        /// <summary>Internal Acessors for PrepareEncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.PrepareEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)PrepareEncryption).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)PrepareEncryption).Type = value; }

        /// <summary>Internal Acessors for RequireInfrastructureEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.RequireInfrastructureEncryption { get => (this._requireInfrastructureEncryption = this._requireInfrastructureEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set { {_requireInfrastructureEncryption = value;} } }

        /// <summary>Internal Acessors for RequireInfrastructureEncryptionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomParametersInternal.RequireInfrastructureEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)RequireInfrastructureEncryption).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)RequireInfrastructureEncryption).Type = value; }

        /// <summary>Backing field for <see cref="PrepareEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter _prepareEncryption;

        /// <summary>
        /// Prepare the workspace for encryption. Enables the Managed Identity for managed storage account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter PrepareEncryption { get => (this._prepareEncryption = this._prepareEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set => this._prepareEncryption = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? PrepareEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)PrepareEncryption).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? PrepareEncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)PrepareEncryption).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)PrepareEncryption).Value = value ?? default(bool); }

        /// <summary>Backing field for <see cref="RequireInfrastructureEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter _requireInfrastructureEncryption;

        /// <summary>
        /// A boolean indicating whether or not the DBFS root file system will be enabled with secondary layer of encryption with
        /// platform managed keys for data at rest.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter RequireInfrastructureEncryption { get => (this._requireInfrastructureEncryption = this._requireInfrastructureEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.WorkspaceCustomBooleanParameter()); set => this._requireInfrastructureEncryption = value; }

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RequireInfrastructureEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)RequireInfrastructureEncryption).Type; }

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? RequireInfrastructureEncryptionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)RequireInfrastructureEncryption).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameterInternal)RequireInfrastructureEncryption).Value = value ?? default(bool); }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyName = value ?? null; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeySource = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource)""); }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyVaultUri = value ?? null; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal)Encryption).ValueKeyVersion = value ?? null; }

        /// <summary>Creates an new <see cref="WorkspaceCustomParameters" /> instance.</summary>
        public WorkspaceCustomParameters()
        {

        }
    }
    /// Custom Parameters used for Cluster Creation.
    public partial interface IWorkspaceCustomParameters :
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

    }
    /// Custom Parameters used for Cluster Creation.
    internal partial interface IWorkspaceCustomParametersInternal

    {
        /// <summary>The ID of a Azure Machine Learning workspace to link with Databricks workspace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter AmlWorkspaceId { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? AmlWorkspaceIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string AmlWorkspaceIdValue { get; set; }
        /// <summary>The name of the Private Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPrivateSubnetName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPrivateSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPrivateSubnetNameValue { get; set; }
        /// <summary>The name of a Public Subnet within the Virtual Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomPublicSubnetName { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomPublicSubnetNameType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomPublicSubnetNameValue { get; set; }
        /// <summary>The ID of a Virtual Network where this Databricks Cluster should be created</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter CustomVirtualNetworkId { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? CustomVirtualNetworkIdType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string CustomVirtualNetworkIdValue { get; set; }
        /// <summary>Should the Public IP be Disabled?</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter EnableNoPublicIP { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EnableNoPublicIPType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? EnableNoPublicIPValue { get; set; }
        /// <summary>
        /// Contains the encryption details for Customer-Managed Key (CMK) enabled workspace.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter Encryption { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? EncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption EncryptionValue { get; set; }
        /// <summary>
        /// Prepare the workspace for encryption. Enables the Managed Identity for managed storage account.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter PrepareEncryption { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? PrepareEncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? PrepareEncryptionValue { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the DBFS root file system will be enabled with secondary layer of encryption with
        /// platform managed keys for data at rest.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomBooleanParameter RequireInfrastructureEncryption { get; set; }
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? RequireInfrastructureEncryptionType { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        bool? RequireInfrastructureEncryptionValue { get; set; }
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

    }
}