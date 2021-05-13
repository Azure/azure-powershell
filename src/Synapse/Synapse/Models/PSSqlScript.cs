using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScript
    {
        public PSSqlScript(SqlScript sqlScript)
        {
            this.Description = sqlScript.Description;
            this.Type = sqlScript.Type?.ToString();
            this.Content = sqlScript.Content != null ? new PSSqlScriptContent(sqlScript.Content) : null;
        }

        /// <summary> The description of the SQL script. </summary>
        public string Description { get; set; }

        /// <summary> The type of the SQL script. </summary>
        public string Type { get; set; }

        /// <summary> The content of the SQL script. </summary>
        public PSSqlScriptContent Content { get; set; }
    }
}
