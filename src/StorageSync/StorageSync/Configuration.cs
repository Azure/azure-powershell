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

using System.Linq;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Class Configuration.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IConfiguration" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IConfiguration" />
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// Class ValidationsConfiguration.
        /// </summary>
        [DataContract]
        public class ValidationsConfiguration
        {
            /// <summary>
            /// The valid filesystems
            /// </summary>
            [DataMember] public List<string> ValidFilesystems;
            /// <summary>
            /// The valid os versions
            /// </summary>
            [DataMember] public List<string> ValidOSVersions;
            /// <summary>
            /// The valid os skus
            /// </summary>
            [DataMember] public List<uint> ValidOSSkus;
            /// <summary>
            /// The invalid filenames
            /// </summary>
            [DataMember] public List<string> InvalidFilenames;
            /// <summary>
            /// The whitelist of code point ranges
            /// </summary>
            [DataMember] public List<CodePointRange> WhitelistOfCodePointRanges;
            /// <summary>
            /// The blacklist of code points
            /// </summary>
            [DataMember] public List<int> BlacklistOfCodePoints;
            /// <summary>
            /// The maximum filename length
            /// </summary>
            [DataMember] public int MaximumFilenameLength;
            /// <summary>
            /// The maximum file size in bytes
            /// </summary>
            [DataMember] public long MaximumFileSizeInBytes;
            /// <summary>
            /// The maximum path length
            /// </summary>
            [DataMember] public int MaximumPathLength;
            /// <summary>
            /// The maximum tree depth
            /// </summary>
            [DataMember] public int MaximumTreeDepth;
            /// <summary>
            /// The maximum dataset size in bytes
            /// </summary>
            [DataMember] public long MaximumDatasetSizeInBytes;

        }

        /// <summary>
        /// Class CodePointRange.
        /// </summary>
        [DataContract]
        public class CodePointRange
        {
            // TODO: validate that Start & End are < and that they are only set on the constructor.
            /// <summary>
            /// Gets or sets the start.
            /// </summary>
            /// <value>The start.</value>
            [DataMember]
            public int Start { get; set; }
            /// <summary>
            /// Gets or sets the end.
            /// </summary>
            /// <value>The end.</value>
            [DataMember]
            public int End { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Includeses the specified code point.
            /// </summary>
            /// <param name="codePoint">The code point.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool Includes(int codePoint)
            {
                return codePoint >= Start && codePoint <= End;
            }

        }

        /// <summary>
        /// The validations configuration
        /// </summary>
        private readonly ValidationsConfiguration _validationsConfiguration;
        /// <summary>
        /// The configuration filename
        /// </summary>
        private static readonly string ConfigFilename = "Config.json";

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //https://stackoverflow.com/a/4885945/294804
            var resourceName = assembly.GetManifestResourceNames().Single(n => n.EndsWith(ConfigFilename));

            using (Stream configStream = assembly.GetManifestResourceStream(resourceName))
            {
                DataContractJsonSerializer validationsConfigurationJsonSerializer = new DataContractJsonSerializer(typeof(ValidationsConfiguration));
                _validationsConfiguration =
                    (ValidationsConfiguration)validationsConfigurationJsonSerializer.ReadObject(configStream);
            }
		}

        /// <summary>
        /// Executings the assembly path.
        /// </summary>
        /// <returns>System.String.</returns>
        private string ExecutingAssemblyPath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string codeBase = assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string unescapedPath = Uri.UnescapeDataString(uri.Path);
            string path = Path.GetDirectoryName(unescapedPath);

            return path;
        }

        /// <summary>
        /// Valids the filesystems.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> ValidFilesystems()
        {
            return _validationsConfiguration.ValidFilesystems;
        }

        /// <summary>
        /// Valids the os versions.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> ValidOsVersions()
        {
            return _validationsConfiguration.ValidOSVersions;
        }

        /// <summary>
        /// Valids the os sku.
        /// </summary>
        /// <returns>IEnumerable&lt;System.UInt32&gt;.</returns>
        public IEnumerable<uint> ValidOsSKU()
        {
            return _validationsConfiguration.ValidOSSkus;
        }

        /// <summary>
        /// Invalids the file names.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> InvalidFileNames()
        {
            return _validationsConfiguration.InvalidFilenames;
        }

        /// <summary>
        /// Whitelists the of code point ranges.
        /// </summary>
        /// <returns>IEnumerable&lt;Configuration.CodePointRange&gt;.</returns>
        public IEnumerable<CodePointRange> WhitelistOfCodePointRanges()
        {
            return _validationsConfiguration.WhitelistOfCodePointRanges;
        }

        /// <summary>
        /// Blacklists the of code points.
        /// </summary>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public IEnumerable<int> BlacklistOfCodePoints()
        {
            return _validationsConfiguration.BlacklistOfCodePoints;
        }

        /// <summary>
        /// Maximums the length of the filename.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int MaximumFilenameLength()
        {
            return _validationsConfiguration.MaximumFilenameLength;
        }

        /// <summary>
        /// Maximums the file size in bytes.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long MaximumFileSizeInBytes()
        {
            return _validationsConfiguration.MaximumFileSizeInBytes;
        }

        /// <summary>
        /// Maximums the length of the path.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int MaximumPathLength()
        {
            return _validationsConfiguration.MaximumPathLength;
        }

        /// <summary>
        /// Maximums the tree depth.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int MaximumTreeDepth()
        {
            return _validationsConfiguration.MaximumTreeDepth;
        }

        /// <summary>
        /// Maximums the dataset size in bytes.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long MaximumDatasetSizeInBytes()
        {
            return _validationsConfiguration.MaximumDatasetSizeInBytes;
        }
    }
}