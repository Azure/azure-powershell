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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpointConnection", DefaultParameterSetName = "ByResourceId", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzurePrivateEndpointConnection : PrivateEndpointConnectionBaseCmdlet
    {
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

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, ServiceName),
                Properties.Resources.RemoveResourceMessage,
                ServiceName,
                () =>
                {
                    provider.DeletePrivateEndpointConnection(this.ResourceGroupName, this.ServiceName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
