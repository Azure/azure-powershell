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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    [TestClass]
    public class GetAzureStorageFileTest : StorageFileTestBase<GetAzureStorageFile>
    {
        private const string ShareName = "share";

        [TestMethod]
        public void GetFileFromRootTest_ShareNameParameterSet()
        {
            var share = this.MockChannel.GetShareReference(ShareName);
            var listItems = Enumerable.Range(0, 10).Select(x => share.GetRootDirectoryReference().GetFileReference(string.Format("file{0}", x))).Cast<IListFileItem>()
                .Concat(Enumerable.Range(0, 5).Select(x => share.GetRootDirectoryReference().GetDirectoryReference(string.Format("dir{0}", x)))).ToArray();

            this.ListFilesAndAssertResults(
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", ShareName)),
                listItems);
        }

        [TestMethod]
        public void GetFileFromRootTest_ShareParameterSet()
        {
            var share = this.MockChannel.GetShareReference(ShareName);
            var listItems = Enumerable.Range(0, 10).Select(x => share.GetRootDirectoryReference().GetFileReference(string.Format("file{0}", x))).Cast<IListFileItem>()
                .Concat(Enumerable.Range(0, 5).Select(x => share.GetRootDirectoryReference().GetDirectoryReference(string.Format("dir{0}", x)))).ToArray();

            this.ListFilesAndAssertResults(
                () => this.CmdletInstance.RunCmdlet(
                    Constants.ShareParameterSetName,
                    new KeyValuePair<string, object>("Share", share)),
                listItems);
        }

        [TestMethod]
        public void GetFileFromSubDirectoryTest_UsingDirectoryObject()
        {
            var share = this.MockChannel.GetShareReference(ShareName);
            var dir = share.GetRootDirectoryReference().GetDirectoryReference("dir");
            var listItems = Enumerable.Range(0, 10).Select(x => dir.GetFileReference(string.Format("file{0}", x))).Cast<IListFileItem>()
                .Concat(Enumerable.Range(0, 5).Select(x => dir.GetDirectoryReference(string.Format("dir{0}", x)))).ToArray();

            this.ListFilesAndAssertResults(
                () => this.CmdletInstance.RunCmdlet(
                    Constants.DirectoryParameterSetName,
                    new KeyValuePair<string, object>("Directory", dir)),
                listItems,
                dir);
        }

        [TestMethod]
        public void GetFileFromSubDirectoryTest_UsingShareObjectWithPath()
        {
            var share = this.MockChannel.GetShareReference(ShareName);
            var dir = share.GetRootDirectoryReference().GetDirectoryReference("dir");

            this.MockChannel.SetsAvailableDirectories(dir.Name);

            this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", ShareName),
                    new KeyValuePair<string, object>("Path", dir.Name));

            List<IListFileItem> fileList = new List<IListFileItem>();
            fileList.Add(dir);
            this.MockCmdRunTime.OutputPipeline.AssertListFileItems(fileList);
        }

        [TestMethod]
        public void GetFileFromSubDirectoryTest_UsingShareNameWithPath()
        {
            var share = this.MockChannel.GetShareReference(ShareName);
            var dir = share.GetRootDirectoryReference().GetDirectoryReference("dir");
            this.MockChannel.SetsAvailableDirectories(dir.Name);

            this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", ShareName),
                    new KeyValuePair<string, object>("Path", dir.Name));

            List<IListFileItem> fileList = new List<IListFileItem>();
            fileList.Add(dir);
            this.MockCmdRunTime.OutputPipeline.AssertListFileItems(fileList);
        }

        [TestMethod]
        public void GetFileFromSubDirectoryTest_GetFromNonExistingDirectory()
        {
            this.CmdletInstance.RunCmdlet(
                Constants.ShareNameParameterSetName,
                new KeyValuePair<string, object>("ShareName", ShareName),
                new KeyValuePair<string, object>("Path", "NonExist"));
            this.MockCmdRunTime.ErrorStream.AssertMockupException("DirectoryNotFound");
        }

        private void ListFilesAndAssertResults(Action runCmdletAction, IListFileItem[] listedItems, CloudFileDirectory dir = null)
        {
            this.MockChannel.SetsEnumerationResults(dir == null ? string.Empty : dir.Name, listedItems);
            runCmdletAction();
            this.MockCmdRunTime.OutputPipeline.AssertListFileItems(listedItems);
        }
    }
}
