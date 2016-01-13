#if PSCMDLET_HELP
using Microsoft.CLU.Common;
using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.CLU.Help
{
    /// <summary>
    /// Generates Cmdlet command help.
    /// </summary>
    internal static class CmdletHelp
    {
        /// <summary>
        /// Generates a list of text lines containing help information for a specific Cmdlet command.
        /// </summary>
        /// <param name="format">The command help formattter</param>
        /// <param name="args">The command-line arguments to be considered in the help logic.</param>
        /// <param name="prefix">True if the help argument comes first, false if last.</param>
        /// <returns>A list of lines containing help information.</returns>
        /// <remarks>
        /// This should be called for generating help for a commands, for example,
        /// 
        ///     azure help vm start     (prefix = true)
        /// 
        /// In the prefix form, if the arguments provide sufficient detail to identify a single command, 
        /// the details about that command are listed. If more than one command is found, they are listed.
        /// 
        ///     azure vm start --help   (prefix = false)
        ///
        /// In the postfix form, there will never be a command list. Rather, if the arguments match an
        /// existing command, help for only that command is displayed. If none match the arguments exactly,
        /// an error is generated.
        /// </remarks>
        public static IEnumerable<string> Generate(Func<string, string, bool, bool, string> format, IEnumerable<string> modules, string[] arguments, bool prefix)
        {
            var result = new List<string>();

            var matches = FindMatches(modules, arguments);

            if (matches != null)
            {
                var cmdlets = matches.SelectMany(m => m.Cmdlets).ToArray();

                if (cmdlets.Length == 1)
                {
                    GenerateSingleCommandHelp(format, result, cmdlets[0]);
                    return result;
                }
                else if (prefix)
                {
                    GenerateCommandList(result, cmdlets);
                    return result;
                }
                else
                {
                    foreach (var cmdlet in cmdlets)
                    {
                        if (cmdlet.Keys.Split(Constants.CmdletIndexWordSeparator[0]).Length == arguments.Length)
                        {
                            GenerateSingleCommandHelp(format, result, cmdlet);
                            return result;
                        }
                    }
                }
            }

            return new string[] { string.Format(Strings.CmdletHelp_Generate_NoCommandAvailable, CLUEnvironment.ScriptName, string.Join(" ", arguments)) };
        }

        private static void GenerateCommandList(List<string> result, InstalledCmdletInfo[] cmdlets)
        {
            var longest = cmdlets
                .Select(c => new { Name = $"{CLUEnvironment.ScriptName} {c.Keys.Replace(Constants.CmdletIndexWordSeparator[0], ' ')}", Brief = c.Info.Brief })
                .Select(n => n.Name.Length).Max<int>();

            foreach (var cmdlet in cmdlets)
            {
                var bldr = new StringBuilder();
                var name = $"{CLUEnvironment.ScriptName} {cmdlet.Keys.Replace(Constants.CmdletIndexWordSeparator[0], ' ')}";
                bldr.Append(name);
                bldr.Append(new String(' ', longest - name.Length + 1));
                bldr.Append(cmdlet.Info.Brief);
                result.Add(bldr.ToString());
            }
        }

        private static void GenerateSingleCommandHelp(Func<string, string, bool, bool, string> formatter, List<string> result, InstalledCmdletInfo cmdlet)
        {
            var info = cmdlet.Info;

            if (string.IsNullOrEmpty(info.Brief))
            {
                result.Add("");
                result.Add($"{info.Name}");
            }
            else
            {
                result.Add("");
                result.Add($"{info.Name}: {info.Brief}");
            }

            if (info.Description.Count > 0)
            {
                result.Add("");

                foreach (var descLine in info.Description)
                {
                    result.Add("");
                    result.Add($"{descLine}");
                }
            }

            result.Add("");
            result.Add("");
            result.Add(Strings.CmdletHelp_GenerateSingleCommandHelp_TxtCommandSyntax);

            var parameters = new Dictionary<string, MAMLReader.ParameterHelpInfo>();

            foreach (var pset in info.ParameterSets)
            {
                result.Add("");

                var builder = new System.Text.StringBuilder();
                builder.Append(CLUEnvironment.ScriptName).Append(' ').Append(info.Keys.Replace(';', ' '));

                foreach (var p in pset.Parameters)
                {
                    if (!parameters.ContainsKey(p.Name))
                        parameters.Add(p.Name, p);
                    var formattedName = formatter(p.Name, MapTypeName(p.Type), p.IsMandatory, p.Position != int.MaxValue);
                    builder.Append(' ').Append(formattedName);
                }
                result.Add(builder.ToString());
            }

            AddReflectionParameterInfo(cmdlet, parameters);

            if (parameters.Values.Count > 0)
            {
                result.Add("");
                result.Add("");
                result.Add(Strings.CmdletHelp_GenerateSingleCommandHelp_TxtParameters);
                result.Add("");

                bool hasDescriptions = parameters.Values.SelectMany(p => p.Description).Any();

                foreach (var p in parameters.Values)
                {
                    var bldr = new StringBuilder(formatter(p.Name, null, true, false));
                    var aliases = p.Aliases != null ? string.Join(", ", p.Aliases.Select(a => formatter(a, null, true, false))) : null;
                    if (!string.IsNullOrEmpty(aliases))
                    {
                        bldr.Append(", ").Append(aliases);
                    }
                    result.Add(bldr.ToString());

                    foreach (var desc in p.Description)
                    {
                        result.Add(desc);
                    }

                    if (hasDescriptions)
                        result.Add("");
                }
            }

            result.Add("");
        }

        private static IEnumerable<InstalledModuleInfo> FindMatches(IEnumerable<string> modules, string[] args)
        {
            var matches = InstalledModuleInfo.Enumerate(modules, args).ToArray();

            if (matches.Length == 0)
            {
                return null;
            }

            foreach (var module in matches)
            {
                var mappings = ConfigurationDictionary.Load(Path.Combine(module.Package.FullPath, Constants.IndexFolder, Constants.NameMappingFileName));

                foreach (var cmd in module.Cmdlets.Select(c => { c.CommandName = mappings[c.Keys]; return c; }).GroupBy(c => c.AssemblyName))
                {
                    MAMLReader.ReadMAMLFile(module.Package.ContentDirPath, cmd.Key, cmd);
                }
            }

            AddReflectionCmdletInfo(matches);

            return matches;
        }

        private static void AddReflectionCmdletInfo(InstalledModuleInfo[] matches)
        {
            foreach (var cmdlet in matches.SelectMany(m => m.Cmdlets).Where(c => c.Info == null))
            {
                var typeMetadata = new TypeMetadata(cmdlet.Type);
                typeMetadata.Load();

                cmdlet.Info = new MAMLReader.CommandHelpInfo { Name = cmdlet.CommandName, Keys = cmdlet.Keys };

                if (typeMetadata.ParameterSets != null && typeMetadata.ParameterSets.Count > 0)
                {
                    foreach (var pSet in typeMetadata.ParameterSets)
                    {
                        var psetInfo = new MAMLReader.ParameterSetHelpInfo();
                        cmdlet.Info.ParameterSets.Add(psetInfo);
                        psetInfo.Parameters.AddRange(pSet.Parameters
                            .Select(p => new MAMLReader.ParameterHelpInfo
                            {
                                Name = p.Name,
                                Aliases = p.Aliases != null ? p.Aliases.ToArray() : null,
                                IsMandatory = p.IsMandatory,
                                Position = p.Position,
                                Type = p.ParameterType.Name
                            }));
                    }
                }
                else
                {
                    var psetInfo = new MAMLReader.ParameterSetHelpInfo();
                    cmdlet.Info.ParameterSets.Add(psetInfo);
                    psetInfo.Parameters.AddRange(typeMetadata.Parameters.Values.Where(p => !p.IsBuiltin)
                        .Select(p => new MAMLReader.ParameterHelpInfo
                        {
                            Name = p.Name,
                            Aliases = p.Aliases != null ? p.Aliases.ToArray() : null,
                            IsMandatory = p.IsMandatory(null),
                            Position = p.Position(null),
                            Type = p.ParameterType.Name
                        }));
                }
            }
        }

        private static void AddReflectionParameterInfo(InstalledCmdletInfo cmdlet, Dictionary<string, MAMLReader.ParameterHelpInfo> parameters)
        {
            var typeMetadata = new TypeMetadata(cmdlet.Type);
            typeMetadata.Load();

            foreach (var p in parameters)
            {
                ParameterMetadata metadata;
                if (typeMetadata.Parameters.TryGetValue(p.Key.ToLowerInvariant(), out metadata))
                {
                    p.Value.Aliases = metadata.Aliases.ToArray();
                }
            }
        }

        private static string MapTypeName(string name)
        {
            switch (name)
            {
                case "SwitchParameter":
                    return null;
                case "Boolean":
                    return "<bool>";
                case "Byte":
                    return "<byte>";
                case "Int32":
                    return "<int>";
                case "Int64":
                    return "<long>";
                case "Char":
                case "String":
                    return $"<{name.ToLower()}>";
                default:
                    return $"<{name}>";
            }
        }
    }
}
#endif