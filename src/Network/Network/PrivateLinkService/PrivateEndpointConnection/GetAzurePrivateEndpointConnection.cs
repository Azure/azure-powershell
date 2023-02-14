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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId"), OutputType(typeof(PSPrivateEndpointConnection))]
    public class GetAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet, IDynamicParameters
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByPrivateLinkResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        [CmdletParameterBreakingChange("Description", ChangeDescription = "Parameter is being deprecated without being replaced")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The reason of action.")]
        public string Description { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
                this.Subscription = resourceIdentifier.Subscription;
                this.PrivateLinkResourceType = resourceIdentifier.ResourceType.Substring(0, resourceIdentifier.ResourceType.LastIndexOf('/'));
                this.ServiceName = resourceIdentifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            }
            else if (this.IsParameterBound(c => c.PrivateLinkResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.PrivateLinkResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Subscription = resourceIdentifier.Subscription;
                this.PrivateLinkResourceType = resourceIdentifier.ResourceType;
                this.ServiceName = resourceIdentifier.ResourceName;
            }
            else if (this.IsParameterBound(c => c.PrivateLinkResourceType))
            {
                this.Subscription = DefaultProfile.DefaultContext.Subscription.Id;
                this.PrivateLinkResourceType = DynamicParameters[privateEndpointTypeName].Value as string;
            }

            IPrivateLinkProvider provider = BuildProvider(this.Subscription, this.PrivateLinkResourceType);

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                var pec = provider.GetPrivateEndpointConnection(this.ResourceGroupName, this.ServiceName, this.Name);
                WriteObject(pec);
            }
            else
            {
                var pecs = provider.ListPrivateEndpointConnections(this.ResourceGroupName, this.ServiceName);
                WriteObject(SubResourceWildcardFilter(Name, pecs), true);
            }
        }
    }
}
