namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using System.Collections.Generic;
    using Validations;
    using Interfaces;

    public class NamespaceValidationsProcessor : INamespaceEnumeratorListener
    {
        #region Fields and Properties
        private readonly IList<INamespaceValidation> _validations;
        private readonly IList<IOutputWriter> _outputWriters;
        private readonly IProgressReporter _progressReporter;
        #endregion

        #region Constructors
        public NamespaceValidationsProcessor(IList<INamespaceValidation> validations, IList<IOutputWriter> outputWriters, IProgressReporter progressReporter)
        {
            this._validations = validations;
            this._outputWriters = outputWriters;
            this._progressReporter = progressReporter;
        }
        #endregion

        #region Public methods
        public void BeginDir(IDirectoryInfo node)
        {
            foreach (INamespaceValidation validation in this._validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
        }

        public void EndDir(IDirectoryInfo node)
        {
            this._progressReporter.CompleteStep();
        }

        public void EndOfEnumeration(INamespaceInfo namespaceInfo)
        {
            foreach (INamespaceValidation validation in this._validations)
            {
                IValidationResult validationResult = validation.Validate(namespaceInfo);
                Broadcast(validationResult);
            }
        }

        public void NextFile(IFileInfo node)
        {
            foreach (INamespaceValidation validation in this._validations)
            {
                IValidationResult validationResult = validation.Validate(node);
                Broadcast(validationResult);
            }
            this._progressReporter.CompleteStep();
        }

        public void UnauthorizedDir(IDirectoryInfo dir)
        {
            Broadcast(ValidationResult.UnauthorizedAccessDir(dir));
        }

        public void NamespaceHint(long directoryCount, long fileCount)
        {
            this._progressReporter.ReserveSteps(directoryCount + fileCount);
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