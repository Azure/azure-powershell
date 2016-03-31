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
using System.Linq;
using System.Threading;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using MS.Test.Common.MsTestLib;
using StorageTestLib;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional tests for Get-CopyState
    /// </summary>
    [TestClass]
    class GetCopyState : TestBase
    {
        [ClassInitialize()]
        public static void GetBlobClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void GetBlobClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// monitor mulitple copy progress
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     3.	Monitor a list of copying blobs
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateFromMultiBlobsTest()
        {
            StorageBlob.CloudBlobContainer srcContainer = blobUtil.CreateContainer();
            StorageBlob.CloudBlobContainer destContainer = blobUtil.CreateContainer();

            List<StorageBlob.ICloudBlob> blobs = blobUtil.CreateRandomBlob(srcContainer);

            try
            {
                ((PowerShellAgent)agent).AddPipelineScript(String.Format("Get-AzureStorageBlob -Container {0}", srcContainer.Name));
                ((PowerShellAgent)agent).AddPipelineScript(String.Format("Start-AzureStorageBlobCopy -DestContainer {0}", destContainer.Name));

                Test.Assert(agent.GetAzureStorageBlobCopyState(string.Empty, string.Empty, true), "Get copy state for many blobs should be successed.");
                Test.Assert(agent.Output.Count == blobs.Count, String.Format("Expected get {0} copy state, and actually get {1} copy state", blobs.Count, agent.Output.Count));
                List<StorageBlob.IListBlobItem> destBlobs = destContainer.ListBlobs().ToList();
                Test.Assert(destBlobs.Count == blobs.Count, String.Format("Expected get {0} copied blobs, and actually get {1} copy state", blobs.Count, destBlobs.Count));

                for (int i = 0, count = agent.Output.Count; i < count; i++)
                {
                    AssertFinishedCopyState(blobs[i].Uri, i);
                }
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainer.Name);
                blobUtil.RemoveContainer(destContainer.Name);
            }
        }

        /// <summary>
        /// monitor mulitple copy progress
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     3.	Monitor a list of copying blobs
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateWithInvalidNameTest()
        {
            string invalidContainerName = "Invalid";
            int maxBlobNameLength = 1024;
            string invalidBlobName = new string('a', maxBlobNameLength + 1);
            string invalidContainerErrorMessage = String.Format("Container name '{0}' is invalid.", invalidContainerName);
            string invalidBlobErrorMessage = String.Format("Blob name '{0}' is invalid.", invalidBlobName);
            Test.Assert(!agent.GetAzureStorageBlobCopyState(invalidContainerName, Utility.GenNameString("blob"), false), "get copy state should failed with invalid container name");
            ExpectedStartsWithErrorMessage(invalidContainerErrorMessage);
            Test.Assert(!agent.GetAzureStorageBlobCopyState(Utility.GenNameString("container"), invalidBlobName, false), "get copy state should failed with invalid blob name");
            ExpectedStartsWithErrorMessage(invalidBlobErrorMessage);
        }

        /// <summary>
        /// monitor mulitple copy progress
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     3.	Monitor a list of copying blobs
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateWithNotExistContainerAndBlobTest()
        {
            string srcContainerName = Utility.GenNameString("copy");
            string blobName = Utility.GenNameString("blob");

            string errorMessage = string.Empty;
            Test.Assert(!agent.GetAzureStorageBlobCopyState(srcContainerName, blobName, false), "Get copy state should fail with not existing container");
            errorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", blobName, srcContainerName);
            ExpectedEqualErrorMessage(errorMessage);

            try
            {
                StorageBlob.CloudBlobContainer srcContainer = blobUtil.CreateContainer(srcContainerName);
                Test.Assert(!agent.GetAzureStorageBlobCopyState(srcContainerName, blobName, false), "Get copy state should fail with not existing blob");
                ExpectedEqualErrorMessage(errorMessage);
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainerName);
            }
        }

        /// <summary>
        /// monitor mulitple copy progress
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///    4.	Monitor copying status of the blob in root container
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateFromRootContainerTest()
        {
            StorageBlob.CloudBlobContainer rootContainer = blobUtil.CreateContainer("$root");

            string srcBlobName = Utility.GenNameString("src");
            StorageBlob.ICloudBlob srcBlob = blobUtil.CreateRandomBlob(rootContainer, srcBlobName);
            StorageBlob.ICloudBlob destBlob = blobUtil.CreateBlob(rootContainer, Utility.GenNameString("dest"), srcBlob.BlobType);

            if (destBlob.BlobType == StorageBlob.BlobType.BlockBlob)
            {
                ((StorageBlob.CloudBlockBlob)destBlob).StartCopyFromBlob((StorageBlob.CloudBlockBlob)srcBlob);
            }
            else
            {
                ((StorageBlob.CloudPageBlob)destBlob).StartCopyFromBlob((StorageBlob.CloudPageBlob)srcBlob);
            }

            Test.Assert(agent.GetAzureStorageBlobCopyState("$root", destBlob.Name, true), "Get copy state in $root container should be successed.");
            AssertFinishedCopyState(srcBlob.Uri);
        }

        /// <summary>
        /// monitor copy progress for cross account copy
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     5.	Get the copy status (on-going) on specified blob for cross account copying
        /// This test use the start-copy pipeline. so It also validate the start-copy cmdlet
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateFromCrossAccountCopyTest()
        {
            CloudStorageAccount secondaryAccount = TestBase.GetCloudStorageAccountFromConfig("Secondary");
            object destContext = PowerShellAgent.GetStorageContext(secondaryAccount.ToString(true));
            CloudBlobUtil destBlobUtil = new CloudBlobUtil(secondaryAccount);
            string destContainerName = Utility.GenNameString("secondary");
            StorageBlob.CloudBlobContainer destContainer = destBlobUtil.CreateContainer(destContainerName);
            blobUtil.SetupTestContainerAndBlob();
            //remove the same name container in source storage account, so we could avoid some conflicts.
            blobUtil.RemoveContainer(destContainer.Name);

            try
            {
                Test.Assert(agent.StartAzureStorageBlobCopy(blobUtil.Blob, destContainer.Name, string.Empty, destContext), "Start cross account copy should successed");
                int expectedBlobCount = 1;
                Test.Assert(agent.Output.Count == expectedBlobCount, String.Format("Expected get {0} copy blob, and actually it's {1}", expectedBlobCount, agent.Output.Count));
                StorageBlob.ICloudBlob destBlob = (StorageBlob.ICloudBlob)agent.Output[0]["ICloudBlob"];
                //make sure this context is different from the PowerShell.Context
                object context = agent.Output[0]["Context"];
                Test.Assert(PowerShellAgent.Context != context, "make sure you are using different context for cross account copy");
                Test.Assert(agent.GetAzureStorageBlobCopyState(destBlob, context, true), "Get copy state in dest container should be successed.");
                AssertFinishedCopyState(blobUtil.Blob.Uri);
            }
            finally
            {
                blobUtil.CleanupTestContainerAndBlob();
                destBlobUtil.RemoveContainer(destContainer.Name);
            }
        }

        /// <summary>
        /// monitor copy progress for cross account copy
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     5.	6.	Get the copy status (on-going) on specified blob for Uri copying
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateFromUriTest()
        {
            blobUtil.SetupTestContainerAndBlob();
            string copiedName = Utility.GenNameString("copied");

            //Set the blob permission, so the copy task could directly copy by uri
            StorageBlob.BlobContainerPermissions permission = new StorageBlob.BlobContainerPermissions();
            permission.PublicAccess = StorageBlob.BlobContainerPublicAccessType.Blob;
            blobUtil.Container.SetPermissions(permission);

            try
            {
                Test.Assert(agent.StartAzureStorageBlobCopy(blobUtil.Blob.Uri.ToString(), blobUtil.ContainerName, copiedName, PowerShellAgent.Context), Utility.GenComparisonData("Start copy blob using source uri", true));
                Test.Assert(agent.GetAzureStorageBlobCopyState(blobUtil.ContainerName, copiedName, true), "Get copy state in dest container should be successed.");
                AssertFinishedCopyState(blobUtil.Blob.Uri);
            }
            finally
            {
                blobUtil.CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// monitor copy progress for cross account copy
        /// 8.21	Get-AzureStorageBlobCopyState Positive Functional Cases
        ///     5.	6.	Get the copy status (on-going) on specified blob for Uri copying
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobCopyState)]
        public void GetCopyStateWhenCopyingTest()
        {
            StorageBlob.CloudBlobContainer Container = blobUtil.CreateContainer();
            string ContainerName = Container.Name;
            string BlobName = Utility.GenNameString("blockblob");
            StorageBlob.ICloudBlob Blob = blobUtil.CreateBlockBlob(Container, BlobName);
            
            string uri = Test.Data.Get("BigFileUri");
            Test.Assert(!String.IsNullOrEmpty(uri), string.Format("Big file uri should be not empty, actually it's {0}", uri));

            if (String.IsNullOrEmpty(uri))
            {
                return;
            }

            Blob.StartCopyFromBlob(new Uri(uri));

            int maxMonitorTime = 30; //seconds
            int checkCount = 0;
            int sleepInterval = 1000; //ms

            StorageBlob.CopyStatus status = StorageBlob.CopyStatus.Pending;

            try
            {
                int expectedCopyStateCount = 1;

                do
                {
                    Test.Info(String.Format("{0}th check current copy state", checkCount));
                    Test.Assert(agent.GetAzureStorageBlobCopyState(ContainerName, BlobName, false), "Get copy state in dest container should be successed.");
                    
                    Test.Assert(agent.Output.Count == expectedCopyStateCount, String.Format("Should contain {0} copy state, and actually it's {1}", expectedCopyStateCount, agent.Output.Count));
                    status = (StorageBlob.CopyStatus)agent.Output[0]["Status"];
                    Test.Assert(status == StorageBlob.CopyStatus.Pending, String.Format("Copy status should be Pending, actually it's {0}", status));
                    checkCount++;
                    Thread.Sleep(sleepInterval);
                }
                while (status == StorageBlob.CopyStatus.Pending && checkCount < maxMonitorTime);

                Test.Info("Finish the monitor loop and try to abort copy");

                try
                {
                    Blob.AbortCopy(Blob.CopyState.CopyId);
                }
                catch (StorageException e)
                {
                    //TODO use extension method
                    if (e.RequestInformation != null && e.RequestInformation.HttpStatusCode == 409)
                    {
                        Test.Info("Skip 409 abort conflict exception. Error:{0}", e.Message);
                        Test.Info("Detail Error Message: {0}", e.RequestInformation.HttpStatusMessage);
                    }
                    else
                    {
                        Test.AssertFail(String.Format("Can't abort copy. Error: {0}", e.Message));
                    }
                }

                Test.Assert(agent.GetAzureStorageBlobCopyState(ContainerName, BlobName, false), "Get copy state in dest container should be successed.");
                Test.Assert(agent.Output.Count == expectedCopyStateCount, String.Format("Should contain {0} copy state, and actually it's {1}", expectedCopyStateCount, agent.Output.Count));
                status = (StorageBlob.CopyStatus)agent.Output[0]["Status"];
                Test.Assert(status == StorageBlob.CopyStatus.Aborted, String.Format("Copy status should be Aborted, actually it's {0}", status));
            }
            finally
            {
                blobUtil.RemoveContainer(Container.Name);
            }
        }

        private void AssertFinishedCopyState(Uri SourceUri, int startIndex = 0)
        {
            string expectedSourceUri = CloudBlobUtil.ConvertCopySourceUri(SourceUri.ToString());
            Test.Assert(agent.Output.Count > startIndex, String.Format("Should contain the great than {0} copy state, and actually it's {1}", startIndex, agent.Output.Count));
            string sourceUri = ((Uri)agent.Output[startIndex]["Source"]).ToString();
            Test.Assert(sourceUri.StartsWith(expectedSourceUri), String.Format("source uri should start with {0}, and actualy it's {1}", expectedSourceUri, sourceUri));
            StorageBlob.CopyStatus status = (StorageBlob.CopyStatus)agent.Output[startIndex]["Status"];
            Test.Assert(status != StorageBlob.CopyStatus.Pending, String.Format("Copy status should not be Pending, actually it's {0}", status));
            string copyId = (string)agent.Output[startIndex]["CopyId"];
            Test.Assert(!String.IsNullOrEmpty(copyId), "Copy ID should be not empty");
        }
    }
}
