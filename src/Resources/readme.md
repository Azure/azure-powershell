<!-- region Generated -->
# Az.Resources
This directory contains the PowerShell module for the Resources service.

---
## Status
[![Az.Resources](https://img.shields.io/powershellgallery/v/Az.Resources.svg?style=flat-square&label=Az.Resources "Az.Resources")](https://www.powershellgallery.com/packages/Az.Resources/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Resources`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/resources/resource-manager/readme.md
  - $(repo)/specification/graphrbac/data-plane/readme.md
  - $(repo)/specification/managementgroups/resource-manager/readme.md
  - $(repo)/specification/authorization/resource-manager/readme.md

subject-prefix: ''
module-version: 4.0.2
title: Resources

directive:
  - from: swagger-document
    where: $..parameters[?(@.name=='$filter')]
    transform: $['x-ms-skip-url-encoding'] = true
  - from: swagger-document
    where: $..[?( /Resources_(CreateOrUpdate|Update|Delete|Get|GetById|CheckExistence|CheckExistenceById)/g.exec(@.operationId))]
    transform: "$.parameters = $.parameters.map( each => { each.name = each.name === 'api-version' ? 'explicit-api-version' : each.name; return each; } );"
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/explicit-api-version/g, 'api-version');
  - where:
      parameter-name: ExplicitApiVersion
    set:
      parameter-name: ApiVersion
  - from: source-file-csharp
    where: $
    transform: >
      $ = $.replace(/result.OdataNextLink/g,'nextLink' );
      return $.replace( /(^\s*)(if\s*\(\s*nextLink\s*!=\s*null\s*\))/gm, '$1var nextLink = Module.Instance.FixNextLink(responseMessage, result.OdataNextLink);\n$1$2' );
  - from: swagger-document
    where:
      - $..DeploymentProperties.properties.template
      - $..DeploymentProperties.properties.parameters
      - $..ResourceGroupExportResult.properties.template
      - $..PolicyDefinitionProperties.properties.policyRule
    transform: $.additionalProperties = true;
  - where:
      subject: OAuth2PermissionGrant
    remove: true
  - where:
      subject: ClassicAdministrator
    remove: true
  - where:
      subject: Permission
    remove: true
  - where:
      subject: ElevateAccess
    remove: true
  - where:
      subject: TenantBackfill.*
    remove: true
  - where:
      subject: Entity
    remove: true
  - where:
      subject: ResourceLink
    remove: true
  - where:
      verb: Set
      subject: Resource
    remove: true
  - where:
      verb: Set
      subject: Deployment
    remove: true
  - where:
      verb: Test
      subject: ResourceExistence
    remove: true
  - where:
      verb: Test
      subject: DeploymentExistence
    remove: true
  - where:
      verb: Get
      subject: AuthorizationOperation
    remove: true
  - where:
      subject: ApplicationDefinition(.*)
    set:
      subject: ManagedApplicationDefinition$1
  - where:
      verb: Get
      subject: Application
      variant: ^Get$|^Get1$|^GetSubscriptionIdViaHost$|^GetViaIdentity$|^GetViaIdentity1$|^List$|^List1$|^ListSubscriptionIdViaHost$|^ListSubscriptionIdViaHost1$
    set:
      subject: ManagedApplication
  - where:
      verb: New
      subject: Application
      variant: ^Create$|^Create1$|^CreateViaIdentity$|^CreateViaIdentity1$|^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^CreateSubscriptionIdViaHost$|^CreateSubscriptionIdViaHostExpanded$
    set:
      subject: ManagedApplication
  - where:
      verb: Remove
      subject: Application
      variant: ^Delete$|^Delete1$|^DeleteViaIdentity$|^DeleteViaIdentity1$|^DeleteSubscriptionIdViaHost$
    set:
      subject: ManagedApplication
  - where:
      verb: Set
      subject: Application
    set:
      subject: ManagedApplication
  - where:
      verb: Update
      subject: Application
      variant: ^Update
    set:
      subject: ManagedApplication
  - where:
      verb: Get
      subject: Application
      variant: ^Get2$|^GetViaIdentity2$|^List2$
    set:
      subject: ADApplication
  - where:
      verb: New
      subject: Application
      variant: ^Create2$|^CreateViaIdentity2$|^CreateExpanded2$|^CreateViaIdentityExpanded2$
    set:
      subject: ADApplication
  - where:
      verb: Remove
      subject: Application
      variant: ^Delete2$|^DeleteViaIdentity2$
    set:
      subject: ADApplication
  - where:
      verb: Update
      subject: Application
      variant: ^Patch
    set:
      subject: ADApplication
  - where:
      subject: ApplicationOwner
    set:
      subject: ADApplicationOwner
  - where:
      subject: (.*)KeyCredentials
    set:
      subject: AD$1KeyCredential
  - where:
      subject: (.*)PasswordCredentials
    set:
      subject: AD$1PasswordCredential
  - where:
      verb: Update
      subject: AD(.*)Credential
    hide: true
  - where:
      subject: ApplicationServicePrincipalId
    hide: true
  - where:
      subject: ^Feature(.*)
    set:
      subject: ProviderFeature$1
  - where:
      subject: ^DeletedApplication(.*)
    set:
      subject: ADDeletedApplication$1
  - where:
      subject: ^Group(.*)
    set:
      subject: ADGroup$1
  - where:
      subject: ^Object
    hide: true
  - where:
      verb: Get
      subject: RoleAssignment
    hide: true
  - where:
      verb: Get
      subject: RoleDefinition
    hide: true
  - where:
      subject: ^ServicePrincipal(.*)
    set:
      subject: ADServicePrincipal$1
  - where:
      subject: ^User(.*)
    set:
      subject: ADUser$1
  - where:
      subject: ^Domain(.*)
    set:
      subject: ADDomain$1
  - where:
      subject: ManagementLock
    set:
      subject: ResourceLock
  - where:
      parameter-name: ApplicationObjectId
    set:
      parameter-name: ObjectId
  - where:
      subject: Resource
      parameter-name: GroupName
    set:
      parameter-name: ResourceGroupName
    clear-alias: true
  - where:
      subject: Resource
      parameter-name: Id
    set:
      parameter-name: ResourceId
    clear-alias: true
  - where:
      subject: Resource
      parameter-name: Type
    set:
      parameter-name: ResourceType
    clear-alias: true
  - where:
      subject: Appliance*
    remove: true
  - where:
      verb: Get
      subject: Subscription
    remove: true
  - where:
      verb: Test
      subject: CheckNameAvailability
    set:
      subject: NameAvailability
  - where:
      verb: Export
      subject: ResourceGroupTemplate
    set:
      subject: ResourceGroup
      alias: Export-AzResourceGroupTemplate
  - where:
      parameter-name: Filter
    set:
      alias: ODataQuery
  - where:
      verb: Test
      subject: ResourceGroupExistence
    set:
      subject: ResourceGroup
      alias: Test-AzResourceGroupExistence
  - where:
      verb: Export
      subject: DeploymentTemplate
    set:
      alias: [Save-AzDeploymentTemplate, Save-AzResourceGroupDeploymentTemplate]
  - where:
      subject: Deployment
    set:
      alias: ${verb}-AzResourceGroupDeployment
  - where:
      verb: Get
      subject: DeploymentOperation
    set:
      alias: Get-AzResourceGroupDeploymentOperation
  - where:
      verb: New
      subject: Deployment
      variant: Create.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: DeploymentPropertyParameter
  - where:
      verb: Test
      subject: Deployment
      variant: Validate.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: DeploymentPropertyParameter
  - where:
      verb: New
      subject: Deployment
      parameter-name: DebugSettingDetailLevel
    set:
      parameter-name: DeploymentDebugLogLevel
  - where:
      verb: New
      subject: Deployment
    hide: true
  - where:
      verb: Test
      subject: Deployment
    hide: true
  - where:
      subject: ProviderOperationMetadata
    set:
      subject: ProviderOperation
  - where:
      subject: Provider
    set:
      subject: ResourceProvider
  - where:
      verb: Get
      subject: ResourceProvider
    hide: true
  - where:
      subject: ProviderFeature|ResourceProvider|ResourceLock
      parameter-name: ResourceProviderNamespace
    set:
      alias: ProviderNamespace
  - where:
      verb: Get
      subject: ProviderFeature
    hide: true
  - where:
      subject: TagValue
    hide: true
  - where:
      verb: Set
      subject: Tag
    hide: true
  - where:
      verb: Get
      subject: ADGroupMember
      parameter-name: ObjectId
    set:
      alias: GroupObjectId
  - where:
      subject: SignedInUser.*
    remove: true
  - where:
      subject: ManagementGroup.*
      parameter-name: GroupId
    set:
      alias: GroupName
  - where:
      verb: Get
      subject: RoleAssignment
      parameter-name: ParentResourcePath
    set:
      parameter-name: ParentResourceId
      alias: ParentResourcePath
  - where:
      verb: New
      subject: RoleAssignment
      parameter-name: CanDelegate
    set:
      alias: AllowDelegation
  - where:
      subject: RoleDefinition
      parameter-name: RoleDefinition
    set:
      alias: Role
  - where:
      verb: New
      subject: PolicyAssignment
      parameter-name: Name
    clear-alias: true
  - where:
      verb: Update
      subject: ResourceGroup
      parameter-name: Name
    clear-alias: true
  - where:
      verb: Get
      subject: Tenant
    hide: true
  - where:
      subject: ResourceMoveResource
    set:
      subject: ResourceMove
  - where:
      subject: PolicyDefinition
      parameter-name: ManagementGroupId
    set:
      parameter-name: ManagementGroupName
  - where:
      subject: PolicySetDefinition
      parameter-name: ManagementGroupId
    set:
      parameter-name: ManagementGroupName
  - where:
      subject: PolicyDefinitionBuilt
    hide: true
  - where:
      subject: PolicySetDefinitionBuilt
    hide: true
  - where:
      parameter-name: UpnOrObjectId
    set:
      alias: ['UserPrincipalName', 'Upn', 'ObjectId']
  - where:
      verb: Update
      subject: ADUser
      parameter-name: UpnOrObjectId
    clear-alias: true
    set:
      alias: ['Upn', 'ObjectId']
  - where:
      verb: Update
      subject: ADUser
      parameter-name: AccountEnabled
    set:
      parameter-name: EnableAccount
  - where:
      verb: Get
      subject: ADGroupOwner
    hide: true
  - where:
      verb: Get|Remove
      subject: ADDeletedApplication.*
    hide: true
  - where:
      verb: New
      subject: RoleDefinition
      variant: ^Create1$|^CreateExpanded1$
    hide: true
  - where:
      subject: ManagedApplication
      parameter-name: ApplicationDefinitionId
    set:
      alias: ManagedApplicationDefinitionId
  - where:
      verb: New
      subject: ManagedApplication
      variant: Create.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: ApplicationPropertiesParameter
  - where:
      verb: Set
      subject: ManagedApplication
      variant: Update.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: ApplicationPropertiesParameter
  - where:
      verb: New
      subject: PolicyDefinition
      variant: Create.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: DefinitionPropertiesParameter
  - where:
      verb: Set
      subject: PolicyDefinition
      variant: Update.*Expanded.*
      parameter-name: Parameter
    set:
      parameter-name: DefinitionPropertiesParameter
  - where:
      verb: New
      subject: PolicyDefinition
    hide: true
  - where:
      subject: ADApplication
      parameter-name: AvailableToOtherTenant
    set:
      parameter-name: AvailableToOtherTenants
  - where:
      subject: Deployment
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: DeploymentParameter
  - where:
      subject: ManagedApplication
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: ApplicationParameter
  - where:
      subject: PolicyAssignment
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: AssignmentParameter
  - where:
      subject: PolicyDefinition
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: DefinitionParameter
  - where:
      subject: PolicySetDefinition
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: SetDefinitionParameter
  - where:
      subject: RoleAssignment
      variant: ^Create1$|^CreateExpanded1$|^CreateViaIdentity1$|^CreateViaIdentityExpanded1$
    remove: true
  - where:
      verb: Add
      subject: ADGroupMember
      parameter-name: Group(.*)
    set:
      alias: TargetGroup$1
  - where:
      subject: ADUser
      parameter-name: PasswordProfileForceChangePasswordNextLogin
    set:
      alias: PasswordChangePasswordNextLogin
  - where:
      verb: Get
      subject: SubscriptionLocation
    set:
      subject: Location
  # Format output
  - where:
      model-name: GenericResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Type
          - Location
        labels:
          Type: ResourceType
  - where:
      model-name: ResourceGroup
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
  - where:
      model-name: DeploymentExtended
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - Timestamp
          - Mode
  - where:
      model-name: PolicyAssignment
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Id
  - where:
      model-name: PolicyDefinition
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Id
  - where:
      model-name: PolicySetDefinition
    set:
      format-table:
        properties:
          - Name
          - DisplayName
          - Id
  - where:
      model-name: Provider
    set:
      format-table:
        properties:
          - Namespace
          - RegistrationState
  - where:
      model-name: ProviderResourceType
    set:
      format-table:
        properties:
          - ResourceType
          - Location
          - ApiVersion
  - where:
      model-name: FeatureResult
    set:
      format-table:
        properties:
          - Name
          - State
  - where:
      model-name: TagDetails
    set:
      format-table:
        properties:
          - TagName
          - CountValue
  - where:
      model-name: Application
    set:
      format-table:
        properties:
          - DisplayName
          - ObjectId
          - AppId
          - Homepage
          - AvailableToOtherTenant
  - where:
      model-name: KeyCredential
    set:
      format-table:
        properties:
          - StartDate
          - EndDate
          - KeyId
          - Type
  - where:
      model-name: PasswordCredential
    set:
      format-table:
        properties:
          - StartDate
          - EndDate
          - KeyId
  - where:
      model-name: User
    set:
      format-table:
        properties:
          - PrincipalName
          - DisplayName
          - ObjectId
          - Type
  - where:
      model-name: AdGroup
    set:
      format-table:
        properties:
          - DisplayName
          - Mail
          - ObjectId
          - SecurityEnabled
  - where:
      model-name: ServicePrincipal
    set:
      format-table:
        properties:
          - DisplayName
          - ObjectId
          - AppDisplayName
          - AppId
  - where:
      model-name: Location
    set:
      format-table:
        properties:
          - Name
          - DisplayName
  - where:
      model-name: ManagementLockObject
    set:
      format-table:
        properties:
          - Name
          - Level
          - ResourceId
  - where:
      model-name: RoleAssignment
    set:
      format-table:
        properties:
          - DisplayName
          - ObjectId
          - ObjectType
          - RoleDefinitionName
          - Scope
  - where:
      model-name: RoleDefinition
    set:
      format-table:
        properties:
          - RoleName
          - Name
          - Action
# Fix the name of the module in the nuspec
  - from: Az.Resources.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Azure Resource Manager and Active Directory cmdlets in Windows PowerShell and PowerShell Core.\n\nFor more information on Resource Manager, please visit the following$1 https://docs.microsoft.com/azure/azure-resource-manager/\nFor more information on Active Directory, please visit the following$1 https://docs.microsoft.com/azure/active-directory/fundamentals/active-directory-whatis');
# Add release notes
  - from: Az.Resources.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Azure Resource Manager and Active Directory cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Make the nuget package a preview
  - from: Az.Resources.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Resources cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Azure Resource Manager and Active Directory cmdlets in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Resource Manager, please visit the following$1 https://docs.microsoft.com/azure/azure-resource-manager/\\nFor more information on Active Directory, please visit the following$1 https://docs.microsoft.com/azure/active-directory/fundamentals/active-directory-whatis\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Resource Manager and Active Directory cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
