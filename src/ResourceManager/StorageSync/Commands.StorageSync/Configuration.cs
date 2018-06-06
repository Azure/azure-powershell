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
                _validationsConfiguration =
                    (ValidationsConfiguration)validationsConfigurationJsonSerializer.ReadObject(configStream);
            }

            // this code loads configuration from file
            // commented out due to a decision of using embedded resource instead
            //
            //string pathToExecutingAssembly = ExecutingAssemblyPath();
            //string pathToConfigFile = Path.Combine(pathToExecutingAssembly, Configuration.ConfigFilename);
            //Stream configStream = new FileStream(pathToConfigFile, FileMode.Open, FileAccess.Read);
            //DataContractJsonSerializer validationsConfigurationJsonSerializer = new DataContractJsonSerializer(typeof(ValidationsConfiguration));
            //_validationsConfiguration =
            //    (ValidationsConfiguration) validationsConfigurationJsonSerializer.ReadObject(configStream);
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
            return _validationsConfiguration.ValidFilesystems;
        }

        public IEnumerable<string> ValidOsVersions()
        {
            return _validationsConfiguration.ValidOSVersions;
        }

        public IEnumerable<uint> ValidOsSKU()
        {
            return new uint[] {
                7, 8, 9, 10
            };
        }

        public IEnumerable<string> InvalidFileNames()
        {
            return _validationsConfiguration.InvalidFilenames;
        }

        public IEnumerable<CodePointRange> WhitelistOfCodePointRanges()
        {
            return _validationsConfiguration.WhitelistOfCodePointRanges;
        }

        public IEnumerable<int> BlacklistOfCodePoints()
        {
            return _validationsConfiguration.BlacklistOfCodePoints;
        }

        public int MaximumFilenameLength()
        {
            return _validationsConfiguration.MaximumFilenameLength;
        }

        public long MaximumFileSizeInBytes()
        {
            return _validationsConfiguration.MaximumFileSizeInBytes;
        }

        public int MaximumPathLength()
        {
            return _validationsConfiguration.MaximumPathLength;
        }

        public int MaximumTreeDepth()
        {
            return _validationsConfiguration.MaximumTreeDepth;
        }

        public long MaximumDatasetSizeInBytes()
        {
            return _validationsConfiguration.MaximumDatasetSizeInBytes;
        }
    }
}