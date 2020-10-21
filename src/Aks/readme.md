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

> Metadata
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

service-name: Aks
powershell: true
azure: true
branch: master
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
prefix: Az
subject-prefix: ''
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
clear-output-folder: true
output-folder: .
aks: $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerInstance
input-file:
- $(aks)/stable/2019-12-01/containerInstance.json

module-version: 4.0.1
title: AksClient
```

``` yaml
directive:
  - where:
      subject: Operation
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
  - from: managedClusters.json
    where: $.definitions.SubResource.properties
    transform: >
      return {
        "id": {
          "readOnly": true,
          "type": "string",
          "description": "Resource ID."
        },
        "name": {
          "readOnly": true,
          "type": "string",
          "description": "The name of the resource that is unique within a resource group. This name can be used to access the resource."
        },
        "restype": {
          "readOnly": true,
          "type": "string",
          "description": "Resource type"
        }
      }
```

### General settings
> Values

``` yaml
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
      verb: Update
      subject: ManagedClusterTag
      variant: $Update$|$UpdateViaIdentity
    remove: true
  - where:
      verb: Set
      subject: AgentPool
      variant: ^Update$
    remove: true
  - where:
      verb: New
      subject: AgentPool
      variant: ^(Create|CreateViaIdentity|CreateViaIdentityExpanded)$
    remove: true
  - where:
      verb: Reset
      subject: AadProfile|ServicePrincipalProfile
      variant: ^(Reset|ResetViaIdentity)$
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
      subject: ^Aks(?!.*AgentPool).*$
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias-name: ResourceName
  - where:
      verb: New|Set|Remove|Get
      subject: AksAgentPool
      parameter-name: ResourceName
    set:
      parameter-name: AksName
      alias-name: ResourceName
  - where:
      subject: AksAgentPoolAvailableAgentPoolVersion|AksTag
      parameter-name: ResourceName
    set:
      parameter-name: Name
      alias-name: ResourceName
  - where:
      subject: AksAgentPoolUpgradeProfile
      parameter-name: ResourceName
    set:
      parameter-name: AksName
      alias-name: ResourceName
  - where:
      subject: AksAgentPoolUpgradeProfile
      parameter-name: AgentPoolName
    set:
      parameter-name: Name
      alias-name: AgentPoolName
  - where:
      subject: ^Aks$
      parameter-name: NetworkProfile(.*)
    set:
      parameter-name: $1
  - where:
      subject: AksAgentPoolAvailableAgentPoolVersion
    set:
      subject: AksAvailableAgentPoolVersion
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
  - where:
      model-name: AksIdentity|ManagedCluster
      property-name: ResourceName
    set:
      property-name: Name

# Update csproj for customizations
  - from: Az.Aks.csproj
    where: $
    transform: >
        return $.replace('</Project>', '  <Import Project=\"custom\\aks.props\" />\n</Project>' );

# Update Restype back to type
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('SerializedName = @"restype"', 'SerializedName = @"type"');
# Update psm1 for module load
  - from: Az.Aks.psm1
    where: $
    transform: >
        return $.replace('\$null = Import-Module -Name \(Join-Path $PSScriptRoot \'\./bin/Az\.Aks\.private\.dll\'\)', '');
#
  - from: Az.Aks.psm1
    where: $
    transform: >
        return $.replace('\$instance = \[Microsoft\.Azure\.PowerShell\.Cmdlets\.Aks\.Module\]::Instance', '' );
# add back in
  - from: Az.Aks.psm1
    where: $
    transform: >
        return $.replace('# Ask for the shared functionality table', '$null = Import-Module -Name (Join-Path $PSScriptRoot \'./bin/Az.Aks.private.dll\')\n# Ask for the shared functionality table' );
# add again
  - from: Az.Aks.psm1
    where: $
    transform: >
        return $.replace('# Ask for the shared functionality table', '$instance = [Microsoft.Azure.PowerShell.Cmdlets.Aks.Module]::Instance\n# Ask for the shared functionality table' );

# add to build-module.ps1
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '$accountsName = \'Az.Accounts\'\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '$accountsModule = Get-Module -Name $accountsName\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', 'if(-not $accountsModule) {\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '  $localAccountsPath = Join-Path $PSScriptRoot \'generated\\modules\'\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '  if(Test-Path -Path $localAccountsPath) {\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '    $localAccounts = Get-ChildItem -Path $localAccountsPath -Recurse -Include \'Az.Accounts.psd1\' | Select-Object -Last 1\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '    if($localAccounts) {\n      $accountsModule = Import-Module -Name ($localAccounts.FullName) -Scope Global -PassThru\n    }\n  }\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '  if(-not $accountsModule) {\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '    $hasAdequateVersion = (Get-Module -Name $accountsName -ListAvailable | Where-Object { $_.Version -ge [System.Version]\'1.6.0\' } | Measure-Object).Count -gt 0\n# Load DLL to use build-time cmdlets');
# next line
  - from: generate-help.ps1
    where: $
    transform: >
        return $.replace('# Load DLL to use build-time cmdlets', '    if($hasAdequateVersion) {\n      $accountsModule = Import-Module -Name $accountsName -MinimumVersion 1.6.0 -Scope Global -PassThru\n    }\n  }\n}\n# Load DLL to use build-time cmdlets');
# Fix the name of the module in the nuspec
  - from: Az.Aks.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Aks service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on Aks, please visit the following$1 https://docs.microsoft.com/azure/aks/');
# Add release notes
  - from: Az.Aks.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Aks cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
 # Make the nuget package a preview
  - from: Az.Aks.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
 # Include YamlDotNet.dll
  - from: Az.Aks.nuspec
    where: $
    transform: $ = $.replace('<file src="bin/Az.Aks.private.dll" target="bin" />', '<file src="bin/Az.Aks.private.dll" target="bin" />\n    <file src="bin/YamlDotNet.dll" target="bin" />')
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Aks cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Aks service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Aks, please visit the following$1 https://docs.microsoft.com/azure/aks/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Aks cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
# Update .gitignore for samples for preview
  - from: .gitignore
    where: $
    transform: $ = $.replace('exports', '/exports');

```
