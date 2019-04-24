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

## Version 0.3.2
* Module dependencies updated
    * AzureRM.Resources module updated to 6.4.3

## Version 0.3.1
* Module dependencies updated
    * AzureRM.Resources module updated to 6.0.3

## Version 0.3.1
* Added missing Azs prefix for New-AddonPlanDefinitionObject and created alias.  The cmdlet will be deprecated in a future release.

## Version 0.3.0
* Module dependencies updated
	* AzureRM.Profile
	* AzureRM.Resources
* Support handling names of nested resources
	* Get-AzsUpdate
	* Get-UpdateRun
	* Install-AzsUpdate
	* Resume-AzsUpdate
* Deprecations
	* Get-AzsBackup, the parameter Update is now an alias for Name
* Bug fixes
	* Handle ErrrorAction correctly now
