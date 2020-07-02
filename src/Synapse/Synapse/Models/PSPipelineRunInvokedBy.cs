using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPipelineRunInvokedBy
    {
        public PSPipelineRunInvokedBy(PipelineRunInvokedBy pipelineRunInvokedBy)
        {
            this.Name = pipelineRunInvokedBy.Name;
            this.Id = pipelineRunInvokedBy.Id;
            this.InvokedByType = pipelineRunInvokedBy.InvokedByType;
        }

        public string Name { get; }
        
        public string Id { get; }
        
        public string InvokedByType { get; }
    }
}
