namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Represents an OAuth 2.0 delegated permission scope. The specified OAuth 2.0 delegated permission scopes may be requested
    /// by client applications (through the requiredResourceAccess collection on the Application object) when calling a resource
    /// application. The oauth2Permissions property of the ServicePrincipal entity and of the Application entity is a collection
    /// of OAuth2Permission.
    /// </summary>
    public partial class OAuth2Permission :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal
    {

        /// <summary>Backing field for <see cref="AdminConsentDescription" /> property.</summary>
        private string _adminConsentDescription;

        /// <summary>
        /// Permission help text that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AdminConsentDescription { get => this._adminConsentDescription; set => this._adminConsentDescription = value; }

        /// <summary>Backing field for <see cref="AdminConsentDisplayName" /> property.</summary>
        private string _adminConsentDisplayName;

        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AdminConsentDisplayName { get => this._adminConsentDisplayName; set => this._adminConsentDisplayName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Unique scope permission identifier inside the oauth2Permissions collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool? _isEnabled;

        /// <summary>
        /// When creating or updating a permission, this property must be set to true (which is the default). To delete a permission,
        /// this property must first be set to false. At that point, in a subsequent call, the permission may be removed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission
        /// that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UserConsentDescription" /> property.</summary>
        private string _userConsentDescription;

        /// <summary>Permission help text that appears in the end user consent experience.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string UserConsentDescription { get => this._userConsentDescription; set => this._userConsentDescription = value; }

        /// <summary>Backing field for <see cref="UserConsentDisplayName" /> property.</summary>
        private string _userConsentDisplayName;

        /// <summary>
        /// Display name for the permission that appears in the end user consent experience.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string UserConsentDisplayName { get => this._userConsentDisplayName; set => this._userConsentDisplayName = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OAuth2Permission" /> instance.</summary>
        public OAuth2Permission()
        {

        }
    }
    /// Represents an OAuth 2.0 delegated permission scope. The specified OAuth 2.0 delegated permission scopes may be requested
    /// by client applications (through the requiredResourceAccess collection on the Application object) when calling a resource
    /// application. The oauth2Permissions property of the ServicePrincipal entity and of the Application entity is a collection
    /// of OAuth2Permission.
    public partial interface IOAuth2Permission :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Permission help text that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permission help text that appears in the admin consent and app assignment experiences.",
        SerializedName = @"adminConsentDescription",
        PossibleTypes = new [] { typeof(string) })]
        string AdminConsentDescription { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name for the permission that appears in the admin consent and app assignment experiences.",
        SerializedName = @"adminConsentDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string AdminConsentDisplayName { get; set; }
        /// <summary>Unique scope permission identifier inside the oauth2Permissions collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique scope permission identifier inside the oauth2Permissions collection.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// When creating or updating a permission, this property must be set to true (which is the default). To delete a permission,
        /// this property must first be set to false. At that point, in a subsequent call, the permission may be removed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false. At that point, in a subsequent call, the permission may be removed. ",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }
        /// <summary>
        /// Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission
        /// that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission that must be consented to by a Company Administrator. Possible values are ""User"" or ""Admin"".",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>Permission help text that appears in the end user consent experience.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permission help text that appears in the end user consent experience.",
        SerializedName = @"userConsentDescription",
        PossibleTypes = new [] { typeof(string) })]
        string UserConsentDescription { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the end user consent experience.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name for the permission that appears in the end user consent experience.",
        SerializedName = @"userConsentDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string UserConsentDisplayName { get; set; }
        /// <summary>
        /// The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Represents an OAuth 2.0 delegated permission scope. The specified OAuth 2.0 delegated permission scopes may be requested
    /// by client applications (through the requiredResourceAccess collection on the Application object) when calling a resource
    /// application. The oauth2Permissions property of the ServicePrincipal entity and of the Application entity is a collection
    /// of OAuth2Permission.
    internal partial interface IOAuth2PermissionInternal

    {
        /// <summary>
        /// Permission help text that appears in the admin consent and app assignment experiences.
        /// </summary>
        string AdminConsentDescription { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        string AdminConsentDisplayName { get; set; }
        /// <summary>Unique scope permission identifier inside the oauth2Permissions collection.</summary>
        string Id { get; set; }
        /// <summary>
        /// When creating or updating a permission, this property must be set to true (which is the default). To delete a permission,
        /// this property must first be set to false. At that point, in a subsequent call, the permission may be removed.
        /// </summary>
        bool? IsEnabled { get; set; }
        /// <summary>
        /// Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission
        /// that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
        /// </summary>
        string Type { get; set; }
        /// <summary>Permission help text that appears in the end user consent experience.</summary>
        string UserConsentDescription { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the end user consent experience.
        /// </summary>
        string UserConsentDisplayName { get; set; }
        /// <summary>
        /// The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
        /// </summary>
        string Value { get; set; }

    }
}