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
    public class NewWAPackStaticIPAddressPoolTests : CmdletTestNetworkingBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing VNet
            this.NetworkingPreTestCleanup();

            // Create a VNnet/VMSubnet
            this.CreateVNet();
            this.CreateVMSubnet();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void NewWAPackStaticIPAddressPoolDefault()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", staticIPAddressPoolName},
                {"VMSubnet", this.createdVMSubnet.First()},
                {"IPAddressRangeStart", ipAddressRangeStart},
                {"IPAddressRangeEnd", ipAddressRangeEnd}
            };
            var createdStaticIPAddressPool = this.InvokeCmdlet(Cmdlets.NewWAPackStaticIPAddressPool, inputParams, null);
            Assert.AreEqual(1, createdStaticIPAddressPool.Count, string.Format("{0} StaticIPAddressPool Found, {1} StaticIPAddressPool Was Expected.", createdStaticIPAddressPool.Count, 1));
            this.createdStaticIPAddressPool.AddRange(createdStaticIPAddressPool);

            var readStaticIPAddressPoolName = createdStaticIPAddressPool.First().Properties["Name"].Value;
            Assert.AreEqual(staticIPAddressPoolName, readStaticIPAddressPoolName, string.Format("Actual StaticIPAddressPool Name - {0}, Expected StaticIPAddressPool Name - {1}", readStaticIPAddressPoolName, staticIPAddressPoolName));

            var readStaticIPAddressPoolIPAddressRangeStart = createdStaticIPAddressPool.First().Properties["IPAddressRangeStart"].Value;
            Assert.AreEqual(ipAddressRangeStart, readStaticIPAddressPoolIPAddressRangeStart, string.Format("Actual StaticIPAddressPool IPAddressRangeStart - {0}, Expected StaticIPAddressPool IPAddressRangeStart - {1}", readStaticIPAddressPoolIPAddressRangeStart, ipAddressRangeStart));

            var readStaticIPAddressPoolIPAddressRangeEnd = createdStaticIPAddressPool.First().Properties["IPAddressRangeEnd"].Value;
            Assert.AreEqual(ipAddressRangeEnd, readStaticIPAddressPoolIPAddressRangeEnd, string.Format("Actual StaticIPAddressPool IPAddressRangeEnd - {0}, Expected StaticIPAddressPool IPAddressRangeEnd - {1}", readStaticIPAddressPoolIPAddressRangeEnd, ipAddressRangeEnd));
        }

        [TestCleanup]
        public void StaticIPAddressPoolCleanup()
        {
            this.RemoveVNet();
        }
    }
}
