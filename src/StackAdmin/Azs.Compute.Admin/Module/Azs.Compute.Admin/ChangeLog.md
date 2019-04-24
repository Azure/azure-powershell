<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 0.2.3
* Module dependencies updated
    * AzureRM.Resources module updated to 6.4.3

## Version 0.2.2
BugFix: Add-AzsPlatformImage, Get-AzsPlatformImage : Calling ConvertTo-PlatformImageObject only in the success path
BugFix: Add-AzsVmExtension, Get-AzsVmExtension : Calling ConvertTo-VmExtensionObject only in the success path

## Version 0.2.1
* Added missing Azs prefix for New-DataDiskObject and created alias.  The cmdlet will be deprecated in a future release.

## Version 0.2.0
* New Module dependencies
	* AzureRM.Profile
	* AzureRM.Resources
* New Quota properties for managed disks
	* StandardManagedDiskAndSnapshotSize
	* PremiumManagedDiskAndSnapshotSize
* Support handling names of nested resources
	* Get-AzsQuota and Set-AzsQuota now handles the Name property correctly
* Additional properties to objects
	* Platform Images - Publisher, Offer, Sku, Version
	* VM Extensions - Publisher, ExtensionType, TypeHandlerVersion
* Bug fixes
	* Handle ErrorAction correctly now
