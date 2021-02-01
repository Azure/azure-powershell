
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Update an existing application.
.Description
Update an existing application.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

APPROLE <IAppRole[]>: The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.
  [AllowedMemberType <String[]>]: Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both. 
  [Description <String>]: Permission help text that appears in the admin app assignment and consent experiences.
  [DisplayName <String>]: Display name for the permission that appears in the admin consent and app assignment experiences.
  [Id <String>]: Unique role identifier inside the appRoles collection.
  [IsEnabled <Boolean?>]: When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must first be set to false. At that point, in a subsequent call, this role may be removed.
  [Value <String>]: Specifies the value of the roles claim that the application should expect in the authentication and access tokens.

INPUTOBJECT <IAdIdentity>: Identity Parameter
  [ApplicationId <String>]: The application ID.
  [ApplicationObjectId <String>]: The object ID of the application for which to get owners.
  [DomainName <String>]: name of the domain.
  [GroupObjectId <String>]: The object ID of the group from which to remove the member.
  [Id <String>]: Resource identity path
  [MemberObjectId <String>]: Member object id
  [NextLink <String>]: Next link for the list operation.
  [ObjectId <String>]: The object ID of the group whose members should be retrieved.
  [OwnerObjectId <String>]: Owner object id
  [TenantId <String>]: The tenant ID.
  [UpnOrObjectId <String>]: The object ID or principal name of the user for which to get information.

KEYCREDENTIALS <IKeyCredential[]>: A collection of KeyCredential objects.
  [CustomKeyIdentifier <String>]: Custom Key Identifier
  [EndDate <DateTime?>]: End date.
  [KeyId <String>]: Key ID.
  [StartDate <DateTime?>]: Start date.
  [Type <String>]: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
  [Usage <String>]: Usage. Acceptable values are 'Verify' and 'Sign'.
  [Value <String>]: Key value.

OAUTH2PERMISSION <IOAuth2Permission[]>: The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.
  [AdminConsentDescription <String>]: Permission help text that appears in the admin consent and app assignment experiences.
  [AdminConsentDisplayName <String>]: Display name for the permission that appears in the admin consent and app assignment experiences.
  [Id <String>]: Unique scope permission identifier inside the oauth2Permissions collection.
  [IsEnabled <Boolean?>]: When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false. At that point, in a subsequent call, the permission may be removed. 
  [Type <String>]: Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
  [UserConsentDescription <String>]: Permission help text that appears in the end user consent experience.
  [UserConsentDisplayName <String>]: Display name for the permission that appears in the end user consent experience.
  [Value <String>]: The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.

OPTIONALCLAIMACCESSTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the access token.
  [AdditionalProperty <IOptionalClaimAdditionalProperties>]: 
  [Essential <Boolean?>]: Is this a required claim.
  [Name <String>]: Claim name.
  [Source <String>]: Claim source.

OPTIONALCLAIMIDTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the id token.
  [AdditionalProperty <IOptionalClaimAdditionalProperties>]: 
  [Essential <Boolean?>]: Is this a required claim.
  [Name <String>]: Claim name.
  [Source <String>]: Claim source.

OPTIONALCLAIMSAMLTOKEN <IOptionalClaim[]>: Optional claims requested to be included in the saml token.
  [AdditionalProperty <IOptionalClaimAdditionalProperties>]: 
  [Essential <Boolean?>]: Is this a required claim.
  [Name <String>]: Claim name.
  [Source <String>]: Claim source.

