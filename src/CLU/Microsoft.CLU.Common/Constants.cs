using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// The constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The configuration file name
        /// </summary>
        public const string CLUConfigFileName = "msclu.cfg";

        /// <summary>
        /// The standard name of a cmdlet index file on disk.
        /// </summary>
        internal const string CmdletsIndexFileName = "_cmdlets.idx";

#if PSCMDLET_HELP
        /// <summary>
        /// The standard name of a name mapping file on disk.
        /// </summary>
        internal const string NameMappingFileName = "_namemap.idx";
#endif
        /// <summary>
        /// The name of a package's index folder.
        /// </summary>
        internal const string IndexFolder = "_indexes";

        /// <summary>
        /// The extension of index file
        /// </summary>
        internal const string IndexFileExtension = ".idx";

        /// <summary>
        /// The character that separate cmdlet assembly name and type name.
        /// </summary>
        internal const char CmdletIndexItemValueSeparator = '/';

        /// <summary>
        /// The character that separate the words of a cmdlet in an index.
        /// </summary>
        internal const String CmdletIndexWordSeparator = ";";

        /// <summary>
        /// The canonical name of the folder containing all installed command packages.
        /// </summary>
        public const string PackageFolderName = "pkgs";

        /// <summary>
        /// Package installation marker file name.
        /// </summary>
        internal const string PkgMarkerFileName = "_marker";

        /// 
        /// <summary>
        /// The package configuration file name
        /// </summary>
        internal const string PkgConfigFileName = "package.cfg";

        /// 
        /// <summary>
        /// The Cmdlet noun rename rules file name
        /// </summary>
        internal const string RenamingRulesFileName = "rename.cfg";

        /// <summary>
        /// The standard name of the package folder containing content files.
        /// </summary>
        internal const string ContentFolder = "content";

        /// <summary>
        /// The standard name of the package folder containing binaries
        /// </summary>
        internal const string LibFolder = "lib";

        /// <summary>
        /// The standard name of the package folder containing tools, such as scripts.
        /// </summary>
        internal const string ToolsFolder = "tools";

        /// <summary>
        /// The full name of the ConfigurationDictionary type in Microsoft.CLU assembly.
        /// </summary>
        public const string ConfigurationDictionaryTypeFullName = "Microsoft.CLU.ConfigurationDictionary";

        /// <summary>
        /// The full type name of the Windows command parser in Microsoft.CLU assembly.
        /// </summary>
        public const string WindowsCommandParser = "Microsoft.CLU.CommandLineParser.UnixCommandLineParser";

        /// <summary>
        /// The full type name of the Unix command parser in Microsoft.CLU assembly.
        /// </summary>
        public const string UnixCommandParser = "Microsoft.CLU.CommandLineParser.UnixCommandLineParser";

        #region Command model entry point constants

        /// <summary>
        /// The key of the configuration entry in command configuration identifying
        /// package containing command model entry point.
        /// </summary>
        internal const string RtPackageConfigKey = "RtPackage";

        /// <summary>
        /// The key of the configuration entry in command configuration identifying
        /// fully qualified command model entry point.
        /// Format of fully qualified method name is Namespace.ClassName.MethodName.
        /// </summary>
        internal const string RtEntryConfigKey = "RtEntry";

        /// <summary>
        /// The key of the configuration entry in command configuration identifying
        /// relative path to the assembly containing command model entry point.
        /// </summary>
        internal const string RtAssemblyConfigKey = "RtAssembly";

        #endregion

        /// <summary>
        /// The fully qualified name of the command model interface in Microsoft.CLU assembly.
        /// </summary>
        internal const string CommandModelInterface = "Microsoft.CLU.ICommandModel";

        /// <summary>
        /// The name of the directory under lib folder of package containing the assemblies
        /// build for .NET4.2.5
        /// </summary>
        public const string NET452 = "net452";

        public const string DNXCORE50 = "dnxcore50";

        /// <summary>
        /// The key of the configuration entry in cmdlet command configuration identifying modules/packages
        /// which has the assemblies with cmdlets.
        /// </summary>
        internal const string CmdletModulesConfigKey = "Modules";

        /// <summary>
        /// The key of the configuration entry in cmdlet command configuration identifying noun prefix.
        /// </summary>
        internal const string CmdletNounPrefixConfigKey = "NounPrefix";

        /// <summary>
        /// The key of the configuration entry in cmdlet command configuration identifying noun prefix.
        /// </summary>
        internal const string CmdletNounFirstConfigKey = "NounFirst";

        /// <summary>
        /// An environment variable indicating debug preference.
        /// </summary>
        internal const string DebugPreference = "DebugPreference";

        /// <summary>
        /// An environment variable indicating verbose preference.
        /// </summary>
        internal const string VerbosePreference = "VerbosePreference";

        /// <summary>
        /// Indicates user preference to continue without prompting.
        /// </summary>
        internal const string CmdletPreferencesContinue = "Continue";

        /// <summary>
        /// Indicates user preference to silently continue without prompting.
        /// </summary>
        internal const string CmdletPreferencesSilentlyContinue = "SilentlyContinue";

        /// <summary>
        /// Indicates user preference to stop cmdlet execution.
        /// </summary>
        internal const string CmdletPreferencesStop = "Stop";

        /// <summary>
        /// Indicates user preference to ask for confirmation before continuing.
        /// </summary>
        internal const string CmdletPreferencesInquire = "Inquire";

        /// <summary>
        /// The reserved commandline argument value representing STDIN pipeline source.
        /// </summary>
        internal const string PipelineSourceStdinArgument = "$stdin";

        /// <summary>
        /// The prefix of commandline argument value representing FILE pipeline source.
        /// </summary>
        internal const string PipelineSourceFileArgumentPrefix = "@@";

        /// <summary>
        /// The prefix of commandline argument value representing FILE input.
        /// </summary>
        internal const string FileArgumentPrefix = "@";

        #region TODO: The constants in this region should go to resource file

        internal const string MissingCommandNounVerb = "Cmdlet not found";

        /// <summary>
        /// The environment variable holding current session ID.
        /// </summary>
        internal const string SessionID = "AzureProfile";

        /// <summary>
        /// The default session ID.
        /// </summary>
        internal const string DefaultSessionID = "default";

        #endregion
    }
}
