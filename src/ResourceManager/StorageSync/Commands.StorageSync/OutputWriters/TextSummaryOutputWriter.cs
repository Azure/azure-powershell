namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;

    class TextSummaryOutputWriter : IOutputWriter
    {
        #region Fields and Properties
        private readonly List<IValidationResult> _systemValidationResults;
        private readonly Dictionary<ValidationType, long> _validationErrorsHistogram;
        private readonly IConsoleWriter _consoleWriter;
        private readonly HashSet<ValidationType> _systemValidationTypes;
        private readonly Dictionary<ValidationType, string> _validationTypeDescriptions;

        #endregion

        #region Constructors
        public TextSummaryOutputWriter(
            IConsoleWriter consoleWriter, 
            IList<IValidationDescription> validationDescriptions)
        {
            _consoleWriter = consoleWriter;
            _validationErrorsHistogram = new Dictionary<ValidationType, long>();
            _systemValidationResults = new List<IValidationResult>();

            _systemValidationTypes = new HashSet<ValidationType>(validationDescriptions
                .Where(o => o.ValidationKind == ValidationKind.SystemValidation)
                .Select(o => o.ValidationType));

            _validationTypeDescriptions = new Dictionary<ValidationType, string>();
            foreach (IValidationDescription validationDescription in validationDescriptions)
            {
                _validationTypeDescriptions[validationDescription.ValidationType] = validationDescription.DisplayName;
            }
        }
        #endregion

        #region Public methods
        public void Write(IValidationResult validationResult)
        {
            if (IsSystemValidation(validationResult))
            {
                _systemValidationResults.Add(validationResult);
            }
            else
            {
                if (IsError(validationResult))
                {
                    if (!_validationErrorsHistogram.ContainsKey(validationResult.Type))
                    {
                        _validationErrorsHistogram[validationResult.Type] = 0;
                    }

                    _validationErrorsHistogram[validationResult.Type] += 1;
                }
            }
        }

        public void WriteReport(string computerName, INamespaceInfo namespaceInfo)
        {
            if (_systemValidationResults.Any())
            {
                _consoleWriter.WriteLine(" ");
                _consoleWriter.WriteLine($"Evaluated host: {computerName}");
                _consoleWriter.WriteLine(" ");
                _consoleWriter.WriteLine("Environment Validation Results");
                WriteSystemValidationResults();
            }

            if (namespaceInfo != null)
            {
                _consoleWriter.WriteLine(" ");
                _consoleWriter.WriteLine($"Evaluated path: {namespaceInfo.Path}");

                _consoleWriter.WriteLine(" ");
                _consoleWriter.WriteLine("Namespace Validation Results");
                _consoleWriter.WriteLine($"Number of files scanned: {namespaceInfo.NumberOfFiles}");
                _consoleWriter.WriteLine($"Number of directories scanned: {namespaceInfo.NumberOfDirectories}");
                _consoleWriter.WriteLine(" ");
                if (!_validationErrorsHistogram.Any())
                {
                    _consoleWriter.WriteLine("There were no compatibility issues found with your files.");
                }
                else
                {
                    WriteCountOfErrorsFound();
                }
            }
        }

        #endregion

        #region Private methods
        private bool IsSystemValidation(IValidationResult validationResult)
        {
            return _systemValidationTypes.Contains(validationResult.Type);
        }

        private bool IsError(IValidationResult validationResult)
        {
            return validationResult.Result == Result.Fail;
        }

        private void WriteCountOfErrorsFound()
        {
            foreach (KeyValuePair<ValidationType, long> entry in _validationErrorsHistogram)
            {
                string description = DescriptionForValidationType(entry.Key);
                _consoleWriter.WriteLine($"{description}: {entry.Value}");
            }
        }

        private string DescriptionForValidationType(ValidationType validationType)
        {
            if (_validationTypeDescriptions.ContainsKey(validationType))
            {
                return _validationTypeDescriptions[validationType];
            }

            return validationType.ToString();
        }

        private void WriteSystemValidationResults()
        {
            foreach (IValidationResult validatonResult in _systemValidationResults)
            {
                string result = IsError(validatonResult) ? "Failed" : "Passed";
                _consoleWriter.WriteLine($"{DescriptionForValidationType(validatonResult.Type)}: {result}.");
            }
        }

        #endregion
    }
}
