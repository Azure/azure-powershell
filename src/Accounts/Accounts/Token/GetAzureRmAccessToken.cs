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
using System.Text.Json;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "AccessToken", DefaultParameterSetName = KnownResourceNameParameterSet)]
    [OutputType(typeof(PSAccessToken))]
    public class GetAzureRmAccessTokenCommand : AzureRMCmdlet
    {
        private const string ResourceUrlParameterSet = "ResourceUrl";
        private const string KnownResourceNameParameterSet = "KnownResourceTypeName";
        private static DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        [Parameter(ParameterSetName = ResourceUrlParameterSet,
            Mandatory = true,
            HelpMessage = "Resource url for that you're requesting token, e.g. 'http://graph.windows.net/'.")]
        [ValidateNotNullOrEmpty]
        [Alias("Resource", "ResourceUri")]
        public string ResourceUrl { get; set; }

        [Parameter(ParameterSetName = KnownResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "Optional resouce type name, supported values: AadGraph, AnalysisServices, Arm, Attestation, Batch, DataLake, KeyVault, OperationalInsights, ResourceManager, Storage, Synapse. Default value is Arm if not specified.")]
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
            SupportedResourceNames.Storage,
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
            result.ExpiresOn = (accessToken as MsalAccessToken)?.ExpiresOn ?? result.ExpiresOn;
            if(result.ExpiresOn == default(DateTimeOffset))
            {
                try
                {
                    var tokenParts = accessToken.AccessToken.Split('.');
                    var decodedToken = Base64UrlHelper.DecodeToString(tokenParts[1]);

                    var tokenDocument = JsonDocument.Parse(decodedToken);
                    int expSeconds = tokenDocument.RootElement.EnumerateObject()
                                    .Where(p => p.Name == "exp")
                                    .Select(p => p.Value.GetInt32())
                                    .First();
                    result.ExpiresOn = UnixEpoch.AddSeconds(expSeconds);
                }
                catch(Exception e)//Ignore exception if fails to parse exp from token
                {
                    WriteDebug("Unable to parse exp in token: " + e.ToString());
                }
            }

            WriteObject(result);
        }
    }
}
