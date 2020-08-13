using Azure;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsArtifactsClient
    {
        private readonly JsonSerializerSettings Settings;
        private readonly PipelineClient _pipelineClient;
        private readonly PipelineRunClient _pipelineRunClient;
        private readonly LinkedServiceClient _linkedServiceClient;
        private readonly NotebookClient _notebookClient;
        private readonly TriggerClient _triggerClient;
        private readonly TriggerRunClient _triggerRunClient;
        private readonly DatasetClient _datasetClient;
        private readonly DataFlowClient _dataFlowClient;

        public SynapseAnalyticsArtifactsClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            Settings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            Settings.Converters.Add(new TransformationJsonConverter());
            Settings.Converters.Add(new PolymorphicDeserializeJsonConverter<PSActivity>("type"));
            Settings.Converters.Add(new PolymorphicDeserializeJsonConverter<PSLinkedService>("type"));
            Settings.Converters.Add(new PolymorphicDeserializeJsonConverter<PSTrigger>("type"));
            Settings.Converters.Add(new PolymorphicDeserializeJsonConverter<PSDataset>("type"));
            Settings.Converters.Add(new PolymorphicDeserializeJsonConverter<PSDataFlow>("type"));

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
        }

        #region pipeline

        public PipelineResource CreateOrUpdatePipeline(string pipelineName, string rawJsonContent)
        {
            PSPipelineResource psPipeline = JsonConvert.DeserializeObject<PSPipelineResource>(rawJsonContent,Settings);
            PipelineResource pipeline = psPipeline.ToSdkObject();
            var operation = _pipelineClient.StartCreateOrUpdatePipeline(pipelineName, pipeline);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
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
            _pipelineClient.StartDeletePipeline(pipelineName);
        }

        public string CreatePipelineRun(string pipelineName, string referencePipelineRunId, bool? isRecovery, string startActivityName, IDictionary<string, object> parameters)
        {
            var operation = _pipelineClient.StartCreatePipelineRun(pipelineName, referencePipelineRunId, isRecovery, startActivityName, parameters);
            var document = JsonDocument.Parse(operation.GetRawResponse().ContentStream);
            return document.RootElement.GetProperty("runId").ToString();
        }

        #endregion

        #region pipeline run

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
            PSLinkedServiceResource psLinkedService = JsonConvert.DeserializeObject<PSLinkedServiceResource>(rawJsonContent, Settings);
            LinkedServiceResource linkedService = psLinkedService.ToSdkObject();
            var operation = _linkedServiceClient.StartCreateOrUpdateLinkedService(linkedServiceName, linkedService);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
        }

        public void DeleteLinkedService(string linkedServiceName)
        {
            _linkedServiceClient.StartDeleteLinkedService(linkedServiceName);
        }

        #endregion

        #region Notebook

        public NotebookResource CreateOrUpdateNotebook(string notebookName, NotebookResource notebook)
        {
            var operation = _notebookClient.StartCreateOrUpdateNotebook(notebookName, notebook);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
        }

        public void DeleteNotebook(string notebookName)
        {
            _notebookClient.StartDeleteNotebook(notebookName);
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
            PSTriggerResource pSTrigger = JsonConvert.DeserializeObject<PSTriggerResource>(rawJsonContent, Settings);
            TriggerResource trigger = pSTrigger.ToSdkObject();
            var operation = _triggerClient.StartCreateOrUpdateTrigger(triggerName, trigger);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
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
            _triggerClient.StartDeleteTrigger(triggerName);
        }

        public TriggerSubscriptionOperationStatus GetEventSubscriptionStatus(string triggerName)
        {
            return _triggerClient.GetEventSubscriptionStatus(triggerName);
        }

        public TriggerSubscriptionOperationStatus StartSubscribeTriggerToEvents(string triggerName)
        {
            var operation = _triggerClient.StartSubscribeTriggerToEvents(triggerName);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
        }

        public void StartUnsubscribeTriggerFromEvents(string triggerName)
        {
            _triggerClient.StartUnsubscribeTriggerFromEvents(triggerName);
        }

        public void StartStartTrigger(string triggerName)
        {
            _triggerClient.StartStartTrigger(triggerName);
        }

        public void StartStopTrigger(string triggerName)
        {
            _triggerClient.StartStopTrigger(triggerName);
        }

        public IReadOnlyList<TriggerRun> QueryTriggerRunsByWorkspace(RunFilterParameters filterParameters)
        {
            return _triggerRunClient.QueryTriggerRunsByWorkspace(filterParameters).Value.Value;
        }

        #endregion

        #region Dataset

        public DatasetResource CreateOrUpdateDataset(string datasetName, string rawJsonContent)
        {
            PSDatasetResource pSDatasetResource = JsonConvert.DeserializeObject<PSDatasetResource>(rawJsonContent, Settings);
            DatasetResource dataset = pSDatasetResource.ToSdkObject();
            var operation = _datasetClient.StartCreateOrUpdateDataset(datasetName, dataset);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
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
            _datasetClient.StartDeleteDataset(datasetName);
        }

        #endregion

        #region DataFlow

        public DataFlowResource CreateOrUpdateDataFlow(string dataFlowName, string rawJsonContent)
        {
            PSDataFlowResource pSDatasetResource = JsonConvert.DeserializeObject<PSDataFlowResource>(rawJsonContent, Settings);
            DataFlowResource dataFlow = pSDatasetResource.ToSdkObject();
            var operation = _dataFlowClient.StartCreateOrUpdateDataFlow(dataFlowName, dataFlow);
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            return operation.Value;
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
            _dataFlowClient.StartDeleteDataFlow(dataFlowName);
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