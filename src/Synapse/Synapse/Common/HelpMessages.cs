﻿using Microsoft.Azure.Commands.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class HelpMessages
    {
        public const string ResourceGroupName = "Resource group name.";

        public const string Location = "Azure region where the resource should be created.";

        public const string WorkspaceName = "Name of Synapse workspace.";

        public const string WorkspaceResourceId = "Resource identifier of Synapse workspace.";

        public const string WorkspaceObject = "workspace input object, usually passed through the pipeline.";

        public const string DefaultDataLakeStorageAccountName = "The default ADLS Gen2 storage account name.";

        public const string DefaultDataLakeStorageFilesystem = "The default ADLS Gen2 file system.";

        public const string ManagedVirtualNetwork = "Name of a Synapse-managed virtual network dedicated for the Azure Synapse workspace.";

        public const string DisallowAllConnection = "Azure Synapse Studio and other client tools will only be able to connect to the workspace endpoints if this parameter is not present. Connections from specific IP addresses or all Azure services can be allowed/disallowed after the workspace is provisioned.";

        public const string SqlAdministratorLoginCredential = "SQL administrator credentials.";

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

        public const string AutoPauseDelayInMinute = "Number of minutes idle. This parameter must be specified when Auto-pause is enabled.";

        public const string SparkVersion = "Apache Spark version. Allowed values: 2.4";

        public const string LibraryRequirementsFilePath = "Environment configuration file (\"PIP freeze\" output).";

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

        public const string SqlDatabaseName = "Name of Synapse SQL Database.";

        public const string SqlDatabaseResourceId = "Resource identifier of Synapse SQL Database.";

        public const string SqlDatabaseObject = "SQL Database input object, usually passed through the pipeline.";

        public const string SqlPoolName = "Name of Synapse SQL pool.";

        public const string SqlPoolVersion = "Version of Synapse SQL pool. For example, 2 or 3.";

        public const string SqlPoolNewName = "The new name to rename the SQL pool to.";

        public const string SqlPoolResourceId = "Resource identifier of Synapse SQL Pool.";

        public const string SqlPoolObject = "SQL pool input object, usually passed through the pipeline.";

        public const string SuspendSqlPool = "Indicates to pause the SQL pool";

        public const string ResumeSqlPool = "Indicates to resume the SQL pool";

        public const string PerformanceLevel = "The SQL Service tier and performance level to assign to the SQL pool. For example, DW2000c.";

        public const string Collation = "Collation defines the rules that sort and compare data, and cannot be changed after SQL pool creation. The default collation is " + SynapseConstants.DefaultCollation + ".";
        
        public const string MaxSizeInBytes = "Specifies the maximum size of the database in bytes.";

        public const string BackupResourceGroupName = "The resource group name of bakcup SQL pool object to create from.";

        public const string BackupWorkspaceName = "The Synapse workspace name of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolName = "The name of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolId = "The resource identifier of bakcup SQL pool object to create from.";

        public const string BackupSqlPoolResourceId = "The resource identifier of backup SQL pool object to restore from.";

        public const string SourceResourceGroupName = "The resource group name of source SQL pool object to create from.";

        public const string SourceWorkspaceName = "The Synapse workspace name of source SQL pool object to create from.";

        public const string SourceSqlPoolName = "The name of source SQL pool object to create from.";

        public const string SourceSqlPoolId = "The resource identifier of source SQL pool object to create from.";

        public const string FromBackup = "Indicates to restore from the most recent backup of any SQL pool in this subscription.";

        public const string FromRestorePoint = "Indicates to leverage a restore point from any SQL pool in this subscription to recover or copy from a previous state.";

        public const string RestorePoint = "Snapshot time to restore.";

        public const string SqlAdministratorLoginPassword = "The new SQL administrator password for the workspace.";

        public const string FirewallRuleName = "The firerwall rule name for the workspace.";

        public const string StartIpAddress = "The start IP address of the firewall rule. Must be IPv4 format.";

        public const string EndIpAddress = "The end IP address of the firewall rule. Must be IPv4 format. Must be greater than or equal to startIpAddress.";

        public const string AzureIpRule = "Creates a special firewall rule that permits all Azure IPs to have access.";

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
    }
}
