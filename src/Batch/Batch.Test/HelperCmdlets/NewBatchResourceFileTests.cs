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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.HelperCmdlets
{
    public class NewBatchResourceFileTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchResourceFileCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchResourceFileTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchResourceFileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchResourceFileWithHttpUrl()
        {
            const string httpUrl = "myurl";
            const string filePath = "mypath";

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSResourceFile> pipeline = new List<PSResourceFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSResourceFile>())).Callback<object>(p => pipeline.Add((PSResourceFile)p));

            cmdlet.HttpUrl = httpUrl;
            cmdlet.FilePath = filePath;

            cmdlet.ExecuteCmdlet();

            Assert.Single(pipeline);
            Assert.Equal(httpUrl, pipeline[0].HttpUrl);
            Assert.Equal(filePath, pipeline[0].FilePath);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchResourceFileWithAutoStorageContainerName()
        {
            const string filePath = "mypath";
            const string containerName = "mycontainer";
            const string blobPrefix = "myprefix";

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSResourceFile> pipeline = new List<PSResourceFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSResourceFile>())).Callback<object>(p => pipeline.Add((PSResourceFile)p));

            cmdlet.AutoStorageContainerName = containerName;
            cmdlet.FilePath = filePath;
            cmdlet.BlobPrefix = blobPrefix;

            cmdlet.ExecuteCmdlet();

            Assert.Single(pipeline);
            Assert.Equal(cmdlet.AutoStorageContainerName, pipeline[0].AutoStorageContainerName);
            Assert.Equal(cmdlet.FilePath, pipeline[0].FilePath);
            Assert.Equal(cmdlet.BlobPrefix, pipeline[0].BlobPrefix);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchResourceFileWithStorageContainerUrl()
        {
            const string filePath = "mypath";
            const string containerUrl = "myurl";
            const string blobPrefix = "myprefix";

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSResourceFile> pipeline = new List<PSResourceFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSResourceFile>())).Callback<object>(p => pipeline.Add((PSResourceFile)p));

            cmdlet.StorageContainerUrl = containerUrl;
            cmdlet.FilePath = filePath;
            cmdlet.BlobPrefix = blobPrefix;

            cmdlet.ExecuteCmdlet();

            Assert.Single(pipeline);
            Assert.Equal(cmdlet.StorageContainerUrl, pipeline[0].StorageContainerUrl);
            Assert.Equal(cmdlet.FilePath, pipeline[0].FilePath);
            Assert.Equal(cmdlet.BlobPrefix, pipeline[0].BlobPrefix);
        }
    }
}
