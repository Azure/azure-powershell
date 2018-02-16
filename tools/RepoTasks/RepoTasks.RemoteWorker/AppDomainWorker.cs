// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace RepoTasks.RemoteWorker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using System.Xml.Serialization;

    public class AppDomainWorker : MarshalByRefObject, IReflectionWorker
    {
        private Configuration _configuration;

        public string BuildFormatPs1Xml(string assemblyPath, string[] cmdlets)
        {
            string assemblyName;
            var cmdletTypes = GetCmdletTypes(assemblyPath, cmdlets, out assemblyName);
            Console.WriteLine($"assembly: {assemblyName}");
            if (cmdletTypes.Count == 0) return null;
            _configuration = BuildXmlConfiguration(cmdletTypes);
            var filename = assemblyName + ".generated.format.ps1xml";
            return filename;
        }

        public void Serialize(string filepath)
        {
            Serialize(_configuration, filepath);
        }

        internal static IList<Type> GetCmdletTypes(string assemblyPath, string[] cmdlets, out string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyPath)) throw new ArgumentNullException(nameof(assemblyPath));
            Console.WriteLine("Child domain: " + AppDomain.CurrentDomain.FriendlyName);
            var assembly = Assembly.LoadFrom(assemblyPath);

            assemblyName = assembly.GetName().Name;
            var cmdletTypes = assembly
                .ExportedTypes
                .Where(
                    type => {
                        var attributes = type.GetCustomAttributes(
                            typeof(CmdletAttribute),
                            false);

                        if (attributes.Length == 0) return false;
                        var cmdletAttribute = (CmdletAttribute)attributes.First();
                        if (cmdletAttribute == null) return false;
                        if (!(cmdlets?.Length > 0)) return true;
                        var attrCmdlet = $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";
                        //Console.WriteLine("=== attrCmdlet: " + attrCmdlet);
                        return cmdlets.Any(cmdlet => string.Equals(cmdlet, attrCmdlet, StringComparison.OrdinalIgnoreCase));
                    })
                .ToList();

            return cmdletTypes;
        }

        private readonly ISet<string> _usedTypes = new HashSet<string>();

        internal Configuration BuildXmlConfiguration(IEnumerable<Type> cmdletTypList)
        {
            var viewList = new List<View>();

            foreach (var cmdletType in cmdletTypList)
            {
                var attributes = cmdletType.GetCustomAttributes(
                    typeof(OutputTypeAttribute),
                    false);

                if (attributes.Length == 0)
                {
                    //WriteWarning($"command {cmdletType} doesn't have OutputTypeAttribute");
                    continue;
                }

                Console.WriteLine($"\tcmdlet: {cmdletType.Name}");

                foreach (var attribute in attributes)
                {
                    var outputTypeAttrubute = (OutputTypeAttribute)attribute;
                    var psTypeNames = outputTypeAttrubute.Type;
                    foreach (var psTypeName in psTypeNames)
                    {
                        if (_usedTypes.Contains(psTypeName.Name)) continue;
                        Console.WriteLine($"\t\toutputType: {psTypeName.Name}");
                        _usedTypes.Add(psTypeName.Name);

                        var tableHeaders = new List<TableColumnHeader>();
                        var tableColumnItems = new List<TableColumnItem>();
                        var listItems = new List<ListItem>();

                        var psType = psTypeName.Type;

                        foreach (var propertyInfo in psType.GetProperties().OrderBy(p => p.Name))
                        {
                            Console.WriteLine($"\t\t\tproperty: {propertyInfo.Name}");
                            tableHeaders.Add(new TableColumnHeader
                            {
                                Label = propertyInfo.Name
                            });

                            tableColumnItems.Add(new TableColumnItem
                            {
                                Alignment = Alignment.Left,
                                PropertyName = propertyInfo.Name
                            });

                            listItems.Add(new ListItem
                            {
                                PropertyName = propertyInfo.Name
                            });
                        }

                        viewList.Add(new View
                        {
                            Name = psTypeName.Name,
                            ViewSelectedBy = new ViewSelectedBy
                            {
                                TypeName = psTypeName.Name
                            },
                            TableControl = new TableControl
                            {
                                TableHeaders = tableHeaders.ToArray(),
                                TableRowEntries = new[] {
                                    new TableRowEntry {
                                        TableColumnItems = tableColumnItems.ToArray()
                                    }
                                }
                            }
                        });

                        foreach (var fieldInfo in psType.GetFields().OrderBy(p => p.Name))
                        {
                            Console.WriteLine($"\t\t\tfield: {fieldInfo.Name}");
                            tableHeaders.Add(new TableColumnHeader
                            {
                                Label = fieldInfo.Name
                            });

                            tableColumnItems.Add(new TableColumnItem
                            {
                                Alignment = Alignment.Left,
                                PropertyName = fieldInfo.Name
                            });

                            listItems.Add(new ListItem
                            {
                                PropertyName = fieldInfo.Name
                            });
                        }

                        viewList.Add(new View
                        {
                            Name = psTypeName.Name,
                            ViewSelectedBy = new ViewSelectedBy
                            {
                                TypeName = psTypeName.Name
                            },
                            ListControl = new ListControl
                            {
                                ListEntries = new[] {
                                    new ListEntry {
                                        ListItems = listItems.ToArray()
                                    }
                                }
                            }
                        });
                    }
                }
            }

            var configuration = new Configuration
            {
                ViewDefinitions = new ViewDefinitions
                {
                    Views = viewList.ToArray()
                }
            };

            return configuration;
        }

        internal static void Serialize(Configuration configuration, string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(Configuration));

            using (Stream filestream = File.Create(filePath))
            {
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(filestream, configuration, xmlns);
            }
        }
    }
}
