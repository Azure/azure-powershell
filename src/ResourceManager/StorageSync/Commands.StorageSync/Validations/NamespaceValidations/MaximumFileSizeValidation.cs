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

    public class MaximumFileSizeValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly long _maxFileSizeInBytes;
        #endregion

        #region Constructors
        public MaximumFileSizeValidation(IConfiguration configuration): base(configuration, "Files over the size limit", ValidationType.FileSize)
        {
            this._maxFileSizeInBytes = configuration.MaximumFileSizeInBytes();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            bool fileIsTooBig = node.Length > this._maxFileSizeInBytes;

            if (fileIsTooBig)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"File {node.Name} is too big. Maximum allowed file size is {this._maxFileSizeInBytes} bytes",
                    Level = ResultLevel.Error,
                    Path = node.FullName,
                    Type = this.ValidationType

                };
            }

            return this.SuccessfulResult;
        }
        #endregion
    }
}