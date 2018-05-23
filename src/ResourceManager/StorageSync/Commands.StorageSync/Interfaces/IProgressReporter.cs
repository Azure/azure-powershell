namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    public interface IProgressReporter
    {
        void AddSteps(long count);
        void ReserveSteps(long count);
        void ResetSteps(long count);
        void Show();
        void CompleteStep();
        void Complete();
    }
}