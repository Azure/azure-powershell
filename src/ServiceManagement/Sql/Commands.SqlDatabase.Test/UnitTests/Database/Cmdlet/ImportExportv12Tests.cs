// ----------------------------------------------------------------------------------
//
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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class ImportExportv12Tests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void ImportExportAzureSqlDatabaseTestv12()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Setup the subscription used for the test
                AzureSubscription subscription =
                    UnitTestHelper.SetupUnitTestSubscription(powershell);

                // Set the necessary session variables
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "serverName",
                    SqlDatabaseTestSettings.Instance.ServerName);
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "sourceDB",
                    SqlDatabaseTestSettings.Instance.SourceDatabaseName);
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "targetDB",
                    SqlDatabaseTestSettings.Instance.TargetDatabaseName);
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "credential",
                    new PSCredential(
                        SqlDatabaseTestSettings.Instance.UserName,
                        SqlDatabaseTestSettings.Instance.SecurePassword));
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "storageAccountName",
                    SqlDatabaseTestSettings.Instance.StorageName);
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "storageAccountKey",
                    SqlDatabaseTestSettings.Instance.AccessKey);
                powershell.Runspace.SessionStateProxy.SetVariable(
                    "storageContainerName",
                    SqlDatabaseTestSettings.Instance.ContainerName);

                // Create a new server
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.ImportExportAzureSqlDatabaseTestsv12");
                ServerTestHelper.SetDefaultTestSessionSettings(testSession);

                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        string expectedRequestText = RequestTextToString(expected.RequestInfo);
                        string actualRequestText = RequestTextToString(actual);

                        // When checking out from GitHub, different new line setting may lead to different char \r\n or \n
                        // Replace them with String.Empty before comparison
                        Assert.AreEqual(
                            Regex.Replace(expectedRequestText, @"\s+", String.Empty),
                            Regex.Replace(actualRequestText, @"\s+", String.Empty));
                        Assert.IsTrue(
                            actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                            "Missing proper UserAgent string.");
                    });

                PSObject storageContext = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureStorageContext" +
                            @" -StorageAccountName $storageAccountName" +
                            @" -StorageAccountKey $storageAccountKey");
                    }).FirstOrDefault();

                // Tell the sql auth factory to create a v12 context (skip checking sql version using select query).
                //
                SqlAuthContextFactory.sqlVersion = SqlAuthContextFactory.SqlVersion.v12;

                Collection<PSObject> databaseContext = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable(
                            "manageUrl",
                            MockHttpServer.DefaultServerPrefixUri.AbsoluteUri);
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabaseServerContext" +
                            @" -ServerName $serverName" +
                            @" -ManageUrl $manageUrl" +
                            @" -Credential $credential");
                    });

                Collection<PSObject> startExportResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("storageContext", storageContext);
                        powershell.Runspace.SessionStateProxy.SetVariable(
                            "databaseContext",
                            databaseContext.FirstOrDefault());
                        return powershell.InvokeBatchScript(
                            @"Start-AzureSqlDatabaseExport" +
                            @" -SqlConnectionContext $databaseContext" +
                            @" -DatabaseName $sourceDB" +
                            @" -StorageContext $storageContext" +
                            @" -StorageContainerName $storageContainerName" +
                            @" -BlobName backup1");
                    });

                // Wait here for operation to finish

                Collection<PSObject> getExportStatusResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable(
                            "exportResult",
                            startExportResult.FirstOrDefault());
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseImportExportStatus" +
                            @" -ServerName $serverName" +
                            @" -RequestId $exportResult.RequestGuid" +
                            @" -Username $exportResult.SqlCredentials.UserName" +
                            @" -Password $exportResult.SqlCredentials.Password");
                    });

                Collection<PSObject> startImportResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Start-AzureSqlDatabaseImport" +
                            @" -SqlConnectionContext $databaseContext" +
                            @" -DatabaseName $targetDB" +
                            @" -Edition Business" +
                            @" -DatabaseMaxSize 10" +
                            @" -StorageContext $storageContext" +
                            @" -StorageContainerName $storageContainerName" +
                            @" -BlobName backup1");
                    });

                // Wait here for import to finish

                Collection<PSObject> getImportStatusResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable(
                            "importResult",
                            startImportResult.FirstOrDefault());
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseImportExportStatus" +
                            @" -ServerName $serverName" +
                            @" -RequestId $importResult.RequestGuid" +
                            @" -Username $importResult.SqlCredentials.UserName" +
                            @" -Password $importResult.SqlCredentials.Password");
                    });

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Unexpected Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Unexpected Warnings during run!");
            }
        }

        /// <summary>
        /// Converts http request message to string, replacing NULL with string.Empty
        /// </summary>
        /// <param name="request">The request to get the message from</param>
        /// <returns>The request message as a non-null string</returns>
        private static string RequestTextToString(HttpMessage.Request request)
        {
            return request.RequestText == null ? String.Empty : request.RequestText;
        }
    }
}
