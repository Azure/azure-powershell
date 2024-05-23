---
Module Name: Az.Synapse
Module Guid: 89eceb4f-9916-4ec5-8499-d5cca97a9cae
Download Help Link: https://learn.microsoft.com/powershell/module/az.synapse
Help Version: 0.0.1.0
Locale: en-US
---

# Az.Synapse Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Azure Synapse Analytics.

## Az.Synapse Cmdlets
### [Add-AzSynapseDataFlowDebugSessionPackage](Add-AzSynapseDataFlowDebugSessionPackage.md)
Add data flow resource and its dependencies into specific data flow debug session.

### [Add-AzSynapseKustoPoolLanguageExtension](Add-AzSynapseKustoPoolLanguageExtension.md)
Add a list of language extensions that can run within KQL queries.

### [Add-AzSynapseTriggerSubscription](Add-AzSynapseTriggerSubscription.md)
Subscribe the event trigger to external service events.

### [Clear-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline](Clear-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline.md)
Clears the vulnerability assessment rule baseline.

### [Convert-AzSynapseSqlPoolVulnerabilityAssessmentScan](Convert-AzSynapseSqlPoolVulnerabilityAssessmentScan.md)
Converts a vulnerability assessment scan results to Excel format.

### [Disable-AzSynapseActiveDirectoryOnlyAuthentication](Disable-AzSynapseActiveDirectoryOnlyAuthentication.md)
Disables Microsoft Entra-only authentication for a specific Synapse workspace.

### [Disable-AzSynapseSqlAdvancedDataSecurity](Disable-AzSynapseSqlAdvancedDataSecurity.md)
Disables Advanced Data Security on a workspace.

### [Disable-AzSynapseSqlPoolSensitivityRecommendation](Disable-AzSynapseSqlPoolSensitivityRecommendation.md)
Disables (dismisses) sensitivity recommendations on columns in the SQL pool.

### [Enable-AzSynapseActiveDirectoryOnlyAuthentication](Enable-AzSynapseActiveDirectoryOnlyAuthentication.md)
Enables Microsoft Entra-only authentication for a specific Synapse workspace.

### [Enable-AzSynapseSqlAdvancedDataSecurity](Enable-AzSynapseSqlAdvancedDataSecurity.md)
Enables Advanced Data Security on a workspace.

### [Enable-AzSynapseSqlPoolSensitivityRecommendation](Enable-AzSynapseSqlPoolSensitivityRecommendation.md)
Enables sensitivity recommendations on columns (recommendations are enabled by default on all columns) in the SQL pool.

