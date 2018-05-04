using System.Collections.Generic;
using AFSEvaluationTool.Cmdlets;
using AFSEvaluationTool.OutputWriters;
using AFSEvaluationTool.Validations;
using AFSEvaluationTool.Validations.NamespaceValidations;

namespace AFSEvaluationTool
{
    public class NamespaceValidationsProcessor : INamespaceEnumeratorListener
    {
        private readonly IEnumerable<INamespaceValidation> _validations;
        private readonly IEnumerable<IOutputWriter> _outputWriters;
        private readonly IProgressReporter _progressReporter;

        public NamespaceValidationsProcessor(IEnumerable<INamespaceValidation> validations, IEnumerable<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            _validations = validations;
            _outputWriters = outputWriters;
            _progressReporter = progressReporter;
        }

        public void BeginDir(IDirectoryInfo node)
        {            
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
        }

        public void EndDir(IDirectoryInfo node)
        {
            _progressReporter.CompleteStep();
        }

        public void EndOfEnumeration()
        {
            return;
        }

        public void NextFile(IFileInfo node)
        {
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
            _progressReporter.CompleteStep();
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