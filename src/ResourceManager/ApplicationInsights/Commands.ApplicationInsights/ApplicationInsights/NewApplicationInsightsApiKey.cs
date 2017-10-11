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

using Microsoft.Azure.Commands.ApplicationInsights.Models;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    [Cmdlet(VerbsCommon.New, ApplicationInsightsApiKeyNounStr), OutputType(typeof(PSApiKey))]
    public class NewAzureApplicationInsightsApiKeyCommand : ApplicationInsightsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Component Name.")]
        [Alias(ApplicationInsightsComponentNameAlias, ComponentNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Permissions that API key allow apps to do.")]
        [Alias(ApplicationKindAlias)]
        [ValidateSet(PermissionType.ReadTelemetry,
            PermissionType.WriteAnnotations,
            PermissionType.AuthenticateSDKControlChannel,
            IgnoreCase = true)]
        public string[] Permissions { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "API Key identify name.")]
        [ValidateNotNullOrEmpty]
        public string ApiKeyName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            APIKeyRequest apiKeyRequest = new APIKeyRequest();
            apiKeyRequest.Name = this.ApiKeyName;

            var access = PSApiKey.BuildApiKeyAccess(this.SubscriptionId, this.ResourceGroupName, this.Name, this.Permissions);
            apiKeyRequest.LinkedReadProperties = access.Item1;
            apiKeyRequest.LinkedWriteProperties = access.Item2;

            var apiKeyResponse = this.AppInsightsManagementClient
                                                    .APIKeys
                                                    .CreateWithHttpMessagesAsync(
                                                        this.ResourceGroupName,
                                                        this.Name,
                                                        apiKeyRequest)
                                                    .GetAwaiter()
                                                    .GetResult();

            WriteComponentApiKey(apiKeyResponse.Body);
        }
    }
}
