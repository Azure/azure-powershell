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
    using System.Collections.Generic;
    using Validations;

    /// <summary>
    /// Interface IValidationResult
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        ValidationKind Kind { get; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        ValidationType Type { get; }
        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>The level.</value>
        ResultLevel Level { get; }
        /// <summary>
        /// Gets the positions.
        /// </summary>
        /// <value>The positions.</value>
        List<int> Positions { get; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        Result Result { get; }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; }
    }
}