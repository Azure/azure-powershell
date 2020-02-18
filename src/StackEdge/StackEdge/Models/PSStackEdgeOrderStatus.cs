using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using StackEdgeOrderStatus = Microsoft.Azure.Management.DataBoxEdge.Models.OrderStatus;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeOrderStatus
    {
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeOrderStatus.Status", Position = 0)]
        [Ps1Xml(Label = "UpdateDateTime", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeOrderStatus.UpdateDateTime", Position = 1)]
        public StackEdgeOrderStatus StackEdgeOrderStatus;


        public string Id;

        public PSStackEdgeOrderStatus()
        {
            StackEdgeOrderStatus = new StackEdgeOrderStatus();
        }

        public PSStackEdgeOrderStatus(StackEdgeOrderStatus stackEdgeOrderStatus)
        {
            if (stackEdgeOrderStatus == null)
            {
                throw new ArgumentNullException("stackEdgeOrderStatus");
            }

            this.StackEdgeOrderStatus = stackEdgeOrderStatus;
        }
    }
}