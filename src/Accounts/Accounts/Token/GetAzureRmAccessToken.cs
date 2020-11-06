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
using System.Management.Automation;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.PowerShell.Authenticators;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "AccessToken", DefaultParameterSetName = KnownResourceNameParameterSet)]
    [OutputType(typeof(PSAccessToken))]
    public class GetAzureRmAccessTokenCommand : AzureRMCmdlet
    {
        private const string ResourceUrlParameterSet = "ResourceUrl";
        private const string KnownResourceNameParameterSet = "KnownResourceTypeName";

        [Parameter(ParameterSetName = ResourceUrlParameterSet,
            Mandatory = true,
            HelpMessage = "Resource url for that you're requesting token, e.g. 'http://graph.windows.net/'.")]
        [ValidateNotNullOrEmpty]
        [Alias("Resource", "ResourceUri")]
        public string ResourceUrl { get; set; }

        [Parameter(ParameterSetName = KnownResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "Optional resouce type name, supported values: AadGraph, AnalysisServices, Arm, Attestation, Batch, DataLake, KeyVault, OperationalInsights, ResourceManager, Synapse. Default value is Arm if not specified.")]
        [PSArgumentCompleter(
            SupportedResourceNames.AadGraph,
            SupportedResourceNames.AnalysisServices,
            SupportedResourceNames.Arm,
            SupportedResourceNames.Attestation,
            SupportedResourceNames.Batch,
            SupportedResourceNames.DataLake,
            SupportedResourceNames.KeyVault,
            SupportedResourceNames.ManagedHsm,
            SupportedResourceNames.OperationalInsights,
            SupportedResourceNames.ResourceManager,
            SupportedResourceNames.Synapse
            )]
        public string ResourceTypeName { get; set; }

        //Use tenant in default context if not specified
        //TODO: Should not specify TenantId for MSI, CloudShell(?)
        [Parameter(Mandatory = false, HelpMessage = "Optional Tenant Id. Use tenant id of default context if not specified.")]
        public string TenantId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            string resourceUrlOrId;

            if (ParameterSetName == KnownResourceNameParameterSet)
            {
                if (ResourceTypeName == null)
                {
                    ResourceTypeName = SupportedResourceNames.Arm;
                }
                if (!SupportedResourceNames.ResourceNameMap.ContainsKey(ResourceTypeName))
                {
                    throw new ArgumentException(Properties.Resources.InvalidResourceTypeName.FormatInvariant(ResourceTypeName), nameof(ResourceTypeName));
                }
                resourceUrlOrId = SupportedResourceNames.ResourceNameMap[ResourceTypeName];
            }
            else
            {
                resourceUrlOrId = ResourceUrl;
            }

            IAzureContext context = DefaultContext;
            if(TenantId == null)
            {
                TenantId = context.Tenant?.Id;
            }

            IAccessToken accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                                context.Account,
                                context.Environment,
                                TenantId,
                                null,
                                ShowDialog.Never,
                                null,
                                null,
                                resourceUrlOrId);

            var result = new PSAccessToken()
            {
                Token = accessToken.AccessToken,
                TenantId = TenantId,
                UserId = accessToken.UserId,
            };
            result.ExpiresOn = (accessToken as MsalAccessToken)?.ExpiredOn ?? result.ExpiresOn;

            WriteObject(result);
        }

        internal class SupportedResourceNames
        {
            public const string Arm = "Arm";
            public const string AadGraph = "AadGraph";
            public const string Batch = "Batch";
            public const string DataLake = "DataLake";
            public const string KeyVault = "KeyVault";
            public const string ResourceManager = "ResourceManager"; //endpoint is same as Arm

            public const string AnalysisServices = "AnalysisServices";
            public const string Attestation = "Attestation";
            public const string OperationalInsights = "OperationalInsights";
            public const string Synapse = "Synapse";
            public const string ManagedHsm = "ManagedHsm";

            internal static Dictionary<string, string> ResourceNameMap = new Dictionary<string, string>()
            {
                { Arm, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId },
                { AadGraph, AzureEnvironment.Endpoint.GraphEndpointResourceId },
                { Batch, AzureEnvironment.Endpoint.BatchEndpointResourceId },
                { DataLake, AzureEnvironment.Endpoint.DataLakeEndpointResourceId },
                { KeyVault, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId },
                { ResourceManager, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId },

                { AnalysisServices, AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId },
                { Attestation, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId },
                { OperationalInsights, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId },
                { Synapse, AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId },
                { ManagedHsm, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId }
            };
        }
    }
}
