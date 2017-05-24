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

## Version 3.0.0
* Adding backup/restore support for KeyVault secrets
    - Secrets can be backed up and restored, matching the functionality currently supported for Keys

* Backup cmdlets for Keys and Secrets now accept a corresponding object as an input parameter
    - The caller may chain retrieval and backup operations: Get-AzureKeyVaultKey -VaultName myVault -Name myKey | Backup-AzureKeyVaultKey
    
* Backup cmdlets now support a -Force switch to overwrite an existing file
    - Note that attempting to overwrite an existing file will no longer throw, and will instead prompt the user for a choice on how to proceed.
      
## Version 2.8.0

## Version 2.7.0

## Version 2.6.0

## Version 2.5.0

## Version 2.4.0

## Version 2.3.0