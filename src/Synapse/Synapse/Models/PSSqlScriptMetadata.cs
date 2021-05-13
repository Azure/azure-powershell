using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptMetadata
    {
        public PSSqlScriptMetadata(SqlScriptMetadata metadata)
        {
            this.Language = metadata.Language;
        }

        public string Language { get; set; }
    }
}