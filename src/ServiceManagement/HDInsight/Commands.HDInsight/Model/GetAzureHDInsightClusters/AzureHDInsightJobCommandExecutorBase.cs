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
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Threading;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal abstract class AzureHDInsightJobCommandExecutorBase : AzureHDInsightCommandBase, IAzureHDInsightJobCommandCredentialsBase
    {
        protected CancellationTokenSource tokenSource = new CancellationTokenSource();

        public override CancellationToken CancellationToken
        {
            get { return this.tokenSource.Token; }
        }

        public PSCredential Credential { get; set; }

        public override void Cancel()
        {
            this.tokenSource.Cancel();
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Url resolution is done when the EndProcessing method is called.")]
        internal IJobSubmissionClient GetClient(string cluster)
        {
            cluster.ArgumentNotNull("ClusterEndpoint");
            IJobSubmissionClient client = null;
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));

            string currentEnvironmentName = this.CurrentSubscription == null ? null : this.CurrentSubscription.Environment;

            var clientCredential = this.GetJobSubmissionClientCredentials(
                this.CurrentSubscription,
                profileClient.GetEnvironmentOrDefault(currentEnvironmentName),
                cluster,
                profileClient.Profile);
            if (clientCredential != null)
            {
                client = ServiceLocator.Instance.Locate<IAzureHDInsightJobSubmissionClientFactory>().Create(clientCredential);
                client.SetCancellationSource(this.tokenSource);
                if (this.Logger.IsNotNull())
                {
                    client.AddLogWriter(this.Logger);
                }

                return client;
            }

            throw new InvalidOperationException("Expected either a Subscription or Credential parameter.");
        }
    }
}
