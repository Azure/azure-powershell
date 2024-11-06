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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{ 
    public abstract class ReachabilityAnalysisRunBaseCmdlet : NetworkBaseCmdlet
    {
        public IReachabilityAnalysisRunsOperations ReachabilityAnalysisRunClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ReachabilityAnalysisRuns;
            }
        }

        public bool IsAnalysisRunPresent(string resourceGroupName, string networkManagerName, string workspaceName, string analysisRunName)
        {
            try
            {
                GetAnalysisRun(resourceGroupName, networkManagerName, workspaceName, analysisRunName);
            }
            catch (Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSReachabilityAnalysisRun GetAnalysisRun(string resourceGroupName, string networkManagerName, string workspaceName, string analysisRunName)
        {
            var analysisRun = this.ReachabilityAnalysisRunClient.Get(resourceGroupName, networkManagerName, workspaceName, analysisRunName);
            var psAnalysisRun = ToPsReachabilityAnalysisRun(analysisRun);
            psAnalysisRun.ResourceGroupName = resourceGroupName;
            psAnalysisRun.NetworkManagerName = networkManagerName;
            psAnalysisRun.VerifierWorkspaceName = workspaceName;
            psAnalysisRun.Name = analysisRunName;
            return psAnalysisRun;
        }

        public PSReachabilityAnalysisRun ToPsReachabilityAnalysisRun(Management.Network.Models.ReachabilityAnalysisRun analysisRun)
        {
            var psReachabilityAnalysisRun = NetworkResourceManagerProfile.Mapper.Map<PSReachabilityAnalysisRun>(analysisRun);
            psReachabilityAnalysisRun.Properties.AnalysisResult = analysisRun.Properties.AnalysisResult;
            psReachabilityAnalysisRun.Properties.ErrorMessage = analysisRun.Properties.ErrorMessage;
            psReachabilityAnalysisRun.Properties.IntentContent = NetworkResourceManagerProfile.Mapper.Map<PSIntentContent>(analysisRun.Properties.IntentContent);
            return psReachabilityAnalysisRun;
        }

        private PSIPTraffic ToPsIPTraffic(Management.Network.Models.IPTraffic ipTraffic)
        {
            return new PSIPTraffic
            {
                SourceIps = ipTraffic.SourceIps?.ToList(),
                DestinationIps = ipTraffic.DestinationIps?.ToList(),
                SourcePorts = ipTraffic.SourcePorts?.ToList(),
                DestinationPorts = ipTraffic.DestinationPorts?.ToList(),
                Protocols = ipTraffic.Protocols?.ToList()
            };
        }
        private PSIntentContent ToPsIntentContent(Management.Network.Models.IntentContent intentContent)
        {
            var ipTraffic = ToPsIPTraffic(intentContent.IPTraffic);
            return new PSIntentContent
            {
                SourceResourceId = intentContent.SourceResourceId,
                DestinationResourceId = intentContent.DestinationResourceId,
                IpTraffic = ipTraffic
            };
        }
    }
}