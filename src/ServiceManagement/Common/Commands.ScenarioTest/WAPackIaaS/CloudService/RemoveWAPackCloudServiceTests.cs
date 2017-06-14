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
    public class RemoveWAPackCloudServiceTests : CmdletTestCloudServiceBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Remove any existing CloudService
            this.CloudServicePreTestCleanup();

            // Create CloudService
            this.CreateCloudService();
        }

        [TestMethod]
        [TestCategory("WAPackIaaS-All")]
        [TestCategory("WAPackIaaS-Functional")]
        [TestCategory("WAPackIaaS-CloudService")]
        public void RemoveWAPackCloudServiceDefault()
        {
            var cloudServiceToDelete = this.createdCloudServices.First();

            var inputParams = new Dictionary<string, object>()
            {
                {"CloudService", cloudServiceToDelete},
                {"Force", null},
                {"PassThru", null}
            };
            var isDeleted = this.InvokeCmdlet(Cmdlets.RemoveWAPackCloudService, inputParams);
            Assert.AreEqual(1, isDeleted.Count);
            Assert.AreEqual(true, isDeleted.First());

            inputParams = new Dictionary<string, object>()
            {
                {"Name", cloudServiceToDelete.Properties["Name"].Value}
            };
            var deletedCloudService = this.InvokeCmdlet(Cmdlets.GetWAPackCloudService, inputParams, nonExistantResourceExceptionMessage);
            Assert.AreEqual(0, deletedCloudService.Count);

            this.createdCloudServices.Remove(cloudServiceToDelete);
        }

        [TestCleanup]
        public void CloudServiceCleanup()
        {
            this.RemoveCloudServices();
        }
    }
}
