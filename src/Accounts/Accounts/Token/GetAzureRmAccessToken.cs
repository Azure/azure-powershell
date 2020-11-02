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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Profile.Token
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "AccessToken")]
    [OutputType(typeof(string))]
    public class GetAzureRmAccessTokenCommand : AzureRMCmdlet
    {
        private const string AuthorizationHeaderName = "Authorization";
        private const string ResourceUriParameterSet = "ResourceUri";
        private const string KnownResourceNameParameterSet = "KnownResourceTypeName";

        //TODO: Support ResourceUri directly
        //[Parameter(ParameterSetName = ResourceUriParameterSet, Mandatory = false)]
        //public string Resource { get; set; }

        [Parameter(ParameterSetName = KnownResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "Optional resouce type name, supported values: AadGraph, Analysis, Arm, Attest, DataLake, KeyVault, OperationInsights, Synapse. Default value is Arm if not specified.")]
        [PSArgumentCompleter(
            SupportedResourceNames.AadGraph,
            SupportedResourceNames.Analysis,
            SupportedResourceNames.Arm,
            SupportedResourceNames.Attest,
            SupportedResourceNames.DataLake,
            SupportedResourceNames.KeyVault,
            SupportedResourceNames.OperationInsights,
            SupportedResourceNames.Synapse
            )]
        public string ResourceTypeName { get; set; }

        //Use tenant in default context if not specified
        [Parameter(Mandatory = false, HelpMessage = "Optional Tenant Id. Use tenant id of default context if not specified.")]
        public string TenantId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string resourceId = null;

            if (ResourceTypeName == null)
            {
                ResourceTypeName = SupportedResourceNames.Arm;
            }
            if (!SupportedResourceNames.ResourceNameMap.ContainsKey(ResourceTypeName))
            {
                throw new ArgumentException(Properties.Resources.InvalidResourceTypeName.FormatInvariant(ResourceTypeName), nameof(ResourceTypeName));
            }

            resourceId = SupportedResourceNames.ResourceNameMap[ResourceTypeName];

            resourceId = string.IsNullOrEmpty(resourceId) ? AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId : resourceId;

            IAzureContext context = DefaultContext;
            if (!string.IsNullOrEmpty(TenantId) && !string.Equals(context.Tenant.Id, TenantId, StringComparison.OrdinalIgnoreCase))
            {
                var profile = DefaultProfile as AzureRmProfile;
                context = profile.Contexts.FirstOrDefault(c =>
                    string.Equals(c.Value.Tenant.Id, TenantId, StringComparison.OrdinalIgnoreCase)).Value;
                if (context == null)
                {
                    throw new ArgumentException(Properties.Resources.InvalidTenantId.FormatInvariant(TenantId), nameof(TenantId));
                }
            }
            var credential = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(
                context,
                resourceId);
            var requestMessage = new HttpRequestMessage();
            credential.ProcessHttpRequestAsync(requestMessage, default(CancellationToken)).ConfigureAwait(false).GetAwaiter().GetResult();
            if (requestMessage.Headers.Contains(AuthorizationHeaderName))
            {
                var token = requestMessage.Headers.GetValues(AuthorizationHeaderName)
                    ?.FirstOrDefault()?.Substring("Bearer ".Length);
                WriteObject(token);
            }
        }

        internal class SupportedResourceNames
        {
            //TODO: Support 'Batch' and 'ManagedHsm', need to upate AzureEnvironmentExtensions.GetTokenAudience() to support more endpoints

            public const string Arm = "Arm";
            public const string AadGraph = "AadGraph";
            public const string DataLake = "DataLake";
            public const string KeyVault = "KeyVault";

            public const string Analysis = "Analysis";
            public const string Attest = "Attest";
            public const string OperationInsights = "OperationInsights";
            public const string Synapse = "Synapse";

            internal static Dictionary<string, string> ResourceNameMap = new Dictionary<string, string>()
            {
                { Arm, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId },
                { AadGraph, AzureEnvironment.Endpoint.Graph}, //Only exception that not using xxxResourceId because of implementation of GetTokenAudience
                { DataLake, AzureEnvironment.Endpoint.DataLakeEndpointResourceId},
                { KeyVault, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId},
                { Analysis, AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId},
                { Attest, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId },
                { OperationInsights, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId},
                { Synapse, AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId},
            };
        }
    }
}
