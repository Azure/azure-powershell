using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Management.Automation;

namespace Microsoft.CLU.Test
{
    [Cmdlet(VerbsCommon.New, "String")]
    public class StringGenerator : PSCmdlet
    {
        public StringGenerator()
        {
            Count = 10;
            StringFormat = "String {0}";
        }

        [Parameter()]
        public int Count { get; set; }

        [Parameter()]
        public string StringFormat { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            for (int i = 1; i <= Count; ++i)
            {
                WriteObject(String.Format(StringFormat, i));
            }
        }

    }
}
