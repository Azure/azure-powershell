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


namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Provides creation details for a new Hive jobDetails.
    /// </summary>
    public class AzureHDInsightSqoopJobDefinition : AzureHDInsightJobDefinition
    {
        /// <summary>
        /// Gets or sets the command to use for a sqoop job.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the query file to use for a hive jobDetails.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the name of the jobDetails.
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Gets or sets the name of the directory for libraries.
        /// </summary>
        public string LibDir { get; set; }
    }
}
