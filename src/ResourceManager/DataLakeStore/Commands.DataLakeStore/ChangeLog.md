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

## Version 6.2.2
* This module is outdated and will go out of support on 29 February 2024.
* The Az.DataLakeStore module has all the capabilities of AzureRM.DataLakeStore and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 6.2.1
* Update the DataLake package to 1.1.10.
* Add default Concurrency to multithreaded operations.

## Version 6.2.0
* Adding support for Virtual Network Rules
    - Get-AzureRmDataLakeStoreVirtualNetworkRule: Gets or Lists Azure Data Lake Store virtual network rule.
    - Add-AzureRmDataLakeStoreVirtualNetworkRule: Adds a virtual network rule to the specified Data Lake Store account.
    - Set-AzureRmDataLakeStoreVirtualNetworkRule: Modifies the specified virtual network rule in the specified Data Lake Store account.
    - Remove-AzureRmDataLakeStoreVirtualNetworkRule: Deletes an Azure Data Lake Store virtual network rule.

## Version 6.1.2
* Fix debugging when DebugPreference is set from powershell command line
* Update example for Set-AzureRmDataLakeStoreItemAcl
* Updated to the latest version of the Azure ClientRuntime.
* Update example for Set-AzureRmDataLakeStoreItemAclEntry

## Version 6.1.1
* Updated all help files to include full parameter types and correct input/output types.
* Updated the DataPlane SDK (Microsoft.Azure.DataLake.Store) version to 1.1.9

## Version 6.1.0
* Add cancellation support and progress tracking for Set-AzureRmDataLakeStoreItemAclEntry, Remove-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl
* Add cancellation support for Export-AzureRmDataLakeStoreChildItemProperties
* Fix flushing of debug messages for cmdlets that does recursive operations
* Fix location of test of DataLake cmdlets
* Fixed formatting of OutputType in help files

## Version 6.0.1
* Fix example for Export-AzureRmDataLakeStoreChildItemProperties
* Fix null parameter exception for Recurse case in Set-AzureRmDataLakeStoreItemAclEntry
* Fix the help files for Set-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl, Remove-AzureRmDataLakeStoreItemAclEntry

## Version 6.0.0
* Add new feature of recursive Acl Change to Remove-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl
* Add new cmdlet for retrieving the content summary under a directory
* Add new cmdlet for retrieving the disk usage and Acl dump
* Set minimum dependency of module to PowerShell 5.0
* Correct return type of Set-AzureRmDataLakeStoreItemAcl bool to IEnumerable<DataLakeStoreItemAce>
* Correct return type of Set-AzureRmDataLakeStoreItemAclEntry bool to IEnumerable<DataLakeStoreItemAce>
* Breaking changes in Export-AzureRmDataLakeStoreItem, Import-AzureRmDataLakeStoreItem, Remove-AzureRmDataLakeStoreItem