PARAMETER <IApplicationUpdateParameters>: Request parameters for updating a new application.
  [AllowGuestsSignIn <Boolean?>]: A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
  [AllowPassthroughUser <Boolean?>]: Indicates that the application supports pass through users who have no presence in the resource tenant.
  [AppLogoUrl <String>]: The url for the application logo image stored in a CDN.
  [AppPermission <String[]>]: The application permissions.
  [AppRole <IAppRole[]>]: The collection of application roles that an application may declare. These roles can be assigned to users, groups or service principals.
    [AllowedMemberType <String[]>]: Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both. 
    [Description <String>]: Permission help text that appears in the admin app assignment and consent experiences.
    [DisplayName <String>]: Display name for the permission that appears in the admin consent and app assignment experiences.
    [Id <String>]: Unique role identifier inside the appRoles collection.
    [IsEnabled <Boolean?>]: When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must first be set to false. At that point, in a subsequent call, this role may be removed.
    [Value <String>]: Specifies the value of the roles claim that the application should expect in the authentication and access tokens.
  [AvailableToOtherTenant <Boolean?>]: Whether the application is available to other tenants.
  [ErrorUrl <String>]: A URL provided by the author of the application to report errors when using the application.
  [GroupMembershipClaim <GroupMembershipClaimTypes?>]: Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
  [Homepage <String>]: The home page of the application.
  [InformationalUrlMarketing <String>]: The marketing URI
  [InformationalUrlPrivacy <String>]: The privacy policy URI
  [InformationalUrlSupport <String>]: The support URI
  [InformationalUrlTermsOfService <String>]: The terms of service URI
  [IsDeviceOnlyAuthSupported <Boolean?>]: Specifies whether this application supports device authentication without a user. The default is false.
  [KeyCredentials <IKeyCredential[]>]: A collection of KeyCredential objects.
    [CustomKeyIdentifier <String>]: Custom Key Identifier
    [EndDate <DateTime?>]: End date.
    [KeyId <String>]: Key ID.
    [StartDate <DateTime?>]: Start date.
    [Type <String>]: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
    [Usage <String>]: Usage. Acceptable values are 'Verify' and 'Sign'.
    [Value <String>]: Key value.
  [KnownClientApplication <String[]>]: Client applications that are tied to this resource application. Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).
  [LogoutUrl <String>]: the url of the logout page
  [Oauth2AllowImplicitFlow <Boolean?>]: Whether to allow implicit grant flow for OAuth2
  [Oauth2AllowUrlPathMatching <Boolean?>]: Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs. The default is false.
  [Oauth2Permission <IOAuth2Permission[]>]: The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications. These permission scopes may be granted to client applications during consent.
    [AdminConsentDescription <String>]: Permission help text that appears in the admin consent and app assignment experiences.
    [AdminConsentDisplayName <String>]: Display name for the permission that appears in the admin consent and app assignment experiences.
    [Id <String>]: Unique scope permission identifier inside the oauth2Permissions collection.
    [IsEnabled <Boolean?>]: When creating or updating a permission, this property must be set to true (which is the default). To delete a permission, this property must first be set to false. At that point, in a subsequent call, the permission may be removed. 
    [Type <String>]: Specifies whether this scope permission can be consented to by an end user, or whether it is a tenant-wide permission that must be consented to by a Company Administrator. Possible values are "User" or "Admin".
    [UserConsentDescription <String>]: Permission help text that appears in the end user consent experience.
    [UserConsentDisplayName <String>]: Display name for the permission that appears in the end user consent experience.
    [Value <String>]: The value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
  [Oauth2RequirePostResponse <Boolean?>]: Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests. The default is false, which specifies that only GET requests will be allowed.
  [OptionalClaimAccessToken <IOptionalClaim[]>]: Optional claims requested to be included in the access token.
    [AdditionalProperty <IOptionalClaimAdditionalProperties>]: 
    [Essential <Boolean?>]: Is this a required claim.
    [Name <String>]: Claim name.
    [Source <String>]: Claim source.
  [OptionalClaimIdToken <IOptionalClaim[]>]: Optional claims requested to be included in the id token.
  [OptionalClaimSamlToken <IOptionalClaim[]>]: Optional claims requested to be included in the saml token.
  [OrgRestriction <String[]>]: A list of tenants allowed to access application.
  [PasswordCredentials <IPasswordCredential[]>]: A collection of PasswordCredential objects
    [CustomKeyIdentifier <Byte[]>]: Custom Key Identifier
    [EndDate <DateTime?>]: End date.
    [KeyId <String>]: Key ID.
    [StartDate <DateTime?>]: Start date.
    [Value <String>]: Key value.
  [PreAuthorizedApplication <IPreAuthorizedApplication[]>]: list of pre-authorized applications.
    [AppId <String>]: Represents the application id.
    [Extension <IPreAuthorizedApplicationExtension[]>]: Collection of extensions from the resource application.
      [Condition <String[]>]: The extension's conditions.
    [Permission <IPreAuthorizedApplicationPermission[]>]: Collection of required app permissions/entitlements from the resource application.
      [AccessGrant <String[]>]: The list of permissions.
      [DirectAccessGrant <Boolean?>]: Indicates whether the permission set is DirectAccess or impersonation.
  [PublicClient <Boolean?>]: Specifies whether this application is a public client (such as an installed application running on a mobile device). Default is false.
  [PublisherDomain <String>]: Reliable domain which can be used to identify an application.
  [ReplyUrl <String[]>]: A collection of reply URLs for the application.
  [RequiredResourceAccess <IRequiredResourceAccess[]>]: Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
    ResourceAccess <IResourceAccess[]>: The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
      Id <String>: The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
      [Type <String>]: Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
    [ResourceAppId <String>]: The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.
  [SamlMetadataUrl <String>]: The URL to the SAML metadata for the application.
  [SignInAudience <String>]: Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
  [WwwHomepage <String>]: The primary Web page.
  [DisplayName <String>]: The display name of the application.
  [IdentifierUri <String[]>]: A collection of URIs for the application.

