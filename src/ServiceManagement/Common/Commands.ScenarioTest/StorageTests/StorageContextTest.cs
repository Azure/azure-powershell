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
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.StorageTests
{
    [TestClass]
    public class StorageContextTest : AzurePowerShellCertificateTest
    {
        public StorageContextTest()
            : base("Storage\\StorageContext.ps1")
        {
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Storage)]
        [TestCategory(Category.BVT)]
        public void NewAnonymousStorageContext()
        {
            RunPowerShellTest("Test-NewAnonymousStorageContext");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Storage)]
        [TestCategory(Category.BVT)]
        public void NewStorageContextWithNameAndKey()
        {
            RunPowerShellTest("Test-NewStorageContextWithNameAndKey");
        }
    }
}