## Version 5.2.0
* Updated to the latest version of the Azure ClientRuntime
* Add debug functionality
* Update the version of the ADLS dataplane SDK to 1.1.2
* Export-AzureRmDataLakeStoreItem (https://github.com/Azure/azure-powershell/blob/adls-data-plane/src/ResourceManager/DataLakeStore/documentation/upcoming-breaking-changes.md) - Deprecated parameters PerFileThreadCount, ConcurrentFileCount and introduced parameter Concurrency
* Import-AzureRMDataLakeStoreItem (https://github.com/Azure/azure-powershell/blob/adls-data-plane/src/ResourceManager/DataLakeStore/documentation/upcoming-breaking-changes.md) -Deprecated parametersPerFileThreadCount, ConcurrentFileCount and introduced parameter Concurrency
* Get-AzureRMDataLakeStoreItemContent - Fixed the tail behavior for contents greater than 4MB
* Set-AzureRMDataLakeStoreItemExpiry - Introduced new parameter set SetRelativeExpiry for setting relative expiration time
* Remove-AzureRmDataLakeStoreItem (https://github.com/Azure/azure-powershell/blob/adls-data-plane/src/ResourceManager/DataLakeStore/documentation/upcoming-breaking-changes.md) - Deprecated parameter Clean.

## Version 5.1.1
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'
* Corrected the error message of 'Test-AzureRmDataLakeStoreAccount' when running this cmdlet without having logged in with 'Login-AzureRmAccount'

## Version 5.1.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataLakeStoreAccount and Set-AzureRmDataLakeStoreAccount

## Version 5.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Removed the Obsolete Properties fields in PSDataLakeStoreAccount.cs and its assoicated files
* Changed one of the two OutputTypes of Get-AzureRmDataLakeStoreAccount
    - List\<PSDataLakeStoreAccount> to List\<PSDataLakeStoreAccountBasic>
    - The properties of PSDataLakeStoreAccountBasic is a strict subset of the properties of PSDataLakeStoreAccount
    - The additional properties that are in PSDataLakeStoreAccount are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSDataLakeStoreAccountBasic, but they are tagged as Obsolete.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 4.4.1

## Version 4.4.0

## Version 4.3.1

## Version 4.3.0
* Fix for issue: https://github.com/Azure/azure-powershell/issues/4323

## Version 4.2.1

## Version 4.2.0
* Added support for user managed KeyVault key rotations in the Set-AzureRMDataLakeStoreAccount cmdlet
* Added a quality of life update to automatically trigger an `enableKeyVault` call when a user managed KeyVault is added or a key is rotated.
* Updated the token audience for job and catalog APIs to use the correct Data Lake specific audience instead of the Azure Resource audience.
* Fixed a bug limiting the size of files created/appended using the following cmdlets:
    - New-AzureRmDataLakeStoreItem
    - Add-AzureRmDataLakeStoreItemContent

## Version 4.1.0
* Enable-AzureRmDataLakeStoreKeyVault (Enable-AdlStoreKeyVault)
  * Enable KeyVault managed encryption for a DataLake Store

## Version 4.0.1

## Version 4.0.0
* For `Import-AzureRMDataLakeStoreItem` and `Export-AzureRMDataLakeStoreItem` trace logging has been disabled by default to improve performance. If trace logging is desired please use the `-DiagnosticLogLevel` and `-DiagnosticLogPath` parameters
* Fixed a bug that would sometimes cause PowerShell to crash when uploading lots of small file to ADLS.

## Version 3.6.0
* Add support for head and tail to the `Get-AzureRMDataLakeStoreItemContent` cmdlet. This enables returning the top N or last N new line delimited rows to be displayed.

## Version 3.5.0

## Version 3.4.0
* Update Upload and Download commands to use the new and improved Upload/Download helpers in the new DataLake.Store clients. This also gives better diagnostic logging, if enabled.
* Default thread counts for Upload and download are now computed on a best effort basis based on the data being uploaded or downloaded. This should allow for good performance without specifying a thread count.
* Update to Set-AzureRMDataLakeStoreAccount to allow for enabling and disabling Azure originating IPs through the firewall
* Add warnings to Add and Set-AzureRMDataLakeStoreFirewallRule and AzureRMDataLakeStoreTrustedIdProvider if they are disabled
* Remove explicit restrictions on resource locations. If Data Lake Store is not supported in a region, we will surface an error from the service.

## Version 3.3.0
* Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
* Update New-AdlStore and Set-AdlStore to support commitment tier options for the service.
* Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.
* Add Diagnostic logging support to Import-AdlStoreItem and Export-AdlStoreItem. This can be enabled through the following parameters:
    * -Debug, enables full diagnostic logging as well as debug logging to the PowerShell console. Most verbose options
    * -DiagnosticLogLevel, allows finer control of the output than debug. If used with debug, this is ignored and debug logging is used.
    * -DiagnosticLogPath, optionally specify the file to write diagnostic logs to. By default it is written to a file under %LOCALAPPDATA%\AdlDataTransfer
* Added support to New-AdlStore to explicitly opt-out of account encryption. To do so, create the account with the -DisableEncryption flag.

## Version 3.2.0
* Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
* Removed the ability to set encryption in Set-AzureRMDataLakeStoreAccount (never was supported)
* Added ability to enable/disable firewall rules and the trusted id providers during Set-AzureRMDataLakeStoreAccount
* Added a new cmdlet: Set-AzureRMDataLakeStoreItemExpiry, which allows the user to set or remove the expiration for files (not folders) in their ADLS account.
* Small fix for friendly date properties to pivot off UTC time instead of local time, ensuring standard time reporting.

## Version 3.1.0
* Improvements to import and export data cmdlets
    - Drastically increased performance for distributed download scenarios, where multiple sessions are running across many clients targeting the same ADLS account.
    - Better error handling and messaging for both upload and download scenarios.
* Full Firewall rules management CRUD
    - The below cmdlets can be used to manage firewall rules for an ADLS account:
    - Add-AzureRMDataLakeStoreFirewallRule
    - Set-AzureRMDataLakeStoreFirewallRule
    - Get-AzureRMDataLakeStoreFirewallRule
    - Remove-AzureRMDataLakeStoreFirewallRule
* Full Trusted ID provider management CRUD
    - The below cmdlets can be used to manage trusted identity providers for an ADLS account:
    - Add-AzureRMDataLakeStoreTrustedIdProvider
    - Set-AzureRMDataLakeStoreTrustedIdProvider
    - Get-AzureRMDataLakeStoreTrustedIdProvider
    - Remove-AzureRMDataLakeStoreTrustedIdProvider
* Account Encryption Support
    - You can now encrypt newly created ADLS accounts as well as enable encryption on existing ADLS accounts using the New-AzureRMDataLakeStoreAccount and Set-AzureRMDataLakeStoreAccount cmdlets, respectively.
