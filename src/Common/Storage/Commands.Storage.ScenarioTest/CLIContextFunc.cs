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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Test.Common.MsTestLib;
using StorageTestLib;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Commands.Storage.ScenarioTest
{
    /// <summary>
    /// this class contains all the account related functional test cases for PowerShell cmdlets
    /// </summary>
    [TestClass]
    class CLIContextFunc
    {
        private static string BlockFilePath;
        private static string PageFilePath;

        private TestContext testContextInstance;
        private static string INVALID_ACCOUNT_NAME = "invalid";
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

            // import module
            string moduleFilePath = Test.Data.Get("ModuleFilePath");
            if (moduleFilePath.Length > 0)
                PowerShellAgent.ImportModule(moduleFilePath);

            BlockFilePath = Path.Combine(Test.Data.Get("TempDir"), FileUtil.GetSpecialFileName());
            PageFilePath = Path.Combine(Test.Data.Get("TempDir"), FileUtil.GetSpecialFileName());
            FileUtil.CreateDirIfNotExits(Path.GetDirectoryName(BlockFilePath));
            FileUtil.CreateDirIfNotExits(Path.GetDirectoryName(PageFilePath));

            // Generate block file and page file which are used for uploading
            Helper.GenerateMediumFile(BlockFilePath, 1);
            Helper.GenerateMediumFile(PageFilePath, 1);
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

        /// <summary>
        /// Functional case : for context
        /// </summary>
        [TestMethod]
        [TestCategory(Tag.Function)]
        public void StorageContextTest()
        {
            StorageContextTest(new PowerShellAgent());
        }

        /// <summary>
        /// Negative Functional case : 
        ///     Use an invalid account to run all cmdlets   (Negative 2)
        /// </summary>
        [TestMethod]
        [TestCategory(Tag.Function)]
        public void UseInvalidAccount()
        {
            Agent agent = new PowerShellAgent();

            // Create an invalid account
            string StorageAccountKey = Test.Data.Get("StorageAccountKey");
            PowerShellAgent.SetStorageContext(INVALID_ACCOUNT_NAME, StorageAccountKey);

            //TODO The test is too large, need to split it into different tests
            StorageContainerTest(agent);

            StorageQueueTest(agent);
            StorageTableTest(agent);

            string BlockFilePath = Path.Combine(Test.Data.Get("TempDir"), FileUtil.GetSpecialFileName());
            string PageFilePath = Path.Combine(Test.Data.Get("TempDir"), FileUtil.GetSpecialFileName());
            FileUtil.CreateDirIfNotExits(Path.GetDirectoryName(BlockFilePath));
            FileUtil.CreateDirIfNotExits(Path.GetDirectoryName(PageFilePath));
            // Generate block file and page file which are used for uploading
            Helper.GenerateMediumFile(BlockFilePath, 1);
            Helper.GenerateMediumFile(PageFilePath, 1);

            StorageBlobTest(agent, BlockFilePath, StorageBlob.BlobType.BlockBlob);
            StorageBlobTest(agent, PageFilePath, StorageBlob.BlobType.PageBlob);
        }

        internal void StorageContextTest(Agent agent)
        {
            string StorageAccountName = Test.Data.Get("StorageAccountName");
            string StorageAccountKey = Test.Data.Get("StorageAccountKey");
            string StorageEndPoint = Test.Data.Get("StorageEndPoint");

            Collection<Dictionary<string, object>> comp = new Collection<Dictionary<string, object>>();
            bool useHttps = true; //default protocol is https
            string[] endPoints = Utility.GetStorageEndPoints(StorageAccountName, useHttps, StorageEndPoint);
            comp.Add(new Dictionary<string, object>{
                {"StorageAccountName", StorageAccountName},
                {"BlobEndPoint", endPoints[0]},
                {"QueueEndPoint", endPoints[1]},
                {"TableEndPoint", endPoints[2]}
            });

            //--------------New operation--------------
            Test.Assert(agent.NewAzureStorageContext(StorageAccountName, StorageAccountKey, StorageEndPoint), Utility.GenComparisonData("NewAzureStorageContext", true));
            // Verification for returned values
            agent.OutputValidation(comp);
        }

        internal void StorageContainerTest(Agent agent)
        {
            string NEW_CONTAINER_NAME = Utility.GenNameString("astoria-");

            //--------------New operation--------------
            Test.Assert(!agent.NewAzureStorageContainer(NEW_CONTAINER_NAME), Utility.GenComparisonData("NewAzureStorageContainer", false));
            CheckErrorOutput(agent);

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageContainer(NEW_CONTAINER_NAME), Utility.GenComparisonData("GetAzureStorageContainer", false));
            CheckErrorOutput(agent);

            //--------------Set operation-------------- 
            Test.Assert(!agent.SetAzureStorageContainerACL(NEW_CONTAINER_NAME, StorageBlob.BlobContainerPublicAccessType.Blob),
                "SetAzureStorageContainerACL operation should fail");
            CheckErrorOutput(agent);

            Test.Assert(!agent.SetAzureStorageContainerACL(NEW_CONTAINER_NAME, StorageBlob.BlobContainerPublicAccessType.Container),
                "SetAzureStorageContainerACL operation should fail");
            CheckErrorOutput(agent);
        }

        internal void StorageBlobTest(Agent agent, string FilePath, StorageBlob.BlobType Type)
        {
            string NEW_CONTAINER_NAME = Utility.GenNameString("upload-");
            string BlobName = Path.GetFileName(FilePath);

            //--------------Upload operation--------------
            Test.Assert(!agent.SetAzureStorageBlobContent(FilePath, NEW_CONTAINER_NAME, Type), Utility.GenComparisonData("SendAzureStorageBlob", false));
            CheckErrorOutput(agent);

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageBlob(BlobName, NEW_CONTAINER_NAME), Utility.GenComparisonData("GetAzureStorageBlob", false));
            CheckErrorOutput(agent);

            //--------------Remove operation--------------
            Test.Assert(!agent.RemoveAzureStorageBlob(BlobName, NEW_CONTAINER_NAME), Utility.GenComparisonData("RemoveAzureStorageBlob", false));
            CheckErrorOutput(agent);
        }

        internal void StorageQueueTest(Agent agent)
        {
            string NEW_QUEUE_NAME = Utility.GenNameString("redmond-");

            //--------------New operation--------------
            Test.Assert(!agent.NewAzureStorageQueue(NEW_QUEUE_NAME), Utility.GenComparisonData("NewAzureStorageQueue", false));
            CheckErrorOutput(agent);

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageQueue(NEW_QUEUE_NAME), Utility.GenComparisonData("GetAzureStorageQueue", false));
            CheckErrorOutput(agent);

            //--------------Remove operation--------------
            Test.Assert(!agent.RemoveAzureStorageQueue(NEW_QUEUE_NAME), Utility.GenComparisonData("RemoveAzureStorageQueue", false));
            CheckErrorOutput(agent);
        }

        internal void StorageTableTest(Agent agent)
        {
            string NEW_TABLE_NAME = Utility.GenNameString("Washington");

            //--------------New operation--------------
            Test.Assert(!agent.NewAzureStorageTable(NEW_TABLE_NAME), Utility.GenComparisonData("NewAzureStorageTable", false));
            CheckErrorOutput(agent);

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageTable(NEW_TABLE_NAME), Utility.GenComparisonData("GetAzureStorageTable", false));
            CheckErrorOutput(agent);

            //--------------Remove operation--------------
            Test.Assert(!agent.RemoveAzureStorageTable(NEW_TABLE_NAME), Utility.GenComparisonData("RemoveAzureStorageTable", false));
            CheckErrorOutput(agent);
        }

        internal void CheckErrorOutput(Agent agent)
        {
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);

            //the same error may output different error messages in different environments
            bool expectedError = agent.ErrorMessages[0].StartsWith("The remote server returned an error: (502) Bad Gateway") ||
                agent.ErrorMessages[0].StartsWith("The remote name could not be resolved") ||
                agent.ErrorMessages[0].StartsWith("The operation has timed out");
            Test.Assert(expectedError, "use invalid storage account should return 502 or time out, actually it's {0}", agent.ErrorMessages[0]);
        }
    }
}
