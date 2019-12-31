using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using DataBoxEdgeOrderStatus = Microsoft.Azure.Management.DataBoxEdge.Models.OrderStatus;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeOrderStatus
    {
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeOrderStatus.Status", Position = 0)]
        [Ps1Xml(Label = "UpdateDateTime", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeOrderStatus.UpdateDateTime", Position = 1)]
        public DataBoxEdgeOrderStatus DataBoxEdgeOrderStatus;


        public string Id;

        public PSDataBoxEdgeOrderStatus()
        {
            DataBoxEdgeOrderStatus = new DataBoxEdgeOrderStatus();
        }

        public PSDataBoxEdgeOrderStatus(DataBoxEdgeOrderStatus dataBoxEdgeOrderStatus)
        {
            if (dataBoxEdgeOrderStatus == null)
            {
                throw new ArgumentNullException("dataBoxEdgeOrderStatus");
            }

            this.DataBoxEdgeOrderStatus = dataBoxEdgeOrderStatus;
        }
    }
}