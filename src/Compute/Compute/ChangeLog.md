
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
* Fixed miscellaneous typos across module

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
