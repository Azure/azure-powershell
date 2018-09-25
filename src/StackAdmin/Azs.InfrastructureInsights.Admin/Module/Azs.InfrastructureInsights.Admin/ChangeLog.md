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

## Version 0.2.0
* Module dependencies updated
	* AzureRM.Profile
	* AzureRM.Resources
* Support handling names of nested resources
	* Get-AzsAlert
	* Close-AzsAlert
	* Get-AzsRegistrationHealth
	* Get-AzsRPHealth
* Deprecations
	* Get-AzsRegistrationHealth, the parameter ResourceHealthId is now an alias for Name
	* Get-AzsRegistrationHealth, the parameter ServiceRegistrationId is now an alias for ServiceRegistrationName
	* Get-AzsRPHealth, the parameter ServiceHealth is now an alias for Name
* Bug fixes
	* Handle ErrrorAction correctly now
