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
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class RestoreDatabaseTests : SMTestBase
    {
        private static System.Management.Automation.PowerShell powershell;

        private static string serverName;

        private bool databasesAlreadyDropped;

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

            // Create atleast two test databases
            NewAzureSqlDatabaseTests.CreateTestDatabasesWithCertAuth(powershell);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            powershell.Streams.ClearStreams();

            if (!databasesAlreadyDropped)
            {
                // Remove the test databases
                NewAzureSqlDatabaseTests.RemoveTestDatabasesWithCertAuth(powershell);
            }

            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void RestoreAzureSqlDatabaseWithDatabaseNameWithCertAuth()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RestoreAzureSqlDatabaseWithDatabaseNameWithCertAuth");
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
                        @"Start-AzureSqlDatabaseRestore " +
                        @"-SourceServerName $serverName " +
                        @"-SourceDatabaseName testdb1 " +
                        @"-TargetDatabaseName testdb1-restored");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsTrue(
                    operation[0].BaseObject is RestoreDatabaseOperation,
                    "Expecting a RestoreDatabaseOperation object");

                var operationObject = (RestoreDatabaseOperation)operation[0].BaseObject;
                Assert.IsTrue(
                    operationObject.RequestID != Guid.Empty,
                    "Expecting a non-empty operation ID");
            }
        }

        [TestMethod]
        public void RestoreAzureSqlDatabaseWithDatabaseObjectWithCertAuth()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RestoreAzureSqlDatabaseWithDatabaseObjectWithCertAuth");
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
                        @"Get-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb1" + " | " +
                        @"Start-AzureSqlDatabaseRestore " +
                        @"-TargetDatabaseName testdb1-restored");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsTrue(
                    operation[0].BaseObject is RestoreDatabaseOperation,
                    "Expecting a RestoreDatabaseOperation object");

                var operationObject = (RestoreDatabaseOperation)operation[0].BaseObject;
                Assert.IsTrue(
                    operationObject.RequestID != Guid.Empty,
                    "Expecting a non-empty operation ID");
            }
        }

        [TestMethod]
        public void RestoreAzureSqlDatabaseWithRestorableDroppedDatabaseNameWithCertAuth()
        {
            DropTestDatabases();

            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RestoreAzureSqlDatabaseWithRestorableDroppedDatabaseNameWithCertAuth");
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
                Collection<PSObject> droppedDatabase, operation;
                using (new MockHttpServer(exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    droppedDatabase = powershell.InvokeBatchScript(
                        @"$(Get-AzureSqlDatabase -ServerName $serverName -RestorableDropped)[0]");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                var droppedDatabaseObject = (RestorableDroppedDatabase)droppedDatabase[0].BaseObject;
                var restorePoint = droppedDatabaseObject.DeletionDate - TimeSpan.FromMinutes(1);

                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    operation = powershell.InvokeBatchScript(
                        @"Start-AzureSqlDatabaseRestore " +
                        @"-SourceServerName $serverName " +
                        @"-RestorableDropped " +
                        @"-SourceDatabaseName '" + droppedDatabaseObject.Name + "' " +
                        @"-SourceDatabaseDeletionDate '" + droppedDatabaseObject.DeletionDate.ToString("O") + "' " +
                        @"-TargetDatabaseName testdb1-restored " +
                        @"-PointInTime '" + restorePoint.ToString("O") + "'");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsTrue(
                    operation[0].BaseObject is RestoreDatabaseOperation,
                    "Expecting a RestoreDatabaseOperation object");

                var operationObject = (RestoreDatabaseOperation)operation[0].BaseObject;
                Assert.IsTrue(
                    operationObject.RequestID != Guid.Empty,
                    "Expecting a non-empty operation ID");

                Assert.IsTrue(operationObject.SourceDatabaseName == droppedDatabaseObject.Name);
                Assert.IsTrue(operationObject.SourceDatabaseDeletionDate == droppedDatabaseObject.DeletionDate);
            }
        }

        [TestMethod]
        public void RestoreAzureSqlDatabaseWithRestorableDroppedDatabaseObjectWithCertAuth()
        {
            DropTestDatabases();

            var deletionDate = DateTime.UtcNow;
            var restorePoint = deletionDate - TimeSpan.FromMinutes(1);

            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTests.RestoreAzureSqlDatabaseWithRestorableDroppedDatabaseObjectWithCertAuth");
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
                Collection<PSObject> droppedDatabase, operation;
                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    droppedDatabase = powershell.InvokeBatchScript(
                        @"$database = $(Get-AzureSqlDatabase -ServerName $serverName -RestorableDropped)[0];" +
                        @"$database");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                var droppedDatabaseObject = (RestorableDroppedDatabase)droppedDatabase[0].BaseObject;

                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    operation = powershell.InvokeBatchScript(
                        @"$database | Start-AzureSqlDatabaseRestore " +
                        @"-TargetDatabaseName testdb1-restored");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting one operation object
                Assert.AreEqual(1, operation.Count, "Expecting one operation object");

                Assert.IsTrue(
                    operation[0].BaseObject is RestoreDatabaseOperation,
                    "Expecting a RestoreDatabaseOperation object");

                var operationObject = (RestoreDatabaseOperation)operation[0].BaseObject;
                Assert.IsTrue(
                    operationObject.RequestID != Guid.Empty,
                    "Expecting a non-empty operation ID");

                Assert.IsTrue(operationObject.SourceDatabaseName == droppedDatabaseObject.Name);
                Assert.IsTrue(operationObject.SourceDatabaseDeletionDate == droppedDatabaseObject.DeletionDate);
            }
        }

        private void DropTestDatabases()
        {
            // Remove the test databases
            NewAzureSqlDatabaseTests.RemoveTestDatabasesWithCertAuth(powershell);

            databasesAlreadyDropped = true;
        }
    }
}
