using System;
using System.IO;

namespace Microsoft.CLU
{
    /// <summary>
    /// Type represents CLU runtime configuration.
    /// </summary>
    internal class RuntimeConfig : Config
    {
        /// <summary>
        /// Path to Nuget repository
        /// </summary>
        public string RepositoryPath { get; set; }

        /// <summary>
        /// Name of the CLURuntime package, name without version.
        /// </summary>
        public string RuntimePackage { get; set; }

        /// <summary>
        /// Version of the CLURuntime package.
        /// </summary>
        public string RuntimeVersion { get; set; }

        /// <summary>
        /// Command line parser -- a fully qualified method name.
        /// </summary>
        public string CommandParser { get; set; }

        /// <summary>
        /// Private constructor to ensure class instances created only via
        /// RuntimeConfig::Load static method.
        /// </summary>
        private RuntimeConfig(string configFilePath) : base(configFilePath)
        {
            RepositoryPath = Items["RepositoryPath"];
            RuntimePackage = Items["RuntimePackage"];
            RuntimeVersion = Items["RuntimeVersion"];

            string parser = null;
            if (Items.TryGetValue("CommandParser", out parser) || string.IsNullOrEmpty(parser))
                CommandParser = parser;
        }

        internal RuntimeConfig() 
        {
        }

        /// <summary>
        /// Load the runtime configuration file from root path identified by
        /// rootPath parameter.
        /// </summary>
        /// <param name="rootPath">The absolute path to installation root directory</param>
        /// <returns></returns>
        public static RuntimeConfig Load(string rootPath)
        {
            if (string.IsNullOrEmpty(rootPath))
            {
                throw new ArgumentNullException("rootPath");
            }

            var configFilePath = Path.Combine(rootPath, Common.Constants.CLUConfigFileName);
            var config = new RuntimeConfig(configFilePath);
            if (string.IsNullOrEmpty(config.CommandParser))
            {
                config.CommandParser = CLUEnvironment.Platform.IsUnixOrMacOSX ?
                    Common.Constants.UnixCommandParser :
                    Common.Constants.WindowsCommandParser;

                config.Set();
            }
            return config;
        }

        /// <summary>
        /// Persist the runtime configuration to configuration file.
        /// </summary>
        public void Set()
        {
            File.WriteAllLines(ConfigFilePath, new string[] {
                "RepositoryPath: " + this.RepositoryPath,
                "RuntimePackage: " + this.RuntimePackage,
                "RuntimeVersion: " + this.RuntimeVersion,
                "CommandParser: " + this.CommandParser});
        }
    }
}
