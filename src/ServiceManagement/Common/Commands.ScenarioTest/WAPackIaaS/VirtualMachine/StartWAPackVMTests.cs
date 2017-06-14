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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class StartWAPackVMTests : CmdletTestVirtualMachineStatusBase
    {
        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldStartVmFromStop()
        {
            var initialVm = this.SetVirtualMachineState(this.VirtualMachine, "Stop");
            Assert.AreEqual("Stopped", initialVm.Properties["StatusString"].Value);

            var startedVm = this.SetVirtualMachineState(initialVm, "Start");
            Assert.AreEqual("Running", startedVm.Properties["StatusString"].Value);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldStartVmAlreadyStarted()
        {
            var initialVm = this.SetVirtualMachineState(this.VirtualMachine, "Start");
            Assert.AreEqual("Running", initialVm.Properties["StatusString"].Value);

            var startedVm = this.SetVirtualMachineState(initialVm, "Start");
            Assert.AreEqual("Running", startedVm.Properties["StatusString"].Value);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        public void StartVmThatNoLongerExistsFails()
        {
            var vm = VirtualMachine;
            var vmId = vm.Properties["ID"].Value;
            this.SetVirtualMachineState(vm, "Stop");
            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Remove-WAPackVM").AddParameter("VM", VirtualMachine).AddParameter("Force");
            PowerShell.InvokeAndAssertForNoErrors();

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Start-WAPackVM").AddParameter("VM", vm).AddParameter("PassThru");
            PowerShell.InvokeAndAssertForErrors(string.Format(Utilities.Properties.Resources.OperationFailedErrorMessage, Utilities.Properties.Resources.Start, vmId));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldBeAbleToGetAndStartAVmUsingPipeline()
        {
            var vm = VirtualMachine;
            var stoppedVm = this.SetVirtualMachineState(vm, "Stop");
            Assert.AreEqual("Stopped", stoppedVm.Properties["StatusString"].Value);

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Get-WAPackVM")
                .AddParameter("Id", stoppedVm.Properties["Id"].Value)
                .AddCommand("Start-WAPackVM").AddParameter("PassThru");

            var startedVm = PowerShell.InvokeAndAssertForNoErrors();
            Assert.AreEqual("Running", startedVm[0].Properties["StatusString"].Value);
        }
    }
}
