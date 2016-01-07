using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Management.Automation;

namespace Microsoft.CLU.Test
{

    [Cmdlet(VerbsCommon.Show, "Progress")]
    public class ShowProgress: PSCmdlet
    {
        [Parameter()]
        public int Steps{ get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var progRecord = new ProgressRecord(4711, "Testing progress", "Running");
            WriteProgress(progRecord);
            for (int step = 1; step <= Steps; ++step)
            {
                System.Threading.Thread.Sleep(100);
                progRecord.PercentComplete = step * 100 / Steps;
                WriteProgress(progRecord);
            }
            progRecord.RecordType = ProgressRecordType.Completed;
            WriteProgress(progRecord);
        }
    }
}
