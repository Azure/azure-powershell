using Azure.Analytics.Synapse.Spark.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkStatement
    {
        public PSSynapseSparkStatement(SparkStatement livyStatement)
        {
            this.Id = livyStatement?.Id;
            this.Code = livyStatement?.Code;
            this.State = livyStatement?.State;
            this.Output = new PSLivyStatementOutput(livyStatement?.Output);
        }

        /// <summary>
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// </summary>
        public PSLivyStatementOutput Output { get; set; }
    }
}