PASSWORDCREDENTIALS <IPasswordCredential[]>: A collection of PasswordCredential objects
  [CustomKeyIdentifier <Byte[]>]: Custom Key Identifier
  [EndDate <DateTime?>]: End date.
  [KeyId <String>]: Key ID.
  [StartDate <DateTime?>]: Start date.
  [Value <String>]: Key value.

PREAUTHORIZEDAPPLICATION <IPreAuthorizedApplication[]>: list of pre-authorized applications.
  [AppId <String>]: Represents the application id.
  [Extension <IPreAuthorizedApplicationExtension[]>]: Collection of extensions from the resource application.
    [Condition <String[]>]: The extension's conditions.
  [Permission <IPreAuthorizedApplicationPermission[]>]: Collection of required app permissions/entitlements from the resource application.
    [AccessGrant <String[]>]: The list of permissions.
    [DirectAccessGrant <Boolean?>]: Indicates whether the permission set is DirectAccess or impersonation.

REQUIREDRESOURCEACCESS <IRequiredResourceAccess[]>: Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources. This pre-configuration of required resource access drives the consent experience.
  ResourceAccess <IResourceAccess[]>: The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
    Id <String>: The unique identifier for one of the OAuth2Permission or AppRole instances that the resource application exposes.
    [Type <String>]: Specifies whether the id property references an OAuth2Permission or an AppRole. Possible values are "scope" or "role".
  [ResourceAppId <String>]: The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ad/update-azadapplication
