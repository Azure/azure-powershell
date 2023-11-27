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

## Version 3.0.4
* Upgraded Azure.Core to 1.35.0.

## Version 3.0.3
* Updated Azure.Core to 1.34.0.
* Updated Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.18

## Version 3.0.2
* Updated Azure.Core to 1.33.0.

## Version 3.0.1
* Fixed the issue for "Start-AzSynapseTrigger/Stop-AzSynapseTrigger" to not throw exception when Request Status is 202

## Version 3.0.0
* Removed the unnecessary breaking change of parameter `-SparkConfigFilePath` for `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` cmdlets

## Version 2.3.1
* Updated Azure.Core to 1.31.0.
* Added PackageAction `Set` for `Update-AzSynapseSparkPool` to support removing and adding packages in one action

## Version 2.3.0
* Upgraded Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.17
* Updated `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` to support for setting spark pool isolated compute by `-EnableIsolatedCompute`
* Updated `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` to support for setting spark pool node size to 'XLarge', 'XXLarge', 'XXXLarge'

## Version 2.2.0
* Added breaking change message for  `-SparkConfigFilePath`. It will be deprecated around the middle of December.
* Updated `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` to support for setting spark pool configuration artifact by `-SparkCongifuration`. `-SparkCongifuration` is an alternative of parameter `-SparkConfigFilePath`.

## Version 2.1.0
* Updated `Update-AzSynaspeWorkSpace` and `New-AzSynpaseWorkspace` to support for Workspace Encrytion Managed Identity setting

## Version 2.0.0
* [Breaking Change] Updated models of Synapse Link for Azure Sql Database
* Updated `New-AzSynapseWorkspace` and `Update-AzSynapseWorkspace` to support for user assigned managed identity (UAMI) by `-UserAssignedIdentityAction` and `-UserAssignedIdentityId`
* Added EnablePublicNetworkAccess parameter to `New-AzureSynapseWorkspace` and `Update-AzSynapseWorkspace`

## Version 1.6.0
* Updated `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` to support for setting spark pool dynamic executor allocation by `-EnableDynamicExecutorAllocation`

## Version 1.5.0
* Set `ResourceGroupName` as optional for `Set-AzSynapseSqlAuditSetting` cmdlet
* Added LastCommitId parameter to `New-AzureSynapseGitRepositoryConfig`
* Fixed the issue that update spark pool version fail by `Update-AzSynapseSparkPool`

## Version 1.4.0
* Added support for Synapse Link for Azure Sql Database
    - Added `Get-AzSynapseLinkConnection` cmdlet
    - Added `Get-AzSynapseLinkConnectionDetailedStatus` cmdlet
    - Added `Set-AzSynapseLinkConnection` cmdlet
    - Added `Remove-AzSynapseLinkConnection` cmdlet
    - Added `Start-AzSynapseLinkConnection` cmdlet
    - Added `Stop-AzSynapseLinkConnection` cmdlet
    - Added `Set-AzSynapseLinkConnectionLinkTable` cmdlet
    - Added `Get-AzSynapseLinkConnectionLinkTable` cmdlet
    - Added `Get-AzSynapseLinkConnectionLinkTableStatus` cmdlet
    - Added `Update-AzSynapseLinkConnectionLandingZoneCredential` cmdlet
* Set `UploadedTimestamp` when adding package to spark pool by `Update-AzSynapseSparkPool`

## Version 1.3.0
* Added support for Synapse Azure Active Directory (Azure AD) only authentication
    - Added `Get-AzSynapseActiveDirectoryOnlyAuthentication` cmdlet
    - Added `Enable-AzSynapseActiveDirectoryOnlyAuthentication` cmdlet
    - Added `Disable-AzSynapseActiveDirectoryOnlyAuthentication` cmdlet

## Version 1.2.0
* Upgraded Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.14
* Fixed the issue that following cmdlets only shows 100 entries
    - `Get-AzSynapseRoleAssignment` cmdlet
    - `Get-AzSynapsePipelineRun` cmdlet
    - `Get-AzSynapseTriggerRun` cmdlet
    - `Get-AzSynapseActivityRun` cmdlet
* Fixed the issue that there should be an error message when removing a dependency pipeline

