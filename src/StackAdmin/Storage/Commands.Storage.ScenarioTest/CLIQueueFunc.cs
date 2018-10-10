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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest
{
    /// <summary>
    /// this class contains all the functional test cases for PowerShell Queue cmdlets
    /// </summary>
    [TestClass]
    class CLIQueueFunc
    {
        private static CloudStorageAccount _StorageAccount;

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Trace.WriteLine("ClassInit");
            Test.FullClassName = testContext.FullyQualifiedTestClassName;

            _StorageAccount = TestBase.GetCloudStorageAccountFromConfig();

            // import module
            string moduleFilePath = Test.Data.Get("ModuleFilePath");
            if (moduleFilePath.Length > 0)
                PowerShellAgent.ImportModule(moduleFilePath);

            // $context = New-AzureStorageContext -ConnectionString ...
            PowerShellAgent.SetStorageContext(_StorageAccount.ToString(true));
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            Trace.WriteLine("ClasssCleanup");
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Trace.WriteLine("TestInit");
            Test.Start(TestContext.FullyQualifiedTestClassName, TestContext.TestName);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Trace.WriteLine("TestCleanup");
            // do not clean up the blobs here for investigation
            // every test case should do cleanup in its init
            Test.End(TestContext.FullyQualifiedTestClassName, TestContext.TestName);
        }

        #endregion

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void CreateInvalidQueue()
        {
            CreateInvalidQueue(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void CreateExistingQueue()
        {
            CreateExistingQueue(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void QueueListOperations()
        {
            QueueListOperations(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void GetNonExistingQueue()
        {
            GetNonExistingQueue(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void EnumerateAllQueues()
        {
            EnumerateAllQueues(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void RemoveNonExistingQueue()
        {
            RemoveNonExistingQueue(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void RemoveQueueWithoutForce()
        {
            RemoveQueueWithoutForce(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void GetMessageCount()
        {
            GetMessageCount(new PowerShellAgent());
        }

        /// <summary>
        /// Functional Cases : for New-AzureStorageQueue
        /// 1. Create a list of new Queues (Positive 2)
        /// 2. Create a list of Queues that already exist (Negative 4)
        /// 3. Create a list of Queues that some of them already exist (Negative 5)
        /// 
        /// Functional Cases : for Get-AzureStorageQueue
        /// 4.	Get a list of Queues by using wildcards in the name (Positive 2)
        /// 
        /// Functional Cases : for Remove-AzureStorageQueue
        /// 5.	Remove a list of existing Queues by using pipeline (Positive 3)
        /// </summary>
        internal void QueueListOperations(Agent agent)
        {
            string PREFIX = Utility.GenNameString("uniqueprefix-") + "-";
            string[] QUEUE_NAMES = new string[] { Utility.GenNameString(PREFIX), Utility.GenNameString(PREFIX), Utility.GenNameString(PREFIX) };

            // PART_EXISTING_NAMES differs only the last element with Queue_NAMES
            string[] PARTLY_EXISTING_NAMES = new string[QUEUE_NAMES.Length];
            Array.Copy(QUEUE_NAMES, PARTLY_EXISTING_NAMES, QUEUE_NAMES.Length - 1);
            PARTLY_EXISTING_NAMES[QUEUE_NAMES.Length - 1] = Utility.GenNameString(PREFIX);

            string[] MERGED_NAMES = QUEUE_NAMES.Union(PARTLY_EXISTING_NAMES).ToArray();
            Array.Sort(MERGED_NAMES);

            // Generate the comparison data
            Collection<Dictionary<string, object>> comp = new Collection<Dictionary<string, object>>();
            foreach (string name in MERGED_NAMES)
            {
                comp.Add(Utility.GenComparisonData(StorageObjectType.Queue, name));
            }

            CloudQueueClient queueClient = _StorageAccount.CreateCloudQueueClient();

            // Check if all the above Queues have been removed
            foreach (string name in MERGED_NAMES)
            {
                CloudQueue Queue = queueClient.GetQueueReference(name);
                Queue.DeleteIfExists();
            }

            //--------------1. New operation--------------
            Test.Assert(agent.NewAzureStorageQueue(QUEUE_NAMES), Utility.GenComparisonData("NewAzureStorageQueue", true));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 3, "3 row returned : {0}", agent.Output.Count);

            // Check if all the above queues have been created
            foreach (string name in QUEUE_NAMES)
            {
                CloudQueue queue = queueClient.GetQueueReference(name);
                Test.Assert(queue.Exists(), "queue {0} should exist", name);
            }

            try
            {
                //--------------2. New operation--------------
                Test.Assert(!agent.NewAzureStorageQueue(QUEUE_NAMES), Utility.GenComparisonData("NewAzureStorageQueue", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "0 row returned : {0}", agent.Output.Count);
                int i = 0;
                foreach (string name in QUEUE_NAMES)
                {
                    Test.Assert(agent.ErrorMessages[i].Equals(String.Format("Queue '{0}' already exists.", name)), agent.ErrorMessages[i]);
                    ++i;
                }

                //--------------3. New operation--------------
                Test.Assert(!agent.NewAzureStorageQueue(PARTLY_EXISTING_NAMES), Utility.GenComparisonData("NewAzureStorageQueue", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 1, "1 row returned : {0}", agent.Output.Count);

                // Check if all the above queues have been created
                foreach (string name in QUEUE_NAMES)
                {
                    CloudQueue queue = queueClient.GetQueueReference(name);
                    Test.Assert(queue.Exists(), "queue {0} should exist", name);
                }

                //--------------4. Get operation--------------
                Test.Assert(agent.GetAzureStorageQueue("*" + PREFIX + "*"), Utility.GenComparisonData("GetAzureStorageQueue", true));
                // Verification for returned values
                agent.OutputValidation(_StorageAccount.CreateCloudQueueClient().ListQueues(PREFIX, QueueListingDetails.All));

                // use Prefix parameter
                Test.Assert(agent.GetAzureStorageQueueByPrefix(PREFIX), Utility.GenComparisonData("GetAzureStorageQueueByPrefix", true));
                // Verification for returned values
                agent.OutputValidation(_StorageAccount.CreateCloudQueueClient().ListQueues(PREFIX, QueueListingDetails.All));
            }
            finally {
                //--------------5. Remove operation--------------
                Test.Assert(agent.RemoveAzureStorageQueue(MERGED_NAMES), Utility.GenComparisonData("RemoveAzureStorageQueue", true));
                // Check if all the above queues have been removed
                foreach (string name in QUEUE_NAMES)
                {
                    CloudQueue queue = queueClient.GetQueueReference(name);
                    Test.Assert(!queue.Exists(), "queue {0} should not exist", name);
                }
            }
        }

        /// <summary>
        /// Negative Functional Cases : for New-AzureStorageQueue 
        /// 1. Create a Queue that already exists (Negative 3)
        /// </summary>
        internal void CreateExistingQueue(Agent agent)
        {
            string QUEUE_NAME = Utility.GenNameString("existing");

            // create queue if not exists
            CloudQueue queue = _StorageAccount.CreateCloudQueueClient().GetQueueReference(QUEUE_NAME);
            queue.CreateIfNotExists();

            try
            {
                //--------------New operation--------------
                Test.Assert(!agent.NewAzureStorageQueue(QUEUE_NAME), Utility.GenComparisonData("NewAzureStorageQueue", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
                Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Queue '{0}' already exists.", QUEUE_NAME)), agent.ErrorMessages[0]);
            }
            finally
            {
                // Recover the environment
                queue.DeleteIfExists();
            }
        }

        /// <summary>
        /// Negative Functional Cases : for New-AzureStorageQueue 
        /// 1. Create a new queue with an invalid queue name (Negative 1)
        /// </summary>
        internal void CreateInvalidQueue(Agent agent)
        {
            string queueName = Utility.GenNameString("abc_");

            //--------------New operation--------------
            Test.Assert(!agent.NewAzureStorageQueue(queueName), Utility.GenComparisonData("NewAzureStorageQueue", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].StartsWith(String.Format("Queue name '{0}' is invalid.", queueName)), agent.ErrorMessages[0]);
        }


        /// <summary>
        /// Negative Functional Cases : for Get-AzureStorageQueue 
        /// 1. Get a non-existing queue (Negative 1)
        /// </summary>
        internal void GetNonExistingQueue(Agent agent)
        {
            string QUEUE_NAME = Utility.GenNameString("nonexisting");

            // Delete the queue if it exists
            CloudQueue queue = _StorageAccount.CreateCloudQueueClient().GetQueueReference(QUEUE_NAME);
            queue.DeleteIfExists();

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageQueue(QUEUE_NAME), Utility.GenComparisonData("GetAzureStorageQueue", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Can not find queue '{0}'.", QUEUE_NAME)), agent.ErrorMessages[0]);
        }

        /// <summary>
        /// Functional Cases : for Get-AzureStorageQueue
        /// 1. Validate that all the queues can be enumerated (Positive 5)
        /// </summary>
        internal void EnumerateAllQueues(Agent agent)
        {
            //--------------Get operation--------------
            Test.Assert(agent.GetAzureStorageQueue(""), Utility.GenComparisonData("EnumerateAllQueues", false));

            // Verification for returned values
            agent.OutputValidation(_StorageAccount.CreateCloudQueueClient().ListQueues());
        }

        /// <summary>
        /// Negative Functional Cases : for Remove-AzureStorageQueue 
        /// 1. Remove a non-existing queue (Negative 2)
        /// </summary>
        internal void RemoveNonExistingQueue(Agent agent)
        {
            string QUEUE_NAME = Utility.GenNameString("nonexisting");

            // Delete the queue if it exists
            CloudQueue queue = _StorageAccount.CreateCloudQueueClient().GetQueueReference(QUEUE_NAME);
            queue.DeleteIfExists();

            //--------------Remove operation--------------
            Test.Assert(!agent.RemoveAzureStorageQueue(QUEUE_NAME), Utility.GenComparisonData("RemoveAzureStorageQueue", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Can not find queue '{0}'.", QUEUE_NAME)), agent.ErrorMessages[0]);
        }

        /// <summary>
        /// Negative Functional Cases : for Remove-AzureStorageQueue 
        /// 1. Remove the queue without by force (Negative 3)
        /// </summary>
        internal void RemoveQueueWithoutForce(Agent agent)
        {
            string QUEUE_NAME = Utility.GenNameString("withoutforce-");

            // create queue if not exists
            CloudQueue queue = _StorageAccount.CreateCloudQueueClient().GetQueueReference(QUEUE_NAME);
            queue.CreateIfNotExists();

            try
            {
                //--------------Remove operation--------------
                Test.Assert(!agent.RemoveAzureStorageQueue(QUEUE_NAME, false), Utility.GenComparisonData("RemoveAzureStorageQueue", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
                Test.Assert(agent.ErrorMessages[0].StartsWith("A command that prompts the user failed because"), agent.ErrorMessages[0]);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        /// <summary>
        /// Positive Functional Cases : for Get-AzureStorageQueue 
        /// 1. Get the ApproximateMessageCount of the queue (Positive 5)
        /// </summary>
        internal void GetMessageCount(Agent agent)
        {
            const int MAX_SIZE = 32;
            string QUEUE_NAME = Utility.GenNameString("messagecount-");

            // create queue if not exists
            CloudQueue queue = _StorageAccount.CreateCloudQueueClient().GetQueueReference(QUEUE_NAME);
            queue.CreateIfNotExists();
            // insert random count queues
            Random random = new Random();
            int count = random.Next(MAX_SIZE) + 1;  // count >= 1
            for (int i = 1; i <= count; ++i)
                queue.AddMessage(new CloudQueueMessage("message " + i));

            // generate comparsion data
            Collection<Dictionary<string, object>> comp = new Collection<Dictionary<string, object>>();
            var dic = Utility.GenComparisonData(StorageObjectType.Queue, QUEUE_NAME);
            dic["ApproximateMessageCount"] = count;
            comp.Add(dic);            

            try
            {
                //--------------Get operation--------------
                Test.Assert(agent.GetAzureStorageQueue(QUEUE_NAME), Utility.GenComparisonData("GetAzureStorageQueue", true));
                // Verification for returned values
                agent.OutputValidation(comp);            
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }
    }
}
