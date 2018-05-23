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
            _commandRunner = commandRunner;
            _validations = validations;
            _outputWriters = outputWriters;
            _progressReporter = progressReporter;
        }
        #endregion

        #region Public methods
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