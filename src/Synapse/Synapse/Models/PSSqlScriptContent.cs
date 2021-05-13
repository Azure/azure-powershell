using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptContent
    {
        public PSSqlScriptContent(SqlScriptContent content)
        {
            this.Query = content.Query;
            this.CurrentConnection = content.CurrentConnection != null ? new PSSqlConnection(content.CurrentConnection) : null;
            this.Metadata = content.Metadata != null ? new PSSqlScriptMetadata(content.Metadata) : null;
        }

        /// <summary> SQL query to execute. </summary>
        public string Query { get; set; }

        /// <summary> The connection used to execute the SQL script. </summary>
        public PSSqlConnection CurrentConnection { get; set; }

        /// <summary> The metadata of the SQL script. </summary>
        public PSSqlScriptMetadata Metadata { get; set; }
    }
}