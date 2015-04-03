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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class ServicePathInfoTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServicePathInfoTest()
        {
            PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo("MyService");
            AzureAssert.AreEqualServicePathInfo("MyService", paths);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServicePathInfoTestEmptyRootPathFail()
        {
            try
            {
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(string.Empty);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
                Assert.Equal<string>(string.Format(Resources.InvalidOrEmptyArgumentMessage, "rootPath"), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServicePathInfoTestNullRootPathFail()
        {
            try
            {
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(null);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
                Assert.Equal<string>(string.Format(Resources.InvalidOrEmptyArgumentMessage, "rootPath"), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServicePathInfoTestInvalidRootPathFail()
        {
            foreach (string invalidDirectoryName in Test.Utilities.Common.Data.InvalidServiceRootName)
            {
                try
                {
                    PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(invalidDirectoryName);
                    Assert.True(false, "No exception was thrown");
                }
                catch (Exception ex)
                {
                    Assert.True(ex is ArgumentException);
                    Assert.Equal<string>(Resources.InvalidRootNameMessage, ex.Message);
                }
            }
        }
    }
}