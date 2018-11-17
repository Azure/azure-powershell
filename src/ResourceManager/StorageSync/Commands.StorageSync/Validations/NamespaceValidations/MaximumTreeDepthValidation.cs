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

    public class MaximumTreeDepthValidation : BaseNamespaceValidation
    {
        #region Fields and Properties
        private readonly int _maxTreeDepth;

        #endregion

        #region Constructors

        public MaximumTreeDepthValidation(IConfiguration configuration) : base(configuration, "Files/Directories in too deep folder structures (directory tree depth)", ValidationType.NodeDepth)
        {
            this._maxTreeDepth = configuration.MaximumTreeDepth();
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
            int depth = path.Depth;

            bool isTooDeep = depth > this._maxTreeDepth;
            if (isTooDeep)
            {
                return new ValidationResult
                {
                    Result = Result.Fail,
                    Description = $"Directory tree depth limit exceeded. Maximum tree depth is {this._maxTreeDepth}.",
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