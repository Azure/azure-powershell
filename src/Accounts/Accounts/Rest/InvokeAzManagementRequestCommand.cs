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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.Internal.Common;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile.Rest
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementRequest", DefaultParameterSetName = ByUri), OutputType(typeof(string))]
    public class InvokeAzManagementRequestCommand : AzureRMCmdlet
    {
        #region Parameter Set

        public const string ByUri = "ByUri";

        public const string ByResourceGroupName = "ByResourceGroupName";

        #endregion

        #region Parameter

        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = false, HelpMessage = "Target Subscription Id")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = true, HelpMessage = "Target Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = true, HelpMessage = "Target Resource Provider Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceProviderName { get; set; }

        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = true, HelpMessage = "Target Resource Type")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceType { get; set; }

        [Parameter(ParameterSetName = ByResourceGroupName, Mandatory = true, HelpMessage = "Target Resource Name")]
        [ValidateNotNullOrEmpty]
        public string[] Name { get; set; }

        [Parameter(ParameterSetName = ByUri, Mandatory = true, HelpMessage = "Target Uri")]
        [ValidateNotNullOrEmpty]
        public string Uri { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Api Version")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Http Method")]
        [ValidateSet("GET", "POST", "PUT", "PATCH", "DELETE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Method { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "JSON format payload")]
        [ValidateNotNullOrEmpty]
        public string Payload { get; set; }

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
            context = DefaultContext;
            string response;

            if (!this.IsParameterBound(c => c.Uri))
            {
                this.Uri = Utils.ConstructUri(this.IsParameterBound(c => c.SubscriptionId) ? this.SubscriptionId : context.Subscription.Id, this.ResourceGroupName, this.ResourceProviderName, this.ResourceType, this.Name, this.ApiVersion);
            }

            switch (this.Method)
            {
                case "GET":
                    response = ServiceClient
                    .Operations
                    .GetResouceGeneric(this.Uri, this.ApiVersion);
                    break;
                case "POST":
                    response = ServiceClient
                    .Operations
                    .PostResouceGeneric(this.Uri, this.ApiVersion, this.Payload);
                    break;
                case "PUT":
                    response = ServiceClient
                    .Operations
                    .PutResouceGeneric(this.Uri, this.ApiVersion, this.Payload);
                    break;
                case "PATCH":
                    response = ServiceClient
                    .Operations
                    .PatchResouceGeneric(this.Uri, this.ApiVersion, this.Payload);
                    break;
                case "DELETE":
                    response = ServiceClient
                    .Operations
                    .DeleteResouceGeneric(this.Uri, this.ApiVersion);
                    break;
                default:
                    throw new PSArgumentException("Invalid HTTP Method");
            }
            WriteObject(response);
        }

        public void ValidateParameters()
        {

        }
    }

}