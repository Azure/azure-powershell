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
using System.Threading;
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional test for Get-AzureStorageBlob
    /// </summary>
    [TestClass]
    class GetBlob : TestBase
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
        /// get blobs in specified container
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     3.	Get an existing blob using the container name specified by the param
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetMultipleBlobByName()
        {
            string containerName = Utility.GenNameString("container");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<string> blobNames = new List<string>();
                int count = random.Next(1, 5);

                for (int i = 0; i < count; i++)
                {
                    blobNames.Add(Utility.GenNameString("blob"));
                }

                List<ICloudBlob> blobs = blobUtil.CreateRandomBlob(container, blobNames);

                Test.Assert(agent.GetAzureStorageBlob(string.Empty, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(blobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get one blob in specified container
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     3.	Get an existing blob using the container name specified by the param
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobByName()
        {
            string containerName = Utility.GenNameString("container");

            try
            {
                string pageBlobName = Utility.GenNameString("page");
                string blockBlobName = Utility.GenNameString("block");
                CloudBlobContainer container = blobUtil.CreateContainer(containerName);

                List<string> blobNames = new List<string>();
                int count = random.Next(1, 5);

                for (int i = 0; i < count; i++)
                {
                    blobNames.Add(Utility.GenNameString("blob"));
                }

                List<ICloudBlob> blobs = blobUtil.CreateRandomBlob(container, blobNames);
                ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);

                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<ICloudBlob>() { pageBlob });

                ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<ICloudBlob>() { pageBlob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get specified blob by container pipeline
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     4.	Get an existing blob using the container object retrieved by Get-AzureContainer
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobByContainerPipeline()
        { 
            //TODO add string.empty as the blob name
            //TODO add invalid container pipeline
            string containerName = Utility.GenNameString("container");
            string blobName = Utility.GenNameString("blob");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                ICloudBlob blob = blobUtil.CreatePageBlob(container, blobName);
                string cmd = String.Format("Get-AzureStorageContainer {0}", containerName);
                ((PowerShellAgent)agent).AddPipelineScript(cmd);

                Test.Assert(agent.GetAzureStorageBlob(blobName, string.Empty), Utility.GenComparisonData("Get-AzureStorageContainer | Get-AzureStorageBlob", true));
                Test.Assert(agent.Output.Count == 1, String.Format("Want to retrieve {0} page blob, but retrieved {1} page blobs", 1, agent.Output.Count));

                agent.OutputValidation(new List<ICloudBlob>() { blob });

                blobName = Utility.GenNameString("blob");
                blob = blobUtil.CreateBlockBlob(container, blobName);
                ((PowerShellAgent)agent).AddPipelineScript(cmd);

                Test.Assert(agent.GetAzureStorageBlob(blobName, string.Empty), Utility.GenComparisonData("Get-AzureStorageContainer | Get-AzureStorageBlob", true));
                Test.Assert(agent.Output.Count == 1, String.Format("Want to retrieve {0} block blob, but retrieved {1} block blobs", 1, agent.Output.Count));

                agent.OutputValidation(new List<ICloudBlob>() { blob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get specified blob by container pipeline
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     5.	Validate that all the blobs in one container can be enumerated
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetAllBlobsInSpecifiedContainer()
        {
            string containerName = Utility.GenNameString("container");
            string blobName = Utility.GenNameString("blob");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                int count = random.Next(1, 5);
                List<string> blobNames = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    blobNames.Add(Utility.GenNameString("blob"));
                }

                List<ICloudBlob> blobs = blobUtil.CreateRandomBlob(container, blobNames);

                Test.Assert(agent.GetAzureStorageBlob(string.Empty, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with empty blob name", true));
                Test.Assert(agent.Output.Count == blobNames.Count, String.Format("Want to retrieve {0} blobs, but retrieved {1} blobs", blobNames.Count, agent.Output.Count));

                agent.OutputValidation(blobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blobs by prefix
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     6.	Get a list of blobs by using Prefix parameter
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobsByPrefix()
        {
            string containerName = Utility.GenNameString("container");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<string> blobNames = new List<string>();

                int count = random.Next(2, 4);
                for (int i = 0; i < count; i++)
                {
                    blobNames.Add(Utility.GenNameString("blobprefix"));
                }

                List<ICloudBlob> blobs = blobUtil.CreateRandomBlob(container, blobNames);

                Test.Assert(agent.GetAzureStorageBlobByPrefix("blobprefix", containerName), Utility.GenComparisonData("Get-AzureStorageBlob with prefix", true));
                Test.Assert(agent.Output.Count == blobs.Count, String.Format("Expect to retrieve {0} blobs, but retrieved {1} blobs", blobs.Count, agent.Output.Count));

                agent.OutputValidation(blobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blobs by wildcard
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     7.	Get a list of blobs by using wildcards in the name
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobByWildCard()
        {
            string containerName = Utility.GenNameString("container");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<string> prefixes = new List<string>();
                List<string> noprefixes = new List<string>();

                int count = random.Next(2, 4);
                for (int i = 0; i < count; i++)
                {
                    prefixes.Add(Utility.GenNameString("prefix"));
                }

                count = random.Next(2, 4);
                for (int i = 0; i < count; i++)
                {
                    noprefixes.Add(Utility.GenNameString("noprefix"));
                }

                List<ICloudBlob> prefixBlobs = blobUtil.CreateRandomBlob(container, prefixes);
                List<ICloudBlob> noprefixBlobs = blobUtil.CreateRandomBlob(container, noprefixes);

                Test.Assert(agent.GetAzureStorageBlob("prefix*", containerName), Utility.GenComparisonData("Get-AzureStorageBlob with wildcard", true));
                Test.Assert(agent.Output.Count == prefixBlobs.Count, String.Format("Expect to retrieve {0} blobs, actually retrieved {1} blobs", prefixBlobs.Count, agent.Output.Count));

                agent.OutputValidation(prefixBlobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get snapshot blobs
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     8.	Validate that all the blob snapshots can be enumerated
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetSnapshotBlobs()
        {
            string containerName = Utility.GenNameString("container");
            string pageBlobName = Utility.GenNameString("page");
            string blockBlobName = Utility.GenNameString("block");
            Test.Info("Create test container and blobs");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);
                ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                List<ICloudBlob> blobs = new List<ICloudBlob>();
                pageBlob.FetchAttributes();
                blockBlob.FetchAttributes();

                int minSnapshot = 1;
                int maxSnapshot = 5;
                int count = random.Next(minSnapshot, maxSnapshot);
                int snapshotInterval = 1 * 1000;

                Test.Info("Create random snapshot for specified blobs");

                for (int i = 0; i < count; i++)
                {
                    CloudBlockBlob snapshot = ((CloudBlockBlob)blockBlob).CreateSnapshot();
                    snapshot.FetchAttributes();
                    blobs.Add(snapshot);
                    Thread.Sleep(snapshotInterval);
                }

                blobs.Add(blockBlob);
                count = random.Next(minSnapshot, maxSnapshot);
                for (int i = 0; i < count; i++)
                {
                    CloudPageBlob snapshot = ((CloudPageBlob)pageBlob).CreateSnapshot();
                    snapshot.FetchAttributes();
                    blobs.Add(snapshot);
                    Thread.Sleep(snapshotInterval);
                }

                blobs.Add(pageBlob);

                Test.Assert(agent.GetAzureStorageBlob(string.Empty, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with snapshot blobs", true));
                Test.Assert(agent.Output.Count == blobs.Count, String.Format("Expect to retrieve {0} blobs, actually retrieved {1} blobs", blobs.Count, agent.Output.Count));
                agent.OutputValidation(blobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blob with lease
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     9.	Validate that the lease data could be listed correctly
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobWithLease()
        {
            string containerName = Utility.GenNameString("container");
            string pageBlobName = Utility.GenNameString("page");
            string blockBlobName = Utility.GenNameString("block");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);
                ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                ((CloudPageBlob)pageBlob).AcquireLease(null, string.Empty);
                ((CloudBlockBlob)blockBlob).AcquireLease(null, string.Empty);
                pageBlob.FetchAttributes();
                blockBlob.FetchAttributes();

                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with lease", true));
                agent.OutputValidation(new List<ICloudBlob>() { pageBlob });

                Test.Assert(agent.GetAzureStorageBlob(blockBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with lease", true));
                agent.OutputValidation(new List<ICloudBlob>() { blockBlob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blob with lease
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     10.	Write Metadata to the specific blob Get the Metadata from the specific blob
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobWithMetadata()
        {
            string containerName = Utility.GenNameString("container");
            string pageBlobName = Utility.GenNameString("page");
            string blockBlobName = Utility.GenNameString("block");
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);
                ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                pageBlob.Metadata.Add(Utility.GenNameString("GetBlobWithMetadata"), Utility.GenNameString("GetBlobWithMetadata"));
                pageBlob.SetMetadata();
                blockBlob.Metadata.Add(Utility.GenNameString("GetBlobWithMetadata"), Utility.GenNameString("GetBlobWithMetadata"));
                blockBlob.SetMetadata();

                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with metadata", true));
                Test.Assert(agent.Output.Count == 1, String.Format("Expect to retrieve {0} blobs, but retrieved {1} blobs", 1, agent.Output.Count));
                agent.OutputValidation(new List<ICloudBlob>() { pageBlob });

                Test.Assert(agent.GetAzureStorageBlob(blockBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with metadata", true));
                Test.Assert(agent.Output.Count == 1, String.Format("Expect to retrieve {0} blobs, but retrieved {1} blobs", 1, agent.Output.Count));
                agent.OutputValidation(new List<ICloudBlob>() { blockBlob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blob in subdirectory
        /// 8.12	Get-AzureStorageBlob Positive Functional Cases
        ///     11.	Validate that blobs with a sub directory path could also be listed
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetBlobInSubdirectory()
        {
            //TODO add test cases for special characters
            string containerName = Utility.GenNameString("container");
            string blobName = Utility.GenNameString("blob");
            string subBlobName = Utility.GenNameString(string.Format("{0}/",blobName));
            string subsubBlobName = Utility.GenNameString(string.Format("{0}/", subBlobName));
            List<string> blobNames = new List<string>
            {
                blobName, subBlobName, subsubBlobName
            };

            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<ICloudBlob> blobs = blobUtil.CreateRandomBlob(container, blobNames);

                Test.Assert(agent.GetAzureStorageBlob(string.Empty, containerName), Utility.GenComparisonData("Get-AzureStorageBlob in sub directory", true));
                Test.Assert(agent.Output.Count == blobs.Count, String.Format("Expect to retrieve {0} blobs, but retrieved {1} blobs", blobs.Count, agent.Output.Count));

                agent.OutputValidation(blobs);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// get blob in subdirectory
        /// 8.12	Get-AzureStorageBlob Negative Functional Cases
        ///     1.	Get a non-existing blob 
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlob)]
        public void GetNonExistingBlob()
        {
            string containerName = Utility.GenNameString("container");
            string blobName = Utility.GenNameString("blob");
            List<ICloudBlob> blobs = new List<ICloudBlob>();
            CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                ICloudBlob blob = blobUtil.CreatePageBlob(container, blobName);

                string notExistingBlobName = "notexistingblob";
                Test.Assert(!agent.GetAzureStorageBlob(notExistingBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob with not existing blob", false));
                Test.Assert(agent.ErrorMessages.Count == 1, "only throw an exception");
                Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Can not find blob '{0}' in container '{1}'.", notExistingBlobName, containerName)), agent.ErrorMessages[0]);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }
    }
}
