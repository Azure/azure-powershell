using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    [Rest.Serialization.JsonTransformation]
    public class PSPipelineResource : PSSubResource
    {
        public PSPipelineResource(PipelineResource pipelineResource, string workspaceName)
            : base(pipelineResource?.Id,
                pipelineResource?.Name,
                pipelineResource?.Type,
                pipelineResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Description = pipelineResource?.Description;
            this.Activities = pipelineResource?.Activities;
            this.Variables = pipelineResource?.Variables?
                .Select(element => new KeyValuePair<string, PSVariableSpecification>(element.Key, new PSVariableSpecification(element.Value)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            this.Concurrency = pipelineResource?.Concurrency;
            this.Annotations = pipelineResource?.Annotations;
            this.RunDimensions = pipelineResource?.RunDimensions;
            this.Folder = new PSPipelineFolder(pipelineResource?.Folder);
            this.Parameters = pipelineResource?.Parameters?
                .Select(element => new KeyValuePair<string, PSParameterSpecification>(element.Key, new PSParameterSpecification(element.Value)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var propertiesEnum = pipelineResource?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public PSPipelineResource() { }

        public string WorkspaceName { get; set; }

        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        public IList<Activity> Activities { get; set; }

        [JsonProperty(PropertyName = "properties.activities")]
        internal IList<PSActivity> ActivitiesForCreate { get; set; }

        [JsonProperty(PropertyName = "properties.variables")]
        public IDictionary<string, PSVariableSpecification> Variables { get; set; }

        [JsonProperty(PropertyName = "properties.concurrency")]
        public int? Concurrency { get; set; }

        [JsonProperty(PropertyName = "properties.annotations")]
        public IList<object> Annotations { get; set; }

        [JsonProperty(PropertyName = "properties.runDimensions")]
        public IDictionary<string, object> RunDimensions { get; set; }

        [JsonProperty(PropertyName = "properties.folder")]
        public PSPipelineFolder Folder { get; set; }

        [JsonProperty(PropertyName = "properties.parameters")]
        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }
        
        [JsonProperty(PropertyName = "properties")]
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public PipelineResource ToSdkObject()
        {
            PipelineResource pipeline = new PipelineResource
            {
                Description = this.Description,
                Concurrency = this.Concurrency,
                Folder = this.Folder?.ToSdkObject()
            };
            this.ActivitiesForCreate?.ForEach(item => pipeline.Activities.Add(item?.ToSdkObject()));
            this.Variables?.ForEach(item => pipeline.Variables.Add(item.Key, item.Value?.ToSdkObject()));
            this.Annotations?.ForEach(item => pipeline.Annotations.Add(item));
            this.RunDimensions?.ForEach(item => pipeline.RunDimensions.Add(item));
            this.Parameters?.ForEach(item => pipeline.Parameters.Add(item.Key, item.Value?.ToSdkObject()));
            List<string> properties = new List<string> { "description", "activities", "variables", "concurrency",
                "annotations", "runDimensions", "folder", "parameters" };
            if (this.AdditionalProperties != null)
            {
                foreach (var item in this.AdditionalProperties)
                {
                    if (!properties.Contains(item.Key))
                    {
                        pipeline.Add(item.Key, item.Value);
                    }
                }
            }
            return pipeline;
        }
    }
}
