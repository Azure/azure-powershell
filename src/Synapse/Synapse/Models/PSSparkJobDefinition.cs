using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkJobDefinition
    {
        public PSSparkJobDefinition(SparkJobDefinition properties)
        {
            Description = properties?.Description;
            TargetBigDataPool = properties?.TargetBigDataPool != null ? new PSBigDataPoolReference(properties.TargetBigDataPool) : null;
            RequiredSparkVersion = properties?.RequiredSparkVersion;
            JobProperties = properties?.JobProperties != null ? new PSSparkJobProperties(properties.JobProperties) : null;
        }

        /// <summary> The description of the Spark job definition. </summary>
        public string Description { get; set; }

        /// <summary> Big data pool reference. </summary>
        public PSBigDataPoolReference TargetBigDataPool { get; set; }

        /// <summary> The required Spark version of the application. </summary>
        public string RequiredSparkVersion { get; set; }

        /// <summary> The language of the Spark application. </summary>
        public string Language { get; set; }

        /// <summary> The properties of the Spark job. </summary>
        public PSSparkJobProperties JobProperties { get; set; }
    }
}