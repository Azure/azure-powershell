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
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class ValidationsFactory.
    /// </summary>
    public static class ValidationsFactory
    {
        #region Public methods

        /// <summary>
        /// Gets the system validations.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="path">The path.</param>
        /// <returns>IList&lt;ISystemValidation&gt;.</returns>
        public static IList<ISystemValidation> GetSystemValidations(Configuration configuration, string path)
        {
            return new List<ISystemValidation>()
            {
                new OSVersionValidation(configuration),
                new FileSystemValidation(configuration, path),
            };
        }

        /// <summary>
        /// Gets the namespace validations.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IList&lt;INamespaceValidation&gt;.</returns>
        public static IList<INamespaceValidation> GetNamespaceValidations(Configuration configuration)
        {
            return new List<INamespaceValidation>()
            {
                new InvalidFilenameValidation(configuration),
                new FilenamesCharactersValidation(configuration),
                new MaximumFileSizeValidation(configuration),
                new MaximumPathLengthValidation(configuration),
                new MaximumFilenameLengthValidation(configuration),
                new MaximumTreeDepthValidation(configuration),
                new MaximumDatasetSizeValidation(configuration),
            };
        }

        /// <summary>
        /// Gets the validation descriptions.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>IList&lt;IValidationDescription&gt;.</returns>
        public static IList<IValidationDescription> GetValidationDescriptions(Configuration configuration)
        {
            List<IValidationDescription> validationDescriptions = new List<IValidationDescription>();

            foreach (IValidationDescription description in GetNamespaceValidations(configuration))
            {
                validationDescriptions.Add(description);
            }

            foreach (IValidationDescription description in GetSystemValidations(configuration, string.Empty))
            {
                validationDescriptions.Add(description);
            }

            return validationDescriptions;
        }

        #endregion
    }
}