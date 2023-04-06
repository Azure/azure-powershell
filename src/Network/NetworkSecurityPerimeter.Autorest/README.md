<!-- region Generated -->
# Az.NetworkSecurityPerimeter
This directory contains the PowerShell module for the NetworkSecurityPerimeter service.

---
## Status
[![Az.NetworkSecurityPerimeter](https://img.shields.io/powershellgallery/v/Az.NetworkSecurityPerimeter.svg?style=flat-square&label=Az.NetworkSecurityPerimeter "Az.NetworkSecurityPerimeter")](https://www.powershellgallery.com/packages/Az.NetworkSecurityPerimeter/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.NetworkSecurityPerimeter`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
# - ../../../../tools/SwaggerCI/readme.azure.noprofile.md
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/kaushal087/azure-rest-api-specs/blob/edd10769b1c1bc88bde274add8562beb13b118af/specification/network/resource-manager/Microsoft.Network/preview/2021-02-01-preview/networkSecurityPerimeter.json
#  - C:\repo\azure-rest-api-specs/specification/network/resource-manager/Microsoft.Network/preview/2021-02-01-preview/networkSecurityPerimeter.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
root-module-name: $(prefix).Network
title: NetworkSecurityPerimeter
subject-prefix: $(service-name)
sanitize-names: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
#  - where:
#      variant: ^Create$|^CreateViaIdentityExpanded$
#    remove: true
# Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      variant: ^Update$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$
    remove: true
  # Hide CreateViaIdentity for customization
  - where:
      variant: ^CreateViaIdentity$
    hide: true
  - where:
      subject: NetworkSecurityPerimeter
    set:
      subject-prefix: ''
  - where:
      subject: NspProfile
    set:
      subject: Profile
  - where:
      subject: NspAccessRule
    set:
      subject: AccessRule
  - where:
      subject: NspAssociation
    set:
      subject: Association
  - where:
      subject: NspLink
    set:
      subject: Link
  - where:
      subject: NspLinkReference
    set:
      subject: LinkReference

# Parameter Update
# NSP
  - where:
      subject: NetworkSecurityPerimeter
      parameter-name: Name
    set:
      alias: 
        - SecurityPerimeterName
        - NSPName

  - where:
      subject: NetworkSecurityPerimeter
      parameter-name: Id
    set:
      parameter-name: SecurityPerimeterId
      alias:
        - Id

# Profile
  - where:
      subject: Profile
      parameter-name: ProfileName
    set:
      parameter-name: Name
      alias:
        - ProfileName

  - where:
      subject: Profile
      parameter-name: Id
    set:
      parameter-name: ProfileId
      alias: 
        - Id

  - where:
      subject: Profile
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# AccessRule
  - where:
      subject: AccessRule
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

  - where:
      subject: AccessRule
      parameter-name: Id
    set:
      parameter-name: AccessRuleId
      alias:
        - Id

  - where:
      subject: AccessRule
      parameter-name: ProfileName
    set:
      parameter-name: ProfileName
      alias: 
        - SecurityPerimeterProfileName
        - NSPProfileName

  - where:
      subject: AccessRule
      parameter-name: AccessRuleName
    set:
      parameter-name: Name
      alias:
        - AccessRuleName

  - where:
      subject: AccessRule
      parameter-name: NetworkSecurityPerimeter
    set:
      parameter-name: Perimeter

# Association
  - where:
      subject: Association
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

  - where:
      subject: Association
      parameter-name: ProfileName
    set:
      parameter-name: ProfileName
      alias: 
        - SecurityPerimeterProfileName
        - NSPProfileName

  - where:
      subject: Association
      parameter-name: AssociationName
    set:
      parameter-name: Name
      alias:
        - AssociationName

  - where:
      subject: Association
      parameter-name: Id
    set:
      parameter-name: AssociationId
      alias:
        - Id

# Link
  - where:
      subject: Link
      parameter-name: LinkName
    set:
      parameter-name: Name
      alias:
        - LinkName

  - where:
      subject: Link
      parameter-name: Id
    set:
      parameter-name: LinkId
      alias: 
        - Id

  - where:
      subject: Link
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# LinkReference
  - where:
      subject: LinkReference
      parameter-name: LinkReferenceName
    set:
      parameter-name: Name
      alias:
        - LinkReferenceName

  - where:
      subject: LinkReference
      parameter-name: Id
    set:
      parameter-name: LinkReferenceId
      alias: 
        - Id

  - where:
      subject: LinkReference
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# feature request for the below change https://github.com/Azure/autorest.powershell/issues/982
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('if (result.NextLink != null)', 'if (result.NextLink != null && result.NextLink != "")')

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('_nextLink != null', '_nextLink != null && _nextLink != ""')

```
