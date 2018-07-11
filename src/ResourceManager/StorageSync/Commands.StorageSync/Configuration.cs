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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;

    public class Configuration : IConfiguration
    {
        [DataContract]
        public class ValidationsConfiguration
        {
            [DataMember] public List<string> ValidFilesystems;
            [DataMember] public List<string> ValidOSVersions;
            [DataMember] public List<uint> ValidOSSkus;
            [DataMember] public List<string> InvalidFilenames;
            [DataMember] public List<CodePointRange> WhitelistOfCodePointRanges;
            [DataMember] public List<int> BlacklistOfCodePoints;
            [DataMember] public int MaximumFilenameLength;
            [DataMember] public long MaximumFileSizeInBytes;
            [DataMember] public int MaximumPathLength;
            [DataMember] public int MaximumTreeDepth;
            [DataMember] public long MaximumDatasetSizeInBytes;

        }

        [DataContract]
        public class CodePointRange
        {
            // TODO: validate that Start & End are < and that they are only set on the constructor.
            [DataMember]
            public int Start { get; set; }
            [DataMember]
            public int End { get; set; }
            public string Description { get; set; }

            public bool Includes(int codePoint)
            {
                return codePoint >= Start && codePoint <= End;
            }

        }

        private readonly ValidationsConfiguration _validationsConfiguration;
        private static readonly string ConfigFilename = "Config.json";

        public Configuration()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{assembly.GetName().Name}.{ConfigFilename}";

            using (Stream configStream = assembly.GetManifestResourceStream(resourceName))
            {
                DataContractJsonSerializer validationsConfigurationJsonSerializer = new DataContractJsonSerializer(typeof(ValidationsConfiguration));
                this._validationsConfiguration =
                    (ValidationsConfiguration)validationsConfigurationJsonSerializer.ReadObject(configStream);
            }
		}

        private string ExecutingAssemblyPath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string codeBase = assembly.CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string unescapedPath = Uri.UnescapeDataString(uri.Path);
            string path = Path.GetDirectoryName(unescapedPath);

            return path;
        }

        public IEnumerable<string> ValidFilesystems()
        {
            return this._validationsConfiguration.ValidFilesystems;
        }

        public IEnumerable<string> ValidOsVersions()
        {
            return this._validationsConfiguration.ValidOSVersions;
        }

        public IEnumerable<uint> ValidOsSKU()
        {
            return this._validationsConfiguration.ValidOSSkus;
        }

        public IEnumerable<string> InvalidFileNames()
        {
            return this._validationsConfiguration.InvalidFilenames;
        }

        public IEnumerable<CodePointRange> WhitelistOfCodePointRanges()
        {
            return this._validationsConfiguration.WhitelistOfCodePointRanges;
        }

        public IEnumerable<int> BlacklistOfCodePoints()
        {
            return this._validationsConfiguration.BlacklistOfCodePoints;
        }

        public int MaximumFilenameLength()
        {
            return this._validationsConfiguration.MaximumFilenameLength;
        }

        public long MaximumFileSizeInBytes()
        {
            return this._validationsConfiguration.MaximumFileSizeInBytes;
        }

        public int MaximumPathLength()
        {
            return this._validationsConfiguration.MaximumPathLength;
        }

        public int MaximumTreeDepth()
        {
            return this._validationsConfiguration.MaximumTreeDepth;
        }

        public long MaximumDatasetSizeInBytes()
        {
            return this._validationsConfiguration.MaximumDatasetSizeInBytes;
        }
    }
}