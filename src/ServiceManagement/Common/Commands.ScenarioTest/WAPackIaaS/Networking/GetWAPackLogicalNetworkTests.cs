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

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class GetWAPackLogicalNetworkTests : CmdletTestNetworkingBase
    {
        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackLogicalNetworkNoParam()
        {
            var allLogicalNetworks = this.InvokeCmdlet(Cmdlets.GetWAPackLogicalNetwork, null);
            Assert.IsTrue(allLogicalNetworks.Count > 0);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackLogicalNetworkFromName()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvezLogicalNetworkName}
            };
            var logicalNetwork = this.InvokeCmdlet(Cmdlets.GetWAPackLogicalNetwork, inputParams);
            Assert.AreEqual(1, logicalNetwork.Count, string.Format("{0} LogicalNetwork Found, {1} LogicalNetwork Was Expected.", logicalNetwork.Count, 1));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackLogicalNetworkFromNameDoesNotExist()
        {
            var expectedLogicalNetworkName = "WAPackLogicalNetworkDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedLogicalNetworkName}
            };
            var logicalNetwork = this.InvokeCmdlet(Cmdlets.GetWAPackLogicalNetwork, inputParams);
            Assert.AreEqual(0, logicalNetwork.Count);
        }
    }
}
