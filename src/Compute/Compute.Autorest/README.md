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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Compute`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
branch: 4640dfc655f8641962814663fd03fd667e5c1a88
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/compute/resource-manager/Microsoft.Compute/stable/2022-01-03/GalleryRP/gallery.json
  - $(repo)/specification/compute/resource-manager/Microsoft.Compute/stable/2021-07-01/runCommands.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
module-version: 0.2.0
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
      verb: Export|Convert|Install
    remove: true
  # Remove existing cmdlets
  - select: command
    where: 
      subject: Gallery$|GallerySharingProfile|GalleryImage$|GalleryImageVersion$
    remove: true
  - select: command
    where: 
      subject: GalleryApplication$|GalleryApplicationVersion$
      verb: Set
    remove: true
  # Change model names for GalleryApplicationVersion
  - where: 
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: ManageActionInstall
    set:
      property-name: Install
  - where:  
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: ManageActionRemove
    set:
      property-name: Remove
  - where:  
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: ManageActionUpdate
    set:
      property-name: Update
  - where:  
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: SourceDefaultConfigurationLink
    set:
      property-name: DefaultConfigFileLink
  - where:  
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: SourceMediaLink
    set:
      property-name: PackageFileLink
  - where: 
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: PublishingProfileReplicaCount
    set:
      property-name: ReplicaCount
  - where: 
      model-name: GalleryApplicationVersion|GalleryApplicationVersionProperties
      property-name: PublishingProfileTargetRegion
    set:
      property-name: TargetRegion
  ### END # Change model names for GalleryApplicationVersion
  # change parameter names for GalleryApplicationVersion
  - where: 
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: ManageActionInstall
    set:
      parameter-name: Install
  - where:   
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: ManageActionRemove
    set:
      parameter-name: Remove
  - where:   
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: ManageActionUpdate
    set:
      parameter-name: Update
  - where:   
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: SourceDefaultConfigurationLink
    set:
      parameter-name: DefaultConfigFileLink
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
      parameter-name: SettingConfigFileName
    set:
      parameter-name: ConfigFileName  
  - where:  
      verb: New|Update
      subject: GalleryApplicationVersion
      parameter-name: SettingPackageFileName
    set:
      parameter-name: PackageFileName  
  ### END # change parameter names for GalleryApplicationVersion
  # hide parameters for New, Update Gallery Application
  - where:
      verb: Update
      subject: GalleryApplication$
      parameter-name: SupportedOSType
    hide: true
  - where:
      verb: Update|New
      subject: GalleryApplication$
      parameter-name: Eula|EndOfLifeDate|PrivacyStatementUri|ReleaseNoteUri
    hide: true
  ### END # hide parameters for New,Update Gallery Application
  # hide parameters for New, Update Gallery Application Version
  - where:
      verb: Update|New
      subject: GalleryApplicationVersion$
      parameter-name: PublishingProfileEnableHealthCheck|PublishingProfileStorageAccountType|PublishingProfileReplicationMode|PublishingProfileTargetExtendedLocation|PublishingProfileAdvancedSetting
    hide: true
  - where:
      verb: Update
      subject: GalleryApplicationVersion$
      parameter-name: Update|Install|Remove
    hide: true
  ### END # hide parameters for New, Update Gallery Application Version
  # hide New-AzGalleryApplication, New-AzGalleryApplicationVersion, Update-AzGalleryApplicationVersion
  - where:
      verb: New|Update
      subject: GalleryApplicationVersion
    hide: true
  - where:
      verb: New
      subject: GalleryApplication
    hide: true 
  ### END # hide New-AzGalleryApplication, New-AzGalleryApplicationVersion, Update-AzGalleryApplicationVersion
  - where:
      subject: VirtualMachineRunCommand
    set:
      subject: VMRunCommand
  - where:
      subject: VirtualMachineScaleSetVMRunCommand
    set:
      subject: VmssVMRunCommand
  - where:
      verb: Start
      subject: VirtualMachineCommand
    remove: true
  - where:
      verb: Start
      subject: VirtualMachineScaleSetVMCommand
    remove: true
  - where:
      verb: New
      subject: VmssVMRunCommand|VMRunCommand
    remove: true
  - where:
      verb: Update
      subject: VmssVMRunCommand|VMRunCommand
    remove: true
  - where:
      subject: VmssVMRunCommand|VMRunCommand
      variant: ^GetViaIdentity1
    remove: true
  - where:
      model-name: VirtualMachineRunCommand
    set:
      format-table:
        properties:
          - Name
          - Location
          - RunAsUser
          - AsyncExecution
          - ErrorBlobUri
          - Id
          - InstanceViewEndTime
          - InstanceViewError
          - InstanceViewExecutionMessage
          - InstanceViewExeutionStage
          - InstanceViewExitCode
          - InstanceViewOutput
          - InstanceViewStartTime
          - InstanceViewStatuses
          - OutputBlobUri
          - Paramater
          - ProtectedParameter
          - ProvisioningStage
          - RunAsPassword
          - SourceCommandId
          - SourceScript
          - SourceScriptUri
          - Tag
          - TimeoutInSecond
          - Type
```
