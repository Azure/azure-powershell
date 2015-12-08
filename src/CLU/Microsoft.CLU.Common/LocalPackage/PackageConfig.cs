using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Type represents package configuration.
    /// </summary>
    internal class PackageConfig : Config
    {
        /// <summary>
        /// Private constructor to ensure class instances created only via
        /// PackageConfig::Load static method.
        /// </summary>
        private PackageConfig(string configFilePath) : base(configFilePath)
        { }

        /// <summary>
        /// Get package configuration of a package.
        /// </summary>
        /// <param name="packageFullPath">The absolute path to packge root directory.</param>
        /// <returns>The package configuration</returns>
        public static PackageConfig Load(string packageFullPath)
        {
            Debug.Assert(!string.IsNullOrEmpty(packageFullPath));

            var configFilePath = Path.Combine(packageFullPath, Common.Constants.ContentFolder, Common.Constants.PkgConfigFileName);
            if (!File.Exists(configFilePath))
                return null;
            return new PackageConfig(configFilePath);
        }

        /// <summary>
        /// The package name.
        /// </summary>
        public string Name
        {
            get
            {
                string nameConfigValue = null;
                Items.TryGetValue("Name", out nameConfigValue);
                return nameConfigValue;
            }
        }

        /// <summary>
        /// The package noun prefix.
        /// </summary>
        public string NounPrefix
        {
            get
            {
                string nounPrefixConfigValue = null;
                Items.TryGetValue(Common.Constants.CmdletNounPrefixConfigKey, out nounPrefixConfigValue);
                return nounPrefixConfigValue;
            }
        }

        /// <summary>
        /// The package verb/noun order.
        /// </summary>
        public bool NounFirst
        {
            get
            {
                string nounFirstConfigValue = null;
                if (Items.TryGetValue(Common.Constants.CmdletNounFirstConfigKey, out nounFirstConfigValue))
                {
                    bool nounFirst = false;
                    bool.TryParse(nounFirstConfigValue.ToLowerInvariant(), out nounFirst);
                    return nounFirst;
                }

                return false;
            }
        }

        /// <summary>
        /// Backing field for CommandAssemblies property.
        /// </summary>
        private IEnumerable<string> _commandAssemblies;
        /// <summary>
        /// Collection of path to command assemblies in the package. Each path should
        /// be relative to the package root folder '$root\packages\package-name'.
        /// The assembly name (the last segment of the path) must have extension (.dll).
        /// e.g. lib/net452/Contoso.SystemUtils.dll
        /// </summary>
        public IEnumerable<string> CommandAssemblies
        {
            get
            {
                if (_commandAssemblies == null)
                {
                    _commandAssemblies = GetListValue("CommandAssemblies");
                }

                return _commandAssemblies;
            }
        }

        /// <summary>
        /// Backing field for OnInstall property.
        /// </summary>
        private IEnumerable<string> _onInstall;
        /// <summary>
        /// Collection of fully qualified method name that needs to be invoked as a part
        /// of package installation.
        /// Format of fully qualified method name is Namespace.ClassName.MethodName.
        /// </summary>
        public IEnumerable<string> OnInstall
        {
            get
            {
                if (_onInstall == null)
                {
                    _onInstall = GetListValue("OnInstall");
                }

                return _onInstall;
            }
        }

        /// <summary>
        /// Backing field for OnUpdate property.
        /// </summary>
        private IEnumerable<string> _onUpdate;
        /// <summary>
        /// Collection of fully qualified method name that needs to be invoked as a part of
        /// package upgrade.
        /// Format of fully qualified method name is Namespace.ClassName.MethodName.
        /// </summary>
        public IEnumerable<string> OnUpdate
        {
            get
            {
                if (_onUpdate == null)
                {
                    _onUpdate = GetListValue("OnUpdate");
                }

                return _onUpdate;
            }
        }
    }
}
