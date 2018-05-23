namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using System.Management.Automation;

    public interface ICmdlet
    {
        void WriteObject(object sendToPipeline);
        void WriteProgress(ProgressRecord progressRecord);
    }
}