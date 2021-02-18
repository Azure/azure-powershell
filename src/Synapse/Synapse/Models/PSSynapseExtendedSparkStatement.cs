using Azure.Analytics.Synapse.Spark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseExtendedSparkStatement : PSSynapseSparkStatement
    {
        public PSSynapseExtendedSparkStatement(SparkStatement livyStatement) : base(livyStatement)
        {
            this.ExecutionOutput = GetExecutionOutput(livyStatement?.Output);
        }

        /// <summary>
        /// </summary>
        public string ExecutionOutput { get; }


        private string GetExecutionOutput(SparkStatementOutput livyOutput)
        {
            if (livyOutput == null)
            {
                return string.Empty;
            }

            if (SparkSessionStatementLivyState.Ok.Equals(livyOutput.Status, StringComparison.OrdinalIgnoreCase))
            {
                var parsedData = LivyStatementOutputParser.Parse(livyOutput.Data);
                if (parsedData is IList<PSSynapseLivyStatementOutputData>)
                {
                    var outputs = (IList<PSSynapseLivyStatementOutputData>)parsedData;
                    var contents = outputs.Where(o => o.ContentType == ContentType.TextPlain && o.Content is string).Select(o => (string)o.Content);
                    return string.Join(Environment.NewLine, contents);
                }
            }
            else if (SparkSessionStatementLivyState.Error.Equals(Output?.Status, StringComparison.OrdinalIgnoreCase))
            {
                var sb = new StringBuilder();
                if (livyOutput.ErrorValue != null)
                {
                    sb.AppendLine(livyOutput.ErrorValue);
                }

                if (livyOutput.Traceback != null)
                {
                    foreach (var trace in livyOutput.Traceback)
                    {
                        sb.Append(trace);
                    }
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
