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
	* Get-AzsBackup
	* Restore-AzsBackup
	* Start-AzsBackup
* Deprecations
	* Set-AzsBackupShare is an alias now to the cmdlet Set-AzsBackupConfiguration
	* Get-AzsBackupLocation is an alias now to the cmdlet Get-AzsBackupConfiguration
	* Set-AzsBackupConfiguration, the parameter BackupShare is an alias now for the parameter path
* Bug fixes
	* Handle ErrrorAction correctly now
