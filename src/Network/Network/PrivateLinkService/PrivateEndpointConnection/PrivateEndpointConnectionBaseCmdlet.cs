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

using Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class PrivateEndpointConnectionBaseCmdlet : NetworkBaseCmdlet, IDynamicParameters
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "ByResource")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
             HelpMessage = "The private link service name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        protected RuntimeDefinedParameterDictionary DynamicParameters;

        public const string privateEndpointTypeName = "PrivateLinkResourceType";
        string NamedContextParameterSet = "ByResource";
        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            RuntimeDefinedParameter namedParameter;
            if (ProviderConfiguration.TryGetProvideServiceParameter(privateEndpointTypeName, NamedContextParameterSet, out namedParameter))
            {
                parameters.Add(privateEndpointTypeName, namedParameter);
            }
            DynamicParameters = parameters;
            return parameters;
        }

        public string PrivateLinkResourceType { get; set; }

        public string Subscription { get; set; }

        protected IPrivateLinkProvider BuildProvider(string subscription, string privateLinkResourceType)
        {
            return PrivateLinkProviderFactory.CreatePrivateLinkProvder(this, subscription, privateLinkResourceType);
        }
    }
}