## Version 1.1.0
* Updated `Update-AzSynapseSparkPool` to support new parameter [-ForceApplySetting]

## Version 1.0.0
* General availability of Az.Synapse
* Migrated Azure AD features in Az.Synapse to MSGraph APIs. The cmdlets below called MSGraph API according to input parameters:
    - `New-AzSynapseRoleAssignment` cmdlet
    - `Get-AzSynapseRoleAssignment` cmdlet
    - `Remove-AzSynapseRoleAssignment` cmdlet
    - `Set-AzSynapseSqlActiveDirectoryAdministrator` cmdlet
* Added a default value for [-AutoPauseDelayInMinute] parameter of command `New-AzSynapseSparkpool` and `Update-AzSynapseSparkpool`

## Version 0.19.0
* Added support for Synapse KQL script
    - Added `Get-AzSynapseKqlScript` cmdlet
    - Added `Export-AzSynapseKqlScript` cmdlet
    - Added `Remove-AzSynapseKqlScript` cmdlet
    - Added `New-AzSynapseKqlScript` cmdlet
* Updated `New-AzSynapseSqlPool` to support new parameter [-StorageAccountType]
* Updated `Restore-AzSynapseSqlPool` to support new parameter [-Tag] and [-StorageAccountType]
* Renamed parameter FolderName in `Set-AzSynapseSqlScript` to FolderPath and keeped FolderName as alias
* Updated `Set-AzSynapseNoteBook` and `Set-AzSynapseSparkJobDefinition` to support new parameter [-FolderPath]
* Added cmdlets for Synapse Spark Configuration
    - Added `Get-AzSynapseSparkConfiguration` cmdlet
    - Added `New-AzSynapseSparkConfiguration` cmdlet
    - Added `Export-AzSynapseSparkConfiguration` cmdlet
    - Added `Remove-AzSynapseSparkConfiguration` cmdlet

## Version 0.18.0
* Added cmdlets for Synapse Kusto pool
    - Added `Get/New/Remove/Update/Start/Stop-AzSynapseKustoPool` cmdlet
    - Added `Get-AzSynapseKustoPoolSku` cmdlet
* Added cmdlets for Synapse Kusto pool language extension
    - Added `Add/Remove/Get-AzSynapseKustoPoolLanguageExtension` cmdlet
* Added cmdlets for Synapse Kusto pool principal assignment
    - Added `Get/New/Remove-AzSynapseKustoPoolPrincipalAssignment` cmdlet
* Added `Get-AzSynapseKustoPoolFollowerDatabase` cmdlet
* Added `Invoke-AzSynapseDetachKustoPoolFollowerDatabase` cmdlet
* Added cmdlets for Synapse Kusto database
    - Added `Get/New/Remove/Update-AzSynapseKustoPoolDatabase` cmdlet
* Added cmdlets for Synapse Kusto database principal assignment
    - Added `Get/New/Remove-AzSynapseKustoPoolDatabasePrincipalAssignment` cmdlet
* Added cmdlets for Synapse Kusto data connection
    - Added `Get/New/Remove/Update-AzSynapseKustoPoolDataConnection` cmdlet
* Added cmdlets for Synapse Kusto pool attached database configuration
    - Added `Get/New/Remove-AzSynaspeKustoPoolAttachedDatabaseConfiguration` cmdlet
* Added support for Synapse data flow debug session
    - Added `Start-AzSynapseDataFlowDebugSession` cmdlet to start a Synapse Analytics data flow debug session.
    - Added `Add-AzSynapseDataFlowDebugSessionPackage` cmdlet
    - Added `Invoke-AzSynapseDataFlowDebugSessionCommand` cmdlet
    - Added `Get-AzSynapseDataFlowDebugSession` cmdlet
    - Added `Stop-AzSynapseDataFlowDebugSession`cmdlet to Stop a data flow debug session by `SessionId`
* Fixed the format of notebook file exported by `Export-AzSynapseNotebook`
* Added support for Synapse sql script
    - Added `Get-AzSynapseSqlScript` cmdlet
    - Added `Remove-AzSynapseSqlScript` cmdlet
    - Added `Export-AzSynapseSqlScript` cmdlet
    - Added `Set-AzSynapseSqlScript` cmdlet

