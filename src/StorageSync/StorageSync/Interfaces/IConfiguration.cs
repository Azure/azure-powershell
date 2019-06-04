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

    /// <summary>
    /// Interface IConfiguration
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Valids the os versions.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> ValidOsVersions();
        /// <summary>
        /// Valids the os sku.
        /// </summary>
        /// <returns>IEnumerable&lt;System.UInt32&gt;.</returns>
        IEnumerable<uint> ValidOsSKU();
        /// <summary>
        /// Valids the filesystems.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> ValidFilesystems();
        /// <summary>
        /// Whitelists the of code point ranges.
        /// </summary>
        /// <returns>IEnumerable&lt;Configuration.CodePointRange&gt;.</returns>
        IEnumerable<Configuration.CodePointRange> WhitelistOfCodePointRanges();
        /// <summary>
        /// Blacklists the of code points.
        /// </summary>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        IEnumerable<int> BlacklistOfCodePoints();
        /// <summary>
        /// Invalids the file names.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        IEnumerable<string> InvalidFileNames();
        /// <summary>
        /// Maximums the length of the filename.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int MaximumFilenameLength();
        /// <summary>
        /// Maximums the file size in bytes.
        /// </summary>
        /// <returns>System.Int64.</returns>
        long MaximumFileSizeInBytes();
        /// <summary>
        /// Maximums the length of the path.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int MaximumPathLength();
        /// <summary>
        /// Maximums the tree depth.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int MaximumTreeDepth();
        /// <summary>
        /// Maximums the dataset size in bytes.
        /// </summary>
        /// <returns>System.Int64.</returns>
        long MaximumDatasetSizeInBytes();
    }
}