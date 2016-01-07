using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CLU.Common;
using System.Diagnostics;

namespace Microsoft.CLU
{
    /// <summary>
    /// Represents an index of Cmdlets in a package. The index is stored as n-ary tree. For example
    /// suppose a package exposes following set of commands:
    ///
    ///   vm create
    ///   vm delete
    ///   vm image create
    ///   vm image delete
    ///   network virtual create
    ///   network virtual show
    ///
    /// Each word in a command is called 'discriminator' (e.g. for "vm image create", "vm" is the first discriminator
    /// "image" is the second and "create" is the third discriminators)
    ///
    /// The index for this package is stored as below:
    ///
    ///                                        [_indexes]
    ///                                             |
    ///                                       _cmdlet.idx
    ///                                       
    ///  The notation [abc] represents a directory, where 'abc' is the directory name.
    ///
    ///  [_indexes] represents the root directory "_indexes".
    /// </summary>
    internal class CmdletIndex
    {
        /// <summary>
        /// The index-entries. These entries will be serialized to/from the file _cmdlet.idx.
        /// </summary>
        public ConfigurationDictionary Entries { get; set; } = new ConfigurationDictionary();


        /// <summary>
        /// Recursively index each discriminator in the given command keys.
        /// </summary>
        /// <param name="keys">The command discriminator list from which key needs to be derived</param>
        /// <param name="value">The value</param>
        private void Add(List<string> keys, string value)
        {
            Entries.Add(string.Join(Constants.CmdletIndexWordSeparator, keys), value);
        }

        /// <summary>
        /// Save this index and all child indicies recursively.
        /// </summary>
        /// <param name="path">The path where the index needs to be stored</param>
        public void Save(string path)
        {
            Debug.Assert(!string.IsNullOrEmpty(path));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var indexFilePath = Path.Combine(path, Constants.CmdletsIndexFileName);
            if (Entries.Count > 0)
                Entries.Store(indexFilePath);
        }

        /// <summary>
        /// Load the index.
        /// </summary>
        /// <param name="path">The index file path</param>
        /// <returns></returns>
        public static CmdletIndex Load(string path)
        {
            Debug.Assert(!string.IsNullOrEmpty(path));

            var indexFullPath = Path.Combine(path, Constants.CmdletsIndexFileName);

            var cmdletIndex = new CmdletIndex();
            if (File.Exists(indexFullPath))
            {
                cmdletIndex.Entries = ConfigurationDictionary.Load(indexFullPath);
            }

            return cmdletIndex;
        }

        /// <summary>
        /// Clear internal data-structures holding index details.
        /// </summary>
        public void Clear()
        {
            Entries.Clear();
        }
    }
}
