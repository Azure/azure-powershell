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

## Version 5.1.5
* This module is outdated and will go out of support on 29 February 2024.
* The Az.DataLakeAnalytics module has all the capabilities of AzureRM.DataLakeAnalytics and provides the following improvements:
    - Greater security with token cache encryption and improved authentication.
    - Availability in Azure Cloud Shell and on Linux and macOS.
    - Support for all Azure services.
    - Allows use of Azure access tokens.
* We encourage you to start using the Az module as soon as possible to take advantage of these improvements.
* [Update your scripts](https://docs.microsoft.com/powershell/azure/migrate-from-azurerm-to-az) that use AzureRM PowerShell modules to use Az PowerShell modules by 29 February 2024.
* To automatically update your scripts, follow the [quickstart guide](https://docs.microsoft.com/powershell/azure/quickstart-migrate-azurerm-to-az-automatically).

## Version 5.1.4
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

## Version 5.1.3
* Fixed issue with default resource groups not being set.

## Version 5.1.2
* Updated to the latest version of the Azure ClientRuntime.

## Version 5.1.1
* Updated all help files to include full parameter types and correct input/output types.

## Version 5.1.0
* Add support for Catalog ACLs through the following commands:
    - Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry
    - Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry
    - Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry
* Fixed formatting of OutputType in help files

## Version 5.0.0
* Set minimum dependency of module to PowerShell 5.0
* Remove deprecated `Tags` alias from cmdlets
    - `New-AzureRmDataLakeAnalyticsAccount`
    - `Set-AzureRmDataLakeAnalyticsAccount`

## Version 4.2.3
* Updated to the latest version of the Azure ClientRuntime

## Version 4.2.2
* Fix issue with Default Resource Group in CloudShell

## Version 4.2.1
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

## Version 4.2.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataLakeAnalyticsAccount and Set-AzureRmDataLakeAnalyticsAccount

## Version 4.1.1
* Added a parameter called ScriptParameter to Submit-AzureRmDataLakeAnalyticsJob
    - Detailed information about ScriptParameter can be found using Get-Help on Submit-AzureRmDataLakeAnalyticsJob
* For New-AzureRmDataLakeAnalyticsAccount, changed the parameter MaxDegreeOfParallelism to MaxAnalyticsUnits
    - Added an alias for the parameter MaxAnalyticsUnits: MaxDegreeOfParallelism
* For New-AzureRmDataLakeAnalyticsComputePolicy, changed the parameter MaxDegreeOfParallelismPerJob to MaxAnalyticsUnitsPerJob
    - Added an alias for the parameter MaxAnalyticsUnitsPerJob: MaxDegreeOfParallelismPerJob
* For Set-AzureRmDataLakeAnalyticsAccount, changed the parameter MaxDegreeOfParallelism to MaxAnalyticsUnits
    - Added an alias for the parameter MaxAnalyticsUnits: MaxDegreeOfParallelism
* For Submit-AzureRmDataLakeAnalyticsJob, changed the parameter DegreeOfParallelism to AnalyticsUnits
    - Added an alias for the parameter AnalyticsUnits: DegreeOfParallelism
* For Update-AzureRmDataLakeAnalyticsComputePolicy, changed the parameter MaxDegreeOfParallelismPerJob to MaxAnalyticsUnitsPerJob
    - Added an alias for the parameter MaxAnalyticsUnitsPerJob: MaxDegreeOfParallelismPerJob

## Version 4.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of breaking changes introduced.
* Removed the Obsolete Properties fields in PSDataLakeAnalyticsAccount.cs and its assoicated files
* Changed one of the two OutputTypes of Get-AzureRmDataLakeAnalyticsAccount
    - List\<DataLakeAnalyticsAccount> to List\<PSDataLakeAnalyticsAccountBasic>
    - The properties of PSDataLakeAnalyticsAccountBasic is a strict subset of the properties of DataLakeAnalyticsAccount
    - The additional properties that are in DataLakeAnalyticsAccount are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSDataLakeAnalyticsAccountBasic, but they are tagged as Obsolete.
* Changed one of the two OutputTypes of Get-AzureRmDataLakeAnalyticsJob
    - List\<JobInformation> to List\<PSJobInformationBasic>
    - The properties of PSJobInformationBasic is a strict subset of the properties of JobInformation
    - The additional properties that are in JobInformation are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSJobInformationBasic, but they are tagged as Obsolete.
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0

## Version 3.3.1

## Version 3.3.0

## Version 3.2.1

## Version 3.2.0
* Add support for Compute Policy CRUD through the following commands:
    - New-AzureRMDataLakeAnalyticsComputePolicy
    - Get-AzureRMDataLakeAnalyticsComputePolicy
    - Remove-AzureRMDataLakeAnalyticsComputePolicy
    - Update-AzureRMDataLakeAnalyticsComputePolicy
* Add support for job relationship metadata for help with recurring jobs and job pipelines. The following commands were updated or added:
    - Submit-AzureRMDataLakeAnalyticsJob
    - Get-AzureRMDataLakeAnalyticsJob
    - Get-AzureRMDataLakeAnalyticsJobRecurrence
    - Get-AzureRMDataLakeAnalyticsJobPipeline
* Updated the token audience for job and catalog APIs to use the correct Data Lake specific audience instead of the Azure Resource audience.

## Version 3.1.0

## Version 3.0.1

## Version 3.0.0
* Add support for catalog package get and list
* Add support for listing the following catalog items from deeper ancestors:
  * Table
  * TVF
  * View
  * Statistics

## Version 2.8.0
* Fix help for some commands to have the proper verbage and examples.

## Version 2.7.0

## Version 2.6.0
* Add Firewall Rule support to Data Lake Analytics:
    - Add-AzureRMDataLakeAnalyticsFirewallRule
    - Get-AzureRMDataLakeAnalyticsFirewallRule
    - Set-AzureRMDataLakeAnalyticsFirewallRule
    - Remove-AzureRMDataLakeAnalyticsFirewallRule
    - Set-AzureRMDataLakeAnalyticsAccount supports enabling/disabling the firewall and allowing/blocking Azure originating IPs through the firewall
    - Warnings will be raised if updating firewall rules when the firewall is disabled
* Fix Get-AzureRMDataLakeAnalyticsJob functionality:
    - Top now correctly returns the number of jobs specified. The default number of jobs to return is 500. The more jobs requested the longer the command will take.
* Remove explicit restrictions on resource locations. If Data Lake Analytics is not supported in a region, we will surface an error from the service.

## Version 2.5.0
* Update Get-AdlJob to support Top parameter
* Update Get-AdlJob to return the list of jobs in order by most recently submitted
* Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
* Update New-AdlAnalyticsAccount and Set-AdlAnalyticsAccount to support commitment tier options for the service.
* Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.

## Version 2.4.0
* Removal of unsupported parameters in Add and Set-AzureRMDataLakeAnalyticsDataSource (default for data lake store)
* Removed unsupported parameter in Set-AzureRMDataLakeAnalyticsAccount (default data lake store)
* Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
* Added the ability to set MaxDegreeOfParallelism, MaxJobCount and QueryStoreRetention in New and Set-AzureRMDataLakeAnalyticsAccount
* Removed invalid return value from New-AzureRMDataLakeAnalyticsCatalogSecret

## Version 2.3.0
* Addition of Catalog CRUD cmdlets:
    - The following cmdlets are replacing Secret CRUD cmdlets. In the next release Secret CRUD cmdlets will be removed.
    - New-AzureRMDataLakeAnalyticsCatalogCredential
    - Set-AzureRMDataLakeAnalyticsCatalogCredential
    - Remove-AzureRMDataLakeAnalyticsCatalogCredential
* Fixes for Get-AzureRMDataLakeAnalyticsCatalogItem
    - Better error messaging and support for invalid input
* General help improvements
    - Clearer help for job operations
    - Fixed typos and incorrect examples
