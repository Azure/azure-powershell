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

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    internal static class Constants
    {
        public const string DataFactoryQualifiedType = "Microsoft.DataFactory/factories";

        public const string DataFactory = "AzureRmDataFactoryV2";

        public const string LinkedService = "AzureRmDataFactoryV2LinkedService";

        public const string LinkedServiceEncryptedCredential = "AzureRmDataFactoryV2LinkedServiceEncryptedCredential";

        public const string IntegrationRuntime = "AzureRmDataFactoryV2IntegrationRuntime";

        public const string IntegrationRuntimeNode = "AzureRmDataFactoryV2IntegrationRuntimeNode";

        public const string IntegrationRuntimeVNetInjectionStandard = "Standard";

        public const string IntegrationRuntimeVNectInjectionExpress = "Express";

        public const string IntegrationRuntimeMetric = "AzureRmDataFactoryV2IntegrationRuntimeMetric";

        public const string IntegrationRuntimeKey = "AzureRmDataFactoryV2IntegrationRuntimeKey";

        public const string IntegrationRuntimeCredential = "AzureRmDataFactoryV2IntegrationRuntimeCredential";

        public const string IntegrationRuntimeUpgrade = "AzureRmDataFactoryV2IntegrationRuntimeUpgrade";

        public const string Dataset = "AzureRmDataFactoryV2Dataset";

        public const string Pipeline = "AzureRmDataFactoryV2Pipeline";

        public const string Trigger = "AzureRmDataFactoryV2Trigger";

        public const string PipelineRun = "AzureRmDataFactoryV2PipelineRun";

        public const string ActivityRun = "AzureRmDataFactoryV2ActivityRun";

        public const string TriggerRun = "AzureRmDataFactoryV2TriggerRun";

        public const string PipelineRunWithSummary = "AzureRmDataFactoryV2PipelineRunWithSummary";

        public const string HelpResourceId = "The Azure resource ID.";

        public const string HelpDataFactoryV2ResourceId = "The Azure resource ID of V2 data factory.";

        public const string HelpResourceGroup = "The resource group name.";

        public const string HelpFactoryObject = "The data factory object.";

        public const string HelpFactoryName = "The data factory name.";

        public const string HelpTagsForFactory = "The tags of the data factory.";

        public const string HelpIdentityForFactory = "The identity for the data factory.";

        public const string HelpPipelineName = "The pipeline name.";

        public const string HelpTriggerName = "The trigger name.";

        public const string HelpTriggerRunId = "The Run ID of the trigger.";

        public const string HelpTriggerRun = "The information about the trigger run.";

        public const string HelpTriggerObject = "The trigger object.";

        public const string HelpPipeline = "The pipeline object.";

        public const string HelpDatasetName = "The dataset name.";

        public const string HelpDataset = "The dataset object.";

        public const string HelpDataFlowName = "The data flow name.";

        public const string HelpDataFlow = "The data flow object.";

        public const string HelpDataFlowDebugSessionId = "The data flow debug session ID.";

        public const string HelpDataFlowDebugCommand = "The data flow debug command.";

        public const string HelpDataFlowDebugStreamName = "The stream name of data flow for debugging.";

        public const string HelpDataFlowDebugRowLimits = "The row limit for data flow data preview.";

        public const string HelpDataFlowDebugExpression = "The expression for data flow expression preview.";

        public const string HelpDataFlowDebugColumns = "The columns list for data flow statistics preview.";

        public const string HelpDataFlowCreationContext = "Creating or updating data flow '{0}' in resource group '{1}' under data factory '{2}'.";

        public const string HelpAddDataFlowPackageContext = "Add data flow package to debug session '{0}' in resource group '{1}' under data factory '{2}'.";

        public const string HelpInvokeDebugSessionCommandContext = "Invoke debug command of debug session '{0}' in resource group '{1}' under data factory '{2}'.";

        public const string HelpStartDataFlowDebugSessionContext = "Start a data flow debug session in resource group '{0}' under data factory '{1}'.";

        public const string HelpLinkedServiceName = "The linked service name.";

        public const string HelpLinkedService = "The linked service object.";

        public const string HelpJsonFilePath = "The JSON file path.";

        public const string HelpDontAskConfirmation = "Don't ask for confirmation.";

        public const string HelpIntegrationRuntimeName = "The integration runtime name.";

        public const string HelpIntegrationRuntimeStatus = "The integration runtime detail status.";

        public const string HelpIntegrationRuntimeNodeName = "The integration runtime node name.";

        public const string HelpIntegrationRuntimeObject = "The integration runtime object.";

        public const string HelpIntegrationRuntimeDescription = "The integration runtime description.";

        public const string HelpIntegrationRuntimetype = "The integration runtime type.";

        public const string HelpIntegrationRuntimeLocation = "The integration runtime location.";

        public const string HelpIntegrationRuntimeNodeSize = "The integration runtime node size.";

        public const string HelpIntegrationRuntimeNodeCount = "Target nodes count of the integration runtime.";

        public const string HelpIntegrationRuntimeCatalogServerEndpoint = "The catalog database server endpoint of the integration runtime.";

        public const string HelpIntegrationRuntimeCatalogAdminCredential = "The catalog database administrator credential of the integration runtime.";

        public const string HelpIntegrationRuntimeCatalogPricingTier = "The catalog database pricing tier of the integration runtime.";

        public const string HelpIntegrationRuntimeVNetId = "The ID of the VNet which the integration runtime will join.";

        public const string HelpIntegrationRuntimeSubnet = "The name of the subnet in the VNet.";

        public const string HelpIntegrationRuntimeSubnetId = "The ID of subnet, to which this Azure-SSIS integration runtime will be joined.";

        public const string HelpIntegrationRuntimePublicIP = "The static public IP addresses which the integration runtime will use.";

        public const string HelpIntegrationRuntimeDataFlowCoreCount = "Core count of the data flow cluster which will execute data flow job.";

        public const string HelpIntegrationRuntimeDataFlowComputeType = "Compute type of the data flow cluster which will execute data flow job.";

        public const string HelpIntegrationRuntimeDataFlowQuickReuseEnabled = "Enable data flow flow cluster reuse in the next data flow activity run.";

        public const string HelpIntegrationRuntimeDataFlowTimeToLive = "Time to live (in minutes) setting of the data flow cluster which will execute data flow job.";

        public const string HelpIntegrationRuntimeManagedVNetCopyComputeScaleDataIntegrationUnit = "DIU number setting reserved for copy activity execution.";

        public const string HelpIntegrationRuntimeManagedVNetCopyComputeScaleTimeToLive = "Time to live (in minutes) setting of integration runtime which will execute copy activity.";

        public const string HelpIntegrationRuntimeManagedVNetPipelineExternalComputeScaleTimeToLive = "Time to live (in minutes) setting of integration runtime which will execute pipeline and external activity.";

        public const string HelpIntegrationRuntimeManagedVNetNumberOfPipelineNodes = "Number of the pipeline nodes, which should be greater than 0 and less than 11.";

        public const string HelpIntegrationRuntimeManagedVNetNumberOfExternalNodes = "Number of the the external nodes, which should be greater than 0 and less than 11.";

        public const string HelpIntegrationRuntimeSelfContainedInteractiveAuthoringEnabled = "An alternative option to ensure interactive authoring function when your self-hosted integration runtime is unable to establish a connection with Azure Relay.";

        public const string HelpIntegrationRuntimeSetupScriptContainerSasUri = "The SAS URI of the Azure blob container that contains the custom setup script.";

        public const string HelpIntegrationRuntimeEdition = "The edition for SSIS integration runtime which could be Standard or Enterprise, default is Standard if it is not specified.";

        public const string HelpIntegrationRuntimeVNetInjectionMethod = "The virtual network injection method for Azure-SSIS Integration Runtime, Standard or Express, with Standard as default when not specified.";

        public const string HelpIntegrationRuntimeExpressCustomSetup = "The express custom setup for SSIS integration runtime which could be used to setup configurations and 3rd party components without custom setup script.";

        public const string HelpIntegrationRuntimeDataProxyIntegrationRuntimeName = "The Self-Hosted Integration Runtime name which is used as a proxy.";

        public const string HelpIntegrationRuntimeDataProxyStagingLinkedServiceName = "The Azure Blob Storage Linked Service name that references the staging data store to be used when moving data between Self-Hosted and Azure-SSIS Integration Runtime.";

        public const string HelpIntegrationRuntimeDataProxyStagingPath = "The path in staging data store to be used when moving data between Self-Hosted and Azure-SSIS Integration Runtimes, a default container will be used if unspecified.";

        public const string HelpIntegrationRuntimeMaxParallelExecutionsPerNode = "Maximum parallel execution count per node for a managed dedicated integration runtime.";

        public const string HelpIntegrationRuntimeLicenseType = "The license type that you want to select for the SSIS IR. There are two types: LicenseIncluded or BasePrice. If you are qualified for the Azure Hybrid Use Benefit (AHUB) pricing, please select BasePrice. If not, please select LicenseIncluded.";

        public const string HelpIntegrationRuntimeAutoUpdate = "Enable or disable the self-hosted integration runtime auto-update.";

        public const string HelpIntegrationRuntimeAutoUpdateTime = "The time of the day for the self-hosted integration runtime auto-update.";

        public const string HelpIntegrationRuntimeKeyName = "The authentication key name of the self-hosted integration runtime.";

        public const string HelpIntegrationRuntimeAuthKey = "The authentication key of the self-hosted integration runtime.";

        public const string HelpSharedIntegrationRuntimeResourceId = "The resource id of the shared self-hosted integration runtime.";

        public const string HelpIntegrationRuntimeJobsLimit = "The number of concurrent jobs permitted to run on the integration runtime node. Values between 1 and maxConcurrentJobs are allowed.";

        public const string HelpIntegrationRuntimeNodeIpAddress = "The IP Address of integration runtime node.";

        public const string HelpIntegrationRuntimeLinks = "Remove the linked integration runtimes created in the shared integration runtime.";

        public const string HelpLinkedFactoryName = "The linked data factory name.";

        public const string HelpPipelineRunId = "The Run ID of the pipeline.";

        public const string HelpPipelineRun = "The information about the pipeline run.";

        public const string HelpActivityName = "The name of the activity.";

        public const string HelpParametersForRun = "Parameters for pipeline run.";

        public const string HelpParameterFileForRun = "The name of the file with parameters for pipeline run.";

        public const string HelpReferencePipelineRunIdForRun = "The pipeline run ID for rerun. If run ID is specified, the parameters of the specified run will be used to create a new run.";

        public const string HelpIsRecoveryForRun = "Recovery mode flag. If recovery mode is set to true, the specified referenced pipeline run and the new run will be grouped under the same groupId.";

        public const string HelpStartActivityNameForRun = "In recovery mode, the rerun will start from this activity. If not specified, all activities will run.";

        public const string HelpStartFromFailureForRun = "Start rerun from failed activities flag. In recovery mode, if specified, the rerun will start from failed activities.";

        public const string HelpQueryParametersForRun = "Query parameters for pipeline run.";

        public const string HelpRunStartedAfter = "The time at or after which the pipeline run started to execute in ISO8601 format.";

        public const string HelpRunStartedBefore = "The time at or before which the pipeline run started to execute in ISO8601 format.";

        public const string HelpRunUpdatedAfter = "The time at or after which the pipeline run was updated in ISO8601 format.";

        public const string HelpRunUpdatedBefore = "The time at or before which the pipeline run was updated in ISO8601 format.";

        public const string HelpRunStatus = "The status of the pipeline run.";

        public const string HelpTriggerRunStartedAfter = "The time at or after which the trigger run started to execute in ISO8601 format.";

        public const string HelpTriggerRunStartedBefore = "The time at or before which the trigger run started to execute in ISO8601 format.";

        public const string File = "File";

        public const string DatasetName = "DatasetName";

        public const string DataFlowName = "DataFlowName";

        public const string DataFlowDebugSessionId = "SessionId";

        public const string DataFactoryName = "DataFactoryName";

        public const string PipelineName = "PipelineName";

        public const string LinkedServiceName = "LinkedServiceName";

        public const string IntegrationRuntimeName = "IntegrationRuntimeName";

        public const string SubnetName = "SubnetName";

        public const string IntegrationRuntimeTypeManaged = "Managed";

        public const string IntegrationRuntimeSelfhosted = "SelfHosted";

        public const string IntegrationRuntimeSelfhostedLinked = "SelfHosted(Linked)";

        public const string IntegrationRuntimeAutoUpdateEnabled = "On";

        public const string IntegrationRuntimeAutoUpdateDisabled = "Off";

        public const string LinkedIntegrationRuntimeKeyAuth = "Key";

        public const string LinkedIntegrationRuntimeRbacAuth = "RBAC";

        public const string TriggerName = "TriggerName";

        public const string IntegrationRuntimeLicenseIncluded = "LicenseIncluded";

        public const string IntegrationRuntimeBasePrice = "BasePrice";

        public const string DeprecatingParameter = "Parameter is being deprecated without being replaced";

        public const string HelpFactoryLocation = "The geographic region of the data factory.";

        public const string HelpGlobalParameter = "The dictionary containing the global parameters of the data factory.";

        public const string HelpIdentityType = "The identity type for the factory. It can be 'SystemAssigned', 'UserAssigned' or 'SystemAssigned,UserAssigned'";

        public const string HelpUserAssignedIdenty = "Dictionary of user assigned identities to use. { \"<UAMI Id>\" : {} }";

        public const string HelpPublicNetworkAccess = "Whether or not public network access is allowed for the data factory. It can be 'Enabled' or 'Disabled'";

        public const string HelpEncryptionVaultBaseUrl = "The url of the Azure Key Vault used for encryption with CMK.";

        public const string HelpEncryptionKeyName = "The name of the key in Azure Key Vault to use as Customer Managed Key for encryption.";

        public const string HelpEncryptionKeyVersion = "The version of the key used for CMK. If not provided, latest version will be used.";

        public const string HelpEncryptionUserAssignedIdentity = "User assigned identity to use to authenticate to customer's key vault. If not provided Managed Service Identity will be used.";

        public const string HelpRepoConfigurationProjectName = "The project name for repo configuration.";

        public const string HelpRepoConfigurationTenantId = "The tenant id for repo configuration.";

        public const string HelpRepoConfigurationAccountName = "The account name for repo configuration.";

        public const string HelpRepoConfigurationRepositoryName = "The repository name for repo configuration.";

        public const string HelpRepoConfigurationHostName = "The host name for repo configuration.";

        public const string HelpRepoConfigurationCollaborationBranch = "The collaboration branch for repo configuration.";

        public const string HelpRepoConfigurationRootFolder = "The root folder for repo configuration.";

        public const string HelpRepoConfigurationLastCommitId = "The last commit id for repo configuration.";

        public const string HelpRepoConfigurationDisablePublish = "Disable manual publish operation in ADF studio to favor automated publish.";

        public const string Id = "Id";

        public const string DataFactoryId = "DataFactoryId";

        public const string HelpPassThru = "If specified, cmdlet will return return true on successful delete.";

        public const string ActionDescriptionForAddEventSubscription = "Subscribe the event trigger to external service events.";

        public const string ActionDescriptionForRemoveEventSubscription = "Unsubscribe the event trigger from external service events.";

        public const string ActionDescriptionForInvokePipeline = "Starts a run for \"{0}\" pipeline in the \"{1}\" factory.";
    }
}
