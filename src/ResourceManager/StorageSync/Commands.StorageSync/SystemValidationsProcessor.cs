using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public class SystemValidationsProcessor
    {
        private readonly IPowershellCommandRunner _commandRunner;
        private readonly IEnumerable<ISystemValidation> _validations;
        private readonly IEnumerable<IOutputWriter> _outputWriters;
        private readonly IProgressReporter _progressReporter;

        public SystemValidationsProcessor(IPowershellCommandRunner commandRunner, IEnumerable<ISystemValidation> validations, IEnumerable<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            _commandRunner = commandRunner;
            _validations = validations;
            _outputWriters = outputWriters;
            _progressReporter = progressReporter;
        }

        public void Run()
        {
            foreach (ISystemValidation validation in _validations)
            {
                IValidationResult validationResult = validation.ValidateUsing(_commandRunner);
                _progressReporter.CompleteStep();
                Broadcast(validationResult);
            }
        }

        private void Broadcast(IValidationResult validationResult)
        {
            foreach (IOutputWriter outputWriter in _outputWriters)
            {
                outputWriter.Write(validationResult);
            }
        }
    }
}