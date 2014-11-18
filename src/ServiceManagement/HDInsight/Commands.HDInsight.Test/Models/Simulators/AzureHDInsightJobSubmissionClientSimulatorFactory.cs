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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators
{
    public class AzureHDInsightJobSubmissionClientSimulatorFactory : IAzureHDInsightJobSubmissionClientFactory
    {
        internal static IDictionary<string, IJobSubmissionClient> jobSubmissionClients = new Dictionary<string, IJobSubmissionClient>();

        public IJobSubmissionClient Create(IJobSubmissionClientCredential credentials)
        {
            var asBasic = credentials as BasicAuthCredential;
            var asSubscription = credentials as JobSubmissionCertificateCredential;
            string clusterName = string.Empty;

            if (asBasic != null)
            {
                clusterName = asBasic.Server.Host.Split('.').First();
            }
            else if (asSubscription != null)
            {
                clusterName = asSubscription.Cluster;
            }
            else
            {
                throw new NotSupportedException("Credential type :" + credentials.GetType().Name + ": is not supported");
            }

            string clusterUri = GatewayUriResolver.GetGatewayUri(clusterName).AbsoluteUri.ToUpperInvariant();
            if (!jobSubmissionClients.ContainsKey(clusterUri))
            {
                AzureHDInsightClusterManagementClientSimulator.SimulatorClusterContainer cluster =
                    AzureHDInsightClusterManagementClientSimulator.GetClusterInternal(clusterName);
                var jobClient = new AzureHDInsightJobSubmissionClientSimulator(credentials, cluster);
                jobSubmissionClients.Add(clusterUri, jobClient);
            }

            return jobSubmissionClients[clusterUri];
        }
    }
}
