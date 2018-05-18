using System.Management.Automation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    internal abstract class ProgressReporter : IProgressReporter
    {
        private long _steps;
        private long _completedSteps;
        private int _lastCompletePercentage;
        private readonly ICmdlet _cmdlet;
        private readonly bool _withProgressBar;

        protected abstract int ActivityId { get; }
        protected abstract string ActivityDescription { get; }
        protected abstract string ActivityStatus { get; }

        public ProgressReporter(ICmdlet cmdlet, bool withProgressBar)
        {
            _steps = 0;
            _completedSteps = 0;
            _lastCompletePercentage = 0;
            _cmdlet = cmdlet;
            _withProgressBar = withProgressBar;
        }

        protected ProgressRecord CreateProgressRecord(int percentage)
        {
            var result = new ProgressRecord(this.ActivityId, this.ActivityDescription, this.ActivityStatus);
            if (_withProgressBar)
            {
                result.PercentComplete = percentage;
            }
            return result;
        }

        protected ProgressRecord CreateCompletionRecord()
        {
            return new ProgressRecord(this.ActivityId, this.ActivityDescription, this.ActivityStatus)
            {
                RecordType = ProgressRecordType.Completed
            };
        }

        public void AddSteps(long steps)
        {
            _steps += steps;
        }

        public void ReserveSteps(long steps)
        {
            long stepsRemaining = _steps - _completedSteps;
            if (stepsRemaining >= 0 && stepsRemaining < steps)
            {
                _steps += steps - stepsRemaining;
            }
        }

        public void ResetSteps(long steps)
        {
            _steps = steps;
        }

        public void Show()
        {
            _cmdlet.WriteProgress(this.CreateProgressRecord(_lastCompletePercentage));
        }

        public void CompleteStep()
        {
            _completedSteps += 1;
            int newCompletePercentage = (int) (_completedSteps * 100 / _steps);
            if (newCompletePercentage != _lastCompletePercentage)
            {
                _lastCompletePercentage = newCompletePercentage;
                _cmdlet.WriteProgress(this.CreateProgressRecord(newCompletePercentage));
            }
        }

        public void Complete()
        {
            _cmdlet.WriteProgress(this.CreateCompletionRecord());
        }
    }

    internal class NamespaceEstimationProgressReporter : ProgressReporter
    {
        protected override int ActivityId => 2;
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        protected override string ActivityStatus => "Preparing to run the analyzis";

        public NamespaceEstimationProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: false)
        {
        }
    }

    internal class NamespaceScanProgressReporter : ProgressReporter
    {
        protected override int ActivityId => 0;
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        protected override string ActivityStatus => "Scanning files and directories";

        public NamespaceScanProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: true)
        {
        }
    }

    internal class SystemCheckProgressReporter : ProgressReporter
    {
        protected override int ActivityId => 1;
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        protected override string ActivityStatus => "Checking your computer for compatibility issues";

        public SystemCheckProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: true)
        {
        }
    }
}