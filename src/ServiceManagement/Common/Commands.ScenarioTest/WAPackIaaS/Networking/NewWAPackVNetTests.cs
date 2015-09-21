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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class NewWAPackVNetTests : CmdletTestNetworkingBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing VNet
            this.NetworkingPreTestCleanup();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void NewWAPackVNetDefault()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvezLogicalNetworkName}
            };
            var existingLogicalNetwork = this.InvokeCmdlet(Cmdlets.GetWAPackLogicalNetwork, inputParams, null);
            Assert.AreEqual(1, existingLogicalNetwork.Count, string.Format("{0} LogicalNetwork Found, {1} LogicalNetwork Was Expected.", existingLogicalNetwork.Count, 1));

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vNetName},
                {"Description", vNetDescription},
                {"LogicalNetwork", existingLogicalNetwork.First()}
            };
            var createdVNet = this.InvokeCmdlet(Cmdlets.NewWAPackVNet, inputParams, null);
            Assert.AreEqual(1, createdVNet.Count, string.Format("{0} VNet Found, {1} VNet Was Expected.", createdVNet.Count, 1));
            this.createdVNet.AddRange(createdVNet);

            var readVNetName = createdVNet.First().Properties["Name"].Value;
            Assert.AreEqual(vNetName, readVNetName, string.Format("Actual VNet Name - {0}, Expected VNet Name - {1}", readVNetName, vNetName));
        }

        [TestCleanup]
        public void VNetCleanup()
        {
            this.RemoveVNet();
        }
    }
}
