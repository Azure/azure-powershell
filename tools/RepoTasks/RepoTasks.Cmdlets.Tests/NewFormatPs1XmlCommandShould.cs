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


using System.Reflection;

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
                        new[] { "RequestId", "StatusCode", "Id", "Name", "Type" },
                        $"{ExpectedAssemblyName}.Models.PsDummyOutput1");

                    TestXml(config,
                        new[] { "LicenseType", "Location" },
                        $"{ExpectedAssemblyName}.Models.PsDummyOutput2");
                }
            }
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

                    string filepath = null;
                    try
                    {
                        filepath = results.First();
                        Assert.NotNull(filepath);
                        Assert.True(File.Exists(filepath));

                        var xelement = XElement.Load(filepath);
                        var config = xelement.Elements().ToList();

                        TestXmlMaked(config,
                            // prop name, target, label
                            new List<Tuple<string, View, string>>
                            {
                                new Tuple<string, View, string>("RequestId", View.None, null),
                                new Tuple<string, View, string>("StatusCode", View.None, null),
                                new Tuple<string, View, string>("Id", View.List, null),
                                new Tuple<string, View, string>("Name", View.Both, null),
                                new Tuple<string, View, string>("Type", View.Table, "PsDummyOutput1 Type"),
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
            public IList<string> TableHeaderLabels { get; set; }
            public IList<string> TableRowValues { get; set; }
            public IList<string> ListValues { get; set; }
        }

        private static XmlData GetDataFromXml(IEnumerable<XElement> config, string typeName)
        {
            var typeViews = config
               .Elements("View")
               .Where(e => e.Element("Name")?.Value == typeName)
               .ToList();

            Assert.Equal(2, typeViews.Count);

            var tableHeaderLabelsQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tabelHeaders in tableControl.Elements("TableHeaders")
                from tabelColumnHeader in tabelHeaders.Elements()
                from label in tabelColumnHeader.Elements("Label")
                select label.Value;

            var tableRowEntriesQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tableRowEntries in tableControl.Elements("TableRowEntries")
                from tableRowEntry in tableRowEntries.Elements()
                from tableColumnItems in tableRowEntry.Elements()
                from tableColumnItem in tableColumnItems.Elements()
                from propertyName in tableColumnItem.Elements("PropertyName")
                select propertyName.Value;

            var listEntriesQuery =
                from listControl in typeViews.Elements("ListControl")
                from listEntries in listControl.Elements()
                from listEntry in listEntries.Elements()
                from listItems in listEntry.Elements()
                from listItem in listItems.Elements()
                from propertyName in listItem.Elements("PropertyName")
                select propertyName.Value;

            return new XmlData()
            {
                TableHeaderLabels = tableHeaderLabelsQuery.OrderBy(s => s).ToList(),
                TableRowValues = tableRowEntriesQuery.OrderBy(s => s).ToList(),
                ListValues = listEntriesQuery.OrderBy(s => s).ToList(),
            };
        }

        private static void TestXml(IEnumerable<XElement> config, IEnumerable<string> expectedProps, string typeName)
        {
            var xmlData = GetDataFromXml(config, typeName);
            var expectedPropsSorted = expectedProps.OrderBy(i => i).ToList();

            var headerLabels = xmlData.TableHeaderLabels;
            Assert.Equal(expectedPropsSorted.Count, headerLabels.Count);
            Assert.Equal(expectedPropsSorted, headerLabels);

            var tableRowPropertyNames = xmlData.TableRowValues;
            Assert.Equal(expectedPropsSorted.Count, tableRowPropertyNames.Count);
            Assert.Equal(expectedPropsSorted, tableRowPropertyNames);

            var listEntriesList = xmlData.ListValues;
            Assert.Equal(expectedPropsSorted.Count, listEntriesList.Count);
            Assert.Equal(expectedPropsSorted, listEntriesList);
        }

        [Flags]
        private enum View
        {
            None = 0,
            Table,
            List,
            Both,
        }

        private static void TestXmlMaked(IEnumerable<XElement> config, IEnumerable<Tuple<string, View, string>> expectedProps, string typeName)
        {
            var xmlData = GetDataFromXml(config, typeName);
            var expectedPropsSorted = expectedProps.OrderBy(tuple => tuple.Item1).ToList();

            var tableHeaderLabels = xmlData.TableHeaderLabels;
            var expectedTableHeaderLabels = expectedPropsSorted
                .Where(tuple => (tuple.Item2 & View.Table) != View.None)
                .Select(tuple => tuple.Item3 ?? tuple.Item1)
                .ToList();

            Assert.Equal(expectedTableHeaderLabels.Count, tableHeaderLabels.Count);
            Assert.Equal(expectedTableHeaderLabels, tableHeaderLabels);

            var tableRowValues = xmlData.TableRowValues;
            var expectedTableValues = expectedPropsSorted
                .Where(tuple => (tuple.Item2 & View.Table) != View.None)
                .Select(tuple => tuple.Item1)
                .ToList();
            Assert.Equal(expectedTableValues.Count, tableRowValues.Count);
            Assert.Equal(expectedTableValues, tableRowValues);

            var listEntries = xmlData.ListValues;
            var expectedListValues = expectedPropsSorted
                .Where(tuple => (tuple.Item2 & View.List) != View.None)
                .Select(tuple => tuple.Item1)
                .ToList();
            Assert.Equal(expectedListValues.Count, listEntries.Count);
            Assert.Equal(expectedListValues, listEntries);

            var expectedExcludedValues = expectedPropsSorted
                .Where(tuple => tuple.Item2 == View.None)
                .Select(tuple => tuple.Item1)
                .ToList();
            foreach (var expectedExcludedValue in expectedExcludedValues)
            {
                Assert.DoesNotContain(expectedExcludedValue, listEntries);
                Assert.DoesNotContain(expectedExcludedValue, tableHeaderLabels);
                Assert.DoesNotContain(expectedExcludedValue, tableRowValues);
            }
        }
    }
}
