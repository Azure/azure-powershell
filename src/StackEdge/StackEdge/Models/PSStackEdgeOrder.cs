using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using StackEdgeOrder = Microsoft.Azure.Management.DataBoxEdge.Models.Order;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeOrder
    {
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeOrder.CurrentStatus.Status", Position = 2)]
        [Ps1Xml(Label = "UpdatedDatetime", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeOrder.CurrentStatus.UpdateDateTime", Position = 3)]
        public StackEdgeOrder StackEdgeOrder;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 0)]
        public string DeviceName;

        public string Id;
        public List<PSStackEdgeOrderStatus> OrderHistory;
        public List<PSStackEdgeOrderTrackingInfo> ForwardTrackingInfo;
        public List<PSStackEdgeOrderTrackingInfo> ReturnTrackingInfo;
        public Address ShippingAddress;

        public PSStackEdgeOrder()
        {
            StackEdgeOrder = new StackEdgeOrder();
        }

        public PSStackEdgeOrder(StackEdgeOrder stackEdgeOrder)
        {
            if (stackEdgeOrder == null)
            {
                throw new ArgumentNullException("stackEdgeOrder");
            }

            this.StackEdgeOrder = stackEdgeOrder;
            this.Id = stackEdgeOrder.Id;
            var stackEdgeResourceIdentifier = new StackEdgeResourceIdentifier(stackEdgeOrder.Id);
            this.ResourceGroupName = stackEdgeResourceIdentifier.ResourceGroupName;
            this.DeviceName = stackEdgeResourceIdentifier.DeviceName;
            OrderHistory = stackEdgeOrder.OrderHistory.Select(t => new PSStackEdgeOrderStatus(t)).ToList();
            ForwardTrackingInfo = stackEdgeOrder.DeliveryTrackingInfo
                .Select(t => new PSStackEdgeOrderTrackingInfo(t)).ToList();
            ReturnTrackingInfo = stackEdgeOrder.ReturnTrackingInfo.Select(t => new PSStackEdgeOrderTrackingInfo(t))
                .ToList();
            ShippingAddress = stackEdgeOrder.ShippingAddress;
        }
    }
}