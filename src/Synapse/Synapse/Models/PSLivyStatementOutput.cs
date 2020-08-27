using Azure.Analytics.Synapse.Spark.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivyStatementOutput
    {
        public PSLivyStatementOutput(SparkStatementOutput output)
        {
            this.Status = output?.Status;
            this.ExecutionCount = output?.ExecutionCount;
            //this.Data = LivyStatementOutputParser.Parse(output?.Data);
            this.Data = output?.Data;
            this.ErrorName = output?.ErrorName;
            this.ErrorValue = output?.ErrorValue;
            this.Traceback = output?.Traceback;
        }

        /// <summary>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        public int? ExecutionCount { get; set; }

        /// <summary>
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// </summary>
        public string ErrorName { get; set; }

        /// <summary>
        /// </summary>
        public string ErrorValue { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<string> Traceback { get; set; }
    }
}