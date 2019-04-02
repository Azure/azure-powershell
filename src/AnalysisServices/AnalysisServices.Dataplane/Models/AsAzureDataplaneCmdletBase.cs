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

using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Net.Http;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure Analysis Services Management cmdlets
    /// </summary>
    public abstract class AsAzureDataplaneCmdletBase : AzurePSCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Azure Analysis Services server",
            Position = 0,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// The fully qualified absolute URI of the server instance.
        /// (scheme.region.azureAsEndpoint/serverName)
        /// </summary>
        /// <example>asazure://westus.asazure.windows.net/testserver</example>
        protected string ServerUri;

        /// <summary>
        /// A DNS safe host name for the server.
        /// (region.azureAsEndpoint)
        /// </summary>
        /// <example>westus.asazure.windows.net</example>
        protected string DnsSafeHost;

        /// <summary>
        /// The name of the server.
        /// </summary>
        /// <example>testserver</example>
        protected string ServerName;

        /// <summary>
        /// Field for the current azure context, for the environment and profile.
        /// </summary>
        private IAzureContext _currentContext;

        /// <summary>
        /// Field for the dataplane http client.
        /// </summary>
        private IAsAzureHttpClient _asAzureDataplaneClient;

        /// <summary>
        /// Gets or sets the <see cref="_currentContext"/>.
        /// </summary>
        public IAzureContext CurrentContext
        {
            get
            {
                if (_currentContext == null)
                {
                    _currentContext = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                }

                return _currentContext;
            }

            set { _currentContext = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="_asAzureDataplaneClient"/>.
        /// </summary>
        public IAsAzureHttpClient AsAzureDataplaneClient
        {
            get
            {
                if (_asAzureDataplaneClient == null)
                {
                    _asAzureDataplaneClient = CreateAsAzureDataplaneClient(DnsSafeHost, CurrentContext, () => { return new HttpClient(); });
                }

                return _asAzureDataplaneClient;
            }

            set { _asAzureDataplaneClient = value; }
        }

        /// <inheritdoc cref="AzurePSCmdlet.DefaultContext"/>
        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
                return null;
            }
        }

        /// <inhereitdoc cref="AzurePSCmdlet.DataCollectionWarning"/>
        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        /// <summary>
        /// Creates an instance of an <see cref="AsAzureDataplaneClient"/> based on parameters.
        /// </summary>
        /// <param name="hostUri">The Uri to derive the <see cref="AsAzureDataplaneClient.BaseUri"/> from.</param>
        /// <param name="context">The <see cref="IAzureContext"/> to retrieve ServiceClientCredentials from.</param>
        /// <param name="httpClientProvider"><see cref="AsAzureDataplaneClient.HttpClientProvider"/>.</param>
        /// <returns>An instance of an <see cref="AsAzureDataplaneClient"/>.</returns>
        internal static AsAzureDataplaneClient CreateAsAzureDataplaneClient(string hostUri, IAzureContext context, Func<HttpClient> httpClientProvider)
        {
            if (context == null)
            {
                throw new ArgumentException(Common.Authentication.Properties.Resources.ArmAccountNotFound);
            }

            if (string.IsNullOrEmpty(hostUri))
            {
                throw new ArgumentNullException(nameof(hostUri));
            }

            if (httpClientProvider == null)
            {
                throw new ArgumentNullException(nameof(httpClientProvider));
            }

            var baseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, hostUri));
            var credentials = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId);
            var handlers = AzureSession.Instance.ClientFactory.GetCustomHandlers();
            return AzureSession.Instance.ClientFactory.CreateCustomArmClient<AsAzureDataplaneClient>(baseUri, credentials, httpClientProvider, handlers);
        }

        /// <inheritdoc cref="AzurePSCmdlet.InitializeQosEvent"/>
        protected override void InitializeQosEvent()
        {
            // No data collection for this cmdlet
        }

        /// <inheritdoc cref="AzurePSCmdlet.BeginProcessing"/>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (string.IsNullOrEmpty(Instance))
            {
                throw new ArgumentNullException(nameof(Instance));
            }

            // user must specify the fully qualified server name. For example, asazure://westus2.asazure.windows.net/testserver
            if (!Uri.TryCreate(Instance, UriKind.Absolute, out var uriResult) || uriResult.Scheme != AsAzureEndpoints.UriSchemeAsAzure)
            {
                throw new PSInvalidOperationException(string.Format(Resources.InvalidServerName, Instance));
            }

            // derive all bits of the url from the input
            ServerUri = uriResult.AbsoluteUri;
            DnsSafeHost = uriResult.DnsSafeHost;
            ServerName = uriResult.PathAndQuery.Trim('/');

            if (_asAzureDataplaneClient == null)
            {
                AsAzureDataplaneClient = CreateAsAzureDataplaneClient(DnsSafeHost, CurrentContext, () => { return new HttpClient(); });
            }
        }
    }
}
