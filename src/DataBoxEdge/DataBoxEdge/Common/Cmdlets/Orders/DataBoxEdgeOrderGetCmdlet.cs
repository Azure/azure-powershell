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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ResourceModel = Microsoft.Azure.Management.EdgeGateway.Models.Order;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeOrder;


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Orders
{
    [Cmdlet(VerbsCommon.Get, Constants.Order, DefaultParameterSetName = GetByNameParameterSet
     ),
     OutputType(typeof(PSResourceModel)),
     OutputType(typeof(PSDataBoxEdgeOrderStatus)),
     OutputType(typeof(PSDataBoxEdgeOrderTrackingInfo)),
    ]
    public class DataBoxEdgeOrderGetCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByDeviceObjectParameterSet = "GetByDeviceObjectParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";


        [Parameter(Mandatory = true,
            ParameterSetName = GetByDeviceObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSDataBoxEdgeDevice DeviceObject { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.ForwardTrackingInfo)]
        public SwitchParameter ForwardTrackingInfo;

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.ReturnTrackingInfo)]
        public SwitchParameter ReturnTrackingInfo;


        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.CurrentOrderStatus)]
        public SwitchParameter OrderStatus;

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.OrderStatusHistory)]
        public SwitchParameter OrderStatusHistory;

        private ResourceModel GetResourceModel()
        {
            return this.DataBoxEdgeManagementClient.Orders.Get(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private List<PSResourceModel> ListResourceByName()
        {
            var resourceModel = GetResourceModel();
            return new List<PSResourceModel>() {new PSResourceModel(resourceModel)};
        }

        private List<PSResourceModel> ListResource()
        {
            return ListResourceByName();
        }

        private List<PSDataBoxEdgeOrderTrackingInfo> ListTrackingInfo()
        {
            var resourceModel = GetResourceModel();
            return resourceModel.DeliveryTrackingInfo.Select(t => new PSDataBoxEdgeOrderTrackingInfo(t)).ToList();
        }

        private List<PSDataBoxEdgeOrderTrackingInfo> ListReturnTrackingInfo()
        {
            var resourceModel = GetResourceModel();
            return resourceModel.ReturnTrackingInfo.Select(t => new PSDataBoxEdgeOrderTrackingInfo(t)).ToList();
        }

        private PSDataBoxEdgeOrderStatus GetCurrentOrderStatus()
        {
            var resourceModel = GetResourceModel();
            return new PSDataBoxEdgeOrderStatus(resourceModel.CurrentStatus);
        }

        private List<PSDataBoxEdgeOrderStatus> ListOrderStatusHistory()
        {
            var resourceModel = GetResourceModel();
            return resourceModel.OrderHistory.Select(t => new PSDataBoxEdgeOrderStatus(t)).ToList();
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

            if (this.ForwardTrackingInfo.IsPresent)
            {
                WriteObject(ListTrackingInfo(), true);
            }
            else if (this.ReturnTrackingInfo.IsPresent)
            {
                WriteObject(ListReturnTrackingInfo(), true);
            }
            else if (this.OrderStatus.IsPresent)
            {
                WriteObject(GetCurrentOrderStatus(), true);
            }
            else if (this.OrderStatusHistory.IsPresent)
            {
                WriteObject(ListOrderStatusHistory(), true);
            }
            else
            {
                WriteObject(ListResource(), true);
            }


        }
    }
}