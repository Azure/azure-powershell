namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    public interface IProgressReporter
    {
        void AddSteps(long nodeCount);
        void CompleteStep();
    }
}