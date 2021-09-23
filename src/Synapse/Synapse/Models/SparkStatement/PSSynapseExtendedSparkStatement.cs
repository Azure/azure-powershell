// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
