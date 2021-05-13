using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptResource : PSSubResource 
    {
        public PSSqlScriptResource(SqlScriptResource pipelineResource)
            : base(pipelineResource?.Id,
                pipelineResource?.Name,
                pipelineResource?.Type,
                pipelineResource?.Etag)
        {
            this.Properties = pipelineResource?.Properties != null ? new PSSqlScript(pipelineResource.Properties) : null;
        }

        /// <summary> Properties of sql script. </summary>
        public PSSqlScript Properties { get; set; }
    }
}
