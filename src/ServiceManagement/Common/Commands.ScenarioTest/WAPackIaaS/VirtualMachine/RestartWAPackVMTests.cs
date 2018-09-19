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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class RestartWAPackVMTests : CmdletTestVirtualMachineStatusBase
    {

        [TestMethod]
        public void ShouldRestartRunningVM()
        {
            var startedVm = SetVirtualMachineState(VirtualMachine, "Start");
            Assert.AreEqual("Running", startedVm.Properties["StatusString"].Value);

            //Get the "last modified time" of the running VM
            var lastModified = startedVm.Properties["ModifiedTime"].Value as DateTime?;
            Assert.IsNotNull(lastModified);

            //Restart the VM, then verify that it is running and that it was modified
            var restartedVm = SetVirtualMachineState(startedVm, "Restart");
            Assert.AreEqual("Running", restartedVm.Properties["StatusString"].Value);

            var lastModifiedAgain = restartedVm.Properties["ModifiedTime"].Value as DateTime?;
            Assert.IsNotNull(lastModifiedAgain);

            Assert.IsTrue(lastModifiedAgain > lastModified);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldFailRestartStoppedVM()
        {
            var stoppedVM = SetVirtualMachineState(VirtualMachine, "Stop");
            Assert.AreEqual("Stopped", stoppedVM.Properties["StatusString"].Value);

            var restartedVm = SetVirtualMachineState(stoppedVM, "Restart");
            Assert.AreEqual("Stopped", restartedVm.Properties["StatusString"].Value);

            //The "Restart" job should fail and a message should appear in the PS error stream
            var ps = this.PowerShell;
            var errMsg = ps.GetPowershellErrorMessage();
            Assert.IsNotNull(errMsg);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void ShouldFailRestartUnknownVM()
        {
            var vm = this.VirtualMachine;
            Assert.IsNotNull(vm);

            vm.Properties["ID"].Value = Guid.NewGuid();

            var ps = this.PowerShell;
            ps.Commands.Clear();
            ps.AddCommand("Restart-WAPackVM");
            ps.AddParameter("VM", vm);
            ps.AddParameter("PassThru");
            ps.InvokeAndAssertForErrors(string.Format(Utilities.Properties.Resources.OperationFailedErrorMessage, Utilities.Properties.Resources.Restart, vm.Properties["ID"].Value));
        }
    }
}
