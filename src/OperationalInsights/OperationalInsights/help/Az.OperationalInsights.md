---
Module Name: Az.OperationalInsights
Module Guid: e827799a-7abf-4538-a61f-94dc52a48bd4
Download Help Link: https://docs.microsoft.com/powershell/module/az.operationalinsights
Help Version: 4.3.2.0
Locale: en-US
---

# Az.OperationalInsights Module
## Description
This topic displays help topics for the Azure Operational Insights Cmdlets.

## Az.OperationalInsights Cmdlets
### [Disable-AzOperationalInsightsIISLogCollection](Disable-AzOperationalInsightsIISLogCollection.md)
Stops collection of IIS logs from computers.

### [Disable-AzOperationalInsightsLinuxCustomLogCollection](Disable-AzOperationalInsightsLinuxCustomLogCollection.md)
Stops collection of custom logs from Linux computers.

### [Disable-AzOperationalInsightsLinuxPerformanceCollection](Disable-AzOperationalInsightsLinuxPerformanceCollection.md)
Stops collection of performance counters from Linux computers.

### [Disable-AzOperationalInsightsLinuxSyslogCollection](Disable-AzOperationalInsightsLinuxSyslogCollection.md)
Stops collection of syslog data from Linux computers.

### [Enable-AzOperationalInsightsIISLogCollection](Enable-AzOperationalInsightsIISLogCollection.md)
Starts collection of IIS logs from computers in a workspace.

### [Enable-AzOperationalInsightsLinuxCustomLogCollection](Enable-AzOperationalInsightsLinuxCustomLogCollection.md)
Starts collection of custom logs from Linux computers.

### [Enable-AzOperationalInsightsLinuxPerformanceCollection](Enable-AzOperationalInsightsLinuxPerformanceCollection.md)
Starts collection of performance counters from Linux computers.

### [Enable-AzOperationalInsightsLinuxSyslogCollection](Enable-AzOperationalInsightsLinuxSyslogCollection.md)
Starts collection of syslog data from Linux computers.

### [Get-AzOperationalInsightsAvailableServiceTier](Get-AzOperationalInsightsAvailableServiceTier.md)
This command gets all available service tiers for a given worksapce.

### [Get-AzOperationalInsightsCluster](Get-AzOperationalInsightsCluster.md)
Get or list clusters

### [Get-AzOperationalInsightsDataExport](Get-AzOperationalInsightsDataExport.md)
Get or list data exports for workspace.

### [Get-AzOperationalInsightsDataSource](Get-AzOperationalInsightsDataSource.md)
Get datasources under Azure Log Analytics workspace.

### [Get-AzOperationalInsightsDeletedWorkspace](Get-AzOperationalInsightsDeletedWorkspace.md)
List deleted workspaces.

### [Get-AzOperationalInsightsIntelligencePack](Get-AzOperationalInsightsIntelligencePack.md)
Gets the available Intelligence Packs.

