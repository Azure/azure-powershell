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
    using System;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Models;
    using Microsoft.Azure.Commands.StorageSync.Properties;

    /// <summary>
    /// Class PSValidationResultOutputWriter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IOutputWriter" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IOutputWriter" />
    class PSValidationResultOutputWriter : IOutputWriter
    {
        #region Fields and Properties

        /// <summary>
        /// Gets the validation.
        /// </summary>
        /// <value>The validation.</value>
        public PSStorageSyncValidation Validation { get; private set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PSValidationResultOutputWriter" /> class.
        /// </summary>
        public PSValidationResultOutputWriter()
        {
            Validation = new PSStorageSyncValidation();
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Writes the specified validation result.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <exception cref="ArgumentException"></exception>
        public void Write(IValidationResult validationResult)
        {
            switch (validationResult.Kind)
            {
                case ValidationKind.SystemValidation:
                    Validation.Results.Add(new PSValidationResult(validationResult));
                    break;
                case ValidationKind.NamespaceValidation:
                    if (validationResult.Result == Result.Fail)
                    {
                        Validation.Results.Add(new PSValidationResult(validationResult));
                    }
                    break;
                default:
                    throw new ArgumentException(string.Format(StorageSyncResources.UnsupportedErrorFormat, validationResult.Kind.GetType().Name, validationResult.Kind));
            }
        }

        #endregion
    }
}
