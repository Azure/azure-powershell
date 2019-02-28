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
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Microsoft.Azure.Commands.StorageSync.Evaluation.Models;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;

    /// <summary>
    /// Class StorageSyncValidationPowerShellFormatting.
    /// </summary>
    public static class StorageSyncValidationPowerShellFormatting
    {
        #region Public methods

        /// <summary>
        /// Formats the specified validation.
        /// </summary>
        /// <param name="validation">The validation.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>System.String.</returns>
        public static string Format(PSStorageSyncValidation validation, int depth = 0)
        {
            Configuration configuration = new Configuration();
            StringBuilder output = new StringBuilder();

            var validationTypeDescriptions = new Dictionary<string, string>();
            foreach (IValidationDescription validationDescription in ValidationsFactory.GetValidationDescriptions(configuration))
            {
                validationTypeDescriptions[validationDescription.ValidationType.ToString()] = validationDescription.DisplayName;
            }

            var systemValidationResults = validation.Results.Where(o => o.Kind == PSValidationKind.SystemValidation).ToList();

            if (systemValidationResults.Any())
            {
                output.AppendLine(" ");
                output.AppendLine("Environment validation results:");
                output.AppendLine(" ");
                output.AppendLine($"Computer name: {validation.ComputerName}");
                foreach (PSValidationResult validatonResult in systemValidationResults)
                {
                    string result = validatonResult.Level == PSResultLevel.Error ? "Failed" : (validatonResult.Level == PSResultLevel.Warning ? "Warning" : "Passed");
                    string displayName;
                    string description = validationTypeDescriptions.TryGetValue(validatonResult.Type.ToString(), out displayName) ? displayName : validatonResult.Type.ToString();
                    output.AppendLine($"{description}: {result}.");
                }
            }

            if (!string.IsNullOrEmpty(validation.NamespacePath))
            {
                var namespaceValidationResults = validation.Results.Where(o => o.Kind == PSValidationKind.NamespaceValidation).ToList();
                var validationErrorsHistogram = new Dictionary<PSValidationType, long>();
                foreach (PSValidationResult validationResult in namespaceValidationResults.Where(o => o.Level == PSResultLevel.Error))
                {
                    if (!validationErrorsHistogram.ContainsKey(validationResult.Type))
                    {
                        validationErrorsHistogram[validationResult.Type] = 0;
                    }
                    validationErrorsHistogram[validationResult.Type] += 1;
                }

                output.AppendLine(" ");
                output.AppendLine("Namespace validation results:");
                output.AppendLine(" ");
                output.AppendLine($"Path: {validation.NamespacePath}");
                output.AppendLine($"Number of files scanned: {validation.NamespaceFileCount}");
                output.AppendLine($"Number of directories scanned: {validation.NamespaceDirectoryCount}");
                output.AppendLine(" ");
                if (!validationErrorsHistogram.Any())
                {
                    output.AppendLine("There were no compatibility issues found with your files.");
                }
                else
                {
                    output.AppendLine("The following compatibility issues were found:");
                    output.AppendLine("");
                    foreach (KeyValuePair<PSValidationType, long> entry in validationErrorsHistogram)
                    {
                        string displayName;
                        string description = validationTypeDescriptions.TryGetValue(entry.Key.ToString(), out displayName) ? displayName : entry.Key.ToString();
                        output.AppendLine($"{description}: {entry.Value}");
                    }
                }
            }

            return output.ToString();
        }
        #endregion
    }
}