> [!NOTE]
> Solutions is being deprecated, please use [az monitor log-analytics solution](https://docs.microsoft.com/en-us/cli/azure/monitor/log-analytics/solution?view=azure-cli-latest) and [Get-AzMonitorLogAnalyticsSolution](https://docs.microsoft.com/en-us/powershell/module/az.monitoringsolutions/get-azmonitorloganalyticssolution?view=azps-5.9.0) instead if this command.

### [Get-AzOperationalInsightsLinkedService](Get-AzOperationalInsightsLinkedService.md)
Get or list linked service for workspace

### [Get-AzOperationalInsightsLinkedStorageAccount](Get-AzOperationalInsightsLinkedStorageAccount.md)
Get or list linked storage account

### [Get-AzOperationalInsightsOperation](Get-AzOperationalInsightsOperation.md)
Lists all of the available OperationalInsights Rest API operations.

### [Get-AzOperationalInsightsOperationStatus](Get-AzOperationalInsightsOperationStatus.md)
Get the status of a long running azure asynchronous operation.

### [Get-AzOperationalInsightsPurgeWorkspaceStatus](Get-AzOperationalInsightsPurgeWorkspaceStatus.md)
Gets status of an ongoing purge operation.

### [Get-AzOperationalInsightsSavedSearch](Get-AzOperationalInsightsSavedSearch.md)
Returns all of the saved searches for a specified workspace.

### [Get-AzOperationalInsightsSchema](Get-AzOperationalInsightsSchema.md)
Returns the schema associated with a workspace.

### [Get-AzOperationalInsightsStorageInsight](Get-AzOperationalInsightsStorageInsight.md)
Gets information about a Storage Insight.

### [Get-AzOperationalInsightsTable](Get-AzOperationalInsightsTable.md)
Get or list tables for workspace.

### [Get-AzOperationalInsightsWorkspace](Get-AzOperationalInsightsWorkspace.md)
Gets information about a workspace.

### [Get-AzOperationalInsightsWorkspaceManagementGroup](Get-AzOperationalInsightsWorkspaceManagementGroup.md)
Gets details of management groups connected to a workspace.

### [Get-AzOperationalInsightsWorkspaceSharedKey](Get-AzOperationalInsightsWorkspaceSharedKey.md)
Gets the shared keys for a workspace.

### [Get-AzOperationalInsightsWorkspaceUsage](Get-AzOperationalInsightsWorkspaceUsage.md)
Gets the usage data for a workspace.

### [Invoke-AzOperationalInsightsMigrateTable](Invoke-AzOperationalInsightsMigrateTable.md)
Migrate a Log Analytics table from support of the Data Collector API and Custom Fields features to support of Data Collection Rule-based Custom Logs.

### [Invoke-AzOperationalInsightsQuery](Invoke-AzOperationalInsightsQuery.md)
Returns search results based on the specified parameters.

### [New-AzOperationalInsightsApplicationInsightsDataSource](New-AzOperationalInsightsApplicationInsightsDataSource.md)
Collect logs from given Application-Insights application.

### [New-AzOperationalInsightsAzureActivityLogDataSource](New-AzOperationalInsightsAzureActivityLogDataSource.md)
Collect Azure Activity log from given subscription.

### [New-AzOperationalInsightsCluster](New-AzOperationalInsightsCluster.md)
Create cluster

### [New-AzOperationalInsightsComputerGroup](New-AzOperationalInsightsComputerGroup.md)
Creates a computer group.

### [New-AzOperationalInsightsCustomLogDataSource](New-AzOperationalInsightsCustomLogDataSource.md)
Defines a custom log collection policy.

### [New-AzOperationalInsightsDataExport](New-AzOperationalInsightsDataExport.md)
Create data export for workspace.

### [New-AzOperationalInsightsLinkedStorageAccount](New-AzOperationalInsightsLinkedStorageAccount.md)
Create linked storage account for workspace

### [New-AzOperationalInsightsLinuxPerformanceObjectDataSource](New-AzOperationalInsightsLinuxPerformanceObjectDataSource.md)
Adds performance counters to all Linux computers in a workspace.

### [New-AzOperationalInsightsLinuxSyslogDataSource](New-AzOperationalInsightsLinuxSyslogDataSource.md)
Adds a data source to Linux computers.

### [New-AzOperationalInsightsPurgeWorkspace](New-AzOperationalInsightsPurgeWorkspace.md)
Purges data in an Log Analytics workspace by a set of user-defined filters

### [New-AzOperationalInsightsRestoreTable](New-AzOperationalInsightsRestoreTable.md)
Create a new Restore table

### [New-AzOperationalInsightsSavedSearch](New-AzOperationalInsightsSavedSearch.md)
Creates a new saved search with the specified parameters.

### [New-AzOperationalInsightsSearchTable](New-AzOperationalInsightsSearchTable.md)
Create a Search table

### [New-AzOperationalInsightsStorageInsight](New-AzOperationalInsightsStorageInsight.md)
Creates a Storage Insight inside a workspace.

### [New-AzOperationalInsightsTable](New-AzOperationalInsightsTable.md)
Creates a custom log table

### [New-AzOperationalInsightsWindowsEventDataSource](New-AzOperationalInsightsWindowsEventDataSource.md)
Collects event logs from computers that run the Windows operating system.

### [New-AzOperationalInsightsWindowsPerformanceCounterDataSource](New-AzOperationalInsightsWindowsPerformanceCounterDataSource.md)
Adds Windows performance counter data source for connected computers that run the Windows operating system.

### [New-AzOperationalInsightsWorkspace](New-AzOperationalInsightsWorkspace.md)
Creates a workspace, or restore a soft-deleted workspace.

### [Remove-AzOperationalInsightsCluster](Remove-AzOperationalInsightsCluster.md)
Delete cluster

### [Remove-AzOperationalInsightsDataExport](Remove-AzOperationalInsightsDataExport.md)
Delete data export for workspace.

### [Remove-AzOperationalInsightsDataSource](Remove-AzOperationalInsightsDataSource.md)
Deletes a data source.

### [Remove-AzOperationalInsightsLinkedService](Remove-AzOperationalInsightsLinkedService.md)
Unlink service for workspace

### [Remove-AzOperationalInsightsLinkedStorageAccount](Remove-AzOperationalInsightsLinkedStorageAccount.md)
Delete linked storage account for workspace

### [Remove-AzOperationalInsightsSavedSearch](Remove-AzOperationalInsightsSavedSearch.md)
Removes a saved search from the workspace.

### [Remove-AzOperationalInsightsStorageInsight](Remove-AzOperationalInsightsStorageInsight.md)
Removes a Storage Insight.

### [Remove-AzOperationalInsightsTable](Remove-AzOperationalInsightsTable.md)
Delete a Log Analytics workspace table.

### [Remove-AzOperationalInsightsWorkspace](Remove-AzOperationalInsightsWorkspace.md)
Removes a workspace.

### [Restore-AzOperationalInsightsWorkspace](Restore-AzOperationalInsightsWorkspace.md)
Restore a deleted workspace.

### [Set-AzOperationalInsightsDataSource](Set-AzOperationalInsightsDataSource.md)
Updates a data source.

### [Set-AzOperationalInsightsIntelligencePack](Set-AzOperationalInsightsIntelligencePack.md)
Enables or disables the specified Intelligence Pack.
> [!NOTE]
> Solutions is being deprecated, please use [az monitor log-analytics solution](https://docs.microsoft.com/en-us/cli/azure/monitor/log-analytics/solution?view=azure-cli-latest) and [Get-AzMonitorLogAnalyticsSolution](https://docs.microsoft.com/en-us/powershell/module/az.monitoringsolutions/get-azmonitorloganalyticssolution?view=azps-5.9.0) instead if this command.

### [Set-AzOperationalInsightsLinkedService](Set-AzOperationalInsightsLinkedService.md)
link service for workspace

### [Set-AzOperationalInsightsLinkedStorageAccount](Set-AzOperationalInsightsLinkedStorageAccount.md)
Set linked storage account for workspace

### [Set-AzOperationalInsightsSavedSearch](Set-AzOperationalInsightsSavedSearch.md)
Updates a saved search that already exists.

### [Set-AzOperationalInsightsStorageInsight](Set-AzOperationalInsightsStorageInsight.md)
Updates a Storage Insight.

### [Set-AzOperationalInsightsWorkspace](Set-AzOperationalInsightsWorkspace.md)
Updates a workspace.

### [Update-AzOperationalInsightsCluster](Update-AzOperationalInsightsCluster.md)
update cluster

### [Update-AzOperationalInsightsDataExport](Update-AzOperationalInsightsDataExport.md)
Update data export.

### [Update-AzOperationalInsightsTable](Update-AzOperationalInsightsTable.md)
Update a Log Analytics workspace table.

### [Update-AzOperationalInsightsWorkspaceSharedKey](Update-AzOperationalInsightsWorkspaceSharedKey.md)
Regenerates the shared keys for a Log Analytics Workspace. These keys are used to connect Microsoft Operational Insights agents to the workspace.

