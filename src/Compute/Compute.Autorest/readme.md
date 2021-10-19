<!-- region Generated -->
# Az.Compute
This directory contains the PowerShell module for the Compute service.

---
## Status
[![Az.Compute](https://img.shields.io/powershellgallery/v/Az.Compute.svg?style=flat-square&label=Az.Compute "Az.Compute")](https://www.powershellgallery.com/packages/Az.Compute/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Compute`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7b19bbd8ee63fa724edf5c780b63ae038312d2b1
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
#  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/compute/resource-manager/Microsoft.Compute/stable/2021-07-01/compute.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/compute/resource-manager/Microsoft.Compute/stable/2021-07-01/gallery.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Compute
subject-prefix: ""

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove following verbs
  - select: command
    where:
      verb: Export|Convert|Install|Set
    remove: true
  # Remove existing cmdlets
  - select: command
    where: 
      subject: Gallery$|GallerySharingProfile|GalleryImage$|GalleryImageVersion$
    remove: true
  # changing parameter names for GalleryApplication, GalleryApplicationVersion
  - where:
      verb: New
      subject: GalleryApplicationVersion
      parameter-name: ManageActionRemove
    set:
      parameter-name: Remove
  - where:
      verb: New
      subject: GalleryApplicationVersion
      parameter-name: ManageActionInstall
    set:
      parameter-name: Install
  - where:
      verb: New
      subject: GalleryApplicationVersion
      parameter-name: ManageActionUpdate
    set:
      parameter-name: Update
  - where:
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: SourceMediaLink
    set:
      parameter-name: PackageFileLink
  - where:
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: PublishingProfileReplicaCount
    set:
      parameter-name: ReplicaCount
  - where:
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: PublishingProfileTargetRegion
    set:
      parameter-name: TargetRegion
  - where:
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: SourceDefaultConfigurationLink
    set:
      parameter-name: DefaultConfigFileLink
  ### END # changing parameter names for GalleryApplication, GalleryApplicationVersion
  - where:
      verb: New
      subject: GalleryApplication$
      parameter-name: EndOfLifeDate
    hide: true
```
