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
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsArtifactsClient
    {
        private readonly JsonSerializerSettings Settings;
        private readonly PipelineClient _pipelineClient;
        private readonly PipelineRunClient _pipelineRunClient;
        private readonly LinkedServiceClient _linkedServiceClient;

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

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _pipelineClient = new PipelineClient(uri, new AzureSessionCredential(context));
            _pipelineRunClient = new PipelineRunClient(uri, new AzureSessionCredential(context));
            _linkedServiceClient = new LinkedServiceClient(uri, new AzureSessionCredential(context));
        }

        #region pipeline

        public PipelineResource CreateOrUpdatePipeline(string pipelineName, string rawJsonContent)
        {
            PSPipelineResource psPipeline = JsonConvert.DeserializeObject<PSPipelineResource>(rawJsonContent,Settings);
            PipelineResource pipeline = psPipeline.ToSdkObject();
            return _pipelineClient.CreateOrUpdatePipeline(pipelineName, pipeline).Value;
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
            _pipelineClient.DeletePipeline(pipelineName);
        }

        public CreateRunResponse CreatePipelineRun(string pipelineName, string referencePipelineRunId, bool? isRecovery, string startActivityName, IDictionary<string, object> parameters)
        {
            return _pipelineClient.CreatePipelineRun(pipelineName, referencePipelineRunId, isRecovery, startActivityName, parameters).Value;
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
            return _linkedServiceClient.CreateOrUpdateLinkedService(linkedServiceName, linkedService);
        }

        public void DeleteLinkedService(string linkedServiceName)
        {
            _linkedServiceClient.DeleteLinkedService(linkedServiceName);
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