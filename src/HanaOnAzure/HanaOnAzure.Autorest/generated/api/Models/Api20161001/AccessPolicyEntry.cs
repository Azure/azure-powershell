namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>
    /// An identity that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's
    /// tenant ID.
    /// </summary>
    public partial class AccessPolicyEntry :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntryInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>Application ID of the client making request on behalf of a principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Internal Acessors for Permission</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntryInternal.Permission { get => (this._permission = this._permission ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.Permissions()); set { {_permission = value;} } }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>
        /// The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object
        /// ID must be unique for the list of access policies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions _permission;

        /// <summary>Permissions the identity has for keys, secrets and certificates.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions Permission { get => (this._permission = this._permission ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.Permissions()); set => this._permission = value; }

        /// <summary>Permissions to certificates</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] PermissionCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Certificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Certificate = value; }

        /// <summary>Permissions to keys</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] PermissionKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Key; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Key = value; }

        /// <summary>Permissions to secrets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] PermissionSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Secret; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Secret = value; }

        /// <summary>Permissions to storage accounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] PermissionStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Storage; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissionsInternal)Permission).Storage = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="AccessPolicyEntry" /> instance.</summary>
        public AccessPolicyEntry()
        {

        }
    }
    /// An identity that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's
    /// tenant ID.
    public partial interface IAccessPolicyEntry :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>Application ID of the client making request on behalf of a principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @" Application ID of the client making request on behalf of a principal",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }
        /// <summary>
        /// The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object
        /// ID must be unique for the list of access policies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get; set; }
        /// <summary>Permissions to certificates</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to certificates",
        SerializedName = @"certificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] PermissionCertificate { get; set; }
        /// <summary>Permissions to keys</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to keys",
        SerializedName = @"keys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] PermissionKey { get; set; }
        /// <summary>Permissions to secrets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to secrets",
        SerializedName = @"secrets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] PermissionSecret { get; set; }
        /// <summary>Permissions to storage accounts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permissions to storage accounts",
        SerializedName = @"storage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] PermissionStorage { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// An identity that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's
    /// tenant ID.
    internal partial interface IAccessPolicyEntryInternal

    {
        /// <summary>Application ID of the client making request on behalf of a principal</summary>
        string ApplicationId { get; set; }
        /// <summary>
        /// The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object
        /// ID must be unique for the list of access policies.
        /// </summary>
        string ObjectId { get; set; }
        /// <summary>Permissions the identity has for keys, secrets and certificates.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IPermissions Permission { get; set; }
        /// <summary>Permissions to certificates</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CertificatePermissions[] PermissionCertificate { get; set; }
        /// <summary>Permissions to keys</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.KeyPermissions[] PermissionKey { get; set; }
        /// <summary>Permissions to secrets</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SecretPermissions[] PermissionSecret { get; set; }
        /// <summary>Permissions to storage accounts</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.StoragePermissions[] PermissionStorage { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; set; }

    }
}