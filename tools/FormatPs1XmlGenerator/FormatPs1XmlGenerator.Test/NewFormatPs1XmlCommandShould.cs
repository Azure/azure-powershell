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

using System;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FormatPs1XmlGenerator.Test
{
    public class NewFormatPs1XmlCommandShould
    {
        private const string CmdletName = "New-FormatPs1Xml";
        private const string ExpectedAssemblyName = "CmdletsForTest";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildPs1XmlFileAndSaveItOnDisk()
        {
            var initialSessionState = InitialSessionState.CreateDefault();

            initialSessionState.Commands.Add(
                new SessionStateCmdletEntry(
                    CmdletName,
                    typeof(NewFormatPs1XmlCommand),
                    null));

            using (var runspace = RunspaceFactory.CreateRunspace(initialSessionState))
            {
                runspace.Open();
                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runspace;

                    var cmdlet = new Command(CmdletName);

                    powershell.Commands.AddCommand(cmdlet);
                    cmdlet.Parameters.Add("ModulePath", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dummy.psd1"));

                    var results = powershell.Invoke<string>();

                    var es = powershell.Streams.Error;

                    Assert.True(es.Count == 0, string.Join("\n,", es));
                    Assert.True(results.Count > 0);
                    var filepath = results.First();
                    Assert.NotNull(filepath);
                    Assert.True(File.Exists(filepath));

                    var xelement = XElement.Load(filepath);
                    var config = xelement.Elements().ToList();

                    TestXml(config, 
                        new[] { "RequestId", "ScriptBlock", "StatusCode", "Id", "Name", "Type", "PsDummyOutput2" },
                        $"{ExpectedAssemblyName}.Models.PsDummyOutput1");

                    TestXml(config,
                        new[] { "LicenseType", "Location" , "Name" },
                        $"{ExpectedAssemblyName}.Models.PsDummyOutput2");
                }
            }
        }

        private enum EntryType
        {
            PropertyName,
            ScriptBlock,
        }

        [Flags]
        private enum View
        {
            None = 0,
            Table,
            List,
            Both,
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveOnlyMarkedPropertiesInSpecifiedViews()
        {
            var initialSessionState = InitialSessionState.CreateDefault();

            initialSessionState.Commands.Add(
                new SessionStateCmdletEntry(
                    CmdletName,
                    typeof(NewFormatPs1XmlCommand),
                    null));

            using (var runspace = RunspaceFactory.CreateRunspace(initialSessionState))
            {
                runspace.Open();
                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runspace;

                    var cmdlet = new Command(CmdletName);

                    powershell.Commands.AddCommand(cmdlet);
                    cmdlet.Parameters.Add("ModulePath", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dummy.psd1"));
                    cmdlet.Parameters.Add("OnlyMarkedProperties");
                    cmdlet.Parameters.Add("OutputPath", AppDomain.CurrentDomain.BaseDirectory);

                    var results = powershell.Invoke<string>();

                    var es = powershell.Streams.Error;

                    Assert.True(es.Count == 0, string.Join("\n,", es));
                    Assert.True(results.Count > 0);

                    var ws = powershell.Streams.Warning;
                    Assert.True(ws.Count == 2);

                    string filepath = null;
                    try
                    {
                        filepath = results.First();
                        Assert.NotNull(filepath);
                        Assert.True(File.Exists(filepath));

                        var xelement = XElement.Load(filepath);
                        var config = xelement.Elements().ToList();

                        TestXmlMarked(config,
                            // entrytype (1), prop-name or script-block (2), target (3), label (4), table-column-width (5), position (6), group-by-this-param (7)
                            new List<Tuple<EntryType, string, View, string, uint?, uint?, bool>>
                            {
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "$_.Foo", View.List, "PsDummyOutput1 Id", 0, null, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "RequestId", View.Both, "RequestId", null, 1, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "Name", View.Both, null, 16, null, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "Type", View.Both, "PsDummyOutput1 Type", null, 3, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "$_.PsDummyOutput2.Name", View.Both, "PsDummyOutput2 Name", null, null, true),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "$_.PsDummyOutput2.Location", View.Both, "PsDummyOutput2 Location", null, 0, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "StatusCode", View.None, null, null, null, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "S_.Foo", View.List, null, null, null, false),
                            },
                            $"{ExpectedAssemblyName}.Models.PsDummyOutput1");

                        TestXmlGroupBy(config,
                            new List<Tuple<GroupBy, View>>
                            {
                                new Tuple<GroupBy, View> (new GroupBy{ScriptBlock = "$_.PsDummyOutput2.Name", Label = "PsDummyOutput2 Name"}, View.Both),
                            },
                            $"{ExpectedAssemblyName}.Models.PsDummyOutput1");
                    }
                    finally
                    {
                        if (filepath != null)
                        {
                            File.Delete(filepath);
                        }
                    }
                }
            }
        }

        private class XmlData
        {
            public IList<TableHeaderFromXml> TableHeaders { get; set; }
            public IList<string> TableRowPropNameValues { get; set; }
            public IList<string> TableRowScriptBlockValues { get; set; }
            public IList<ListItem> ListPropNameItems { get; set; }
            public IList<ListItem> ListScriptBlockItems { get; set; }
            public IList<XElement> TableRowEntries { get; set; }
            public IList<XElement> ListEntries { get; set; }
        }

        private class TableHeaderFromXml
        {
            public string Label { get; set; }
            public string Width { get; set; }
        }

        private static XmlData GetDataFromXml(IEnumerable<XElement> config, string typeName)
        {
            var typeViews = config
               .Elements("View")
               .Where(e => e.Element("Name")?.Value == typeName)
               .ToList();

            Assert.Equal(2, typeViews.Count);

            var tableHeadersQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tableHeaders in tableControl.Elements("TableHeaders")
                from tableColumnHeader in tableHeaders.Elements()
                where tableColumnHeader.Element("Label") != null
                select new TableHeaderFromXml
                {
                    Label = tableColumnHeader.Element("Label")?.Value,
                    Width = tableColumnHeader.Element("Width")?.Value,
                };

            var tableRowEntriesQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tableRowEntries in tableControl.Elements("TableRowEntries")
                from tableRowEntry in tableRowEntries.Elements()
                from tableColumnItems in tableRowEntry.Elements()
                from tableColumnItem in tableColumnItems.Elements()
                select tableColumnItem;

            var tableRowEntriesRes = tableRowEntriesQuery.ToList();

            var tableRowEntriesPropNamesQuery = 
                from propertyName in tableRowEntriesRes.Elements("PropertyName")
                select propertyName.Value;

            var tableRowEntriesScriptBlocksQuery = 
                from scriptBlock in tableRowEntriesRes.Elements("ScriptBlock")
                select scriptBlock.Value;

            var listEntriesQuery =
                from listControl in typeViews.Elements("ListControl")
                from listEntries in listControl.Elements()
                from listEntry in listEntries.Elements()
                from listItems in listEntry.Elements()
                from listItem in listItems.Elements()
                select listItem;

            var listEntriesRes = listEntriesQuery.ToList();

            var listEntriesPropNamesQuery =
                from scriptBlockItems in listEntriesRes
                where scriptBlockItems.Element("PropertyName") != null
                select new ListItem
                {
                    Label = scriptBlockItems.Element("Label")?.Value,
                    PropertyName = scriptBlockItems.Element("PropertyName")?.Value,
                };

            var listEntrieScriptBlocksQuery =
                from scriptBlockItems in listEntriesRes
                where scriptBlockItems.Element("ScriptBlock") != null
                select new ListItem
                {
                    Label = scriptBlockItems.Element("Label")?.Value,
                    ScriptBlock = scriptBlockItems.Element("ScriptBlock")?.Value,
                };

            return new XmlData()
            {
                TableHeaders = tableHeadersQuery.ToList(),
                TableRowPropNameValues = tableRowEntriesPropNamesQuery.ToList(),
                TableRowScriptBlockValues = tableRowEntriesScriptBlocksQuery.ToList(),
                ListPropNameItems = listEntriesPropNamesQuery.ToList(),
                ListScriptBlockItems = listEntrieScriptBlocksQuery.ToList(),
                TableRowEntries = tableRowEntriesRes,
                ListEntries = listEntriesRes,
            };
        }

        private static void TestXml(IEnumerable<XElement> config, IEnumerable<string> expectedProps, string typeName)
        {
            var xmlData = GetDataFromXml(config, typeName);
            var expectedPropsOrdered = expectedProps.OrderBy(i => i).ToList();

            var headerLabels = xmlData.TableHeaders.OrderBy(i => i.Label).Select(i=>i.Label).ToList();
            Assert.Equal(expectedPropsOrdered.Count, headerLabels.Count);
            Assert.Equal(expectedPropsOrdered, headerLabels);

            var tableRowPropertyNames = xmlData.TableRowPropNameValues.OrderBy(i => i).ToList();
            Assert.Equal(expectedPropsOrdered.Count, tableRowPropertyNames.Count);
            Assert.Equal(expectedPropsOrdered, tableRowPropertyNames);

            var listEntriesList = xmlData.ListPropNameItems.Select(i=>i.PropertyName).OrderBy(i=>i).ToList();
            Assert.Equal(expectedPropsOrdered.Count, listEntriesList.Count);
            Assert.Equal(expectedPropsOrdered, listEntriesList);
        }

        private static void TestXmlMarked(IList<XElement> config, IEnumerable<Tuple<EntryType, string, View, string, uint?, uint?, bool>> expectedProps, string typeName)
        {
            var xmlData = GetDataFromXml(config, typeName);
            var expectedPropsOrdered = expectedProps.ToList();

            #region Table

            var tableHeaders = xmlData.TableHeaders;
            var expectedTableHeaders = expectedPropsOrdered
                .Where(tuple => (tuple.Item3 & View.Table) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple =>
                    {
                        var strWidth = tuple.Item5?.ToString();
                        return new TableHeaderFromXml
                        {
                            Label = tuple.Item4 ?? tuple.Item2,
                            Width = strWidth,
                        };
                    })
                .ToList();

            var tableHeaderComparer = new Comparer<TableHeaderFromXml>(
                (l, r) => l.Label == r.Label && l.Width == r.Width);

            Assert.Equal(expectedTableHeaders.Count, tableHeaders.Count);
            Assert.Equal(expectedTableHeaders.OrderBy(i=>i.Label), tableHeaders.OrderBy(i=>i.Label), tableHeaderComparer);

            var  expectedPosTableHeaders = expectedPropsOrdered
                .Where(tuple => (tuple.Item3 & View.Table) != View.None)
                .Where(tuple => tuple.Item6 != null)
                .Select(tuple => new
                {
                    Label = tuple.Item4 ?? tuple.Item2,
                    Position = (int)tuple.Item6
                });

            foreach (var pth in expectedPosTableHeaders)
            {
                var value = tableHeaders.Skip(pth.Position).Select(i => i.Label).First();
                Assert.Equal(pth.Label, value);
            }

            var tableRowPropNameValues = xmlData.TableRowPropNameValues;
            var expectedTablePropNameValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.PropertyName)
                .Where(tuple => (tuple.Item3 & View.Table) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => tuple.Item2)
                .ToList();

            Assert.Equal(expectedTablePropNameValues.Count, tableRowPropNameValues.Count);
            Assert.Equal(expectedTablePropNameValues.OrderBy(i=>i), tableRowPropNameValues.OrderBy(i=>i));

            var tableRowScriptBlockValues = xmlData.TableRowScriptBlockValues;
            var expectedTableScriptBlockValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.ScriptBlock)
                .Where(tuple => (tuple.Item3 & View.Table) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => tuple.Item2)
                .ToList();

            Assert.Equal(expectedTableScriptBlockValues.Count, tableRowScriptBlockValues.Count);
            Assert.Equal(expectedTableScriptBlockValues.OrderBy(i=>i), tableRowScriptBlockValues.OrderBy(i=>i));

            var  expectedPosTableItems = expectedPropsOrdered
                .Where(tuple => (tuple.Item3 & View.Table) != View.None)
                .Where(tuple => tuple.Item6 != null)
                .Select(tuple => new
                {
                    EntryType = tuple.Item1,
                    Item = tuple.Item2,
                    Position = (int)tuple.Item6
                });

            foreach (var pti in expectedPosTableItems)
            {
                var value = xmlData.TableRowEntries
                    .Select(e => 
                        e.Element("ScriptBlock")?.Value 
                        ?? e.Element("PropertyName")?.Value)
                    .Skip(pti.Position)
                    .First();
                Assert.Equal(pti.Item, value);
            }

            #endregion

            #region List 

            var listItemComparer = new Comparer<ListItem>(
                (l, r) => l.Label == r.Label && l.ScriptBlock == r.ScriptBlock && l.PropertyName == r.PropertyName);

            var listPropNameEntries = xmlData.ListPropNameItems;
            var expectedListPropNameValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.PropertyName)
                .Where(tuple => (tuple.Item3 & View.List) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => new ListItem
                    {
                        Label = tuple.Item4,
                        PropertyName = tuple.Item2
                    })
                .ToList();

            Assert.Equal(expectedListPropNameValues.Count, listPropNameEntries.Count);
            Assert.Equal(expectedListPropNameValues.OrderBy(i=>i.PropertyName), listPropNameEntries.OrderBy(i=>i.PropertyName), listItemComparer);

            var listScriptBlocksEntries = xmlData.ListScriptBlockItems;
            var expectedListScriptBlocksValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.ScriptBlock)
                .Where(tuple => (tuple.Item3 & View.List) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => new ListItem
                    {
                        Label = tuple.Item4,
                        ScriptBlock = tuple.Item2
                    })
                .ToList();

            Assert.Equal(expectedListScriptBlocksValues.Count, listScriptBlocksEntries.Count);
            Assert.Equal(expectedListScriptBlocksValues.OrderBy(i => i.ScriptBlock), listScriptBlocksEntries.OrderBy(i => i.ScriptBlock), listItemComparer);

            var  expectedPosListItems = expectedPropsOrdered
                .Where(tuple => (tuple.Item3 & View.List) != View.None)
                .Where(tuple => tuple.Item6 != null)
                .Select(tuple => new
                {
                    EntryType = tuple.Item1,
                    Item = tuple.Item2,
                    Position = (int)tuple.Item6
                });

            foreach (var pli in expectedPosListItems)
            {
                var value = xmlData.ListEntries
                    .Select(e => 
                        e.Element("ScriptBlock")?.Value 
                        ?? e.Element("PropertyName")?.Value)
                    .Skip(pli.Position)
                    .First();
                Assert.Equal(pli.Item, value);
            }

            #endregion

            #region Excluded

            var expectedExcludedValues = expectedPropsOrdered
                .Where(tuple => tuple.Item3 == View.None)
                .Select(tuple => tuple.Item2)
                .ToList();

            foreach (var expectedExcludedValue in expectedExcludedValues)
            {
                Assert.DoesNotContain(expectedExcludedValue, listPropNameEntries.Select(i=>i.PropertyName));
                Assert.DoesNotContain(expectedExcludedValue, listScriptBlocksEntries.Select(i=>i.ScriptBlock));
                Assert.DoesNotContain(expectedExcludedValue, tableHeaders.Select(h=>h.Label));
                Assert.DoesNotContain(expectedExcludedValue, tableRowPropNameValues);
                Assert.DoesNotContain(expectedExcludedValue, tableRowScriptBlockValues);
            }

            #endregion
       }

        private static void TestXmlGroupBy(IEnumerable<XElement> config,
            IList<Tuple<GroupBy,View>> expected, string typeName)
        {
            var typeViews = config
                .Elements("View")
                .Where(e => e.Element("Name")?.Value == typeName)
                .ToList();

            var tableGroupBy = typeViews
                .Where(e => e.Element("TableControl") != null)
                .Elements("GroupBy")
                .Select(e => new GroupBy
                    {
                        Label = e.Element("Label")?.Value,
                        PropertyName = e.Element("PropertyName")?.Value,
                        ScriptBlock = e.Element("ScriptBlock")?.Value,
                    })
                .ToList();

            var tableGroupByExpected = expected
                .Where(tuple => (tuple.Item2 & View.Table) != View.None)
                .Select(tuple => tuple.Item1)
                .ToList();

            var comparer = new Comparer<GroupBy>(
                (l, r) =>
                    l.ScriptBlock == r.ScriptBlock
                    && l.PropertyName == r.PropertyName
                    && l.Label == r.Label);

            Assert.Equal(tableGroupByExpected, tableGroupBy, comparer);

            var listGroupBy = typeViews
                .Where(e => e.Element("ListControl") != null)
                .Elements("GroupBy")
                    .Select(e => new GroupBy
                    {
                        Label = e.Element("Label")?.Value,
                        PropertyName = e.Element("PropertyName")?.Value,
                        ScriptBlock = e.Element("ScriptBlock")?.Value,
                    })
                .ToList();

            var listGroupByExpected = expected
                .Where(tuple => (tuple.Item2 & View.List) != View.None)
                .Select(tuple => tuple.Item1)
                .ToList();

            Assert.Equal(listGroupByExpected, listGroupBy, comparer);
        }

        private class Comparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _isEqual;

            public Comparer(Func<T,T,bool> isEqual)
            {
                _isEqual = isEqual;
            }

            public bool Equals(T x, T y)
            {
                var result = _isEqual(x, y);
                return result;
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
