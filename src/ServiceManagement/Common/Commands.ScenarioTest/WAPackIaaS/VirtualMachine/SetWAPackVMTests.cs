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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class SetWAPackVMTests : CmdletTestVirtualMachineStatusBase
    {
        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void SetSizeProfile()
        {
            var ps = this.PowerShell;

            //Get a size profile
            ps.Commands.Clear();
            ps.AddCommand("Get-WAPackVMSizeProfile");
            ps.AddParameter("Name", WAPackConfigurationFactory.VMSizeProfileName);
            var sizeProfileList = this.PowerShell.InvokeAndAssertForNoErrors();
            Assert.AreEqual(1, sizeProfileList.Count);

            //Get the VM, verify that is stopped before we change the profile
            SetVirtualMachineState(VirtualMachine, "Stop");
            var vm = this.VirtualMachine;
            Assert.IsNotNull(vm);
            Assert.AreEqual("Stopped", vm.Properties["StatusString"].Value);

            //See what the size of our VM is currently
            var currentRAM = vm.Properties["Memory"].Value;
            var currentCPU = vm.Properties["CPUCount"].Value;

            var newProfile = sizeProfileList.First();
            Assert.IsNotNull(newProfile);

            //Modify the profile to make sure it's different from what the VM currently has
            newProfile.Properties["Memory"].Value = 1024;
            if ((int)currentRAM >= 1024)
                newProfile.Properties["Memory"].Value = 512;

            //Set the size profile
            ps.Commands.Clear();
            ps.Commands.AddCommand("Set-WAPackVM");
            ps.AddParameter("VM", vm);
            ps.AddParameter("VMSizeProfile", newProfile);
            ps.AddParameter("PassThru");
            var updatedVMList = ps.InvokeAndAssertForNoErrors();
            Assert.AreEqual(1, updatedVMList.Count);

            var updatedVM = updatedVMList.First();
            Assert.IsNotNull(updatedVM);

            //Only way to know if size profile has truly updated is if there is a different amount of CPU/RAM than before
            Assert.AreNotEqual(updatedVM.Properties["CPUCount"].Value, currentRAM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldFailSetOnNonexistantVM()
        {
            var ps = this.PowerShell;

            //Get a size profile
            ps.Commands.Clear();
            ps.AddCommand("Get-WAPackVMSizeProfile");
            ps.AddParameter("Name", WAPackConfigurationFactory.VMSizeProfileName);
            var sizeProfileList = this.PowerShell.InvokeAndAssertForNoErrors();
            Assert.AreEqual(1, sizeProfileList.Count);

            //Get our VM object, then change its ID to something that doesn't exist
            var vm = this.VirtualMachine;
            Assert.IsNotNull(vm);
            vm.Properties["ID"].Value = Guid.NewGuid();


            //Try to set the size profile
            ps.Commands.Clear();
            ps.Commands.AddCommand("Set-WAPackVM");
            ps.AddParameter("VM", vm);
            ps.AddParameter("VMSizeProfile", sizeProfileList[0]);
            ps.AddParameter("PassThru");

            var expectedError = string.Format(Utilities.Properties.Resources.ResourceNotFound, vm.Properties["ID"].Value);
            var updatedVMList = ps.InvokeAndAssertForErrors(expectedError);
        }
    }
}
