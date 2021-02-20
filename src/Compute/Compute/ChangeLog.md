
<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1

-->
## Upcoming Release

## Version 4.9.0
* Added parameter `-EnableAutomaticUpgrade` to `Set-AzVmExtension` and `Add-AzVmssExtension`.
* Removed FilterExpression parameter from `Get-AzVMImage` cmdlet documentation. 
* Added deprecation message to the ContainerService cmdlets:
    - `Add-AzureRmContainerServiceAgentPoolProfileCommand`
    - `Get-AzContainerService`
    - `New-AzContainerService`
    - `New-AzContainerServiceConfig`
    - `Remove-AzContainerService`
    - `Remove-AzContainerServiceAgentPoolProfile`
    - `Update-AzContainerService`
* Added parameter `-BurstingEnabled` to `New-AzDiskConfig` and `New-AzDiskUpdateConfig`
* Added `-GroupByApplicationId` and `-GroupByUserAgent` parameters to the `Export-AzLogAnalyticThrottledRequest` and `Export-AzLogAnalyticRequestRateByInterval` cmdlets.
* Added `VMParameterSet` parameter set to `Get-AzVMExtension` cmdlet. Added new parameter `-VM` to this parameter set. 

## Version 4.8.0
* New parameter `VM` in new parameter set `VMParameterSet` added to `Get-AzVMDscExtensionStatus` and `Get-AzVMDscExtension` cmdlets. 
* Edited `New-AzSnapshot` cmdlet to check for existing snapshot with the same name in the same resource group. 
    - Throws an error if a duplicate snapshot exists. 

## Version 4.7.0
* Edited Get-AzVm to filter by `-Name` prior to checking for throttling due to too many resources. 
* New cmdlet `Start-AzVmssRollingExtensionUpgrade`.
## Version 4.6.0
* Added `-VmssId` parameter to `New-AzVm`
* Added `PlatformFaultDomainCount` parameter to the `New-AzVmss` cmdlet.
* New cmdlet `Get-AzDiskEncryptionSetAssociatedResource`
* Added `Tier` and `LogicalSectorSize` optional parameters to the New-AzDiskConfig cmdlet. 
* Added `Tier`, `MaxSharesCount`, `DiskIOPSReadOnly`, and `DiskMBpsReadOnly` optional parameters to the `New-AzDiskUpdateConfig` cmdlet. 
* Modified `Get-AzVmBootDiagnostics` cmdlet to use the new RetrieveBootDiagnosticsData API instead of directly accessing the BootDiagnostics properties on the virtual machine.  

## Version 4.5.0
* Fixed issue in `Update-ASRRecoveryPlan` by populating FailoverTypes
* Added the `-Top` and `-OrderBy` optional parameters to the `Get-AzVmImage` cmdlet. 

## Version 4.4.0
* Added the `-EncryptionType` optional parameter to `New-AzVmDiskEncryptionSetConfig`
* New cmdlets for new resource type: DiskAccess `Get-AzDiskAccess`, `New-AzDiskAccess`, `Get-AzDiskAccess`
* Added optional parameters `-DiskAccessId` and `-NetworkAccessPolicy` to `New-AzSnapshotConfig`
* Added optional parameters `-DiskAccessId` and `-NetworkAccessPolicy` to `New-AzDiskConfig`
* Added `PatchStatus` property to VirtualMachine Instance View
* Added `VMHealth` property to the virtual machine's instance view, which is the returned object when `Get-AzVm` is invoked with `-Status`
* Added `AssignedHost` field to `Get-AzVM` and `Get-AzVmss` instance views. The field shows the resource id of the virtual machine instance
* Added optional parameter `-SupportAutomaticPlacement` to `New-AzHostGroup` 
* Added the `-HostGroupId` parameter to `New-AzVm` and `New-AzVmss`

