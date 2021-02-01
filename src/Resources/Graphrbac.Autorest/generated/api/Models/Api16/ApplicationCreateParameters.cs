namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for creating a new application.</summary>
    public partial class ApplicationCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationCreateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationCreateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBase" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBase __applicationBase = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ApplicationBase();

        /// <summary>
        /// A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? AllowGuestsSignIn { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AllowGuestsSignIn; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AllowGuestsSignIn = value; }

        /// <summary>
        /// Indicates that the application supports pass through users who have no presence in the resource tenant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? AllowPassthroughUser { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AllowPassthroughUser; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AllowPassthroughUser = value; }

        /// <summary>The url for the application logo image stored in a CDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string AppLogoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppLogoUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppLogoUrl = value; }

        /// <summary>The application permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string[] AppPermission { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppPermission; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppPermission = value; }

        /// <summary>
        /// The collection of application roles that an application may declare. These roles can be assigned to users, groups or service
        /// principals.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[] AppRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AppRole = value; }

        /// <summary>Whether the application is available to other tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? AvailableToOtherTenant { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AvailableToOtherTenant; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).AvailableToOtherTenant = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>
        /// A URL provided by the author of the application to report errors when using the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ErrorUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).ErrorUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).ErrorUrl = value; }

        /// <summary>
        /// Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes? GroupMembershipClaim { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).GroupMembershipClaim; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).GroupMembershipClaim = value; }

        /// <summary>The home page of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string Homepage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Homepage; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Homepage = value; }

        /// <summary>Backing field for <see cref="IdentifierUri" /> property.</summary>
        private string[] _identifierUri;

        /// <summary>A collection of URIs for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] IdentifierUri { get => this._identifierUri; set => this._identifierUri = value; }

        /// <summary>URLs with more information about the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IInformationalUrl InformationalUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrl = value; }

        /// <summary>The marketing URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string InformationalUrlMarketing { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlMarketing; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlMarketing = value; }

        /// <summary>The privacy policy URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string InformationalUrlPrivacy { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlPrivacy; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlPrivacy = value; }

        /// <summary>The support URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string InformationalUrlSupport { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlSupport; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlSupport = value; }

        /// <summary>The terms of service URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string InformationalUrlTermsOfService { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlTermsOfService; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).InformationalUrlTermsOfService = value; }

        /// <summary>
        /// Specifies whether this application supports device authentication without a user. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? IsDeviceOnlyAuthSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).IsDeviceOnlyAuthSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).IsDeviceOnlyAuthSupported = value; }

        /// <summary>A collection of KeyCredential objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).KeyCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).KeyCredentials = value; }

        /// <summary>
        /// Client applications that are tied to this resource application. Consent to any of the known client applications will result
        /// in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes
        /// required by the client and the resource).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string[] KnownClientApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).KnownClientApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).KnownClientApplication = value; }

        /// <summary>the url of the logout page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string LogoutUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).LogoutUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).LogoutUrl = value; }

        /// <summary>Whether to allow implicit grant flow for OAuth2</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? Oauth2AllowImplicitFlow { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2AllowImplicitFlow; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2AllowImplicitFlow = value; }

        /// <summary>
        /// Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications
        /// collection of replyURLs. The default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? Oauth2AllowUrlPathMatching { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2AllowUrlPathMatching; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2AllowUrlPathMatching = value; }

        /// <summary>
        /// The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
        /// These permission scopes may be granted to client applications during consent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[] Oauth2Permission { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2Permission; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2Permission = value; }

        /// <summary>
        /// Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
        /// The default is false, which specifies that only GET requests will be allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? Oauth2RequirePostResponse { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2RequirePostResponse; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).Oauth2RequirePostResponse = value; }

        /// <summary>Specifying the claims to be included in the token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims OptionalClaim { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaim; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaim = value; }

        /// <summary>Optional claims requested to be included in the access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimAccessToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimAccessToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimAccessToken = value; }

        /// <summary>Optional claims requested to be included in the id token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimIdToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimIdToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimIdToken = value; }

        /// <summary>Optional claims requested to be included in the saml token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] OptionalClaimSamlToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimSamlToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OptionalClaimSamlToken = value; }

        /// <summary>A list of tenants allowed to access application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string[] OrgRestriction { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OrgRestriction; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).OrgRestriction = value; }

        /// <summary>A collection of PasswordCredential objects</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PasswordCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PasswordCredentials = value; }

        /// <summary>list of pre-authorized applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[] PreAuthorizedApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PreAuthorizedApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PreAuthorizedApplication = value; }

        /// <summary>
        /// Specifies whether this application is a public client (such as an installed application running on a mobile device). Default
        /// is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? PublicClient { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PublicClient; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PublicClient = value; }

        /// <summary>Reliable domain which can be used to identify an application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string PublisherDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PublisherDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).PublisherDomain = value; }

        /// <summary>A collection of reply URLs for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string[] ReplyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).ReplyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).ReplyUrl = value; }

        /// <summary>
        /// Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles
        /// that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[] RequiredResourceAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).RequiredResourceAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).RequiredResourceAccess = value; }

        /// <summary>The URL to the SAML metadata for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string SamlMetadataUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).SamlMetadataUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).SamlMetadataUrl = value; }

        /// <summary>
        /// Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string SignInAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).SignInAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).SignInAudience = value; }

        /// <summary>The primary Web page.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string WwwHomepage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).WwwHomepage; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal)__applicationBase).WwwHomepage = value; }

        /// <summary>Creates an new <see cref="ApplicationCreateParameters" /> instance.</summary>
        public ApplicationCreateParameters()
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
            await eventListener.AssertNotNull(nameof(__applicationBase), __applicationBase);
            await eventListener.AssertObjectIsValid(nameof(__applicationBase), __applicationBase);
        }
    }
    /// Request parameters for creating a new application.
    public partial interface IApplicationCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBase
    {
        /// <summary>The display name of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The display name of the application.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>A collection of URIs for the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of URIs for the application.",
        SerializedName = @"identifierUris",
        PossibleTypes = new [] { typeof(string) })]
        string[] IdentifierUri { get; set; }

    }
    /// Request parameters for creating a new application.
    internal partial interface IApplicationCreateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationBaseInternal
    {
        /// <summary>The display name of the application.</summary>
        string DisplayName { get; set; }
        /// <summary>A collection of URIs for the application.</summary>
        string[] IdentifierUri { get; set; }

    }
}