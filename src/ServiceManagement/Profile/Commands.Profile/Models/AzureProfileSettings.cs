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
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    /// <summary>
    /// Configuration for generating an Azure Profile using certificate or AAD credentials
    /// </summary>
    public class AzureProfileSettings
    {
        public AzureEnvironment Environment { get; set; }

        public string SubscriptionId { get; set; }

        public string StorageAccount { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public PSCredential Credential { get; set; }

        public string Tenant { get; set; }

        public string AccessToken { get; set; }

        public string AccountId { get; set; }

        public static AzureProfileSettings Create(NewAzureProfileCommand command)
        {
            return new AzureProfileSettings
            {
                Environment = command.Environment,
                SubscriptionId = command.SubscriptionId,
                StorageAccount = command.StorageAccount,
                Certificate = command.Certificate,
                Credential = command.Credential,
                Tenant = command.Tenant,
                AccessToken = command.AccessToken,
                AccountId = command.AccountId
            };
        }
    }
}
