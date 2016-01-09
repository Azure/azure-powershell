using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Represents details of a package (containing cmdlets) exists in local file system under packages root directory.
    /// </summary>
    internal class CmdletLocalPackage : LocalPackage
    {
        /// <summary>
        /// Create an instance of CmdletLocalPackage.
        /// </summary>
        /// <param name="packageBaseName">The base name of the package, i.e. the name without version number</param>
        /// <param name="packageDirInfo">DirectoryInfo of this package</param>
        internal CmdletLocalPackage(string packageBaseName, DirectoryInfo packageDirInfo) : base(packageBaseName, packageDirInfo)
        { }

        /// <summary>
        /// Find the Cmdlet corrosponding to the given command discriminators.
        /// e.g. Suppose the command discriminators are [ 'vm', 'image', 'list'], if this package
        /// contains Cmdlet (AzureVMImageList) corrosponding to this command discriminators then
        /// the method returns a CmdletValue instance representing AzureVMImageList cmdlet.
        /// </summary>
        /// <param name="commandDiscriminators">The command discriminators</param>
        /// <returns>CmdletValue instance representing Cmdlet for the given discriminators</returns>
        public CmdletValue FindCmdlet(IEnumerable<string> commandDiscriminators)
        {
            Debug.Assert(commandDiscriminators !=null);
            Debug.Assert(commandDiscriminators.Count() >= 1);
            var index = LoadFromCache();
            if (index != null)
            {
                string key = string.Join(Constants.CmdletIndexWordSeparator, commandDiscriminators);
                string cmdletIdentifier;
                if (index.Entries.TryGetValue(key, out cmdletIdentifier))
                {
                    return new CmdletValue(commandDiscriminators, cmdletIdentifier, this);
                }
            }

            return null;
        }

        /// <summary>
        /// Find all the matching Cmdlets for the given command discriminators.
        /// e.g. Suppose the command discriminators are [ 'vm', 'image'], if this package contains
        /// Cmdlets corrosponding to the commands starting with "vm image"  then this method
        /// returns the matching information.
        /// </summary>
        /// <param name="commandDiscriminators">The command discriminators</param>
        /// <returns>Matching commands details as key-value collections</returns>
        public ConfigurationDictionary FindMatchingCmdlets(IEnumerable<string> commandDiscriminators)
        {
            Debug.Assert(commandDiscriminators != null);
            var directorySeparator = new string(Path.DirectorySeparatorChar, 1);
            return LoadFromCache().Entries;
        }

        /// <summary>
        /// Find the Cmdlet corrosponding to the given command discriminators from a package list.
        /// e.g. Suppose the command discriminators are [ 'vm', 'image', 'list'], if one of the given
        /// package in the pacakgeNames contains Cmdlet (AzureVMImageList) for the command
        /// "vm image list" then this method returns a CmdletValue instance representing
        /// AzureVMImageList cmdlet.
        /// </summary>
        /// <param name="packageNames">The package names</param>
        /// <param name="commandDiscriminators">The command discriminators</param>
        /// <returns>CmdletValue instance representing Cmdlet for the given command discriminators</returns>
        public static CmdletValue FindCmdlet(IEnumerable<string> packageNames, IEnumerable<string> commandDiscriminators)
        {
            Debug.Assert(packageNames != null);
            Debug.Assert(commandDiscriminators != null);
            foreach (var packageName in packageNames)
            {
                CmdletLocalPackage package = LoadCmdletPackage(packageName);
                if (package != null)
                {
                    var cmdletIndexValue = package.FindCmdlet(commandDiscriminators);
                    if (cmdletIndexValue != null)
                    {
                        return cmdletIndexValue;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Load an index of this package identified by the given index name.
        /// </summary>
        /// <returns>The index</returns>
        private CmdletIndex LoadFromCache()
        {
            var indexFilePath = Path.Combine(FullPath, Constants.IndexFolder);
            CmdletIndex index;
            if (CLUEnvironment.IsThreadSafe)
            {
                lock (_cachelock)
                {
                    if (!_cache.TryGetValue(this.Name, out index))
                    {
                        index = CmdletIndex.Load(indexFilePath);
                        _cache[this.Name] = index;
                    }
                }
            }
            else
            {
                if (!_cache.TryGetValue(this.Name, out index))
                {
                    index = CmdletIndex.Load(indexFilePath);
                    _cache[this.Name] = index;
                }
            }

            return index;
        }

        #region Private fields

        /// <summary>
        /// The lock for cache while running in mutli-threaded mode.
        /// </summary>
        private static object _cachelock = new object();

        /// <summary>
        /// Cache of loaded command indicies.
        /// The cache is shared across all instances of CmdletLocalPackage.
        /// </summary>
        private static Dictionary<string, CmdletIndex> _cache = new Dictionary<string, CmdletIndex>();

        #endregion
    }
}
