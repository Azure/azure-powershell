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
    [Cmdlet(VerbsCommon.Get, "Brian", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchLifetimeStatisticsCommand : BatchObjectModelCmdletBase
    {
        public override void ExecuteCmdlet()
        {

        }
    }
}
