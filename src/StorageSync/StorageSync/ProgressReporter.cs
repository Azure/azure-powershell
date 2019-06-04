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

    /// <summary>
    /// Class ProgressReporter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IProgressReporter" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IProgressReporter" />
    internal abstract class ProgressReporter : IProgressReporter
    {
        #region Fields and Properties
        /// <summary>
        /// The update frequency
        /// </summary>
        private readonly TimeSpan _updateFrequency = TimeSpan.FromSeconds(1);
        /// <summary>
        /// The timer
        /// </summary>
        private Stopwatch _timer;
        /// <summary>
        /// The steps
        /// </summary>
        private long _steps;
        /// <summary>
        /// The reserve steps
        /// </summary>
        private long _reserveSteps;
        /// <summary>
        /// The completed steps
        /// </summary>
        private long _completedSteps;
        /// <summary>
        /// The last complete percentage
        /// </summary>
        private int _lastCompletePercentage;
        /// <summary>
        /// The cmdlet
        /// </summary>
        private readonly ICmdlet _cmdlet;
        /// <summary>
        /// The with progress bar
        /// </summary>
        private readonly bool _withProgressBar;

        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        protected abstract int ActivityId { get; }
        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <value>The activity description.</value>
        protected abstract string ActivityDescription { get; }
        /// <summary>
        /// Gets the activity status.
        /// </summary>
        /// <value>The activity status.</value>
        protected abstract string ActivityStatus { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressReporter" /> class.
        /// </summary>
        /// <param name="cmdlet">The cmdlet.</param>
        /// <param name="withProgressBar">if set to <c>true</c> [with progress bar].</param>
        public ProgressReporter(ICmdlet cmdlet, bool withProgressBar)
        {
            _steps = 0;
            _completedSteps = 0;
            _lastCompletePercentage = 0;
            _cmdlet = cmdlet;
            _withProgressBar = withProgressBar;
            _timer = Stopwatch.StartNew();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds the steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        public void AddSteps(long steps)
        {
            _steps += steps;
        }

        /// <summary>
        /// Reserves the steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        public void ReserveSteps(long steps)
        {
            _reserveSteps += steps;
        }

        /// <summary>
        /// Resets the steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        public void ResetSteps(long steps)
        {
            _steps = steps;
        }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            _cmdlet.WriteProgress(CreateProgressRecord(_lastCompletePercentage));
        }

        /// <summary>
        /// Marks completion of a single step and recalculates the progress.
        /// </summary>
        public void CompleteStep()
        {
            bool shouldUpdateProgress = ShouldUpdateProgress();

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
                _cmdlet.WriteProgress(CreateProgressRecord(newCompletePercentage));
            }
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        public void Complete()
        {
            _cmdlet.WriteProgress(CreateCompletionRecord());
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Creates the progress record.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <returns>ProgressRecord.</returns>
        protected ProgressRecord CreateProgressRecord(int percentage)
        {
            var result = new ProgressRecord(ActivityId, ActivityDescription, ActivityStatus);
            if (_withProgressBar)
            {
                result.PercentComplete = percentage;
            }
            return result;
        }

        /// <summary>
        /// Creates the completion record.
        /// </summary>
        /// <returns>ProgressRecord.</returns>
        protected ProgressRecord CreateCompletionRecord()
        {
            return new ProgressRecord(ActivityId, ActivityDescription, ActivityStatus)
            {
                RecordType = ProgressRecordType.Completed
            };
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Shoulds the update progress.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldUpdateProgress()
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
        #endregion

    }

    /// <summary>
    /// Class NamespaceEstimationProgressReporter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    internal class NamespaceEstimationProgressReporter : ProgressReporter
    {
        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        protected override int ActivityId => 2;
        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <value>The activity description.</value>
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        /// <summary>
        /// Gets the activity status.
        /// </summary>
        /// <value>The activity status.</value>
        protected override string ActivityStatus => "Preparing to run the analysis";

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceEstimationProgressReporter" /> class.
        /// </summary>
        /// <param name="cmdlet">The cmdlet.</param>
        public NamespaceEstimationProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: false)
        {
        }
    }

    /// <summary>
    /// Class NamespaceScanProgressReporter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    internal class NamespaceScanProgressReporter : ProgressReporter
    {
        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        protected override int ActivityId => 0;
        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <value>The activity description.</value>
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        /// <summary>
        /// Gets the activity status.
        /// </summary>
        /// <value>The activity status.</value>
        protected override string ActivityStatus => "Scanning files and directories";

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceScanProgressReporter" /> class.
        /// </summary>
        /// <param name="cmdlet">The cmdlet.</param>
        public NamespaceScanProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: true)
        {
        }
    }

    /// <summary>
    /// Class SystemCheckProgressReporter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets.ProgressReporter" />
    internal class SystemCheckProgressReporter : ProgressReporter
    {
        /// <summary>
        /// Gets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        protected override int ActivityId => 1;
        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <value>The activity description.</value>
        protected override string ActivityDescription => "Analyzing storage sync compatibility";
        /// <summary>
        /// Gets the activity status.
        /// </summary>
        /// <value>The activity status.</value>
        protected override string ActivityStatus => "Checking your computer for compatibility issues";

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemCheckProgressReporter" /> class.
        /// </summary>
        /// <param name="cmdlet">The cmdlet.</param>
        public SystemCheckProgressReporter(ICmdlet cmdlet) : base(cmdlet, withProgressBar: true)
        {
        }
    }
}