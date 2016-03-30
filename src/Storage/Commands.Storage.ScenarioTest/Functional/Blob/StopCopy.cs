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
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    [TestClass]
    class StopCopy : TestBase
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void SetBlobContentClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// Stop copy in root container
        /// 8.22	Stop-AzureStorageBlobCopy
        ///     1.	Stop the copy task on the blob in root container
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StopCopyBlob)]
        public void StopCopyInRootContainerTest()
        {
            CloudBlobContainer rootContainer = blobUtil.CreateContainer("$root");
            string srcBlobName = Utility.GenNameString("src");
            //We could only use block blob to copy from external uri
            ICloudBlob srcBlob = blobUtil.CreateBlockBlob(rootContainer, srcBlobName);
            CopyBigFileToBlob(srcBlob);
            AssertStopPendingCopyOperationTest(srcBlob);
        }

        /// <summary>
        /// Stop copy using blob pipeline
        /// 8.22	Stop-AzureStorageBlobCopy
        ///   2.	Stop a list of copying blobs
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StopCopyBlob)]
        public void StopCopyUsingBlobPipelineTest()
        {
            CloudBlobContainer container = blobUtil.CreateContainer();
            int count = random.Next(1, 5);
            List<string> blobNames = new List<string>();
            List<ICloudBlob> blobs = new List<ICloudBlob>();

            for (int i = 0; i < count; i++)
            {
                //We could only use block blob to copy from external uri
                blobs.Add(blobUtil.CreateBlockBlob(container, Utility.GenNameString("blob")));
            }

            try
            {
                foreach (ICloudBlob blob in blobs)
                {
                    CopyBigFileToBlob(blob);
                }

                ((PowerShellAgent)agent).AddPipelineScript(String.Format("Get-AzureStorageBlob -Container {0}", container.Name));
                string copyId = "*";
                bool force = true;
                Test.Assert(agent.StopAzureStorageBlobCopy(string.Empty, string.Empty, copyId, force), "Stop multiple copy operations using blob pipeline should be successful");
                int expectedOutputCount = blobs.Count;
                Test.Assert(agent.Output.Count == expectedOutputCount, String.Format("Should return {0} message, and actually it's {1}", expectedOutputCount, agent.Output.Count));

                for (int i = 0; i < expectedOutputCount; i++)
                {
                    blobs[i].FetchAttributes();
                    Test.Assert(blobs[i].CopyState.Status == CopyStatus.Aborted, String.Format("The copy status should be aborted, actually it's {0}", blobs[i].CopyState.Status));
                }
            }
            finally
            {
                blobUtil.RemoveContainer(container.Name);
            }
        }

        /// <summary>
        /// Unit test for invalid blob or container name.
        /// 8.20	Stop-AzureStorageBlobCopy Negative Functional Cases
        ///     1.	Stop the copy task on invalid container name and blob name
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StopCopyBlob)]
        public void StopCopyWithInvalidNameTest()
        {
            string invalidContainerName = "Invalid";
            int maxBlobNameLength = 1024;
            string invalidBlobName = new string('a', maxBlobNameLength + 1);
            string invalidContainerErrorMessage = String.Format("Container name '{0}' is invalid.", invalidContainerName);
            string invalidBlobErrorMessage = String.Format("Blob name '{0}' is invalid.", invalidBlobName);
            string copyId = "*";
            Test.Assert(!agent.StopAzureStorageBlobCopy(invalidContainerName, Utility.GenNameString("blob"), copyId, false), "Stop copy should failed with invalid container name");
            ExpectedStartsWithErrorMessage(invalidContainerErrorMessage);
            Test.Assert(!agent.StopAzureStorageBlobCopy(Utility.GenNameString("container"), invalidBlobName, copyId, false), "Start copy should failed with invalid blob name");
            ExpectedStartsWithErrorMessage(invalidBlobErrorMessage);
        }

        /// <summary>
        /// Stop the copy task on a not existing container and blob
        /// 8.22	Stop-CopyAzureStorageBlob Negative Functional Cases
        ///    2. Stop the copy task on a not existing container and blob
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StopCopyBlob)]
        public void StopCopyWithNotExistsContainerAndBlobTest()
        {
            string srcContainerName = Utility.GenNameString("copy");
            string blobName = Utility.GenNameString("blob");
            string copyId = Guid.NewGuid().ToString();
            string errorMessage = string.Empty;
            Test.Assert(!agent.StopAzureStorageBlobCopy(srcContainerName, blobName, copyId, false), "Stop copy should failed with not existing src container");
            errorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", blobName, srcContainerName);
            ExpectedEqualErrorMessage(errorMessage);

            try
            {
                CloudBlobContainer srcContainer = blobUtil.CreateContainer(srcContainerName);
                Test.Assert(!agent.StopAzureStorageBlobCopy(srcContainerName, blobName, copyId, false), "Stop copy should failed with not existing src container");
                errorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", blobName, srcContainerName);
                ExpectedEqualErrorMessage(errorMessage);
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainerName);
            }
        }

        private void AssertStopPendingCopyOperationTest(ICloudBlob blob)
        {
            Test.Assert(blob.CopyState.Status == CopyStatus.Pending, String.Format("The copy status should be pending, actually it's {0}", blob.CopyState.Status));
            string copyId = "*";
            bool force = true;
            Test.Assert(agent.StopAzureStorageBlobCopy(blob.Container.Name, blob.Name, copyId, force), "Stop copy operation should be successed");
            blob.FetchAttributes();
            Test.Assert(blob.CopyState.Status == CopyStatus.Aborted, String.Format("The copy status should be aborted, actually it's {0}", blob.CopyState.Status));
            int expectedOutputCount = 1;
            Test.Assert(agent.Output.Count == expectedOutputCount, String.Format("Should return {0} message, and actually it's {1}", expectedOutputCount, agent.Output.Count));
        }

        private void CopyBigFileToBlob(ICloudBlob blob)
        {
            string uri = Test.Data.Get("BigFileUri");
            Test.Assert(!String.IsNullOrEmpty(uri), string.Format("Big file uri should be not empty, actually it's {0}", uri));
            
            if (String.IsNullOrEmpty(uri))
            {
                return;
            }
            
            Test.Info(String.Format("Copy Big file to blob '{0}'", blob.Name));
            blob.StartCopyFromBlob(new Uri(uri));
            Test.Assert(blob.CopyState.Status == CopyStatus.Pending, String.Format("The copy status should be pending, actually it's {0}", blob.CopyState.Status));
        }
    }
}
