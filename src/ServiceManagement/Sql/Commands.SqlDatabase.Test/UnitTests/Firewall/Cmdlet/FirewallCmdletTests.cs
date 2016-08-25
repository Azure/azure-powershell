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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Firewall.Cmdlet
{
    [TestClass]
    public class FirewallCmdletTests : SMTestBase
    {
        [TestCleanup]
        public void CleanupTest()
        {
            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void AzureSqlDatabaseServerFirewallTests()
        {
            // This test uses the https endpoint, setup the certificates.
            MockHttpServer.SetupCertificates();
            
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                // Setup the subscription used for the test
                AzureSubscription subscription =
                    UnitTestHelper.SetupUnitTestSubscription(powershell);

                powershell.Runspace.SessionStateProxy.SetVariable(
                    "serverName",
                    SqlDatabaseTestSettings.Instance.ServerName);

                // Create a new server
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.AzureSqlDatabaseServerFirewallTests");
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

                Collection<PSObject> newFirewallRuleResult1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabaseServerFirewallRule" +
                            @" -ServerName $serverName" +
                            @" -RuleName Rule1" +
                            @" -StartIpAddress 0.0.0.0" +
                            @" -EndIpAddress 1.1.1.1");
                    });

                Collection<PSObject> newFirewallRuleResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabaseServerFirewallRule" +
                            @" -ServerName $serverName" +
                            @" -RuleName Rule2" +
                            @" -StartIpAddress 1.1.1.1" +
                            @" -EndIpAddress 2.2.2.2");
                    });

                Collection<PSObject> getFirewallRuleResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServerFirewallRule $serverName");
                    });

                Collection<PSObject> setFirewallResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("fw", newFirewallRuleResult1);
                        powershell.InvokeBatchScript(
                            @"$fw | Set-AzureSqlDatabaseServerFirewallRule" +
                            @" -StartIpAddress 2.2.2.2" +
                            @" -EndIpAddress 3.3.3.3");
                        return powershell.InvokeBatchScript(
                            @"$fw | Get-AzureSqlDatabaseServerFirewallRule");
                    });

                Collection<PSObject> removeFirewallResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("rules", getFirewallRuleResult);
                        powershell.InvokeBatchScript(
                            @"$rules | Remove-AzureSqlDatabaseServerFirewallRule" +
                            @" -Force");

                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServerFirewallRule $serverName");
                    });

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Unexpected Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Unexpected Warnings during run!");

                // Validate New- and Get-AzureSqlDatabaseServerFirewallRule
                SqlDatabaseServerFirewallRuleContext[] firewallRules = getFirewallRuleResult
                    .Select(r => r.BaseObject as SqlDatabaseServerFirewallRuleContext)
                    .ToArray();
                Assert.AreEqual(2, firewallRules.Length, "Expecting two firewall rules");
                Assert.IsNotNull(firewallRules[0],
                    "Expecting a SqlDatabaseServerFirewallRuleContext object.");
                Assert.IsNotNull(firewallRules[1],
                    "Expecting a SqlDatabaseServerFirewallRuleContext object.");

                Assert.AreEqual(SqlDatabaseTestSettings.Instance.ServerName, firewallRules[0].ServerName);
                Assert.AreEqual("Rule1", firewallRules[0].RuleName);
                Assert.AreEqual("0.0.0.0", firewallRules[0].StartIpAddress);
                Assert.AreEqual("1.1.1.1", firewallRules[0].EndIpAddress);
                Assert.AreEqual("Success", firewallRules[0].OperationStatus);

                Assert.AreEqual(SqlDatabaseTestSettings.Instance.ServerName, firewallRules[1].ServerName);
                Assert.AreEqual("Rule2", firewallRules[1].RuleName);
                Assert.AreEqual("1.1.1.1", firewallRules[1].StartIpAddress);
                Assert.AreEqual("2.2.2.2", firewallRules[1].EndIpAddress);
                Assert.AreEqual("Success", firewallRules[1].OperationStatus);

                // Validate Set-AzureSqlDatabaseServerFirewallRule
                SqlDatabaseServerFirewallRuleContext firewallRule =
                    setFirewallResult.Single().BaseObject as SqlDatabaseServerFirewallRuleContext;
                Assert.IsNotNull(firewallRule, "Expecting a SqlDatabaseServerFirewallRuleContext object");
                Assert.AreEqual(SqlDatabaseTestSettings.Instance.ServerName, firewallRule.ServerName);
                Assert.AreEqual("Rule1", firewallRule.RuleName);
                Assert.AreEqual("2.2.2.2", firewallRule.StartIpAddress);
                Assert.AreEqual("3.3.3.3", firewallRule.EndIpAddress);
                Assert.AreEqual("Success", firewallRule.OperationStatus);

                // Validate Remove-AzureSqlDatabaseServerFirewallRule
                Assert.AreEqual(0, removeFirewallResult.Count,
                    "Expect all firewall rules are dropped.");
            }
        }
    }
}
