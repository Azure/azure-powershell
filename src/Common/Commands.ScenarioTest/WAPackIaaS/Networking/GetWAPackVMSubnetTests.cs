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
    public class GetWAPackVMSubnetTests : CmdletTestNetworkingBase
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
        public void GetWAPackVMSubnetWithNoNameParam()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"VNet", this.createdVNet.First()}
            };
            var allVMSubnet = this.InvokeCmdlet(Cmdlets.GetWAPackVMSubnet, inputParams);
            Assert.IsTrue(allVMSubnet.Count > 0);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackVMSubnetFromName()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmSubnetName},
                {"VNet", this.createdVNet.First()}
            };
            var vmSubnet = this.InvokeCmdlet(Cmdlets.GetWAPackVMSubnet, inputParams);
            Assert.AreEqual(1, vmSubnet.Count, string.Format("{0} VMSubnet Found, {1} VMSubnet Was Expected.", vmSubnet.Count, 1));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackVMSubnetFromNameDoesNotExist()
        {
            var expectedVMSubnetName = "WAPackVMSubnetDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVMSubnetName},
                {"VNet", this.createdVNet.First()}
            };
            var vmSubnet = this.InvokeCmdlet(Cmdlets.GetWAPackVMSubnet, inputParams);
            Assert.IsTrue(vmSubnet.Count == 0);
        }

        [TestCleanup]
        public void VMSubnetCleanup()
        {
            this.RemoveVNet();
        }
    }
}
