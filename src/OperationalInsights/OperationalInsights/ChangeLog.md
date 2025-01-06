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

## Version 3.2.1
* Fixed an issue that `Invoke-AzOperationalInsightsQuery` timed out after 100 seconds. The timeout is now bound to the `-Wait` parameter. (#16553)
* Removed the outdated deps.json file.

## Version 3.2.0
* Added new cmdlets for Table resource: 'New-AzOperationalInsightsRestoreTable', 'New-AzOperationalInsightsSearchTable', 'New-AzOperationalInsightsTable','Remove-AzOperationalInsightsTable','Update-AzOperationalInsightsTable', 'Convert-AzOperationalInsightsMigrateTable'
* Added new property 'DefaultDataCollectionRuleResourceId' to 'Set-AzOperationalInsightsWorkspace' and to 'New-AzOperationalInsightsWorkspace' cmdlets

## Version 3.1.0
* Removed capacity validation in new and update cluster cmdlets as validation exists on server side.
* Extended error message on base class for extended information.
* Bug fix - prevent exceptions while using StorageInsight cmdlets.
* Bug fix - when updating a cluster, it's SKU was set even if no value was passed.

## Version 3.0.1
* Added logic to prevent exceptions while using `StorageInsight` cmdlets.

## Version 3.0.0
* Expanded DataSourceType with values `Query`, `Alerts` for LinkedStorageAccount cmdlets
* [Breaking Change] rename `StorageAccountId` to `StorageAccountIds`
  - `New-AzOperationalInsightsLinkedStorageAccount`
* [Breaking Change] Returns `PSSavedSearch` instead of `HttpStatusCode` by `New-AzOperationalInsightsComputerGroup`
* [Breaking Change] Returns `PSCluster` instead of `PSLinkedService` by `Update-AzOperationalInsightsCluster`
* Expanded Sku with values `capacityreservation`, `lacluster` for Workspace
* Added new properties:`SkuCapacity`, `ForceCmkForQuery`, `DisableLocalAuth` for Workspace
* Added new property: `DailyQuotaGb`on`Set-AzOperationalInsightsWorkspace`
* Added new properties: `ETag`, `Tag` for StorageInsight cmdlets
* Added new property `StorageAccountResourceId` to cmdlet:
  - `Set-AzOperationalInsightsStorageInsight`
* Added SupportsShouldProcess attribute to cmdlet:
  - `Set-AzOperationalInsightsStorageInsight`
* Added new cmdlets to support Table, DataExport, WorkspaceShareKey, PurgeWorkspace, and AvailableServiceTier
* Added `Error` property in the result of the `Invoke-AzOperationalInsightsQuery` to retrieve partial error when running a query [#16378]

## Version 2.3.1
* Fixed a bug in `Set-AzOperationalInsightsLinkedService: when linked service does not exist, perform create(update) instead of failing`

## Version 2.3.0
* Added `-ForceDelete` option for `Remove-AzOperationalInsightsWorkspace`
* Added new cmdlet `Get-AzOperationalInsightsDeletedWorkspace`
* Added new cmdlet `Restore-AzOperationalInsightsWorkspace`

## Version 2.2.0
* Fixed bug PSWorkspace doesn't implement IOperationalInsightsWorkspace [#12135]
* Added "pergb2018" to valid value set of parameter `Sku` in `Set-AzOperationalInsightsWorkspace`
* Added alias "FunctionParameters" for parameter `FunctionParameter` to
    - `New-AzOperationalInsightsSavedSearch`
    - `Set-AzOperationalInsightsSavedSearch`

## Version 2.1.0
* Upgraded SDK to 0.21.0
* Added optional parameters to
    - `New-AzOperationalInsightsSavedSearch`
    - `Set-AzOperationalInsightsSavedSearch`

## Version 2.0.0
* Updated legacy code to apply new generated SDK
* Deleted cmdlets due to deprecated APIs
    - `Get-AzOperationalInsightsSavedSearchResult` (alias `Get-AzOperationalInsightsSavedSearchResults`)
    - `Get-AzOperationalInsightsSearchResult` (alias `Get-AzOperationalInsightsSearchResults`)
    - `Get-AzOperationalInsightsLinkTarget` (alias `Get-AzOperationalInsightsLinkTargets`)
* Added parameters for `Set-AzOperationalInsightsWorkspace` and `New-AzOperationalInsightsWorkspace`
* Created cmdlets for Linked Stoarge Account
* Created cmdlets for Clusters and Linked Service

## Version 1.3.4
* Update references in .psd1 to use relative path

## Version 1.3.3
* Fixed miscellaneous typos across module
* Updated documentation for `New-AzOperationalInsightsLinuxSyslogDataSource`
    - Added example
    - Updated description for `-Name` parameter
* Added an example for New-AzOperationalInsightsWindowsEventDataSource
* Changed the description of the -Name parameter for New-AzOperationalInsightsWindowsEventDataSource

## Version 1.3.2
* Updated default version for saved searches to be 1.
* Fixed custom log null regex handling

## Version 1.3.1
* Fixed CustomLog datasource model returned in Get-AzOperationalInsightsDataSource

## Version 1.3.0
* Enable **pergb2018** pricing tier in `New-AzureRmOperationalInsightsWorkspace` command

## Version 1.2.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.1.0
* Additional support for New and Get ApplicationInsights data source.
    - Added new 'ApplicationInsights' kind to support Get specific and Get all ApplicationInsights data sources for given workspace.
    - Added New-AzOperationalInsightsApplicationInsightsDataSource cmdlet for creating data source by given Application-Insights resource parameters: subscription Id, resourceGroupName and name.

## Version 1.0.0
* General availability of `Az.OperationalInsights` module
* Default parameter set for Get-AzOperationalInsightsDataSource is removed, and ByWorkspaceNameByKind has become the default parameter set
