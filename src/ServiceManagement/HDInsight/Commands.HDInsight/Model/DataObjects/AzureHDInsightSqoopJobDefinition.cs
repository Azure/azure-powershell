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

using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Provides creation details for a new Pig jobDetails.
    /// </summary>
    public class AzureHDInsightSqoopJobDefinition : AzureHDInsightJobDefinition
    {
        /// <summary>
        ///     Gets or sets the Command to use for a sqoop job.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        ///     Gets or sets the query file to use for a sqoop job.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        ///     Creates a SDK object from the PSCmdlet object type.
        /// </summary>
        /// <returns>A SDK Sqoop job definition object.</returns>
        internal SqoopJobCreateParameters ToSqoopJobCreateParameters()
        {
            var soopJobDefinition = new SqoopJobCreateParameters { Command = this.Command, File = this.File, StatusFolder = this.StatusFolder };

            if (this.Files.IsNotNull())
            {
                soopJobDefinition.Files.AddRange(this.Files);
            }

            return soopJobDefinition;
        }
    }
}
