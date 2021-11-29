<!-- region Generated -->
# Az.CustomProviders
This directory contains the PowerShell module for the CustomProviders service.

---
## Status
[![Az.CustomProviders](https://img.shields.io/powershellgallery/v/Az.CustomProviders.svg?style=flat-square&label=Az.CustomProviders "Az.CustomProviders")](https://www.powershellgallery.com/packages/Az.CustomProviders/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.CustomProviders`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/customproviders/resource-manager/Microsoft.CustomProviders/preview/2018-09-01-preview/customproviders.json

metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell: Custom Providers cmdlets'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule CustomProviders
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell
  releaseNotes: Initial release of CustomProviders cmdlets.

module-version: 0.1.0
title: CustomProviders
subject-prefix: ''

directive:
  - where:
      subject: CustomResourceProvider
    set:
      subject: CustomProvider

  - where:
      subject: Association
    set:
      subject: CustomProviderAssociation

  - where: 
      verb: New
      subject: ^CustomProvider.*$
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Create$
    remove: true
  
  - where:
      verb: Set
      subject: CustomProviderAssociation
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Set
      subject: ^CustomProvider$
    remove: true

  - where:
      verb: Update
      subject: CustomProvider
      variant: ^Update$|^UpdateViaIdentity$
    remove: true

  - where:
       verb: Set
       subject: CustomProviderAssociation
    remove: true

# Parameter renames
  - where: 
      subject: ^CustomProvider$
      parameter-name: ResourceProviderName
    set:
      parameter-name: Name
      alias: ResourceProviderName

# Make ResourceId validation case insensitive
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/var _match = new global\:\:System\.Text\.RegularExpressions\.Regex\(\"([^\"]+)\"\).Match\(viaIdentity\);/g, 'var _match = new global\:\:System.Text.RegularExpressions.Regex\(\"$1\", global\:\:System\.Text\.RegularExpressions\.RegexOptions\.IgnoreCase\).Match\(viaIdentity\);');

# Fix issue with delete LRO operations
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/var _finalUri = _response.GetFirstHeader\(\@\"Location\"\);/g, 'var _finalUri = \"\";');

```
