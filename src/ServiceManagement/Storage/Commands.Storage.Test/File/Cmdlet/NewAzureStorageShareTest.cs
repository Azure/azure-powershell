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

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    [TestClass]
    public class NewAzureStorageShareTest : StorageFileTestBase<NewAzureStorageShare>
    {
        [TestMethod]
        public void NewShareBasicTest()
        {
            this.NewShareAndValidate("newshare");
        }

        [TestMethod]
        public void NewShareWithLongName()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateValidShareName(63));
        }

        [TestMethod]
        public void NewShareWithInvalidShareName_DoubleDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_DoubleDash(20), "ArgumentException");
        }

        [TestMethod]
        public void NewShareWithInvalidShareName_EndsWithDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_EndsWithDash(20), "ArgumentException");
        }

        [TestMethod]
        public void NewShareWithInvalidShareName_StartsWithDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_StartsWithDash(20), "ArgumentException");
        }

        [TestMethod]
        public void NewShareWithInvalidShareName_UpperCase()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_UpperCase(20), "ArgumentException");
        }

        [TestMethod]
        public void NewShareWithTooLongName()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateValidASCIIName(64), "ArgumentException");
        }

        [TestMethod]
        public void NewShareWithInvalidCharacter()
        {
            this.NewShareAndValidate("&LOv=\\ji1eJgg% -SY;m", "ArgumentException");
        }

        private void NewShareAndValidate(string name, string expectedErrorId = null)
        {
            this.CmdletInstance.RunCmdlet(
                Constants.ShareNameParameterSetName,
                new KeyValuePair<string, object>("Name", name));

            if (expectedErrorId == null)
            {
                this.MockCmdRunTime.OutputPipeline.Cast<CloudFileShare>().AssertSingleObject(x => x.Name == name);
            }
            else
            {
                this.MockCmdRunTime.ErrorStream.AssertSingleObject(x => x.FullyQualifiedErrorId == expectedErrorId);
            }
        }
    }
}
