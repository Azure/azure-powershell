<!-- region Generated -->
# Az.Resources.TestSupport
This directory contains the PowerShell module for the Resources service.

---
## Status
[![Az.Resources.TestSupport](https://img.shields.io/powershellgallery/v/Az.Resources.TestSupport.svg?style=flat-square&label=Az.Resources.TestSupport "Az.Resources.TestSupport")](https://www.powershellgallery.com/packages/Az.Resources.TestSupport/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.7.4 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Resources.TestSupport`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g @autorest/autorest`<br>&nbsp;
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

> Values
``` yaml
azure: true
powershell: true
branch: master
repo: https://github.com/Azure/azure-rest-api-specs/blob/master
metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  copyright: Microsoft Corporation. All rights reserved.
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell
```

> Names
``` yaml
prefix: Az
```

> Folders
``` yaml
clear-output-folder: true
```

``` yaml
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/master/specification/resources/resource-manager/Microsoft.Resources/stable/2018-05-01/resources.json
module-name: Az.Resources.TestSupport
namespace: Microsoft.Azure.PowerShell.Cmdlets.Resources

subject-prefix: ''
module-version: 0.0.1
title: Resources

directive:
  - where:
      subject: Operation
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
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
      verb: Set
      subject: Resource
    remove: true
  - where:
      verb: Set
      subject: Deployment
    remove: true
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
      verb: New
      subject: Deployment
    hide: true
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
      subject: Provider
    set:
      subject: ResourceProvider
  - where:
      subject: ProviderFeature|ResourceProvider|ResourceLock
      parameter-name: ResourceProviderNamespace
    set:
      alias: ProviderNamespace
  - where:
      verb: Update
      subject: ResourceGroup
      parameter-name: Name
    clear-alias: true
  - where:
      parameter-name: UpnOrObjectId
    set:
      alias: ['UserPrincipalName', 'Upn', 'ObjectId']
  - where:
      subject: Deployment
      variant: (.*)Expanded(.*)
      parameter-name: Parameter
    set:
      parameter-name: DeploymentParameter
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
# To remove cmdlets not used in the test frame
  - where:
      subject: Operation
    remove: true
  - where:
      subject: Deployment
      variant: (.*)1|Cancel(.*)|Validate(.*)|Export(.*)|List(.*)|Delete(.*)|Check(.*)|Calculate(.*)
    remove: true
  - where:
      subject: ResourceProvider
      variant: Register(.*)|Unregister(.*)|Get(.*)
    remove: true
  - where:
      subject: ResourceGroup
      variant: List(.*)|Update(.*)|Export(.*)|Move(.*)
    remove: true
  - where:
      subject: Resource
    remove: true
  - where:
      subject: Tag|TagValue
    remove: true
  - where:
      subject: DeploymentOperation
    remove: true
  - where:
      subject: DeploymentTemplate
    remove: true
  - where:
      subject: Calculate(.*)
    remove: true
  - where:
      subject: ResourceExistence
    remove: true
  - where:
      subject: ResourceMoveResource
    remove: true
  - where:
      subject: DeploymentExistence
    remove: true
```
