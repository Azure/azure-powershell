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

## Version 0.3.0
* Support new storage sdk version 2019-08-08-preview

## Version 0.2.3
* Module dependencies updated
    * AzureRM.Resources module updated to 6.4.3

## Version 0.2.2
* Module dependencies updated
    * AzureRM.Resources module updated to 6.0.3

## Version 0.2.1
* Bug fix
    * New-AzureRmStorageQuota was not using default values

## Version 0.2.0
* Module dependencies updated
	* AzureRM.Profile
	* AzureRM.Resources
* Support handling names of nested resources
	* Get-AzsStorageAccount
	* Get-AzsStorageContainer
	* Get-AzsStorageDestinationShare
	* Get-AzsStorageQuota
	* Get-AzsStorageShare
	* Get-AzsStorageShareMetric
	* Get-AzsStorageShareMetricDefinition
	* Remove-AzsStorageQuota
	* Restore-AzsStorageAccount
	* Set-AzsStorageQuota
	* Start-AzsStorageContainerMigration
* Deprecations
	* Get-AzsStorageShare, the parameter ShareName is now an alias for Name
	* Get-AzsStorageShareMetric, the parameter ShareName is now an alias for Name
	* Get-AzsStorageShareMetricDefinition, the parameter ShareName is now an alias for Name
	* Start-AzsReclaimStorageCapacity, the parameter FarmName is now an alias for Name
	* Start-AzsStorageContainerMigration, the parameter ContainerName is now an alias for Name
* Bug fixes
	* Handle ErrrorAction correctly now
