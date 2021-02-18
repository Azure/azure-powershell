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
namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection"), OutputType(typeof(PSPrivateLinkService))]
    public class SetAzurePrivateEndpointConnection : PrivateLinkServiceBaseCmdlet
=======
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId"), OutputType(typeof(PSPrivateEndpointConnection))]
    public class SetAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The private link service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }
=======
            HelpMessage = "The resource name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Approved or rejected the resource.")]
        [PSArgumentCompleter("Approved","Rejected","Removed")]
<<<<<<< HEAD
        [ValidateNotNullOrEmpty]
        public string PrivateLinkServiceConnectionState { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The reason of action.")]
=======
        public string PrivateLinkServiceConnectionState { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The reason of action.")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string Description { get; set; }

        public override void Execute()
        {
            base.Execute();

<<<<<<< HEAD
            var psPrivateLinkService = this.GetPrivateLinkService(ResourceGroupName, ServiceName);
            var obj = psPrivateLinkService.PrivateEndpointConnections.Find(x => x.Name == Name);
            if (obj != null)
            {
                obj.PrivateLinkServiceConnectionState.Status = PrivateLinkServiceConnectionState;
                obj.PrivateLinkServiceConnectionState.Description = Description;

                var plsConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PrivateEndpointConnection>(obj);
                this.PrivateLinkServiceClient.UpdatePrivateEndpointConnection(ResourceGroupName, ServiceName, Name, plsConnectionModel);

                var getPrivateLinkService = GetPrivateLinkService(ResourceGroupName, ServiceName);
                WriteObject(getPrivateLinkService);
            }
=======
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
                this.Subscription = resourceIdentifier.Subscription;
                this.PrivateLinkResourceType = resourceIdentifier.ResourceType.Substring(0, resourceIdentifier.ResourceType.LastIndexOf('/'));
                this.ServiceName = resourceIdentifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            }

            IPrivateLinkProvider provider = BuildProvider(this.Subscription, this.PrivateLinkResourceType);

            var pec = provider.UpdatePrivateEndpointConnectionStatus(this.ResourceGroupName, this.ServiceName, this.Name, this.PrivateLinkServiceConnectionState, this.Description);
            WriteObject(pec);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
