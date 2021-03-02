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

## Version 5.2.2
* This module is outdated and will go out of support on 29 February 2024.
* The Az.KeyVault module has all the capabilities of AzureRM.KeyVault and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.2.1
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.2.0
* Fixed issue with default resource groups not being set.

## Version 5.1.1
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.1.0-preview
* Adding support for listing certificates in a pending state

## Version 5.1.0
* Fix piping issue in Set-AzureRmKeyVaultAccessPolicy
* Updated help files to include full parameter types and correct input/output types.

## Version 5.0.4
* Update error message for Set-AzureRmKeyVaultAccessPolicy

## Version 5.0.3
* Fixed formatting of OutputType in help files
* Fix issue where all resources were being returned by Get-AzureRmKeyVault -Tag

## Version 5.0.2
* Fix issue where no Tags are being returned when Get-AzureRmKeyVault -Tag is run

## Version 5.0.1
* Update documentation with example output

## Version 5.0.0
* Breaking changes to support piping scenarios
* Added new cmdlets: Backup/Restore-AzureKeyVaultManagedStorageAccount, Backup/Restore-AzureKeyVaultCertificate, Undo-AzureKeyVaultManagedStorageSasDefinitionRemoval, and Undo-AzureKeyVaultManagedStorageAccountRemoval
* Set minimum dependency of module to PowerShell 5.0

## Version 4.4.0-preview
* Updated cmdlets to include piping scenarios
* Added new cmdlets around NewtorkRules: Add/Remove/Update-AzureKeyVaultNetworkRule
* Added new cmdlets: Backup/Restore-AzureKeyVaultManagedStorageAccount, Backup/Restore-AzureKeyVaultCertificate, Undo-AzureKeyVaultManagedStorageSasDefinitionRemoval, and Undo-AzureKeyVaultManagedStorageAccountRemoval

## Version 4.3.0
* Updated cmdlets to include piping scenarios
* Add deprecation messages for upcoming breaking change release
* Updated to the latest version of the Azure ClientRuntime

## Version 4.2.1
* Fix issue with Default Resource Group in CloudShell

## Version 4.2.0
* Fixed example for Set-AzureRmKeyVaultAccessPolicy

## Version 4.1.1
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

## Version 4.1.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running KeyVault cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
    * Affected cmdlet is: Remove-AzureRmKeyVault
* Fixed bug in Set-AzureRmKeyVaultAccessPolicy where the AAD filter was setting SPN to the provided UPN, rather than setting the UPN
   - See the following issue for more information: https://github.com/Azure/azure-powershell/issues/5201

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1
* Deprecating the PurgeDisabled flag from Key, Secret and Certificate attributes, respectively.
  * The flag is being superseded by the RecoveryLevel attribute.

## Version 3.4.0
* New/updated Cmdlets to support soft-delete for KeyVault certificates
  * Get-AzureKeyVaultCertificate
  * Remove-AzureKeyVaultCertificate
  * Undo-AzureKeyVaultCertificateRemoval

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0
* Remove email address from the directory query when -UserPrincipalName is specified to the Set-AzureRMKeyVaultAccessPolicy and Remove-AzureRMKeyVaultAccessPolicy cmdlets.
  - Both Cmdlets now have an -EmailAddress parameter that can be used instead of the -UserPrincipalName parameter when querying for email address is appropriate.  If there are more than one matching email addresses in the directory then the Cmdlet will fail.

## Version 3.1.0
* New Cmdlets to support KeyVault Managed Storage Account Keys
  * Get-AzureKeyVaultManagedStorageAccount
  * Add-AzureKeyVaultManagedStorageAccount
  * Remove-AzureKeyVaultManagedStorageAccount
  * Update-AzureKeyVaultManagedStorageAccount
  * Update-AzureKeyVaultManagedStorageAccountKey
  * Get-AzureKeyVaultManagedStorageSasDefinition
  * Set-AzureKeyVaultManagedStorageSasDefinition
  * Remove-AzureKeyVaultManagedStorageSasDefinition

## Version 3.0.1

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
