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
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.File;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    [TestClass]
    public class NewAzureStorageDirectoryTest : StorageFileTestBase<NewAzureStorageDirectory>
    {
        [TestMethod]
        public void NewDirectoryUsingShareNameAndPathTest()
        {
            NewDirectoryAndAssert("newDirectory");
        }

        [TestMethod]
        public void NewDirectoryUsingShareObjectAndPathTest()
        {
            this.CmdletInstance.RunCmdlet(
                Constants.ShareParameterSetName,
                new KeyValuePair<string, object>("Share", this.MockChannel.GetShareReference("share")),
                new KeyValuePair<string, object>("Path", "newDirectory"));

            this.MockCmdRunTime.OutputPipeline
                .Cast<CloudFileDirectory>()
                .AssertSingleObject(x => x.Name == "newDirectory" && x.Share.Name == "share");
        }

        [TestMethod]
        public void NewDirectoryUsingDirectoryObjectAndPathTest()
        {
            this.CmdletInstance.RunCmdlet(
                Constants.DirectoryParameterSetName,
                new KeyValuePair<string, object>("Directory", this.MockChannel.GetShareReference("share").GetRootDirectoryReference()),
                new KeyValuePair<string, object>("Path", "newDirectory"));

            this.MockCmdRunTime.OutputPipeline
                .Cast<CloudFileDirectory>()
                .AssertSingleObject(x => x.Name == "newDirectory" && x.Share.Name == "share");
        }

        [TestMethod]
        public void NewDirectoryWithTooLongNameTest()
        {
            NewDirectoryAndAssert(FileNamingGenerator.GenerateValidASCIIName(256), "ArgumentException");
        }

        [TestMethod]
        public void NewDirectoryWithLongNameTest()
        {
            NewDirectoryAndAssert(FileNamingGenerator.GenerateValidASCIIName(255));
        }

        [TestMethod]
        public void NewDirectoryWithInvalidCharacterTest()
        {
            NewDirectoryAndAssert("?*?\"\\*p:?\\/D?*?<:Z>:/l*<??\\:\\c\"(/:|**<<<|r:/**<:\\y", "ArgumentException");
        }

        private void NewDirectoryAndAssert(string directoryName)
        {
            this.CmdletInstance.RunCmdlet(
                Constants.ShareNameParameterSetName,
                new KeyValuePair<string, object>("ShareName", "share"),
                new KeyValuePair<string, object>("Path", directoryName));

            this.MockCmdRunTime.OutputPipeline
                .Cast<CloudFileDirectory>()
                .AssertSingleObject(x => x.Name == directoryName && x.Share.Name == "share");
        }

        private void NewDirectoryAndAssert(string directoryName, string expectedErrorId)
        {
            try
            {
                this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("ShareName", "share"),
                    new KeyValuePair<string, object>("Path", directoryName));
            }
            catch (TargetInvocationException exception)
            {
                Trace.WriteLine(string.Format("Creating a directory with name '{0}'", directoryName));
                if (exception.InnerException != null)
                {
                    Trace.WriteLine(string.Format("Exception:"));
                    Trace.WriteLine(string.Format("{0}: {1}", exception.InnerException.GetType(), exception.InnerException.Message));
                    if (exception.InnerException.GetType().ToString().Contains(expectedErrorId))
                    {
                        return;
                    }
                }

            }

            throw new InvalidOperationException("Did not receive expected exception");
        }
    }
}
