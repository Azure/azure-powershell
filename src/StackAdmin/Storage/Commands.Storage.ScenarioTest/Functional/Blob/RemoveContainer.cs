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
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional test for RemoveContainer
    /// </summary>
    [TestClass]
    class RemoveContainer : TestBase
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
        /// Remove a list of existing blob containers by using wildcards.
        /// 8.3	Remove-AzureStorageContainer Positive Functional Cases
        ///     2.	Remove a list of existing blob containers by using wildcards.
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.RemoveContainer)]
        public void RemoveContainerByWildCardAndPipeline()
        { 
            int containerCount = GetRandomTestCount();
            string containerPrefix = "removecontainer";
            List<string> containerNames = Utility.GenNameLists(containerPrefix, containerCount);
            List<CloudBlobContainer> containers = blobUtil.CreateContainer(containerNames);

            ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageContainer {0}*", containerPrefix));
            Test.Assert(agent.RemoveAzureStorageContainer(string.Empty), "Remove container using wildcard and pipeline should succeed");
            containers.ForEach(container => Test.Assert(!container.Exists(), string.Format("the specified container '{0}' should not exist", container.Name)));
        }
    }
}
