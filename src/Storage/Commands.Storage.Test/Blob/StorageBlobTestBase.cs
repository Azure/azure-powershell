﻿// ----------------------------------------------------------------------------------
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.Test.Service;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob
{
    /// <summary>
    /// Test base class for storage blob
    /// </summary>
    [TestClass]
    public class StorageBlobTestBase : StorageTestBase
    {
        /// <summary>
        /// Init task id 
        /// </summary>
        public static long InitTaskId = 0;

        /// <summary>
        /// Current blob command
        /// </summary>
        protected StorageCloudBlobCmdletBase CurrentBlobCmd { get; set; }

        protected bool Confirmed = true;

        protected bool ConfirmWriter(string msg1, string msg2, string msg3)
        {
            return Confirmed;
        }

        /// <summary>
        /// Mock blob management
        /// </summary>
        public MockStorageBlobManagement BlobMock
        {
            get;
            set;
        }

        [TestInitialize]
        public void InitMock()
        {
            BlobMock = new MockStorageBlobManagement();
            MockCmdRunTime = new MockCommandRuntime();
            AzureSession.DataStore = new MemoryDataStore();
        }

        [TestCleanup]
        public void CleanMock()
        {
            BlobMock = null;
        }

        /// <summary>
        /// Clean all the test data
        /// </summary>
        private void CleanTestData()
        {
            BlobMock.ContainerList.Clear();
            BlobMock.ContainerPermissions.Clear();
            BlobMock.ContainerBlobs.Clear();
        }

        /// <summary>
        /// Add test containers
        /// </summary>
        public void AddTestContainers()
        {
            CleanTestData();
            string testUri = "http://127.0.0.1/account/test";
            string textUri = "http://127.0.0.1/account/text";
            string publicOffUri = "http://127.0.0.1/account/publicoff";
            string publicBlobUri = "http://127.0.0.1/account/publicblob";
            string publicContainerUri = "http://127.0.0.1/account/publiccontainer";
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(testUri)));
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(textUri)));
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(publicOffUri)));
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(publicBlobUri)));
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(publicContainerUri)));

            BlobContainerPermissions publicOff = new BlobContainerPermissions();
            publicOff.PublicAccess = BlobContainerPublicAccessType.Off;
            BlobMock.ContainerPermissions.Add("publicoff", publicOff);
            BlobContainerPermissions publicBlob = new BlobContainerPermissions();
            publicBlob.PublicAccess = BlobContainerPublicAccessType.Blob;
            BlobMock.ContainerPermissions.Add("publicblob", publicBlob);
            BlobContainerPermissions publicContainer = new BlobContainerPermissions();
            publicContainer.PublicAccess = BlobContainerPublicAccessType.Container;
            BlobMock.ContainerPermissions.Add("publiccontainer", publicContainer);
        }

        /// <summary>
        /// Add test blobs
        /// </summary>
        public void AddTestBlobs()
        {
            CleanTestData();
            string container0Uri = "http://127.0.0.1/account/container0";
            string container1Uri = "http://127.0.0.1/account/container1";
            string container20Uri = "http://127.0.0.1/account/container20";
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(container0Uri)));
            AddContainerBlobs("container0", 0);
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(container1Uri)));
            AddContainerBlobs("container1", 1);
            BlobMock.ContainerList.Add(new CloudBlobContainer(new Uri(container20Uri)));
            AddContainerBlobs("container20", 20);
        }

        /// <summary>
        /// Add some blobs into a container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="count">How many blobs need to be added to the container</param>
        private void AddContainerBlobs(string containerName, int count)
        {
            List<CloudBlob> blobList = null;

            if (BlobMock.ContainerBlobs.ContainsKey(containerName))
            {
                blobList = BlobMock.ContainerBlobs[containerName];
                blobList.Clear();
            }
            else
            {
                blobList = new List<CloudBlob>();
                BlobMock.ContainerBlobs.Add(containerName, blobList);
            }

            string prefix = "blob";
            string uri = string.Empty;
            string endPoint = "http://127.0.0.1/account";

            for(int i = 0; i < count; i++)
            {
                uri = string.Format("{0}/{1}/{2}{3}", endPoint, containerName, prefix, i);
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(uri));
                blobList.Add(blob);
            }
        }

        /// <summary>
        /// Run async command
        /// </summary>
        /// <param name="cmd">Storage command</param>
        /// <param name="asyncAction">Async action</param>
        protected void RunAsyncCommand(Action asyncAction)
        {
            MockCmdRunTime.ResetPipelines();
            CurrentBlobCmd.SetUpMultiThreadEnvironment();
            CurrentBlobCmd.OutputStream.ConfirmWriter = ConfirmWriter;
            asyncAction();
            CurrentBlobCmd.MultiThreadEndProcessing();
        }
    }
}