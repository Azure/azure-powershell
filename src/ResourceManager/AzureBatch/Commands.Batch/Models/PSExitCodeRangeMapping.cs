using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Batch;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSExitCodeRangeMapping
    {
        public PSExitCodeRangeMapping()
        {
            this.omObject = new ExitCodeRangeMapping(Start, End, new ExitOptions());
        }

        public PSExitCodeRangeMapping(int start, int end, ExitOptions exitOptions)
        {
            this.omObject = new ExitCodeRangeMapping(start, end, exitOptions);
        }

    }
}
