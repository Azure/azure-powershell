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
    public class GetAzureStorageFileContentTest : StorageFileTestBase<GetAzureStorageFileContent>
    {
        private string destinationFilePath;

        private string destinationPath;

        public GetAzureStorageFileContentTest()
        {
            this.destinationFilePath = Path.GetTempFileName();
            this.destinationPath = Path.GetTempPath();

            if (System.IO.File.Exists(this.destinationFilePath))
            {
                System.IO.File.Delete(this.destinationFilePath);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFileUsingShareNameAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFileUsingShareObjectAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFileUsingDirectoryAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference()),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFileUsingFileObjectToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.FileParameterSetName,
                    new KeyValuePair<string, object>("File", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetFileReference("remoteFile")),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFileUsingFileObjectToLocalDirectoryTest()
        {
            this.destinationFilePath = Path.Combine(this.destinationPath, "remoteFile");
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    PSHFile.Constants.FileParameterSetName,
                    new KeyValuePair<string, object>("File", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetFileReference("remoteFile")),
                    new KeyValuePair<string, object>("Destination", this.destinationPath)));
        }

        private void DownloadFileInternal(string shareName, string fileName, string destination, Action downloadFileAction)
        {
            var mockupTransferManager = new DownloadTransferManager(
            (sourceFile, destPath) =>
                {
                    Assert.Equal(destination, destPath);
                    Assert.Equal(shareName, sourceFile.Share.Name);
                    Assert.Equal(fileName, sourceFile.Name);
                });

            TransferManagerFactory.SetCachedTransferManager(mockupTransferManager);

            downloadFileAction();

            mockupTransferManager.ThrowAssertExceptionIfAvailable();
            this.MockCmdRunTime.OutputPipeline.AssertNoObject();
        }

        private sealed class DownloadTransferManager : MockTransferManager
        {
            private Action<CloudFile, string> validateAction;

            public DownloadTransferManager(Action<CloudFile, string> validate)
            {
                validateAction = validate;
            }

            public override Task DownloadAsync(CloudFile sourceFile, string destFilePath, DownloadOptions options, TransferContext context, CancellationToken cancellationToken)
            {
                validateAction(sourceFile, destFilePath);
                return TaskEx.FromResult(true);
            }
        }
    }
}
