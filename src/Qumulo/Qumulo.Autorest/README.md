<!-- region Generated -->
# Az.Qumulo
This directory contains the PowerShell module for the Qumulo service.

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
For information on how to develop for `Az.Qumulo`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 9a84af9201f37ad7c221b42652c4e04f0d8473f3
# Pin the API version tag. The pinned swagger's default tag advanced to a newer
# api-version; pin to the original tag so the generated module stays on the
# api-version that the shipped code targets.
tag: package-2022-10-12-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/liftrqumulo/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/liftrqumulo/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Qumulo
service-name: Qumulo
subject-prefix: Qumulo

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required

  # Remove unexpanded Create/Update variants (v4 directive)
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Remove CreateViaIdentity variants as they are not needed for New-* cmdlets
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  # Don't support update of resource
  - where:
      verb: Update
    hide: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Set adminPassword to secure string
  - from: swagger-document 
    where: $.definitions.FileSystemResourceProperties.properties.adminPassword
    transform: >-
      return {
          "type": "string",
          "x-ms-secret": true,
          "description": "Initial administrator password of the resource",
          "format": "password"
      }
  # Rename FileSystemResource descriptions to file system resource
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Qumulo.Storage/fileSystems"].get.description
    transform: >-
      return "List file system resources by resource group"
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Qumulo.Storage/fileSystems/{fileSystemName}"].get.description
    transform: >-
      return "Get a file system resource"
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Qumulo.Storage/fileSystems/{fileSystemName}"].put.description
    transform: >-
      return "Create a file system resource"
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Qumulo.Storage/fileSystems/{fileSystemName}"].patch.description
    transform: >-
      return "Update a file system resource"
  - from: swagger-document 
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Qumulo.Storage/fileSystems/{fileSystemName}"].delete.description
    transform: >-
      return "Delete a file system resource"
  # Rename parameters for better PowerShell experience
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      parameter-name: MarketplaceDetailOfferId
    set:
      parameter-name: MarketplaceOfferId
  - where:
      parameter-name: MarketplaceDetailMarketplaceSubscriptionId
    set:
      parameter-name: MarketplaceSubscriptionId
  - where:
      parameter-name: MarketplaceDetailPlanId
    set:
      parameter-name: MarketplacePlanId
  - where:
      parameter-name: MarketplaceDetailPublisherId
    set:
      parameter-name: MarketplacePublisherId
  - where:
      parameter-name: UserDetailEmail
    set:
      parameter-name: UserEmail
```
