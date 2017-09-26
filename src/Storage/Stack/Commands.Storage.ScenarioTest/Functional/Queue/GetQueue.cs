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

using System;
using System.Collections.Generic;
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Queue;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Queue
{
    /// <summary>
    /// general settings for queue related tests
    /// </summary>
    [TestClass]
    public class GetQueue : TestBase
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
        /// get queue with meta data
        /// 8.7	Get-AzureStorageQueue Positive Functional cases
        ///     6. Write Metadata to the specific queue Get the Metadata from the specific queue
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Queue)]
        [TestCategory(PsTag.GetQueue)]
        //TODO add test for Get-AzureStorageQueue -Name String.Empty
        public void GetSpecifiedQueueWithMetaData()
        {
            //create random container
            int count = random.Next(1, 5);
            string queueName = Utility.GenNameString("queue");

            CloudQueue queue = queueUtil.CreateQueue(queueName);

            try
            {
                //list specified queue with properties and meta data
                Test.Assert(agent.GetAzureStorageQueue(queueName), Utility.GenComparisonData("GetAzureStorageQueue", true));

                int queueCount = 1;
                Test.Assert(agent.Output.Count == queueCount, String.Format("Create {0} queues, but retrieved {1} queues", queueCount, agent.Output.Count));

                // Verification for returned values
                agent.OutputValidation(new List<CloudQueue>() { queue});
            }
            finally
            {
                queueUtil.RemoveQueue(queueName);
            }
        }
    }
}
