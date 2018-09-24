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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class DiagnosticsExtensionTests
    {
        private static string configDirPath = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath)), "ConfigFiles");

        private static string GetConfigFilePath(string filename)
        {
            return Path.Combine(configDirPath, filename);
        }

        XunitTracingInterceptor _logger;

        public DiagnosticsExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionBasic()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-DiagnosticsExtensionBasic");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionSepcifyStorageAccountName()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-DiagnosticsExtensionSepcifyStorageAccountName");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionCantListSepcifyStorageAccountKey()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-DiagnosticsExtensionCantListSepcifyStorageAccountKey");
        }

#if NETSTANDARD
        [Fact(Skip = "Updated Storage, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionSupportJsonConfig()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-DiagnosticsExtensionSupportJsonConfig");
        }

#if NETSTANDARD
        [Fact(Skip = "Resources -> ResourceManager, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVmssDiagnosticsExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-VmssDiagnosticsExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsConfigBuilderMismatchAccountNames()
        {
            string pubJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPublicConfigWithStorageType.json");
            string privJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPrivateConfigWithWrongName.json");

            var exception = Record.Exception(() => DiagnosticsHelper.GetConfigurationsFromFiles(pubJsonConfigPath, privJsonConfigPath, "a-resouce-id", null, null));
            Assert.IsType<ArgumentException>(exception);


            string[] configs = {
                GetConfigFilePath("DiagnosticsExtensionConfigWithWrongName.json"),
                GetConfigFilePath("DiagnosticsExtensionConfigWithWrongName.xml")
            };

            foreach (var configPath in configs)
            {
                exception = Record.Exception(() => DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(configPath, "wrong-name", "a-key", "an-endpoint"));
                Assert.IsType<ArgumentException>(exception);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsConfigBuilderWithSasToken()
        {
            string pubJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPublicConfigWithStorageType.json");
            string privJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPrivateConfigWithSasToken.json");

            string sasTokenValue = "This-is-a-sas-token";
            var result = DiagnosticsHelper.GetConfigurationsFromFiles(pubJsonConfigPath, privJsonConfigPath, "a-resource-id", null, null);
            Assert.Equal(sasTokenValue, result.Item2["storageAccountSasToken"] as string);

            string[] configs = {
                GetConfigFilePath("DiagnosticsExtensionConfigWithSasToken.json"),
                GetConfigFilePath("DiagnosticsExtensionConfigWithSasToken.xml")
            };

            foreach (var configPath in configs)
            {
                var privateSettings = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(configPath, "[StorageAccountName]", "a-key", "an-endpoint");
                Assert.Null(privateSettings["storageAccountKey"]);
                Assert.NotNull(privateSettings["storageAccountEndPoint"]);
                Assert.Equal(sasTokenValue, privateSettings["storageAccountSasToken"] as string);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsConfigBuilderWithStorageType()
        {
            string pubJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPublicConfigWithStorageType.json");
            string privJsonConfigPath = GetConfigFilePath("DiagnosticsExtensionPrivateConfigWithSasToken.json");

            string storageTypeValue = "TableAndBlob";

            var result = DiagnosticsHelper.GetConfigurationsFromFiles(pubJsonConfigPath, privJsonConfigPath, "a-resource-id", null, null);
            Assert.Equal(storageTypeValue, result.Item1["StorageType"] as string);

            string[] configs = {
                GetConfigFilePath("DiagnosticsExtensionConfigWithStorageType.json"),
                GetConfigFilePath("DiagnosticsExtensionConfigWithStorageType.xml")
            };

            foreach (var configPath in configs)
            {
                var publicSettings = DiagnosticsHelper.GetPublicDiagnosticsConfigurationFromFile(configPath, "[StorageAccountName]", "dummy", null);
                Assert.Equal(storageTypeValue, publicSettings["StorageType"] as string);
            }
        }
    }
}
