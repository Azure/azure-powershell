using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSPipelineFolder
    {
        public PSPipelineFolder(PipelineFolder pipelineFolder)
        {
            this.Name = pipelineFolder?.Name;
        }

        public string Name { get; set; }

        public PipelineFolder ToSdkObject() 
        {
            return new PipelineFolder()
            {
                Name = this.Name
            };
        }
    }
}
