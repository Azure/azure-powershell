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