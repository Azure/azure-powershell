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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkResource", DefaultParameterSetName = "ByPrivateLinkResourceId"), OutputType(typeof(PSPrivateLinkResource))]
    public class GetAzurePrivateLinkResourceCommand : NetworkBaseCmdlet, IDynamicParameters
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByPrivateLinkResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The private link service name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        public string PrivateLinkResourceType { get; set; }
        string NamedContextParameterSet = "ByResource";
        private RuntimeDefinedParameterDictionary DynamicParameters;
        public const string privateEndpointTypeName = "PrivateLinkResourceType";
        public string Subscription { get; set; }

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

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.PrivateLinkResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.PrivateLinkResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ServiceName = resourceIdentifier.ResourceName;
                this.PrivateLinkResourceType = resourceIdentifier.ResourceType;
                this.Subscription = resourceIdentifier.Subscription;
            }
            else
            {
                this.Subscription = DefaultProfile.DefaultContext.Subscription.Id;
                this.PrivateLinkResourceType = DynamicParameters[privateEndpointTypeName].Value as string;
            }
            IPrivateLinkProvider provider = PrivateLinkProviderFactory.CreatePrivateLinkProvder(this, Subscription, PrivateLinkResourceType);
            if (provider == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.InvalidResourceId, this.PrivateLinkResourceId));
            }

            var plrs = provider.ListPrivateLinkResource(ResourceGroupName, ServiceName);
            WriteObject(plrs, true);

        }
    }
}
