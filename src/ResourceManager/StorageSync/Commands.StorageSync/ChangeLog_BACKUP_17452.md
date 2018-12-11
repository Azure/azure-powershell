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
* Fixed a typo in the progress message.
<<<<<<< HEAD

## Version 0.1.2
* Updated list of unsupported file name characters.

## Version 0.1.2
* Update all cmdlets required to manager StorageSync ARM resources.

## Version 0.1.1
* Updated to the latest version of the Azure ClientRuntime.

## Version 0.1.0
* Add Azure File Sync evaluation cmdlet
    - Invoke-AzureRmStorageSyncCompatibilityCheck

=======
* Introduced the following breaking changes in Invoke-AzureRmStorageSyncCompatibilityCheck cmdlet:
    - Parameter 'Quiet' had been removed.
    - Return type has changed from list of PSValidationResult to PSStorageSyncValidation. Validation results are now stored in PSStorageSyncValidation.Results member.
>>>>>>> a0fa6ac1b3130536628ae5c0ed8870f9f7a9eb63
