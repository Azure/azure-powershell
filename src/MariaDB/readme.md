<!-- region Generated -->
# Az.MariaDb
This directory contains the PowerShell module for the MariaDb service.

---
## Status
[![Az.MariaDb](https://img.shields.io/powershellgallery/v/Az.MariaDb.svg?style=flat-square&label=Az.MariaDb "Az.MariaDb")](https://www.powershellgallery.com/packages/Az.MariaDb/)

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
For information on how to develop for `Az.MariaDb`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/mariadb/resource-manager/readme.md

title: MariaDB
module-version: 4.0.0

directive:
  - where:
      verb: Set
    set:
      verb: Update
  - where:
     verb: New$
     variant: ^CreateViaIdentity
    hide: true
  - where:
      verb: New$|Update$
      variant: ^(?!.*?Expanded)
    hide: true

# Server
  - where:
      verb: New|Update
      subject: Server
    hide: true

# VNet
  - where:
      subject: VirtualNetworkRule
    set:
      subject: VNetRule
  - where:
      subject: VNetRule
      parameter-name: Parameter
    set:
      parameter-name: VNetRule
  - where:
      subject: VNetRule
      parameter-name: VirtualNetworkSubnetId
    set:
      parameter-name: SubnetId

# FirewallRule
  - where:
      subject: FirewallRule
      parameter-name: Parameter
    set:
      parameter-name: FirewallRule

# MariaDBConfiguration
  - where:
      verb: New
      subject: Configuration
    hide: true
  - where:
      verb: Update
      subject: Configuration
      parameter-name: Parameter
    set:
      parameter-name: Configuration
  - where:
      verb: Update
      subject: Configuration
    hide: true

  - where:
      subject: LogFile|Database|LocationBasedPerformanceTier|CheckNameAvailability|ServerSecurityAlertPolicy
    hide: true
  
# Fix the name of the module in the nuspec
  - from: Az.MariaDB.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - MariaDB service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on MariaDB, please visit the following$1 https://docs.microsoft.com/azure/MariaDB/');
# Add release notes
  - from: Az.MariaDB.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview MariaDB cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
 # Make the nuget package a preview
  - from: Az.MariaDB.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) MariaDB cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - MariaDB service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on MariaDB, please visit the following$1 https://docs.microsoft.com/azure/MariaDB/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview MariaDB cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
# Fix the bug that OperationOrigin.System conflict with namespace System
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/OperationOrigin System/, 'OperationOrigin System1');
  - from: ServerForCreate.cs
    where: $
    transform: $ = $.replace(/internal partial interface IServerForCreateInternal/, 'public partial interface IServerForCreateInternal');
```
