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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.DataMovement;
using Microsoft.WindowsAzure.Storage.File;
using Xunit;
using PSHFile = Microsoft.WindowsAzure.Commands.Storage.File;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    public class SetAzureStorageFileContentTest : StorageFileTestBase<SetAzureStorageFileContent>
    {
        private string sourceFilePath = Path.GetTempFileName();

        public SetAzureStorageFileContentTest()
        {
            using (var writer = System.IO.File.CreateText(this.sourceFilePath))
            {
                writer.WriteLine("SampleContent");
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingShareNameAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingShareObjectAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingDirectoryAndPathTest()
        {
            UploadFileInternal(
                "share",
                this.sourceFilePath,
                "remoteFile",
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference()),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath),
                    new KeyValuePair<string, object>("Path", "remoteFile")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingDirectoryObjectOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("dir");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetDirectoryReference("dir")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingShareObjectOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadFileUsingShareNameOnlyTest()
        {
            this.MockChannel.SetsAvailableDirectories("");

            UploadFileInternal(
                "share",
                this.sourceFilePath,
                Path.GetFileName(this.sourceFilePath),
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Source", this.sourceFilePath)));
        }

        private void UploadFileInternal(string shareName, string sourceFilePath, string destinationFileName, Action uploadFileAction)
        {
            var mockupTransferManager = new UploadTransferManager(
                (sourcePath, destFile) =>
                {
                    Assert.Equal(destinationFileName, destFile.Name);
                    Assert.Equal(shareName, destFile.Share.Name);
                    Assert.Equal(sourceFilePath, sourcePath);
                });

            TransferManagerFactory.SetCachedTransferManager(mockupTransferManager);

            uploadFileAction();

            mockupTransferManager.ThrowAssertExceptionIfAvailable();
            this.MockCmdRunTime.OutputPipeline.AssertNoObject();
            this.MockCmdRunTime.ErrorStream.AssertNoObject();
        }

        private sealed class UploadTransferManager : MockTransferManager
        {
            private Action<string, CloudFile> validateAction;
            public UploadTransferManager(Action<string, CloudFile> validate)
            {
                validateAction = validate;
            }

            public override Task UploadAsync(string sourcePath, CloudFile destFile, UploadOptions options, TransferContext context, CancellationToken cancellationToken)
            {
                validateAction(sourcePath, destFile);
                return TaskEx.FromResult(true);
            }
        }
    }
}
