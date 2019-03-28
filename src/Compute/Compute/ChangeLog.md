
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
