using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Models;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchPoolsLifetimeStats", DefaultParameterSetName = Constants.ODataFilterParameterSet),
     OutputType(typeof(PSPoolStatistics))]
    public class GetBatchPoolsLifetimeStatisticsCommand : BatchObjectModelCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            PSPoolStatistics poolStats = BatchClient.ListAllPoolsLifetimeStatistics(this.BatchContext, this.AdditionalBehaviors);
            WriteObject(poolStats);
        }
    }
}