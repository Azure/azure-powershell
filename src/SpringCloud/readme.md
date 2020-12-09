<!-- region Generated -->
# Az.SpringCloud
This directory contains the PowerShell module for the SpringCloud service.

---
## Status
[![Az.SpringCloud](https://img.shields.io/powershellgallery/v/Az.SpringCloud.svg?style=flat-square&label=Az.SpringCloud "Az.SpringCloud")](https://www.powershellgallery.com/packages/Az.SpringCloud/)

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
For information on how to develop for `Az.SpringCloud`, see [how-to.md](how-to.md).
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
branch: f595fe8142bff77ddba974fe8ec53522528eed61
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appplatform/resource-manager/Microsoft.AppPlatform/stable/2020-07-01/appplatform.json
    
title: SpringCloud
module-version: 0.1.0
identity-correction-for-post: true
# prefix: Az
# subject-prefix: ''

directive:
  - where:
      verb: Set
      subject: App$|Binding$|CustomDomain$|Deployment$|Service$|Certificate$|ConfigServerPut$|MonitoringSettingPut$
    remove: true
  - where:
      verb: Get
      subject: ConfigServer$|MonitoringSetting$|RuntimeVersion$
    remove: true
  - where:
      verb: Test
      subject: AppDomain$
    remove: true
  - where:
      verb: Update
      subject: ConfigServerPatch$|MonitoringSettingPatch
    remove: true
  # - where:
  #     verb: Set
  #     subject: App$|Binding$|CustomDomain$|Deployment$|Service$
  #   set:
  #     verb: Update
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/internal partial interface/, 'public partial interface');
  - where:
      subject: ServiceTestEndpoint$
      variant: ^DisableViaIdentity$|^EnableViaIdentity$
    remove: true
  - where:
      subject: ServiceTestKey$
      variant: ^RegenerateViaIdentityExpanded$|^RegenerateViaIdentity$
    remove: true
  - where:
      subject: DeploymentClusterDeployment|DeploymentLogFileUrl|ServiceTestKey|Sku|ServiceTestEndpoint|ServiceNameAvailability|Binding|CustomDomain|Certificate
    remove: true
  - where:
      subject: Deployment
      verb: New|Update
    hide: true
  - where:
      subject: Deployment
    set:
      subject: AppDeployment
  - where:
      subject: App
      verb: New|Update
    hide: true
  - where:
      subject: Service|AppResourceUploadUrl
    hide: true
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppPlatform/Spring/{serviceName}"].delete.responses
    transform: >-
        return {
          "200": {
            "description": "Accepted. The response indicates the delete operation is performed in the background."
          },
          "202": {
            "description": "Accepted. The response indicates the delete operation is performed in the background."
          },
          "204": {
            "description": "Success. The response indicates the resource is already deleted."
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/CloudError"
            }
          }
        }
```
