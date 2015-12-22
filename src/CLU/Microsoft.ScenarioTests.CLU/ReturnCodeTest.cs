using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Management.Automation;

namespace Microsoft.CLU.Test
{

    [Cmdlet(VerbsCommon.Show, "Success")]
    public class ShowSuccess: PSCmdlet
    {
        [Parameter()]
        public bool GenerateNonTerminatingError{ get; set; }

        [Parameter()]
        public bool GenerateTerminatingError{ get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (GenerateNonTerminatingError)
            {
                var errorRecord = new ErrorRecord(
                        new InvalidOperationException("I was asked to generate a non-terminating error"),
                        "TestAssert",
                        ErrorCategory.InvalidOperation,
                        this);
                this.WriteError(errorRecord);
            }
            if (GenerateTerminatingError)
            {
                var errorRecord = new ErrorRecord(
                        new InvalidOperationException("I was asked to generate a terminating error"),
                        "TestAssert",
                        ErrorCategory.InvalidOperation,
                        this);
                this.ThrowTerminatingError(errorRecord);
            }

        }
    }
}
