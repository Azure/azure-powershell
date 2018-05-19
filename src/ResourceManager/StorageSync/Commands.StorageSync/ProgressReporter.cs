namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
    using System;
    using System.Diagnostics;

    internal abstract class ProgressReporter : IProgressReporter
    {
        private readonly TimeSpan _updateFrequency = TimeSpan.FromSeconds(1);
        private Stopwatch _timer;
        private long _steps;
        private long _reserveSteps;
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
            _timer = Stopwatch.StartNew();
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
            _reserveSteps += steps;
        }

        public void ResetSteps(long steps)
        {
            _steps = steps;
        }

        public void Show()
        {
            _cmdlet.WriteProgress(this.CreateProgressRecord(_lastCompletePercentage));
        }

        private bool shouldUpdateProgress()
        {
            _timer.Stop();
            if (_timer.Elapsed < _updateFrequency)
            {
                _timer.Start();
                return false;
            }

            _timer.Restart();
            return true;
        }

        /// <summary>
        /// Marks completion of a single step and recalculates the progress.
        /// </summary>
        public void CompleteStep()
        {
            bool shouldUpdateProgress = this.shouldUpdateProgress();

            _completedSteps += 1;
            
            // It is possible to have more actual steps than predicted
            // and if that happens, we might not have a good estimate on remaining work
            // we limit it to 100 to avoid going above the limit.
            // Callers can use AddSteps, ResetSteps or ReserveSteps to update number of steps
            // and make progress behave better if they can predict amount of pending work.
            int newCompletePercentage = System.Math.Min(100, (int)(_completedSteps * 100 / System.Math.Max(_steps, _reserveSteps)));

            if (newCompletePercentage != _lastCompletePercentage && shouldUpdateProgress)
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