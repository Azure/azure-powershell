namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    /// </summary>
    public partial class SiteAuthSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint when
        /// a user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AdditionalLoginParam { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AdditionalLoginParam; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AdditionalLoginParam = value; }

        /// <summary>
        /// Allowed audience values to consider when validating JWTs issued by
        /// Azure Active Directory. Note that the <code>ClientID</code> value is always considered an
        /// allowed audience, regardless of this setting.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AllowedAudience { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AllowedAudience; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AllowedAudience = value; }

        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part
        /// of the URL is ignored.
        /// This is an advanced setting typically only needed by Windows Store application backends.
        /// Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AllowedExternalRedirectUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AllowedExternalRedirectUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).AllowedExternalRedirectUrl = value; }

        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.
        /// This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        /// other 3rd party OpenID Connect providers.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientId = value; }

        /// <summary>
        /// The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).
        /// This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate
        /// end users.
        /// Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientSecret = value; }

        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property
        /// acts as
        /// a replacement for the Client Secret. It is also optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ClientSecretCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientSecretCertificateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ClientSecretCertificateThumbprint = value; }

        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.
        /// This setting is only needed if multiple providers are configured and the unauthenticated client
        /// action is set to "RedirectToLoginPage".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider? DefaultProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).DefaultProvider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).DefaultProvider = value; }

        /// <summary>
        /// <code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).Enabled = value; }

        /// <summary>
        /// The App ID of the Facebook app used for login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FacebookAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookAppId = value; }

        /// <summary>
        /// The App Secret of the Facebook app used for Facebook Login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FacebookAppSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookAppSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookAppSecret = value; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.
        /// This setting is optional.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] FacebookOAuthScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookOAuthScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).FacebookOAuthScope = value; }

        /// <summary>
        /// The OpenID Connect Client ID for the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string GoogleClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleClientId = value; }

        /// <summary>
        /// The client secret associated with the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string GoogleClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleClientSecret = value; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.
        /// This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] GoogleOAuthScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleOAuthScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).GoogleOAuthScope = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        /// When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.
        /// This URI is a case-sensitive identifier for the token issuer.
        /// More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).Issuer = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties()); set { {_property = value;} } }

        /// <summary>
        /// The OAuth 2.0 client ID that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MicrosoftAccountClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountClientId = value; }

        /// <summary>
        /// The OAuth 2.0 client secret that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MicrosoftAccountClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountClientSecret = value; }

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.
        /// This setting is optional. If not specified, "wl.basic" is used as the default scope.
        /// Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] MicrosoftAccountOAuthScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountOAuthScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).MicrosoftAccountOAuthScope = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties _property;

        /// <summary>SiteAuthSettings resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties()); set => this._property = value; }

        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.
        /// The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RuntimeVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).RuntimeVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).RuntimeVersion = value; }

        /// <summary>
        /// The number of hours after session token expiration that a session token can be used to
        /// call the token refresh API. The default is 72 hours.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? TokenRefreshExtensionHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TokenRefreshExtensionHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TokenRefreshExtensionHour = value; }

        /// <summary>
        /// <code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise,
        /// <code>false</code>.
        /// The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? TokenStoreEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TokenStoreEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TokenStoreEnabled = value; }

        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TwitterConsumerKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TwitterConsumerKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TwitterConsumerKey = value; }

        /// <summary>
        /// The OAuth 1.0a consumer secret of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TwitterConsumerSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TwitterConsumerSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).TwitterConsumerSecret = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>The action to take when an unauthenticated client attempts to access the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction? UnauthenticatedClientAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).UnauthenticatedClientAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).UnauthenticatedClientAction = value; }

        /// <summary>
        /// Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ValidateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ValidateIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)Property).ValidateIssuer = value; }

        /// <summary>Creates an new <see cref="SiteAuthSettings" /> instance.</summary>
        public SiteAuthSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    public partial interface ISiteAuthSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint when
        /// a user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Login parameters to send to the OpenID Connect authorization endpoint when
        a user logs in. Each parameter must be in the form ""key=value"".",
        SerializedName = @"additionalLoginParams",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdditionalLoginParam { get; set; }
        /// <summary>
        /// Allowed audience values to consider when validating JWTs issued by
        /// Azure Active Directory. Note that the <code>ClientID</code> value is always considered an
        /// allowed audience, regardless of this setting.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allowed audience values to consider when validating JWTs issued by
        Azure Active Directory. Note that the <code>ClientID</code> value is always considered an
        allowed audience, regardless of this setting.",
        SerializedName = @"allowedAudiences",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedAudience { get; set; }
        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part
        /// of the URL is ignored.
        /// This is an advanced setting typically only needed by Windows Store application backends.
        /// Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part of the URL is ignored.
        This is an advanced setting typically only needed by Windows Store application backends.
        Note that URLs within the current domain are always implicitly allowed.",
        SerializedName = @"allowedExternalRedirectUrls",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedExternalRedirectUrl { get; set; }
        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.
        /// This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        /// other 3rd party OpenID Connect providers.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Client ID of this relying party application, known as the client_id.
        This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        other 3rd party OpenID Connect providers.
        More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>
        /// The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).
        /// This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate
        /// end users.
        /// Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).
        This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate end users.
        Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.
        More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecret { get; set; }
        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property
        /// acts as
        /// a replacement for the Client Secret. It is also optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property acts as
        a replacement for the Client Secret. It is also optional.",
        SerializedName = @"clientSecretCertificateThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecretCertificateThumbprint { get; set; }
        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.
        /// This setting is only needed if multiple providers are configured and the unauthenticated client
        /// action is set to "RedirectToLoginPage".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default authentication provider to use when multiple providers are configured.
        This setting is only needed if multiple providers are configured and the unauthenticated client
        action is set to ""RedirectToLoginPage"".",
        SerializedName = @"defaultProvider",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider? DefaultProvider { get; set; }
        /// <summary>
        /// <code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// The App ID of the Facebook app used for login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The App ID of the Facebook app used for login.
        This setting is required for enabling Facebook Login.
        Facebook Login documentation: https://developers.facebook.com/docs/facebook-login",
        SerializedName = @"facebookAppId",
        PossibleTypes = new [] { typeof(string) })]
        string FacebookAppId { get; set; }
        /// <summary>
        /// The App Secret of the Facebook app used for Facebook Login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The App Secret of the Facebook app used for Facebook Login.
        This setting is required for enabling Facebook Login.
        Facebook Login documentation: https://developers.facebook.com/docs/facebook-login",
        SerializedName = @"facebookAppSecret",
        PossibleTypes = new [] { typeof(string) })]
        string FacebookAppSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.
        /// This setting is optional.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.
        This setting is optional.
        Facebook Login documentation: https://developers.facebook.com/docs/facebook-login",
        SerializedName = @"facebookOAuthScopes",
        PossibleTypes = new [] { typeof(string) })]
        string[] FacebookOAuthScope { get; set; }
        /// <summary>
        /// The OpenID Connect Client ID for the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OpenID Connect Client ID for the Google web application.
        This setting is required for enabling Google Sign-In.
        Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/",
        SerializedName = @"googleClientId",
        PossibleTypes = new [] { typeof(string) })]
        string GoogleClientId { get; set; }
        /// <summary>
        /// The client secret associated with the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client secret associated with the Google web application.
        This setting is required for enabling Google Sign-In.
        Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/",
        SerializedName = @"googleClientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string GoogleClientSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.
        /// This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.
        This setting is optional. If not specified, ""openid"", ""profile"", and ""email"" are used as default scopes.
        Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/",
        SerializedName = @"googleOAuthScopes",
        PossibleTypes = new [] { typeof(string) })]
        string[] GoogleOAuthScope { get; set; }
        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        /// When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.
        /// This URI is a case-sensitive identifier for the token issuer.
        /// More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.
        This URI is a case-sensitive identifier for the token issuer.
        More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string Issuer { get; set; }
        /// <summary>
        /// The OAuth 2.0 client ID that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 2.0 client ID that was created for the app used for authentication.
        This setting is required for enabling Microsoft Account authentication.
        Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm",
        SerializedName = @"microsoftAccountClientId",
        PossibleTypes = new [] { typeof(string) })]
        string MicrosoftAccountClientId { get; set; }
        /// <summary>
        /// The OAuth 2.0 client secret that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 2.0 client secret that was created for the app used for authentication.
        This setting is required for enabling Microsoft Account authentication.
        Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm",
        SerializedName = @"microsoftAccountClientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string MicrosoftAccountClientSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.
        /// This setting is optional. If not specified, "wl.basic" is used as the default scope.
        /// Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.
        This setting is optional. If not specified, ""wl.basic"" is used as the default scope.
        Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx",
        SerializedName = @"microsoftAccountOAuthScopes",
        PossibleTypes = new [] { typeof(string) })]
        string[] MicrosoftAccountOAuthScope { get; set; }
        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.
        /// The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The RuntimeVersion of the Authentication / Authorization feature in use for the current app.
        The setting in this value can control the behavior of certain features in the Authentication / Authorization module.",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuntimeVersion { get; set; }
        /// <summary>
        /// The number of hours after session token expiration that a session token can be used to
        /// call the token refresh API. The default is 72 hours.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of hours after session token expiration that a session token can be used to
        call the token refresh API. The default is 72 hours.",
        SerializedName = @"tokenRefreshExtensionHours",
        PossibleTypes = new [] { typeof(double) })]
        double? TokenRefreshExtensionHour { get; set; }
        /// <summary>
        /// <code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise,
        /// <code>false</code>.
        /// The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise, <code>false</code>.
         The default is <code>false</code>.",
        SerializedName = @"tokenStoreEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TokenStoreEnabled { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        This setting is required for enabling Twitter Sign-In.
        Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in",
        SerializedName = @"twitterConsumerKey",
        PossibleTypes = new [] { typeof(string) })]
        string TwitterConsumerKey { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer secret of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OAuth 1.0a consumer secret of the Twitter application used for sign-in.
        This setting is required for enabling Twitter Sign-In.
        Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in",
        SerializedName = @"twitterConsumerSecret",
        PossibleTypes = new [] { typeof(string) })]
        string TwitterConsumerSecret { get; set; }
        /// <summary>The action to take when an unauthenticated client attempts to access the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The action to take when an unauthenticated client attempts to access the app.",
        SerializedName = @"unauthenticatedClientAction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction? UnauthenticatedClientAction { get; set; }
        /// <summary>
        /// Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.",
        SerializedName = @"validateIssuer",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ValidateIssuer { get; set; }

    }
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    internal partial interface ISiteAuthSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint when
        /// a user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        string[] AdditionalLoginParam { get; set; }
        /// <summary>
        /// Allowed audience values to consider when validating JWTs issued by
        /// Azure Active Directory. Note that the <code>ClientID</code> value is always considered an
        /// allowed audience, regardless of this setting.
        /// </summary>
        string[] AllowedAudience { get; set; }
        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part
        /// of the URL is ignored.
        /// This is an advanced setting typically only needed by Windows Store application backends.
        /// Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        string[] AllowedExternalRedirectUrl { get; set; }
        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.
        /// This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        /// other 3rd party OpenID Connect providers.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).
        /// This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate
        /// end users.
        /// Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        string ClientSecret { get; set; }
        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property
        /// acts as
        /// a replacement for the Client Secret. It is also optional.
        /// </summary>
        string ClientSecretCertificateThumbprint { get; set; }
        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.
        /// This setting is only needed if multiple providers are configured and the unauthenticated client
        /// action is set to "RedirectToLoginPage".
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider? DefaultProvider { get; set; }
        /// <summary>
        /// <code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// The App ID of the Facebook app used for login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        string FacebookAppId { get; set; }
        /// <summary>
        /// The App Secret of the Facebook app used for Facebook Login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        string FacebookAppSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.
        /// This setting is optional.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        string[] FacebookOAuthScope { get; set; }
        /// <summary>
        /// The OpenID Connect Client ID for the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        string GoogleClientId { get; set; }
        /// <summary>
        /// The client secret associated with the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        string GoogleClientSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.
        /// This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        string[] GoogleOAuthScope { get; set; }
        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        /// When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.
        /// This URI is a case-sensitive identifier for the token issuer.
        /// More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        string Issuer { get; set; }
        /// <summary>
        /// The OAuth 2.0 client ID that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        string MicrosoftAccountClientId { get; set; }
        /// <summary>
        /// The OAuth 2.0 client secret that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        string MicrosoftAccountClientSecret { get; set; }
        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.
        /// This setting is optional. If not specified, "wl.basic" is used as the default scope.
        /// Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
        /// </summary>
        string[] MicrosoftAccountOAuthScope { get; set; }
        /// <summary>SiteAuthSettings resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties Property { get; set; }
        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.
        /// The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        string RuntimeVersion { get; set; }
        /// <summary>
        /// The number of hours after session token expiration that a session token can be used to
        /// call the token refresh API. The default is 72 hours.
        /// </summary>
        double? TokenRefreshExtensionHour { get; set; }
        /// <summary>
        /// <code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise,
        /// <code>false</code>.
        /// The default is <code>false</code>.
        /// </summary>
        bool? TokenStoreEnabled { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        string TwitterConsumerKey { get; set; }
        /// <summary>
        /// The OAuth 1.0a consumer secret of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        string TwitterConsumerSecret { get; set; }
        /// <summary>The action to take when an unauthenticated client attempts to access the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction? UnauthenticatedClientAction { get; set; }
        /// <summary>
        /// Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.
        /// </summary>
        bool? ValidateIssuer { get; set; }

    }
}