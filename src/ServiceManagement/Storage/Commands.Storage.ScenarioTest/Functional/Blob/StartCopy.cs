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
using System.Linq;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional tests for Start-CopyBlob
    /// </summary>
    [TestClass]
    class StartCopy : TestBase
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
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Positive Functional Cases
        ///    3. Cross account copy and Properties and metadata could be copied correctly
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCrossAccountCopyWithMetaAndPropertiesTest()
        {
            blobUtil.SetupTestContainerAndBlob();

            try
            {
                CloudStorageAccount secondaryAccount = TestBase.GetCloudStorageAccountFromConfig("Secondary");
                object destContext = PowerShellAgent.GetStorageContext(secondaryAccount.ToString(true));
                CloudBlobUtil destBlobUtil = new CloudBlobUtil(secondaryAccount);
                string destContainerName = Utility.GenNameString("secondary");
                CloudBlobContainer destContainer = destBlobUtil.CreateContainer(destContainerName);
                AssertCopyBlobCrossContainer(blobUtil.Blob, destContainer, string.Empty, destContext);
                destBlobUtil.RemoveContainer(destContainer.Name);
            }
            finally
            {
                blobUtil.CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Positive Functional Cases
        ///    2.	Root container case
        ///     1.	Root -> Non-Root
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyFromRootToNonRootContainerTest()
        {
            CloudBlobContainer rootContainer = blobUtil.CreateContainer("$root");
            
            string srcBlobName = Utility.GenNameString("src");
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(rootContainer, srcBlobName);
            CloudBlobContainer destContainer = blobUtil.CreateContainer();

            try
            {
                AssertCopyBlobCrossContainer(srcBlob, destContainer, Utility.GenNameString("dest"), PowerShellAgent.Context);
            }
            finally
            {
                //Keep the $root container since it may cause many confict exceptions
                blobUtil.RemoveContainer(destContainer.Name);
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Positive Functional Cases
        ///    2.	Root container case
        ///     2.	Non-Root -> Root
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyFromNonRootToRootContainerTest()
        {
            CloudBlobContainer rootContainer = blobUtil.CreateContainer("$root");

            string srcBlobName = Utility.GenNameString("src");
            CloudBlobContainer srcContainer = blobUtil.CreateContainer();
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(srcContainer, srcBlobName);

            try
            {
                AssertCopyBlobCrossContainer(srcBlob, rootContainer, string.Empty, PowerShellAgent.Context);
            }
            finally
            {
                //Keep the $root container since it may cause many confict exceptions
                blobUtil.RemoveContainer(srcContainer.Name);
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Positive Functional Cases
        ///    2.	Root container case
        ///     3.	Root -> Root
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyFromRootToRootContainerTest()
        {
            CloudBlobContainer rootContainer = blobUtil.CreateContainer("$root");

            string srcBlobName = Utility.GenNameString("src");
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(rootContainer, srcBlobName);

            try
            {
                AssertCopyBlobCrossContainer(srcBlob, rootContainer, Utility.GenNameString("dest"), PowerShellAgent.Context);
            }
            finally
            {
                //Keep the $root container since it may cause many confict exceptions
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Positive Functional Cases
        ///    2.	Root container case
        ///     3.	Root -> Root
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyFromSnapshotTest()
        {
            CloudBlobContainer srcContainer = blobUtil.CreateContainer();
            CloudBlobContainer destContainer = blobUtil.CreateContainer();

            string srcBlobName = Utility.GenNameString("src");
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(srcContainer, srcBlobName);
            ICloudBlob snapshot = default(ICloudBlob);

            if (srcBlob.BlobType == Microsoft.WindowsAzure.Storage.Blob.BlobType.BlockBlob)
            {
                snapshot = ((CloudBlockBlob)srcBlob).CreateSnapshot();
            }
            else
            {
                snapshot = ((CloudPageBlob)srcBlob).CreateSnapshot();
            }

            try
            {
                Func<bool> StartCopyUsingICloudBlob = delegate()
                {
                    return agent.StartAzureStorageBlobCopy(snapshot, destContainer.Name, string.Empty, PowerShellAgent.Context);
                };

                ICloudBlob destBlob = AssertCopyBlobCrossContainer(snapshot, destContainer, string.Empty, PowerShellAgent.Context);
                Test.Assert(snapshot.SnapshotTime != null, "The snapshot time of destination blob should be not null");
                Test.Assert(destBlob.SnapshotTime == null, "The snapshot time of destination blob should be null");
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainer.Name);
                blobUtil.RemoveContainer(destContainer.Name);
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Negative Functional Cases
        ///   5.	Copy blob to itself
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyFromSelfTest()
        {
            CloudBlobContainer srcContainer = blobUtil.CreateContainer();

            string srcBlobName = Utility.GenNameString("src");
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(srcContainer, srcBlobName);

            try
            {
                Test.Assert(!agent.StartAzureStorageBlobCopy(srcBlob.Container.Name, srcBlob.Name, srcContainer.Name, string.Empty, PowerShellAgent.Context), "blob copy should failed when copy itself");
                string errorMessage = "Source and destination cannot be the same.";
                Test.Assert(errorMessage == agent.ErrorMessages[0], String.Format("Expected error message: {0}, and actually it's {1}", errorMessage, agent.ErrorMessages[0]));
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainer.Name);
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Negative Functional Cases
        ///     1.	Copy the blob with invalid container name or blob name
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyWithInvalidNameTest()
        {
            string invalidContainerName = "Invalid";
            int maxBlobNameLength = 1024;
            string invalidBlobName = new string('a', maxBlobNameLength + 1);
            string invalidContainerErrorMessage = String.Format("Container name '{0}' is invalid.", invalidContainerName);
            string invalidBlobErrorMessage = String.Format("Blob name '{0}' is invalid.", invalidBlobName);
            Test.Assert(!agent.StartAzureStorageBlobCopy(invalidContainerName, Utility.GenNameString("blob"), Utility.GenNameString("container"), Utility.GenNameString("blob")), "Start copy should failed with invalid src container name");
            ExpectedStartsWithErrorMessage(invalidContainerErrorMessage);
            Test.Assert(!agent.StartAzureStorageBlobCopy(Utility.GenNameString("container"), Utility.GenNameString("blob"), invalidContainerName, Utility.GenNameString("blob")), "Start copy should failed with invalid dest container name");
            ExpectedStartsWithErrorMessage(invalidContainerErrorMessage);
            Test.Assert(!agent.StartAzureStorageBlobCopy(Utility.GenNameString("container"), invalidBlobName, Utility.GenNameString("container"), Utility.GenNameString("blob")), "Start copy should failed with invalid src blob name");
            ExpectedStartsWithErrorMessage(invalidBlobErrorMessage);
            Test.Assert(!agent.StartAzureStorageBlobCopy(Utility.GenNameString("container"), Utility.GenNameString("blob"), Utility.GenNameString("container"), invalidBlobName), "Start copy should failed with invalid dest blob name");
            ExpectedStartsWithErrorMessage(invalidBlobErrorMessage);
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Negative Functional Cases
        ///     2.	Copy the blob that the container doesn't exist
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyWithNotExistsContainerAndBlobTest()
        {
            string srcContainerName = Utility.GenNameString("copy");
            string destContainerName = Utility.GenNameString("dest");
            string blobName = Utility.GenNameString("blob");

            string errorMessage = string.Empty;
            Test.Assert(!agent.StartAzureStorageBlobCopy(srcContainerName, blobName, destContainerName, string.Empty), "Start copy should failed with not existing src container");
            errorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", blobName, srcContainerName);
            ExpectedEqualErrorMessage(errorMessage);

            try
            {
                CloudBlobContainer srcContainer = blobUtil.CreateContainer(srcContainerName);
                Test.Assert(!agent.StartAzureStorageBlobCopy(srcContainerName, blobName, destContainerName, string.Empty), "Start copy should failed with not existing blob");
                ExpectedEqualErrorMessage(errorMessage);
                blobUtil.CreateRandomBlob(srcContainer, blobName);
                Test.Assert(!agent.StartAzureStorageBlobCopy(srcContainerName, blobName, destContainerName, string.Empty), "Start copy should failed with not existing dest container");
                ExpectedContainErrorMessage("The specified container does not exist.");
            }
            finally
            {
                blobUtil.RemoveContainer(srcContainerName);
            }
        }

        /// <summary>
        /// Cross storage account copy
        /// 8.20	Start-AzureStorageBlob Negative Functional Cases
        ///     4.	If the existing destination blob type is not same as BlobType parameter
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyWithMismatchedBlobTypeTest()
        {
            CloudBlobContainer container = blobUtil.CreateContainer();
            ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, Utility.GenNameString("block"));
            ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, Utility.GenNameString("page"));

            try
            {
                Test.Assert(!agent.StartAzureStorageBlobCopy(blockBlob, container.Name, pageBlob.Name), "Start copy should failed with mismatched blob type");
                ExpectedEqualErrorMessage("Cannot overwrite an existing PageBlob with a BlockBlob.");
                Test.Assert(!agent.StartAzureStorageBlobCopy(container.Name, pageBlob.Name, container.Name, blockBlob.Name), "Start copy should failed with mismatched blob type");
                ExpectedEqualErrorMessage("Cannot overwrite an existing BlockBlob with a PageBlob.");
            }
            finally
            {
                blobUtil.RemoveContainer(container.Name);
            }
        }

        /// <summary>
        /// Copy to an existing blob without force parameter
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.StartCopyBlob)]
        public void StartCopyToExistsBlobWithoutForce()
        {
            CloudBlobContainer container = blobUtil.CreateContainer();
            string srcBlobName = Utility.GenNameString("src");
            ICloudBlob srcBlob = blobUtil.CreateRandomBlob(container, srcBlobName);
            string destBlobName = Utility.GenNameString("dest");
            ICloudBlob destBlob = blobUtil.CreateRandomBlob(container, destBlobName);
            string filePath = FileUtil.GenerateOneTempTestFile();

            try
            {
                Test.Assert(!agent.StartAzureStorageBlobCopy(srcBlob, container.Name, destBlob.Name, null, false), "copy to existing blob without force parameter should fail");
                ExpectedContainErrorMessage(ConfirmExceptionMessage);
                srcBlob.FetchAttributes();
                destBlob.FetchAttributes();
                ExpectNotEqual(srcBlob.Properties.ContentMD5, destBlob.Properties.ContentMD5, "content md5");
            }
            finally
            {
                blobUtil.RemoveContainer(container);
                FileUtil.RemoveFile(filePath);
            }
        }

        private ICloudBlob AssertCopyBlobCrossContainer(ICloudBlob srcBlob, CloudBlobContainer destContainer, string destBlobName, object destContext, Func<bool> StartFunc = null)
        {
            if (StartFunc == null)
            {
                Test.Assert(agent.StartAzureStorageBlobCopy(srcBlob.Container.Name, srcBlob.Name, destContainer.Name, destBlobName, destContext), "blob copy should start sucessfully");
            }
            else
            {
                Test.Assert(StartFunc(), "blob copy should start sucessfully");
            }

            int expectedBlobCount = 1;
            Test.Assert(agent.Output.Count == expectedBlobCount, String.Format("Expected get {0} copy state, and actually it's {1}", expectedBlobCount, agent.Output.Count));
            ICloudBlob destBlob = (ICloudBlob)agent.Output[0]["ICloudBlob"];
            string expectedBlobName = destBlobName;
            
            if(string.IsNullOrEmpty(expectedBlobName))
            {
                expectedBlobName = srcBlob.Name;
            }

            Test.Assert(expectedBlobName == destBlob.Name, string.Format("Expected destination blob name is {0}, and actually it's {1}", expectedBlobName, destBlob.Name));
            Test.Assert(CloudBlobUtil.WaitForCopyOperationComplete(destBlob), "Copy Operation should finished");
            destBlob.FetchAttributes();
            string expectedSourceUri = CloudBlobUtil.ConvertCopySourceUri(srcBlob.Uri.ToString());
            string sourceUri = destBlob.CopyState.Source.ToString();
            Test.Assert(sourceUri.StartsWith(expectedSourceUri), String.Format("source uri should start with {0}, and actualy it's {1}", expectedSourceUri, sourceUri));
            Test.Assert(destBlob.Metadata.Count > 0, "destination blob should contain meta data");
            Test.Assert(destBlob.Metadata.SequenceEqual(srcBlob.Metadata), "Copied blob's meta data should be equal with origin metadata");
            Test.Assert(destBlob.Properties.ContentEncoding == srcBlob.Properties.ContentEncoding, String.Format("expected content encoding is {0}, and actually it's {1}", srcBlob.Properties.ContentEncoding, destBlob.Properties.ContentEncoding));

            return destBlob;
        }
    }
}
