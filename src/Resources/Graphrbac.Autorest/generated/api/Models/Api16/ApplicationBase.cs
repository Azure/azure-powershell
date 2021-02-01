namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directive Application common properties shared among GET, POST and PATCH</summary>
    public partial class ApplicationBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBase,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal
    {

        /// <summary>Backing field for <see cref="AllowGuestsSignIn" /> property.</summary>
        private bool? _allowGuestsSignIn;

        /// <summary>
        /// A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AllowGuestsSignIn { get => this._allowGuestsSignIn; set => this._allowGuestsSignIn = value; }

        /// <summary>Backing field for <see cref="AllowPassthroughUser" /> property.</summary>
        private bool? _allowPassthroughUser;

        /// <summary>
        /// Indicates that the application supports pass through users who have no presence in the resource tenant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AllowPassthroughUser { get => this._allowPassthroughUser; set => this._allowPassthroughUser = value; }

        /// <summary>Backing field for <see cref="AppLogoUrl" /> property.</summary>
        private string _appLogoUrl;

        /// <summary>The url for the application logo image stored in a CDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppLogoUrl { get => this._appLogoUrl; set => this._appLogoUrl = value; }

        /// <summary>Backing field for <see cref="AppPermission" /> property.</summary>
        private string[] _appPermission;

        /// <summary>The application permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] AppPermission { get => this._appPermission; set => this._appPermission = value; }

        /// <summary>Backing field for <see cref="AppRole" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] _appRole;

        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get => this._appRole; set => this._appRole = value; }

        /// <summary>Backing field for <see cref="AvailableToOtherTenant" /> property.</summary>
        private bool? _availableToOtherTenant;

        /// <summary>Whether the application is available to other tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AvailableToOtherTenant { get => this._availableToOtherTenant; set => this._availableToOtherTenant = value; }

        /// <summary>Backing field for <see cref="ErrorUrl" /> property.</summary>
        private string _errorUrl;

        /// <summary>
        /// A URL provided by the author of the application to report errors when using the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ErrorUrl { get => this._errorUrl; set => this._errorUrl = value; }

        /// <summary>Backing field for <see cref="GroupMembershipClaim" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes? _groupMembershipClaim;

        /// <summary>
        /// Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes? GroupMembershipClaim { get => this._groupMembershipClaim; set => this._groupMembershipClaim = value; }

        /// <summary>Backing field for <see cref="Homepage" /> property.</summary>
        private string _homepage;

        /// <summary>The home page of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Homepage { get => this._homepage; set => this._homepage = value; }

        /// <summary>Backing field for <see cref="InformationalUrl" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl _informationalUrl;

        /// <summary>URLs with more information about the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl InformationalUrl { get => (this._informationalUrl = this._informationalUrl ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrl()); set => this._informationalUrl = value; }

        /// <summary>The marketing URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string InformationalUrlMarketing { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Marketing; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Marketing = value; }

        /// <summary>The privacy policy URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string InformationalUrlPrivacy { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Privacy; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Privacy = value; }

        /// <summary>The support URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string InformationalUrlSupport { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Support; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).Support = value; }

        /// <summary>The terms of service URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string InformationalUrlTermsOfService { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).TermsOfService; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrlInternal)InformationalUrl).TermsOfService = value; }

        /// <summary>Backing field for <see cref="IsDeviceOnlyAuthSupported" /> property.</summary>
        private bool? _isDeviceOnlyAuthSupported;

        /// <summary>
        /// Specifies whether this application supports device authentication without a user. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IsDeviceOnlyAuthSupported { get => this._isDeviceOnlyAuthSupported; set => this._isDeviceOnlyAuthSupported = value; }

        /// <summary>Backing field for <see cref="KeyCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] _keyCredentials;

        /// <summary>A collection of KeyCredential objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get => this._keyCredentials; set => this._keyCredentials = value; }

        /// <summary>Backing field for <see cref="KnownClientApplication" /> property.</summary>
        private string[] _knownClientApplication;

        /// <summary>
        /// Client applications that are tied to this resource application. Consent to any of the known client applications will result
        /// in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes
        /// required by the client and the resource).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] KnownClientApplication { get => this._knownClientApplication; set => this._knownClientApplication = value; }

        /// <summary>Backing field for <see cref="LogoutUrl" /> property.</summary>
        private string _logoutUrl;

        /// <summary>the url of the logout page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string LogoutUrl { get => this._logoutUrl; set => this._logoutUrl = value; }

        /// <summary>Internal Acessors for InformationalUrl</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal.InformationalUrl { get => (this._informationalUrl = this._informationalUrl ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrl()); set { {_informationalUrl = value;} } }

        /// <summary>Internal Acessors for OptionalClaim</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal.OptionalClaim { get => (this._optionalClaim = this._optionalClaim ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaims()); set { {_optionalClaim = value;} } }

        /// <summary>Backing field for <see cref="Oauth2AllowImplicitFlow" /> property.</summary>
        private bool? _oauth2AllowImplicitFlow;

        /// <summary>Whether to allow implicit grant flow for OAuth2</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? Oauth2AllowImplicitFlow { get => this._oauth2AllowImplicitFlow; set => this._oauth2AllowImplicitFlow = value; }

        /// <summary>Backing field for <see cref="Oauth2AllowUrlPathMatching" /> property.</summary>
        private bool? _oauth2AllowUrlPathMatching;

        /// <summary>
        /// Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications
        /// collection of replyURLs. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? Oauth2AllowUrlPathMatching { get => this._oauth2AllowUrlPathMatching; set => this._oauth2AllowUrlPathMatching = value; }

        /// <summary>Backing field for <see cref="Oauth2Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] _oauth2Permission;

        /// <summary>
        /// The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
        /// These permission scopes may be granted to client applications during consent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get => this._oauth2Permission; set => this._oauth2Permission = value; }

        /// <summary>Backing field for <see cref="Oauth2RequirePostResponse" /> property.</summary>
        private bool? _oauth2RequirePostResponse;

        /// <summary>
        /// Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
        /// The default is false, which specifies that only GET requests will be allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? Oauth2RequirePostResponse { get => this._oauth2RequirePostResponse; set => this._oauth2RequirePostResponse = value; }

        /// <summary>Backing field for <see cref="OptionalClaim" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims _optionalClaim;

        /// <summary>Specifying the claims to be included in the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims OptionalClaim { get => (this._optionalClaim = this._optionalClaim ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaims()); set => this._optionalClaim = value; }

        /// <summary>Optional claims requested to be included in the access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimAccessToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).AccessToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).AccessToken = value; }

        /// <summary>Optional claims requested to be included in the id token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimIdToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).IdToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).IdToken = value; }

        /// <summary>Optional claims requested to be included in the saml token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimSamlToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).SamlToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal)OptionalClaim).SamlToken = value; }

        /// <summary>Backing field for <see cref="OrgRestriction" /> property.</summary>
        private string[] _orgRestriction;

        /// <summary>A list of tenants allowed to access application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] OrgRestriction { get => this._orgRestriction; set => this._orgRestriction = value; }

        /// <summary>Backing field for <see cref="PasswordCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] _passwordCredentials;

        /// <summary>A collection of PasswordCredential objects</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get => this._passwordCredentials; set => this._passwordCredentials = value; }

        /// <summary>Backing field for <see cref="PreAuthorizedApplication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[] _preAuthorizedApplication;

        /// <summary>list of pre-authorized applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[] PreAuthorizedApplication { get => this._preAuthorizedApplication; set => this._preAuthorizedApplication = value; }

        /// <summary>Backing field for <see cref="PublicClient" /> property.</summary>
        private bool? _publicClient;

        /// <summary>
        /// Specifies whether this application is a public client (such as an installed application running on a mobile device). Default
        /// is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? PublicClient { get => this._publicClient; set => this._publicClient = value; }

        /// <summary>Backing field for <see cref="PublisherDomain" /> property.</summary>
        private string _publisherDomain;

        /// <summary>Reliable domain which can be used to identify an application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PublisherDomain { get => this._publisherDomain; set => this._publisherDomain = value; }

        /// <summary>Backing field for <see cref="ReplyUrl" /> property.</summary>
        private string[] _replyUrl;

        /// <summary>A collection of reply URLs for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] ReplyUrl { get => this._replyUrl; set => this._replyUrl = value; }

        /// <summary>Backing field for <see cref="RequiredResourceAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[] _requiredResourceAccess;

        /// <summary>
        /// Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles
        /// that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[] RequiredResourceAccess { get => this._requiredResourceAccess; set => this._requiredResourceAccess = value; }

        /// <summary>Backing field for <see cref="SamlMetadataUrl" /> property.</summary>
        private string _samlMetadataUrl;

        /// <summary>The URL to the SAML metadata for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string SamlMetadataUrl { get => this._samlMetadataUrl; set => this._samlMetadataUrl = value; }

        /// <summary>Backing field for <see cref="SignInAudience" /> property.</summary>
        private string _signInAudience;

        /// <summary>
        /// Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string SignInAudience { get => this._signInAudience; set => this._signInAudience = value; }

        /// <summary>Backing field for <see cref="WwwHomepage" /> property.</summary>
        private string _wwwHomepage;

        /// <summary>The primary Web page.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string WwwHomepage { get => this._wwwHomepage; set => this._wwwHomepage = value; }

        /// <summary>Creates an new <see cref="ApplicationBase" /> instance.</summary>
        public ApplicationBase()
        {

        }
    }
    /// Active Directive Application common properties shared among GET, POST and PATCH
    public partial interface IApplicationBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A property on the application to indicate if the application accepts other IDPs or not or partially accepts.",
        SerializedName = @"allowGuestsSignIn",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowGuestsSignIn { get; set; }
        /// <summary>
        /// Indicates that the application supports pass through users who have no presence in the resource tenant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates that the application supports pass through users who have no presence in the resource tenant.",
        SerializedName = @"allowPassthroughUsers",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowPassthroughUser { get; set; }
        /// <summary>The url for the application logo image stored in a CDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The url for the application logo image stored in a CDN.",
        SerializedName = @"appLogoUrl",
        PossibleTypes = new [] { typeof(string) })]
        string AppLogoUrl { get; set; }
        /// <summary>The application permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The application permissions.",
        SerializedName = @"appPermissions",
        PossibleTypes = new [] { typeof(string) })]
        string[] AppPermission { get; set; }
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
        /// <summary>Whether the application is available to other tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the application is available to other tenants.",
        SerializedName = @"availableToOtherTenants",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AvailableToOtherTenant { get; set; }
        /// <summary>
        /// A URL provided by the author of the application to report errors when using the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A URL provided by the author of the application to report errors when using the application.",
        SerializedName = @"errorUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorUrl { get; set; }
        /// <summary>
        /// Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.",
        SerializedName = @"groupMembershipClaims",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes? GroupMembershipClaim { get; set; }
        /// <summary>The home page of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The home page of the application.",
        SerializedName = @"homepage",
        PossibleTypes = new [] { typeof(string) })]
        string Homepage { get; set; }
        /// <summary>The marketing URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The marketing URI",
        SerializedName = @"marketing",
        PossibleTypes = new [] { typeof(string) })]
        string InformationalUrlMarketing { get; set; }
        /// <summary>The privacy policy URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The privacy policy URI",
        SerializedName = @"privacy",
        PossibleTypes = new [] { typeof(string) })]
        string InformationalUrlPrivacy { get; set; }
        /// <summary>The support URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The support URI",
        SerializedName = @"support",
        PossibleTypes = new [] { typeof(string) })]
        string InformationalUrlSupport { get; set; }
        /// <summary>The terms of service URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The terms of service URI",
        SerializedName = @"termsOfService",
        PossibleTypes = new [] { typeof(string) })]
        string InformationalUrlTermsOfService { get; set; }
        /// <summary>
        /// Specifies whether this application supports device authentication without a user. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether this application supports device authentication without a user. The default is false.",
        SerializedName = @"isDeviceOnlyAuthSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDeviceOnlyAuthSupported { get; set; }
        /// <summary>A collection of KeyCredential objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of KeyCredential objects.",
        SerializedName = @"keyCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>
        /// Client applications that are tied to this resource application. Consent to any of the known client applications will result
        /// in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes
        /// required by the client and the resource).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Client applications that are tied to this resource application. Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).",
        SerializedName = @"knownClientApplications",
        PossibleTypes = new [] { typeof(string) })]
        string[] KnownClientApplication { get; set; }
        /// <summary>the url of the logout page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the url of the logout page",
        SerializedName = @"logoutUrl",
        PossibleTypes = new [] { typeof(string) })]
        string LogoutUrl { get; set; }
        /// <summary>Whether to allow implicit grant flow for OAuth2</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to allow implicit grant flow for OAuth2",
        SerializedName = @"oauth2AllowImplicitFlow",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Oauth2AllowImplicitFlow { get; set; }
        /// <summary>
        /// Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications
        /// collection of replyURLs. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs. The default is false.",
        SerializedName = @"oauth2AllowUrlPathMatching",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Oauth2AllowUrlPathMatching { get; set; }
        /// <summary>
        /// The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
        /// These permission scopes may be granted to client applications during consent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.",
        SerializedName = @"oauth2Permissions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get; set; }
        /// <summary>
        /// Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
        /// The default is false, which specifies that only GET requests will be allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests. The default is false, which specifies that only GET requests will be allowed.",
        SerializedName = @"oauth2RequirePostResponse",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Oauth2RequirePostResponse { get; set; }
        /// <summary>Optional claims requested to be included in the access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the access token.",
        SerializedName = @"accessToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimAccessToken { get; set; }
        /// <summary>Optional claims requested to be included in the id token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the id token.",
        SerializedName = @"idToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimIdToken { get; set; }
        /// <summary>Optional claims requested to be included in the saml token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the saml token.",
        SerializedName = @"samlToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimSamlToken { get; set; }
        /// <summary>A list of tenants allowed to access application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of tenants allowed to access application.",
        SerializedName = @"orgRestrictions",
        PossibleTypes = new [] { typeof(string) })]
        string[] OrgRestriction { get; set; }
        /// <summary>A collection of PasswordCredential objects</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of PasswordCredential objects",
        SerializedName = @"passwordCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>list of pre-authorized applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"list of pre-authorized applications.",
        SerializedName = @"preAuthorizedApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[] PreAuthorizedApplication { get; set; }
        /// <summary>
        /// Specifies whether this application is a public client (such as an installed application running on a mobile device). Default
        /// is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether this application is a public client (such as an installed application running on a mobile device). Default is false.",
        SerializedName = @"publicClient",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PublicClient { get; set; }
        /// <summary>Reliable domain which can be used to identify an application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reliable domain which can be used to identify an application.",
        SerializedName = @"publisherDomain",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherDomain { get; set; }
        /// <summary>A collection of reply URLs for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of reply URLs for the application.",
        SerializedName = @"replyUrls",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReplyUrl { get; set; }
        /// <summary>
        /// Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles
        /// that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.",
        SerializedName = @"requiredResourceAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[] RequiredResourceAccess { get; set; }
        /// <summary>The URL to the SAML metadata for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to the SAML metadata for the application.",
        SerializedName = @"samlMetadataUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SamlMetadataUrl { get; set; }
        /// <summary>
        /// Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).",
        SerializedName = @"signInAudience",
        PossibleTypes = new [] { typeof(string) })]
        string SignInAudience { get; set; }
        /// <summary>The primary Web page.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary Web page.",
        SerializedName = @"wwwHomepage",
        PossibleTypes = new [] { typeof(string) })]
        string WwwHomepage { get; set; }

    }
    /// Active Directive Application common properties shared among GET, POST and PATCH
    internal partial interface IApplicationBaseInternal

    {
        /// <summary>
        /// A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
        /// </summary>
        bool? AllowGuestsSignIn { get; set; }
        /// <summary>
        /// Indicates that the application supports pass through users who have no presence in the resource tenant.
        /// </summary>
        bool? AllowPassthroughUser { get; set; }
        /// <summary>The url for the application logo image stored in a CDN.</summary>
        string AppLogoUrl { get; set; }
        /// <summary>The application permissions.</summary>
        string[] AppPermission { get; set; }
        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get; set; }
        /// <summary>Whether the application is available to other tenants.</summary>
        bool? AvailableToOtherTenant { get; set; }
        /// <summary>
        /// A URL provided by the author of the application to report errors when using the application.
        /// </summary>
        string ErrorUrl { get; set; }
        /// <summary>
        /// Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes? GroupMembershipClaim { get; set; }
        /// <summary>The home page of the application.</summary>
        string Homepage { get; set; }
        /// <summary>URLs with more information about the application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl InformationalUrl { get; set; }
        /// <summary>The marketing URI</summary>
        string InformationalUrlMarketing { get; set; }
        /// <summary>The privacy policy URI</summary>
        string InformationalUrlPrivacy { get; set; }
        /// <summary>The support URI</summary>
        string InformationalUrlSupport { get; set; }
        /// <summary>The terms of service URI</summary>
        string InformationalUrlTermsOfService { get; set; }
        /// <summary>
        /// Specifies whether this application supports device authentication without a user. The default is false.
        /// </summary>
        bool? IsDeviceOnlyAuthSupported { get; set; }
        /// <summary>A collection of KeyCredential objects.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>
        /// Client applications that are tied to this resource application. Consent to any of the known client applications will result
        /// in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes
        /// required by the client and the resource).
        /// </summary>
        string[] KnownClientApplication { get; set; }
        /// <summary>the url of the logout page</summary>
        string LogoutUrl { get; set; }
        /// <summary>Whether to allow implicit grant flow for OAuth2</summary>
        bool? Oauth2AllowImplicitFlow { get; set; }
        /// <summary>
        /// Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications
        /// collection of replyURLs. The default is false.
        /// </summary>
        bool? Oauth2AllowUrlPathMatching { get; set; }
        /// <summary>
        /// The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
        /// These permission scopes may be granted to client applications during consent.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get; set; }
        /// <summary>
        /// Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
        /// The default is false, which specifies that only GET requests will be allowed.
        /// </summary>
        bool? Oauth2RequirePostResponse { get; set; }
        /// <summary>Specifying the claims to be included in the token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims OptionalClaim { get; set; }
        /// <summary>Optional claims requested to be included in the access token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimAccessToken { get; set; }
        /// <summary>Optional claims requested to be included in the id token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimIdToken { get; set; }
        /// <summary>Optional claims requested to be included in the saml token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimSamlToken { get; set; }
        /// <summary>A list of tenants allowed to access application.</summary>
        string[] OrgRestriction { get; set; }
        /// <summary>A collection of PasswordCredential objects</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>list of pre-authorized applications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[] PreAuthorizedApplication { get; set; }
        /// <summary>
        /// Specifies whether this application is a public client (such as an installed application running on a mobile device). Default
        /// is false.
        /// </summary>
        bool? PublicClient { get; set; }
        /// <summary>Reliable domain which can be used to identify an application.</summary>
        string PublisherDomain { get; set; }
        /// <summary>A collection of reply URLs for the application.</summary>
        string[] ReplyUrl { get; set; }
        /// <summary>
        /// Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles
        /// that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[] RequiredResourceAccess { get; set; }
        /// <summary>The URL to the SAML metadata for the application.</summary>
        string SamlMetadataUrl { get; set; }
        /// <summary>
        /// Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
        /// </summary>
        string SignInAudience { get; set; }
        /// <summary>The primary Web page.</summary>
        string WwwHomepage { get; set; }

    }
}