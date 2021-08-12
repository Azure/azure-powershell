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

## Version 2.4.0
changes to existing commands summary:
1.	Get-AzOperationalInsightsLinkedStorageAccount
•	Added DataSourceType types: "Query", "Alerts"
2. New-AzOperationalInsightsLinkedStorageAccount:
•	Added DataSourceType types: "Query", "Alerts"
•	CmdletParameterBreakingChange: rename StorageAccountId to StorageAccountIds
3.	Remove-AzOperationalInsightsLinkedStorageAccount
•	Added DataSourceType types: "Query", "Alerts"
4.	Set-AzOperationalInsightsLinkedStorageAccount
•	Added DataSourceType types: "Query", "Alerts"
5.	Get-AzOperationalInsightsSavedSearch:
•	file moved - nothing changed and nothing to test
6. Get-AzOperationalInsightsSchema
•	file moved - nothing changed and nothing to test
7. New-AzOperationalInsightsComputerGroup
•	Now returns PSSavedSearch instead of HttpStatusCode
8. New-AzOperationalInsightsSavedSearch
•	file moved - nothing changed and nothing to test	
9. Remove-AzOperationalInsightsSavedSearch
•	file moved - nothing changed and nothing to test	
10. Set-AzOperationalInsightsSavedSearch
•	file moved - nothing changed and nothing to test		
11. Get-AzOperationalInsightsWorkspace 
	a. Get-AzOperationalInsightsWorkspace -resourceGroupName dabenham-dev -Name dabenhamIntWS
	b. Get-AzOperationalInsightsWorkspace -resourceGroupName testnotifyrg -Name Export
12. Set-AzOperationalInsightsWorkspace
	○ Added 2 new values to Sku : "capacityreservation", "lacluster"
	○ Added new property SkuCapacity 
	○ PublicNetworkAccessForIngestion preoperty: added ValidateSet attribute with "Enabled", "Disabled" values
	○ Added new property ForceCmkForQuery
	○ Added new property DailyQuotaGb
13. New-AzOperationalInsightsWorkspace
	○ Added 2 new values to Sku : "capacityreservation", "lacluster"
	○ Added new property SkuCapacity 
	○ PublicNetworkAccessForIngestion - added ValidateSet attribute with "Enabled", "Disabled" values
	○ Added new property ForceCmkForQuery
14. Set-AzOperationalInsightsStorageInsight
	○ Added SupportsShouldProcess attribute
	○ Added new property StorageAccountResourceId 
	○ Added new property ETag  
	○ Added new property Tags  
15. New-AzOperationalInsightsStorageInsight
	○ Added new property ETag  
    ○ Added new property Tags  


new commands summary (with command examples):
1. Set-AzOperationalInsightsTable
a. $updatedTable = Set-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E -tableName E2E_16_12_2020_CL -RetentionInDays 50

2. Get-AzOperationalInsightsTable
	a. $testTable = Get-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E -tableName E2E_16_12_2020_CL
3. Get-AzOperationalInsightsOperations
	a. $allOps = Get-AzOperationalInsightsOperations
	
4. Get-AzOperationalInsightsDataExport
	a. Get-AzOperationalInsightsDataExport -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E
	b. Get-AzOperationalInsightsDataExport -ResourceGroupName testnotifyrg -WorkspaceName Export
	c. Get-AzOperationalInsightsDataExport -ResourceGroupName cli_test_monitor_workspace_data_export -WorkspaceName clitestypg6yjcnrwypz
	
5. New-AzOperationalInsightsDataExport
	a. New-AzOperationalInsightsDataExport  -ResourceGroupName cli_test_monitor_workspace_data_export -WorkspaceName clitestypg6yjcnrwypz -DataExportName "dabenhamTestDataExport" -TableNames "Heartbeat" -ResourceId "/subscriptions/57947cb5-aadd-4b6c-9e8e-27f545bb7bf5/resourceGroups/dabenham-dev/providers/Microsoft.EventHub/namespaces/dabenhamNamespace"
	
6. Remove-AzOperationalInsightsDataExport
	a. Remove-AzOperationalInsightsDataExport  -ResourceGroupName cli_test_monitor_workspace_data_export -WorkspaceName clitestypg6yjcnrwypz -DataExportName "dabenhamTestDataExport"
	
7. Update-AzOperationalInsightsDataExport
	a. Update-AzOperationalInsightsDataExport  -ResourceGroupName cli_test_monitor_workspace_data_export -WorkspaceName clitestypg6yjcnrwypz -DataExportName "dabenhamTestDataExport" -TableNames "Heartbeat","Perf"
	
8. Get-AzOperationalInsightsOperationStatus
	a. Get-AzOperationalInsightsOperationStatus -Location "East US" -OperationId  {GUID}
	
9. Update-AzOperationalInsightsWorkspaceSharedKey
	a. Update-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName dabenham-dev -Name  dabenham-troubleShootingE2E
	NOTE: perform the following command before to validate the keys have changed:
		 Get-AzOperationalInsightsWorkspaceSharedKey  -ResourceGroupName dabenham-dev -Name  dabenham-troubleShootingE2E 
		
		
10. New-AzOperationalInsightsPurgeWorkspace
	a. New-AzOperationalInsightsPurgeWorkspace -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E -Column {NAME} -OperatorProperty {OPERATOR} -Value {VAL} -key {KEY} -Table {TABLENAME}
	NOTE:  operators are ==, =~, in, in~, >, >=, <, <=, between, -> as string
	NOTE: This can be a number (e.g., > 100), a string (timestamp >= '2017-09-01') or array of values
	
11. Get-AzOperationalInsightsPurgeWorkspaceStatus
	a. Get-AzOperationalInsightsPurgeWorkspaceStatus  -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E -PurgeId {PURGEID}
NOTE: PurgeId is received from New-AzOperationalInsightsPurgeWorkspace command



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
