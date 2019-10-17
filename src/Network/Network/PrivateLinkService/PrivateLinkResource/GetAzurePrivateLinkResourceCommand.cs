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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkResource", DefaultParameterSetName = "ByResourceId"), OutputType(typeof(PSPrivateLinkResource))]
    public class GetAzurePrivateLinkResourceCommand : NetworkBaseCmdlet
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
            HelpMessage = "The service name.",
            ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "ByResource")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource type.",
            ParameterSetName = "ByResource")]
        public string ResourceType { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;

                if (this.ResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Contains("privateLinkResources"))
                {
                    this.Name = resourceIdentifier.ResourceName;
                    this.ResourceType = resourceIdentifier.ResourceType;
                    string parentResource = resourceIdentifier.ParentResource;
                    this.ServiceName = parentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                }
                else
                {
                    throw new ArgumentException(string.Format(Properties.Resources.InvalidResourceId, "[ServiceProvider]/privateLinkResources"));
                }
            }

            IPrivateLinkProvider provider = BuildProvider(this.ResourceType);

            if(provider == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound, "[ServiceProvider]/privateLinkResources"));
            }

            if (ShouldGetByName(this.ResourceGroupName,this.Name))
            {
                var plr = provider.GetPrivateLinkResource(this.ResourceGroupName, this.ServiceName, this.Name);
                WriteObject(plr);
            }
            else
            {
                var plrs = provider.ListPrivateLinkResource(this.ResourceGroupName, this.ServiceName);
                WriteObject(SubResourceWildcardFilter(Name, plrs), true);
            }

        }

        protected IPrivateLinkProvider BuildProvider(string resourceType)
        {
            IPrivateLinkProvider provider = null;

            switch (resourceType.ToLower())
            {
                case "microsoft.sql/servers/privatelinkresources":
                    provider = new SqlProvider(this);
                    break;
                default:
                    break;
            }

            return provider;
        }
    }
}
