using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.CLU.Common;
using System.Diagnostics;

namespace Microsoft.CLU.Help
{
    /// <summary>
    /// This class contains logic to read Powershell help files using the MAML schema.
    /// </summary>
    internal static class MAMLReader
    {
        /// <summary>
        /// Reads a help file for a given assembly in a given package for a given set of commands.
        /// Any content that is found is attached to the command record.
        /// 
        /// </summary>
        /// <param name="contentRootPath">Absolute path to the content folder containing MAML file</param>
        /// <param name="assembly">The specific command assembly in which the commands are found.</param>
        /// <param name="commands">A sequence of command records to look for.</param>
        internal static void ReadMAMLFile(string contentRootPath, string assembly, IEnumerable<InstalledCmdletInfo> commands)
        {
            Debug.Assert(!string.IsNullOrEmpty(contentRootPath));
            Debug.Assert(!string.IsNullOrEmpty(assembly));
            Debug.Assert(commands != null);

            var nameSet = commands.ToDictionary(desc => desc.CommandName);

            var path = Path.Combine(contentRootPath, assembly + "-help.xml");

            if (File.Exists(path))
            {
                var doc = XDocument.Load(path);

                var helpItems = doc.Root;

                foreach (var command in GetChildrenMatching(helpItems, "command"))
                {
                    var info = new CommandHelpInfo();

                    FillInDetails(command, info);

                    InstalledCmdletInfo cmdlet = null;
                    if (string.IsNullOrEmpty(info.Name) || 
                        !nameSet.TryGetValue(info.Name, out cmdlet))
                    {
                        continue;
                    }

                    info.Keys = cmdlet.Keys;
                    cmdlet.Info = info;

                    FillInParameterSets(command, info);
                }
            }
        }

        /// <summary>
        /// Extract command-level information from the MAML contents.
        /// </summary>
        /// <param name="command">The command XML element.</param>
        /// <param name="descriptor">A command info record.</param>
        private static void FillInDetails(XElement command, CommandHelpInfo descriptor)
        {
            var details = GetChildrenMatching(command, "details").FirstOrDefault();
            if (details != null)
            {
                descriptor.Name = GetChildrenMatching(details, "name").FirstOrDefault().Value;
                descriptor.Brief = GetChildrenMatching(details, "description").FirstOrDefault().Value;
            }

            FillInDescriptionRecords(GetChildrenMatching(command, "description").FirstOrDefault(), descriptor);
        }

        /// <summary>
        /// Fill in a description for any record type that has them (commands and parameters).
        /// </summary>
        /// <param name="description">The description element, a sequence of paragraphs.</param>
        /// <param name="descriptor">The target record.</param>
        private static void FillInDescriptionRecords(XElement description, HelpInfoWithDescription descriptor)
        {
            if (description != null)
            {
                foreach (var para in GetChildrenMatching(description, "para"))
                {
                    descriptor.Description.Add(para.Value);
                }
            }
        }

        /// <summary>
        /// Fill in information for parameter sets and parameters.
        /// </summary>
        /// <param name="command">The command XML element.</param>
        /// <param name="descriptor">A command info record.</param>
        private static void FillInParameterSets(XElement command, CommandHelpInfo descriptor)
        {
            var syntax = GetChildrenMatching(command, "syntax").FirstOrDefault();
            if (syntax != null)
            {
                foreach (var syntaxItem in GetChildrenMatching(syntax, "syntaxItem"))
                {
                    var pset = new ParameterSetHelpInfo();
                    descriptor.ParameterSets.Add(pset);

                    foreach (var param in GetChildrenMatching(syntaxItem, "parameter"))
                    {
                        var p = new ParameterHelpInfo();
                        pset.Parameters.Add(p);

                        var name = GetChildrenMatching(param, "name").FirstOrDefault();
                        if (name != null)
                            p.Name = name.Value;
                        var type = GetChildrenMatching(param, "parameterValue").FirstOrDefault();
                        if (type != null)
                            p.Type = type.Value;
                        var required = GetAttributeMatching(param, "required").FirstOrDefault();
                        if (required != null)
                            p.IsMandatory = bool.Parse(required.Value);
                        var position = GetAttributeMatching(param, "position").FirstOrDefault();
                        if (position != null)
                        {
                            int pos = int.MaxValue;
                            if (int.TryParse(position.Value, out pos))
                                p.Position = pos;
                        }
                        FillInDescriptionRecords(GetChildrenMatching(param, "description").FirstOrDefault(), p);
                    }

                    pset.Parameters.Sort((x, y) => x.Position.CompareTo(y.Position));
                }
            }

        }

        private static IEnumerable<XElement> GetChildrenMatching(XElement node, string name)
        {
            return node.Nodes().Where(c => Matches(c as XElement, name)).Select(c => c as XElement);
        }

        private static IEnumerable<XAttribute> GetAttributeMatching(XElement node, string name)
        {
            return node.Attributes().Where(c => Matches(c, name));
        }

        private static bool Matches(XElement node, string name)
        {
            return node != null && node.Name.LocalName.Equals(name);
        }

        private static bool Matches(XAttribute node, string name)
        {
            return node != null && node.Name.LocalName.Equals(name);
        }


        internal class HelpInfoWithDescription
        {
            internal List<string> Description { get; set; } = new List<string>();
        }

        internal class CommandHelpInfo : HelpInfoWithDescription
        {
            internal string Name { get; set; }
            internal string Brief { get; set; }

            internal string Keys { get; set; }

            internal List<ParameterSetHelpInfo> ParameterSets { get; set; } = new List<ParameterSetHelpInfo>();
        }

        internal class ParameterSetHelpInfo
        {
            internal List<ParameterHelpInfo> Parameters { get; set; } = new List<ParameterHelpInfo>();

        }
        internal class ParameterHelpInfo : HelpInfoWithDescription
        {
            internal string Name { get; set; }
            internal string[] Aliases { get; set; }

            internal string Type { get; set; }

            internal bool IsMandatory { get; set; }

            internal int Position { get; set; } = int.MaxValue;
        }
    }
}
