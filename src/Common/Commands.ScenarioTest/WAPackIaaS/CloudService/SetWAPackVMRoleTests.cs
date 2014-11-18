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
    public class SetWAPackVMRoleTests : CmdletTestCloudServiceBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing VMRoles/CloudService
            this.CloudServicePreTestCleanup();
            this.VMRolePreTestCleanup();

            // Create a QuickCreateVMRole
            this.CreateVMRoleFromQuickCreate();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void SetWAPackQuickCreateVMRoleInstanceCount()
        {
            var vmRoleToScale = this.createdVMRolesFromQuickCreate.First();
            var vmRoleInstances = (IEnumerable<object>) vmRoleToScale.Properties["VMs"].Value;

            var inputParams = new Dictionary<string, object>()
            {
                {"VMRole", vmRoleToScale},
                {"InstanceCount", vmRoleInstances.Count() + 1},
                {"PassThru", null}
            };
            var isUpdated = this.InvokeCmdlet(Cmdlets.SetWAPackVMRole, inputParams);
            Assert.AreEqual(1, isUpdated.Count);
            Assert.AreEqual(true, isUpdated.First());

            inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromQuickCreate}
            };
            var updatedVMRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams);
            Assert.AreEqual(1, updatedVMRole.Count, string.Format("{0} VMRole Found, {1} VMRole Was Expected.", updatedVMRole.Count, 1));

            var updatedVMRoleInstances = (IEnumerable<object>) updatedVMRole.First().Properties["VMs"].Value;
            Assert.AreEqual(vmRoleInstances.Count() + 1, updatedVMRoleInstances.Count(), string.Format("{0} VMInstances Found, {1} VMInstances Was Expected.", vmRoleInstances.Count() + 1, updatedVMRoleInstances.Count()));
        }

        [TestCleanup]
        public void VMRoleCleanup()
        {
            this.RemoveVMRoles();
            this.RemoveCloudServices();
        }
    }
}
