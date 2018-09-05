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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InvalidFilenameValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly HashSet<string> _invalidFileNames;
        #endregion

        #region Constructors

        public InvalidFilenameValidation(IConfiguration configuration) : base(configuration, "Files with prohibited names", ValidationType.Filename)
        {
            this._invalidFileNames = new HashSet<string>(configuration.InvalidFileNames(), StringComparer.OrdinalIgnoreCase);
        }

        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return this.Validate(node.Name, node.FullName);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return this.Validate(node.Name, node.FullName);
        }
        #endregion

        #region Private methods

        private IValidationResult Validate(string name, string path)
        {
            if (this._invalidFileNames.Contains(name))
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"The name {name} is not allowed.",
                    Level = ResultLevel.Error,
                    Path = path,
                    Type = this.ValidationType
                };
            }

            return this.SuccessfulResult;
        }

        #endregion
    }
}