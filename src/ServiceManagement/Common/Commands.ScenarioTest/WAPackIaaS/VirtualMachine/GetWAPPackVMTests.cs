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
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class GetWAPPackVMTests : CmdletTestBase
    {
        public const string cmdletName = "Get-WAPackVM";

        public string VMNameToCreate = "TestVirtualMachineForGetTests";

        public List<PSObject> CreatedVirtualMachines;

        [TestInitialize]
        public void TestInitialize()
        {
            CreatedVirtualMachines = new List<PSObject>();
            this.CreateVirtualMachine(VMNameToCreate);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetVmWithNoParam()
        {
            var allVms = this.InvokeCmdlet(cmdletName, null);
            Assert.IsTrue(allVms.Count > 0);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetVmFromName()
        {
            string expectedVmName = VMNameToCreate;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVmName}
            };
            var vmFromName = this.InvokeCmdlet(cmdletName, inputParams);

            var actualVmName = vmFromName.First().Properties["Name"].Value;
            Assert.AreEqual(expectedVmName, actualVmName);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVmFromId()
        {
            string expectedVmName = VMNameToCreate;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVmName}
            };
            var vmFromName = this.InvokeCmdlet(cmdletName, inputParams);

            var expectedVmId = vmFromName.First().Properties["Id"].Value;

            inputParams = new Dictionary<string, object>()
            {
                {"Id", expectedVmId}
            };
            var vmFromId = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, vmFromId.Count);
            var actualvmFromId = vmFromId.First().Properties["Id"].Value;
            Assert.AreEqual(expectedVmId, actualvmFromId);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVmByNameDoesNotExist()
        {
            string expectedVmName = "WAPackVmDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVmName}
            };
            var vmFromName = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(0, vmFromName.Count);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void GetWAPackVmByIdDoesNotExist()
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

        public void CreateVirtualMachine(string vmNameToCreate)
        {
            var ps = this.PowerShell;

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate}
            };
            var existingVMs = this.InvokeCmdlet(cmdletName, inputParams, null);
           
            if (existingVMs != null && existingVMs.Any())
            {
                if (existingVMs.Count == 1)
                {
                    CreatedVirtualMachines.Add(existingVMs.First());
                    return;
                }
                else
                {
                    CreatedVirtualMachines.AddRange(existingVMs);
                    RemoveVMs();
                }
            }

            ps.Commands.Clear();
            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvenzVnetName}
            };
            var vNet = this.InvokeCmdlet("Get-WAPackVnet", inputParams, null);
            Assert.AreEqual(vNet.Count, 1, string.Format("Actual Vnet found - {0}, Expected Vnet - {1}", vNet.Count, 1));

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Ws2k8R2OSDiskName}
            };
            var osDisk = this.InvokeCmdlet("Get-WAPackVMOSDisk", inputParams, null);
            Assert.AreEqual(1, osDisk.Count, string.Format("Actual OSDisks found - {0}, Expected OSDisks - {1}", osDisk.Count, 1));

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.VMSizeProfileName}
            };
            var vmSizeProfile = this.InvokeCmdlet("Get-WAPackVMSizeProfile", inputParams, null);
            Assert.AreEqual(1, vmSizeProfile.Count, string.Format("Actual VMSizeProfiles found - {0}, Expected VMSizeProfiles - {1}", vmSizeProfile.Count, 1));

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"OSDisk", osDisk.First()},
                {"VNet", vNet.First()},
                {"VMSizeProfile", vmSizeProfile.First()}
            };
            var actualCreatedVM = this.InvokeCmdlet("New-WAPackVM", inputParams, null);

            Assert.AreEqual(1, actualCreatedVM.Count, string.Format("Actual VirtualMachines found - {0}, Expected VirtualMachines - {1}", actualCreatedVM.Count, 1));
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            ps.Commands.Clear();

            Assert.AreEqual(vmNameToCreate, createdVMName, string.Format("Actual VirtualMachines name - {0}, Expected VirtualMachines name- {1}", createdVMName, vmNameToCreate));
            CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        private void RemoveVMs()
        {
            foreach (var vm in this.CreatedVirtualMachines)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"VM", vm},
                    {"Force", null}
                };
                var vmFromName = this.InvokeCmdlet("Remove-WAPackVM", inputParams, null);
            }

            this.CreatedVirtualMachines.Clear();
        }
    }
}