## Version 0.17.0
* Added cmdlets for Synapse Integration Runtime
	- Added `Start-AzSynapseIntegrationRuntime` cmdlet
	- Added `Stop-AzSynapseIntegrationRuntime` cmdlet
* Added cmdlets for Synapse trigger run
	- Added `Stop-AzSynapseTriggerRun` cmdlet
	- Added `Invoke-AzSynapseTriggerRun` cmdlet
* Added `New-AzSynapseLinkedServiceEncryptedCredential` cmdlet to encrypt credential in linked service
* Upgraded some package version
    - Upgraded Azure.Analytics.Synapse.AccessControl to 1.0.0-preview.5
    - Upgraded Azure.Analytics.Synapse.ManagedPrivateEndpoints to 1.0.0-beta.5
    - Upgraded Azure.Analytics.Synapse.Spark to 1.0.0-preview.7
    - Upgraded Microsoft.Azure.Management.Synapse to 2.2.0-preview
* Updated `New-AzSynapseSparkPool` and `Update-AzSynapseSparkPool` to support for uploading spark configuration properties file by `SparkConfigFilePath`
* Updated `Restore-AzSynapseSqlPool` to support for restoring SQL pool from a backup of a deleted SQL pool.

## Version 0.16.0
* Fixed the issue when `Update-AzSynapseSparkPool` is used with workspace package

## Version 0.15.0
* Fixed the issue when `Update-AzSynapseSparkPool` is used with workspace package
* Added support for Synapse Managed Private Endpoint
	- Added `New-AzSynapseManagedPrivateEndpoint` cmdlet
	- Added `Get-AzSynapseManagedPrivateEndpoint` cmdlet
	- Added `Remove-AzSynapseManagedPrivateEndpoint` cmdlet
* Fixed the blank page issue of pause setting and scale setting for Apache Spark pool through management API
* Updated `Set-AzSynapseSqlActiveDirectoryAdministrator` to support for setting SQL Admin by `DisplayName` or by `ObjectId`
* Renamed `Update-AzSynapseWorkspaceKey` to `Enable-AzSynapseWorkspace` to activate a new synapse workspace without `-Activate` parameter
* Added `New-AzSynapseGitRepositoryConfig` cmdlet to create Git repository configuration
* Updated `New-AzSynapseWorkspace` and `Update-AzSynapseWorkspace` to support for connecting a workspace to a Git reposirory
  - Added parameters `-GitRepositoryType`
* Added support for workspace package
	- Added `New-AzSynapseWorkspacePackage` cmdlet
	- Added `Get-AzSynapseWorkspacePackage` cmdlet
	- Added `Remove-AzSynapseWorkspacePackage` cmdlet
	- Updated `New-AzSynapseSparkPool` cmdlet to drop parameter `-LibraryRequirementsFilePath`
	- Updated `Updated-AzSynapseSparkPool` cmdlet to add parameter `-Package` and `-PackageAction`

## Version 0.14.0
* Added parameter `-ManagedResourceGroupName` for the `New-AzSynapseWorkspace` cmdlet
* Added support for event hub and log analytics to `Set-AzSynapseSqlAuditSetting` and `Set-AzSynapseSqlPoolAuditSetting`
  - Added parameters `-EventHubTargetState -EventHubName -EventHubAuthorizationRuleResourceId -LogAnalyticsTargetState -WorkspaceResourceId`

## Version 0.13.0
* Add support for Synapse Spark job definition
	- Add `New-AzSynapseSparkJobDefinition` cmdlet
    - Add `Get-AzSynapseSparkJobDefinition` cmdlet
    - Add `Remove-AzSynapseSparkJobDefinition` cmdlet

## Version 0.12.0
* Upgraded Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.9

## Version 0.11.0
* Removed principaltype in Synapse Role-based access control

## Version 0.10.0
* Add support for Synapse Role-based access control
   - Upgraded Azure.Analytics.Synapse.AccessControl to 1.0.0-preview.3
   - Updated `New-AzSynapseRoleAssignment` cmdlet
   - Updated `Get-AzSynapseRoleAssignment` cmdlet
   - Updated `Remove-AzSynapseRoleAssignment` cmdlet
   - Added `Get-AzSynapseRoleScope` cmdlet
