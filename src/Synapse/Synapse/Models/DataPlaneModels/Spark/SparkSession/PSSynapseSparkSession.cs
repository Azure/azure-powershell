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
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSparkSession : PSSynapseSparkJobInformationBase
    {
        public PSSynapseSparkSession(SparkSession session) : this(null, session)
        {
        }

        public PSSynapseSparkSession(string language, SparkSession session) :
            base(session?.Name,
                session?.WorkspaceName,
                session?.SparkPoolName,
                session?.SubmitterName,
                session?.SubmitterId,
                session?.ArtifactId,
                session?.JobType,
                session?.Result.ToString(),
                session?.Scheduler,
                session?.Plugin,
                session?.Errors,
                session?.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                session?.Id,
                session?.AppId,
                session?.AppInfo,
                session?.State,
                session?.LogLines)
        {
            this.Language = language;
            this.LivyInfo = session?.LivyInfo != null ? new PSLivySessionStateInformation(session?.LivyInfo) : null;
        }

        /// <summary>
        /// </summary>
        public PSLivySessionStateInformation LivyInfo { get; set; }

        public string Language { get; set; }
    }
}