### [Enable-AzSynapseWorkspace](Enable-AzSynapseWorkspace.md)
When creating an Azure Synapse Analytics workspace, you can choose to encrypt all data at rest in the workspace `with a customer-managed key which will provide double encryption to the workspace.You may need to set up the encryption environment firstly, such as to create a key vault with purge protection enable and specify Access Polices to the key vault. Then use this cmdlet to activate the new Azure Synapse Analytics workspace which double encryption is enabled using a customer-managed key.

### [Export-AzSynapseKqlScript](Export-AzSynapseKqlScript.md)
Exports KQL script.

### [Export-AzSynapseNotebook](Export-AzSynapseNotebook.md)
Exports notbooks.

### [Export-AzSynapseSparkConfiguration](Export-AzSynapseSparkConfiguration.md)
Exports a Synapse spark configuration to an output folder.

### [Export-AzSynapseSqlScript](Export-AzSynapseSqlScript.md)
Exports a sql script from a Synapse workspace.

### [Get-AzSynapseActiveDirectoryOnlyAuthentication](Get-AzSynapseActiveDirectoryOnlyAuthentication.md)
Gets Microsoft Entra-only authentication for a specific Synapse workspace.

### [Get-AzSynapseActivityRun](Get-AzSynapseActivityRun.md)
Gets information about activity runs for a pipeline run.

### [Get-AzSynapseDataFlow](Get-AzSynapseDataFlow.md)
Gets information about data flows in workspace.

### [Get-AzSynapseDataFlowDebugSession](Get-AzSynapseDataFlowDebugSession.md)
Get all active data flow debug sessions in specified Synapse workspace.

### [Get-AzSynapseDataset](Get-AzSynapseDataset.md)
Gets information about datasets in workspace.

### [Get-AzSynapseDroppedSqlPool](Get-AzSynapseDroppedSqlPool.md)
Gets a dropped Sql pool backup of a Synapse Sql Pool.

### [Get-AzSynapseFirewallRule](Get-AzSynapseFirewallRule.md)
Gets a Synapse Analytics Firewall Rule.

### [Get-AzSynapseIntegrationRuntime](Get-AzSynapseIntegrationRuntime.md)
Gets information about integration runtime resources.

### [Get-AzSynapseIntegrationRuntimeKey](Get-AzSynapseIntegrationRuntimeKey.md)
Gets keys for a self-hosted integration runtime.

### [Get-AzSynapseIntegrationRuntimeMetric](Get-AzSynapseIntegrationRuntimeMetric.md)
Gets metric data for an integration runtime. 

### [Get-AzSynapseIntegrationRuntimeNode](Get-AzSynapseIntegrationRuntimeNode.md)
Gets an integration runtime node information.

### [Get-AzSynapseKqlScript](Get-AzSynapseKqlScript.md)
Gets information about KQL scripts in a workspace.

### [Get-AzSynapseKustoPool](Get-AzSynapseKustoPool.md)
Gets a Kusto pool.

### [Get-AzSynapseKustoPoolAttachedDatabaseConfiguration](Get-AzSynapseKustoPoolAttachedDatabaseConfiguration.md)
Returns an attached database configuration.

### [Get-AzSynapseKustoPoolDatabase](Get-AzSynapseKustoPoolDatabase.md)
Returns a database.

### [Get-AzSynapseKustoPoolDatabasePrincipalAssignment](Get-AzSynapseKustoPoolDatabasePrincipalAssignment.md)
Gets a Kusto pool database principalAssignment.

### [Get-AzSynapseKustoPoolDataConnection](Get-AzSynapseKustoPoolDataConnection.md)
Returns a data connection.

### [Get-AzSynapseKustoPoolFollowerDatabase](Get-AzSynapseKustoPoolFollowerDatabase.md)
Returns a list of databases that are owned by this Kusto Pool and were followed by another Kusto Pool.

### [Get-AzSynapseKustoPoolLanguageExtension](Get-AzSynapseKustoPoolLanguageExtension.md)
Returns a list of language extensions that can run within KQL queries.

### [Get-AzSynapseKustoPoolPrincipalAssignment](Get-AzSynapseKustoPoolPrincipalAssignment.md)
Gets a Kusto pool principalAssignment.

### [Get-AzSynapseKustoPoolSku](Get-AzSynapseKustoPoolSku.md)
Lists eligible SKUs for Kusto Pool resource.

### [Get-AzSynapseLinkConnection](Get-AzSynapseLinkConnection.md)
Gets information about link connections in workspace.

### [Get-AzSynapseLinkConnectionDetailedStatus](Get-AzSynapseLinkConnectionDetailedStatus.md)
Gets detail status about a link connection in workspace.

### [Get-AzSynapseLinkConnectionLinkTable](Get-AzSynapseLinkConnectionLinkTable.md)
Gets information about link tables under a link connection.

### [Get-AzSynapseLinkConnectionLinkTableStatus](Get-AzSynapseLinkConnectionLinkTableStatus.md)
Gets status of link tables under a link connection.

### [Get-AzSynapseLinkedService](Get-AzSynapseLinkedService.md)
Gets information about linked services in workspace.

### [Get-AzSynapseManagedIdentitySqlControlSetting](Get-AzSynapseManagedIdentitySqlControlSetting.md)
Gets Managed Identity Sql Control Settings.

### [Get-AzSynapseManagedPrivateEndpoint](Get-AzSynapseManagedPrivateEndpoint.md)
Gets information about mananged private endpoints in a workspace

### [Get-AzSynapseNotebook](Get-AzSynapseNotebook.md)
Gets information about notebooks in a workspace.

### [Get-AzSynapsePipeline](Get-AzSynapsePipeline.md)
Gets information about pipelines in workspace.

### [Get-AzSynapsePipelineRun](Get-AzSynapsePipelineRun.md)
Gets information about pipeline runs.

### [Get-AzSynapseRoleAssignment](Get-AzSynapseRoleAssignment.md)
Gets a Synapse Analytics role assignment.

### [Get-AzSynapseRoleDefinition](Get-AzSynapseRoleDefinition.md)
Gets a Synapse Analytics role definition.

### [Get-AzSynapseRoleScope](Get-AzSynapseRoleScope.md)
Gets a Synapse Analytics role scope.

### [Get-AzSynapseSparkConfiguration](Get-AzSynapseSparkConfiguration.md)
Gets information about spark configurations in a workspace.

### [Get-AzSynapseSparkJob](Get-AzSynapseSparkJob.md)
Gets a Synapse Analytics Spark job.

### [Get-AzSynapseSparkJobDefinition](Get-AzSynapseSparkJobDefinition.md)
Gets a Spark job definition in workspace.

### [Get-AzSynapseSparkPool](Get-AzSynapseSparkPool.md)
Gets a Apache Spark pool in Azure Synapse Analytics.

### [Get-AzSynapseSparkSession](Get-AzSynapseSparkSession.md)
Gets a Synapse Analytics Spark session.

### [Get-AzSynapseSparkStatement](Get-AzSynapseSparkStatement.md)
Gets a Synapse Analytics Spark statement.

### [Get-AzSynapseSqlActiveDirectoryAdministrator](Get-AzSynapseSqlActiveDirectoryAdministrator.md)
Gets information about a Microsoft Entra administrator for Synapse Analytics Workspace.

### [Get-AzSynapseSqlAdvancedDataSecurityPolicy](Get-AzSynapseSqlAdvancedDataSecurityPolicy.md)
Gets Advanced Data Security policy of a workspace.

### [Get-AzSynapseSqlAdvancedThreatProtectionSetting](Get-AzSynapseSqlAdvancedThreatProtectionSetting.md)
Gets the advanced threat protection settings for a workspace.

### [Get-AzSynapseSqlAuditSetting](Get-AzSynapseSqlAuditSetting.md)
Gets the auditing settings of an Azure Synapse Analytics Workspace.

### [Get-AzSynapseSqlDatabase](Get-AzSynapseSqlDatabase.md)
This feature is in a limited preview, initially accessible only to certain subscriptions. Gets a Synapse Analytics SQL database.

### [Get-AzSynapseSqlPool](Get-AzSynapseSqlPool.md)
Gets a Synapse Analytics SQL pool.

### [Get-AzSynapseSqlPoolAdvancedThreatProtectionSetting](Get-AzSynapseSqlPoolAdvancedThreatProtectionSetting.md)
Gets the advanced threat protection settings for a SQL pool.

### [Get-AzSynapseSqlPoolAuditSetting](Get-AzSynapseSqlPoolAuditSetting.md)
Gets the auditing settings of an Azure Synapse Analytics SQL pool.

### [Get-AzSynapseSqlPoolGeoBackup](Get-AzSynapseSqlPoolGeoBackup.md)
Gets a geo-redundant backup of a Sql Pool.

### [Get-AzSynapseSqlPoolRestorePoint](Get-AzSynapseSqlPoolRestorePoint.md)
Retrieves the distinct restore points from which a Synapse Analytics SQL pool can be restored.

### [Get-AzSynapseSqlPoolSensitivityClassification](Get-AzSynapseSqlPoolSensitivityClassification.md)
Gets the current information types and sensitivity labels of columns in the SQL pool.

### [Get-AzSynapseSqlPoolSensitivityRecommendation](Get-AzSynapseSqlPoolSensitivityRecommendation.md)
Gets the recommended information types and sensitivity labels of columns in the SQL pool.

### [Get-AzSynapseSqlPoolTransparentDataEncryption](Get-AzSynapseSqlPoolTransparentDataEncryption.md)
Gets the TDE state for a SQL pool.

### [Get-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline](Get-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline.md)
Gets the vulnerability assessment rule baseline.

### [Get-AzSynapseSqlPoolVulnerabilityAssessmentScanRecord](Get-AzSynapseSqlPoolVulnerabilityAssessmentScanRecord.md)
Gets all vulnerability assessment scan record(s) associated with a given sql pool.

### [Get-AzSynapseSqlPoolVulnerabilityAssessmentSetting](Get-AzSynapseSqlPoolVulnerabilityAssessmentSetting.md)
Gets the vulnerability assessment settings of a SQL pool.

### [Get-AzSynapseSqlScript](Get-AzSynapseSqlScript.md)
Gets information about sql scripts in a Synapse workspace.

### [Get-AzSynapseSqlVulnerabilityAssessmentSetting](Get-AzSynapseSqlVulnerabilityAssessmentSetting.md)
Gets the vulnerability assessment settings of a workspace.

### [Get-AzSynapseTrigger](Get-AzSynapseTrigger.md)
Gets information about triggers in a workspace.

### [Get-AzSynapseTriggerRun](Get-AzSynapseTriggerRun.md)
Returns information about trigger runs.

### [Get-AzSynapseTriggerSubscriptionStatus](Get-AzSynapseTriggerSubscriptionStatus.md)
Get the status of the subscription for the event trigger to the specified external service events.

### [Get-AzSynapseWorkspace](Get-AzSynapseWorkspace.md)
Gets a Synapse Analytics workspace.

### [Get-AzSynapseWorkspaceKey](Get-AzSynapseWorkspaceKey.md)
Gets a workspace key.

### [Get-AzSynapseWorkspacePackage](Get-AzSynapseWorkspacePackage.md)
Gets a workspace package.

### [Invoke-AzSynapseDataFlowDebugSessionCommand](Invoke-AzSynapseDataFlowDebugSessionCommand.md)
Invoke debug action in data flow debug session.

### [Invoke-AzSynapseDetachKustoPoolFollowerDatabase](Invoke-AzSynapseDetachKustoPoolFollowerDatabase.md)
Detaches all followers of a database owned by this Kusto Pool.

### [Invoke-AzSynapseIntegrationRuntimeUpgrade](Invoke-AzSynapseIntegrationRuntimeUpgrade.md)
Upgrades self-hosted integration runtime.

### [Invoke-AzSynapsePipeline](Invoke-AzSynapsePipeline.md)
Invokes a pipeline to start a run for it.

### [Invoke-AzSynapseSparkStatement](Invoke-AzSynapseSparkStatement.md)
Invokes a Synapse Analytics Spark statement.

### [Invoke-AzSynapseTriggerRun](Invoke-AzSynapseTriggerRun.md)
Invokes another instance of a trigger run.

### [New-AzSynapseFirewallRule](New-AzSynapseFirewallRule.md)
Creates a Synapse Analytics Firewall Rule.

### [New-AzSynapseGitRepositoryConfig](New-AzSynapseGitRepositoryConfig.md)
Creates Git repository configuration.

### [New-AzSynapseIntegrationRuntimeKey](New-AzSynapseIntegrationRuntimeKey.md)
Regenerate self-hosted integration runtime key.

### [New-AzSynapseKqlScript](New-AzSynapseKqlScript.md)
Creates or updates a KQL script in a workspace.

### [New-AzSynapseKustoPool](New-AzSynapseKustoPool.md)
Create or update a Kusto pool.

### [New-AzSynapseKustoPoolAttachedDatabaseConfiguration](New-AzSynapseKustoPoolAttachedDatabaseConfiguration.md)
Creates or updates an attached database configuration.

### [New-AzSynapseKustoPoolDatabase](New-AzSynapseKustoPoolDatabase.md)
Creates or updates a database.

### [New-AzSynapseKustoPoolDatabasePrincipalAssignment](New-AzSynapseKustoPoolDatabasePrincipalAssignment.md)
Creates a Kusto pool database principalAssignment.

### [New-AzSynapseKustoPoolDataConnection](New-AzSynapseKustoPoolDataConnection.md)
Creates or updates a data connection.

### [New-AzSynapseKustoPoolPrincipalAssignment](New-AzSynapseKustoPoolPrincipalAssignment.md)
Create a Kusto pool principalAssignment.

### [New-AzSynapseLinkedServiceEncryptedCredential](New-AzSynapseLinkedServiceEncryptedCredential.md)
Encrypt credential in linked service with specified integration runtime.

### [New-AzSynapseManagedPrivateEndpoint](New-AzSynapseManagedPrivateEndpoint.md)
Creates or updates a managed private endpoint in a workspace.

### [New-AzSynapseManagedVirtualNetworkConfig](New-AzSynapseManagedVirtualNetworkConfig.md)
Creates managed virtual network configuration.

### [New-AzSynapseRoleAssignment](New-AzSynapseRoleAssignment.md)
Creates a Synapse Analytics role assignment.
 

### [New-AzSynapseSparkConfiguration](New-AzSynapseSparkConfiguration.md)
Creates or updates a spark configuration in a workspace.

### [New-AzSynapseSparkPool](New-AzSynapseSparkPool.md)
Creates a Synapse Analytics Spark pool.

### [New-AzSynapseSqlDatabase](New-AzSynapseSqlDatabase.md)
This feature is in a limited preview, initially accessible only to certain subscriptions. Creates a Synapse Analytics SQL database.

### [New-AzSynapseSqlPool](New-AzSynapseSqlPool.md)
Creates a Synapse Analytics SQL pool.

### [New-AzSynapseSqlPoolRestorePoint](New-AzSynapseSqlPoolRestorePoint.md)
Creates a new restore point in an Azure Synapse Analytics SQL pool.

### [New-AzSynapseWorkspace](New-AzSynapseWorkspace.md)
Creates a Synapse Analytics workspace.

### [New-AzSynapseWorkspaceKey](New-AzSynapseWorkspaceKey.md)
Creates a workspace key.

### [New-AzSynapseWorkspacePackage](New-AzSynapseWorkspacePackage.md)
Uploads a local workspace package file to an Azure Synapse workspace.

### [Remove-AzSynapseDataFlow](Remove-AzSynapseDataFlow.md)
Removes a data flow from workspace.

### [Remove-AzSynapseDataset](Remove-AzSynapseDataset.md)
Removes a dataset from workspace.

### [Remove-AzSynapseFirewallRule](Remove-AzSynapseFirewallRule.md)
Deletes a Synapse Analytics Firewall Rule.

### [Remove-AzSynapseIntegrationRuntime](Remove-AzSynapseIntegrationRuntime.md)
Removes an integration runtime.

### [Remove-AzSynapseIntegrationRuntimeNode](Remove-AzSynapseIntegrationRuntimeNode.md)
Remove a node with the given name on an integration runtime.

### [Remove-AzSynapseKqlScript](Remove-AzSynapseKqlScript.md)
Removes a KQL script from a workspace.

### [Remove-AzSynapseKustoPool](Remove-AzSynapseKustoPool.md)
Deletes a Kusto pool.

### [Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration](Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration.md)
Deletes the attached database configuration with the given name.

### [Remove-AzSynapseKustoPoolDatabase](Remove-AzSynapseKustoPoolDatabase.md)
Deletes the database with the given name.

### [Remove-AzSynapseKustoPoolDatabasePrincipalAssignment](Remove-AzSynapseKustoPoolDatabasePrincipalAssignment.md)
Deletes a Kusto pool principalAssignment.

### [Remove-AzSynapseKustoPoolDataConnection](Remove-AzSynapseKustoPoolDataConnection.md)
Deletes the data connection with the given name.

### [Remove-AzSynapseKustoPoolLanguageExtension](Remove-AzSynapseKustoPoolLanguageExtension.md)
Remove a list of language extensions that can run within KQL queries.

### [Remove-AzSynapseKustoPoolPrincipalAssignment](Remove-AzSynapseKustoPoolPrincipalAssignment.md)
Deletes a Kusto pool principalAssignment.

### [Remove-AzSynapseLinkConnection](Remove-AzSynapseLinkConnection.md)
Deletes a link connection from workspace.

### [Remove-AzSynapseLinkedService](Remove-AzSynapseLinkedService.md)
Removes a linked service from workspace.

### [Remove-AzSynapseManagedPrivateEndpoint](Remove-AzSynapseManagedPrivateEndpoint.md)
Removes a managed private endpoint from a workspace.

### [Remove-AzSynapseNotebook](Remove-AzSynapseNotebook.md)
Removes a notebook from a workspace.

### [Remove-AzSynapsePipeline](Remove-AzSynapsePipeline.md)
Removes a pipeline from workspace.

### [Remove-AzSynapseRoleAssignment](Remove-AzSynapseRoleAssignment.md)
Deletes a Synapse Analytics role assignment.

### [Remove-AzSynapseSparkConfiguration](Remove-AzSynapseSparkConfiguration.md)
Removes a spark configuration from a workspace.

### [Remove-AzSynapseSparkJobDefinition](Remove-AzSynapseSparkJobDefinition.md)
Removes a Spark job definition from workspace.

### [Remove-AzSynapseSparkPool](Remove-AzSynapseSparkPool.md)
Deletes a Apache Spark pool in Azure Synapse Analytics.

### [Remove-AzSynapseSqlActiveDirectoryAdministrator](Remove-AzSynapseSqlActiveDirectoryAdministrator.md)
Removes a Microsoft Entra administrator for Synapse Analytics Workspace.

### [Remove-AzSynapseSqlDatabase](Remove-AzSynapseSqlDatabase.md)
This feature is in a limited preview, initially accessible only to certain subscriptions. Deletes a Synapse Analytics SQL database.

### [Remove-AzSynapseSqlPool](Remove-AzSynapseSqlPool.md)
Deletes a Synapse Analytics SQL pool.

### [Remove-AzSynapseSqlPoolRestorePoint](Remove-AzSynapseSqlPoolRestorePoint.md)
Deletes a Synapse Analytics SQL pool restore point.

### [Remove-AzSynapseSqlPoolSensitivityClassification](Remove-AzSynapseSqlPoolSensitivityClassification.md)
Removes the information types and sensitivity labels of columns in the SQL pool.

### [Remove-AzSynapseSqlScript](Remove-AzSynapseSqlScript.md)
Removes a sql script from a Synapse workspace.

### [Remove-AzSynapseTrigger](Remove-AzSynapseTrigger.md)
Removes a trigger from a workspace.

### [Remove-AzSynapseTriggerSubscription](Remove-AzSynapseTriggerSubscription.md)
Unsubscribe the event trigger to external service events.

### [Remove-AzSynapseWorkspace](Remove-AzSynapseWorkspace.md)
Deletes a Synapse Analytics workspace.

### [Remove-AzSynapseWorkspaceKey](Remove-AzSynapseWorkspaceKey.md)
Deletes a workspace key.

### [Remove-AzSynapseWorkspacePackage](Remove-AzSynapseWorkspacePackage.md)
Deletes a workspace package.

### [Reset-AzSynapseSparkSessionTimeout](Reset-AzSynapseSparkSessionTimeout.md)
Resets timeout of a Synapse Analytics Spark session.

### [Reset-AzSynapseSqlAdvancedThreatProtectionSetting](Reset-AzSynapseSqlAdvancedThreatProtectionSetting.md)
Removes the advanced threat protection settings from a workspace.

### [Reset-AzSynapseSqlAuditSetting](Reset-AzSynapseSqlAuditSetting.md)
Removes the auditing settings of an Azure Synapse Analytics Workspace.

### [Reset-AzSynapseSqlPoolAdvancedThreatProtectionSetting](Reset-AzSynapseSqlPoolAdvancedThreatProtectionSetting.md)
Removes the advanced threat protection settings from a SQL pool.

### [Reset-AzSynapseSqlPoolAuditSetting](Reset-AzSynapseSqlPoolAuditSetting.md)
Removes the auditing settings of an Azure Synapse Analytics SQL pool.

### [Reset-AzSynapseSqlPoolVulnerabilityAssessmentSetting](Reset-AzSynapseSqlPoolVulnerabilityAssessmentSetting.md)
Clears the vulnerability assessment settings of a SQL pool.

### [Reset-AzSynapseSqlVulnerabilityAssessmentSetting](Reset-AzSynapseSqlVulnerabilityAssessmentSetting.md)
Clears the vulnerability assessment settings of a workspace.

### [Restore-AzSynapseSqlPool](Restore-AzSynapseSqlPool.md)
Restores a Synapse Analytics SQL pool.

### [Resume-AzSynapseSqlPool](Resume-AzSynapseSqlPool.md)
Resumes a Synapse Analytics SQL pool.

### [Set-AzSynapseDataFlow](Set-AzSynapseDataFlow.md)
Creates or updates a data flow in workspace.

### [Set-AzSynapseDataset](Set-AzSynapseDataset.md)
Creates or updates a dataset in workspace.

### [Set-AzSynapseIntegrationRuntime](Set-AzSynapseIntegrationRuntime.md)
Updates an integration runtime.

### [Set-AzSynapseLinkConnection](Set-AzSynapseLinkConnection.md)
Creates or updates a link connection in workspace.

### [Set-AzSynapseLinkConnectionLinkTable](Set-AzSynapseLinkConnectionLinkTable.md)
Edits link tables under a link connection.

### [Set-AzSynapseLinkedService](Set-AzSynapseLinkedService.md)
Links a data store or a cloud service to workspace.

### [Set-AzSynapseManagedIdentitySqlControlSetting](Set-AzSynapseManagedIdentitySqlControlSetting.md)
Updates managed identity SQL control settings to workspace.

### [Set-AzSynapseNotebook](Set-AzSynapseNotebook.md)
Creates or updates a notebook in a workspace.

### [Set-AzSynapsePipeline](Set-AzSynapsePipeline.md)
Creates a pipeline in workspace.

### [Set-AzSynapseSparkJobDefinition](Set-AzSynapseSparkJobDefinition.md)
Creates a Spark job definition in workspace.

### [Set-AzSynapseSqlActiveDirectoryAdministrator](Set-AzSynapseSqlActiveDirectoryAdministrator.md)
Provisions a Microsoft Entra administrator for Synapse Analytics SQL pool.

### [Set-AzSynapseSqlAuditSetting](Set-AzSynapseSqlAuditSetting.md)
Changes the auditing settings of an Azure Synapse Analytics Workspace.

### [Set-AzSynapseSqlPoolAuditSetting](Set-AzSynapseSqlPoolAuditSetting.md)
Changes the auditing settings for an Azure Synapse Analytics SQL pool.

### [Set-AzSynapseSqlPoolSensitivityClassification](Set-AzSynapseSqlPoolSensitivityClassification.md)
Sets the information types and sensitivity labels of columns in the SQL pool.

### [Set-AzSynapseSqlPoolTransparentDataEncryption](Set-AzSynapseSqlPoolTransparentDataEncryption.md)
Modifies TDE property for a SQL pool.

### [Set-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline](Set-AzSynapseSqlPoolVulnerabilityAssessmentRuleBaseline.md)
Sets the vulnerability assessment rule baseline.

### [Set-AzSynapseSqlScript](Set-AzSynapseSqlScript.md)
Creates or updates a SQL script in a workspace.

### [Set-AzSynapseTrigger](Set-AzSynapseTrigger.md)
Creates a trigger in a workspace.

### [Start-AzSynapseDataFlowDebugSession](Start-AzSynapseDataFlowDebugSession.md)
Starts a Synapse Analytics data flow debug session in Synapse Workspace.

### [Start-AzSynapseIntegrationRuntime](Start-AzSynapseIntegrationRuntime.md)
Starts a managed dedicated integration runtime.

### [Start-AzSynapseKustoPool](Start-AzSynapseKustoPool.md)
Starts a Kusto pool.

### [Start-AzSynapseLinkConnection](Start-AzSynapseLinkConnection.md)
Starts a link connection.

### [Start-AzSynapseSparkSession](Start-AzSynapseSparkSession.md)
Starts a Synapse Analytics Spark session.

### [Start-AzSynapseSqlPoolVulnerabilityAssessmentScan](Start-AzSynapseSqlPoolVulnerabilityAssessmentScan.md)
Starts a vulnerability assessment scan.

### [Start-AzSynapseTrigger](Start-AzSynapseTrigger.md)
Starts a trigger in a workspace.

### [Stop-AzSynapseDataFlowDebugSession](Stop-AzSynapseDataFlowDebugSession.md)
Stops a data flow debug session in a workspace.

### [Stop-AzSynapseIntegrationRuntime](Stop-AzSynapseIntegrationRuntime.md)
Stops a managed dedicated integration runtime.

### [Stop-AzSynapseKustoPool](Stop-AzSynapseKustoPool.md)
Stops a Kusto pool.

### [Stop-AzSynapseLinkConnection](Stop-AzSynapseLinkConnection.md)
Stops a link connection.

### [Stop-AzSynapsePipelineRun](Stop-AzSynapsePipelineRun.md)
Stops a pipeline run in a workspace.

### [Stop-AzSynapseSparkJob](Stop-AzSynapseSparkJob.md)
Cancels a Synapse Analytics Spark job.

### [Stop-AzSynapseSparkSession](Stop-AzSynapseSparkSession.md)
Stops a Synapse Analytics Spark session.

### [Stop-AzSynapseSparkStatement](Stop-AzSynapseSparkStatement.md)
Cancels a Synapse Analytics Spark statement.

### [Stop-AzSynapseTrigger](Stop-AzSynapseTrigger.md)
Stops a trigger in a workspace.

### [Stop-AzSynapseTriggerRun](Stop-AzSynapseTriggerRun.md)
Stops a trigger run in a synapse workspace.

### [Submit-AzSynapseSparkJob](Submit-AzSynapseSparkJob.md)
Submits a Synapse Analytics Spark job.

### [Suspend-AzSynapseSqlPool](Suspend-AzSynapseSqlPool.md)
Suspends a Synapse Analytics SQL pool.

### [Sync-AzSynapseIntegrationRuntimeCredential](Sync-AzSynapseIntegrationRuntimeCredential.md)
Synchronizes credentials among integration runtime nodes.

### [Test-AzSynapseSparkPool](Test-AzSynapseSparkPool.md)
Checks for the existence of a Synapse Analytics Spark pool.

### [Test-AzSynapseSqlDatabase](Test-AzSynapseSqlDatabase.md)
This feature is in a limited preview, initially accessible only to certain subscriptions. Checks for the existence of a Synapse Analytics SQL database.

### [Test-AzSynapseSqlPool](Test-AzSynapseSqlPool.md)
Checks for the existence of a Synapse Analytics SQL pool.

### [Test-AzSynapseWorkspace](Test-AzSynapseWorkspace.md)
Checks for the existence of a Synapse Analytics workspace.

### [Update-AzSynapseFirewallRule](Update-AzSynapseFirewallRule.md)
Updates a Synapse Analytics Firewall Rule.

### [Update-AzSynapseIntegrationRuntime](Update-AzSynapseIntegrationRuntime.md)
Updates an integration runtime.

### [Update-AzSynapseIntegrationRuntimeNode](Update-AzSynapseIntegrationRuntimeNode.md)
Updates self-hosted integration runtime node.

### [Update-AzSynapseKustoPool](Update-AzSynapseKustoPool.md)
Update a Kusto Kusto Pool.

### [Update-AzSynapseKustoPoolDatabase](Update-AzSynapseKustoPoolDatabase.md)
Updates a database.

### [Update-AzSynapseKustoPoolDataConnection](Update-AzSynapseKustoPoolDataConnection.md)
Updates a data connection.

### [Update-AzSynapseLinkConnectionLandingZoneCredential](Update-AzSynapseLinkConnectionLandingZoneCredential.md)
Updates the landing zone credential of a link connection.

### [Update-AzSynapseManagedVirtualNetworkConfig](Update-AzSynapseManagedVirtualNetworkConfig.md)
Updates managed virtual network configuration to workspace.

### [Update-AzSynapseSparkPool](Update-AzSynapseSparkPool.md)
Updates a Apache Spark pool in Azure Synapse Analytics.

### [Update-AzSynapseSqlAdvancedThreatProtectionSetting](Update-AzSynapseSqlAdvancedThreatProtectionSetting.md)
Updates an advanced threat protection settings on a workspace.

### [Update-AzSynapseSqlDatabase](Update-AzSynapseSqlDatabase.md)
This feature is in a limited preview, initially accessible only to certain subscriptions. Updates a Synapse Analytics SQL database.

### [Update-AzSynapseSqlPool](Update-AzSynapseSqlPool.md)
Updates a Synapse Analytics SQL pool.

### [Update-AzSynapseSqlPoolAdvancedThreatProtectionSetting](Update-AzSynapseSqlPoolAdvancedThreatProtectionSetting.md)
Sets a advanced threat protection settings on a SQL pool.

### [Update-AzSynapseSqlPoolVulnerabilityAssessmentSetting](Update-AzSynapseSqlPoolVulnerabilityAssessmentSetting.md)
Updates the vulnerability assessment settings of a SQL pool.

### [Update-AzSynapseSqlVulnerabilityAssessmentSetting](Update-AzSynapseSqlVulnerabilityAssessmentSetting.md)
Updates the vulnerability assessment settings of a workspace.

### [Update-AzSynapseWorkspace](Update-AzSynapseWorkspace.md)
Updates a Synapse Analytics workspace.

### [Wait-AzSynapseSparkJob](Wait-AzSynapseSparkJob.md)
Waits for a Synapse Analytics Spark job to complete.

