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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using Microsoft.Azure.Internal.Common;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Text;
using System.Linq;
using System;

namespace Microsoft.Azure.Commands.Profile.Rest
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestMethod", DefaultParameterSetName = ByPath, SupportsShouldProcess = true), OutputType(typeof(PSHttpResponse))]
    [Alias("Invoke-AzRest")]
    public class InvokeAzRestMethodCommand : AzureRMCmdlet
    {
        #region Parameter Set

        public const string ByPath = "ByPath";
        public const string ByParameters = "ByParameters";

        #endregion

        #region Parameter

        [Parameter(ParameterSetName = ByParameters, Mandatory = false, HelpMessage = "Target Subscription Id")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = false, HelpMessage = "Target Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = false, HelpMessage = "Target Resource Provider Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceProviderName { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = false, HelpMessage = "List of Target Resource Type")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceType { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = false, HelpMessage = "list of Target Resource Name")]
        [ValidateNotNullOrEmpty]
        public string[] Name { get; set; }

        [Parameter(ParameterSetName = ByPath, Mandatory = true, HelpMessage = "Target Path")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = true, HelpMessage = "Api Version")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Http Method")]
        [ValidateSet("GET", "POST", "PUT", "PATCH", "DELETE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Method { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "JSON format payload")]
        [ValidateNotNullOrEmpty]
        public string Payload { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        IAzureContext context;
        private IAzureRestClient _client;
        private IAzureRestClient ServiceClient
        {
            get
            {
                if (_client == null)
                {
                    var clientFactory = AzureSession.Instance.ClientFactory;
                    _client = clientFactory.CreateArmClient<AzureRestClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        public override void ExecuteCmdlet()
        {
            this.ValidateParameters();

            context = DefaultContext;
            AzureOperationResponse<string> response;

            if (!this.IsParameterBound(c => c.Path))
            {
                this.Path = ConstructPath(this.IsParameterBound(c => c.SubscriptionId) ? this.SubscriptionId : context.Subscription.Id, this.ResourceGroupName, this.ResourceProviderName, this.ResourceType, this.Name);
            }

            switch (this.Method.ToUpper())
            {
                case "GET":
                    response = ServiceClient
                    .Operations
                    .GetResourceWithFullResponse(this.Path, this.ApiVersion);
                    break;
                case "POST":
                    response = ServiceClient
                    .Operations
                    .PostResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "PUT":
                    response = ServiceClient
                    .Operations
                    .PutResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "PATCH":
                    response = ServiceClient
                    .Operations
                    .PatchResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "DELETE":
                    response = ServiceClient
                    .Operations
                    .DeleteResourceWithFullResponse(this.Path, this.ApiVersion);
                    break;
                default:
                    throw new PSArgumentException("Invalid HTTP Method");
            }

            WriteObject(new PSHttpResponse(response));
        }

        public void ValidateParameters()
        {
            if (this.IsParameterBound(c => this.ResourceType) && !this.IsParameterBound(c => this.Name) && this.ResourceType.Length > 1)
            {
                throw new PSArgumentException("Invalid resource type/name");
            }

            if (!this.IsParameterBound(c => this.ResourceType) && this.IsParameterBound(c => this.Name))
            {
                throw new PSArgumentException("Invalid resource type/name");
            }

            if (this.IsParameterBound(c => this.ResourceType) && this.IsParameterBound(c => this.Name))
            {
                if (this.Name.Length > this.ResourceType.Length || this.ResourceType.Length - this.Name.Length > 1)
                {
                    throw new PSArgumentException("Invalid resource type/name");
                }
            }
        }

        private const string Subscriptions = "subscriptions";

        private const string ResourceGroups = "resourceGroups";

        private const string Providers = "providers";

        private const string slash = "/";

        private const string API_VERSION = "api-version";

        private string ConstructPath(string sub, string rg, string rp, string[] types, string[] names)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(slash + Subscriptions);
            sb.Append(slash + sub);

            if (rg != null && rg.Length != 0)
            {
                sb.Append(slash + ResourceGroups);
                sb.Append(slash + rg);
            }

            if (rp != null && rp.Length != 0)
            {
                sb.Append(slash + Providers);
                sb.Append(slash + rp);
            }

            if (types != null && types.Length != 0)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    sb.Append(slash + types[i]);
                    if (names != null && i != names.Length)
                    {
                        sb.Append(slash + names[i]);
                    }       
                }
            }
            return sb.ToString();
        }
    }
}
