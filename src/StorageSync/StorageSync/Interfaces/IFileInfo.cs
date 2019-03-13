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
    /// <summary>
    /// Interface IFileInfo
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamedObjectInfo" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.INamedObjectInfo" />
    public interface IFileInfo : INamedObjectInfo
    {
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        long Length { get; }
    }
}
