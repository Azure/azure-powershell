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

    public class MaximumPathLengthValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly int _maxPathLength;
        #endregion

        #region Constructors
        public MaximumPathLengthValidation(IConfiguration configuration) : base(configuration, "Files/Directories over the path length limit", ValidationType.PathLength)
        {
            this._maxPathLength = configuration.MaximumPathLength();
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidate(IFileInfo node)
        {
            return this.ValidateInternal(node);
        }

        protected override IValidationResult DoValidate(IDirectoryInfo node)
        {
            return this.ValidateInternal(node);
        }
        #endregion

        #region Private methods
        private IValidationResult ValidateInternal(INamedObjectInfo node)
        {
            AfsPath path = new AfsPath(node.FullName);
            int pathLength = path.Length;

            bool pathIsTooLong = pathLength > this._maxPathLength;
            if (pathIsTooLong)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Path length limit exceeded. Maximum length is {this._maxPathLength}.",
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