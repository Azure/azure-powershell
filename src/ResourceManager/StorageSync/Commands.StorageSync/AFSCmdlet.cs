using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    class AFSCmdlet : ICmdlet
    {
        private readonly Cmdlet _cmdlet;

        public AFSCmdlet(Cmdlet cmdlet)
        {
            _cmdlet = cmdlet;
        }

        public void WriteObject(object sendToPipeline)
        {
            _cmdlet.WriteObject(sendToPipeline);
        }

        public void WriteProgress(ProgressRecord pr)
        {
            _cmdlet.WriteProgress(pr);
        }
    }
}
