// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class HelpMessages
    {
        public const string ResourceGroupName = "Resource group name.";

        public const string ScanId = "Scan Id.";

        public const string Location = "Azure region where the resource should be created.";

        public const string WorkspaceName = "Name of Synapse workspace.";

        public const string WorkspaceResourceId = "Resource identifier of Synapse workspace.";

        public const string WorkspaceObject = "workspace input object, usually passed through the pipeline.";

        public const string ManagedResourceGroupName = "A container that holds ancillary resources. Created by default while the name can be specified. Note that this group must be different with ResourceGroupName.";

        public const string DefaultDataLakeStorageAccountName = "The default ADLS Gen2 storage account name.";

        public const string DefaultDataLakeStorageFilesystem = "The default ADLS Gen2 file system.";

        public const string DeletionDate = "The deletion date of the Azure Synaspe SQL Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)";

        public const string ManagedVirtualNetwork = "Managed Virtual Network Settings.";

        public const string DisallowAllConnection = "Azure Synapse Studio and other client tools will only be able to connect to the workspace endpoints if this parameter is not present. Connections from specific IP addresses or all Azure services can be allowed/disallowed after the workspace is provisioned.";

        public const string SqlAdministratorLoginCredential = "SQL administrator credentials.";

        public const string GitRepository = "Git Repository Settings. Connect workspace to the repository for source control and collaboration for work on your workspace pipelines";

        public const string PublicNetworkAccess = "Enable or Disable public network access to workspace. Possible values include: 'Enabled', 'Disabled'";

        public const string UserAssignedIdentityAction = 
@"Action must be specified when you add/remove/set user assigned managed identities for workspace. 
The supported actions are:
Add
Remove
Set
Add means to add user assigned managed identities for workspace, Remove means to remove user assigned managed identities from workspace, Set can be used when you want to add and remove user assigned managed identities at the same time, current identities will be coverd by specified ones.";

        public const string UserAssignedIdentityId = "User assigned managed identity Id for workspace.";

        public const string RepositoryType = "Select the repository type that you want to use to store your artifacts for this Synapse Analytics workspace, the type include DevOps and GitHub.";

        public const string HostName = "GitHub Enterprise host name. For example: https://github.mydomain.com";

        public const string AccountName = "GitHub or DevOps account name used for the repository.";

        public const string ProjectName = "The project name you are connecting, only specify it when you choose DevOps.";

        public const string RepositoryName = "The name of the repository you are connecting.";

        public const string CollaborationBranch = "Select the branch name where you will collaborate with others and from which you will publish.";

        public const string PublishBranch = "The publish branch is the branch in your repository where publishing related ARM templates are stored and update. The default value is workspace_publish.";

        public const string RootFolder = "Displays the name of the folder to the location of your Azure Data Factory JSON resources are imported. The default value is /";

        public const string TenantId = "Select the tenant Id to use when signing in into the Azure DevOps Git repository.";

        public const string LastCommitId = "The last published commit Id.";

        public const string DoNotAssignManagedIdentity = "Do not assign the workspace's system-assigned managed identity CONTROL permissions to SQL pools for pipeline integration.";

        public const string SparkPoolName = "Name of Synapse Spark pool.";

        public const string SparkPoolResourceId = "Resource identifier of Synapse Spark pool.";

        public const string SparkPoolObject = "Spark pool input object, usually passed through the pipeline.";

        public const string NodeCount = "Number of nodes to be allocated in the specified Spark pool.";

        public const string NodeSize = "Number of core and memory to be used for nodes allocated in the specified Spark pool. This parameter must be specified when Auto-scale is disabled";

        public const string EnableAutoScale = "Indicates whether Auto-scale should be enabled";

        public const string DisableAutoScale = "Indicates whether Auto-scale should be disabled";

        public const string AutoScaleMinNodeCount = "Minimum number of nodes to be allocated in the specified Spark pool. This parameter must be specified when Auto-scale is enabled.";

        public const string AutoScaleMaxNodeCount = "Maximum number of nodes to be allocated in the specified Spark pool. This parameter must be specified when Auto-scale is enabled.";

        public const string EnableAutoPause = "Indicates whether Auto-pause should be enabled.";

        public const string DisableAutoPause = "Indicates whether Auto-pause should be disabled.";

        public const string AutoPauseDelayInMinute = "Number of minutes idle. This parameter can be specified when Auto-pause is enabled. If it is not specified manually, the default value will be " + SynapseConstants.DefaultAutoPauseDelayInMinute + ".";

        public const string EnableDynamicExecutorAllocation = "Indicates whether dynamic executor allocation should be enabled.";

        public const string MinExecutorCount = "Minimum number of executors to be allocated in the specified Spark pool. This parameter can be specified when DynamicExecutorAllocation is enabled. The value should lie between 1 (inclusive) and maxExecutors (exclusive). If it is not specified manually, the default value will be " + SynapseConstants.DefaultMinExecutorCount + "."; 

        public const string MaxExecutorCount = "Maximum number of executors to be allocated in the specified Spark pool. This parameter can be specified when DynamicExecutorAllocation is enabled. The value should lie between 1 (inclusive) and maximumNodeCount (exclusive). If it is not specified manually, the default value will be " + SynapseConstants.DefaultMaxExecutorCount + ".";

        public const string SparkVersion = "Apache Spark version. Allowed values: 2.3,2.4,3.1,3.2";

        public const string LibraryRequirementsFilePath = "Environment configuration file (\"PIP freeze\" output).";

        public const string SparkConfigPropertiesFilePath = "Spark pool properties configuration file.";

        public const string Batch = "Indicates Spark batch.";

        public const string SparkJobName = "Name of Spark job.";

        public const string SparkJobId = "Identifier of Spark job.";

        public const string SparkJobObject = "Spark job input object, usually passed through the pipeline.";

        public const string SparkJobLanguage = "Language of the job to submit.";

        public const string WaitIntervalInSeconds = "The polling interval between checks for the job status, in seconds.";

        public const string TimeoutInSeconds = "The maximum amount of time to wait before erroring out. Default value is to never timeout.";

        public const string MainDefinitionFile = @"The main file used for the job. e.g. ""abfss://filesystem@account.dfs.core.windows.net/mySpark.jar""";

        public const string MainClassName = @"The fully-qualified identifier or the main class that is in the main definition file. Required for Spark and .NET Spark job. e.g. ""org.apache.spark.examples.SparkPi""";

        public const string CommandLineArgument = @"Optional arguments to the job. e.g. ""--iteration 10000 --timeout 20s""";

        public const string ReferenceFile = @"Additional files used for reference in the main definition file. Comma-separated storage URI list. e.g. ""abfss://filesystem@account.dfs.core.windows.net/file1.txt,abfss://filesystem@account.dfs.core.windows.net/result/""";

        public const string ExecutorCount = "Number of executors to be allocated in the specified Spark pool for the job.";

        public const string ExecutorSize = "Number of core and memory to be used for executors allocated in the specified Spark pool for the job.";

        public const string Configuration = "Spark configuration properties.";

        public const string Session = "Indicates Spark session.";

        public const string SessionId = "Identifier of Spark session.";

        public const string SessionName = "Name of Spark session.";

        public const string SparkStatementId = "Identifier of Spark statement.";

        public const string SessionObject = "Spark session input object, usually passed through the pipeline.";

        public const string SessionStatementName = "Name of Spark statement.";

        public const string SessionStatementObject = "Spark statement input object, usually passed through the pipeline.";

        public const string Code = "The execution code.";

        public const string FilePath = "Specifies a local file path that contains the execution code.";

        public const string LanguageForExecutionCode = "Language of the execution code.";

        public const string Force = "Do not ask for confirmation.";

        public const string PassThru = "This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.";

        public const string Response = "Indicates full response should be return.";

        public const string AsJob = "Run cmdlet in the background";

        public const string Tag = "A string,string dictionary of tags associated with the resource.";

        public const string Interactive = "Start Spark session in interactive mode.";

        public const string Top = "An optional value which indicates the number of resources to return.";

        public const string ApplicationId = "The Application identifier of the session.";

        public const string scanRecordObject = "The scan record object to use in order to convert a Vulnerability Assessment scan.";

        public const string SqlDatabaseName = "Name of Synapse SQL Database.";

        public const string SqlDatabaseResourceId = "Resource identifier of Synapse SQL Database.";

        public const string SqlDatabaseObject = "SQL Database input object, usually passed through the pipeline.";

        public const string SqlPoolName = "Name of Synapse SQL pool.";

        public const string SqlPoolRestorePointName = "Name of Synapse SQL pool restore point name.";

        public const string SqlPoolVersion = "Version of Synapse SQL pool. For example, 2 or 3.";

        public const string SqlPoolNewName = "The new name to rename the SQL pool to.";

        public const string SqlPoolResourceId = "Resource identifier of Synapse SQL Pool.";

        public const string SqlPoolRestorePointResourceId = "Resource identifier of Synapse SQL Pool Restore Point.";

        public const string SqlPoolObject = "SQL pool input object, usually passed through the pipeline.";

        public const string SqlPoolRestorePointObject = "SQL pool restore point input object, usually passed through the pipeline.";

        public const string SuspendSqlPool = "Indicates to pause the SQL pool";

        public const string ResumeSqlPool = "Indicates to resume the SQL pool";

        public const string PerformanceLevel = "The SQL Service tier and performance level to assign to the SQL pool. For example, DW2000c.";

        public const string Collation = "Collation defines the rules that sort and compare data, and cannot be changed after SQL pool creation. The default collation is " + SynapseConstants.DefaultCollation + ".";
        
        public const string MaxSizeInBytes = "Specifies the maximum size of the database in bytes.";

        public const string StorageRedundancy = "Storage redundancy of the database.";

        public const string BackupResourceGroupName = "The resource group name of bakcup SQL pool object to create from.";

        public const string BackupWorkspaceName = "The Synapse workspace name of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolName = "The name of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolId = "The resource identifier of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolResourceId = "The resource identifier of backup SQL pool object to restore from.";

        public const string SourceResourceGroupName = "The resource group name of source SQL pool object to create from.";

        public const string SourceWorkspaceName = "The Synapse workspace name of source SQL pool object to create from.";

        public const string SourceSqlPoolName = "The name of source SQL pool object to create from.";

        public const string SourceDatabaseId = "The resource ID of the database to restore.";

        public const string FromBackup = "Indicates to restore from the most recent backup of any SQL pool in this subscription.";

        public const string FromRestorePoint = "Indicates to leverage a restore point from any SQL pool in this subscription to recover or copy from a previous state.";

        public const string RestorePoint = "Snapshot time to restore.";

        public const string RestorePointLabel = "The label we associate a restore point with, may not be unique.";

        public const string SqlAdministratorLoginPassword = "The new SQL administrator password for the workspace.";

        public const string DisplayName = "Specifies the display name of the user or group for whom to grant permissions. This display name must exist in the active directory associated with the current subscription.";

        public const string ObjectId = "Specifies the object ID of the user or group in Azure Active Directory for which to grant permissions.";

        public const string LinkConnectionName = "Name of link connection.";

        public const string MaxSegmentCount = "Max segment count to query table status.";

        public const string SasToken = "Landing zone's sas token.";

        public const string EditTablesRequestFile = "Specifies a local file path for a file to edit link tables";

        public const string LinkTableContinuationToken = "Continuation token to query table status.";

        public const string LinkConnectionObject = "The information about the link connection.";

        // TODO: need to update to Synapse link in future
        public const string AuditActionGroup =
@"The recommended set of action groups to use is the following combination - this will audit all the queries and stored procedures executed against the database, as well as successful and failed logins:  
  
“BATCH_COMPLETED_GROUP“,  
“SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP“,  
“FAILED_DATABASE_AUTHENTICATION_GROUP“  
This above combination is also the set that is configured by default. These groups cover all SQL statements and stored procedures executed against the database, and should not be used in combination with other groups as this will result in duplicate audit logs.
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-action-groups.";

        public const string AuditAction =
@"The set of audit actions.  
The supported actions to audit are:  
SELECT  
UPDATE  
INSERT  
DELETE  
EXECUTE  
RECEIVE  
REFERENCES  
The general form for defining an action to be audited is:
[action] ON [object] BY [principal]
Note that [object] in the above format can refer to an object like a table, view, or stored procedure, or an entire database or schema. For the latter cases, the forms DATABASE::[dbname] and SCHEMA::[schemaname] are used, respectively.
For example:  
SELECT on dbo.myTable by public  
SELECT on DATABASE::myDatabase by public  
SELECT on SCHEMA::mySchema by public  
For more information, see https://docs.microsoft.com/en-us/sql/relational-databases/security/auditing/sql-server-audit-action-groups-and-actions#database-level-audit-actions.";

        public const string PredicateExpression = "The T-SQL predicate (WHERE clause) used to filter audit logs.";

        public const string BlobStorageTargetState = "Indicates whether blob storage is a destination for audit records.";

        public const string AuditStorageAccountResourceId = "The storage account resource id";

        public const string StorageKeyType = "Specifies which of the storage access keys to use.";

        public const string RetentionInDays = "The number of retention days for the audit logs.";

        public const string EventHubTargetState = "Indicates whether event hub is a destination for audit records.";

        public const string EventHubName = "The name of the event hub. If none is specified when providing EventHubAuthorizationRuleResourceId, the default event hub will be selected.";

        public const string EventHubAuthorizationRuleId = "The resource Id for the event hub authorization rule";

        public const string LogAnalyticsTargetState = "Indicates whether log analytics is a destination for audit records.";

        public const string WorkspaceId = "The workspace ID (resource ID of a Log Analytics workspace) for a Log Analytics workspace to which you would like to send Audit Logs. Example: /subscriptions/4b9e8510-67ab-4e9a-95a9-e2f1e570ea9c/resourceGroups/insights-integration/providers/Microsoft.OperationalInsights/workspaces/viruela2";

        public const string NotificationRecipientsEmails = "A semicolon separated list of email addresses to send the alerts to.";

        public const string EmailAdmins = "Defines whether to email administrators.";

        public const string ExcludedDetectionType = "Detection types to exclude.";

        public const string StorageAccountName = "The name of the storage account.";

        public const string ScanResultsStorageAccountName = "The name of the storage account that will hold the scan results.";

        public const string ScanResultsContainerName = "The name of the storage container that will hold the scan results.";

        public const string BlobStorageSasUri = "A SAS URI to a storage container that will hold the scan results.";

        public const string RecurringScansInterval = "The recurring scans interval.";

        public const string ScanEmailAdmins = "A value indicating whether to email service and co-administrators on recurring scan completion.";

        public const string NotificationEmail = "A list of mail addresses to send on recurring scan completion.";

        public const string DoNotConfigureVulnerabilityAssessment = "Do not auto enable Vulnerability Assessment (This will not create a storage account).";

        public const string DeploymentName = "Supply a custom name for Advanced Data Security deployment.";

        public const string TransparentDataEncryptionState = "The Azure Synapse Analytics Sql Pool Transparent Data Encryption state.";

        public const string FirewallRuleName = "The firerwall rule name for the workspace.";

        public const string StartIpAddress = "The start IP address of the firewall rule. Must be IPv4 format.";

        public const string EndIpAddress = "The end IP address of the firewall rule. Must be IPv4 format. Must be greater than or equal to startIpAddress.";

        public const string AllowAllAzureIpRule = "Creates a special firewall rule that permits all Azure IPs to have access. The Start IP is 0.0.0.0. The End IP is 0.0.0.0.";

        public const string AllowAllIpRule = "Creates a special firewall rule that allows connections from all IP addresses. The Start IP is 0.0.0.0. The End IP is 255.255.255.255.";

        public const string RoleAssignmentId = "The ID of the role assignment.";

        public const string RoleDefinitionId = "Id of the Role that is assigned to the principal.";

         public const string RoleDefinitionName = "Name of the Role that is assigned to the principal.";

        public const string PrincipalId = "The Azure AD ObjectId of the User, Group or Service Principal.";

        public const string SignInName = "The email address or the user principal name of the user.";

        public const string ServicePrincipalName = "The ServicePrincipalName of the service principal.";

        public const string IntegrationRuntimeName = "The integration runtime name.";

        public const string IntegrationRuntimeObject = "The integration runtime object.";

        public const string IntegrationRuntimeResourceId = "Resource identifier of Synapse integration runtime.";
    
        public const string IntegrationRuntimeStatus = "The integration runtime detail status.";

        public const string IntegrationRuntimeNodeName = "The integration runtime node name.";

        public const string IntegrationRuntimeNodeIpAddress = "The IP Address of integration runtime node.";

        public const string IntegrationRuntimeKeyName = "The authentication key name of the self-hosted integration runtime.";
    
        public const string DontAskConfirmation = "Don't ask for confirmation.";

        public const string IntegrationRuntimetype = "The integration runtime type.";

        public const string IntegrationRuntimeDescription = "The integration runtime description.";

        public const string IntegrationRuntimeLocation = "The integration runtime description.";

        public const string IntegrationRuntimeNodeSize = "The integration runtime node size.";

        public const string IntegrationRuntimeNodeCount = "Target nodes count of the integration runtime.";

        public const string IntegrationRuntimeCatalogServerEndpoint = "The catalog database server endpoint of the integration runtime.";

        public const string IntegrationRuntimeCatalogAdminCredential = "The catalog database administrator credential of the integration runtime.";

        public const string IntegrationRuntimeCatalogPricingTier = "The catalog database pricing tier of the integration runtime.";

        public const string IntegrationRuntimeVNetId = "The ID of the VNet which the integration runtime will join.";

        public const string IntegrationRuntimeSubnet = "The name of the subnet in the VNet.";

        public const string IntegrationRuntimePublicIP = "The static public IP addresses which the integration runtime will use.";

        public const string IntegrationRuntimeDataFlowComputeType = "Compute type of the data flow cluster which will execute data flow job.";

        public const string IntegrationRuntimeDataFlowCoreCount = "Core count of the data flow cluster which will execute data flow job.";

        public const string IntegrationRuntimeDataFlowTimeToLive = "Time to live (in minutes) setting of the data flow cluster which will execute data flow job.";

        public const string IntegrationRuntimeSetupScriptContainerSasUri = "The SAS URI of the Azure blob container that contains the custom setup script.";

        public const string IntegrationRuntimeEdition = "The edition for SSIS integration runtime which could be Standard or Enterprise, default is Standard if it is not specified.";

        public const string IntegrationRuntimeExpressCustomSetup = "The express custom setup for SSIS integration runtime which could be used to setup configurations and 3rd party components without custom setup script.";

        public const string IntegrationRuntimeDataProxyIntegrationRuntimeName = "The Self-Hosted Integration Runtime name which is used as a proxy.";

        public const string IntegrationRuntimeDataProxyStagingLinkedServiceName = "The Azure Blob Storage Linked Service name that references the staging data store to be used when moving data between Self-Hosted and Azure-SSIS Integration Runtime.";

        public const string IntegrationRuntimeDataProxyStagingPath = "The path in staging data store to be used when moving data between Self-Hosted and Azure-SSIS Integration Runtimes, a default container will be used if unspecified.";
        
        public const string IntegrationRuntimeMaxParallelExecutionsPerNode = "Maximum parallel execution count per node for a managed dedicated integration runtime.";

        public const string IntegrationRuntimeLicenseType = "The license type that you want to select for the SSIS IR. There are two types: LicenseIncluded or BasePrice. If you are qualified for the Azure Hybrid Use Benefit (AHUB) pricing, please select BasePrice. If not, please select LicenseIncluded.";

        public const string IntegrationRuntimeAuthKey = "The authentication key of the self-hosted integration runtime.";

        public const string SharedIntegrationRuntimeResourceId = "The resource id of the shared self-hosted integration runtime.";
    
        public const string IntegrationRuntimeAutoUpdate = "Enable or disable the self-hosted integration runtime auto-update.";

        public const string IntegrationRuntimeAutoUpdateTime = "The time of the day for the self-hosted integration runtime auto-update.";
    
        public const string IntegrationRuntimeJobsLimit = "The number of concurrent jobs permitted to run on the integration runtime node. Values between 1 and maxConcurrentJobs are allowed.";

        public const string PipelineName = "The pipeline name.";

        public const string RunId = "The pipeline run identifier.";

        public const string LastUpdatedAfter = "The time at or after which the run event was updated in 'ISO 8601' format.";

        public const string LastUpdatedBefore = "The time at or before which the run event was updated in 'ISO 8601' format.";

        public const string JsonFilePath = "The JSON file path.";

        public const string ActivityName = "The name of the activity.";

        public const string RunStatus = "The status of the pipeline run.";

        public const string PipelineRunObject = "The information about the pipeline run.";

        public const string PipelineObject = "The pipeline object.";

        public const string ParametersForRun = "Parameters for pipeline run.";

        public const string HelpParameterFileForRun = "The name of the file with parameters for pipeline run.";

        public const string ReferencePipelineRunIdForRun = "The pipeline run ID for rerun. If run ID is specified, the parameters of the specified run will be used to create a new run.";

        public const string IsRecoveryForRun = "Recovery mode flag. If recovery mode is set to true, the specified referenced pipeline run and the new run will be grouped under the same groupId.";

        public const string StartActivityNameForRun = "In recovery mode, the rerun will start from this activity. If not specified, all activities will run.";

        public const string LinkedServiceName = "The linked service name.";

        public const string LinkedServiceObject = "The linked service object.";

        public const string NotebookName = "The notebook name.";

        public const string NotebookObject = "The notebook object.";

        public const string Nbformat = "Notebook format (major number). Incremented between backwards incompatible changes to the notebook format.";

        public const string NbformatMinor = "Notebook format (minor number). Incremented for backward compatible changes to the notebook format.";

        public const string NotebookDescription = "The description of the notebook.";

        public const string NotebookLanguage = "The programming language of the notebook.";

        public const string OutputFolder = "The folder where the notebook should be placed.";

        public const string TriggerName = "The trigger name.";

        public const string TriggerObject = "The trigger object.";

        public const string DatasetName = "The dataset name.";

        public const string DatasetObject = "The dataset object.";

        public const string DataFlowName = "The data flow name.";

        public const string DataFlowObject = "The data flow object.";

        public const string EnableManagedIdentitySqlControlSetting = "Indicates whether to enable managed identity SQL control setting. Specify $True to enable managed identity SQL control setting, or $False to disable managed identity SQL control setting.";

        public const string PreventDataExfiltration = "Indicates whether to prevent data exfiltration.";

        public const string LinkedAccessCheckOnTargetResource = "Indicates whther to check linked access on target resource.";

        public const string AllowedAadTenantIdsForLinking = "The allowed AAD tenant IDs for linking.";

        public const string EncryptionKeyName = "The workspace encryption key name.";

        public const string EncryptionKeyIdentifier = "Key identifier should be in the format of: https://{keyvaultname}.vault.azure.net/keys/{keyname}.";

        public const string UserAssignedIdentityInEncryption = "User assigned identity resource Id used in Workspace Encryption";

        public const string UseSystemAssignedIdentityInEncryption = "specifying whether to use system assigned identity in Workspace Encryption or not";

        public const string WorkspaceKeyName = "The name of the workspace key.";

        public const string WorkspaceItemType = "The workspace item type.";

        public const string WorkspaceItem = "The workspace item.";

        public const string IsActiveCustomerManagedKey = "Indicates whether to activate the workspace after a customer managed key is provided.";

        public const string KeyResourceId = "The resource identifier of Synapse SQL Pool.";

        public const string KeyObject = "Workspace key input object, usually passed through the pipeline.";

        public const string SparkJobDefinitionName = "The Spark job definition name.";

        public const string SparkJobDefinitionObject = "The Spark job definition object.";

        public const string MaxServiceObjectName = "The max service level objective name of the sql pool.";

        public const string AutoPauseTimer = "The period of inactivity in minutes before automatically pausing the sql pool.";

        public const string AutoResume = "Indicates whether the sql pool can automatically resume when connection attempts are made.";

        public const string ManagedPrivateEndpointName = "The Synapse Managed Private Endpoint Name.";

        public const string ManagedPrivateEndpointObject = "The Synapse Managed Private Endpoint Object.";

        public const string DefaultVNetName = "Managed Virtual Network Name is 'default'.";

        public const string HelpTriggerRun = "The information about the trigger run.";

        public const string TriggerRunId = "The Run ID of the trigger.";

        public const string WorkspacePackageFile = "Specifies a local file path for a file to upload as workspace package.";

        public const string WorkspacePackageName = "The workspace package name.";

        public const string WorkspacePackageObject = "The workspace package object.";

        public const string WorkspacePackages = "The workspace packages.";

        public const string PackageAction = "Package action must be specified when you add or remove a workspace package from a Apache Spark pool.";

        public const string DataFlowDebugSessionId = "Identifier for Synapse data flow debug session.";

        public const string DebugSessionCommand = "The data flow debug command. Optionals are executePreviewQuery, executeStatisticsQuery and executeExpressionQuery.";

        public const string DebugSessionStreamName = "The stream name of data flow for debugging.";

        public const string DebugSessionRowLimit = "The row limit for data flow data preview.";

        public const string DebugSessionExpression = "The expression for data flow expression preview.";

        public const string DebugSessionColumns = "The columns list for data flow statistics preview.";

        public const string DataFlowDebugSessionFilePath = "File path for Synapse data flow debug session";

        public const string SqlScriptName = "The sql script name.";

        public const string SqlScriptObject = "The sql script object.";

        public const string SqlScriptOutputFolder = "The folder where the sql scripts should be placed.";

        public const string SqlScriptSqlPoolName = "Which sql pool the sql script is going to connect to.";

        public const string SqlScriptDatabaseName = "Which database the sql script is going to use.";

        public const string ResultLimit = "Limit of results, '-1' for no limit.";

        public const string SqlFolderPath = "The folder that this SQL script is in. If specify a multi-level path such as [rootFolder/subFolder], the SqlScript will appear at the bottom level. If not specified, this SQL script will appear at the root level.";

        public const string Description = "The description of the SQL script.";

        public const string DefaultResultLimit = "The default resultLimit is 5000";

        public const string SqlFilePath = "The SQL file path.";

        public const string SparkConfigurationFolderPath = "The folder that this Spark job definition is in. If specify a multi-level path such as [rootFolder/subFolder], the Spark job definition will appear at the bottom level. If not specified, this Spark job definition will appear at the root level.";

        public const string NoteBookFolderPath = "The folder that this notebook is in. If specify a multi-level path such as [rootFolder/subFolder], the notebook will appear at the bottom level. If not specified, this notebook will appear at the root level.";

        public const string SparkConfigurationName = "The Spark Configuration name.";

        public const string SparkConfigurationObject = "The Spark configuration object.";
        
        public const string KqlScriptName = "KQL script name.";

        public const string KqlScriptObject = "KQL script object.";

        public const string KqlScriptOutputFolder = "The folder where the KQL script should be placed.";

        public const string KqlFilePath = "The KQL file path.";

        public const string KustoPoolName = "Name of Synapse Kusto pool.";

        public const string KustoPoolDatabaseName = "Name of Synapse Kusto database.";

        public const string StorageAccountType = "The storage account type used to store backups for the sql pool. Possible values include: 'GRS', 'LRS'.";

        public const string ForceApplySetting = "Whether to stop any running jobs in the Big Data pool.";
    }
}
