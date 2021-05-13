using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlConnection
    {
        public PSSqlConnection(SqlConnection currentConnection)
        {
            this.Type = currentConnection.Type.ToString();
            this.Name = currentConnection.Name;
        }

        /// <summary> The type of the connection. </summary>
        public string Type { get; set; }

        /// <summary> The identifier of the connection. </summary>
        public string Name { get; set; }
    }
}