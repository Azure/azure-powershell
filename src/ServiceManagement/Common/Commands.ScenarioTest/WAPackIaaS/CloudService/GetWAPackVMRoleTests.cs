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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    [TestClass]
    public class GetWAPackVMRoleTests : CmdletTestCloudServiceBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing VMRoles/CloudService
            this.VMRolePreTestCleanup();
            this.CloudServicePreTestCleanup();

            // Create a QuickCreateVMRole
            this.CreateVMRoleFromQuickCreate();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void GetWAPackVMRolesWithNoParam()
        {
            var allVMRoles = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, null);
            Assert.IsTrue(allVMRoles.Count > 0);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void GetWAPackVMRoleFromName()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromQuickCreate}
            };
            var vmRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams);
            Assert.AreEqual(1, vmRole.Count, string.Format("{0} VMRole Found, {1} VMRole Was Expected.", vmRole.Count, 1));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void GetWAPackVMRoleWithSameCloudServiceAndVMRoleNames()
        {
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromQuickCreate},
                {"CloudServiceName", vmRoleNameFromQuickCreate}
            };
            var vmRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams);
            Assert.AreEqual(1, vmRole.Count, string.Format("{0} VMRole Found, {1} VMRole Was Expected.", vmRole.Count, 1));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void GetWAPackVMRoleFromNameDoesNotExist()
        {
            string expectedVMRoleName = "WAPackVMRoleDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", expectedVMRoleName},
            };
            var vmRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, nonExistantResourceExceptionMessage);
            Assert.AreEqual(0, vmRole.Count);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Negative")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void GetWAPackVMRoleFromNonExistentCloudService()
        {
            string nonExistentCloudService = "WAPackVMRoleCloudServiceNameDoesNotExist";
            var inputParams = new Dictionary<string, object>()
            {
                {"Name", vmRoleNameFromQuickCreate},
                {"CloudServiceName", nonExistentCloudService}
            };
            var vmRole = this.InvokeCmdlet(Cmdlets.GetWAPackVMRole, inputParams, nonExistantResourceExceptionMessage);
            Assert.AreEqual(0, vmRole.Count);
        }

        [TestCleanup]
        public void VMRoleCleanup()
        {
            this.RemoveVMRoles();
            this.RemoveCloudServices();
        }
    }
}
