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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPipelineRun
    {
        public PSPipelineRun(PipelineRun pipelineRun, string workspaceName)
        {
            this.WorkspaceName = workspaceName;
            this.Message = pipelineRun?.Message;
            this.Status = pipelineRun?.Status;
            this.DurationInMs = pipelineRun?.DurationInMs;
            this.RunEnd = pipelineRun?.RunEnd;
            this.RunStart = pipelineRun?.RunStart;
            this.LastUpdated = pipelineRun?.LastUpdated;
            this.InvokedBy = new PSPipelineRunInvokedBy(pipelineRun?.InvokedBy);
            this.Parameters = pipelineRun?.Parameters;
            this.PipelineName = pipelineRun?.PipelineName;
            this.IsLatest = pipelineRun?.IsLatest;
            this.RunGroupId = pipelineRun?.RunGroupId;
            this.RunId = pipelineRun?.RunId;
            this.AdditionalProperties = pipelineRun?.AdditionalProperties;
        }

        public string WorkspaceName { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

        public int? DurationInMs { get; set; }

        public DateTimeOffset? RunEnd { get; set; }

        public DateTimeOffset? RunStart { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public PSPipelineRunInvokedBy InvokedBy { get; set; }

        public IReadOnlyDictionary<string, string> Parameters { get; set; }

        public string PipelineName { get; set; }

        public bool? IsLatest { get; set; }

        public string RunGroupId { get; set; }

        public string RunId { get; set; }

        public IReadOnlyDictionary<string, object> AdditionalProperties { get; }
    }
}
