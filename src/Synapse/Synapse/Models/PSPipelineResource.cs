using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPipelineResource
    {
        public PSPipelineResource(PipelineResource pipelineResource, string workspaceName)
        {
            if (pipelineResource != null)
            {
                this.WorkspaceName = workspaceName;
                this.Name = pipelineResource.Name;
                this.Description = pipelineResource.Description;
                if (pipelineResource.Activities != null)
                {
                    this.Activities = pipelineResource.Activities.Select(element => new PSActivity(element)).ToList();
                }
                this.Values = pipelineResource.Values;
                if (pipelineResource.Variables != null)
                {
                    this.Variables = pipelineResource.Variables
                        .Select(element => new KeyValuePair<string, PSVariableSpecification>(element.Key, new PSVariableSpecification(element.Value)))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
                this.Concurrency = pipelineResource.Concurrency;
                this.Annotations = pipelineResource.Annotations;
                this.RunDimensions = pipelineResource.RunDimensions;
                this.Folder = new PSPipelineFolder(pipelineResource.Folder);
                this.Keys = pipelineResource.Keys;
                if (pipelineResource.Parameters != null)
                {
                    this.Parameters = pipelineResource.Parameters
                        .Select(element => new KeyValuePair<string, PSParameterSpecification>(element.Key, new PSParameterSpecification(element.Value)))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
            }
        }

        public string Name { get; set; }

        public string WorkspaceName { get; set; }

        public string Description { get; set; }

        public IList<PSActivity> Activities { get; set; }

        public ICollection<object> Values { get; set; }

        public IDictionary<string, PSVariableSpecification> Variables { get; set; }

        public int? Concurrency { get; set; }

        public IList<object> Annotations { get; set; }

        public IDictionary<string, object> RunDimensions { get; set; }

        public PSPipelineFolder Folder { get; set; }

        public ICollection<string> Keys { get; set; }

        public IDictionary<string, PSParameterSpecification> Parameters { get; set; }
    }
}
