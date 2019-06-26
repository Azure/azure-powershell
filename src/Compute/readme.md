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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Compute`, see [how-to.md](how-to.md).
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
  - $(repo)/specification/compute/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/compute/resource-manager/readme.md

#input-file: 
#  - $(repo)/specification/containerservice/resource-manager/Microsoft.ContainerService/stable/2017-07-01/containerService.json

subject-prefix: ''
module-version: 0.0.1

directive:
# subject renames for VM and Vmss
  - where:
      subject: VirtualMachineScaleSet(.*)
    set:
      subject: Vmss$1
  - where:
      subject: VirtualMachine(.*)
    set:
      subject: VM$1
  - where:
      subject: VM
      parameter-name: VmName
    set:
      parameter-name: Name
  - where:
      subject: Vmss
      parameter-name: VMScaleSetName
    set:
      parameter-name: Name
      alias: VMScaleSetName
  - where:
      subject: VmssExtension
      parameter-name: VmssExtensionName
    set:
      parameter-name: ExtensionName
# Fix Convert verb
  - where:
      verb: Convert
      subject: VMToManagedDisk
    set:
      verb: ConvertTo
      subject: VMManagedDisk
  - where:
      verb: Convert
      subject: VmssToSinglePlacementGroup
    set:
      verb: ConvertTo
      subject: VmssSinglePlacementGroup
# Add service name prefix
  - where:
      verb: Get
      subject: ResourceSku
    set:
      subject-prefix: Compute
# Cmdlet renames 
  - where:
      verb: Invoke
      subject: ForceVmssRecoveryServiceFabricPlatformUpdateDomainWalk
    set:
      verb: Repair
      subject: VmssServiceFabricUpdateDomain
  - where:
      verb: Get
      subject: VMRunCommand
    set:
      subject: VMRunCommandDocument
  - where: 
      verb: Get
      subject: VmssRollingUpgradeLatest
    set:
      subject: VmssRollingUpgrade
  - where: 
      verb: Invoke
      subject: RedeployVM
    set:
      subject: VMReimage
  - where:
      verb: Set
      subject: Gallery
    set:
      verb: Update
  - where:
      verb: Set
      subject: GalleryImage.*
    set:
      verb: Update
  - where: 
      subject: GalleryImage
    set:
      subject: GalleryImageDefinition
  - where:
      subject: Usage
    set:
      subject: VMUsage
  - where: 
      verb: Start
      subject: VmssRollingUpgradeOSUpgrade
    set:
      subject: VmssRollingOSUpgrade
  - where:
      verb: Start
      subject: .+Command
    set: 
      verb: Invoke
  - where:
      verb: Invoke
      subject: VMCommand
    set:
      alias: Invoke-AzVMRunCommand
  - where:
      verb: Invoke
      subject: VmssVMCommand
    set:
      alias: Invoke-AzVmssVMRunCommand
#  - where:
#      verb: Reset
#      subject: VM
#    set: 
#      alias: Invoke-AzVMReimage
  - where: 
      verb: Export
      subject: VM
    set:
      verb: Save
      subject: VMImage
  - where: 
      verb: Export
      subject: LogAnalyticRequestRate
    set:
      subject: LogAnalyticRequestRateByInterval
  - where: 
      verb: Export
      subject: LogAnalyticThrottledRequest
    set:
      alias: Export-AzLogAnalyticThrottledRequests
  # parameter renames
  - where: 
      verb: New
      subject: GalleryImageDefinition
      parameter-name: Identifier(.+)
    set:
      parameter-name: $1
  - where: 
      subject: GalleryImageDefinition
      parameter-name: VCpUsMin
    set:
      parameter-name: MinimumVCpu
  - where: 
      subject: GalleryImageDefinition
      parameter-name: VCpUsMax
    set:
      parameter-name: MaximumVCpu
  - where: 
      subject: GalleryImageDefinition
      parameter-name: MemoryMin
    set:
      parameter-name: MinimumMemory
  - where: 
      subject: GalleryImageDefinition
      parameter-name: MemoryMax
    set:
      parameter-name: MaximumMemory
  - where:
      subject: VM
      parameter-name: Parameter
    set:
      parameter-name: VM
  - where:
      subject: Vmss
      parameter-name: Parameter
    set:
      parameter-name: VirtualMachineScaleSet
  - where:
      subject: VM
      parameter-name: HardwareProfileVMSize
    set:
      parameter-name: Size
  - where:
      parameter-name: AdditionalCapabilityUltraSsdEnabled
    set:
      parameter-name: UltraSsdEnabled
  - where:
      parameter-name: UltraSsdEnabled
    set:
      alias: EnableUltraSSD
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: IdentityId
  - where:
      parameter-name: IdentityId
    set:
      alias: UserAssignedIdentity
  - where:
      parameter-name: AutomaticOSUpgradePolicyEnableAutomaticOsupgrade
    set:
      parameter-name: AutomaticOSUpgrade
  - where:
      parameter-name: RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent
    set:
      parameter-name: MaxUnhealthyUpgradedInstancePercent
  - where:
      parameter-name: AutomaticOSUpgradePolicyDisableAutomaticRollback
    set:
      parameter-name: DisableAutoRollback
  - where:
      parameter-name: RollingUpgradePolicyMaxBatchInstancePercent
    set:
      parameter-name: MaxBatchInstancePercent
  - where:
      parameter-name: RollingUpgradePolicyMaxUnhealthyInstancePercent
    set:
      parameter-name: MaxUnhealthyInstancePercent
  - where:
      parameter-name: RollingUpgradePolicyPauseTimeBetweenBatch
    set:
      parameter-name: PauseTimeBetweenBatches
  - where: 
      subject: GalleryImageVersion
      parameter-name: ^PublishingProfile(.*)$
    set:
      parameter-name: $1
  - where: 
      subject: GalleryImageVersion
      parameter-name: ManagedImageId
    set:
      alias: SourceImageId
  - where:
      subject: Image
      parameter-name: Parameter
    set:
      parameter-name: Image
  - where: 
      parameter-name: GalleryImageName
    set:
      parameter-name: GalleryImageDefinitionName
  - where:
      subject: VMExtension
      parameter-name: ExtensionImageName
    set:
      parameter-name: ImageName
  - where:
      subject: VMExtension
      parameter-name: VMExtensionName
    set:
      parameter-name: Name
  - where:
      subject: VMExtension
      parameter-name: PropertiesType
    set:
      parameter-name: ExtensionType
  - where:
      subject: VMExtension
      parameter-name: Setting
    set:
      alias: Settings
  - where:
      subject: VMExtension
      parameter-name: ProtectedSetting
    set:
      alias: ProtectedSettings
  - where:
      subject: VMExtension
      parameter-name: ForceUpdateTag
    set:
      parameter-name: ForceRerun
  - where:
      subject: VmssExtension
      parameter-name: VMScaleSetName
    set:
      parameter-name: VmssName
  - where:
      verb: Get
      subject: VMImage
      parameter-name: Filter
    set:
      parameter-name: FilterExpression
  - where:
      verb: Get
      subject: VMImage
      parameter-name: Sku
    set:
      alias: Skus
  - where:
      verb: Remove
      subject: VmssExtension
      parameter-name: VmssExtensionName
    set:
      parameter-name: Name
  - where:
      subject: VmssExtension
      parameter-name: ExtensionParameter
    set:
      parameter-name: VmssExtension
  - where:
      subject: VmssVM
      parameter-name: VMScaleSetVMReimageInput
    set:
      parameter-name: VirtualMachineScaleSetVM
  - where:
      subject: AvailabilitySet
      parameter-name: Parameter
    set:
      parameter-name: AvailabilitySet
  - where:
      parameter-name: ^DurationIn(Second|Millisecond|Minute|Hour|Day)$
    set:
      parameter-name: DurationIn$1s
      alias: ${parameter-name}
  - where:
      parameter-name: ^PlatformFaultDomainCount$
    set:
      parameter-name: FaultDomainCount
      alias: PlatformFaultDomainCount
  - where:
      parameter-name: ^PlatformUpdateDomainCount$
    set:
      parameter-name: UpdateDomainCount
      alias: PlatformUpdateDomainCount
  - where:
      subject: .*Disk.*|.*Snapshot.*
      parameter-name: CreationData(.+)
    set:
      parameter-name: $1
  - where:
      subject: .*Disk.*|.*Snapshot.*
      parameter-name: Disk(.+)
    set:
      parameter-name: $1
  - where:
      subject: .*Disk.*|.*Snapshot.*
      parameter-name: EncryptionSettingCollectionEnabled
    set:
      parameter-name: EncryptionEnabled
  - where:
      subject: .*Disk.*|.*Snapshot.*
      parameter-name: EncryptionSettingCollectionEncryptionSetting
    set:
      parameter-name: EncryptionSetting
  - where:  
      subject: ProximityPlacementGroup
      parameter-name: Parameter
    set:
      parameter-name: ProximityPlacementGroup
  - where:
      parameter-name: ^(.+)SizeGb$
    set:
      parameter-name: $1SizeInGb
  - where:
      parameter-name: ^SizeGb$
    set:
      parameter-name: SizeInGb
  - where:
      subject: VMExtension
      parameter-name: ExtensionParameter
    set:
      parameter-name: VMExtension
  
  # model property renames
  - where:
      model-name: VirtualMachineSize
      property-name: ^NumberOfCore$
    set:
      property-name: NumberOfCores
  - where:
      model-name: VirtualMachineInstanceView
      property-name: ^MaintenanceRedeployStatus(.+)$
    set:
      property-name: $1
  - where:
      model-name: VirtualMachineInstanceView
      property-name: ^VMAgentVmagentVersion$
    set:
      property-name: VMAgentVersion
  - where:
      property-name: AutomaticOSUpgradePropertyAutomaticOsupgradeSupported
    set:
      property-name: AutomaticOsupgradeSupported
  - where:
      model-name: RollingUpgradeStatusInfo
      property-name: ^Policy(.+)$
    set:
      property-name: $1
  - where:
      model-name: RollingUpgradeStatusInfo
      property-name: ^RunningStatusCode$
    set:
      property-name: StatusCode
  - where:
      model-name: RollingUpgradeStatusInfo
      property-name: ^RunningStatus(.+)$
    set:
      property-name: $1
  - where:
      property-name: ^CapacityDefaultCapacity$
    set:
      property-name: DefaultCapacity
  - where:
      property-name: ^Capacity(Default|Maximum|Minimum)$
    set:
      property-name: $1Capacity
  - where:
      property-name: ^RestrictionInfo(Location|Zone)$
    set:
      property-name: $1
  - where:
      model-name: Gallery
      property-name: IdentifierUniqueName
    set:
      property-name: UniqueName
  - where:
      property-name: ^(.+)SizeGb$
    set:
      property-name: $1SizeInGb
  - where:
      property-name: ^SizeGb$
    set:
      property-name: SizeInGb
  - where:
      model-name: .*Disk.*|.*Snapshot.*
      property-name: CreationData(.+)
    set:
      property-name: $1
  - where:
      model-name: .*Disk.*|.*Snapshot.*
      property-name: Disk(.+)
    set:
      property-name: $1
  - where:
      model-name: .*Disk.*|.*Snapshot.*
      property-name: EncryptionSettingCollectionEnabled
    set:
      property-name: EncryptionEnabled
  - where:
      model-name: .*Disk.*|.*Snapshot.*
      property-name: EncryptionSettingCollectionEncryptionSetting
    set:
      property-name: EncryptionSetting

  - where:
      property-name: ErrorInnererror
    set:
      property-name: InnerError
  - where:
      property-name: InnererrorErrorDetail
    set:
      property-name: InnerErrorDetail
  - where:
      property-name: InnererrorExceptionType
    set:
      property-name: InnerErrorExceptionType
  - where:
      property-name: ^(.+)Statu$
    set:
      property-name: $1Status
  - where:
      model-name: GalleryImage
      property-name: RecommendedVCpU
    set:
      property-name: RecommendedVCpu
  - where: 
      model-name: GalleryImage.*
      property-name: Identifier(.+)
    set:
      property-name: $1
  - where: 
      model-name: GalleryImage.*
      property-name: VCpUsMin
    set:
      property-name: MinimumVCpu
  - where: 
      model-name: GalleryImage.*
      property-name: VCpUsMax
    set:
      property-name: MaximumVCpu
  - where: 
      model-name: GalleryImageDefinition
      property-name: MemoryMin
    set:
      property-name: MinimumMemory
  - where: 
      model-name: GalleryImageDefinition
      property-name: MemoryMax
    set:
      property-name: MaximumMemory
  - where:
      model-name: VirtualMachine
      property-name: HardwareProfileVMSize
    set:
      property-name: Size
  - where:
      property-name: AdditionalCapabilityUltraSsdEnabled
    set:
      property-name: UltraSsdEnabled
  - where:
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: IdentityId
  - where:
      property-name: AutomaticOSUpgradePolicyEnableAutomaticOsupgrade
    set:
      property-name: AutomaticOSUpgrade
  - where:
      property-name: RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent
    set:
      property-name: MaxUnhealthyUpgradedInstancePercent
  - where:
      property-name: AutomaticOSUpgradePolicyDisableAutomaticRollback
    set:
      property-name: DisableAutoRollback
  - where:
      property-name: RollingUpgradePolicyMaxBatchInstancePercent
    set:
      property-name: MaxBatchInstancePercent
  - where:
      property-name: RollingUpgradePolicyMaxUnhealthyInstancePercent
    set:
      property-name: MaxUnhealthyInstancePercent
  - where:
      property-name: RollingUpgradePolicyPauseTimeBetweenBatch
    set:
      property-name: PauseTimeBetweenBatches
  - where: 
      model-name: GalleryImageVersion
      property-name: ^PublishingProfile(.*)$
    set:
      property-name: $1
  - where: 
      property-name: GalleryImageName
    set:
      property-name: GalleryImageDefinitionName
  - where:
      model-name: VirtualMachineExtension
      property-name: ExtensionImageName
    set:
      property-name: ImageName
  - where:
      model-name: VirtualMachineExtension
      property-name: PropertiesType
    set:
      property-name: ExtensionType
  - where:
      model-name: VirtualMachineExtension
      property-name: ForceUpdateTag
    set:
      property-name: ForceRerun
  - where:
      model-name: VirtualMachineScaleSetExtension
      property-name: VMScaleSetName
    set:
      property-name: VmssName
  - where:
      model-name: VirtualMachineImage
      property-name: Filter
    set:
      property-name: FilterExpression
  - where:
      model-name: VirtualMachineImage
      property-name: Filter
    set:
      property-name: FilterExpression
  - where:
      model-name: VirtualMachineScaleSetVM
      property-name: VMScaleSetVMReimageInput
    set:
      property-name: VirtualMachineScaleSetVM
  - where:
      model-name: VirtualMachineScaleSetExtension
      property-name: Name
    set:
      property-name: ExtensionName
  # parameter alias not working
  - where:
      verb: Remove
      subject: VmssExtension
      parameter-name: InputObject
    set:
      alias: VirtualMachineScaleSet
  - where:
      verb: Update
      subject: Disk
      parameter-name: Disk
    set:
      alias: DiskUpdate
  - where:
      verb: Update
      subject: Snapshot
      parameter-name: Snapshot
    set:
      alias: SnapshotUpdate
  - where:
      verb: Repair
      subject: VmssServiceFabricUpdateDomain
      parameter-name: InputObject
    set:
      alias: VirtualMachineScaleSet  
  # Rename flattedned parameter names for VMSS
  - where:
      subject: GalleryImageVersion
      parameter-name: ExcludeFromLatest
    set:
      alias: PublishingProfileExcludeFromLatest
  - where:
      subject: GalleryImageVersion
      parameter-name: EndOfLifeDate
    set:
      alias: PublishingProfileEndOfLifeDate
  - where:
      parameter-name: StorageProfile(.+)
    set:
      parameter-name: $1
  - where:
      parameter-name: NetworkProfile(.+)
    set:
      parameter-name: $1
  # Hide cmdlets for customizations
  - where:
      verb: Get
      subject: AvailabilitySetAvailableSize
    hide: true
  - where:
      verb: Get
      subject: VMAvailableSize
    hide: true
  - where:
      verb: Get
      subject: VMExtensionImageVersion
    hide: true
  - where:
      verb: Get
      subject: VmssInstanceView
    hide: true
  - where:
      verb: Get
      subject: VmssOSUpgradeHistory
    hide: true
  - where:
      verb: Get
      subject: VmssVMInstanceView
    hide: true
  - where:
      verb: Invoke
      subject: DeallocateVM
    hide: true
  - where:
      verb: Invoke
      subject: DeallocateVmss
    hide: true
  - where:
      verb: Invoke
      subject: DeallocateVmssVM
    hide: true
  - where:
      verb: Invoke
      subject: PerformVMMaintenance
    hide: true
  - where:
      verb: Invoke
      subject: PerformVmssMaintenance
    hide: true
  - where:
      verb: Invoke
      subject: PerformVmssVMMaintenance
    hide: true
  - where:
      verb: Invoke
      subject: RedeployVmss
    hide: true
  - where:
      verb: Invoke
      subject: RedeployVmssVM
    hide: true
  - where:
      verb: Invoke
      subject: ViewVMInstance
    hide: true
  - where:
      verb: Reset
      subject: VM
    hide: true
  - where:
      verb: Invoke
      subject: VmssReimage
    hide: true

# renaming variants [bug](https://github.com/Azure/autorest.powershell/issues/309)
  - where: 
      verb: Update
      subject: VM
      variant: ^Reimage.*$
    set:
      verb: Invoke
      subject: VMReimage
  - where: 
      verb: Update
      subject: Vmss
      variant: ^Reimage.*$
    set:
      verb: Invoke
      subject: VmssReimage
  - where: 
      verb: Update
      subject: VmssVM
      variant: ^Reimage.*$
    set:
      verb: Invoke
      subject: VmssVMReimage
# changing after variant change
  - where:
      verb: Set
      subject: VmssVM
    set:
      alias: Update-AzVmssVM
# variant remove (flattened body parameters with no piping value)
  - where:
      verb: ConvertTo
      subject: VmssSinglePlacementGroup
      variant: ^Convert\d?$|^ConvertViaIdentity\d?$
    remove: true
  - where:
      verb: Export
      subject: LogAnalytic.*
      variant: ^Export\d?$|^ExportViaIdentity\d?$
    remove: true
  - where:
      verb: Grant
      subject: .+Access
      variant: ^Grant\d?$|^GrantViaIdentity\d?$
    remove: true
  - where:
      verb: Invoke
      subject: .*Command
      variant: ^Run\d?$|^RunViaIdentity\d?$
    remove: true
  - where:
      verb: Remove
      subject: VmssInstance
      variant: ^Delete\d?$|^DeleteViaIdentity\d?$
    remove: true
  - where:
      verb: Restart
      subject: Vmss
      variant: ^Restart\d?$|^RestartViaIdentity\d?$
    remove: true
  - where:
      verb: Start
      subject: Vmss
      variant: ^Start\d?$|^StartViaIdentity\d?$
    remove: true
  - where:
      verb: Stop
      subject: Vmss
      variant: ^PowerOff\d?$|^PowerOffViaIdentity\d?$
    remove: true
# Set correct variants for PUT and PATCH verbs
  - where:
      verb: New
      variant: ^CreateViaIdentityExpanded\d?$|^CreateViaIdentity\d?$
    remove: true
  - where:
      verb: Set
      variant: ^Update\d?$|^UpdateViaIdentity\d?$
    remove: true
  - where:
      verb: Update
      variant: ^Update\d?$|^UpdateViaIdentity\d?$
    remove: true
# Remove variants for hidden cmdlets
  - where:
      verb: Invoke
      subject: DeallocateVmss
      variant: ^Deallocate\d?$|^DeallocateViaIdentity\d?$
    remove: true
  - where:
      verb: Invoke
      subject: PerformVmssMaintenance
      variant: ^Perform\d?$|^PerformViaIdentity\d?$
    remove: true
  - where:
      verb: Invoke
      subject: PerformVMMaintenance
      variant: ^Perform\d?$|^PerformViaIdentity\d?$
    remove: true
  - where:
      verb: Invoke
      subject: RedeployVmss
      variant: ^Redeploy\d?$|^RedeployViaIdentity\d?$
    remove: true
  - where:
      verb: Invoke
      subject: .*Reimage
      variant: ^Reimage\d?$|^ReimageViaIdentity\d?$
    remove: true
  - where:
      verb: Save
      subject: VMImage
      variant: ^Capture\d?$|^CaptureViaIdentity\d?$
    remove: true
```
