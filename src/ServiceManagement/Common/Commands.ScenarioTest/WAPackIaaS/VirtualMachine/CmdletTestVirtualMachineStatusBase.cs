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

using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    public class CmdletTestVirtualMachineStatusBase : CmdletTestBase
    {
        protected virtual string OsDiskName
        {
            get { return WAPackConfigurationFactory.Ws2k8R2OSDiskName; }
        }

        protected virtual string VmSizeProfileName
        {
            get { return WAPackConfigurationFactory.VMSizeProfileName; }
        }

        protected virtual PSObject VirtualMachine
        {
            get
            {
                var commandBackup = PowerShell.Commands.Clone();

                try
                {
                    PowerShell.Commands.Clear();
                    PowerShell.AddCommand("Get-WAPackVM").AddParameter("Name", GetType().Name);
                    var vm = PowerShell.InvokeAndAssertForNoErrors();
                    PowerShell.Commands.Clear();

                    if (vm.Count > 0)
                    {
                        return vm[0];
                    }

                    PowerShell.AddCommand("Get-WAPackVMOSDisk");
                    PowerShell.AddParameter("Name", OsDiskName);
                    var osDisk = this.PowerShell.InvokeAndAssertForNoErrors();
                    Assert.AreEqual(1, osDisk.Count);

                    PowerShell.Commands.Clear();
                    PowerShell.AddCommand("Get-WAPackVMSizeProfile");
                    PowerShell.AddParameter("Name", VmSizeProfileName);
                    var vmSizeProfile = this.PowerShell.InvokeAndAssertForNoErrors();
                    Assert.AreEqual(1, vmSizeProfile.Count);

                    PowerShell.Commands.Clear();
                    PowerShell.AddCommand("New-WAPackVM");
                    PowerShell.AddParameter("Name", GetType().Name);
                    PowerShell.AddParameter("OSDisk", osDisk[0]);
                    PowerShell.AddParameter("VMSizeProfile", vmSizeProfile[0]);
                    var createdVm = PowerShell.InvokeAndAssertForNoErrors();
                    this.PowerShell.Commands.Clear();

                    Assert.AreEqual(1, createdVm.Count);
                    return createdVm[0];
                }
                finally
                {
                    PowerShell.Commands = commandBackup;
                }
            }
        }

        protected virtual PSObject SetVirtualMachineState(PSObject vm, string state)
        {
            PowerShell.Commands.Clear();
            PowerShell.Streams.ClearStreams();
            PowerShell.AddCommand(string.Format("{0}-WAPackVM", state)).AddParameter("VM", vm).AddParameter("PassThru"); ;
            var updatedVm = PowerShell.Invoke();
            return updatedVm[0];
        }
    }
}
