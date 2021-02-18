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

<<<<<<< HEAD
using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
=======
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId"), OutputType(typeof(PSPrivateEndpointConnection))]
<<<<<<< HEAD
    public class GetAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet
    {
=======
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

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override void Execute()
        {
            base.Execute();

<<<<<<< HEAD
            string resourceType = string.Empty;
            string parentResource = string.Empty;

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
<<<<<<< HEAD
                if (this.ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Contains("privateEndpointConnections"))
                {
                    this.Name = resourceIdentifier.ResourceName;
                    resourceType = resourceIdentifier.ResourceType;
                    parentResource = resourceIdentifier.ParentResource;
                    this.ServiceName = parentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                }
                else
                {
                    this.ServiceName = resourceIdentifier.ResourceName;
                }
            }

            var psPrivateLinkService = this.GetPrivateLinkService(ResourceGroupName, ServiceName);

            if (!string.IsNullOrEmpty(this.Name))
            {
                var peConnection = psPrivateLinkService.PrivateEndpointConnections.FirstOrDefault(
                        resource =>
                            string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

                if (peConnection == null)
                {
                    throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.Name));
                }

                WriteObject(peConnection);
            }
            else
            {
                var peConnections = psPrivateLinkService.PrivateEndpointConnections;
                WriteObject(peConnections, true);
            }

=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