#>
function Update-AzADApplication {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='PatchExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Patch', Mandatory)]
    [Parameter(ParameterSetName='PatchExpanded', Mandatory)]
    [Alias('ApplicationObjectId')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # Application object ID.
    ${ObjectId},

    [Parameter(ParameterSetName='Patch', Mandatory)]
    [Parameter(ParameterSetName='PatchExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The tenant ID.
    ${TenantId},

    [Parameter(ParameterSetName='PatchViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Patch', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='PatchViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplicationUpdateParameters]
    # Request parameters for updating a new application.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A property on the application to indicate if the application accepts other IDPs or not or partially accepts.
    ${AllowGuestsSignIn},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Indicates that the application supports pass through users who have no presence in the resource tenant.
    ${AllowPassthroughUser},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The url for the application logo image stored in a CDN.
    ${AppLogoUrl},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # The application permissions.
    ${AppPermission},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]]
    # The collection of application roles that an application may declare.
    # These roles can be assigned to users, groups or service principals.
    # To construct, see NOTES section for APPROLE properties and create a hash table.
    ${AppRole},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether the application is available to other tenants.
    ${AvailableToOtherTenant},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The display name of the application.
    ${DisplayName},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # A URL provided by the author of the application to report errors when using the application.
    ${ErrorUrl},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Support.GroupMembershipClaimTypes]
    # Configures the groups claim issued in a user or OAuth 2.0 access token that the app expects.
    ${GroupMembershipClaim},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The home page of the application.
    ${Homepage},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # A collection of URIs for the application.
    ${IdentifierUri},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The marketing URI
    ${InformationalUrlMarketing},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The privacy policy URI
    ${InformationalUrlPrivacy},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The support URI
    ${InformationalUrlSupport},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The terms of service URI
    ${InformationalUrlTermsOfService},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether this application supports device authentication without a user.
    # The default is false.
    ${IsDeviceOnlyAuthSupported},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]]
    # A collection of KeyCredential objects.
    # To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.
    ${KeyCredentials},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # Client applications that are tied to this resource application.
    # Consent to any of the known client applications will result in implicit consent to the resource application through a combined consent dialog (showing the OAuth permission scopes required by the client and the resource).
    ${KnownClientApplication},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # the url of the logout page
    ${LogoutUrl},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether to allow implicit grant flow for OAuth2
    ${Oauth2AllowImplicitFlow},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether during a token Request Azure AD will allow path matching of the redirect URI against the applications collection of replyURLs.
    # The default is false.
    ${Oauth2AllowUrlPathMatching},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]]
    # The collection of OAuth 2.0 permission scopes that the web API (resource) application exposes to client applications.
    # These permission scopes may be granted to client applications during consent.
    # To construct, see NOTES section for OAUTH2PERMISSION properties and create a hash table.
    ${Oauth2Permission},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether, as part of OAuth 2.0 token requests, Azure AD will allow POST requests, as opposed to GET requests.
    # The default is false, which specifies that only GET requests will be allowed.
    ${Oauth2RequirePostResponse},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]]
    # Optional claims requested to be included in the access token.
    # To construct, see NOTES section for OPTIONALCLAIMACCESSTOKEN properties and create a hash table.
    ${OptionalClaimAccessToken},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]]
    # Optional claims requested to be included in the id token.
    # To construct, see NOTES section for OPTIONALCLAIMIDTOKEN properties and create a hash table.
    ${OptionalClaimIdToken},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[]]
    # Optional claims requested to be included in the saml token.
    # To construct, see NOTES section for OPTIONALCLAIMSAMLTOKEN properties and create a hash table.
    ${OptionalClaimSamlToken},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # A list of tenants allowed to access application.
    ${OrgRestriction},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]]
    # A collection of PasswordCredential objects
    # To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.
    ${PasswordCredentials},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]]
    # list of pre-authorized applications.
    # To construct, see NOTES section for PREAUTHORIZEDAPPLICATION properties and create a hash table.
    ${PreAuthorizedApplication},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether this application is a public client (such as an installed application running on a mobile device).
    # Default is false.
    ${PublicClient},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Reliable domain which can be used to identify an application.
    ${PublisherDomain},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # A collection of reply URLs for the application.
    ${ReplyUrl},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]]
    # Specifies resources that this application requires access to and the set of OAuth permission scopes and application roles that it needs under each of those resources.
    # This pre-configuration of required resource access drives the consent experience.
    # To construct, see NOTES section for REQUIREDRESOURCEACCESS properties and create a hash table.
    ${RequiredResourceAccess},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The URL to the SAML metadata for the application.
    ${SamlMetadataUrl},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Audience for signing in to the application (AzureADMyOrganization, AzureADAllOrganizations, AzureADAndMicrosoftAccounts).
    ${SignInAudience},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The primary Web page.
    ${WwwHomepage},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Patch = 'Az.AD.private\Update-AzADApplication_Patch';
            PatchExpanded = 'Az.AD.private\Update-AzADApplication_PatchExpanded';
            PatchViaIdentity = 'Az.AD.private\Update-AzADApplication_PatchViaIdentity';
            PatchViaIdentityExpanded = 'Az.AD.private\Update-AzADApplication_PatchViaIdentityExpanded';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
