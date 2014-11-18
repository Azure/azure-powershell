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
    public class GetAzureStorageFileContentTest : StorageFileTestBase<GetAzureStorageFileContent>
    {
        private string destinationFilePath;

        private string destinationPath;

        [TestInitialize]
        public void DownloadInitialize()
        {
            this.destinationFilePath = Path.GetTempFileName();
            this.destinationPath = Path.GetTempPath();

            if (System.IO.File.Exists(this.destinationFilePath))
            {
                System.IO.File.Delete(this.destinationFilePath);
            }
        }

        [TestCleanup]
        public void DownloadCleanup()
        {
            if (System.IO.File.Exists(this.destinationFilePath))
            {
                System.IO.File.Delete(this.destinationFilePath);
            }
        }

        [TestMethod]
        public void DownloadFileUsingShareNameAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [TestMethod]
        public void DownloadFileUsingShareObjectAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [TestMethod]
        public void DownloadFileUsingDirectoryAndPathToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference()),
                    new KeyValuePair<string, object>("Path", "remoteFile"),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [TestMethod]
        public void DownloadFileUsingFileObjectToLocalFileTest()
        {
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    Constants.FileParameterSetName,
                    new KeyValuePair<string, object>("File", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetFileReference("remoteFile")),
                    new KeyValuePair<string, object>("Destination", this.destinationFilePath)));
        }

        [TestMethod]
        public void DownloadFileUsingFileObjectToLocalDirectoryTest()
        {
            this.destinationFilePath = Path.Combine(this.destinationPath, "remoteFile");
            DownloadFileInternal(
                "share",
                "remoteFile",
                this.destinationFilePath,
                () => this.CmdletInstance.RunCmdlet(
                    Constants.FileParameterSetName,
                    new KeyValuePair<string, object>("File", this.MockChannel.GetShareReference("share").GetRootDirectoryReference().GetFileReference("remoteFile")),
                    new KeyValuePair<string, object>("Destination", this.destinationPath)));
        }

        private void DownloadFileInternal(string shareName, string fileName, string destination, Action downloadFileAction)
        {
            var mockupRunner = new MockTransferJobRunner(
                job =>
                {
                    Assert.IsTrue(job is FileDownloadJob, "The transfer job must be an instance of FileDownloadJob.");
                    var downloadJob = job as FileDownloadJob;
                    Assert.AreEqual(destination, downloadJob.DestPath, "Destination validation failed.");
                    Assert.AreEqual(shareName, downloadJob.SourceFile.Share.Name, "Share validation failed.");
                    Assert.AreEqual(fileName, downloadJob.SourceFile.Name, "SourceFile validation failed.");
                    return TaskEx.FromResult(true);
                });

            TransferJobRunnerFactory.SetCachedRunner(mockupRunner);

            downloadFileAction();

            mockupRunner.ThrowAssertExceptionIfAvailable();
            this.MockCmdRunTime.OutputPipeline.AssertNoObject();
            this.MockCmdRunTime.ErrorStream.AssertNoObject();
        }
    }
}
