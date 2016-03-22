using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchPoolStats"), OutputType(typeof(PSPoolStatistics))]
    public class GetBatchAllPoolsLifetimeStatisticsCommand : BatchObjectModelCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            WriteObject(BatchClient.ListAllPoolsLifetimeStatistics(this.BatchContext, this.AdditionalBehaviors));
        }
    }
}
