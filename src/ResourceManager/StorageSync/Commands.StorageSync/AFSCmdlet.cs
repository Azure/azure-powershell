using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using AFSEvaluationTool.OutputWriters;
using AFSEvaluationTool.Validations;

namespace AFSEvaluationTool
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
