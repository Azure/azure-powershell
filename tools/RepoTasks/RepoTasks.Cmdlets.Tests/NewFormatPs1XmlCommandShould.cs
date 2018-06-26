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



namespace RepoTasks.Cmdlets.Tests
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using Xunit;
    using System.IO;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using RemoteWorker;

    public class NewFormatPs1XmlCommandShould
    {
        private const string CmdletName = "New-FormatPs1Xml";
        private const string ExpectedAssemblyName = "RepoTasks.CmdletsForTest";

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
                        new[] { "RequestId", "StatusCode", "Id", "Name", "Type", "PsDummyOutput2" },
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
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "Id", View.List, null, 0, null, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "RequestId", View.Both, null, null, 1, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "Name", View.Both, null, 16, null, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "Type", View.Both, "PsDummyOutput1 Type", null, 3, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "$_.PsDummyOutput2.Name", View.Both, "PsDummyOutput2 Name", null, null, true),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.ScriptBlock, "$_.PsDummyOutput2.Location", View.Both, "PsDummyOutput2 Location", null, 0, false),
                                Tuple.Create<EntryType, string, View, string, uint?, uint?, bool>(EntryType.PropertyName, "StatusCode", View.None, null, null, null, false),
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
            public IList<string> ListPropNameValues { get; set; }
            public IList<string> ListScriptBlockValues { get; set; }
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
                from propertyName in listEntriesRes.Elements("PropertyName")
                select propertyName.Value;

            var listEntrieScriptBlocksQuery =
                from scriptBlock in listEntriesRes.Elements("ScriptBlock")
                select scriptBlock.Value;

            return new XmlData()
            {
                TableHeaders = tableHeadersQuery.ToList(),
                TableRowPropNameValues = tableRowEntriesPropNamesQuery.ToList(),
                TableRowScriptBlockValues = tableRowEntriesScriptBlocksQuery.ToList(),
                ListPropNameValues = listEntriesPropNamesQuery.ToList(),
                ListScriptBlockValues = listEntrieScriptBlocksQuery.ToList(),
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

            var listEntriesList = xmlData.ListPropNameValues.OrderBy(i => i).ToList();
            Assert.Equal(expectedPropsOrdered.Count, listEntriesList.Count);
            Assert.Equal(expectedPropsOrdered, listEntriesList);
        }

        private static void TestXmlMarked(IList<XElement> config, IEnumerable<Tuple<EntryType, string, View, string, uint?, uint?, bool>> expectedProps, string typeName)
        {
            var xmlData = GetDataFromXml(config, typeName);
            var expectedPropsOrdered = expectedProps.ToList();

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

            var comparer = new Comparer<TableHeaderFromXml>(
                (l, r) => l.Label == r.Label && l.Width == r.Width);

            Assert.Equal(expectedTableHeaders.Count, tableHeaders.Count);
            Assert.Equal(expectedTableHeaders.OrderBy(i=>i.Label), tableHeaders.OrderBy(i=>i.Label), comparer);

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

            var listPropNameEntries = xmlData.ListPropNameValues;
            var expectedListPropNameValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.PropertyName)
                .Where(tuple => (tuple.Item3 & View.List) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => tuple.Item2)
                .ToList();

            Assert.Equal(expectedListPropNameValues.Count, listPropNameEntries.Count);
            Assert.Equal(expectedListPropNameValues.OrderBy(i=>i), listPropNameEntries.OrderBy(i=>i));

            var listScriptBlocksEntries = xmlData.ListScriptBlockValues;
            var expectedListScriptBlocksValues = expectedPropsOrdered
                .Where(tuple => tuple.Item1 == EntryType.ScriptBlock)
                .Where(tuple => (tuple.Item3 & View.List) != View.None)
                .Where(tuple => !tuple.Item7)
                .Select(tuple => tuple.Item2)
                .ToList();

            Assert.Equal(expectedListScriptBlocksValues.Count, listScriptBlocksEntries.Count);
            Assert.Equal(expectedListScriptBlocksValues, listScriptBlocksEntries);

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

            var expectedExcludedValues = expectedPropsOrdered
                .Where(tuple => tuple.Item3 == View.None)
                .Select(tuple => tuple.Item2)
                .ToList();

            foreach (var expectedExcludedValue in expectedExcludedValues)
            {
                Assert.DoesNotContain(expectedExcludedValue, listPropNameEntries);
                Assert.DoesNotContain(expectedExcludedValue, listScriptBlocksEntries);
                Assert.DoesNotContain(expectedExcludedValue, tableHeaders.Select(h=>h.Label));
                Assert.DoesNotContain(expectedExcludedValue, tableRowPropNameValues);
                Assert.DoesNotContain(expectedExcludedValue, tableRowScriptBlockValues);
            }
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
