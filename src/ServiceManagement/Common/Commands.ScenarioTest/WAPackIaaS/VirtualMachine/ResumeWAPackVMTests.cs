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
    public class ResumeWAPackVMTests : CmdletTestVirtualMachineStatusBase
    {
        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldResumeFromSuspended()
        {
            var initialVm = this.SetVirtualMachineState(this.VirtualMachine, "Start");
            Assert.AreEqual("Running", initialVm.Properties["StatusString"].Value);

            var suspendVm = this.SetVirtualMachineState(this.VirtualMachine, "Suspend");
            Assert.AreEqual("Paused", suspendVm.Properties["StatusString"].Value);

            var resumeVm = this.SetVirtualMachineState(suspendVm, "Resume");
            Assert.AreEqual("Running", resumeVm.Properties["StatusString"].Value);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ResumeVmThatNoLongerExistsFails()
        {
            var vm = VirtualMachine;
            var vmId = vm.Properties["ID"].Value;
            this.SetVirtualMachineState(vm, "Stop");
            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Remove-WAPackVM").AddParameter("VM", VirtualMachine).AddParameter("Force");
            PowerShell.InvokeAndAssertForNoErrors();

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Resume-WAPackVM").AddParameter("VM", vm).AddParameter("PassThru");
            PowerShell.InvokeAndAssertForErrors(string.Format(Utilities.Properties.Resources.OperationFailedErrorMessage, Utilities.Properties.Resources.Resume, vmId));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldBeAbleToGetAndResumeAVmUsingPipeline()
        {
            var vm = VirtualMachine;
            var initialVm = this.SetVirtualMachineState(vm, "Start");
            Assert.AreEqual("Running", initialVm.Properties["StatusString"].Value);

            var suspendedVm = this.SetVirtualMachineState(initialVm, "Suspend");
            Assert.AreEqual("Paused", suspendedVm.Properties["StatusString"].Value);

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Get-WAPackVM")
                .AddParameter("Id", suspendedVm.Properties["Id"].Value)
                .AddCommand("Resume-WAPackVM").AddParameter("PassThru");

            var startedVm = PowerShell.InvokeAndAssertForNoErrors();
            Assert.AreEqual("Running", startedVm[0].Properties["StatusString"].Value);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ResumeFromStoppedFails()
        {
            var vm = VirtualMachine;
            var initialVm = this.SetVirtualMachineState(vm, "Stop");
            Assert.AreEqual("Stopped", initialVm.Properties["StatusString"].Value);

            this.SetVirtualMachineState(initialVm, "Resume");
            var errorMsg = PowerShell.GetPowershellErrorMessage();
            Assert.IsTrue(errorMsg.Contains("Error: 1730"), errorMsg);
        }
    }
}
