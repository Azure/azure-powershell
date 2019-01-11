using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Profile.UninstallAzureRm;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
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
            dataStore.CreateDirectory("testmodulepath\\AzureRM.ApiManagement");
            dataStore.WriteFile("testmodulepath\\AzureRM.ApiManagement\\file1", new byte[2]);
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists("testmodulepath\\AzureRM.ApiManagement"));

            var cmdlet = new UninstallAzureRmCommand();
            Environment.SetEnvironmentVariable("PSModulePath", "testmodulepath");
            cmdlet.ExecuteCmdlet();
            Assert.False(dataStore.DirectoryExists("testmodulepath\\AzureRM.ApiManagement"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUninstallAzureRmMultiplePaths()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.CreateDirectory("testmodulepath");
            dataStore.CreateDirectory("testmodulepath2");
            dataStore.CreateDirectory("testmodulepath\\AzureRM.ApiManagement");
            dataStore.CreateDirectory("testmodulepath2\\AzureRM.Profile");
            dataStore.WriteFile("testmodulepath\\AzureRM.ApiManagement\\file1", new byte[2]);
            dataStore.WriteFile("testmodulepath2\\AzureRM.Profile\\file1", new byte[2]);
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists("testmodulepath\\AzureRM.ApiManagement"));
            Assert.True(dataStore.DirectoryExists("testmodulepath2\\AzureRM.Profile"));

            var cmdlet = new UninstallAzureRmCommand();
            Environment.SetEnvironmentVariable("PSModulePath", "testmodulepath;testmodulepath2;pathdoesntexist");
            cmdlet.ExecuteCmdlet();
            Assert.False(dataStore.DirectoryExists("testmodulepath\\AzureRM.ApiManagement"));
            Assert.False(dataStore.DirectoryExists("testmodulepath2\\AzureRM.Profile"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUninstallAzureRmUnauthorized()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.CreateDirectory("testmodulepath");
            dataStore.CreateDirectory("testmodulepath\\AzureRM.ApiManagement");
            dataStore.WriteFile("testmodulepath\\AzureRM.ApiManagement\\file1", new byte[2]);
            dataStore.LockAccessToFile("testmodulepath\\AzureRM.ApiManagement");
            // Ensure read does not throw
            Assert.True(dataStore.DirectoryExists("testmodulepath\\AzureRM.ApiManagement"));

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
