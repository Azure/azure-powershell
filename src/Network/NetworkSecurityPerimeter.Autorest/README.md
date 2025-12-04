<!-- region Generated -->
# Az.NetworkSecurityPerimeter
This directory contains the PowerShell module for the NetworkSecurityPerimeter service.

---
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
commit: main
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/4db9e81042ec3ffd1eee8df1bf2b8489a1e7fa0a/specification/network/resource-manager/Microsoft.Network/stable/2025-03-01/networkSecurityPerimeter.json

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
  
  # Hide Reconcile apis
  - where:
      subject: ReconcileNetworkSecurityPerimeterAccessRule
    remove: true
  - where:
      subject: ReconcileNetworkSecurityPerimeterAssociation
    remove: true
  - where:
      subject: NetworkSecurityPerimeterOperationStatuses
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      variant: ^Update.*$
    remove: true
  # Hide CreateViaIdentity for customization
  - where:
      variant: ^CreateViaIdentity$
    hide: true
  - where:
      subject: NetworkSecurityPerimeterProfile
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterAccessRule
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterAssociation
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterLink
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterLinkReference
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterLoggingConfiguration
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterAssociableResourceType
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeterServiceTag
    set:
      subject-prefix: ''
  - where:
      subject: NetworkSecurityPerimeter
    set:
      subject-prefix: ''

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
      subject: NetworkSecurityPerimeterProfile
      parameter-name: ProfileName
    set:
      parameter-name: Name
      alias:
        - ProfileName

  - where:
      subject: NetworkSecurityPerimeterProfile
      parameter-name: Id
    set:
      parameter-name: ProfileId
      alias: 
        - Id

  - where:
      subject: NetworkSecurityPerimeterProfile
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# AccessRule
  - where:
      subject: NetworkSecurityPerimeterAccessRule
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

  - where:
      subject: NetworkSecurityPerimeterAccessRule
      parameter-name: Id
    set:
      parameter-name: AccessRuleId
      alias:
        - Id

  - where:
      subject: NetworkSecurityPerimeterAccessRule
      parameter-name: ProfileName
    set:
      parameter-name: ProfileName
      alias: 
        - SecurityPerimeterProfileName
        - NSPProfileName

  - where:
      subject: NetworkSecurityPerimeterAccessRule
      parameter-name: AccessRuleName
    set:
      parameter-name: Name
      alias:
        - AccessRuleName

  - where:
      subject: NetworkSecurityPerimeterAccessRule
      parameter-name: NetworkSecurityPerimeter
    set:
      parameter-name: Perimeter

# Association
  - where:
      subject: NetworkSecurityPerimeterAssociation
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

  - where:
      subject: NetworkSecurityPerimeterAssociation
      parameter-name: ProfileName
    set:
      parameter-name: ProfileName
      alias: 
        - SecurityPerimeterProfileName
        - NSPProfileName

  - where:
      subject: NetworkSecurityPerimeterAssociation
      parameter-name: AssociationName
    set:
      parameter-name: Name
      alias:
        - AssociationName

  - where:
      subject: NetworkSecurityPerimeterAssociation
      parameter-name: Id
    set:
      parameter-name: AssociationId
      alias:
        - Id

# Link
  - where:
      subject: NetworkSecurityPerimeterLink
      parameter-name: LinkName
    set:
      parameter-name: Name
      alias:
        - LinkName

  - where:
      subject: NetworkSecurityPerimeterLink
      parameter-name: Id
    set:
      parameter-name: LinkId
      alias: 
        - Id

  - where:
      subject: NetworkSecurityPerimeterLink
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# LinkReference
  - where:
      subject: NetworkSecurityPerimeterLinkReference
      parameter-name: LinkReferenceName
    set:
      parameter-name: Name
      alias:
        - LinkReferenceName

  - where:
      subject: NetworkSecurityPerimeterLinkReference
      parameter-name: Id
    set:
      parameter-name: LinkReferenceId
      alias: 
        - Id

  - where:
      subject: NetworkSecurityPerimeterLinkReference
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

# LoggingConfiguration
  - where:
      subject: NetworkSecurityPerimeterLoggingConfiguration
      parameter-name: LoggingConfigurationName
    set:
      parameter-name: Name
      alias:
        - LoggingConfigurationName

  - where:
      subject: NetworkSecurityPerimeterLoggingConfiguration
      parameter-name: Id
    set:
      parameter-name: LoggingConfigurationId
      alias: 
        - Id

  - where:
      subject: NetworkSecurityPerimeterLoggingConfiguration
      parameter-name: NetworkSecurityPerimeterName
    set:
      parameter-name: SecurityPerimeterName
      alias: 
        - NetworkSecurityPerimeterName
        - NSPName

  - where:
      subject: NetworkSecurityPerimeterLoggingConfiguration
      parameter-name: Name
    set:
      default:
        script: '"instance"'

# feature request for the below change https://github.com/Azure/autorest.powershell/issues/982
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('if (result.NextLink != null)', 'if (result.NextLink != null && result.NextLink != "")')

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('_nextLink != null', '_nextLink != null && _nextLink != ""')

```
