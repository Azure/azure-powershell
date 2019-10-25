<!-- region Generated -->
# Az.Aks
This directory contains the PowerShell module for the Aks service.

---
## Status
[![Az.Aks](https://img.shields.io/powershellgallery/v/Az.Aks.svg?style=flat-square&label=Az.Aks "Az.Aks")](https://www.powershellgallery.com/packages/Az.Aks/)

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
For information on how to develop for `Az.Aks`, see [how-to.md](how-to.md).
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

> Directives
``` yaml
metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell: $(service-name) cmdlets'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule $(service-name)
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell

directive:
  - where:
      subject: Operation
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
```

### General settings
> Values

``` yaml
service-name: Aks
powershell: true
azure: true
branch: master
repo: https://github.com/erich-wang/azure-rest-api-specs/blob/$(branch)
prefix: Az
subject-prefix: ''
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService
input-file:
- $(aks)/stable/2019-08-01/location.json
- $(aks)/stable/2019-08-01/managedClusters.json

module-version: 0.0.1
title: AksClient

directive:
  - where:
      subject: Operation
    hide: true
  - where: $.definitions.Identifier.properties
    suppress: R3019
  - where:
      verb: New|Set|Remove|Get
      subject: ^ManagedCluster$
      variant: Create|CreateViaIdentity|Update|UpdateViaIdentity|Get|List|Delete
    remove: true
  - where:
      subject: (ManagedCluster|ContainerService)(.*)
    set:
      subject: Aks$2
  - where:
      subject: (AgentPool|Operation)(.*)
    set:
      subject: Aks$1$2
  - where:
      verb: New|Set|Remove|Get
      subject: Aks
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias-name: ResouceName
  - where:
      model-name: ManagedCluster
    set:
      format-table:
        properties:
          - Name
          - Type
          - ProvisioningState
          - DnsPrefix
          - Fqdn
          - KubernetesVersion
          - Id
          - Tag

# Update csproj for customizations
  - from: Az.Aks.csproj
    where: $
    transform: >
        return $.replace('</Project>', '  <Import Project=\"custom\\aks.props\" />\n</Project>' );

# Update Restype back to type
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('SerializedName = @"restype"', 'SerializedName = @"type"');
```

