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
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Orders
{
    [Cmdlet(VerbsCommon.Get, Constants.Order, DefaultParameterSetName = GetByNameParameterSet
     ),
     OutputType(typeof(PSDataBoxEdgeOrder))
    ]
    public class DataBoxEdgeOrderGetCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByDeviceObjectParameterSet = "GetByDeviceObjectParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";


        [Parameter(Mandatory = true,
            ParameterSetName = GetByDeviceObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSDataBoxEdgeDevice DeviceObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]

        public string ResourceId { get; set; }


        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
        Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true, 
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        private Order GetResource()
        {
            return this.DataBoxEdgeManagementClient.Orders.Get(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private List<PSDataBoxEdgeOrder> ListResourceByName()
        {
            var order = GetResource();
            return new List<PSDataBoxEdgeOrder>() {new PSDataBoxEdgeOrder(order)};
        }

        private List<PSDataBoxEdgeOrder> ListResource()
        {
            return ListResourceByName();
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DeviceName = resourceIdentifier.DeviceName;
            }

            if (this.IsParameterBound(c => c.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.Name;
            }

            WriteObject(ListResource(), true);
        }
    }
}