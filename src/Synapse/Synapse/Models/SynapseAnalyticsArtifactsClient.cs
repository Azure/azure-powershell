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
        private readonly PipelineClient _pipelineClient;
        private readonly PipelineRunClient _pipelineRunClient;

        public SynapseAnalyticsArtifactsClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _pipelineClient = new PipelineClient(uri, new AzureSessionCredential(context));
            _pipelineRunClient = new PipelineRunClient(uri, new AzureSessionCredential(context));
        }

        #region pipeline

        public PipelineResource CreateOrUpdatePipeline(string pipelineName, string rawJsonContent)
        {
            PSPipelineResource psPipeline = JsonConvert.DeserializeObject<PSPipelineResource>(rawJsonContent);
            PipelineResource pipeline = GetPipelienResource(psPipeline);
            return _pipelineClient.CreateOrUpdatePipeline(pipelineName, pipeline).Value;
        }

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

        #region helpers

        public PipelineResource GetPipelienResource(PSPipelineResource pSPipelineResource)
        {
            PipelineResource pipeline = new PipelineResource
            {
                Description = pSPipelineResource.Description,
                Concurrency = pSPipelineResource.Concurrency,
                Annotations = pSPipelineResource.Annotations,
                RunDimensions = pSPipelineResource.RunDimensions
            };

            IList<PSActivity> pSActivities = pSPipelineResource.Activities;
            if (pSActivities != null)
            {
                IList<Activity> activities = new List<Activity>();
                foreach (PSActivity pSActivity in pSActivities)
                {
                    activities.Add(PSActivity.ToSdkObject(pSActivity));
                }
                pipeline.Activities = activities;
            }

            IDictionary<string, PSVariableSpecification> pSVariables = pSPipelineResource.Variables;
            if (pSVariables != null)
            {
                IDictionary<string, VariableSpecification> variables = new Dictionary<string, VariableSpecification>();
                foreach (var pSVariable in pSVariables)
                {
                    variables.Add(pSVariable.Key, PSVariableSpecification.ToSdkObject(pSVariable.Value));
                }
                pipeline.Variables = variables;
            }

            if (pSPipelineResource.Folder != null)
            {
                pipeline.Folder = PSPipelineFolder.ToSdkObject(pSPipelineResource.Folder);
            }

            IDictionary<string, PSParameterSpecification> pSParameters = pSPipelineResource.Parameters;
            if (pSParameters != null)
            {
                IDictionary<string, ParameterSpecification> parameters = new Dictionary<string, ParameterSpecification>();
                foreach (var pSParameter in pSParameters)
                {
                    parameters.Add(pSParameter.Key, PSParameterSpecification.ToSdkObject(pSParameter.Value));
                }
                pipeline.Parameters = parameters;
            }

            return pipeline;
        }

        #endregion
    }
}