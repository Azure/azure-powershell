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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet
    {
<<<<<<< HEAD
=======
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [CmdletParameterBreakingChange("Description", ChangeDescription = "Parameter is being deprecated without being replaced")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The reason of action.")]
        public string Description { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

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
                this.Name = resourceIdentifier.ResourceName;
<<<<<<< HEAD
                resourceType = resourceIdentifier.ResourceType;
                parentResource = resourceIdentifier.ParentResource;
                this.ServiceName = parentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            }

=======
                this.Subscription = resourceIdentifier.Subscription;
                this.PrivateLinkResourceType = resourceIdentifier.ResourceType.Substring(0, resourceIdentifier.ResourceType.LastIndexOf('/'));
                this.ServiceName = resourceIdentifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            }

            IPrivateLinkProvider provider = BuildProvider(this.Subscription, this.PrivateLinkResourceType);

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, ServiceName),
                Properties.Resources.RemoveResourceMessage,
                ServiceName,
                () =>
                {
<<<<<<< HEAD
                    this.PrivateLinkServiceClient.DeletePrivateEndpointConnection(this.ResourceGroupName, this.ServiceName, this.Name);
=======
                    provider.DeletePrivateEndpointConnection(this.ResourceGroupName, this.ServiceName, this.Name);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
