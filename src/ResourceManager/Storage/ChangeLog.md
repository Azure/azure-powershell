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

## Version 4.2.2
* Fix examples to reflect required lowercase syntax in StorageAccountName
* Fix issue with Default Resource Group in CloudShell

## Version 4.2.1
* Obsolete following parameters in new and set Storage Account cmdlets: EnableEncryptionService and DisableEncryptionService, since Encryption at Rest is enabled by default and can't be disabled.
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount

## Version 4.2.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Fix a null reference issue of run cmdlet New-AzureRMStorageAccount with parameter -EnableEncryptionService None
* Added -AsJob support for long-running Storage cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
    - Affected cmdlets are New-, Remove-, Add-, and Update- for Storage Account and Storage Account Network Rule.

## Version 4.1.0
* Upgrade SRP SDK to 7.1.0
* Add StorageV2 account kind to resource mode storage account cmdlets
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 3.4.1

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0
* Add NeworkRule support to resource mode storage account cmdlets
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
    - Get-AzureRmStorageAccountNetworkRuleSet
    - Update-AzureRmStorageAccountNetworkRuleSet
    - Add-AzureRmStorageAccountNetworkRule
    - Remove-AzureRmStorageAccountNetworkRule

## Version 3.2.1

## Version 3.2.0

## Version 3.1.0
* Add AssignIdentity setting support to resource mode storage account cmdlets
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
* Add Customer Key Support to resource mode storage account cmdlets
    - Set-AzureRmStorageAccount
    - New-AzureRmStorageAccountEncryptionKeySource

## Version 3.0.2

## Version 3.0.0
* Upgrade SRP SDK to 6.3.0
* New/Set-AzureRmStorageAccount:Add a new parameter to support EnableHttpsTrafficOnly
* New/Set/Get-AzureRmStorageAccount: Returned Storage Account contains a new attribute EnableHttpsTrafficOnly

## Version 2.8.0

## Version 2.7.0

## Version 2.6.0
* Upgrade Microsoft.Azure.Management.Storage to version 6.1.0-preview
* Add File Encryption features support to resource mode storage account cmdlets
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount


## Version 2.5.0

## Version 2.4.0

## Version 2.3.0
