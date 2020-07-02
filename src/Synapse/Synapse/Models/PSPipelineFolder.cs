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
            if (pipelineFolder != null)
            {
                this.Name = pipelineFolder.Name;
            }
        }

        public string Name { get; set; }

        public static PipelineFolder ToSdkObject(PSPipelineFolder pSPipelineFolder) 
        {
            return new PipelineFolder()
            {
                Name = pSPipelineFolder.Name
            };
        }
    }
}
