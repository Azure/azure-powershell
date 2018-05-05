using System.Management.Automation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    public interface ICmdlet
    {
        void WriteObject(object sendToPipeline);
        void WriteProgress(ProgressRecord pr);
    }
}