// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets
{
    using System.Management.Automation;
    using System;
    using System.Diagnostics;
    using Interfaces;

    internal abstract class ProgressReporter : IProgressReporter
    {
        #region Fields and Properties
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
        #endregion

        #region Constructors
        public ProgressReporter(ICmdlet cmdlet, bool withProgressBar)
        {
            this._steps = 0;
            this._completedSteps = 0;
            this._lastCompletePercentage = 0;
            this._cmdlet = cmdlet;
            this._withProgressBar = withProgressBar;
            this._timer = Stopwatch.StartNew();
        }
        #endregion

        #region Public methods
        public void AddSteps(long steps)
        {
            this._steps += steps;
        }

        public void ReserveSteps(long steps)
        {
            this._reserveSteps += steps;
        }

        public void ResetSteps(long steps)
        {
            this._steps = steps;
        }

        public void Show()
        {
            this._cmdlet.WriteProgress(this.CreateProgressRecord(this._lastCompletePercentage));
        }

        /// <summary>
        /// Marks completion of a single step and recalculates the progress.
        /// </summary>
        public void CompleteStep()
        {
            bool shouldUpdateProgress = this.ShouldUpdateProgress();

            this._completedSteps += 1;

            // It is possible to have more actual steps than predicted
            // and if that happens, we might not have a good estimate on remaining work
            // we limit it to 100 to avoid going above the limit.
            // Callers can use AddSteps, ResetSteps or ReserveSteps to update number of steps
            // and make progress behave better if they can predict amount of pending work.
            int newCompletePercentage = System.Math.Min(100, (int)(this._completedSteps * 100 / System.Math.Max(this._steps, this._reserveSteps)));

            if (newCompletePercentage != this._lastCompletePercentage && shouldUpdateProgress)
            {
                this._lastCompletePercentage = newCompletePercentage;
                this._cmdlet.WriteProgress(this.CreateProgressRecord(newCompletePercentage));
            }
        }

        public void Complete()
        {
            this._cmdlet.WriteProgress(this.CreateCompletionRecord());
        }
        #endregion

        #region Protected methods
        protected ProgressRecord CreateProgressRecord(int percentage)
        {
            var result = new ProgressRecord(this.ActivityId, this.ActivityDescription, this.ActivityStatus);
            if (this._withProgressBar)
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
        #endregion

        #region Private methods
        private bool ShouldUpdateProgress()
        {
            this._timer.Stop();
            if (this._timer.Elapsed < this._updateFrequency)
            {
                this._timer.Start();
                return false;
            }

            this._timer.Restart();
            return true;
        }
        #endregion

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