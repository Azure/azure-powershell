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
using Microsoft.WindowsAzure.Storage.Queue;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Queue
{
    /// <summary>
    /// functional test for remove-azurestorage queue
    /// </summary>
    [TestClass]
    public class RemoveQueue : TestBase
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
        /// 2.	Remove a list of existing queues by using wildcards.
        /// 8.8	Remove-AzureStorageQueue Positive Functional Cases
        ///     2.	Remove a list of existing queues by using wildcards.
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Queue)]
        [TestCategory(PsTag.RemoveQueue)]
        public void RemoveQueueByWildCardAndPipeline()
        {
            int queueCount = GetRandomTestCount();
            string queuePrefix = "removequeue";
            List<string> queueNames = Utility.GenNameLists(queuePrefix, queueCount);
            List<CloudQueue> containers = queueUtil.CreateQueue(queueNames);

            ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageQueue {0}*", queuePrefix));
            Test.Assert(agent.RemoveAzureStorageQueue(string.Empty), "Remove queue using wildcard and pipeline should succeed");
            containers.ForEach(queue => Test.Assert(!queue.Exists(), string.Format("the specified queue '{0}' should not exist", queue.Name)));
        }
    }
}