* Renamed -AllowAllAzureIP to -AllowAllAzureIp and changed IP range to 0.0.0.0-0.0.0.0 
* Added -AllowAllIp and set IP range to 0.0.0.0-255.255.255.255
* Fixed the issue of retrieving Apache Spark pool information through management API

## Version 0.9.0
* Added support for workspace key encryption management
	- Add `New-AzSynapseWorkspaceKey` cmdlet
    - Add `Get-AzSynapseWorkspaceKey` cmdlet
    - Add `Remove-AzSynapseWorkspaceKey` cmdlet
    - Add `Update-AzSynapseWorkspaceKey` cmdlet
* Added support for managed identity SQL control
	- Add `Set-AzSynapseManagedIdentitySqlControlSetting` cmdlet
    - Add `Get-AzSynapseManagedIdentitySqlControlSetting` cmdlet
* Added support for data exfiltration
	- Update `New-AzSynapseWorkspace` cmdlet to accept `-ManagedVirtualNetwork`
    - Add `New-AzSynapseManagedVirtualNetworkConfig` cmdlet
    - Add `Update-AzSynapseManagedVirtualNetworkConfig` cmdlet

## Version 0.8.0
* Added support for operation of getting droppedsqlpool and geobackup
    - Add `Get-AzSynapseDroppedSqlPool` cmdlet
    - Add `Get-AzSynapseSqlPoolGeoBackup` cmdlet
* Switched to Azure PowerShell official exception types

## Version 0.7.0
* Simplify `Restore-AzSynapseSqlPool` cmdlet to make it consistent with the existing SQL DW cmdlet

## Version 0.6.0
* Added support for operation of Advanced Threat Protection settings in SqlPool-level
    - Add `Update-AzSynapseSqlPoolAdvancedThreatProtectionSetting` cmdlet
    - Add `Get-AzSynapseSqlPoolAdvancedThreatProtectionSetting` cmdlet
    - Add `Reset-AzSynapseSqlPoolAdvancedThreatProtectionSetting` cmdlet
* Added support for operation of Vulnerability Assessment settings in SqlPool-level
    - Add `Update-AzSynapseSqlPoolVulnerabilityAssessmentSetting` cmdlet
    - Add `Get-AzSynapseSqlPoolVulnerabilityAssessmentSetting` cmdlet
    - Add `Reset-AzSynapseSqlPoolVulnerabilityAssessmentSetting` cmdlet
* Added support for operation of SQL Advanced Data Security
    - Add `Enable-AzSynapseSqlAdvancedDataSecurity` cmdlet
    - Add `Disable-AzSynapseSqlAdvancedDataSecurity` cmdlet
    - Add `Get-AzSynapseSqlAdvancedDataSecurityPolicy` cmdlet
* Added support for operation of Transparent Data Encryption in SqlPool-level
    - Add `Get-AzSynapseSqlPoolTransparentDataEncryption` cmdlet
    - Add `Set-AzSynapseSqlPoolTransparentDataEncryption` cmdlet
* Added support for operation of Data Classification in SqlPool-level
    - Add `Disable-AzSynapseSqlPoolSensitivityRecommendation` cmdlet
    - Add `Enable-AzSynapseSqlPoolSensitivityRecommendation` cmdlet
    - Add `Get-AzSynapseSqlPoolSensitivityRecommendation` cmdlet
    - Add `Get-AzSynapseSqlPoolSensitivityClassification` cmdlet
    - Add `Remove-AzSynapseSqlPoolSensitivityClassification` cmdlet
    - Add `Set-AzSynapseSqlPoolSensitivityClassification` cmdlet
* Added support for operation of Vulnerability Assessment Baseline in SqlPool-level
    - Add `Clear-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline` cmdlet
    - Add `Get-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline` cmdlet
    - Add `Set-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline` cmdlet
* Fixed deserialization error when create Pipeline/Dataset/Trigger through DefinitionFile
* Added polling for artifacts cmdlets

## Version 0.5.0
* Added support for operation of Synapse SQL Pool Restore Point
    - Add `New-AzSynapseSqlPoolRestorePoint` cmdlet
    - Add `Remove-AzSynapseSqlPoolRestorePoint` cmdlet
