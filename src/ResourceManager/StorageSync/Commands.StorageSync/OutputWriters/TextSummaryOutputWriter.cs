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
            this._consoleWriter = consoleWriter;
            this._validationErrorsHistogram = new Dictionary<ValidationType, long>();
            this._systemValidationResults = new List<IValidationResult>();

            this._systemValidationTypes = new HashSet<ValidationType>(validationDescriptions
                .Where(o => o.ValidationKind == ValidationKind.SystemValidation)
                .Select(o => o.ValidationType));

            this._validationTypeDescriptions = new Dictionary<ValidationType, string>();
            foreach (IValidationDescription validationDescription in validationDescriptions)
            {
                this._validationTypeDescriptions[validationDescription.ValidationType] = validationDescription.DisplayName;
            }
        }
        #endregion

        #region Public methods
        public void Write(IValidationResult validationResult)
        {
            if (this.IsSystemValidation(validationResult))
            {
                this._systemValidationResults.Add(validationResult);
            }
            else
            {
                if (IsError(validationResult))
                {
                    if (!this._validationErrorsHistogram.ContainsKey(validationResult.Type))
                    {
                        this._validationErrorsHistogram[validationResult.Type] = 0;
                    }

                    this._validationErrorsHistogram[validationResult.Type] += 1;
                }
            }
        }

        public void WriteReport(string computerName, INamespaceInfo namespaceInfo)
        {
            if (this._systemValidationResults.Any())
            {
                this._consoleWriter.WriteLine(" ");
                this._consoleWriter.WriteLine("Environment validation results:");
                this._consoleWriter.WriteLine(" ");
                this._consoleWriter.WriteLine($"Computer name: {computerName}");
                this.WriteSystemValidationResults();
            }

            if (namespaceInfo != null)
            {
                this._consoleWriter.WriteLine(" ");
                this._consoleWriter.WriteLine("Namespace validation results:");
                this._consoleWriter.WriteLine(" ");
                this._consoleWriter.WriteLine($"Path: {namespaceInfo.Path}");
                this._consoleWriter.WriteLine($"Number of files scanned: {namespaceInfo.NumberOfFiles}");
                this._consoleWriter.WriteLine($"Number of directories scanned: {namespaceInfo.NumberOfDirectories}");
                this._consoleWriter.WriteLine(" ");
                if (!_validationErrorsHistogram.Any())
                {
                    this._consoleWriter.WriteLine("There were no compatibility issues found with your files.");
                }
                else
                {
                    this._consoleWriter.WriteLine("The following compatibility issues were found:");
                    this._consoleWriter.WriteLine("");
                    this.WriteCountOfErrorsFound();
                }
            }
        }

        #endregion

        #region Private methods
        private bool IsSystemValidation(IValidationResult validationResult)
        {
            return this._systemValidationTypes.Contains(validationResult.Type);
        }

        private bool IsError(IValidationResult validationResult)
        {
            return validationResult.Result == Result.Fail;
        }

        private void WriteCountOfErrorsFound()
        {
            foreach (KeyValuePair<ValidationType, long> entry in this._validationErrorsHistogram)
            {
                string description = DescriptionForValidationType(entry.Key);
                this._consoleWriter.WriteLine($"{description}: {entry.Value}");
            }
        }

        private string DescriptionForValidationType(ValidationType validationType)
        {
            if (this._validationTypeDescriptions.ContainsKey(validationType))
            {
                return this._validationTypeDescriptions[validationType];
            }

            return validationType.ToString();
        }

        private void WriteSystemValidationResults()
        {
            foreach (IValidationResult validatonResult in this._systemValidationResults)
            {
                string result = this.IsError(validatonResult) ? "Failed" : "Passed";
                this._consoleWriter.WriteLine($"{DescriptionForValidationType(validatonResult.Type)}: {result}.");
            }
        }

        #endregion
    }
}
