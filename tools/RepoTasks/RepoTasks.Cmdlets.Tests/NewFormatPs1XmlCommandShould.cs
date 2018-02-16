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

        [Fact]
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
                    cmdlet.Parameters.Add("ModulePath", "./Dummy.psd1");

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
                        "RepoTasks.Cmdlets.Models.PsDummyOutput1");

                    TestXml(config,
                        new[] { "LicenseType", "Location" },
                        "RepoTasks.Cmdlets.Models.PsDummyOutput2");
                }
            }
        }

        private static void TestXml(IEnumerable<XElement> config, IEnumerable<string> expectedProps, string typeName)
        {
            var typeViews = config
                .Elements("View")
                .Where(e => e.Element("Name")?.Value == typeName)
                .ToList();

            Assert.Equal(2, typeViews.Count);

            var expectedPropsSorted = expectedProps.OrderBy(i => i).ToList();

            var tableHeaderLabelsQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tabelHeaders in tableControl.Elements("TableHeaders")
                from tabelColumnHeader in tabelHeaders.Elements()
                from label in tabelColumnHeader.Elements("Label")
                select label.Value;

            var headerLabels = tableHeaderLabelsQuery.OrderBy(s => s).ToList();

            Assert.Equal(expectedPropsSorted.Count, headerLabels.Count);
            Assert.Equal(expectedPropsSorted, headerLabels);

            var tableRowEntriesQuery =
                from tableControl in typeViews.Elements("TableControl")
                from tableRowEntries in tableControl.Elements("TableRowEntries")
                from tableRowEntry in tableRowEntries.Elements()
                from tableColumnItems in tableRowEntry.Elements()
                from tableColumnItem in tableColumnItems.Elements()
                from propertyName in tableColumnItem.Elements("PropertyName")
                select propertyName.Value;

            var tableRowPropertyNames = tableRowEntriesQuery.OrderBy(s => s).ToList();

            Assert.Equal(expectedPropsSorted.Count, tableRowPropertyNames.Count);
            Assert.Equal(expectedPropsSorted, tableRowPropertyNames);

            var listEntriesQuery =
                from listControl in typeViews.Elements("ListControl")
                from listEntries in listControl.Elements()
                from listEntry in listEntries.Elements()
                from listItems in listEntry.Elements()
                from listItem in listItems.Elements()
                from propertyName in listItem.Elements("PropertyName")
                select propertyName.Value;

            var listEntriesList = listEntriesQuery.OrderBy(s => s).ToList();

            Assert.Equal(expectedPropsSorted.Count, listEntriesList.Count);
            Assert.Equal(expectedPropsSorted, listEntriesList);
        }
    }
}
