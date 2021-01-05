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
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class ApplicationGatewayTests : NetworkTestRunner
    {
        public ApplicationGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestAvailableSslOptions()
        {
            TestRunner.RunTestScript("Test-AvailableSslOptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestAvailableWafRuleSets()
        {
            TestRunner.RunTestScript("Test-AvailableWafRuleSets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD2()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD2 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD3()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD3 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestKeyVaultIntegrationTest()
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string servicePrincipal = "fakefakefake";
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                var mode = connectionInfo.GetValue<string>(ConnectionStringKeys.HttpRecorderModeKey);
                if (mode == HttpRecorderMode.Playback.ToString())
                {
                    servicePrincipal = HttpMockServer.GetVariable("spn", "fake");
                }
                else
                {
                    servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                    HttpMockServer.Variables["spn"] = servicePrincipal;
                }
            }
            TestRunner.RunTestScript(string.Format("Test-KeyVaultIntegrationTest -baseDir '{0}' -spn '{1}'", AppDomain.CurrentDomain.BaseDirectory, servicePrincipal));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUDSubItems()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDSubItems -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUDSubItems2()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDSubItems2 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestAvailableServerVariableAndHeader()
        {
            TestRunner.RunTestScript("Test-AvailableServerVariableAndHeader");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayCRUDRewriteRuleSet()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDRewriteRuleSet -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayCRUDRewriteRuleSetWithConditions()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDRewriteRuleSetWithConditions -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestTopLevelWafResourceWithApplicationGateway()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayTopLevelFirewallPolicy -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayWithFirewallPolicy()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayWithFirewallPolicy -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayCRUDRewriteRuleSetUrlConfiguration()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDRewriteRuleSetWithUrlConfiguration -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayWithListenerHostNames()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayWithListenerHostNames -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayWithPrivateLinkConfiguration()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayWithPrivateLinkConfiguration -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayPrivateEndpointConnectionsWorkFlows()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayPrivateEndpointWorkFlows -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev_subset1)]
        public void TestApplicationGatewayCRUDWithMutualAuthentication()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDWithMutualAuthentication -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}
