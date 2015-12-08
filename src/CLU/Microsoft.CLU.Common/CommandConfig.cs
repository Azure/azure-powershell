using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.CLU
{
    /// <summary>
    /// Type represents command configuration.
    /// </summary>
    internal class CommandConfig : Config
    {
        /// <summary>
        /// The name of the package containing command model entry point.
        /// This property cannot be null
        /// </summary>
        public string RtAssembly { get; private set; }

        /// <summary>
        /// Fully qualified command model entry point. Format of fully qualified
        /// method name is Namespace.ClassName.MethodName.
        /// This property cannot be null
        /// </summary>
        public string RtEntry { get; private set; }

        /// <summary>
        /// Relative path to the assembly containing command model entry point.
        /// This property cannot be null
        /// </summary>
        public string RtPackage { get; private set; }

        /// <summary>
        /// Private constructor to ensure class instances created only via
        /// CommandConfig::Load static method.
        /// </summary>
        private CommandConfig(string configFilePath) : base(configFilePath)
        {
            RtPackage = GetConfigEntry(Common.Constants.RtPackageConfigKey, true);
            RtEntry = GetConfigEntry(Common.Constants.RtEntryConfigKey, true);
            RtAssembly = GetConfigEntry(Common.Constants.RtAssemblyConfigKey, true);
        }

        /// <summary>
        /// Load the command configuration file.
        /// 
        /// This method check the presence of required configuration entries,
        /// if missing ConfigEntryNotFoundException will be thrown.
        /// </summary>
        /// <param name="commandConfigPath">The configuration file</param>
        /// <returns></returns>
        public static CommandConfig Load(string commandConfigPath)
        {
            return new CommandConfig(commandConfigPath);
        }
    }
}
