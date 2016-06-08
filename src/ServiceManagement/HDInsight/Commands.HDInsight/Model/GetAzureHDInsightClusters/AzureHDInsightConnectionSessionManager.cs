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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal class AzureHDInsightConnectionSessionManager : IAzureHDInsightConnectionSessionManager
    {
        private const string CurrentClusterVariableName = "_hdinsightCurrentCluster";

        private readonly SessionState sessionState;

        public AzureHDInsightConnectionSessionManager(SessionState sessionState)
        {
            this.sessionState = sessionState;
        }

        public AzureHDInsightClusterConnection GetCurrentCluster()
        {
            PSVariable currentClusterVariable = this.sessionState.PSVariable.Get(CurrentClusterVariableName);
            if (currentClusterVariable == null)
            {
                return null;
            }

            return (AzureHDInsightClusterConnection)currentClusterVariable.Value;
        }

        public void SetCurrentCluster(AzureHDInsightClusterConnection cluster)
        {
            this.sessionState.PSVariable.Set(CurrentClusterVariableName, cluster);
        }
    }
}
