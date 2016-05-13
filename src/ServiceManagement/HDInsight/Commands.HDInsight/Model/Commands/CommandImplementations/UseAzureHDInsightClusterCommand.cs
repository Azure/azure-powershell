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
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class UseAzureHDInsightClusterCommand : AzureHDInsightClusterCommand<AzureHDInsightClusterConnection>, IUseAzureHDInsightClusterCommand
    {
        private const string GrantHttpAccessCmdletName = "Grant Azure HDInsight Http Services Access";

        public override async Task EndProcessing()
        {
            this.Name.ArgumentNotNullOrEmpty("Name");
            IHDInsightClient client = this.GetClient(IgnoreSslErrors);
            var cluster = await client.GetClusterAsync(this.Name);
            var connection = new AzureHDInsightClusterConnection();
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            connection.Credential = this.GetSubscriptionCredentials(this.CurrentSubscription,
                profileClient.GetEnvironmentOrDefault(this.CurrentSubscription.Environment),
                profileClient.Profile);

            if (cluster == null)
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Failed to connect to cluster :{0}", this.Name));
            }

            connection.Cluster = new AzureHDInsightCluster(cluster);

            if (!(cluster.State == ClusterState.Running || cluster.State == ClusterState.Operational))
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.InvariantCulture, "Cluster {0} is in an invalid state : {1}", this.Name, cluster.State.ToString()));
            }

            if (string.IsNullOrEmpty(cluster.HttpUserName))
            {
                throw new NotSupportedException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Cluster {0} is not configured for Http Services access.\r\nPlease use the {1} cmdlet to enable Http Services access.",
                        this.Name,
                        GrantHttpAccessCmdletName));
            }

            this.Output.Add(connection);
        }
    }
}
