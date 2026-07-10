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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob.Cmdlet
{
    /// <summary>
    /// Unit test for get azure storage blob content cmdlet
    /// </summary>
    [TestClass]
    public class GetAzureStorageBlobContentTest : StorageBlobTestBase
    {
        private GetAzureStorageBlobContentCommand command = null;

        private string destinationDirectory = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new GetAzureStorageBlobContentCommand(BlobMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentBlobCmd = command;

            destinationDirectory = Path.Combine(Path.GetTempPath(), "GetBlobContentTraversalTest_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(destinationDirectory);
        }

        [TestCleanup]
        public void CleanCommand()
        {
            if (destinationDirectory != null && Directory.Exists(destinationDirectory))
            {
                Directory.Delete(destinationDirectory, true);
            }
            destinationDirectory = null;
            command = null;
        }

        /// <summary>
        /// A blob name that resolves outside the destination directory must be rejected
        /// </summary>
        [DataTestMethod]
        [DataRow("../evil.dll")]
        [DataRow("../../evil.dll")]
        [DataRow("..\\..\\evil.dll")]
        [DataRow("sub/../../evil.dll")]
        [DataRow("sub/sub2/../../../evil.dll")]
        public void GetFullReceiveFilePathBlocksPathTraversal(string blobName)
        {
            AssertThrows<ArgumentException>(
                () => command.GetFullReceiveFilePath(destinationDirectory, blobName, null),
                string.Format(Resources.DownloadDestinationPathTraversal, blobName, destinationDirectory));
        }

        /// <summary>
        /// Legitimate blob names (including nested virtual directories) must resolve
        /// to a path inside the destination directory.
        /// </summary>
        [TestMethod]
        public void GetFullReceiveFilePathAllowsInDirectoryPaths()
        {
            Assert.AreEqual(
                Path.Combine(destinationDirectory, "file.txt"),
                command.GetFullReceiveFilePath(destinationDirectory, "file.txt", null));

            Assert.AreEqual(
                Path.Combine(destinationDirectory, "sub", "file.txt"),
                command.GetFullReceiveFilePath(destinationDirectory, "sub/file.txt", null));

            Assert.AreEqual(
                Path.Combine(destinationDirectory, "a", "b", "c", "file.txt"),
                command.GetFullReceiveFilePath(destinationDirectory, "a/b/c/file.txt", null));
        }

        /// <summary>
        /// A blob name with a ".." segment that still lands inside the destination
        /// directory must be allowed (not over-blocked).
        /// </summary>
        [TestMethod]
        public void GetFullReceiveFilePathAllowsInDirectoryTraversal()
        {
            string result = command.GetFullReceiveFilePath(destinationDirectory, "sub/../file.txt", null);
            Assert.AreEqual(Path.Combine(destinationDirectory, "file.txt"), Path.GetFullPath(result));
        }
    }
}
