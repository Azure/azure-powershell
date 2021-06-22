using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkJobDefinitionResource : PSSubResource
    {
        public PSSparkJobDefinitionResource(SparkJobDefinitionResource sparkJobDefinition)
           : base(sparkJobDefinition.Id, sparkJobDefinition.Name, sparkJobDefinition.Type, sparkJobDefinition.Etag)
        {
            Properties = sparkJobDefinition?.Properties != null ? new PSSparkJobDefinition(sparkJobDefinition.Properties) : null;
        }

        /// <summary> Properties of spark job definition. </summary>
        public PSSparkJobDefinition Properties { get; set; }
    }
}
