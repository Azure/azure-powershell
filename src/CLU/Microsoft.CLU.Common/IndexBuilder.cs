using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.CLU.Common;
using System.Diagnostics;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU
{
    /// <summary>
    /// Type used to index the commands.
    /// </summary>
    internal static class IndexBuilder
    {
        /// <summary>
        /// Index the commands exposed in a given package.
        /// </summary>
        /// <param name="package">The package</param>
        /// <param name="resolver">The assembly resolver</param>
        internal static void CreateIndexes(LocalPackage package, AssemblyResolver resolver)
        {
            Debug.Assert(package != null);
            Debug.Assert(resolver != null);
            var indexFolderPath = GetIndexDirectoryPath(package);
            if (!Directory.Exists(indexFolderPath))
                Directory.CreateDirectory(indexFolderPath);
            BuildCmdletIndex(package, resolver);
        }

        /// <summary>
        /// Remove command indicies generated for the given package.
        /// </summary>
        /// <param name="localPackage">The package</param>
        internal static void RemoveIndexes(LocalPackage localPackage)
        {
            var path = GetIndexDirectoryPath(localPackage);
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        /// <summary>
        /// Given the package, gets path to the directory containing index files.
        /// </summary>
        /// <param name="package">The package</param>
        /// <returns></returns>
        private static string GetIndexDirectoryPath(LocalPackage package)
        {
            return Path.Combine(package.FullPath, Constants.IndexFolder);
        }
        /// <summary>
        /// Index cmdlet commands in the given package.
        /// </summary>
        /// <param name="package">The package</param>
        /// <param name="resolver">The assembly resolver</param>
        private static void BuildCmdletIndex(LocalPackage package, AssemblyResolver resolver)
        {
            // We'll create one dictionary per verb, so that we can segment the index by verb at runtime,
            // leading to a quicker lookup process.

            foreach (var asm in package.LoadCommandAssemblies())
            {
                var types = FindCmdlets(package, asm);
            }

            _index.Save(Path.Combine(package.FullPath, Constants.IndexFolder));

#if PSCMDLET_HELP
            _nameMap.Store(Path.Combine(package.FullPath, Constants.IndexFolder, Constants.NameMappingFileName));
#endif
            _index.Clear();
        }

        /// <summary>
        /// Analyze assemblies in the given package and find the cmdlet types.
        /// </summary>
        /// <param name="package">The package</param>
        /// <param name="resolver">The assembly resolver</param>
        /// <returns>The cmdlet types</returns>
        public static IEnumerable<Type> FindCmdlets(LocalPackage package, PackageAssembly assembly)
        {
            var config = package.LoadConfig();

            var nounFirst = config.NounFirst;
            var nounPrefix = config.NounPrefix;
            nounPrefix = (nounPrefix != null) ? nounPrefix.ToLowerInvariant() : null;

            var result = new List<Type>();

            ConfigurationDictionary renamingRules = new ConfigurationDictionary();

            var rulesPath = Path.Combine(package.FullPath, Constants.ContentFolder, Constants.RenamingRulesFileName);

            if (File.Exists(rulesPath))
            {
                renamingRules = ConfigurationDictionary.Load(rulesPath);
            }

            foreach (var type in assembly.Assembly.GetExportedTypes())
            {
                var aliasEntryAdded = false;
                {
                    var cmdletAliasAttributes = type.GetTypeInfo().GetCustomAttributes()
                                                .Where((at) => at.GetType().FullName.Equals("System.Management.Automation.CliCommandAliasAttribute")).ToArray();

                    foreach (var cmdletAliasAttribute in cmdletAliasAttributes)
                    {
                        var attrType = cmdletAliasAttribute.GetType();
                        var keys = ((string)attrType.GetProperty("CommandName").GetValue(cmdletAliasAttribute)).Split(' ').ToList();
                        AddEntry(_index, keys, $"{assembly.Name}{Constants.CmdletIndexItemValueSeparator}{type.FullName}");
                        aliasEntryAdded = true;
                    }
                }
                if (!aliasEntryAdded)
                {
                    var cmdletAttributes = type.GetTypeInfo().GetCustomAttributes()
                                                .Where((at) => at.GetType().FullName.Equals("System.Management.Automation.CmdletAttribute")).ToArray();

                    foreach (var cmdletAttribute in cmdletAttributes)
                    {
                        var attrType = cmdletAttribute.GetType();

                        if (attrType.FullName.Equals("System.Management.Automation.CmdletAttribute"))
                        {
                            // We caught ourselves a Cmdlet! The CLU runtime must be loaded at this point.
                            var verbProp = attrType.GetProperty("VerbName");
                            var nounProp = attrType.GetProperty("NounName");

                            if (verbProp == null || nounProp == null)
                                continue;

                            var origVerb = (verbProp.GetValue(cmdletAttribute) as string).Trim();
                            var origNoun = (nounProp.GetValue(cmdletAttribute) as string).Trim();

                            var verb = origVerb.ToLowerInvariant();
                            var noun = origNoun; // DO NOT LOWER HERE!

                            if (!string.IsNullOrEmpty(noun))
                            {
                                if (!string.IsNullOrEmpty(nounPrefix) && noun.StartsWith(nounPrefix, StringComparison.CurrentCultureIgnoreCase))
                                    noun = noun.Substring(nounPrefix.Length);

                            }

                            if (!string.IsNullOrEmpty(verb))
                            {
                                string replacedVerb = verb;
                                if (renamingRules.TryGetValue(verb, out replacedVerb))
                                {
                                    replacedVerb = replacedVerb.Trim();
                                    if (replacedVerb.Contains(' '))
                                        // No verb splitting!!!
                                        throw new ArgumentException(string.Format(Strings.IndexBuilder_FindCmdlets_InvalidVerbRenameRule, verb, replacedVerb, package.Name));
                                    verb = replacedVerb;
                                }

                                var keys = SplitNoun(noun, renamingRules);
                                if (nounFirst)
                                    keys.Add(verb);
                                else
                                    keys.Insert(0, verb);

                                AddEntry(_index, keys, $"{assembly.Name}{Constants.CmdletIndexItemValueSeparator}{type.FullName}");
#if PSCMDLET_HELP
                            if (!string.IsNullOrEmpty(origNoun))
                                _nameMap.Add(string.Join(";", keys), $"{origVerb}-{origNoun}");
                            else
                                _nameMap.Add(string.Join(";", keys), $"{origVerb}");
#endif
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Split the noun string using camel casing and given renaming rules.
        /// </summary>
        /// <param name="noun">The noun</param>
        /// <param name="renamingRules">The renaming rules</param>
        /// <returns>The noun splitted</returns>
        private static List<string> SplitNoun(string noun, ConfigurationDictionary renamingRules)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(noun))
                return result;

            var builder = new StringBuilder();
            var wasUpper = true;

            List<string[]> splits = new List<string[]>();

            foreach (var entry in renamingRules)
            {
                var idx = noun.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase);
                if (idx > -1)
                {
                    var len = entry.Key.Length;
                    noun = noun.Replace(noun.Substring(idx, len), "*");
                    splits.Add(entry.Value.Split(' '));
                }
            }

            var splitIdx = 0;
            foreach (var ch in noun)
            {
                if (ch == '*')
                {
                    if (builder.Length > 0)
                        result.Add(builder.ToString().ToLowerInvariant());
                    result.AddRange(splits[splitIdx++]);
                    builder.Clear();
                    wasUpper = true;
                    continue;
                }
                else if (char.IsUpper(ch) && !wasUpper)
                {
                    result.Add(builder.ToString().ToLowerInvariant());
                    builder.Clear();
                }

                wasUpper = char.IsUpper(ch);
                builder.Append(ch);
            }
            if (builder.Length > 0)
                result.Add(builder.ToString().ToLowerInvariant());

            return result;
        }

        /// <summary>
        /// Adds an entry to index file identifying a cmdlet command.
        /// </summary>
        /// <param name="primary">The cmdlet primary identifier</param>
        /// <param name="secondary">The cmdlet secondary identifier</param>
        /// <param name="value">The identifier that identifies the cmdlet</param>
        private static void AddEntry(CmdletIndex root, List<string> keys, string value)
        {
            root.Entries.Add(string.Join(Constants.CmdletIndexWordSeparator, keys), value);
        }

        #region Private fields

        /// <summary>
        /// All indicies of commands exposed in a given package.
        /// </summary>
        private static CmdletIndex _index = new CmdletIndex();

#if PSCMDLET_HELP
        /// <summary>
        /// At installation time, we build a mapping from the CLI name, a sequence of keys, to
        /// the official PS name, Verb-Noun. This is necessary in order to identify the help
        /// content for a command.
        /// </summary>
        private static ConfigurationDictionary _nameMap = new ConfigurationDictionary();
#endif
        #endregion
    }
}
