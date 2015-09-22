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
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class NewWAPackVMTests : CmdletTestBase
    {
        public const string cmdletName = "New-WAPackVM";

        public List<PSObject> CreatedVirtualMachines;

        [TestInitialize]
        public void Initialize()
        {
            CreatedVirtualMachines = new List<PSObject>();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateVMFromTemplateWithVNet()
        {
            string vmNameToCreate = "TestWindowsVM_VMFromTemplateWithVNet";

            var ps = this.PowerShell;
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Win7_64TemplateName}
            };
            var template = this.InvokeCmdlet("Get-WAPackVMTemplate", inputParams);
            Assert.AreEqual(template.Count, 1);

            ps.Commands.Clear();
            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvenzVnetName}
            };
            var vNet = this.InvokeCmdlet("Get-WAPackVnet", inputParams);
            Assert.AreEqual(vNet.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"Template", template.First()},
                {"VNet", vNet.First()},
                {"VMCredential", WAPackConfigurationFactory.WindowsVMCredential},
                {"Windows", null},

            };

            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);
            Assert.AreEqual(1, actualCreatedVM.Count);

            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;
            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateVMFromTemplateWithoutVNet()
        {
            string vmNameToCreate = "TestWindowsVM_VMFromTemplateWithoutVNet";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Win7_64TemplateName}
            };
            var template = this.InvokeCmdlet("Get-WAPackVMTemplate", inputParams);
            Assert.AreEqual(template.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"Template", template.First()},
                {"VMCredential", WAPackConfigurationFactory.WindowsVMCredential},
                {"Windows", null},

            };

            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);
            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);
            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateVMFromVHDWithVNet()
        {
            string vmNameToCreate = "TestWindowsVM_VMFromVHDWithVNet";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvenzVnetName}
            };
            var vNet = this.InvokeCmdlet("Get-WAPackVnet", inputParams);
            Assert.AreEqual(vNet.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Ws2k8R2OSDiskName}
            };
            var osDisk = this.InvokeCmdlet("Get-WAPackVMOSDisk", inputParams);
            Assert.AreEqual(osDisk.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.VMSizeProfileName}
            };
            var vmSizeProfile = this.InvokeCmdlet("Get-WAPackVMSizeProfile", inputParams);
            Assert.AreEqual(vmSizeProfile.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"OSDisk", osDisk.First()},
                {"VNet", vNet.First()},
                {"VMSizeProfile", vmSizeProfile.First()}

            };
            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateVMFromVHDWithoutVNet()
        {
            string vmNameToCreate = "TestWindowsVM_VMFromVHDWithoutVNet";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Ws2k8R2OSDiskName}
            };
            var osDisk = this.InvokeCmdlet("Get-WAPackVMOSDisk", inputParams);
            Assert.AreEqual(osDisk.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.VMSizeProfileName}
            };
            var vmSizeProfile = this.InvokeCmdlet("Get-WAPackVMSizeProfile", inputParams);
            Assert.AreEqual(vmSizeProfile.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"OSDisk", osDisk.First()},
                {"VMSizeProfile", vmSizeProfile.First()},
            };
            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateUbuntuVMFromTemplate()
        {
            string vmNameToCreate = "TestUbuntuVM_FromTemplate";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.LinuxUbuntu_64TemplateName}
            };
            var template = this.InvokeCmdlet("Get-WAPackVMTemplate", inputParams);
            Assert.AreEqual(template.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"Template", template.First()},
                {"VMCredential",  WAPackConfigurationFactory.LinuxVMCredential},
                {"Linux", null},
            };
            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateUbuntuVMFromVHDWithVNet()
        {
            string vmNameToCreate = "TestUbuntuVM_FromVHD";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.LinuxOSDiskName}
            };
            var osDisk = this.InvokeCmdlet("Get-WAPackVMOSDisk", inputParams);
            Assert.AreEqual(osDisk.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.VMSizeProfileName}
            };
            var vmSizeProfile = this.InvokeCmdlet("Get-WAPackVMSizeProfile", inputParams);
            Assert.AreEqual(vmSizeProfile.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.AvenzVnetName}
            };
            var vNet = this.InvokeCmdlet("Get-WAPackVnet", inputParams);
            Assert.AreEqual(vNet.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"OSDisk", osDisk.First()},
                {"VMSizeProfile", vmSizeProfile.First()},
                {"VNet", vNet.First()},
            };
            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateUbuntuVMFromVHDWithoutVnet()
        {
            string vmNameToCreate = "TestUbuntuVM_FromVHDWithoutVnet";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.LinuxOSDiskName}
            };
            var osDisk = this.InvokeCmdlet("Get-WAPackVMOSDisk", inputParams);
            Assert.AreEqual(osDisk.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.VMSizeProfileName}
            };
            var vmSizeProfile = this.InvokeCmdlet("Get-WAPackVMSizeProfile", inputParams);
            Assert.AreEqual(vmSizeProfile.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"OSDisk", osDisk.First()},
                {"VMSizeProfile", vmSizeProfile.First()}
            };
            var actualCreatedVM = this.InvokeCmdlet(cmdletName, inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;

            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        public void CreateVMQuickCreate()
        {
            string vmNameToCreate = "TestWindowsVM_QuickCreate";

            var inputParams = new Dictionary<string, object>()
            {
                {"Name", WAPackConfigurationFactory.Win7_64TemplateName}
            };
            var template = this.InvokeCmdlet("Get-WAPackVMTemplate", inputParams);
            Assert.AreEqual(template.Count, 1);

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmNameToCreate},
                {"Template", template.First()},
                {"VMCredential", WAPackConfigurationFactory.WindowsVMCredential}
            };
            var actualCreatedVM = this.InvokeCmdlet("New-WAPackQuickVM", inputParams);

            Assert.AreEqual(1, actualCreatedVM.Count);
            var createdVMName = actualCreatedVM.First().Properties["Name"].Value;
            Assert.AreEqual(vmNameToCreate, createdVMName);

            this.CreatedVirtualMachines.AddRange(actualCreatedVM);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (!this.CreatedVirtualMachines.Any())
                return;

            var ps = this.PowerShell;

            foreach (var vm in this.CreatedVirtualMachines)
            {
                var inputParams = new Dictionary<string, object>()
                {
                    {"VM", vm},
                    {"Force", null}
                };

                this.InvokeCmdlet("Remove-WAPackVM", inputParams);
            }
        }
    }
}
