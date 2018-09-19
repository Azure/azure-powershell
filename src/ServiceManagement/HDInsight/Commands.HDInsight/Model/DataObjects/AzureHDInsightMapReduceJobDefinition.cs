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
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Provides creation details for a new MapReduce jobDetails.
    /// </summary>
    public class AzureHDInsightMapReduceJobDefinition : AzureHDInsightJobDefinition
    {
        /// <summary>
        ///     Initializes a new instance of the AzureHDInsightMapReduceJobDefinition class.
        /// </summary>
        public AzureHDInsightMapReduceJobDefinition()
        {
            this.LibJars = new List<string>();
            this.Defines = new Dictionary<string, string>();
        }

        /// <summary>
        ///     Gets or sets the class name to use for the jobDetails.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        ///     Gets the parameters for the jobDetails.
        /// </summary>
        public IDictionary<string, string> Defines { get; private set; }

        /// <summary>
        ///     Gets or sets the jar file to use for the jobDetails.
        /// </summary>
        public string JarFile { get; set; }

        /// <summary>
        ///     Gets or sets the name of the jobDetails.
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        ///     Gets the libjars to use for the jobDetails.
        /// </summary>
        public ICollection<string> LibJars { get; private set; }

        /// <summary>
        ///     Converts the Powershell object type to SDK object type.
        /// </summary>
        /// <returns>An SDK MapReduce object type.</returns>
        internal MapReduceJobCreateParameters ToMapReduceJobCreateParameters()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                ClassName = this.ClassName,
                JarFile = this.JarFile,
                JobName = this.JobName,
                StatusFolder = this.StatusFolder
            };

            if (this.Arguments.IsNotNull())
            {
                mapReduceJobDefinition.Arguments.AddRange(this.Arguments);
            }

            if (this.Defines.IsNotNull())
            {
                mapReduceJobDefinition.Defines.AddRange(this.Defines);
            }

            if (this.Files.IsNotNull())
            {
                mapReduceJobDefinition.Files.AddRange(this.Files);
            }

            if (this.LibJars.IsNotNull())
            {
                mapReduceJobDefinition.LibJars.AddRange(this.LibJars);
            }

            return mapReduceJobDefinition;
        }
    }
}
