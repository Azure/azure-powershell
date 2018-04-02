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
    using System.Reflection;
    using System.Xml.Serialization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class AppDomainWorker : MarshalByRefObject, IReflectionWorker
    {
        private Configuration _configuration;
        private bool _onlyMarkedProperties;

        public string BuildFormatPs1Xml(string assemblyPath, string[] cmdlets, bool onlyMarkedProperties)
        {
            _onlyMarkedProperties = onlyMarkedProperties;
            string assemblyName;
            var cmdletTypes = GetCmdletTypes(assemblyPath, cmdlets, out assemblyName);
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

                if (attributes.Length == 0) continue;

                foreach (var attribute in attributes)
                {
                    var outputTypeAttrubute = (OutputTypeAttribute)attribute;
                    var psTypeNames = outputTypeAttrubute.Type;

                    foreach (var psTypeName in psTypeNames)
                    {
                        if (_usedTypes.Contains(psTypeName.Name)) continue;
                        _usedTypes.Add(psTypeName.Name);

                        var psType = psTypeName.Type;

                        var tableHeaders = new List<TableColumnHeader>();
                        var tableColumnItems = new List<TableColumnItem>();
                        var listItems = new List<ListItem>();

                        HandleMemberInfo(psType.GetProperties(), tableHeaders, tableColumnItems, listItems);
                        HandleMemberInfo(psType.GetFields(), tableHeaders, tableColumnItems, listItems);

                        if (tableHeaders.Count != 0)
                        {
                            viewList.Add(
                                new View
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
                                }
                            );
                        }

                        if (listItems.Count != 0)
                        {
                            viewList.Add(
                                new View
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
                                }
                            );
                        }
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

        internal void HandleMemberInfo<T>(
            IEnumerable<T> memberInfoList,
            IList<TableColumnHeader> tableHeaders, 
            IList<TableColumnItem> tableColumnItems, 
            IList<ListItem> listItems) 
            where T: MemberInfo
        {

            var memeber = typeof(T) == typeof(PropertyInfo)
                ? "property"
                : "field";

            var memberInfoListFiltered = memberInfoList
                .Where(p => {
                    if (!_onlyMarkedProperties) return true;
                    var ps1XmlAttribute = (Ps1XmlAttribute)Attribute.GetCustomAttribute(p, typeof(Ps1XmlAttribute));
                    return ps1XmlAttribute != null;
                })
                .OrderBy(p => p.Name)
                .ToList();

            if (memberInfoListFiltered.Count == 0) return;

            foreach (var memberInfo in memberInfoListFiltered)
            {
                var ps1XmlAttribute = _onlyMarkedProperties
                    ? (Ps1XmlAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(Ps1XmlAttribute))
                    : null;

                if (_onlyMarkedProperties && ps1XmlAttribute == null) throw new InvalidCastException("Ps1XmlAttribute");

                if (ps1XmlAttribute == null ||
                    (ps1XmlAttribute.Target & ViewControl.Table) != ViewControl.None)
                {
                    tableHeaders.Add(new TableColumnHeader
                    {
                        Label = ps1XmlAttribute?.Label ?? memberInfo.Name
                    });

                    tableColumnItems.Add(new TableColumnItem
                    {
                        Alignment = Alignment.Left,
                        PropertyName = memberInfo.Name
                    });
                }

                if (ps1XmlAttribute == null ||
                    (ps1XmlAttribute.Target & ViewControl.List) != ViewControl.None)
                {
                    listItems.Add(new ListItem
                    {
                        PropertyName = memberInfo.Name
                    });
                }
            }
        }

        internal void Serialize(Configuration configuration, string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(Configuration));

            using (var stream = File.Create(filePath))
            {
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(stream, configuration, xmlns);
            }
        }
    }
}
