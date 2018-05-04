using System.Management.Automation;
using AFSEvaluationTool.Validations;

namespace AFSEvaluationTool.OutputWriters
{
    public interface ICmdlet
    {
        void WriteObject(object sendToPipeline);
        void WriteProgress(ProgressRecord pr);
    }
}