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
    /// Provides the details of an HDInsight jobDetails when creating the jobDetails.
    /// </summary>
    public abstract class AzureHDInsightJobDefinition
    {
        /// <summary>
        /// Initializes a new instance of the AzureHDInsightJobDefinition class.
        /// </summary>
        protected AzureHDInsightJobDefinition()
        {
            Files = new List<string>();
            Arguments = new List<string>();
        }

        /// <summary>
        /// Gets the arguments for the jobDetails.
        /// </summary>
        public IList<string> Arguments { get; private set; }

        /// <summary>
        /// Gets the files to be copied to the cluster
        /// </summary>
        public IList<string> Files { get; private set; }

        /// <summary>
        /// Gets or sets the status folder to use for the jobDetails.
        /// </summary>
        public string StatusFolder { get; set; }
    }
}
