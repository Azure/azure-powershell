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
    /// Interface INamespaceInfo
    /// </summary>
    public interface INamespaceInfo
    {
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; }

        /// <summary>
        /// Gets the number of files.
        /// </summary>
        /// <value>The number of files.</value>
        long NumberOfFiles { get; }

        /// <summary>
        /// Gets the number of directories.
        /// </summary>
        /// <value>The number of directories.</value>
        long NumberOfDirectories { get; }

        /// <summary>
        /// Gets the total file size in bytes.
        /// </summary>
        /// <value>The total file size in bytes.</value>
        long TotalFileSizeInBytes { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is complete.
        /// </summary>
        /// <value><c>true</c> if this instance is complete; otherwise, <c>false</c>.</value>
        bool IsComplete { get; }
    }
}
