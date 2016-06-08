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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions
{
    public class MockIPersistentVMForChefExtension : IPersistentVM
    {
        public PersistentVM GetInstance()
        {
            ResourceExtensionReference extensionRef = null;
            extensionRef = new ResourceExtensionReference()
            {
                Name = "ChefClient",
                Publisher = "Chef.Bootstrap.WindowsAzure,",
                Version = "11.0"
            };

            var resourceList = new ResourceExtensionReferenceList();
            resourceList.Add(extensionRef);

            return new PersistentVM()
            {
                ResourceExtensionReferences = resourceList,
                OSVirtualHardDisk = new OSVirtualHardDisk() { OS = "Windows" }
            };
        }
    }

    [TestClass]
    public class GetAzureVMChefExtensionCommandTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;
        private MockIPersistentVMForChefExtension mockIPersistentVM;
        [TestInitialize]
        public void SetupTest()
        {
            mockCommandRuntime = new MockCommandRuntime();
            mockIPersistentVM = new MockIPersistentVMForChefExtension();
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }
        public class GetAzureVMChefExtensionCommandStub : GetAzureVMChefExtensionCommand
        {
            public GetAzureVMChefExtensionCommandStub() { }
        }

        [TestMethod]
        public void GetAzureVMChefExtensionExecuteChefCommand()
        {
            var getChefExtension = new GetAzureVMChefExtensionCommandStub()
            {
                CommandRuntime = mockCommandRuntime,
                VM = mockIPersistentVM
            };

            getChefExtension.ExecuteCommand();

            Assert.AreEqual(1, mockCommandRuntime.OutputPipeline.Count, "One item should be in the output pipeline");
        }
    }
}