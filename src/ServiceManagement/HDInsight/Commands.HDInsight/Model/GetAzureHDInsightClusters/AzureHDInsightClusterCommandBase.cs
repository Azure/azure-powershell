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

using System.Threading;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal abstract class AzureHDInsightClusterCommandBase : AzureHDInsightCommandBase, IAzureHDInsightClusterCommandBase
    {
        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        public override CancellationToken CancellationToken
        {
            get { return this.tokenSource.Token; }
        }

        public string Name { get; set; }

        public override void Cancel()
        {
            this.tokenSource.Cancel();
        }

        internal IHDInsightClient GetClient(bool ignoreSslErrors = false)
        {
            this.CurrentSubscription.ArgumentNotNull("CurrentSubscription");

            ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));

            var subscriptionCredentials = this.GetSubscriptionCredentials(
                this.CurrentSubscription,
                client.GetEnvironmentOrDefault(this.CurrentSubscription.Environment),
                client.Profile);

            if (this.Endpoint.IsNotNull())
            {
                subscriptionCredentials.Endpoint = this.Endpoint;               
            }

            var clientInstance = ServiceLocator.Instance.Locate<IAzureHDInsightClusterManagementClientFactory>().Create(subscriptionCredentials, ignoreSslErrors);
            clientInstance.SetCancellationSource(this.tokenSource);
            if (this.Logger.IsNotNull())
            {
                clientInstance.AddLogWriter(this.Logger);
            }

            return clientInstance;
        }
    }
}
