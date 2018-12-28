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

    public class BaseNamespaceValidation : BaseValidation, INamespaceValidation
    {
        #region Fields and Properties
        protected IConfiguration Configuration { get;  }
        #endregion

        #region Constructors
        public BaseNamespaceValidation(
            IConfiguration configuration,
            string validationName,
            ValidationType validationType): base(validationName, validationType, ValidationKind.NamespaceValidation)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Public methods
        public IValidationResult Validate(IFileInfo fileInfo)
        {
            return this.DoValidate(fileInfo);
        }

        public IValidationResult Validate(IDirectoryInfo directoryInfo)
        {
            return this.DoValidate(directoryInfo);
        }

        public IValidationResult Validate(INamespaceInfo namespaceInfo)
        {
            return this.DoValidate(namespaceInfo);
        }
        #endregion

        #region Protected methods
        protected virtual IValidationResult DoValidate(IFileInfo file)
        {
            return this.SuccessfulResult;
        }

        protected virtual IValidationResult DoValidate(IDirectoryInfo directoryInfo)
        {
            return this.SuccessfulResult;
        }

        protected virtual IValidationResult DoValidate(INamespaceInfo namespaceInfo)
        {
            return this.SuccessfulResult;
        }
        #endregion
    }
}
