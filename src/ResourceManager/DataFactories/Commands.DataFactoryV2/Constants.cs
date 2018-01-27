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
        public const string DataFactory = "AzureRmDataFactoryV2";

        public const string LinkedService = "AzureRmDataFactoryV2LinkedService";

        public const string LinkedServiceEncryptedCredential = "AzureRmDataFactoryV2LinkedServiceEncryptedCredential";

        public const string IntegrationRuntime = "AzureRmDataFactoryV2IntegrationRuntime";

        public const string IntegrationRuntimeNode = "AzureRmDataFactoryV2IntegrationRuntimeNode";

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

        public const string HelpResourceGroup = "The resource group name.";

        public const string HelpFactoryObject = "The data factory object.";

        public const string HelpFactoryName = "The data factory name.";

        public const string HelpTagsForFactory = "The tags of the data factory.";

        public const string HelpIdentityForFactory = "The identity for the data factory.";

        public const string HelpPipelineName = "The pipeline name.";

        public const string HelpTriggerName = "The trigger name.";

        public const string HelpPipeline = "The pipeline object.";

        public const string HelpDatasetName = "The dataset name.";

        public const string HelpDataset = "The dataset object.";

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

        public const string HelpIntegrationRuntimeMaxParallelExecutionsPerNode = "Maximum parallel execution count per node for a managed dedicated integration runtime.";

        public const string HelpIntegrationRuntimeLicenseType = "The license type that you want to select for the SSIS IR. There are two types: LicenseIncluded or BasePrice. If you are qualified for the Azure Hybrid Use Benefit (AHUB) pricing, please select BasePrice. If not, please select LicenseIncluded.";

        public const string HelpIntegrationRuntimeAutoUpdate = "Enable or disable the self-hosted integration runtime auto-update.";

        public const string HelpIntegrationRuntimeAutoUpdateTime = "The time of the day for the self-hosted integration runtime auto-update.";

        public const string HelpIntegrationRuntimeKeyName = "The authentication key name of the self-hosted integration runtime.";

        public const string HelpIntegrationRuntimeJobsLimit = "The number of concurrent jobs permitted to run on the integration runtime node. Values between 1 and maxConcurrentJobs are allowed.";

        public const string HelpIntegrationRuntimeNodeIpAddress = "The IP Address of integration runtime node.";

        public const string HelpPipelineRunId = "The Run ID of the pipeline.";

        public const string HelpPipelineRun = "The information about the pipeline run.";

        public const string HelpActivityName = "The name of the activity.";

        public const string HelpParametersForRun = "Parameters for pipeline run.";

        public const string HelpParameterFileForRun = "The name of the file with parameters for pipeline run.";

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

        public const string DataFactoryName = "DataFactoryName";

        public const string PipelineName = "PipelineName";

        public const string LinkedServiceName = "LinkedServiceName";

        public const string IntegrationRuntimeName = "IntegrationRuntimeName";

        public const string SubnetName = "SubnetName";

        public const string IntegrationRuntimeTypeManaged = "Managed";

        public const string IntegrationRuntimeSelfhosted = "SelfHosted";

        public const string IntegrationRuntimeAutoUpdateEnabled = "On";

        public const string IntegrationRuntimeAutoUpdateDisabled = "Off";

        public const string TriggerName = "TriggerName";

        public const string IntegrationRuntimeLicenseIncluded = "LicenseIncluded";

        public const string IntegrationRuntimeBasePrice = "BasePrice";
    }
}
