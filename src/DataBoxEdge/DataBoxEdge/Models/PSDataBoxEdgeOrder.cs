using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using DataBoxEdgeOrder = Microsoft.Azure.Management.DataBoxEdge.Models.Order;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeOrder
    {
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeOrder.CurrentStatus.Status", Position = 2)]
        [Ps1Xml(Label = "UpdatedDatetime", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeOrder.CurrentStatus.UpdateDateTime", Position = 3)]
        public DataBoxEdgeOrder DataBoxEdgeOrder;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 0)]
        public string DeviceName;

        public string Id;
        public List<PSDataBoxEdgeOrderStatus> OrderHistory;
        public List<PSDataBoxEdgeOrderTrackingInfo> ForwardTrackingInfo;
        public List<PSDataBoxEdgeOrderTrackingInfo> ReturnTrackingInfo;
        public Address ShippingAddress;

        public PSDataBoxEdgeOrder()
        {
            DataBoxEdgeOrder = new DataBoxEdgeOrder();
        }

        public PSDataBoxEdgeOrder(DataBoxEdgeOrder dataBoxEdgeOrder)
        {
            if (dataBoxEdgeOrder == null)
            {
                throw new ArgumentNullException("dataBoxEdgeOrder");
            }

            this.DataBoxEdgeOrder = dataBoxEdgeOrder;
            this.Id = dataBoxEdgeOrder.Id;
            var dataBoxEdgeResourceIdentifier = new DataBoxEdgeResourceIdentifier(dataBoxEdgeOrder.Id);
            this.ResourceGroupName = dataBoxEdgeResourceIdentifier.ResourceGroupName;
            this.DeviceName = dataBoxEdgeResourceIdentifier.DeviceName;
            OrderHistory = dataBoxEdgeOrder.OrderHistory.Select(t => new PSDataBoxEdgeOrderStatus(t)).ToList();
            ForwardTrackingInfo = dataBoxEdgeOrder.DeliveryTrackingInfo
                .Select(t => new PSDataBoxEdgeOrderTrackingInfo(t)).ToList();
            ReturnTrackingInfo = dataBoxEdgeOrder.ReturnTrackingInfo.Select(t => new PSDataBoxEdgeOrderTrackingInfo(t))
                .ToList();
            ShippingAddress = dataBoxEdgeOrder.ShippingAddress;
        }
    }
}