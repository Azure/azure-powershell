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

using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkJobDefinition
    {
        public PSSparkJobDefinition(SparkJobDefinition properties)
        {
            Description = properties?.Description;
            TargetBigDataPool = properties?.TargetBigDataPool != null ? new PSBigDataPoolReference(properties.TargetBigDataPool) : null;
            RequiredSparkVersion = properties?.RequiredSparkVersion;
            JobProperties = properties?.JobProperties != null ? new PSSparkJobProperties(properties.JobProperties) : null;
            Folder = properties?.Folder != null ? new PSSparkJobDefinitionFolder(properties.Folder) : null;
        }

        /// <summary> The description of the Spark job definition. </summary>
        public string Description { get; set; }

        /// <summary> Big data pool reference. </summary>
        public PSBigDataPoolReference TargetBigDataPool { get; set; }

        /// <summary> The required Spark version of the application. </summary>
        public string RequiredSparkVersion { get; set; }

        /// <summary> The language of the Spark application. </summary>
        public string Language { get; set; }

        /// <summary> The properties of the Spark job. </summary>
        public PSSparkJobProperties JobProperties { get; set; }

        /// <summary> The folder that this Spark job definition is in. If not specified, this Spark job definition will appear at the root level.</summary>
        public PSSparkJobDefinitionFolder Folder { get; set; }
    }
}