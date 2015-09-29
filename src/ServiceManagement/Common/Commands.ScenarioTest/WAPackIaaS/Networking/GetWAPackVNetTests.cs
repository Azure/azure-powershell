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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class GetWAPackVNetTests : CmdletTestNetworkingBase
    {
        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackVNetWithNoParam()
        {
            var allVNetworks = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, null);
            Assert.IsTrue(allVNetworks.Any());
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackWAPackVNetFromName()
        {
            string expectedVNetworkName = WAPackConfigurationFactory.AvenzVnetName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVNetworkName}
            };
            var vNetworkFromName = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams);

            Assert.AreEqual(1, vNetworkFromName.Count);
            var actualvNetworkFromName = vNetworkFromName.First().Properties["Name"].Value;

            Assert.AreEqual(expectedVNetworkName, actualvNetworkFromName);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackWAPackVNetFromIdAndName()
        {
            string expectedVNetworkName = WAPackConfigurationFactory.AvenzVnetName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVNetworkName}
            };
            var vNetworkFromName = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams);

            Assert.AreEqual(1, vNetworkFromName.Count);
            var expectedvNetworkId = vNetworkFromName.First().Properties["Id"].Value;

            inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedvNetworkId}
            };
            var vNetworkFromId = this.PowerShell.InvokeAndAssertForNoErrors();

            var actualvNetworkFromId = vNetworkFromId[0].Properties["Id"].Value;
            Assert.AreEqual(expectedvNetworkId, actualvNetworkFromId);
        }


        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]        
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackVNetByNameDoesNotExist()
        {
            string expectedVNetworkName = "WAPackWAPackVNetDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVNetworkName}
            };
            var vNetworkFromName = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams);

            Assert.AreEqual(0, vNetworkFromName.Count);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]        
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-Networking")]
        public void GetWAPackVNetByIdDoesNotExist()
        {
            var expectedVmId = Guid.NewGuid().ToString();
            var expectedError = string.Format(Utilities.Properties.Resources.ResourceNotFound, expectedVmId);
            var inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedVmId}
            };
            var vmFromName = this.InvokeCmdlet(Cmdlets.GetWAPackVNet, inputParams, expectedError);
            Assert.AreEqual(0, vmFromName.Count);
        }
    }
}
