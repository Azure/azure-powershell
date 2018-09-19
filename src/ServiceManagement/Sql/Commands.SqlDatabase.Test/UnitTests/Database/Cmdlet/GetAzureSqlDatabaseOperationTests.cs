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
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class GetAzureSqlDatabaseOperationTests : SMTestBase
    {
        [TestCleanup]
        public void CleanupTest()
        {
            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        /// <summary>
        /// Create a database on the given context then get the operations on that database.
        /// </summary>
        /// <param name="powershell">The powershell instance containing the context.</param>
        /// <param name="contextVariable">The variable name that holds the server context.</param>
        [TestMethod]
        [Ignore]
        public void GetAzureSqlDatabaseOperationWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.Common.GetAzureSqlDatabaseOperationWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                        (expected, actual) =>
                        {
                            Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                            Assert.IsNotNull(actual.UserAgent);
                            switch (expected.Index)
                            {
                                // Request 0-7: Create and Query $testdb                                                                
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                // Request 8: Delete $testdb
                                case 8:
                                // Request 9-11: Query Database Operations                                
                                case 9:
                                case 10:
                                case 11:                                
                                    DatabaseTestHelper.ValidateHeadersForODataRequest(
                                    expected.RequestInfo,
                                    actual);
                                    break;
                                default:
                                    Assert.Fail("No more requests expected.");
                                    break;
                            }
                        });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // There is a known issue about the Get-AzureSqlDatabaseOperation that it returns all
                    // operations which has the required database name no matter it's been deleted and recreated.
                    // So when run it against the mock session, please use the hard coded testsDBName.
                    // Run against onebox, please use the one with NewGuid(). 
                    // This unit test should be updated once that behavior get changed which was already been 
                    // created as a task.

                    // string testsDBName = string.Format("getAzureSqlDatabaseOperationTestsDB_{0}",
                    //     Guid.NewGuid().ToString());
                    string testsDBName = "getAzureSqlDatabaseOperationTestsDB_08ebd7c9-bfb7-426a-9e2f-9921999567e1";
                    Collection<PSObject> database, operationsByName, operationsByDatabase, operationsById;
                    using (new MockHttpServer(
                            exceptionManager,
                            MockHttpServer.DefaultServerPrefixUri,
                            testSession))
                    {
                        database = powershell.InvokeBatchScript(
                            string.Format(
                                @"$testdb = New-AzureSqlDatabase " +
                                @"-Context $context " +
                                @"-DatabaseName {0} " +
                                @"-Force", testsDBName),
                            @"$testdb");

                        powershell.InvokeBatchScript(
                            string.Format(
                                @"Remove-AzureSqlDatabase " +
                                @"-Context $context " +
                                @"-DatabaseName {0} " +
                                @"-Force", testsDBName));

                        operationsByName = powershell.InvokeBatchScript(
                            string.Format(
                                @"$operations = Get-AzureSqlDatabaseOperation " +
                                @"-ConnectionContext $context " +
                                @"-DatabaseName {0}",
                                testsDBName),
                            @"$operations");

                        operationsByDatabase = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseOperation " +
                            @"-ConnectionContext $context " +
                            @"-Database $testdb");

                        operationsById = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseOperation " +
                            @"-ConnectionContext $context " +
                            @"-OperationGuid $operations[0].Id"
                            );
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    VerifyGetOperationsResult(testsDBName, operationsByName);
                    VerifyGetOperationsResult(testsDBName, operationsByDatabase);
                    // Update this verification once Task 1615375:Adding Drop record in dm_operation_status resolved
                    VerifyGetOperationsResult(testsDBName, operationsById);
                }
            }
        }

        private static void VerifyGetOperationsResult(string testsDBName, Collection<PSObject> operationsByName)
        {
            DatabaseOperation[] operations = operationsByName.Select(r => r.BaseObject as DatabaseOperation).ToArray(); ;
            // Task 1615375:Adding Drop record in dm_operation_status
            // There is a known issue that Drop record is not included in the DatabaseOperation log
            // Once that's done We should change the assert to 
            // Assert.AreEqual(2, operations.Length, "Expecting one DatabaseOperation");
            Assert.AreEqual(1, operations.Length, "Expecting one DatabaseOperation.");
            Assert.IsNotNull(operations[0], "Expecting a DatabaseOperation object.");
            Assert.AreEqual(testsDBName, operations[0].DatabaseName, "Database name does NOT match.");
            Assert.AreEqual("CREATE DATABASE", operations[0].Name, "Operation name does NOT match.");
            Assert.AreEqual(100, operations[0].PercentComplete, "Operation should be 100 percent complete.");
            Assert.AreEqual("COMPLETED", operations[0].State, "Operation state should be COMPLETED.");
        }        
    }
}