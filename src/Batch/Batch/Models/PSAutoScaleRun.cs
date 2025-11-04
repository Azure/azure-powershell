using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSAutoScaleRun
    {
        public static PSAutoScaleRun fromMgmtAutoScaleRun(Microsoft.Azure.Management.Batch.Models.AutoScaleRun mgmtAutoScaleRun)
        {
            if (mgmtAutoScaleRun == null) return null;

            return new PSAutoScaleRun(mgmtAutoScaleRun);
        }
    }
}
