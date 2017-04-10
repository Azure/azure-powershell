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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators
{
    internal class AzureHDInsightSubscriptionResolverSimulator : IAzureHDInsightSubscriptionResolver
    {
        private IEnumerable<AzureSubscription> knownSubscriptions;

        internal AzureHDInsightSubscriptionResolverSimulator()
        {
            var certificate = new X509Certificate2(Convert.FromBase64String(IntegrationTestBase.TestCredentials.Certificate), string.Empty);
            AzureSession.Instance.DataStore.AddCertificate(certificate);
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));
            var newAccount = new AzureAccount
            {
                Id = certificate.Thumbprint,
                Type = AzureAccount.AccountType.Certificate,
            };
            newAccount.SetSubscriptions(IntegrationTestBase.TestCredentials.SubscriptionId.ToString());
            profileClient.Profile.AccountTable[certificate.Thumbprint] = newAccount;
            profileClient.Profile.Save();
            var sub1 = new AzureSubscription()
            {
                Id = IntegrationTestBase.TestCredentials.SubscriptionId.ToString(),
            };
            sub1.SetAccount(certificate.Thumbprint);
            sub1.SetEnvironment(EnvironmentName.AzureCloud);
            this.knownSubscriptions = new AzureSubscription[]
                {
                    sub1
                };
        }

        public AzureSubscription ResolveSubscription(string subscription)
        {
            Guid subId;
            if (Guid.TryParse(subscription, out subId))
            {
                return this.knownSubscriptions.FirstOrDefault(s => s.GetId() == subId);
            }
            else
            {
                return this.knownSubscriptions.FirstOrDefault(s => s.Name == subscription);   
            }
        }
    }
}