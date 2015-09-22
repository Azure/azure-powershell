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
    public class GetWAPackVMOSDiskTests : CmdletTestBase
    {
        public const string cmdletName = "Get-WAPackVMOSDisk";

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackOSDiskWithNoParam()
        {
            var allOSDisks = this.InvokeCmdlet(cmdletName, null);
            Assert.IsTrue(allOSDisks.Any());
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackOSDiskFromName()
        {
            string expectedosDiskName = WAPackConfigurationFactory.Ws2k8R2OSDiskName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedosDiskName}
            };
            var osDiskFromName = this.InvokeCmdlet(cmdletName, inputParams);
            var actualDiskName = osDiskFromName.First().Properties["Name"].Value;

            Assert.AreEqual(1, osDiskFromName.Count);
            Assert.AreEqual(expectedosDiskName, actualDiskName);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackOSDiskFromIdAndName()
        {
            string expectedosDiskName = WAPackConfigurationFactory.Ws2k8R2OSDiskName;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedosDiskName}
            };
            var osDiskFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, osDiskFromName.Count);

            var expectedosDiskId = osDiskFromName.First().Properties["Id"].Value;

            inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedosDiskId}
            };
            var osDiskFromId = this.InvokeCmdlet(cmdletName, inputParams);

            var actualosDiskFromId = osDiskFromId.First().Properties["Id"].Value;
            Assert.AreEqual(expectedosDiskId, actualosDiskFromId);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackOSDiskByNameDoesNotExist()
        {
            string expectedosDiskName = "WAPackOSDiskDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedosDiskName}
            };
            var osDiskFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(0, osDiskFromName.Count);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackOSDiskByIdDoesNotExist()
        {
            var expectedVmId = Guid.NewGuid().ToString();
            var expectedError = string.Format(Utilities.Properties.Resources.ResourceNotFound, expectedVmId);
            var inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedVmId}
            };
            var vmFromName = this.InvokeCmdlet(cmdletName, inputParams, expectedError);
            Assert.AreEqual(0, vmFromName.Count);
        }
    }
}