## Version 4.3.1
* Patched `-EncryptionAtHost` parameter in `New-AzVm` to remove default value of false [#12776]

## Version 4.3.0
* Added `-EncryptionAtHost` parameter to `New-AzVm`, `New-AzVmss`, `New-AzVMConfig`, `New-AzVmssConfig`, `Update-AzVM`, and `Update-AzVmss`
* Added `SecurityProfile` to `Get-AzVM` and `Get-AzVmss` return object
* Added `-InstanceView` switch as optional parameter to `Get-AzHostGroup`
* Added new cmdlet `Invoke-AzVmPatchAssessment`

## Version 4.2.1
* Added warning when using `New-AzVmss` without "latest" image version
* Added '-Location' as optional positional parameter to Get-AzComputeResourceSku cmdlet

## Version 4.2.0
* Added SimulateEviction parameter to Set-AzVM and Set-AzVmssVM cmdlets.
* Added 'Premium_LRS' to the argument completer of StorageAccountType parameter for New-AzGalleryImageVersion cmdlet.
* Added Substatuses to VMCustomScriptExtension [#11297]
* Added 'Delete' to the argument completer of EvictionPolicy parameter for New-AzVM and New-AzVMConfig cmdlets.
* Fixed name of new VM Extension for SAP

## Version 4.1.0
* Added HostId parameter to `Update-AzVM` cmdlet
* Updated Help documents for `New-AzVMConfig`, `New-AzVmssConfig`, `Update-AzVmss`, `Set-AzVMOperatingSystem` and `Set-AzVmssOsProfile` cmdlets.
* Breaking changes
    - FilterExpression parameter is removed from `Get-AzVMImage` cmdlet.
    - AssignIdentity parameter is removed from `New-AzVmssConfig`, `New-AzVMConfig` and `Update-AzVM` cmdlets.
    - AutomaticRepairMaxInstanceRepairsPercent is removed from `New-AzVmssConfig` and `Update-AzVmss` cmdlets.
    - AvailabilitySetsColocationStatus, VirtualMachinesColocationStatus and VirtualMachineScaleSetsColocationStatus properties are removed from ProximityPlacementGroup.
    - MaxInstanceRepairsPercent property is removed from AutomaticRepairsPolicy.
    - The types of AvailabilitySets, VirtualMachines and VirtualMachineScaleSets are changed from IList<SubResource> to IList<SubResourceWithColocationStatus>.
* Description for `Get-AzVM` cmdlet has been updated to better describe it. 

## Version 3.7.0
* Added `Set-AzVmssOrchestrationServiceState` cmdlet.
* `Get-AzVmss` with -InstanceView shows OrchestrationService states.

## Version 3.6.0
* Added the following parameters to `New-AzDiskConfig` cmdlet: 
    - DiskIOPSReadOnly, DiskMBpsReadOnly, MaxSharesCount, GalleryImageReference
* Allowed Encryption property to Target parameter of `New-AzGalleryImageVersion` cmdlet.
* Fixed tempDisk issue for `Set-AzVmss` -Reimage and `Invoke-AzVMReimage` cmdlets. [#11354]
* Added support to below cmdlets for new SAP Extension
    - `Set-AzVMAEMExtension`
    - `Get-AzVMAEMExtension`
    - `Remove-AzVMAEMExtension`
    - `Update-AzVMAEMExtension`
* Fixed errors in examples of help document
* Showed the exact string value for VM PowerState in the table format.
* `New-AzVmssConfig`: fixed serialization of AutomaticRepairs property when SinglePlacementGroup is disabled. [#11257]

## Version 3.5.0
* Allowed empty value for ProximityPlacementGroupId during update

## Version 3.4.0
* Limit the number of VM status to 100 to avoid throttling when Get-AzVM -Status is performed without VM name.
* Add Update-AzDiskEncryptionSet cmdlet
* Add EncryptionType and DiskEncryptionSetId parameters to the following cmdlets:
    - New-AzDiskUpdateConfig, New-AzSnapshotUpdateConfig
* Add ColocationStatus parameter to Get-AzProximityPlacementGroup cmdlet.
* Fix broken example code for 'Revoke-AzSnapshotAccess' and 'Grant-AzSnapshotAccess'
* Fix broken example code for 'Set-AzDiskDiskEncryptionKey' and 'Set-AzDiskKeyEncryptionKey'

## Version 3.3.0
* Fix Set-AzVMCustomScriptExtension cmdlet for a VM with managed OD disk which does not have OS profile.
* Updated the example of `Set-AzVMAccessExtension` to use version 2.4 instead of 2.0

## Version 3.2.0
* Add ProximityPlacementGroupId parameter to the following cmdlets:
    - Update-AzAvailabilitySet, Update-AzVM, Update-AzVmss
* Change ProximityPlacementGroup parameter to ProximityPlacementGroupId parameter in New-AzVM and New-AzVmss.
  (ProximityPlacementGroup parameter is still supported as an alias)
* Update help message for VM and VMSS priority.
* Update references in .psd1 to use relative path

## Version 3.1.0
* VM Reapply feature
    - Add Reapply parameter to Set-AzVM cmdlet
* VM Scale Set AutomaticRepairs feature:
    - Add EnableAutomaticRepair, AutomaticRepairGracePeriod, and AutomaticRepairMaxInstanceRepairsPercent parameters to the following cmdlets:
        New-AzVmssConfig
        Update-AzVmss
* Cross tenant gallery image support for New-AzVM
* Add 'Spot' to the argument completer of Priority parameter in New-AzVM, New-AzVMConfig and New-AzVmss cmdlets
* Add DiskIOPSReadWrite and DiskMBpsReadWrite parameters to Add-AzVmssDataDisk cmdlet
* Change SourceImageId parameter of New-AzGalleryImageVersion cmdlet to optional
* Add OSDiskImage and DataDiskImage parameters to New-AzGalleryImageVersion cmdlet
* Add HyperVGeneration parameter to New-AzGalleryImageDefinition cmdlet
* Add SkipExtensionsOnOverprovisionedVMs parameters to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets

## Version 3.0.0
* Disk Encryption Set feature
    - New cmdlets:
        New-AzDiskEncryptionSetConfig
        New-AzDiskEncryptionSet
        Get-AzDiskEncryptionSet
        Remove-AzDiskEncryptionSet
    - DiskEncryptionSetId parameter is added to the following cmdlets:
        Set-AzImageOSDisk
        Set-AzVMOSDisk
        Set-AzVmssStorageProfile        
        Add-AzImageDataDisk
        New-AzVMDataDisk
        Set-AzVMDataDisk
        Add-AzVMDataDisk
        Add-AzVmssDataDisk
        Add-AzVmssVMDataDisk
    - DiskEncryptionSetId and EncryptionType parameters are added to the following cmdlets:
        New-AzDiskConfig
        New-AzSnapshotConfig
* Add PublicIPAddressVersion parameter to New-AzVmssIPConfig
* Move FileUris of custom script extension from public setting to protected setting
* Add ScaleInPolicy to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets
* Breaking changes
    - UploadSizeInBytes parameter is used instead of DiskSizeGB for New-AzDiskConfig when CreateOption is Upload
    - PublishingProfile.Source.ManagedImage.Id is replaced with StorageProfile.Source.Id in GalleryImageVersion object

## Version 2.7.0
* Add Priority, EvictionPolicy, and MaxPrice parameters to New-AzVM and New-AzVmss cmdlets
* Fix warning message and help document for Add-AzVMAdditionalUnattendContent and Add-AzVMSshPublicKey cmdlets
* Fix -skipVmBackup exception for Linux VMs with managed disks for Set-AzVMDiskEncryptionExtension. 
* Fix bug in update encryption settings in Set-AzVMDiskEncryptionExtension, two pass scenario.

## Version 2.6.0
* Add UploadSizeInBytes parameter tp New-AzDiskConfig
* Add Incremental parameter to New-AzSnapshotConfig
* Add a low priority virtual machine feature:
    - MaxPrice, EvictionPolicy and Priority parameters are added to New-AzVMConfig.
    - MaxPrice parameter is added to New-AzVmssConfig, Update-AzVM and Update-AzVmss cmdlets.
* Fix VM reference issue for Get-AzAvailabilitySet cmdlet when it lists all availability sets in the subscription.
* Fix the null exception for Get-AzRemoteDesktopFile.
* Fix VHD Seek method for end-relative position.
* Fix UltraSSD issue for New-AzVM and Update-AzVM.
* Fix code to allow non default extension publisher, type and name for Get-AzVMDiskEncryptionStatus

## Version 2.5.0
* Add VmssId to New-AzVMConfig cmdlet
* Add TerminateScheduledEvents and TerminateScheduledEventNotBeforeTimeoutInMinutes parameters to New-AzVmssConfig and Update-AzVmss
* Add HyperVGeneration property to VM image object
* Add Host and HostGroup features
    - New cmdlets:
        New-AzHostGroup
        New-AzHost
        Get-AzHostGroup
        Get-AzHost
        Remove-AzHostGroup
        Remove-AzHost
    - HostId parameter is added to New-AzVMConfig and New-AzVM
* Fixed miscellaneous typos across module
* Update example in `Invoke-AzVMRunCommand` documentation to use correct parameter name
* Update `-VolumeType` description in `Set-AzVMDiskEncryptionExtension` and `Set-AzVmssDiskEncryptionExtension` reference documentation

## Version 2.4.1
* Add missing properties (ComputerName, OsName, OsVersion and HyperVGeneration) of VM instance view object.

## Version 2.4.0
* Add HyperVGeneration parameter to New-AzImageConfig
* Use the extension type instead of the name when disabling vmss disk encryption

## Version 2.3.0
* New-AzVm and New-AzVmss simple parameter sets now accept the `ProximityPlacementGroup` parameter.
* Fix typo in `New-AzVM` reference documentation

## Version 2.2.0
* Added `NoWait` parameter that starts the operation and returns immediately, before the operation is completed.
    - Updated cmdlets:
        Export-AzLogAnalyticRequestRateByInterval
        Export-AzLogAnalyticThrottledRequest
        Remove-AzVM
        Remove-AzVMAccessExtension
        Remove-AzVMAEMExtension
        Remove-AzVMChefExtension
        Remove-AzVMCustomScriptExtension
        Remove-AzVMDiagnosticsExtension
        Remove-AzVMDiskEncryptionExtension
        Remove-AzVMDscExtension
        Remove-AzVMSqlServerExtension
        Restart-AzVM
        Set-AzVM
        Set-AzVMAccessExtension
        Set-AzVMADDomainExtension
        Set-AzVMAEMExtension
        Set-AzVMBginfoExtension
        Set-AzVMChefExtension
        Set-AzVMCustomScriptExtension
        Set-AzVMDiagnosticsExtension
        Set-AzVMDscExtension
        Set-AzVMExtension
        Start-AzVM
        Stop-AzVM
        Update-AzVM

## Version 2.1.0
* Add ProtectFromScaleIn and ProtectFromScaleSetAction parameters to Update-AzVmssVM cmdlet.
* New-AzVM simple parameter set now uses by default an available location if 'East US' is not supported

## Version 2.0.0
* Proximity placement group feature.
    - The following new cmdlets are added:
        New-AzProximityPlacementGroup
        Get-AzProximityPlacementGroup
        Remove-AzProximityPlacementGroup
    - The new parameter, ProximityPlacementGroupId, is added to the following cmdlets:
        New-AzAvailabilitySet
        New-AzVMConfig
        New-AzVmssConfig
* StorageAccountType parameter is added to New-AzGalleryImageVersion.
* TargetRegion of New-AzGalleryImageVersion can contain StorageAccountType.
* SkipShutdown switch parameter is added to Stop-AzVM and Stop-AzVmss
* Breaking changes
    - Set-AzVMBootDiagnostics is changed to Set-AzVMBootDiagnostic.
    - Export-AzLogAnalyticThrottledRequests is changed to Export-AzLogAnalyticThrottledRequests.

## Version 1.8.0
* Fix issue with AEM installation if resource ids of disks had lowercase resourcegroups in resource id
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

## Version 1.7.0
* Add HyperVGeneration parameter to New-AzDiskConfig and New-AzSnapshotConfig
* Allow VM creation with galley image from other tenants. 

## Version 1.6.0
* Fix issue with path resolution in Get-AzVmBootDiagnosticsData
* Update Compute client library to 25.0.0.
* Add new parameter sets to Set-AzVMCustomScriptExtension
    - Accepts PSVirtualMachine object from pipeline
    - Accepts Resource Id and a VirtualMachineCustomScriptExtensionContext also from pipeline

## Version 1.5.0
* Add wildcard support to Get cmdlets

## Version 1.4.0
* Fix issue with ID parameter sets
* Update Get-AzVMExtension to list all installed extension if Name parameter is not provided
* Add Tag and ResourceId parameters to Update-AzImage cmdlet
* Get-AzVmssVM without instance ID and with InstanceView can list VMSS VMs with instance view.

## Version 1.3.0
* AEM extension: Add support for UltraSSD and P60,P70 and P80 disks
* Update help description for Set-AzVMBootDiagnostics
* Update help description and example for Update-AzImage

## Version 1.2.0
* Add Invoke-AzVMReimage cmdlet
* Add TempDisk parameter to Set-AzVmss
* Fix the warning message of New-AzVM
* Add ProvisionAfterExtension parameter to Add-AzVmssExtension

## Version 1.1.0
* Name is now optional in ID parameter set for Restart/Start/Stop/Remove/Set-AzVM and Save-AzVMImage
* Updated the description of ID in help files
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0
* General availability of `Az.Compute` module
* Breaking changes
    - IdentityIds are removed from Identity property in PSVirtualMachine and PSVirtualMachineScaleSet object.
    - The type of InstanceView property of PSVirtualMachineScaleSetVM object is changed from VirtualMachineInstanceView to VirtualMachineScaleSetVMInstanceView.
    - AutoOSUpgradePolicy and AutomaticOSUpgrade properties are removed from UpgradePolicy property.
    - The type of Sku property in PSSnapshotUpdate object is changed from DiskSku to SnapshotSku.
    - VmScaleSetVMParameterSet is removed from Add-AzVMDataDisk.
