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
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class GetAzureSqlDatabaseServiceObjectiveTests : SMTestBase
    {
        [TestCleanup]
        public void CleanupTest()
        {
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void GetAzureSqlDatabaseServiceObjectiveWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetAzureSqlServiceObjectiveWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        switch (expected.Index)
                        {
                            // Request 0-6: Retrieving all (6) ServiceObjectives and DimensionSettings
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            // Request 7-8: Retrieving Reserved P1 ServiceObjectives and DimensionSettings
                            case 7:
                            case 8:
                                DatabaseTestHelper.ValidateHeadersForODataRequest(
                                    expected.RequestInfo,
                                    actual);
                                break;
                            default:
                                Assert.Fail("No more requests expected.");
                                break;
                        }
                    });
                testSession.ResponseModifier =
                    new Action<HttpMessage>(
                        (message) =>
                        {
                            DatabaseTestHelper.FixODataResponseUri(
                                message.ResponseInfo,
                                testSession.ServiceBaseUri,
                                MockHttpServer.DefaultServerPrefixUri);
                        });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    Collection<PSObject> objectives, objective1;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        objectives = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServiceObjective " +
                            @"-Context $context");

                        objective1 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServiceObjective " +
                            @"-Context $context " +
                            @"-ServiceObjectiveName ""P1""");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    Assert.AreEqual(6, objectives.Count, "Expecting 6 Objective objects");

                    Assert.IsTrue(
                        objective1.Single().BaseObject is Services.Server.ServiceObjective,
                        "Expecting a ServiceObjective object");
                    Services.Server.ServiceObjective objective1Obj =
                        (Services.Server.ServiceObjective)objective1.Single().BaseObject;
                    Assert.AreEqual("P1", objective1Obj.Name, "Expected objective name to be 'Reserved P1'");
                }
            }
        }
    }
}
