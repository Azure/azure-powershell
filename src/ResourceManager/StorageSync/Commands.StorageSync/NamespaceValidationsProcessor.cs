using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets;
using Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public class NamespaceValidationsProcessor : INamespaceEnumeratorListener
    {
        private readonly IList<INamespaceValidation> _validations;
        private readonly IList<IOutputWriter> _outputWriters;
        private readonly IProgressReporter _progressReporter;

        public NamespaceValidationsProcessor(IList<INamespaceValidation> validations, IList<IOutputWriter> outputWriters, IProgressReporter progressReporter)
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

        public void EndOfEnumeration(INamespaceInfo namespaceInfo)
        {
            foreach (INamespaceValidation validation in _validations)
            {
                IValidationResult validationResult = validation.Validate(namespaceInfo);
                Broadcast(validationResult);
            }
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

        public void UnauthorizedDir(IDirectoryInfo dir)
        {
            Broadcast(ValidationResult.UnauthorizedAccessDir(dir));
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