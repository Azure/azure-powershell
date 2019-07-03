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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;

    /// <summary>
    /// Interface IValidationDescription
    /// </summary>
    public interface IValidationDescription
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; }
        /// <summary>
        /// Gets the kind of the validation.
        /// </summary>
        /// <value>The kind of the validation.</value>
        ValidationKind ValidationKind { get; }
        /// <summary>
        /// Gets the type of the validation.
        /// </summary>
        /// <value>The type of the validation.</value>
        ValidationType ValidationType { get; }
    }
}
