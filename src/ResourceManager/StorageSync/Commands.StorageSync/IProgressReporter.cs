namespace AFSEvaluationTool.Cmdlets
{
    public interface IProgressReporter
    {
        void AddSteps(long nodeCount);
        void CompleteStep();
    }
}