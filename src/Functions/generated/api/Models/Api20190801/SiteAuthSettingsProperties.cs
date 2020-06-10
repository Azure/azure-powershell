namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteAuthSettings resource specific properties</summary>
    public partial class SiteAuthSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdditionalLoginParam" /> property.</summary>
        private string[] _additionalLoginParam;

        /// <summary>
        /// Login parameters to send to the OpenID Connect authorization endpoint when
        /// a user logs in. Each parameter must be in the form "key=value".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AdditionalLoginParam { get => this._additionalLoginParam; set => this._additionalLoginParam = value; }

        /// <summary>Backing field for <see cref="AllowedAudience" /> property.</summary>
        private string[] _allowedAudience;

        /// <summary>
        /// Allowed audience values to consider when validating JWTs issued by
        /// Azure Active Directory. Note that the <code>ClientID</code> value is always considered an
        /// allowed audience, regardless of this setting.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedAudience { get => this._allowedAudience; set => this._allowedAudience = value; }

        /// <summary>Backing field for <see cref="AllowedExternalRedirectUrl" /> property.</summary>
        private string[] _allowedExternalRedirectUrl;

        /// <summary>
        /// External URLs that can be redirected to as part of logging in or logging out of the app. Note that the query string part
        /// of the URL is ignored.
        /// This is an advanced setting typically only needed by Windows Store application backends.
        /// Note that URLs within the current domain are always implicitly allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedExternalRedirectUrl { get => this._allowedExternalRedirectUrl; set => this._allowedExternalRedirectUrl = value; }

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>
        /// The Client ID of this relying party application, known as the client_id.
        /// This setting is required for enabling OpenID Connection authentication with Azure Active Directory or
        /// other 3rd party OpenID Connect providers.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="ClientSecret" /> property.</summary>
        private string _clientSecret;

        /// <summary>
        /// The Client Secret of this relying party application (in Azure Active Directory, this is also referred to as the Key).
        /// This setting is optional. If no client secret is configured, the OpenID Connect implicit auth flow is used to authenticate
        /// end users.
        /// Otherwise, the OpenID Connect Authorization Code Flow is used to authenticate end users.
        /// More information on OpenID Connect: http://openid.net/specs/openid-connect-core-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ClientSecret { get => this._clientSecret; set => this._clientSecret = value; }

        /// <summary>Backing field for <see cref="ClientSecretCertificateThumbprint" /> property.</summary>
        private string _clientSecretCertificateThumbprint;

        /// <summary>
        /// An alternative to the client secret, that is the thumbprint of a certificate used for signing purposes. This property
        /// acts as
        /// a replacement for the Client Secret. It is also optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ClientSecretCertificateThumbprint { get => this._clientSecretCertificateThumbprint; set => this._clientSecretCertificateThumbprint = value; }

        /// <summary>Backing field for <see cref="DefaultProvider" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider? _defaultProvider;

        /// <summary>
        /// The default authentication provider to use when multiple providers are configured.
        /// This setting is only needed if multiple providers are configured and the unauthenticated client
        /// action is set to "RedirectToLoginPage".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider? DefaultProvider { get => this._defaultProvider; set => this._defaultProvider = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// <code>true</code> if the Authentication / Authorization feature is enabled for the current app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="FacebookAppId" /> property.</summary>
        private string _facebookAppId;

        /// <summary>
        /// The App ID of the Facebook app used for login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FacebookAppId { get => this._facebookAppId; set => this._facebookAppId = value; }

        /// <summary>Backing field for <see cref="FacebookAppSecret" /> property.</summary>
        private string _facebookAppSecret;

        /// <summary>
        /// The App Secret of the Facebook app used for Facebook Login.
        /// This setting is required for enabling Facebook Login.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FacebookAppSecret { get => this._facebookAppSecret; set => this._facebookAppSecret = value; }

        /// <summary>Backing field for <see cref="FacebookOAuthScope" /> property.</summary>
        private string[] _facebookOAuthScope;

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Facebook Login authentication.
        /// This setting is optional.
        /// Facebook Login documentation: https://developers.facebook.com/docs/facebook-login
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] FacebookOAuthScope { get => this._facebookOAuthScope; set => this._facebookOAuthScope = value; }

        /// <summary>Backing field for <see cref="GoogleClientId" /> property.</summary>
        private string _googleClientId;

        /// <summary>
        /// The OpenID Connect Client ID for the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string GoogleClientId { get => this._googleClientId; set => this._googleClientId = value; }

        /// <summary>Backing field for <see cref="GoogleClientSecret" /> property.</summary>
        private string _googleClientSecret;

        /// <summary>
        /// The client secret associated with the Google web application.
        /// This setting is required for enabling Google Sign-In.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string GoogleClientSecret { get => this._googleClientSecret; set => this._googleClientSecret = value; }

        /// <summary>Backing field for <see cref="GoogleOAuthScope" /> property.</summary>
        private string[] _googleOAuthScope;

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Google Sign-In authentication.
        /// This setting is optional. If not specified, "openid", "profile", and "email" are used as default scopes.
        /// Google Sign-In documentation: https://developers.google.com/identity/sign-in/web/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] GoogleOAuthScope { get => this._googleOAuthScope; set => this._googleOAuthScope = value; }

        /// <summary>Backing field for <see cref="Issuer" /> property.</summary>
        private string _issuer;

        /// <summary>
        /// The OpenID Connect Issuer URI that represents the entity which issues access tokens for this application.
        /// When using Azure Active Directory, this value is the URI of the directory tenant, e.g. https://sts.windows.net/{tenant-guid}/.
        /// This URI is a case-sensitive identifier for the token issuer.
        /// More information on OpenID Connect Discovery: http://openid.net/specs/openid-connect-discovery-1_0.html
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Issuer { get => this._issuer; set => this._issuer = value; }

        /// <summary>Backing field for <see cref="MicrosoftAccountClientId" /> property.</summary>
        private string _microsoftAccountClientId;

        /// <summary>
        /// The OAuth 2.0 client ID that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MicrosoftAccountClientId { get => this._microsoftAccountClientId; set => this._microsoftAccountClientId = value; }

        /// <summary>Backing field for <see cref="MicrosoftAccountClientSecret" /> property.</summary>
        private string _microsoftAccountClientSecret;

        /// <summary>
        /// The OAuth 2.0 client secret that was created for the app used for authentication.
        /// This setting is required for enabling Microsoft Account authentication.
        /// Microsoft Account OAuth documentation: https://dev.onedrive.com/auth/msa_oauth.htm
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MicrosoftAccountClientSecret { get => this._microsoftAccountClientSecret; set => this._microsoftAccountClientSecret = value; }

        /// <summary>Backing field for <see cref="MicrosoftAccountOAuthScope" /> property.</summary>
        private string[] _microsoftAccountOAuthScope;

        /// <summary>
        /// The OAuth 2.0 scopes that will be requested as part of Microsoft Account authentication.
        /// This setting is optional. If not specified, "wl.basic" is used as the default scope.
        /// Microsoft Account Scopes and permissions documentation: https://msdn.microsoft.com/en-us/library/dn631845.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] MicrosoftAccountOAuthScope { get => this._microsoftAccountOAuthScope; set => this._microsoftAccountOAuthScope = value; }

        /// <summary>Backing field for <see cref="RuntimeVersion" /> property.</summary>
        private string _runtimeVersion;

        /// <summary>
        /// The RuntimeVersion of the Authentication / Authorization feature in use for the current app.
        /// The setting in this value can control the behavior of certain features in the Authentication / Authorization module.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RuntimeVersion { get => this._runtimeVersion; set => this._runtimeVersion = value; }

        /// <summary>Backing field for <see cref="TokenRefreshExtensionHour" /> property.</summary>
        private double? _tokenRefreshExtensionHour;

        /// <summary>
        /// The number of hours after session token expiration that a session token can be used to
        /// call the token refresh API. The default is 72 hours.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? TokenRefreshExtensionHour { get => this._tokenRefreshExtensionHour; set => this._tokenRefreshExtensionHour = value; }

        /// <summary>Backing field for <see cref="TokenStoreEnabled" /> property.</summary>
        private bool? _tokenStoreEnabled;

        /// <summary>
        /// <code>true</code> to durably store platform-specific security tokens that are obtained during login flows; otherwise,
        /// <code>false</code>.
        /// The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? TokenStoreEnabled { get => this._tokenStoreEnabled; set => this._tokenStoreEnabled = value; }

        /// <summary>Backing field for <see cref="TwitterConsumerKey" /> property.</summary>
        private string _twitterConsumerKey;

        /// <summary>
        /// The OAuth 1.0a consumer key of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TwitterConsumerKey { get => this._twitterConsumerKey; set => this._twitterConsumerKey = value; }

        /// <summary>Backing field for <see cref="TwitterConsumerSecret" /> property.</summary>
        private string _twitterConsumerSecret;

        /// <summary>
        /// The OAuth 1.0a consumer secret of the Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TwitterConsumerSecret { get => this._twitterConsumerSecret; set => this._twitterConsumerSecret = value; }

        /// <summary>Backing field for <see cref="UnauthenticatedClientAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction? _unauthenticatedClientAction;

        /// <summary>The action to take when an unauthenticated client attempts to access the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction? UnauthenticatedClientAction { get => this._unauthenticatedClientAction; set => this._unauthenticatedClientAction = value; }

        /// <summary>Backing field for <see cref="ValidateIssuer" /> property.</summary>
        private bool? _validateIssuer;

        /// <summary>
        /// Gets a value indicating whether the issuer should be a valid HTTPS url and be validated as such.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ValidateIssuer { get => this._validateIssuer; set => this._validateIssuer = value; }

        /// <summary>Creates an new <see cref="SiteAuthSettingsProperties" /> instance.</summary>
        public SiteAuthSettingsProperties()
        {

        }
    }
    /// SiteAuthSettings resource specific properties
    public partial interface ISiteAuthSettingsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// SiteAuthSettings resource specific properties
    internal partial interface ISiteAuthSettingsPropertiesInternal

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