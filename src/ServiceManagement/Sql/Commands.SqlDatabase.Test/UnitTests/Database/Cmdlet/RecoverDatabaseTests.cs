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

using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class RecoverDatabaseTests : SMTestBase
    {
        private static System.Management.Automation.PowerShell powershell;

        private static string serverName;

        /// <summary>
        /// Initialize the necessary environment for the tests.
        /// </summary>
        [TestInitialize]
        public void SetupTest()
        {
            powershell = System.Management.Automation.PowerShell.Create();

            MockHttpServer.SetupCertificates();

            UnitTestHelper.SetupUnitTestSubscription(powershell);

            serverName = SqlDatabaseTestSettings.Instance.ServerName;
            powershell.Runspace.SessionStateProxy.SetVariable("serverName", serverName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            powershell.Streams.ClearStreams();

            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void RecoverAzureSqlDatabaseWithDatabaseName()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RecoverAzureSqlDatabaseWithDatabaseName");
            ServerTestHelper.SetDefaultTestSessionSettings(testSession);

            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsTrue(
                            actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                            "Missing proper UserAgent string.");
                    });

            using (var exceptionManager = new AsyncExceptionManager())
            {
                Collection<PSObject> operation;
                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    operation = powershell.InvokeBatchScript(
                        @"Start-AzureSqlDatabaseRecovery " +
                        @"-SourceServerName $serverName " +
                        @"-SourceDatabaseName testdb1 " +
                        @"-TargetDatabaseName testdb1-restored");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsInstanceOfType(
                    operation[0].BaseObject, typeof(RecoverDatabaseOperation),
                    "Expecting a RecoverDatabaseOperation object");

                var operationObject = (RecoverDatabaseOperation)operation[0].BaseObject;
                Guid operationId;
                Assert.IsTrue(
                    Guid.TryParse(operationObject.Id, out operationId),
                    "Expecting a operation ID that's a GUID");
                Assert.AreNotEqual(
                    Guid.Empty, operationId,
                    "Expecting an operation ID that's not an empty GUID");
                Assert.AreEqual(
                    operationObject.SourceDatabaseName, "testdb1",
                    "Source database name mismatch");
                Assert.AreEqual(
                    operationObject.TargetServerName, serverName,
                    "Target server name mismatch");
                Assert.AreEqual(
                    operationObject.TargetDatabaseName, "testdb1-restored",
                    "Target database name mismatch");
            }
        }

        [TestMethod]
        public void RecoverAzureSqlDatabaseWithDatabaseObject()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RecoverAzureSqlDatabaseWithDatabaseObject");
            ServerTestHelper.SetDefaultTestSessionSettings(testSession);
            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsTrue(
                            actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                            "Missing proper UserAgent string.");
                    });

            using (var exceptionManager = new AsyncExceptionManager())
            {
                Collection<PSObject> operation;
                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    operation = powershell.InvokeBatchScript(
                        @"Get-AzureSqlRecoverableDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb1" + " | " +
                        @"Start-AzureSqlDatabaseRecovery " +
                        @"-TargetDatabaseName testdb1-restored");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsInstanceOfType(
                    operation[0].BaseObject, typeof(RecoverDatabaseOperation),
                    "Expecting a RecoverDatabaseOperation object");

                var operationObject = (RecoverDatabaseOperation)operation[0].BaseObject;
                Guid operationId;
                Assert.IsTrue(
                    Guid.TryParse(operationObject.Id, out operationId),
                    "Expecting a operation ID that's a GUID");
                Assert.AreNotEqual(
                    Guid.Empty, operationId,
                    "Expecting an operation ID that's not an empty GUID");
                Assert.AreEqual(
                    operationObject.SourceDatabaseName, "testdb1",
                    "Source database name mismatch");
                Assert.AreEqual(
                    operationObject.TargetServerName, serverName,
                    "Target server name mismatch");
                Assert.AreEqual(
                    operationObject.TargetDatabaseName, "testdb1-restored",
                    "Target database name mismatch");
            }
        }
    }
}
