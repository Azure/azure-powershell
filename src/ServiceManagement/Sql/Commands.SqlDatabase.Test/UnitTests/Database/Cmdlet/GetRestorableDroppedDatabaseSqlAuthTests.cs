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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class GetRestorableDroppedDatabaseSqlAuthTests : SMTestBase
    {
        private const string deletionDateStringFormat = "yyyy-MM-ddTHH:mm:ss.FFFZ";

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            // Create atleast two test databases
            NewAzureSqlDatabaseTests.CreateTestDatabasesWithSqlAuth();

            // Remove the test databases
            NewAzureSqlDatabaseTests.RemoveTestDatabasesWithSqlAuth();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void GetRestorableDroppedDatabaseWithSqlAuth()
        {
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(powershell, "$context");

                var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetRestorableDroppedDatabaseWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                        (expected, actual) =>
                        {
                            Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                            Assert.IsNotNull(actual.UserAgent);
                            if (expected.Index < 3)
                            {
                                DatabaseTestHelper.ValidateHeadersForODataRequest(expected.RequestInfo, actual);
                            }
                            else
                            {
                                Assert.Fail("No more requests expected.");
                            }
                        });

                using (var exceptionManager = new AsyncExceptionManager())
                {
                    Collection<PSObject> databases, database1, database2;
                    using (new MockHttpServer(exceptionManager, MockHttpServer.DefaultServerPrefixUri, testSession))
                    {
                        databases = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    // Expecting testdb1, testdb2, possibly dropped databases from previous runs
                    Assert.IsTrue(
                        databases.Count >= 2,
                        "Expecting at-least two RestorableDroppedDatabase objects");

                    Assert.IsTrue(
                        databases[0].BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");

                    Assert.IsTrue(
                        databases[1].BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");

                    var database1Object = (RestorableDroppedDatabase)databases[0].BaseObject;
                    var database1DeletionDate = database1Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                    var database2Object = (RestorableDroppedDatabase)databases[1].BaseObject;
                    var database2DeletionDate = database2Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                    using (new MockHttpServer(
                        exceptionManager, MockHttpServer.DefaultServerPrefixUri, testSession))
                    {
                        database1 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context " +
                            @"-DatabaseName " + database1Object.Name + @" " +
                            @"-DatabaseDeletionDate " + database1DeletionDate);
                        database2 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context " +
                            @"-DatabaseName " + database2Object.Name + @" " +
                            @"-DatabaseDeletionDate " + database2DeletionDate);
                    }

                    Assert.IsTrue(
                        database1.Single().BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");
                    var refreshedDatabase1Object = (RestorableDroppedDatabase)database1.Single().BaseObject;
                    Assert.AreEqual(
                        database1Object.Name, refreshedDatabase1Object.Name,
                        "Expected db name to be " + database1Object.Name);

                    Assert.IsTrue(
                        database2.Single().BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");
                    var refreshedDatabase2Object = (RestorableDroppedDatabase)database2.Single().BaseObject;
                    Assert.AreEqual(
                        database2Object.Name, refreshedDatabase2Object.Name,
                        "Expected db name to be " + database2Object.Name);
                    Assert.AreEqual(
                        database2Object.Edition, refreshedDatabase2Object.Edition,
                        "Expected edition to be " + database2Object.Edition);
                    Assert.AreEqual(
                        database2Object.MaxSizeBytes, refreshedDatabase2Object.MaxSizeBytes,
                        "Expected max size to be " + database2Object.MaxSizeBytes);
                }
            }
        }

        [TestMethod]
        public void GetRestorableDroppedDatabaseWithSqlAuthByPipe()
        {
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(powershell, "$context");

                var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetRestorableDroppedDatabaseWithSqlAuthByPipe");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                        (expected, actual) =>
                        {
                            Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                            Assert.IsNotNull(actual.UserAgent);
                            if (expected.Index < 5)
                            {
                                DatabaseTestHelper.ValidateHeadersForODataRequest(expected.RequestInfo, actual);
                            }
                            else
                            {
                                Assert.Fail("No more requests expected.");
                            }
                        });

                using (var exceptionManager = new AsyncExceptionManager())
                {
                    Collection<PSObject> databases, database1, database2;
                    using (new MockHttpServer(
                        exceptionManager, MockHttpServer.DefaultServerPrefixUri, testSession))
                    {
                        databases = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    // Expecting testdb1, testdb2, possibly dropped databases from previous runs
                    Assert.IsTrue(
                        databases.Count >= 2,
                        "Expecting at-least two RestorableDroppedDatabase objects");

                    Assert.IsTrue(
                        databases[0].BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");

                    Assert.IsTrue(
                        databases[1].BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");

                    var database1Object = (RestorableDroppedDatabase)databases[0].BaseObject;
                    var database1DeletionDate = database1Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                    var database2Object = (RestorableDroppedDatabase)databases[1].BaseObject;
                    var database2DeletionDate = database2Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                    using (new MockHttpServer(
                        exceptionManager, MockHttpServer.DefaultServerPrefixUri, testSession))
                    {
                        powershell.InvokeBatchScript(
                            @"$testdb1 = Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context " +
                            @"-DatabaseName " + database1Object.Name + @" " +
                            @"-DatabaseDeletionDate " + database1DeletionDate);

                        powershell.InvokeBatchScript(
                            @"$testdb2 = Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context " +
                            @"-DatabaseName " + database2Object.Name + @" " +
                            @"-DatabaseDeletionDate " + database2DeletionDate);

                        database1 = powershell.InvokeBatchScript(
                            @"$testdb1 | Get-AzureSqlDatabase");

                        database2 = powershell.InvokeBatchScript(
                            @"$testdb2 | Get-AzureSqlDatabase");
                    }

                    Assert.IsTrue(
                        database1.Single().BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");
                    var refreshedDatabase1Object = (RestorableDroppedDatabase)database1.Single().BaseObject;
                    Assert.AreEqual(
                        database1Object.Name, refreshedDatabase1Object.Name,
                        "Expected db name to be " + database1Object.Name);

                    Assert.IsTrue(
                        database2.Single().BaseObject is RestorableDroppedDatabase,
                        "Expecting a RestorableDroppedDatabase object");
                    var refreshedDatabase2Object = (RestorableDroppedDatabase)database2.Single().BaseObject;
                    Assert.AreEqual(
                        database2Object.Name, refreshedDatabase2Object.Name,
                        "Expected db name to be " + database2Object.Name);
                    Assert.AreEqual(
                        database2Object.Edition, refreshedDatabase2Object.Edition,
                        "Expected edition to be " + database2Object.Edition);
                    Assert.AreEqual(
                        database2Object.MaxSizeBytes, refreshedDatabase2Object.MaxSizeBytes,
                        "Expected max size to be " + database2Object.MaxSizeBytes);
                }
            }
        }

        [TestMethod]
        public void GetRestorableDroppedDatabaseWithSqlAuthNonExistentDb()
        {
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(powershell, "$context");

                var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetRestorableDroppedDatabaseWithSqlAuthNonExistentDb");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                        (expected, actual) =>
                        {
                            Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                            Assert.IsNotNull(actual.UserAgent);
                            if (expected.Index < 1)
                            {
                                DatabaseTestHelper.ValidateHeadersForODataRequest(expected.RequestInfo, actual);
                            }
                            else
                            {
                                Assert.Fail("No more requests expected.");
                            }
                        });

                using (var exceptionManager = new AsyncExceptionManager())
                {
                    using (new MockHttpServer(
                        exceptionManager, MockHttpServer.DefaultServerPrefixUri, testSession))
                    {
                        powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase -RestorableDropped " +
                            @"-Context $context " +
                            @"-DatabaseName testdbnonexistent " +
                            @"-DatabaseDeletionDate '10/01/2013 12:00:00 AM'");
                    }

                    Assert.AreEqual(
                        1, powershell.Streams.Error.Count,
                        "Expecting errors");
                    Assert.AreEqual(
                        2, powershell.Streams.Warning.Count,
                        "Expecting tracing IDs");
                    Assert.AreEqual(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "Database '{0}' with deletion date '{1}' not found.",
                            testSession.SessionProperties["Servername"] + ".testdbnonexistent",
                            new DateTime(2013, 10, 01, 0, 0, 0, DateTimeKind.Utc)),
                        powershell.Streams.Error.First().Exception.Message,
                        "Unexpected error message");
                    Assert.IsTrue(
                        powershell.Streams.Warning.Any(w => w.Message.StartsWith("Client Session Id")),
                        "Expecting Client Session Id");
                    Assert.IsTrue(
                        powershell.Streams.Warning.Any(w => w.Message.StartsWith("Client Request Id")),
                        "Expecting Client Request Id");
                }
            }
        }
    }
}
