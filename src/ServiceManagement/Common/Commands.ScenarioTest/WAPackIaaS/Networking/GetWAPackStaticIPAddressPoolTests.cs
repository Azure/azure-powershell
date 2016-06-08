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
    public class GetWAPackStaticIPAddressPoolTests : CmdletTestNetworkingBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing VNet
            this.NetworkingPreTestCleanup();

            // Create a FullVNet
            this.CreateFullVNet();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackStaticIPAddressPoolWithNoNameParam()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"VMSubnet", this.createdVMSubnet.First()}
            };
            var allStaticIPAddressPool = this.InvokeCmdlet(Cmdlets.GetWAPackStaticIPAddressPool, inputParams);
            Assert.IsTrue(allStaticIPAddressPool.Count > 0);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackStaticIPAddressPoolFromName()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", staticIPAddressPoolName},
                {"VMSubnet", this.createdVMSubnet.First()}
            };
            var staticIPAddressPool = this.InvokeCmdlet(Cmdlets.GetWAPackStaticIPAddressPool, inputParams);
            Assert.AreEqual(1, staticIPAddressPool.Count, string.Format("{0} StaticIPAddressPool Found, {1} StaticIPAddressPool Was Expected.", staticIPAddressPool.Count, 1));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackStaticIPAddressPoolFromNameDoesNotExist()
        {
            var expectedStaticIPAddressPoolName = "WAPackStaticIPAddressPoolDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedStaticIPAddressPoolName},
                {"VMSubnet", this.createdVMSubnet.First()}
            };
            var staticIPAddressPool = this.InvokeCmdlet(Cmdlets.GetWAPackStaticIPAddressPool, inputParams);
            Assert.IsTrue(staticIPAddressPool.Count == 0);
        }

        [TestCleanup]
        public void StaticIPAddressPoolCleanup()
        {
            this.RemoveVNet();
        }
    }
}
