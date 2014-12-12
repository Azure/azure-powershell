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
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Join, "AzureCoreResourceProvider"), OutputType(typeof(PSPublicIpAddress))]
    public class JoinAzureCoreResourceProvider : NetworkBaseClient
    {
        [Alias("ResourceProviderName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Register with Network, Storage and Compute resource provider")]
        public SwitchParameter All { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var credentials = (AccessTokenCredential)NetworkClient.NetworkResourceProviderClient.Credentials;

            if (All.IsPresent)
            {
                RegisterResourceProvider(credentials, "Microsoft.Network");
                RegisterResourceProvider(credentials, "Microsoft.Compute");
                RegisterResourceProvider(credentials, "Microsoft.Storage");
            }
            else if (!string.IsNullOrEmpty(this.Name))
            {
                RegisterResourceProvider(credentials, this.Name);
            }
            else
            {
                throw new ArgumentException("Please specify a provider name or -all flag");
            }
        }

        private void RegisterResourceProvider(AccessTokenCredential credentials, string resourceProvider)
        {
            var uriString =
                string.Format(
                    "https://api-dogfood.resources.windows-int.net/subscriptions/{0}/providers/{1}/register?api-version=2014-04-01", credentials.SubscriptionId, resourceProvider);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriString);

            this.NetworkClient.NetworkResourceProviderClient.Credentials.ProcessHttpRequestAsync(httpRequestMessage,
                CancellationToken.None).Wait();

            var httpClient = new HttpClient();
            httpClient.SendAsync(httpRequestMessage, CancellationToken.None).Wait();

        }
    }
}

 