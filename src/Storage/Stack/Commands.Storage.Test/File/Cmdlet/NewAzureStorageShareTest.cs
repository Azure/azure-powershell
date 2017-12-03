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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File.Cmdlet
{
    public class NewAzureStorageShareTest : StorageFileTestBase<NewAzureStorageShare>
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareBasicTest()
        {
            this.NewShareAndValidate("newshare");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithLongName()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateValidShareName(63));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithInvalidShareName_DoubleDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_DoubleDash(20), "ArgumentException");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithInvalidShareName_EndsWithDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_EndsWithDash(20), "ArgumentException");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithInvalidShareName_StartsWithDash()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_StartsWithDash(20), "ArgumentException");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithInvalidShareName_UpperCase()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateInvalidShareName_UpperCase(20), "ArgumentException");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithTooLongName()
        {
            this.NewShareAndValidate(FileNamingGenerator.GenerateValidASCIIName(64), "ArgumentException");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewShareWithInvalidCharacter()
        {
            this.NewShareAndValidate("&LOv=\\ji1eJgg% -SY;m", "ArgumentException");
        }

        private void NewShareAndValidate(string name)
        {
            this.CmdletInstance.RunCmdlet(
                Constants.ShareNameParameterSetName,
                new KeyValuePair<string, object>("Name", name));
            this.MockCmdRunTime.OutputPipeline.Cast<CloudFileShare>().AssertSingleObject(x => x.Name == name);
        }

        private void NewShareAndValidate(string name, string expectedErrorId)
        {
            try
            {
                AzureSessionInitializer.InitializeAzureSession();
                this.CmdletInstance.RunCmdlet(
                    Constants.ShareNameParameterSetName,
                    new KeyValuePair<string, object>("Name", name));
            }
            catch (TargetInvocationException exception)
            {
                Trace.WriteLine(string.Format("Creating a share with name '{0}'", name));
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
