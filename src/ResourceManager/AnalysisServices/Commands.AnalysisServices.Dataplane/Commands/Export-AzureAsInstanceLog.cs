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
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to export an Analysis Services server log to file
    /// </summary>
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzurePrefix + "AnalysisServicesInstanceLog", SupportsShouldProcess=true)]
    [Alias("Export-AzureAsInstanceLog")]
    [OutputType(typeof(void))]
    public class ExportAzureAnalysisServerLog : AzurePSCmdlet
    {
        private string _serverName;

        [Parameter(Mandatory = true, HelpMessage = "Name of the Azure Analysis Services which log will be fetched")]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Path to file to write Azure Analysis Services log")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite file if exists")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public IAsAzureHttpClient AsAzureHttpClient { get; private set; }

        public ITokenCacheItemProvider TokenCacheItemProvider { get; private set; }

        public ExportAzureAnalysisServerLog()
        {
            AsAzureHttpClient = new AsAzureHttpClient(() => new HttpClient());
            TokenCacheItemProvider = new TokenCacheItemProvider();
        }

        public ExportAzureAnalysisServerLog(IAsAzureHttpClient asAzureHttpClient, ITokenCacheItemProvider tokenCacheItemProvider)
        {
            AsAzureHttpClient = asAzureHttpClient;
            TokenCacheItemProvider = tokenCacheItemProvider;
        }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
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

            if (AsAzureClientSession.Instance.Profile.Environments.Count == 0)
            {
                throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
            }

            _serverName = Instance;
            Uri uriResult;

            // if the user specifies the FQN of the server, then extract the server name out of that.
            // and set the current context
            if (Uri.TryCreate(Instance, UriKind.Absolute, out uriResult) && uriResult.Scheme == "asazure")
            {
                _serverName = uriResult.PathAndQuery.Trim('/');
                if (string.Compare(AsAzureClientSession.Instance.Profile.Context.Environment.Name, uriResult.DnsSafeHost, StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    AsAzureClientSession.Instance.SetCurrentContext(
                        new AsAzureAccount(),
                        AsAzureClientSession.Instance.Profile.CreateEnvironment(uriResult.DnsSafeHost));
                }
            }
            else
            {
                var currentContext = AsAzureClientSession.Instance.Profile.Context;
                if (currentContext != null
                    && AsAzureClientSession.AsAzureRolloutEnvironmentMapping.ContainsKey(currentContext.Environment.Name))
                {
                    throw new PSInvalidOperationException(string.Format(Resources.InvalidServerName, _serverName));
                }
            }

            if (AsAzureHttpClient == null)
            {
                AsAzureHttpClient = new AsAzureHttpClient(() => new HttpClient());
            }

            if (TokenCacheItemProvider == null)
            {
                TokenCacheItemProvider = new TokenCacheItemProvider();
            }
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.ExportingLogFromAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);

                var accessToken = TokenCacheItemProvider.GetTokenFromTokenCache(
                    AsAzureClientSession.TokenCache, context.Account.UniqueId);

                var logfileBaseUri = new Uri($"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}{context.Environment.Name}");

                var resolvedUriBuilder = new UriBuilder(logfileBaseUri)
                {
                    Host = ClusterResolve(logfileBaseUri, accessToken, _serverName)
                };

                var logfileEndpoint = string.Format(
                        (string) context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.LogfileEndpointFormat],
                        _serverName);

                AsAzureHttpClient.resetHttpClient();
                using (var message = AsAzureHttpClient.CallGetAsync(
                    resolvedUriBuilder.Uri,
                    logfileEndpoint,
                    accessToken).ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    message.EnsureSuccessStatusCode();
                    var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ExportingLogOverwriteWarning, OutputPath);
                    if (AzureSession.Instance.DataStore.FileExists(OutputPath) && !Force.IsPresent && !ShouldContinue(actionWarning, Resources.Confirm))
                    {
                        return;
                    }
                    AzureSession.Instance.DataStore.WriteFile(OutputPath, message.Content.ReadAsStringAsync().Result);
                }
            }
        }

        private string ClusterResolve(Uri clusterUri, string accessToken, string serverName)
        {
            const string resolveEndpoint = "/webapi/clusterResolve";
            var content = new StringContent($"ServerName={serverName}");
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            
            using (var message = AsAzureHttpClient.CallPostAsync(
                clusterUri,
                resolveEndpoint,
                accessToken,
                content).Result)
            {
                message.EnsureSuccessStatusCode();
                var rawResult = message.Content.ReadAsStringAsync().Result;
                var jsonResult = JObject.Parse(rawResult);
                return jsonResult["clusterFQDN"].ToString();
            }
        }
    }
}
