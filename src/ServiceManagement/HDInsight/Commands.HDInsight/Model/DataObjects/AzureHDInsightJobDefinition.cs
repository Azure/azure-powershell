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
using System.Collections.ObjectModel;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Provides the details of an HDInsight jobDetails when creating the jobDetails.
    /// </summary>
    public abstract class AzureHDInsightJobDefinition
    {
        /// <summary>
        ///     Initializes a new instance of the AzureHDInsightJobDefinition class.
        /// </summary>
        protected AzureHDInsightJobDefinition()
        {
            this.Files = new List<string>();
            this.Arguments = new Collection<string>();
        }

        /// <summary>
        ///     Gets the arguments for the jobDetails.
        /// </summary>
        public ICollection<string> Arguments { get; private set; }

        /// <summary>
        ///     Gets the resources for the jobDetails.
        /// </summary>
        public ICollection<string> Files { get; private set; }

        /// <summary>
        ///     Gets or sets the status folder to use for the jobDetails.
        /// </summary>
        public string StatusFolder { get; set; }
    }
}
