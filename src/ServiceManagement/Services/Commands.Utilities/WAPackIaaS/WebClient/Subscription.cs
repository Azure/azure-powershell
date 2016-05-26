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
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal enum CredentialType
    {
        None = 0,
        UseCertificate = 1,
        DefaultCredentials = 2,
        DefaultNetworkCredentials = 3,
        NetworkCredential = 4,
    }

    internal class Subscription
    {
        internal string SubscriptionName { get; set; }
        internal string SubscriptionId { get; set; }
        internal Uri ServiceEndpoint { get; set; }
        internal X509Certificate2 Certificate { get; set; }

        internal CredentialType CredentialType { get; set; }
        private string userName;
        private SecureString password;

        internal Subscription()
        {
            this.SubscriptionName = String.Empty;
            this.SubscriptionId = String.Empty;
            this.ServiceEndpoint = new Uri("http://127.0.0.1:8090");
            this.Certificate = new X509Certificate2();
        }

        internal Subscription(AzureSubscription azureSubscription)
        {
            if (azureSubscription == null)
            {
                throw new ArgumentNullException();
            }

            ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            var environment = client.GetEnvironmentOrDefault(azureSubscription.Environment);

            this.SubscriptionName = azureSubscription.Name;
            this.SubscriptionId = azureSubscription.Id.ToString();
            this.ServiceEndpoint = new Uri(String.Format("{0}/{1}/services/systemcenter/vmm", environment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement).TrimEnd(new[] { '/' }), SubscriptionId));
            this.Certificate = FileUtilities.DataStore.GetCertificate(azureSubscription.Account);
            this.CredentialType = CredentialType.UseCertificate;
        }

        internal void SetNetworkCredentials(string userName, SecureString password)
        {
            this.CredentialType = CredentialType.NetworkCredential;
            this.userName = userName;
            this.password = password;
        }

        internal NetworkCredential GetNetworkCredentials()
        {
            if (String.IsNullOrWhiteSpace(userName) || this.password == null)
            {
                return null;
            }
            
            return new NetworkCredential(this.userName, this.password);
        }
    }
}