* Added support for operation of Auditing settings in Workspace-level and SqlPool-level
    - Add `Set-AzSynapseSqlAuditSetting` cmdlet
    - Add `Get-AzSynapseSqlAuditSetting` cmdlet
    - Add `Reset-AzSynapseSqlAuditSetting` cmdlet
    - Add `Set-AzSynapseSqlPoolAuditSetting` cmdlet
    - Add `Get-AzSynapseSqlPoolAuditSetting` cmdlet
    - Add `Reset-AzSynapseSqlPoolAuditSetting` cmdlet
* Added support for operation of Advanced Threat Protection settings in Workspace-level
    - Add `Update-AzSynapseSqlAdvancedThreatProtectionSetting` cmdlet
    - Add `Get-AzSynapseSqlAdvancedThreatProtectionSetting` cmdlet
    - Add `Reset-AzSynapseSqlAdvancedThreatProtectionSetting` cmdlet
* Added support for operation of Vulnerability Assessment settings in Workspace-level
    - Add `Update-AzSynapseSqlVulnerabilityAssessmentSetting` cmdlet
    - Add `Get-AzSynapseSqlVulnerabilityAssessmentSetting` cmdlet
    - Add `Reset-AzSynapseSqlVulnerabilityAssessmentSetting` cmdlet
* Added support for operation of SQL Active Directory admin
    - Add `Set-AzSynapseSqlActiveDirectoryAdministrator` cmdlet
    - Add `Get-AzSynapseSqlActiveDirectoryAdministrator` cmdlet
    - Add `Remove-AzSynapseSqlActiveDirectoryAdministrator` cmdlet
* Fixed Null Reference Exception when submit spark job.

## Version 0.4.0
* Add `-Force` to all Remove cmdlets

## Version 0.3.0
* Added support for operation of Synapse LinkedService
    - Add `Get-AzSynapseLinkedService` cmdlet
    - Add `Remove-AzSynapseLinkedService` cmdlet
    - Add `Set-AzSynapseLinkedService` cmdlet
    - Add `New-AzSynapseLinkedService` cmdlet
* Added support for operation of Synapse Notebook
    - Add `Get-AzSynapseNotebook` cmdlet
    - Add `Export-AzSynapseNotebook` cmdlet
    - Add `Remove-AzSynapseNotebook` cmdlet
    - Add `Set-AzSynapseNotebook` cmdlet
    - Add `New-AzSynapseNotebook` cmdlet
    - Add `Import-AzSynapseNotebook` cmdlet
* Added support for operation of Synapse Pipeline
    - Add `Get-AzSynapsePipeline` cmdlet
    - Add `Remove-AzSynapsePipeline` cmdlet
    - Add `Set-AzSynapsePipeline` cmdlet
    - Add `New-AzSynapsePipeline` cmdlet
    - Add `Get-AzSynapseActivityRun` cmdlet
    - Add `Get-AzSynapsePipelineRun` cmdlet
    - Add `Invoke-AzSynapsePipeline` cmdlet
    - Add `Stop-AzSynapsePipelineRun` cmdlet
* Added support for operation of Synapse Trigger
    - Add `Get-AzSynapseTrigger` cmdlet
    - Add `Remove-AzSynapseTrigger` cmdlet
    - Add `Set-AzSynapseTrigger` cmdlet
    - Add `New-AzSynapseTrigger` cmdlet
    - Add `Add-AzSynapseTriggerSubscription` cmdlet
    - Add `Get-AzSynapseTriggerSubscriptionStatus` cmdlet
    - Add `Remove-AzSynapseTriggerSubscription` cmdlet
    - Add `Start-AzSynapseTrigger` cmdlet
    - Add `Stop-AzSynapseTrigger` cmdlet
    - Add `Get-AzSynapseTriggerRun` cmdlet
* Added support for operation of Synapse DataFlow
    - Add `Get-AzSynapseDataFlow` cmdlet
    - Add `Remove-AzSynapseDataFlow` cmdlet
    - Add `Set-AzSynapseDataFlow` cmdlet
    - Add `New-AzSynapseDataFlow` cmdlet
