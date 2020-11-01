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

namespace FormatPs1XmlGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;
    using System.Xml.Serialization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class Reflector
    {
        private Configuration _configuration;
        private bool _onlyMarkedProperties;
        public PSCmdlet Cmdlet { get; set; }

        public string BuildFormatPs1Xml(string assemblyPath, string[] cmdlets, bool onlyMarkedProperties)
        {
            _onlyMarkedProperties = onlyMarkedProperties;
            var cmdletTypes = GetCmdletTypes(assemblyPath, cmdlets, out var assemblyName);
            if (cmdletTypes.Count == 0) return null;
            _configuration = BuildXmlConfiguration(cmdletTypes);
            var filename = assemblyName + ".generated.format.ps1xml";
            return filename;;
        }

        public void Serialize(string filepath)
        {
            Serialize(_configuration, filepath);
        }

        public IList<Type> GetCmdletTypes(string assemblyPath, string[] cmdlets, out string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyPath)) throw new ArgumentNullException(nameof(assemblyPath));

            // Every module has dependecy on the Az.Accounts module
            // First, try to find the Az.Accounts module in the 'artifacts' directory
            Assembly Resoler(AssemblyLoadContext context, AssemblyName name)
            {
                try
                {
                    // we assume that our assembly is in the 'artifacts' directory as well
                    var assemblyDirectory = Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException();
                    var accountPath = Path.Combine(assemblyDirectory, Path.Combine("..", @"Az.Accounts"));
                    return Assembly.LoadFrom(Path.Combine(accountPath, $"{name.Name}.dll"));
                }
                catch
                {
                    return null;
                }
            }

            try
            {
                // if the Az.Accounts module gets imported manually
                return LoadAssemblyAndGetCmdletTypes(assemblyPath, cmdlets, out assemblyName);
            }
            catch
            {
                try
                {
                    AssemblyLoadContext.Default.Resolving += Resoler;
                    return LoadAssemblyAndGetCmdletTypes(assemblyPath, cmdlets, out assemblyName);
                }
                finally
                {
                    AssemblyLoadContext.Default.Resolving -= Resoler;
                }
            }
        }

        public IList<Type> LoadAssemblyAndGetCmdletTypes(string assemblyPath, string[] cmdlets, out string assemblyName)
        {
            var assembly = Assembly.LoadFrom(assemblyPath);
            assemblyName = assembly.GetName().Name;
            var cmdletTypes = assembly
                .ExportedTypes
                .Where(
                    type =>
                    {
                        var attributes = type.GetCustomAttributes(
                            typeof(CmdletAttribute),
                            false);

                        if (attributes.Length == 0) return false;
                        var cmdletAttribute = (CmdletAttribute) attributes.First();
                        if (cmdletAttribute == null) return false;
                        if (!(cmdlets?.Length > 0)) return true;
                        var attrCmdlet = $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";
                        return cmdlets.Any(cmdlet =>
                            string.Equals(cmdlet, attrCmdlet, StringComparison.OrdinalIgnoreCase));
                    })
                .ToList();
            return cmdletTypes;
        }

        private readonly ISet<string> _usedTypes = new HashSet<string>();

        public Configuration BuildXmlConfiguration(IEnumerable<Type> cmdletTypeLists)
        {
            var viewList = new List<View>();

            foreach (var cmdletType in cmdletTypeLists)
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
                        GroupByInfo groupByInfo = null;

                        HandleMemberInfo(psType.GetProperties(), tableHeaders, tableColumnItems, listItems, ref groupByInfo);
                        HandleMemberInfo(psType.GetFields(), tableHeaders, tableColumnItems, listItems, ref groupByInfo);

                        if (tableHeaders.Count != 0)
                        {
                            var view = new View
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
                            };

                            if (groupByInfo != null && (groupByInfo.TargetView & ViewControl.Table) != ViewControl.None)
                            {
                                view.GroupBy = new GroupBy
                                {
                                    Label = groupByInfo.Label
                                };
                                if (groupByInfo.ScriptBlock != null)
                                {
                                    view.GroupBy.ScriptBlock = groupByInfo.ScriptBlock;
                                }
                                else
                                {
                                    view.GroupBy.PropertyName = groupByInfo.PropertyName;
                                }
                            }

                            viewList.Add(view);
                        }

                        if (listItems.Count != 0)
                        {
                            var view = new View
                            {
                                Name = psTypeName.Name,
                                ViewSelectedBy = new ViewSelectedBy
                                {
                                    TypeName = psTypeName.Name
                                },
                                ListControl = new ListControl
                                {
                                    ListEntries = new[]
                                    {
                                        new ListEntry
                                        {
                                            ListItems = listItems.ToArray()
                                        }
                                    }
                                }
                            };

                            if (groupByInfo != null && (groupByInfo.TargetView & ViewControl.List) != ViewControl.None)
                            {
                                view.GroupBy = new GroupBy
                                {
                                    Label = groupByInfo.Label
                                };
                                if (groupByInfo.ScriptBlock != null)
                                {
                                    view.GroupBy.ScriptBlock = groupByInfo.ScriptBlock;
                                }
                                else
                                {
                                    view.GroupBy.PropertyName = groupByInfo.PropertyName;
                                }
                            }

                            viewList.Add(view);
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

        internal class GroupByInfo {
            public  string Label { get; set; }
            public  string PropertyName { get; set; }
            public  string ScriptBlock { get; set; }
            public ViewControl TargetView { get; set; }
        }

        internal void HandleMemberInfo<T>(
            IEnumerable<T> memberInfoList,
            IList<TableColumnHeader> tableHeaders, 
            IList<TableColumnItem> tableColumnItems, 
            IList<ListItem> listItems,
            ref GroupByInfo groupByInfo) 
            where T: MemberInfo
        {
            var memeber = typeof(T) == typeof(PropertyInfo)
                ? "property"
                : "field";

            var memberInfoListFiltered = memberInfoList
                .Where(p => {
                    if (!_onlyMarkedProperties) return true;
                    var ps1XmlAttributes = Attribute.GetCustomAttributes(p, typeof(Ps1XmlAttribute));
                    return ps1XmlAttributes.Length > 0;
                })
                .ToList();

            if (memberInfoListFiltered.Count == 0) return;

            var columnHeadersWithPosition = new List<Tuple<TableColumnHeader, uint>>();
            var columnItemsWithPosition = new List<Tuple<TableColumnItem, uint>>();
            var listItemsWithPosition = new List<Tuple<ListItem, uint>>();

            // Tuple type assignment: output type name, base type name, property name
            // We track the base type to get a proper warning in case when duplication occurs in a base and derived classes.
            var dupTrackerGroupBy = new List<Tuple<string, string, string>>();
            
            // tuple type assignment: output type name, base type name, property name, position property value
            var dupTrackerPosition = new List<Tuple<string, string, string, uint>>();

            foreach (var memberInfo in memberInfoListFiltered)
            {
                if (_onlyMarkedProperties)
                {
                    var ps1XmlAttributes = Attribute.GetCustomAttributes(memberInfo, typeof(Ps1XmlAttribute));
                    foreach (var attribute in ps1XmlAttributes)
                    {
                        var ps1XmlAttribute = (Ps1XmlAttribute) attribute;
                        if (ps1XmlAttribute.GroupByThis)
                        {
                            dupTrackerGroupBy.Add(Tuple.Create(memberInfo.DeclaringType?.Name, memberInfo.DeclaringType?.BaseType?.Name, memberInfo.Name));

                            if (groupByInfo == null)
                            {
                                groupByInfo = new GroupByInfo
                                {
                                    Label = ps1XmlAttribute.Label,
                                    ScriptBlock = ps1XmlAttribute.ScriptBlock,
                                    PropertyName = memberInfo.Name,
                                    TargetView = ps1XmlAttribute.Target,
                                };

                                continue;
                            }
                        }

                        var position = ps1XmlAttribute.Position;

                        if ((ps1XmlAttribute.Target & ViewControl.Table) != ViewControl.None)
                        {
                            uint? width = ps1XmlAttribute.TableColumnWidth;
                            var tableColumnHeader = new TableColumnHeader
                            {
                                Label = ps1XmlAttribute.Label ?? memberInfo.Name,
                                Width = width > 0 ? width : null,
                            };

                            var tableColumnItem = ps1XmlAttribute.ScriptBlock != null
                                ? new TableColumnItem
                                {
                                    Alignment = Alignment.Left,
                                    ScriptBlock = ps1XmlAttribute.ScriptBlock,
                                }
                                : new TableColumnItem
                                {
                                    Alignment = Alignment.Left,
                                    PropertyName = memberInfo.Name,
                                };

                            if (position == Ps1XmlConstants.DefaultPosition)
                            {
                                tableHeaders.Add(tableColumnHeader);
                                tableColumnItems.Add(tableColumnItem);
                            }
                            else
                            {
                                columnHeadersWithPosition.Add(Tuple.Create(tableColumnHeader, position));
                                columnItemsWithPosition.Add(Tuple.Create(tableColumnItem, position));
                                dupTrackerPosition.Add(Tuple.Create(memberInfo.DeclaringType?.Name, memberInfo.DeclaringType?.BaseType?.Name, memberInfo.Name, position));
                            }
                        }

                        if ((ps1XmlAttribute.Target & ViewControl.List) == ViewControl.None) continue;

                        var listItem = (ps1XmlAttribute.ScriptBlock != null)
                            ? new ListItem
                            {
                                ScriptBlock = ps1XmlAttribute.ScriptBlock,
                            }
                            : new ListItem
                            {
                                PropertyName = memberInfo.Name
                            };

                        if (ps1XmlAttribute.Label != null)
                        {
                            listItem.Label = ps1XmlAttribute.Label;
                        }

                        if (position == Ps1XmlConstants.DefaultPosition)
                        {
                            listItems.Add(listItem);
                        }
                        else
                        {
                            listItemsWithPosition.Add(Tuple.Create(listItem, position));
                        }
                    }
                }
                else
                {
                    tableHeaders.Add(new TableColumnHeader
                    {
                        Label = memberInfo.Name
                    });

                    tableColumnItems.Add(new TableColumnItem
                    {
                        Alignment = Alignment.Left,
                        PropertyName = memberInfo.Name
                    });

                    listItems.Add(new ListItem
                    {
                        PropertyName = memberInfo.Name
                    });
                }
            }

            // track duplicate
            if (dupTrackerGroupBy.Count > 1)
            {
                var warning = "Found a duplicate. GroupByThis is true for the following properties: ";

                foreach (var tuple in dupTrackerGroupBy)
                {
                    var outputTypeName = tuple.Item1;
                    var baseTypeName = tuple.Item2;
                    var propName = tuple.Item3;
                    warning = warning + "'" + propName + "' in the class " + outputTypeName + " : " + baseTypeName + "; ";
                }

                Cmdlet.WriteWarning(warning); 
            }

            var duplicates = dupTrackerPosition
                .GroupBy(p => p.Item4)
                .Where(g => g.Count() > 1)
                .ToList();

            if (duplicates.Count > 0)
            {
                var warning = "Found a duplicate. ";
                foreach (var duplicate in duplicates)
                {
                    warning += $"Position value of {duplicate.Key} specified: ";
                    foreach (var tuple in duplicate)
                    {
                        var outputTypeName = tuple.Item1;
                        var baseTypeName = tuple.Item2;
                        var propName = tuple.Item3;
                        warning = warning + "'" + propName + "' in the class " + outputTypeName + " : " + baseTypeName + "; ";
                    }
                }

                Cmdlet.WriteWarning(warning);
            }

            Merge(tableHeaders, columnHeadersWithPosition);
            Merge(tableColumnItems, columnItemsWithPosition);
            Merge(listItems, listItemsWithPosition);
        }

        internal void Merge<T>(IList<T> dstList, IList<Tuple<T,uint>> srcListWithPosition)
        {
            foreach (var tuple in srcListWithPosition.OrderBy(t => t.Item2))
            {
                var index = (int)tuple.Item2;
                if (index < dstList.Count)
                {
                    dstList.Insert(index, tuple.Item1);
                }
                else
                {
                    dstList.Add(tuple.Item1);
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
