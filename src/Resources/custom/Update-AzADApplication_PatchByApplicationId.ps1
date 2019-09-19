function Update-AzADApplication_PatchByApplicationId {
    [OutputType('System.Boolean')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(SupportsShouldProcess, PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='Application ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ApplicationId},

        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${TenantId},

        [Parameter(HelpMessage='When specified, PassThru will force the cmdlet return a ''bool'' given that there isn''t a return type by default.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

        [Parameter(HelpMessage='A property on the application to indicate if the application accepts other IDPs or not or partially accepts.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${AllowGuestsSignIn},

        [Parameter(HelpMessage='Indicates that the application supports pass through users who have no presence in the resource tenant.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${AllowPassthroughUser},

        [Parameter(HelpMessage='The url for the application logo image stored in a CDN.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${AppLogoUrl},

        [Parameter(HelpMessage='The application permissions.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${AppPermission},

        [Parameter(HelpMessage='The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAppRole[]]
        ${AppRole},

        [Parameter(HelpMessage='Whether the application is available to other tenants.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${AvailableToOtherTenant},

        [Parameter(HelpMessage='The display name of the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(HelpMessage='A URL provided by the author of the application to report errors when using the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${ErrorUrl},

        [Parameter(HelpMessage='Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.GroupMembershipClaimTypes])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.GroupMembershipClaimTypes]
        ${GroupMembershipClaim},

        [Parameter(HelpMessage='The home page of the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${Homepage},

        [Parameter(HelpMessage='A collection of URIs for the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${IdentifierUri},

        [Parameter(HelpMessage='The marketing URI')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${InformationalUrlMarketing},

        [Parameter(HelpMessage='The privacy policy URI')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${InformationalUrlPrivacy},

        [Parameter(HelpMessage='The support URI')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${InformationalUrlSupport},

        [Parameter(HelpMessage='The terms of service URI')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${InformationalUrlTermsOfService},

        [Parameter(HelpMessage='Specifies whether this application supports device authentication without a user. The default is false.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${IsDeviceOnlyAuthSupported},

        [Parameter(HelpMessage='A collection of KeyCredential objects.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IKeyCredential[]]
        ${KeyCredentials},

        [Parameter(HelpMessage='Client applications that are tied to this resource application. Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${KnownClientApplication},

        [Parameter(HelpMessage='the url of the logout page')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${LogoutUrl},

        [Parameter(HelpMessage='Whether to allow implicit grant flow for OAuth2')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${Oauth2AllowImplicitFlow},

        [Parameter(HelpMessage='Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs. The default is false.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${Oauth2AllowUrlPathMatching},

        [Parameter(HelpMessage='The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOAuth2Permission[]]
        ${Oauth2Permission},

        [Parameter(HelpMessage='Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests. The default is false, which specifies that only GET requests will be allowed.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${Oauth2RequirePostResponse},

        [Parameter(HelpMessage='Optional claims requested to be included in the access token.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]]
        ${OptionalClaimAccessToken},

        [Parameter(HelpMessage='Optional claims requested to be included in the id token.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]]
        ${OptionalClaimIdToken},

        [Parameter(HelpMessage='Optional claims requested to be included in the saml token.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IOptionalClaim[]]
        ${OptionalClaimSamlToken},

        [Parameter(HelpMessage='A list of tenants allowed to access application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${OrgRestriction},

        [Parameter(HelpMessage='A collection of PasswordCredential objects')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPasswordCredential[]]
        ${PasswordCredentials},

        [Parameter(HelpMessage='list of pre-authorized applications.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPreAuthorizedApplication[]]
        ${PreAuthorizedApplication},

        [Parameter(HelpMessage='Specifies whether this application is a public client (such as an installed application running on a mobile device). Default is false.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${PublicClient},

        [Parameter(HelpMessage='Reliable domain which can be used to identify an application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${PublisherDomain},

        [Parameter(HelpMessage='A collection of reply URLs for the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String[]]
        ${ReplyUrl},

        [Parameter(HelpMessage='Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IRequiredResourceAccess[]]
        ${RequiredResourceAccess},

        [Parameter(HelpMessage='The URL to the SAML metadata for the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${SamlMetadataUrl},

        [Parameter(HelpMessage='Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${SignInAudience},

        [Parameter(HelpMessage='The primary Web page.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${WwwHomepage},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $Application = Az.Resources\Get-AzADApplication -TenantId $TenantId -ApplicationId $ApplicationId
        if ($null -ne $Application)
        {
            $null = $PSBoundParameters.Add("ObjectId", $Application.ObjectId)
            $null = $PSBoundParameters.Remove("ApplicationId")
            Az.Resources\Update-AzADApplication @PSBoundParameters
        }
    }
}