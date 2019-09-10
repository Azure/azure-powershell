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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Profile.UninstallAzureRm;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class UninstallAzureRmTests
    {
        public UninstallAzureRmTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUninstallAzureRm()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.CreateDirectory("testmodulepath");
            dataStore.CreateDirectory(Path.Combine("testmodulepath", "AzureRM.ApiManagement"));
            dataStore.WriteFile(Path.Combine("testmodulepath", Path.Combine("AzureRM.ApiManagement", "file1")), new byte[2]);
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists(Path.Combine("testmodulepath", "AzureRM.ApiManagement")));

            var cmdlet = new UninstallAzureRmCommand();
            Environment.SetEnvironmentVariable("PSModulePath", "testmodulepath");
            cmdlet.ExecuteCmdlet();
            Assert.False(dataStore.DirectoryExists(Path.Combine("testmodulepath", "AzureRM.ApiManagement")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUninstallAzureRmMultiplePaths()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.CreateDirectory("testmodulepath");
            dataStore.CreateDirectory("testmodulepath2");
            dataStore.CreateDirectory(Path.Combine("testmodulepath", "AzureRM.ApiManagement"));
            dataStore.CreateDirectory(Path.Combine("testmodulepath2", "AzureRM.Profile"));
            dataStore.WriteFile(Path.Combine("testmodulepath", Path.Combine("AzureRM.ApiManagement", "file1")), new byte[2]);
            dataStore.WriteFile(Path.Combine("testmodulepath2", Path.Combine("AzureRM.Profile", "file1")), new byte[2]);
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists(Path.Combine("testmodulepath", "AzureRM.ApiManagement")));
            Assert.True(dataStore.DirectoryExists(Path.Combine("testmodulepath2", "AzureRM.Profile")));

            var cmdlet = new UninstallAzureRmCommand();
            Environment.SetEnvironmentVariable("PSModulePath", 
                "testmodulepath" + Path.PathSeparator + "testmodulepath2" + Path.PathSeparator + "pathdoesntexist");
            cmdlet.ExecuteCmdlet();
            Assert.False(dataStore.DirectoryExists(Path.Combine("testmodulepath", "AzureRM.ApiManagement")));
            Assert.False(dataStore.DirectoryExists(Path.Combine("testmodulepath2", "AzureRM.Profile")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUninstallAzureRmUnauthorized()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.CreateDirectory("testmodulepath");
            dataStore.CreateDirectory(Path.Combine("testmodulepath", "AzureRM.ApiManagement"));
            dataStore.WriteFile(Path.Combine("testmodulepath", Path.Combine("AzureRM.ApiManagement", "file1")), new byte[2]);
            dataStore.LockAccessToFile(Path.Combine("testmodulepath", "AzureRM.ApiManagement"));
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists(Path.Combine("testmodulepath", "AzureRM.ApiManagement")));

            var cmdlet = new UninstallAzureRmCommand();
            Environment.SetEnvironmentVariable("PSModulePath", "testmodulepath");
            try
            {
                cmdlet.ExecuteCmdlet();
                // Throw incorrect exception if cmdlet does not throw
                Assert.True(false);
            }
            catch (UnauthorizedAccessException e)
            {
                Assert.Equal("Module deletion failed. Please close all PowerShell sessions to ensure no AzureRM modules are currently loaded, and rerun this cmdlet in Administrator mode.", e.Message);
            }
        }
    }
}
