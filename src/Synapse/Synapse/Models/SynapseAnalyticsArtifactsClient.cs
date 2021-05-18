using Azure;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Rest.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsArtifactsClient
    {
        private readonly PipelineClient _pipelineClient;
        private readonly PipelineRunClient _pipelineRunClient;
        private readonly LinkedServiceClient _linkedServiceClient;
        private readonly NotebookClient _notebookClient;
        private readonly TriggerClient _triggerClient;
        private readonly TriggerRunClient _triggerRunClient;
        private readonly DatasetClient _datasetClient;
        private readonly DataFlowClient _dataFlowClient;
        private readonly BigDataPoolsClient _bigDataPoolsClient;

        public SynapseAnalyticsArtifactsClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _pipelineClient = new PipelineClient(uri, new AzureSessionCredential(context));
            _pipelineRunClient = new PipelineRunClient(uri, new AzureSessionCredential(context));
            _linkedServiceClient = new LinkedServiceClient(uri, new AzureSessionCredential(context));
            _notebookClient = new NotebookClient(uri, new AzureSessionCredential(context));
            _triggerClient = new TriggerClient(uri, new AzureSessionCredential(context));
            _triggerRunClient = new TriggerRunClient(uri, new AzureSessionCredential(context));
            _datasetClient = new DatasetClient(uri, new AzureSessionCredential(context));
            _dataFlowClient = new DataFlowClient(uri, new AzureSessionCredential(context));
            _bigDataPoolsClient = new BigDataPoolsClient(uri, new AzureSessionCredential(context));
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

        public IReadOnlyList<PipelineRun> QueryPipelineRunsByWorkspace(RunFilterParameters filterParameters)
        {
            return _pipelineRunClient.QueryPipelineRunsByWorkspace(filterParameters).Value.Value;
        }

        public void CancelPipelineRun(string runId)
        {
            _pipelineRunClient.CancelPipelineRun(runId);
        }

        public ActivityRunsQueryResponse GetActivityRuns(string pipelineName, string runId, RunFilterParameters filterParameters)
        {
            return _pipelineRunClient.QueryActivityRuns(pipelineName, runId, filterParameters).Value;
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

        public IReadOnlyList<TriggerRun> QueryTriggerRunsByWorkspace(RunFilterParameters filterParameters)
        {
            return _triggerRunClient.QueryTriggerRunsByWorkspace(filterParameters).Value.Value;
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

        #region BigDataPools

        public BigDataPoolResourceInfo GetBigDataPool(string bigDataPoolName)
        {
            return _bigDataPoolsClient.Get(bigDataPoolName);
        }

        #endregion

        #region helpers

        public virtual string ReadJsonFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (TextReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion
    }
}