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
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    [TestClass]
    public class SetAzureStorageFileContentTest : StorageFileTestBase<SetAzureStorageFileContent>
    {
        private string sourceFilePath = Path.GetTempFileName();

        [TestInitialize]
        public void UploadInitialize()
        {
            using (var writer = System.IO.File.CreateText(this.sourceFilePath))
            {
                writer.WriteLine("SampleContent");
            }
        }

        [TestCleanup]
        public void UploadCleanup()
        {
            if (System.IO.File.Exists(this.sourceFilePath))
            {
                System.IO.File.Delete(this.sourceFilePath);
            }
        }

        [TestMethod]
        public void UploadFileUsingShareNameAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [TestMethod]
        public void UploadFileUsingShareObjectAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [TestMethod]
        public void UploadFileUsingDirectoryAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference()),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [TestMethod]
        public void UploadFileUsingDirectoryObjectOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("dir");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetDirectoryReference("dir")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        [TestMethod]
        public void UploadFileUsingShareObjectOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        [TestMethod]
        public void UploadFileUsingShareNameOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        private void UploadFileInternal(string shareName, string sourceFilePath, string destinationFileName, Action uploadFileAction)
        {
            var mockupRunner = new MockTransferJobRunner(
                job =>
                {
                    Assert.IsTrue(job is FileUploadJob, "The transfer job must be an instance of FileUploadJob.");
                    var uploadJob = job as FileUploadJob;
                    Assert.AreEqual(destinationFileName, uploadJob.DestFile.Name, "Destination file name validation failed.");
                    Assert.AreEqual(shareName, uploadJob.DestFile.Share.Name, "Share validation failed.");
                    Assert.AreEqual(sourceFilePath, uploadJob.SourcePath, "Source file validation failed.");
                    return TaskEx.FromResult(true);
                });

            TransferJobRunnerFactory.SetCachedRunner(mockupRunner);

            uploadFileAction();

            mockupRunner.ThrowAssertExceptionIfAvailable();
            this.MockCmdRunTime.OutputPipeline.AssertNoObject();
            this.MockCmdRunTime.ErrorStream.AssertNoObject();
        }
    }
}
