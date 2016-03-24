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

using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional test for NewContainer
    /// </summary>
    [TestClass]
    class NewContainer : TestBase
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// Create a container which was deleted but not gc’d fully yet
        /// 8.1	New-AzureStorageContainer Negative Functional Cases
        ///     5.	Create a container which was deleted but not gc’d fully yet
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.NewContainer)]
        public void CreateIsDeletingContainer()
        {
            CloudBlobContainer container = blobUtil.CreateContainer();
            blobUtil.CreateRandomBlob(container);

            blobUtil.RemoveContainer(container.Name);

            Test.Assert(!agent.NewAzureStorageContainer(container.Name), "Create a container which is being deleted should fail");
            ExpectedContainErrorMessage("The specified container is being deleted. Try operation later.");
        }
    }
}
