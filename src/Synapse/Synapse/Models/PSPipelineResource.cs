using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        public string Description { get; set; }

        public IList<Activity> Activities { get; set; }

        public IDictionary<string, PSVariableSpecification> Variables { get; set; }

        public int? Concurrency { get; set; }

        public IList<object> Annotations { get; set; }

        public IDictionary<string, object> RunDimensions { get; set; }

        public PSPipelineFolder Folder { get; set; }

        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }
        
        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
