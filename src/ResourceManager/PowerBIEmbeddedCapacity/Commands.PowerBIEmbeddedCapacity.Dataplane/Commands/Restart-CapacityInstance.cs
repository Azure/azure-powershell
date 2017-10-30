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
using System.Management.Automation;
using System.Management.Instrumentation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane.Models;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an PowerBI Embedded Capacity environment
    /// </summary>
    [Cmdlet("Restart", "AzurePowerBIEmbeddedCapacityInstance", SupportsShouldProcess=true)]
    [Alias("Restart-AzureCapacityInstance")]
    [OutputType(typeof(bool))]
    public class RestartAzurePowerBIEmbeddedCapacity: AzurePSCmdlet
    {
        private string capacityName;

        [Parameter(Mandatory = true, HelpMessage = "Name of the Azure PowerBI Embedded Capacity to restart")]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public IPBIHttpClient PBIHttpClient { get; private set; }

        public ITokenCacheItemProvider TokenCacheItemProvider { get; private set; }

        public RestartAzurePowerBIEmbeddedCapacity()
        {
            this.PBIHttpClient = new PBIHttpClient(() => new HttpClient());
            this.TokenCacheItemProvider = new TokenCacheItemProvider();

        }

        public RestartAzurePowerBIEmbeddedCapacity(IPBIHttpClient PBIHttpClient, ITokenCacheItemProvider TokenCacheItemProvider)
        {
            this.PBIHttpClient = PBIHttpClient;
            this.TokenCacheItemProvider = TokenCacheItemProvider;
        }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Managment context
                return null;
            }
        }

        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (PBIClientSession.Instance.Profile.Environments.Count == 0)
            {
                throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
            }

            capacityName = Instance;
            Uri uriResult;

            // if the user specifies the FQN of the capacity, then extract the capacityname out of that.
            // and set the current context
            if (Uri.TryCreate(Instance, UriKind.Absolute, out uriResult) && uriResult.Scheme == "asazure")
            {
                capacityName = uriResult.PathAndQuery.Trim('/');
                if (string.Compare(PBIClientSession.Instance.Profile.Context.Environment.Name, uriResult.DnsSafeHost, StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    PBIClientSession.Instance.SetCurrentContext(
                        new PBIAccount(),
                        PBIClientSession.Instance.Profile.CreateEnvironment(uriResult.DnsSafeHost));
                }
            }
            else
            {
                var currentContext = PBIClientSession.Instance.Profile.Context;
                if (currentContext != null 
                    && PBIClientSession.PBIRolloutEnvironmentMapping.ContainsKey(currentContext.Environment.Name))
                {
                    throw new PSInvalidOperationException(string.Format(Resources.InvalidCapacityName, capacityName));
                }
            }

            if (this.PBIHttpClient == null)
            {
                this.PBIHttpClient = new PBIHttpClient(() =>
                {
                    return new HttpClient();
                });
            }

            if (this.TokenCacheItemProvider == null)
            {
                this.TokenCacheItemProvider = new TokenCacheItemProvider();
            }
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.RestartingPowerBIEmbeddedCapacity))
            {
                var context = PBIClientSession.Instance.Profile.Context;
                PBIClientSession.Instance.Login(context, null);
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(PBIClientSession.TokenCache, context.Account.UniqueId);

                Uri restartBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var restartEndpoint = string.Format((string)context.Environment.Endpoints[PBIEnvironment.AsRolloutEndpoints.RestartEndpointFormat], capacityName);

                using (HttpResponseMessage message = PBIHttpClient.CallPostAsync(
                    restartBaseUri,
                    restartEndpoint,
                    accessToken).Result)
                {
                    message.EnsureSuccessStatusCode();
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
