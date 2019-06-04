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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// Class SystemValidationsProcessor.
    /// </summary>
    public class SystemValidationsProcessor
    {
        #region Fields and Properties
        /// <summary>
        /// The command runner
        /// </summary>
        private readonly IPowershellCommandRunner _commandRunner;
        /// <summary>
        /// The validations
        /// </summary>
        private readonly IList<ISystemValidation> _validations;
        /// <summary>
        /// The output writers
        /// </summary>
        private readonly IList<IOutputWriter> _outputWriters;
        /// <summary>
        /// The progress reporter
        /// </summary>
        private readonly IProgressReporter _progressReporter;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemValidationsProcessor" /> class.
        /// </summary>
        /// <param name="commandRunner">The command runner.</param>
        /// <param name="validations">The validations.</param>
        /// <param name="outputWriters">The output writers.</param>
        /// <param name="progressReporter">The progress reporter.</param>
        public SystemValidationsProcessor(IPowershellCommandRunner commandRunner, IList<ISystemValidation> validations, IList<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            _commandRunner = commandRunner;
            _validations = validations;
            _outputWriters = outputWriters;
            _progressReporter = progressReporter;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            _progressReporter.ResetSteps(_validations.Count);
            foreach (ISystemValidation validation in _validations)
            {
                IValidationResult validationResult = validation.ValidateUsing(_commandRunner);
                _progressReporter.CompleteStep();
                Broadcast(validationResult);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Broadcasts the specified validation result.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        private void Broadcast(IValidationResult validationResult)
        {
            foreach (IOutputWriter outputWriter in _outputWriters)
            {
                outputWriter.Write(validationResult);
            }
        }
        #endregion
    }
}