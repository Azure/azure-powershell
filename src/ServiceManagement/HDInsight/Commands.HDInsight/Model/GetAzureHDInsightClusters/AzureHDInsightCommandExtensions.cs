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
using System.Linq;
using System.Reflection;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Factories;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using System.Diagnostics;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal static class AzureHDInsightCommandExtensions
    {
        public static IHDInsightSubscriptionCredentials GetSubscriptionCredentials(
            this IAzureHDInsightCommonCommandBase command,
            AzureSubscription currentSubscription,
            AzureEnvironment environment,
            AzureProfile profile)
        {
            var accountId = currentSubscription.Account;
            Debug.Assert(profile.Accounts.ContainsKey(accountId));

            if (profile.Accounts[accountId].Type == AzureAccount.AccountType.Certificate)
            {
                return GetSubscriptionCertificateCredentials(command, currentSubscription, profile.Accounts[accountId], environment);
            }
            else if (profile.Accounts[accountId].Type == AzureAccount.AccountType.User)
            {
                return GetAccessTokenCredentials(command, currentSubscription, profile.Accounts[accountId], environment);
            }
            else if (profile.Accounts[accountId].Type == AzureAccount.AccountType.ServicePrincipal)
            {
                return GetAccessTokenCredentials(command, currentSubscription, profile.Accounts[accountId], environment);
            }

            throw new NotSupportedException();
        }

        public static IHDInsightSubscriptionCredentials GetSubscriptionCertificateCredentials(this IAzureHDInsightCommonCommandBase command, 
            AzureSubscription currentSubscription, AzureAccount azureAccount, AzureEnvironment environment)
        {
            return new HDInsightCertificateCredential
            {
                SubscriptionId = currentSubscription.Id,
                Certificate = ProfileClient.DataStore.GetCertificate(currentSubscription.Account),
                Endpoint = environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement),
            };
        }

        public static IHDInsightSubscriptionCredentials GetAccessTokenCredentials(this IAzureHDInsightCommonCommandBase command, 
            AzureSubscription currentSubscription, AzureAccount azureAccount, AzureEnvironment environment)
        {
            ProfileClient profileClient = new ProfileClient();
            AzureContext azureContext = new AzureContext
            {
                Subscription = currentSubscription,
                Environment = environment,
                Account = azureAccount
            };

            var cloudCredentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(azureContext) as AccessTokenCredential;
            if (cloudCredentials != null)
            {
                var field= typeof(AccessTokenCredential).GetField("token", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                var accessToken = field.GetValue(cloudCredentials) as IAccessToken;
                if (accessToken != null)
                {
                    return new HDInsightAccessTokenCredential()
                    {
                        SubscriptionId = currentSubscription.Id,
                        AccessToken = accessToken.AccessToken
                    };
                }
            }
            return null;
        }

        public static IJobSubmissionClientCredential GetJobSubmissionClientCredentials(
            this IAzureHDInsightJobCommandCredentialsBase command,
            AzureSubscription currentSubscription,
            AzureEnvironment environment, string cluster,
            AzureProfile profile)
        {
            IJobSubmissionClientCredential clientCredential = null;
            if (command.Credential != null)
            {
                clientCredential = new BasicAuthCredential
                {
                    Server = GatewayUriResolver.GetGatewayUri(cluster),
                    UserName = command.Credential.UserName,
                    Password = command.Credential.GetCleartextPassword()
                };
            }
            else if (currentSubscription.IsNotNull())
            {
                var subscriptionCredentials = GetSubscriptionCredentials(command, currentSubscription, environment, profile);
                var asCertificateCredentials = subscriptionCredentials as HDInsightCertificateCredential;
                var asTokenCredentials = subscriptionCredentials as HDInsightAccessTokenCredential;
                if (asCertificateCredentials.IsNotNull())
                {
                    clientCredential = new JobSubmissionCertificateCredential(asCertificateCredentials, cluster);
                }
                else if (asTokenCredentials.IsNotNull())
                {
                    clientCredential = new JobSubmissionAccessTokenCredential(asTokenCredentials, cluster);
                }
            }

            return clientCredential;
        }
    }
}
