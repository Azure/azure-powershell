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

using Azure;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public partial class SynapseAnalyticsArtifactsClient
    {
        private static readonly object _lock = new object();
        private readonly IAzureContext _context;
        private readonly Uri _endpoint;
        private readonly PipelineClient _pipelineClient;
        private readonly PipelineRunClient _pipelineRunClient;
        private readonly LinkedServiceClient _linkedServiceClient;
        private readonly NotebookClient _notebookClient;
        private readonly TriggerClient _triggerClient;
        private readonly TriggerRunClient _triggerRunClient;
        private readonly DatasetClient _datasetClient;
        private readonly DataFlowClient _dataFlowClient;
        private readonly DataFlowDebugSessionClient _dataFlowDebugSessionClient;
        private readonly BigDataPoolsClient _bigDataPoolsClient;
        private readonly SparkJobDefinitionClient _sparkJobDefinitionClient;
        private readonly SqlScriptClient _sqlScriptClient;
        private readonly SparkConfigurationClient _sparkConfigurationClient;
        private readonly KqlScriptClient _kqlScriptClient;
        private readonly KqlScriptsClient _kqlScriptsClient;
        private readonly LinkConnectionClient _linkConnectionClient;

        public SynapseAnalyticsArtifactsClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            _context = context;
            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _endpoint = uri;
            _pipelineClient = new PipelineClient(uri, new AzureSessionCredential(context));
            _pipelineRunClient = new PipelineRunClient(uri, new AzureSessionCredential(context));
            _linkedServiceClient = new LinkedServiceClient(uri, new AzureSessionCredential(context));
            _notebookClient = new NotebookClient(uri, new AzureSessionCredential(context));
            _triggerClient = new TriggerClient(uri, new AzureSessionCredential(context));
            _triggerRunClient = new TriggerRunClient(uri, new AzureSessionCredential(context));
            _datasetClient = new DatasetClient(uri, new AzureSessionCredential(context));
            _dataFlowClient = new DataFlowClient(uri, new AzureSessionCredential(context));
            _dataFlowDebugSessionClient = new DataFlowDebugSessionClient(uri, new AzureSessionCredential(context));
            _bigDataPoolsClient = new BigDataPoolsClient(uri, new AzureSessionCredential(context));
            _sparkJobDefinitionClient = new SparkJobDefinitionClient(uri, new AzureSessionCredential(context));
            _sqlScriptClient = new SqlScriptClient(uri, new AzureSessionCredential(context));
            _sparkConfigurationClient = new SparkConfigurationClient(uri, new AzureSessionCredential(context));
            _kqlScriptClient = new KqlScriptClient(uri, new AzureSessionCredential(context));
            _kqlScriptsClient = new KqlScriptsClient(uri, new AzureSessionCredential(context));
            _linkConnectionClient = new LinkConnectionClient(uri, new AzureSessionCredential(context));
        }

        #region pipeline

        public PipelineResource CreateOrUpdatePipeline(string pipelineName, string rawJsonContent)
        {
            PipelineResource pipeline = JsonConvert.DeserializeObject<PipelineResource>(rawJsonContent);
            var operation = _pipelineClient.StartCreateOrUpdatePipeline(pipelineName, pipeline);
            return operation.Poll().Value;
        }

        public PipelineResource GetPipeline(string pipelineName)
        {
            return _pipelineClient.GetPipeline(pipelineName).Value;
        }

        public Pageable<PipelineResource> GetPipelinesByWorkspace()
        {
            return _pipelineClient.GetPipelinesByWorkspace();
        }

        public void DeletePipeline(string pipelineName)
        {
            _pipelineClient.StartDeletePipeline(pipelineName).Poll();
        }

        #endregion

        #region pipeline run

        public CreateRunResponse CreatePipelineRun(string pipelineName, string referencePipelineRunId, bool? isRecovery, string startActivityName, IDictionary<string, object> parameters)
        {
            return _pipelineClient.CreatePipelineRun(pipelineName, referencePipelineRunId, isRecovery, startActivityName, parameters);
        }

        public PipelineRun GetPipelineRun(string runId)
        {
            return _pipelineRunClient.GetPipelineRun(runId).Value;
        }

        public List<PipelineRun> QueryPipelineRunsByWorkspace(RunFilterParameters filterParameters)
        {
            List<PipelineRun> pipelineRuns = new List<PipelineRun>();
            string ContinuationToken = null;
            do
            {
                var response = _pipelineRunClient.QueryPipelineRunsByWorkspace(filterParameters).Value;
                ContinuationToken = response.ContinuationToken;
                filterParameters.ContinuationToken = ContinuationToken;
                pipelineRuns.AddRange(response.Value);
            }
            while (!string.IsNullOrWhiteSpace(ContinuationToken));            
           
            return pipelineRuns;
        }

        public void CancelPipelineRun(string runId)
        {
            _pipelineRunClient.CancelPipelineRun(runId);
        }

        public List<ActivityRunsQueryResponse> GetActivityRuns(string pipelineName, string runId, RunFilterParameters filterParameters)
        {
            List<ActivityRunsQueryResponse> activityRuns = new List<ActivityRunsQueryResponse>();
            string ContinuationToken = null;
            do
            {
                var response = _pipelineRunClient.QueryActivityRuns(pipelineName, runId, filterParameters).Value;
                ContinuationToken = response.ContinuationToken;
                filterParameters.ContinuationToken = ContinuationToken;
                activityRuns.Add(response);
            }
            while (!string.IsNullOrWhiteSpace(ContinuationToken));

            return activityRuns;
        }

        #endregion

        #region LinkedService

        public LinkedServiceResource GetLinkedService(string linkedServiceName)
        {
            return _linkedServiceClient.GetLinkedService(linkedServiceName);
        }

        public Pageable<LinkedServiceResource> GetLinkedServicesByWorkspace()
        {
            return _linkedServiceClient.GetLinkedServicesByWorkspace();
        }

        public LinkedServiceResource CreateOrUpdateLinkedService(string linkedServiceName, string rawJsonContent)
        {
            LinkedServiceResource linkedService = JsonConvert.DeserializeObject<LinkedServiceResource>(rawJsonContent);
            var operation = _linkedServiceClient.StartCreateOrUpdateLinkedService(linkedServiceName, linkedService);
            return operation.Poll().Value;
        }

        public void DeleteLinkedService(string linkedServiceName)
        {
            _linkedServiceClient.StartDeleteLinkedService(linkedServiceName).Poll();
        }

        #endregion

        #region Notebook

        public NotebookResource CreateOrUpdateNotebook(string notebookName, NotebookResource notebook)
        {
            var operation = _notebookClient.StartCreateOrUpdateNotebook(notebookName, notebook);
            return operation.Poll().Value;
        }

        public void DeleteNotebook(string notebookName)
        {
            _notebookClient.StartDeleteNotebook(notebookName).Poll();
        }

        public NotebookResource GetNotebook(string notebookName)
        {
            return _notebookClient.GetNotebook(notebookName);
        }

        public Pageable<NotebookResource> GetNotebooksByWorkspace()
        {
            return _notebookClient.GetNotebooksByWorkspace();
        }

        #endregion

        #region Trigger

        public TriggerResource CreateOrUpdateTrigger(string triggerName, string rawJsonContent)
        {
            TriggerResource trigger = JsonConvert.DeserializeObject<TriggerResource>(rawJsonContent);
            var operation = _triggerClient.StartCreateOrUpdateTrigger(triggerName, trigger);
            return operation.Poll().Value;
        }

        public TriggerResource GetTrigger(string triggerName)
        {
            return _triggerClient.GetTrigger(triggerName);
        }

        public Pageable<TriggerResource> GetTriggersByWorkspace()
        {
            return _triggerClient.GetTriggersByWorkspace();
        }

        public void DeleteTrigger(string triggerName)
        {
            _triggerClient.StartDeleteTrigger(triggerName).Poll();
        }

        public TriggerSubscriptionOperationStatus GetEventSubscriptionStatus(string triggerName)
        {
            return _triggerClient.GetEventSubscriptionStatus(triggerName);
        }

        public TriggerSubscriptionOperationStatus SubscribeTriggerToEvents(string triggerName)
        {
            var operation = _triggerClient.StartSubscribeTriggerToEvents(triggerName);
            return operation.Poll().Value;
        }

        public void UnsubscribeTriggerFromEvents(string triggerName)
        {
            _triggerClient.StartUnsubscribeTriggerFromEvents(triggerName).Poll();
        }

        public void StartTrigger(string triggerName)
        {
            _triggerClient.StartStartTrigger(triggerName).Poll();
        }

        public void StopTrigger(string triggerName)
        {
            _triggerClient.StartStopTrigger(triggerName).Poll();
        }

        public List<TriggerRun> QueryTriggerRunsByWorkspace(RunFilterParameters filterParameters)
        {
            List<TriggerRun> triggerRuns = new List<TriggerRun>();
            string continuationToken = null;
            do
            {
                var response = _triggerRunClient.QueryTriggerRunsByWorkspace(filterParameters).Value;
                continuationToken = response.ContinuationToken;
                filterParameters.ContinuationToken = continuationToken;
                triggerRuns.AddRange(response.Value);
            }
            while (!string.IsNullOrWhiteSpace(continuationToken));

            return triggerRuns;
        }

        public void StopTriggerRun(string triggerName, string triggerRunId)
        {
            _triggerRunClient.CancelTriggerInstance(triggerName, triggerRunId);
        }

        public void RerunTriggerRun(string triggerName, string triggerRunId)
        {
            _triggerRunClient.RerunTriggerInstance(triggerName, triggerRunId);
        }
        #endregion

        #region Dataset

        public DatasetResource CreateOrUpdateDataset(string datasetName, string rawJsonContent)
        {
            DatasetResource dataset = JsonConvert.DeserializeObject<DatasetResource>(rawJsonContent);
            var operation = _datasetClient.StartCreateOrUpdateDataset(datasetName, dataset);
            return operation.Poll().Value;
        }

        public DatasetResource GetDataset(string datasetName)
        {
            return _datasetClient.GetDataset(datasetName);
        }

        public Pageable<DatasetResource> GetDatasetsByWorkspace()
        {
            return _datasetClient.GetDatasetsByWorkspace();
        }

        public void DeleteDataset(string datasetName)
        {
            _datasetClient.StartDeleteDataset(datasetName).Poll();
        }

        #endregion

        #region DataFlow

        public DataFlowResource CreateOrUpdateDataFlow(string dataFlowName, string rawJsonContent)
        {
            DataFlowResource dataFlow = JsonConvert.DeserializeObject<DataFlowResource>(rawJsonContent);
            var operation = _dataFlowClient.StartCreateOrUpdateDataFlow(dataFlowName, dataFlow);
            return operation.Poll().Value;
        }

        public DataFlowResource GetDataFlow(string dataFlowName)
        {
            return _dataFlowClient.GetDataFlow(dataFlowName);
        }

        public Pageable<DataFlowResource> GetDataFlowsByWorkspace()
        {
            return _dataFlowClient.GetDataFlowsByWorkspace();
        }

        public void DeleteDataFlow(string dataFlowName)
        {
            _dataFlowClient.StartDeleteDataFlow(dataFlowName).Poll();
        }

        #endregion

        #region DataFlowDebugSession

        public AddDataFlowToDebugSessionResponse AddDataFlowDebugSessionPackage(string rawJsonContent, string sessionId)
        {
            DataFlowDebugPackage package = JsonConvert.DeserializeObject<DataFlowDebugPackage>(rawJsonContent);
            if (!string.IsNullOrWhiteSpace(sessionId))
            {
                package.SessionId = sessionId;
            }
            var operation = _dataFlowDebugSessionClient.AddDataFlow(package);
            return operation.Value;
        }

        public Pageable<DataFlowDebugSessionInfo> GetDataFlowDebugSessionsByWorkspace()
        {
            return _dataFlowDebugSessionClient.QueryDataFlowDebugSessionsByWorkspace();
        }
     
        public DataFlowDebugCommandResponse InvokeDataFlowDebugSessionCommand(DataFlowDebugCommandRequest request)
        {
           return _dataFlowDebugSessionClient.StartExecuteCommand(request).Poll().Value;
        }

        public void DeleteDataFlowDebugSession(DeleteDataFlowDebugSessionRequest request)
        {
            _dataFlowDebugSessionClient.DeleteDataFlowDebugSession(request);
        }

        public CreateDataFlowDebugSessionResponse CreateDataFlowDebugSession(CreateDataFlowDebugSessionRequest request)
        {
            return _dataFlowDebugSessionClient.StartCreateDataFlowDebugSession(request).Poll().Value;
        }

        #endregion

        #region BigDataPools

        public BigDataPoolResourceInfo GetBigDataPool(string bigDataPoolName)
        {
            return _bigDataPoolsClient.Get(bigDataPoolName);
        }

        #endregion

        #region Spark Job Definition

        public SparkJobDefinitionResource CreateOrUpdateSparkJobDefinition(string SparkJobDefinitionName, SparkJobDefinitionResource SparkJobDefinition)
        {
            var operation = _sparkJobDefinitionClient.StartCreateOrUpdateSparkJobDefinition(SparkJobDefinitionName, SparkJobDefinition);
            return operation.Poll().Value;
        }

        public SparkJobDefinitionResource GetSparkJobDefinition(string SparkJobDefinitionName)
        {
            return _sparkJobDefinitionClient.GetSparkJobDefinition(SparkJobDefinitionName).Value;
        }

        public Pageable<SparkJobDefinitionResource> GetSparkJobDefinitionsByWorkspace()
        {
            return _sparkJobDefinitionClient.GetSparkJobDefinitionsByWorkspace();
        }

        public void DeleteSparkJobDefinition(string SparkJobDefinitionName)
        {
            _sparkJobDefinitionClient.StartDeleteSparkJobDefinition(SparkJobDefinitionName).Poll();
        }

        public void RenameSparkJobDefinition(string SparkJobDefinitionName, string newName)
        {
            _sparkJobDefinitionClient.StartRenameSparkJobDefinition(SparkJobDefinitionName, new ArtifactRenameRequest
            {
                NewName = newName
            }).Poll();
        }

        #endregion

        #region SqlScript
        public void DeleteSqlScript(string sqlscriptName)
        {
            _sqlScriptClient.StartDeleteSqlScript(sqlscriptName).Poll();
        }

        public SqlScriptResource GetSqlScript(string sqlscriptName)
        {
            return _sqlScriptClient.GetSqlScript(sqlscriptName);
        }

        public Pageable<SqlScriptResource> GetSqlScriptsByWorkspace()
        {
            return _sqlScriptClient.GetSqlScriptsByWorkspace();
        }

        public SqlScriptResource CreateOrUpdateSqlScript(string sqlScriptName, SqlScriptResource resource)
        {
            return _sqlScriptClient.StartCreateOrUpdateSqlScript(sqlScriptName, resource).Poll().Value;
        }
        #endregion

        #region Spark Configuration

        public SparkConfigurationResource CreateOrUpdateSparkConfiguration(string sparkConfigurationName, string rawJsonContent)
        {
            SparkConfigurationResource sparkConfigurationResource = new SparkConfigurationResource(JsonConvert.DeserializeObject<SparkConfiguration>(rawJsonContent));
            return _sparkConfigurationClient.StartCreateOrUpdateSparkConfiguration(sparkConfigurationName, sparkConfigurationResource).Poll().Value;
        }

        public SparkConfigurationResource GetSparkConfiguration(string sparkConfigurationName)
        {
            return _sparkConfigurationClient.GetSparkConfiguration(sparkConfigurationName).Value;
        }

        public Pageable<SparkConfigurationResource> GetSparkConfigurationByWorkspace()
        {
            return _sparkConfigurationClient.GetSparkConfigurationsByWorkspace();
        }

        public void DeleteSparkConfiguration(string sparkConfigurationName)
        {
            _sparkConfigurationClient.StartDeleteSparkConfiguration(sparkConfigurationName).Poll();
        }

        #endregion

        #region Kql Script

        public KqlScriptResource GetKqlScript(string kqlScriptName)
        {
            return _kqlScriptClient.GetByName(kqlScriptName);
        }

        public Pageable<KqlScriptResource> GetKqlScriptsByWorkspace()
        {
            return _kqlScriptsClient.GetAll();
        }

        public void DeleteKqlScript(string kqlScriptName)
        {
            _kqlScriptClient.StartDeleteByName(kqlScriptName).Poll();
        }

        public KqlScriptResource CreateOrUpdateKqlScript(string kqlScriptName, KqlScriptResource kqlScript)
        {
            var operation = _kqlScriptClient.StartCreateOrUpdate(kqlScriptName, kqlScript);
            return operation.Poll().Value;
        }

        #endregion

        #region Link Connection

        public void EditTables(string linkConnectionName, string rawJsonContent)
        {
            EditTablesRequest editTablesRequest = JsonConvert.DeserializeObject<EditTablesRequest>(rawJsonContent);
            _linkConnectionClient.EditTables(linkConnectionName, editTablesRequest);
        }

        public IReadOnlyList<LinkTableResource> ListLinkTables(string linkConnectionName)
        {
            return _linkConnectionClient.ListLinkTables(linkConnectionName).Value.Value;
        }

        public LinkConnectionQueryTableStatus QueryTableStatus(string linkConnectionName, QueryTableStatusRequest queryTableStatusRequest)
        {
            return _linkConnectionClient.QueryTableStatus(linkConnectionName, queryTableStatusRequest);
        }

        public void UpdateLandingZoneCredential(string linkConnectionName, UpdateLandingZoneCredential updateLandingZoneCredentialRequest)
        {
            _linkConnectionClient.UpdateLandingZoneCredential(linkConnectionName, updateLandingZoneCredentialRequest);
        }

        public LinkConnectionResource GetLinkConnection(string linkConnectionName)
        {
            return _linkConnectionClient.GetLinkConnection(linkConnectionName).Value;
        }

        public Pageable<LinkConnectionResource> GetLinkConnectionByWorkspace()
        {
            return _linkConnectionClient.ListLinkConnectionsByWorkspace();
        }

        public void StartLinkConnection(string linkConnectionName)
        {
            _linkConnectionClient.Start(linkConnectionName);
        }

        public void StopLinkConnection(string linkConnectionName)
        {
             _linkConnectionClient.Stop(linkConnectionName);
        }

        public void DeleteLinkConnection(string linkConnectionName)
        {
            _linkConnectionClient.DeleteLinkConnection(linkConnectionName);
        }

        public LinkConnectionResource CreateOrUpdateLinkConnection(string linkConnectionName, string rawJsonContent)
        {
            LinkConnectionResource linkConnection = JsonConvert.DeserializeObject<LinkConnectionResource>(rawJsonContent);
            var response = _linkConnectionClient.CreateOrUpdateLinkConnection(linkConnectionName, linkConnection);
            return response.Value;
        }

        public LinkConnectionDetailedStatus GetLinkConnectionDetailedStatus(string linkConnectionName)
        {
            return _linkConnectionClient.GetDetailedStatus(linkConnectionName).Value;
        }
        #endregion

        #region helpers

        public virtual string ReadJsonFileContent(string path)
        {
            return Utils.ReadJsonFileContent(path);
        }

        internal Exception CreateAzurePowerShellException(RequestFailedException ex)
        {
            return Utils.CreateAzurePowerShellException(ex);
        }

        #endregion
    }
}