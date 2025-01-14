<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
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
## Upcoming Release
* upgraded nuget package to signed package.
* Removed "Microsoft.Azure.Management.Logic" Version "4.1.0" PackageReference

## Version 1.5.1
* Removed the *.deps.json file that caused false positive security alerts. [#23603]

## Version 1.5.0
* Fixed issue that `Get-AzLogicAppTriggerHistory` and `Get-AzLogicAppRunAction` only retrieving the first page of results [#9141]

## Version 1.4.0
* Fixed issue that `Get-AzLogicAppRunHistory` only retrieving the first page of results [#9141]

## Version 1.3.2
* Update references in .psd1 to use relative path

## Version 1.3.1
* Fixed miscellaneous typos across module

## Version 1.3.0
* Fix for Get-AzIntegrationAccountMap to list all map types
	- Added new MapType parameter for filtering

## Version 1.2.1
* Fix for ListWorkflows only retrieving the first page of results

## Version 1.2.0
* Add in Basic sku for Integration Accounts
* Add in XSLT 2.0, XSLT 3.0 and Liquid Map Types
* New cmdlets for Integration Account Assemblies
	- Get-AzIntegrationAccountAssembly
	- New-AzIntegrationAccountAssembly
	- Remove-AzIntegrationAccountAssembly
	- Set-AzIntegrationAccountAssembly
* New cmdlets for Integration Account Batch Configuration
	- Get-AzIntegrationAccountBatchConfiguration
	- New-AzIntegrationAccountBatchConfiguration
	- Remove-AzIntegrationAccountBatchConfiguration
	- Set-AzIntegrationAccountBatchConfiguration
* Update Logic App SDK to version 4.1.0

## Version 1.1.0
* Get-AzLogicApp lists all without specified Name

## Version 1.0.0
* General availability of `Az.LogicApp` module
