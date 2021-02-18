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
            this.Keys = pipelineRun?.Keys;
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
            this.Values = pipelineRun?.Values;
        }

        public string WorkspaceName { get; set; }

        public IEnumerable<string> Keys { get; set; }

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

        public IEnumerable<object> Values { get; set; }
    }
}
