using Microsoft.CLU.Common;
using Microsoft.CLU.Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.CLU
{
    /// <summary>
    /// Entry point to access CLU runtime enviroment.
    /// </summary>
    public static class CLUEnvironment
    {
        /// <summary>
        /// Name of the environment variable holding root path.
        /// </summary>
        private static string RootPathEnvVaribleName = "RootPath";

        /// <summary>
        /// Name of the environment variable holding package root path.
        /// </summary>
        private static string PackagesRootPathEnvVaribleName = "PackagesRootPath";

        /// <summary>
        /// Set the root paths.
        /// </summary>
        /// <param name="cluRootPath"></param>
        public static void SetRootPaths(string cluRootPath)
        {
            SetEnvironmentVariable(RootPathEnvVaribleName, cluRootPath);

            var rootPathPrefix = "";
            if (Platform.IsUnixOrMacOSX)
            {
                rootPathPrefix = "/";
            }
            SetEnvironmentVariable(PackagesRootPathEnvVaribleName, rootPathPrefix + Path.Combine(cluRootPath, Common.Constants.PackageFolderName));
        }

        /// <summary>
        /// Gets the runtime configuration defined in $root\msclu.cfg.
        /// </summary>
        /// <returns></returns>
        internal static RuntimeConfig RuntimeConfig
        {
            get
            {
                if (_config == null)
                {
                    var root = GetEnvironmentVariable(RootPathEnvVaribleName);
                    _config = RuntimeConfig.Load(root);
                }
                return _config;
            }

            set
            {
                _config = value;
            }
        }
        private static RuntimeConfig _config;

        /// <summary>
        /// Get the root path ($root), root path is where clurun.exe located.
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            return GetEnvironmentVariable(RootPathEnvVaribleName);
        }

        /// <summary>
        /// Get the packages root path, $root\pkgs
        /// </summary>
        /// <returns></returns>
        public static string GetPackagesRootPath()
        {
            return GetEnvironmentVariable(PackagesRootPathEnvVaribleName);
        }

        /// <summary>
        /// Gets path to the directories holding all package assemblies.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetPackagePaths()
        {
            return Directory.EnumerateDirectories(CLUEnvironment.GetPackagesRootPath())
                .Select(pkg => Path.Combine(pkg, Common.Constants.LibFolder, CLUEnvironment.CLRName));
        }

        /// <summary>
        /// The CLR Name
        /// </summary>
        public static string CLRName
        {
            get
            {
                // TODO: Find the exact environment (DesktopCLR, mono, CoreCRL) and return
                return Common.Constants.DNXCORE50;
            }
        }

        /// <summary>
        /// Get the home path according to the platform...
        /// </summary>
        /// <returns></returns>
        private static string GetHomePath()
        {
            if (Platform.IsWindows)
            {
                string[] items = {
                        GetEnvironmentVariable("USERPROFILE"),
                        GetEnvironmentVariable("HOMEDRIVE") + GetEnvironmentVariable("HOMEPATH")
                    };

                return items.First((s) => !String.IsNullOrEmpty(s));
            }
            else
            {
                return GetEnvironmentVariable("HOME");
            }
        }

        /// <summary>
        /// Keeps the script name used to invoke a command, e.g. 'azure'.
        /// </summary>
        public static string ScriptName
        {
            get;
            set;
        }

        /// <summary>
        /// Get value of an environment variable.
        /// </summary>
        /// <param name="envVariableName"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(string envVariableName, bool required = true)
        {
            string value;

            if (IsThreadSafe)
            {
                lock (_cacheLock)
                {
                    if (_cache.TryGetValue(envVariableName, out value))
                        return value;
                }
            }
            else
            {
                if (_cache.TryGetValue(envVariableName, out value))
                    return value;
            }

            var envVariableValue = Environment.GetEnvironmentVariable(envVariableName);
            if (envVariableValue == null && required)
            {
                CLUEnvironment.Console.WriteErrorLine($"Required environment variable '{envVariableName}' is not set");
            }

            if (IsThreadSafe)
            {
                lock (_cacheLock)
                {
                    _cache[envVariableName] = envVariableValue;
                }
            }
            else
            {
                _cache[envVariableName] = envVariableValue;
            }

            return envVariableValue;
        }

        /// <summary>
        /// Inject a value for an environment variable.
        /// </summary>
        /// <param name="envVariableName"></param>
        /// <remarks>Used for testing scenarios.</remarks>
        internal static void SetEnvironmentVariable(string envVariableName, string value)
        {
            if (IsThreadSafe)
            {
                lock (_cacheLock)
                {
                    _cache[envVariableName] = value;
                }
            }
            else
            {
                _cache[envVariableName] = value;
            }
        }

        /// <summary>
        /// Lock to protect _cache when IsThreadSafe is true.
        /// </summary>
        private static object _cacheLock = new object();

        /// <summary>
        /// The cache of environment variables.
        /// </summary>
        private static Dictionary<string, string> _cache = new Dictionary<string, string>();

        /// <summary>
        /// The console to make IO API calls.
        /// </summary>
        public static IConsoleInputOutput Console { get; set; }

        /// <summary>
        /// Indicates whether CLU runs in thread-safe mode or not.
        /// Default to false.
        /// </summary>
        public static bool IsThreadSafe { get; internal set; }

        /// <summary>
        /// Access to platform specific environment.
        /// </summary>
        public static class Platform
        {
            /// <summary>
            /// Checks whether the operating system is Windows.
            /// </summary>
            public static bool IsWindows
            {
                get
                {
                    return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
                }
            }

            /// <summary>
            /// Checks whether the operating system is UNIX.
            /// </summary>
            public static bool IsUnix
            {
                get
                {
                    return !(IsWindows || IsMacOSX);
                }
            }

            /// <summary>
            /// Checks whether the operating system is Macintosh.
            /// </summary>
            public static bool IsMacOSX
            {
                get
                {
                    return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX);
                }
            }

            /// <summary>
            /// Checks whether the operating system is UNIX or Macintosh.
            /// </summary>
            public static bool IsUnixOrMacOSX
            {
                get
                {
                    return IsUnix || IsMacOSX;
                }
            }

            /// <summary>
            /// The extension to use for generated command script files.
            /// </summary>
            public static string ScriptFileExtension
            {
                get
                {
                    return IsUnixOrMacOSX ? "" : ".bat";
                }
            }

            /// <summary>
            /// The pattern to use to search for command config files.
            /// </summary>
            public static string ConfigFileSearchPattern
            {
                get
                {
                    return "*.lx";
                }
            }
        }

        /// <summary>
        /// Access to CLUEnvironment current session.
        /// </summary>
        public static class Session
        {
            /// <summary>
            /// Gets the current session ID.
            /// </summary>
            private static string ID { get; set; }

            /// <summary>
            /// The backing field for SessionPath property.
            /// </summary>
            private static string _path;
            /// <summary>
            /// The directory to store session specific resources.
            /// </summary>
            public static string SessionPath
            {
                get
                {
                    if (_path == null)
                    {
                        var directory = Path.Combine(CLUEnvironment.GetHomePath(), ".azure");
                        System.IO.Directory.CreateDirectory(directory);
                        _path = Path.Combine(directory, $"{ID}.profile.json");
                    }

                    return _path;
                }
            }

            /// <summary>
            /// Constructor
            /// Note: Called automatically to initialize the Session before
            /// any static members are referenced.
            /// </summary>
            static Session()
            {
                ID = Environment.GetEnvironmentVariable(Constants.SessionID);
                if (string.IsNullOrEmpty(ID))
                {
                    ID = Constants.DefaultSessionID;

                    Environment.SetEnvironmentVariable(Constants.SessionID, ID);
                }
            }
        }
    }
}
