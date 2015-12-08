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
    ///                         ===========================================
    ///                         |                          |              |
    ///                         |                          |              |
    ///                       [vm]                    [network]       _cmdlet.idx
    ///                         |                          |
    ///                ==================              [virtual]
    ///                |        |       |                  |
    ///           [create] [delete] _cmdlet.idx   ==================
    ///                |        |                 |        |       |
    ///         _cmdlet.idx _cmdlet.idx         [create] [delete] _cmdlet.idx
    ///                                           |        |
    ///                                      _cmdlet.idx  _cmdlet.idx
    ///
    ///  The notation [abc] represents a directory, where 'abc' is the directory name.
    ///
    ///  [_indexes] represents the root directory "_indexes".
    ///  There is a directory corrosponding to each discriminator of commands, each such directory contains a
    ///  file named _cmdlet.idx which is the index for commands this discriminator participate.
    ///  For example _cmdlet.idx under [virtual] diretory will contains index for following commands
    ///     vm network create
    ///     vm network delete
    ///  _cmdlet.idx under [virtual]/[create] index
    ///     vm network create
    /// </summary>
    internal class CmdletIndex
    {
        /// <summary>
        /// Name of the index.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The index-entries. These entries will be serialized to/from the file _cmdlet.idx.
        /// </summary>
        public ConfigurationDictionary Entries { get; set; } = new ConfigurationDictionary();

        /// <summary>
        /// Child indicies.
        /// </summary>
        public Dictionary<string, CmdletIndex> Children { get; set; } = new Dictionary<string, CmdletIndex>();

        /// <summary>
        /// Index a command identified by the given command discriminators.
        /// </summary>
        /// <param name="keys">The command discriminator list from which key needs to be derived</param>
        /// <param name="value">The value</param>
        public void Add(List<string> keys, string value)
        {
            Add(keys, 0, value);
        }

        /// <summary>
        /// Recursively index each discriminator in the given command keys.
        /// </summary>
        /// <param name="keys">The command discriminator list from which key needs to be derived</param>
        /// <param name="level">The discriminator level</param>
        /// <param name="value">The value</param>
        private void Add(List<string> keys, int level, string value)
        {
            Entries.Add(string.Join(Constants.CmdletIndexWordSeparator, keys), value);
            if (level < keys.Count)
            {
                CmdletIndex childIndex;
                if (!Children.TryGetValue(keys[level], out childIndex))
                {
                    childIndex = new CmdletIndex { Name = keys[level] };
                    Children.Add(keys[level], childIndex);
                }

                childIndex.Add(keys, level + 1, value);
            }
        }

        /// <summary>
        /// Save this index and all child indicies recursively.
        /// </summary>
        /// <param name="path">The path where the index needs to be stored</param>
        public void Save(string path)
        {
            Debug.Assert(!string.IsNullOrEmpty(path));

            var fullPath = string.IsNullOrEmpty(Name) ? path : Path.Combine(path, Name);
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            var indexFilePath = Path.Combine(fullPath, Constants.CmdletsIndexFileName);
            if (Entries.Count > 0)
                Entries.Store(indexFilePath);

            foreach (var idx in Children.Values)
            {
                idx.Save(fullPath);
            }
        }

        /// <summary>
        /// Load the index.
        /// </summary>
        /// <param name="keys">The command discriminator list identifying the index to be loaded</param>
        /// <param name="path">The index file path</param>
        /// <param name="recursive">
        ///  True  - If the index for all command discriminator in the discriminator list needs to be loaded
        ///  False - Only the index of the root discriminator needs to be loaded</param>
        /// <returns></returns>
        public static CmdletIndex Load(IEnumerable<string> keys, string path, bool recursive)
        {
            Debug.Assert(keys != null);
            Debug.Assert(!string.IsNullOrEmpty(path));

            var indexName = keys.FirstOrDefault();
            var indexFullPath = Path.Combine(path, Constants.CmdletsIndexFileName);

            var cmdletIndex = new CmdletIndex { Name = indexName };
            if (File.Exists(indexFullPath))
            {
                cmdletIndex.Entries = ConfigurationDictionary.Load(indexFullPath);
            }

            if (recursive)
            {
                foreach (var dir in Directory.EnumerateDirectories(path))
                {
                    cmdletIndex.Children.Add(indexName, Load(keys.Skip(1), Path.Combine(path, indexName), true));
                }
            }

            return cmdletIndex;
        }

        /// <summary>
        /// Clear internal data-structures holding index details.
        /// </summary>
        public void Clear()
        {
            Name = null;
            Entries.Clear();
            Children.Clear();
        }
    }
}
