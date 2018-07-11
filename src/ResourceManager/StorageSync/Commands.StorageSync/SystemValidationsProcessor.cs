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

    public class SystemValidationsProcessor
    {
        #region Fields and Properties
        private readonly IPowershellCommandRunner _commandRunner;
        private readonly IList<ISystemValidation> _validations;
        private readonly IList<IOutputWriter> _outputWriters;
        private readonly IProgressReporter _progressReporter;
        #endregion

        #region Constructors
        public SystemValidationsProcessor(IPowershellCommandRunner commandRunner, IList<ISystemValidation> validations, IList<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            this._commandRunner = commandRunner;
            this._validations = validations;
            this._outputWriters = outputWriters;
            this._progressReporter = progressReporter;
        }
        #endregion

        #region Public methods
        public void Run()
        {
            this._progressReporter.ResetSteps(this._validations.Count);
            foreach (ISystemValidation validation in this._validations)
            {
                IValidationResult validationResult = validation.ValidateUsing(this._commandRunner);
                this._progressReporter.CompleteStep();
                this.Broadcast(validationResult);
            }
        }
        #endregion

        #region Private methods
        private void Broadcast(IValidationResult validationResult)
        {
            foreach (IOutputWriter outputWriter in this._outputWriters)
            {
                outputWriter.Write(validationResult);
            }
        }
        #endregion
    }
}