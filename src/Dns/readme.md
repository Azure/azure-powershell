<!-- region Generated -->
# Az.Dns
This directory contains the PowerShell module for the Dns service.

---
## Status
[![Az.Dns](https://img.shields.io/powershellgallery/v/Az.Dns.svg?style=flat-square&label=Az.Dns "Az.Dns")](https://www.powershellgallery.com/packages/Az.Dns/)

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
For information on how to develop for `Az.Dns`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/dns/resource-manager/readme.md

title: Dns
module-version: 4.0.2

directive:
# RecordSet
  - where:
      subject: RecordSet
      parameter-name: Parameter
    set:
      parameter-name: RecordSet
  - where: # This parameter needs removed
      subject: RecordSet
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: RecordSet
      parameter-name: RelativeRecordSetName
    set:
      parameter-name: Name
      alias: RelativeRecordSetName
  - where:
      subject: RecordSet
      parameter-name: Ttl
    set:
      parameter-name: TimeToLive
      alias: Ttl
  - where:
      subject: RecordSet
      parameter-name: Recordsetnamesuffix
    set:
      parameter-name: NameSuffix
  - where:
      subject: RecordSet
      parameter-name: MxRecord
    set:
      parameter-name: MXRecord
  - where:
      subject: RecordSet
      parameter-name: NsRecord
    set:
      parameter-name: NSRecord
  - where:
      subject: RecordSet
      parameter-name: CnameRecordCname
    set:
      parameter-name: CnameRecordName
  - where:
      verb: ^New$|^Set$|^Update$
      subject: RecordSet
    hide: true

# ResourceReference
  - where:
      subject: DnsResourceReference
      parameter-name: Parameter
    set:
      parameter-name: ResourceReference
  - where:
      verb: Get
      subject: DnsResourceReference
    hide: true

# Zone
  - where: # Only updates Tags
      verb: Update
      subject: Zone
    remove: true
  - where:
      subject: Zone
      parameter-name: Parameter
    set:
      parameter-name: Zone
  - where:
      verb: ^New$|^Set$
      subject: Zone
    hide: true
# Fix the name of the module in the nuspec
  - from: Az.Dns.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Dns service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on DNS, please visit the following$1 https://docs.microsoft.com/azure/dns/');
# Add release notes
  - from: Az.Dns.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Dns cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
 # Make the nuget package a preview
  - from: Az.Dns.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Dns cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Dns service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on DNS, please visit the following$1 https://docs.microsoft.com/azure/dns/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Dns cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
