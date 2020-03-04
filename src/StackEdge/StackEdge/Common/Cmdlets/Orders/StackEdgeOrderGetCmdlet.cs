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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Orders
{
    [Cmdlet(VerbsCommon.Get, Constants.Order, DefaultParameterSetName = GetByNameParameterSet
     ),
     OutputType(typeof(PSStackEdgeOrder))
    ]
    public class StackEdgeOrderGetCmdlet : AzureStackEdgeCmdletBase
    {
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByDeviceObjectParameterSet = "GetByDeviceObjectParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";


        [Parameter(Mandatory = true,
            ParameterSetName = GetByDeviceObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.DeviceAlias)]
        public PSStackEdgeOrder DeviceObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        private IPage<Order> ListResource()
        {
            return this.StackEdgeManagementClient.Orders.ListByDataBoxEdgeDevice(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private IPage<Order> ListResource(string nextPageLink)
        {
            return this.StackEdgeManagementClient.Orders.ListByDataBoxEdgeDeviceNext(
                nextPageLink);
        }

        private List<PSStackEdgeOrder> ListPSResource()
        {
            var listResource = ListResource();
            var paginatedResult = new List<Order>(listResource);
            while (!string.IsNullOrEmpty(listResource.NextPageLink))
            {
                listResource = ListResource(listResource.NextPageLink);
                paginatedResult.AddRange(listResource);
            }

            return paginatedResult.Select(t => new PSStackEdgeOrder(t)).ToList();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new StackEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
            }

            if (this.IsParameterBound(c => c.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.DeviceName;
            }

            WriteObject(ListPSResource(), true);
        }
    }
}