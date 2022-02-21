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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Internal.Common;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Rest
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestMethod", DefaultParameterSetName = ByPath, SupportsShouldProcess = true), OutputType(typeof(PSHttpResponse))]
    [Alias("Invoke-AzRest")]
    public class InvokeAzRestMethodCommand : AzureRMCmdlet
    {
        #region Parameter Set

        public const string ByPath = "ByPath";
        public const string ByURI = "ByURI";
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

        [Parameter(ParameterSetName = ByPath, Mandatory = true, HelpMessage = "Path of target resource URL. Hostname of Resource Manager should not be added.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(ParameterSetName = ByParameters, Mandatory = true, HelpMessage = "Api Version")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        [Parameter(ParameterSetName = ByURI, Mandatory = true, Position = 1, HelpMessage = "Uniform Resource Identifier of the Azure resources. " +
            "The target resource needs to support Azure AD authentication and the access token is derived according to resource id. " +
            "If resource id is not set, its value is derived according to built-in service suffixes in current Azure Environment.")]
        [ValidateNotNullOrEmpty]
        public Uri Uri { get; set; }

        [Parameter(ParameterSetName = ByURI, Mandatory = false, HelpMessage = "Identifier URI specified by the REST API you are calling. " +
            "It shouldn't be the resource id of Azure Resource Manager.")]
        [ValidateNotNullOrEmpty]
        public Uri ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies the method used for the web request. Defaults to GET.")]
        [ValidateSet("GET", "POST", "PUT", "PATCH", "DELETE", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Method { get; set; } = "GET";

        [Parameter(Mandatory = false, HelpMessage = "JSON format payload")]
        [ValidateNotNullOrEmpty]
        public string Payload { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        IAzureContext context;

        public override void ExecuteCmdlet()
        {
            this.ValidateParameters();

            context = DefaultContext;
            AzureOperationResponse<string> response;

            if (ByParameters.Equals(this.ParameterSetName))
            {
                this.Path = ConstructPath(this.IsParameterBound(c => c.SubscriptionId) ? this.SubscriptionId : context.Subscription.Id, this.ResourceGroupName, this.ResourceProviderName, this.ResourceType, this.Name);
            }
            else if (ByURI.Equals(this.ParameterSetName))
            {
                this.Path = Uri.PathAndQuery;
            }

            IAzureRestClient serviceClient = null;
            if (ByPath.Equals(this.ParameterSetName) || ByParameters.Equals(this.ParameterSetName))
            {
                serviceClient = AzureSession.Instance.ClientFactory.CreateArmClient<AzureRestClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            }
            else if (ByURI.Equals(this.ParameterSetName))
            {
                string targetResourceIdKey = null;
                string resourceId = this.IsParameterBound(c => c.ResourceId) ? ResourceId.ToString() : null; 
                if(this.IsParameterBound(c => c.ResourceId) 
                    && context.Environment.ActiveDirectoryServiceEndpointResourceId.Equals(resourceId) 
                    && !HasSameEndpoint(Uri.Authority, context.Environment.ResourceManagerUrl))
                {
                    throw new AzPSArgumentException("The resource ID of Azure Resource Manager cannot be used for other endpoint. Please make sure to input the correct resource ID that matches the request URI.",
                        nameof(ResourceId));
                }
                var targetResourceId = string.IsNullOrEmpty(resourceId) ? MatchResourceId(context, Uri.Authority, out targetResourceIdKey) : resourceId;
                if (string.IsNullOrWhiteSpace(targetResourceId))
                {
                    throw new AzPSArgumentException("Cannot find resource id(audience) for authentication", nameof(ResourceId));
                }

                ServiceClientCredentials creds = null;
                if (AzureSession.Instance.AuthenticationFactory is Commands.Common.Authentication.Factories.AuthenticationFactory factory)
                {
                    creds = factory.GetServiceClientCredentials(context, targetResourceIdKey, targetResourceId);
                }
                else
                {
                    creds = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, targetResourceId);
                }
                Uri baseUri = new Uri($"{Uri.Scheme}://{Uri.Authority}");
                serviceClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<AzureRestClient>(baseUri, creds);
            }
            else
            {
                WriteErrorWithTimestamp("Parameter set is not implemented");
            }

            switch (this.Method.ToUpper())
            {
                case "GET":
                    response = serviceClient
                    .Operations
                    .GetResourceWithFullResponse(this.Path, this.ApiVersion);
                    break;
                case "POST":
                    response = serviceClient
                    .Operations
                    .PostResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "PUT":
                    response = serviceClient
                    .Operations
                    .PutResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "PATCH":
                    response = serviceClient
                    .Operations
                    .PatchResourceWithFullResponse(this.Path, this.ApiVersion, this.Payload);
                    break;
                case "DELETE":
                    response = serviceClient
                    .Operations
                    .DeleteResourceWithFullResponse(this.Path, this.ApiVersion);
                    break;
                default:
                    throw new AzPSArgumentException("Invalid HTTP Method", nameof(Method));
            }

            WriteObject(new PSHttpResponse(response));
        }

        private string MatchResourceId(IAzureContext context, string authority, out string targetResourceIdKey)
        {
            var env = context.Environment;
            targetResourceIdKey = null;
            if (HasSameEndpoint(authority, env.ResourceManagerUrl))
            {
                targetResourceIdKey = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId;
                return env.ActiveDirectoryServiceEndpointResourceId;
            }
            if (HasSameEndpoint(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.MicrosoftGraphEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.MicrosoftGraphEndpointResourceId];
            }
            if (HasSameEndpointSuffix(authority, env.AzureKeyVaultDnsSuffix))
            {
                targetResourceIdKey = AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId;
                return env.AzureKeyVaultServiceEndpointResourceId;
            }
            if (HasSameEndpointSuffix(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointSuffix]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId];
            }
            if (HasSameEndpointSuffix(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId];
            }
            if (HasSameEndpoint(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            }
            if (HasSameEndpointSuffix(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointSuffix]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId];
            }
            if (HasSameEndpointSuffix(authority, env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]))
            {
                targetResourceIdKey = AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId;
                return env.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId];
            }
            if (HasSameEndpointSuffix(authority, env.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix))
            {
                targetResourceIdKey = AzureEnvironment.Endpoint.DataLakeEndpointResourceId;
                return env.DataLakeEndpointResourceId;
            }
            if (HasSameEndpointSuffix(authority, env.AzureDataLakeStoreFileSystemEndpointSuffix))
            {
                targetResourceIdKey = AzureEnvironment.Endpoint.DataLakeEndpointResourceId;
                return env.DataLakeEndpointResourceId;
            }
            return null;
        }

        private bool HasSameEndpointSuffix(string sourceAuthority, string targetSuffix)
        {
            if (string.IsNullOrWhiteSpace(targetSuffix) || string.IsNullOrWhiteSpace(sourceAuthority))
            {
                return false;
            }
            return sourceAuthority.EndsWith(targetSuffix, StringComparison.OrdinalIgnoreCase);
        }

        private bool HasSameEndpoint(string sourceAuthority, string targetUri)
        {
            if (string.IsNullOrWhiteSpace(targetUri) || string.IsNullOrWhiteSpace(sourceAuthority))
            {
                return false;
            }
            try
            {
                var targetAuthority = (new Uri(targetUri)).Authority;
                return sourceAuthority.Equals(targetAuthority, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                WriteDebug($"Cannot get authority from {targetUri}");
            }
            return false;
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
