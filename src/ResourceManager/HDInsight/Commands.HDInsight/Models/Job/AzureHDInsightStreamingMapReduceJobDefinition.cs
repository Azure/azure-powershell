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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Provides creation details for a new Streaming jobDetails.
    /// </summary>
    public class AzureHDInsightStreamingMapReduceJobDefinition : AzureHDInsightJobDefinition
    {
        /// <summary>
        /// Gets or sets the location of the input data in Hadoop.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the Location in which to store the output data.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the Mapper.
        /// </summary>
        public string Mapper { get; set; }

        /// <summary>
        /// Gets or sets the Reducer.
        /// </summary>
        public string Reducer { get; set; }

        /// <summary>
        /// Gets or sets a file to add to the distributed cache.	
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Gets the parameters for the jobDetails.
        /// </summary>
        public IDictionary<string, string> Defines { get; private set; }

        /// <summary>
        /// Gets the command line environment for the mappers or the reducers.
        /// </summary>
        public IDictionary<string, string> CommandEnvironment { get; private set; }

        /// <summary>
        /// Initializes a new instance of the AzureHDInsightStreamingMapReduceJobDefinition class.
        /// </summary>
        public AzureHDInsightStreamingMapReduceJobDefinition()
        {
            CommandEnvironment = new Dictionary<string, string>();
            Defines = new Dictionary<string, string>();
        }
    }
}
