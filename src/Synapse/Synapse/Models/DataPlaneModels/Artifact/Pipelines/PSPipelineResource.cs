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
            this.AdditionalProperties = pipelineResource?.AdditionalProperties;
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