* Added support for operation of Synapse Dataset
    - Add `Get-AzSynapseDataset` cmdlet
    - Add `Remove-AzSynapseDataset` cmdlet
    - Add `Set-AzSynapseDataset` cmdlet
    - Add `New-AzSynapseDataset` cmdlet
* Removed parameter sets related 'create from backup' and 'create from restore point' from the `New-AzSynapseSqlPool` cmdlet
* Removed parameter sets related 'pause' and 'resume' from the `Update-AzSynapseSqlPool`
* Added support for operation of Synapse Sql pool
    - Add `Get-AzSynapseSqlPoolRestorePoint` cmdlet
    - Add `Restore-AzSynapseSqlPool` cmdlet
    - Add `Resume-AzSynapseSqlPool` cmdlet
    - Add `Suspend-AzSynapseSqlPool` cmdlet

## Version 0.2.0

* Added support for gen3 Sql Pools
    - For `Get-AzSynapseSqlPool`, `New-AzSynapseSqlPool`, ` Remove-AzSynapseSqlPool`, ` Test-AzSynapseSqlPool` and `Update-AzSynapseSqlPool` cmdlet
        - Add Version parameter to cmdlets to specify version 3. 
        - For this release, these cmdlets will not work unless a customer's subscription is on the allowlist.
* Added support for gen3 Sql Databases
    - Add `Get-AzSynapseSqlDatabase` cmdlet
    - Add `New-AzSynapseSqlDatabase` cmdlet
    - Add `Remove-AzSynapseSqlDatabase` cmdlet
    - Add `Update-AzSynapseSqlDatabase` cmdlet
    - Add `Test-AzSynapseSqlDatabase` cmdlet
* Added support for operation of Synapse IntegrationRuntime
    - Add `Get-AzSynapseIntegrationRuntime` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeKey` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeMetric` cmdlet
    - Add `Get-AzSynapseIntegrationRuntimeNode` cmdlet
    - Add `Invoke-AzSynapseIntegrationRuntimeUpgrade` cmdlet
    - Add `New-AzSynapseIntegrationRuntimeKey` cmdlet
    - Add `Remove-AzSynapseIntegrationRuntime` cmdlet
    - Add `Remove-AzSynapseIntegrationRuntimeNode` cmdlet
    - Add `Set-AzSynapseIntegrationRuntime` cmdlet
    - Add `Sync-AzSynapseIntegrationRuntimeCredential` cmdlet
    - Add `Update-AzSynapseIntegrationRuntime` cmdlet
    - Add `Update-AzSynapseIntegrationRuntimeNode` cmdlet

## Version 0.1.2

* Changed some property names and types of output for the following cmdlets
    - For `Get-AzSynapseSparkJob`, `Submit-AzSynapseSparkJob`, ` Get-AzSynapseSparkSession` and `Start-AzSynapseSparkSession` cmdlet
        - Change JobType's type from `string` to `SparkJobType?`
        - Change AppInfo's type from `IDictionary<string, string>` to `IReadOnlyDictionary<string, string>`
        - Change ErrorInfo's type from `IList<ErrorInformation>` to `IReadOnlyList<SparkServiceError>`
        - Change Log's type from `IList<string>` to `IReadOnlyList<string>`
        - Change `Scheduler` to `Scheduler`
        - Change `PluginInfo` to `Plugin`
        - Change `ErrorInfo` to `Errors`
        - Change `Log` to `LogLines`
* Added support for operation of Synapse access control
    - Add `Get-AzSynapseRoleDefinition` cmdlet
    - Add `New-AzSynapseRoleAssignment` cmdlet
    - Add `Remove-AzSynapseRoleAssignment` cmdlet
    - Add `Get-AzSynapseRoleAssignment` cmdlet

## Version 0.1.1

* Added support for operation of Synapse FirewallRule
    - Add `New-AzSynapseFirewallRule` cmdlet 
    - Add `Remove-AzSynapseFirewallRule` cmdlet 
    - Add `Get-AzSynapseFirewallRule` cmdlet 
    - Add `Update-AzSynapseFirewallRule` cmdlet 
* Removed '-DisallowAllConnection' parameter from the 'New-AzSynapseWorkspace' cmdlet
* Updated parameter set for New-AzSynapseSparkPool to fix node count issue for auto scale

## Version 0.1.0

* Preview release of `Az.Synapse` module
