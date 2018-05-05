using System.Management.Automation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    internal class ProgressReporter : IProgressReporter
    {
        private long _steps;
        private long _completedSteps;
        private int _lastCompletePercentage;
        private readonly ICmdlet _cmdlet;

        public ProgressReporter(ICmdlet cmdlet)
        {
            _steps = 0;
            _completedSteps = 0;
            _lastCompletePercentage = 0;
            _cmdlet = cmdlet;
        }

        public void AddSteps(long steps)
        {
            _steps += steps;
        }

        public void CompleteStep()
        {
            _completedSteps += 1;
            int newCompletePercentage = (int) (_completedSteps / _steps);
            if (newCompletePercentage > _lastCompletePercentage)
            {
                _lastCompletePercentage = newCompletePercentage;
                ProgressRecord pr = new ProgressRecord(
                    0,
                    "Analyzing storage sync compatibility...",
                    $"{newCompletePercentage}%"
                );

                _cmdlet.WriteProgress(pr);
            }
        }
    }
}