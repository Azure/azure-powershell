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

using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightVersionsCapability
    {
        public AzureHDInsightVersionsCapability(VersionsCapability versionsCapability)
        {
            Available = new List<AzureHDInsightVersionSpec>();
            int? count = versionsCapability?.Available?.Count;
            for (int i = 0; i < count; i++)
            {
                this.Available.Add(new AzureHDInsightVersionSpec(versionsCapability.Available[i]));
            }
        }

        public IList<AzureHDInsightVersionSpec> Available { get; set; }
    }
}
