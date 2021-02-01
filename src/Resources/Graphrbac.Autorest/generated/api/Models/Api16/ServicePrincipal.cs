namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory service principal information.</summary>
    public partial class ServicePrincipal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject();

        /// <summary>Backing field for <see cref="AccountEnabled" /> property.</summary>
        private bool? _accountEnabled;

        /// <summary>whether or not the service principal account is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AccountEnabled { get => this._accountEnabled; set => this._accountEnabled = value; }

        /// <summary>Backing field for <see cref="AlternativeName" /> property.</summary>
        private string[] _alternativeName;

        /// <summary>alternative names</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] AlternativeName { get => this._alternativeName; set => this._alternativeName = value; }

        /// <summary>Backing field for <see cref="AppDisplayName" /> property.</summary>
        private string _appDisplayName;

        /// <summary>The display name exposed by the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppDisplayName { get => this._appDisplayName; }

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>The application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>Backing field for <see cref="AppOwnerTenantId" /> property.</summary>
        private string _appOwnerTenantId;

        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppOwnerTenantId { get => this._appOwnerTenantId; }

        /// <summary>Backing field for <see cref="AppRole" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] _appRole;

        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get => this._appRole; set => this._appRole = value; }

        /// <summary>Backing field for <see cref="AppRoleAssignmentRequired" /> property.</summary>
        private bool? _appRoleAssignmentRequired;

        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AppRoleAssignmentRequired { get => this._appRoleAssignmentRequired; set => this._appRoleAssignmentRequired = value; }

        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public global::System.DateTime? DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="ErrorUrl" /> property.</summary>
        private string _errorUrl;

        /// <summary>
        /// A URL provided by the author of the associated application to report errors when using the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ErrorUrl { get => this._errorUrl; set => this._errorUrl = value; }

        /// <summary>Backing field for <see cref="Homepage" /> property.</summary>
        private string _homepage;

        /// <summary>The URL to the homepage of the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Homepage { get => this._homepage; set => this._homepage = value; }

        /// <summary>Backing field for <see cref="KeyCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] _keyCredentials;

        /// <summary>The collection of key credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get => this._keyCredentials; set => this._keyCredentials = value; }

        /// <summary>Backing field for <see cref="LogoutUrl" /> property.</summary>
        private string _logoutUrl;

        /// <summary>A URL provided by the author of the associated application to logout</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string LogoutUrl { get => this._logoutUrl; set => this._logoutUrl = value; }

        /// <summary>Internal Acessors for DeletionTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp = value; }

        /// <summary>Internal Acessors for ObjectId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId = value; }

        /// <summary>Internal Acessors for AppDisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal.AppDisplayName { get => this._appDisplayName; set { {_appDisplayName = value;} } }

        /// <summary>Internal Acessors for AppOwnerTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal.AppOwnerTenantId { get => this._appOwnerTenantId; set { {_appOwnerTenantId = value;} } }

        /// <summary>Internal Acessors for Oauth2Permission</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalInternal.Oauth2Permission { get => this._oauth2Permission; set { {_oauth2Permission = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string[] _name;

        /// <summary>A collection of service principal names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Oauth2Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] _oauth2Permission;

        /// <summary>The OAuth 2.0 permissions exposed by the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get => this._oauth2Permission; }

        /// <summary>The object ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; }

        /// <summary>The object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType = value; }

        /// <summary>Backing field for <see cref="PasswordCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] _passwordCredentials;

        /// <summary>The collection of password credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get => this._passwordCredentials; set => this._passwordCredentials = value; }

        /// <summary>Backing field for <see cref="PreferredTokenSigningKeyThumbprint" /> property.</summary>
        private string _preferredTokenSigningKeyThumbprint;

        /// <summary>The thumbprint of preferred certificate to sign the token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PreferredTokenSigningKeyThumbprint { get => this._preferredTokenSigningKeyThumbprint; set => this._preferredTokenSigningKeyThumbprint = value; }

        /// <summary>Backing field for <see cref="PublisherName" /> property.</summary>
        private string _publisherName;

        /// <summary>The publisher's name of the associated application</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PublisherName { get => this._publisherName; set => this._publisherName = value; }

        /// <summary>Backing field for <see cref="ReplyUrl" /> property.</summary>
        private string[] _replyUrl;

        /// <summary>
        /// The URLs that user tokens are sent to for sign in with the associated application. The redirect URIs that the oAuth 2.0
        /// authorization code and access tokens are sent to for the associated application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] ReplyUrl { get => this._replyUrl; set => this._replyUrl = value; }

        /// <summary>Backing field for <see cref="SamlMetadataUrl" /> property.</summary>
        private string _samlMetadataUrl;

        /// <summary>The URL to the SAML metadata of the associated application</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string SamlMetadataUrl { get => this._samlMetadataUrl; set => this._samlMetadataUrl = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private string[] _tag;

        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>the type of the service principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ServicePrincipal" /> instance.</summary>
        public ServicePrincipal()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__directoryObject), __directoryObject);
            await eventListener.AssertObjectIsValid(nameof(__directoryObject), __directoryObject);
        }
    }
    /// Active Directory service principal information.
    public partial interface IServicePrincipal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject
    {
        /// <summary>whether or not the service principal account is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"whether or not the service principal account is enabled",
        SerializedName = @"accountEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AccountEnabled { get; set; }
        /// <summary>alternative names</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"alternative names",
        SerializedName = @"alternativeNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] AlternativeName { get; set; }
        /// <summary>The display name exposed by the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name exposed by the associated application.",
        SerializedName = @"appDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string AppDisplayName { get;  }
        /// <summary>The application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The application ID.",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"appOwnerTenantId",
        PossibleTypes = new [] { typeof(string) })]
        string AppOwnerTenantId { get;  }
        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.",
        SerializedName = @"appRoles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get; set; }
        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token to the application.",
        SerializedName = @"appRoleAssignmentRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AppRoleAssignmentRequired { get; set; }
        /// <summary>The display name of the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the service principal.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// A URL provided by the author of the associated application to report errors when using the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URL provided by the author of the associated application to report errors when using the application.",
        SerializedName = @"errorUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorUrl { get; set; }
        /// <summary>The URL to the homepage of the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to the homepage of the associated application.",
        SerializedName = @"homepage",
        PossibleTypes = new [] { typeof(string) })]
        string Homepage { get; set; }
        /// <summary>The collection of key credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of key credentials associated with the service principal.",
        SerializedName = @"keyCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>A URL provided by the author of the associated application to logout</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URL provided by the author of the associated application to logout",
        SerializedName = @"logoutUrl",
        PossibleTypes = new [] { typeof(string) })]
        string LogoutUrl { get; set; }
        /// <summary>A collection of service principal names.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of service principal names.",
        SerializedName = @"servicePrincipalNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] Name { get; set; }
        /// <summary>The OAuth 2.0 permissions exposed by the associated application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OAuth 2.0 permissions exposed by the associated application.",
        SerializedName = @"oauth2Permissions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get;  }
        /// <summary>The collection of password credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of password credentials associated with the service principal.",
        SerializedName = @"passwordCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>The thumbprint of preferred certificate to sign the token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The thumbprint of preferred certificate to sign the token",
        SerializedName = @"preferredTokenSigningKeyThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string PreferredTokenSigningKeyThumbprint { get; set; }
        /// <summary>The publisher's name of the associated application</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The publisher's name of the associated application",
        SerializedName = @"publisherName",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherName { get; set; }
        /// <summary>
        /// The URLs that user tokens are sent to for sign in with the associated application. The redirect URIs that the oAuth 2.0
        /// authorization code and access tokens are sent to for the associated application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URLs that user tokens are sent to for sign in with the associated application.  The redirect URIs that the oAuth 2.0 authorization code and access tokens are sent to for the associated application.",
        SerializedName = @"replyUrls",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReplyUrl { get; set; }
        /// <summary>The URL to the SAML metadata of the associated application</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to the SAML metadata of the associated application",
        SerializedName = @"samlMetadataUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SamlMetadataUrl { get; set; }
        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional list of tags that you can apply to your service principals. Not nullable.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(string) })]
        string[] Tag { get; set; }
        /// <summary>the type of the service principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the type of the service principal",
        SerializedName = @"servicePrincipalType",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Active Directory service principal information.
    internal partial interface IServicePrincipalInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal
    {
        /// <summary>whether or not the service principal account is enabled</summary>
        bool? AccountEnabled { get; set; }
        /// <summary>alternative names</summary>
        string[] AlternativeName { get; set; }
        /// <summary>The display name exposed by the associated application.</summary>
        string AppDisplayName { get; set; }
        /// <summary>The application ID.</summary>
        string AppId { get; set; }

        string AppOwnerTenantId { get; set; }
        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get; set; }
        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        bool? AppRoleAssignmentRequired { get; set; }
        /// <summary>The display name of the service principal.</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// A URL provided by the author of the associated application to report errors when using the application.
        /// </summary>
        string ErrorUrl { get; set; }
        /// <summary>The URL to the homepage of the associated application.</summary>
        string Homepage { get; set; }
        /// <summary>The collection of key credentials associated with the service principal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>A URL provided by the author of the associated application to logout</summary>
        string LogoutUrl { get; set; }
        /// <summary>A collection of service principal names.</summary>
        string[] Name { get; set; }
        /// <summary>The OAuth 2.0 permissions exposed by the associated application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get; set; }
        /// <summary>The collection of password credentials associated with the service principal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>The thumbprint of preferred certificate to sign the token</summary>
        string PreferredTokenSigningKeyThumbprint { get; set; }
        /// <summary>The publisher's name of the associated application</summary>
        string PublisherName { get; set; }
        /// <summary>
        /// The URLs that user tokens are sent to for sign in with the associated application. The redirect URIs that the oAuth 2.0
        /// authorization code and access tokens are sent to for the associated application.
        /// </summary>
        string[] ReplyUrl { get; set; }
        /// <summary>The URL to the SAML metadata of the associated application</summary>
        string SamlMetadataUrl { get; set; }
        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        string[] Tag { get; set; }
        /// <summary>the type of the service principal</summary>
        string Type { get; set; }

    }
}