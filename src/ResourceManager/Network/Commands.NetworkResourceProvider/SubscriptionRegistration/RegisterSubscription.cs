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

using Microsoft.Azure.Common.Authentication;
using System;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Join, "AzureCoreResourceProvider")]
    public class JoinAzureCoreResourceProvider : NetworkBaseClient
    {
        [Alias("ResourceProviderName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ValidateSet("Microsoft.Network",
                     "Microsoft.Compute",
                     "Microsoft.Storage",
                     IgnoreCase = true)]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The CSM environment")]
        [ValidateSet("production",
                     "dogfood",
                     IgnoreCase = true)]
        public virtual string Environment { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Register with Network, Storage and Compute resource provider")]
        public SwitchParameter All { get; set; }
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var credentials = (AccessTokenCredential)NetworkClient.NetworkResourceProviderClient.Credentials;

            string host = "https://management.azure.com/";

            if (string.Equals(this.Environment, "dogfood", StringComparison.OrdinalIgnoreCase))
            {
                host = "https://api-dogfood.resources.windows-int.net";
            }

            if (All.IsPresent)
            {
                RegisterResourceProvider(credentials, host, "Microsoft.Network");
                RegisterResourceProvider(credentials, host, "Microsoft.Compute");
                RegisterResourceProvider(credentials, host, "Microsoft.Storage");
            }
            else if (!string.IsNullOrEmpty(this.Name))
            {
                RegisterResourceProvider(credentials, host, this.Name);
            }
            else
            {
                throw new ArgumentException("Please specify a provider name or -all flag");
            }
        }

        private void RegisterResourceProvider(AccessTokenCredential credentials, string host, string resourceProvider)
        {
            var uriString =
                string.Format(
                    "{0}/subscriptions/{1}/providers/{2}/register?api-version=2014-04-01", host, credentials.SubscriptionId, resourceProvider);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uriString);

            this.NetworkClient.NetworkResourceProviderClient.Credentials.ProcessHttpRequestAsync(httpRequestMessage,
                CancellationToken.None).Wait();

            var httpClient = new HttpClient();
            httpClient.SendAsync(httpRequestMessage, CancellationToken.None).Wait();

        }
    }
}

 