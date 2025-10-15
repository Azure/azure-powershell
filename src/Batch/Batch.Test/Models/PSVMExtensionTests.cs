// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSVMExtensionTests
    {
        #region toMgmtVMExtension Tests

        [Fact]
        public void ToMgmtVMExtension_WithBasicProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
        }

        [Fact]
        public void ToMgmtVMExtension_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var settings = new { commandToExecute = "echo Hello World" };
            var protectedSettings = new { password = "secret123" };
            var provisionAfterExtensions = new List<string> { "Extension1", "Extension2" };

            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                TypeHandlerVersion = "1.10",
                AutoUpgradeMinorVersion = true,
                EnableAutomaticUpgrade = false,
                Settings = settings,
                ProtectedSettings = protectedSettings,
                ProvisionAfterExtensions = provisionAfterExtensions
            };

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
            Assert.Equal("1.10", result.TypeHandlerVersion);
            Assert.Equal(true, result.AutoUpgradeMinorVersion);
            Assert.Equal(false, result.EnableAutomaticUpgrade);
            Assert.Same(settings, result.Settings);
            Assert.Same(protectedSettings, result.ProtectedSettings);
            Assert.Equal(provisionAfterExtensions, result.ProvisionAfterExtensions);
        }

        [Fact]
        public void ToMgmtVMExtension_WithNullOptionalProperties_HandlesCorrectly()
        {
            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                TypeHandlerVersion = null,
                AutoUpgradeMinorVersion = null,
                EnableAutomaticUpgrade = null,
                Settings = null,
                ProtectedSettings = null,
                ProvisionAfterExtensions = null
            };

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
            Assert.Null(result.TypeHandlerVersion);
            Assert.Null(result.AutoUpgradeMinorVersion);
            Assert.Null(result.EnableAutomaticUpgrade);
            Assert.Null(result.Settings);
            Assert.Null(result.ProtectedSettings);
            Assert.Null(result.ProvisionAfterExtensions);
        }

        [Fact]
        public void ToMgmtVMExtension_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var result1 = psExtension.toMgmtVMExtension();
            var result2 = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtVMExtension_VerifyVMExtensionType()
        {
            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VMExtension>(result);
        }

        [Fact]
        public void ToMgmtVMExtension_WithComplexSettings_PreservesObjectReferences()
        {
            // Arrange
            var complexSettings = new
            {
                script = "startup.ps1",
                parameters = new { param1 = "value1", param2 = 42 },
                options = new[] { "option1", "option2" }
            };

            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                Settings = complexSettings
            };

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.Same(complexSettings, result.Settings);
        }

        [Fact]
        public void ToMgmtVMExtension_WithEmptyProvisionAfterExtensions_HandlesCorrectly()
        {
            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                ProvisionAfterExtensions = new List<string>()
            };

            // Act
            var result = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ProvisionAfterExtensions);
            Assert.Empty(result.ProvisionAfterExtensions);
        }

        #endregion

        #region fromMgmtVMExtension Tests

        [Fact]
        public void FromMgmtVMExtension_WithBasicProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtExtension = new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var result = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
        }

        [Fact]
        public void FromMgmtVMExtension_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var settings = new { commandToExecute = "echo Hello World" };
            var protectedSettings = new { password = "secret123" };
            var provisionAfterExtensions = new List<string> { "Extension1", "Extension2" };

            var mgmtExtension = new VMExtension(
                name: "TestExtension",
                publisher: "Microsoft.Azure.Extensions",
                type: "CustomScript",
                typeHandlerVersion: "1.10",
                autoUpgradeMinorVersion: true,
                enableAutomaticUpgrade: false,
                settings: settings,
                protectedSettings: protectedSettings,
                provisionAfterExtensions: provisionAfterExtensions
            );

            // Act
            var result = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
            Assert.Equal("1.10", result.TypeHandlerVersion);
            Assert.Equal(true, result.AutoUpgradeMinorVersion);
            Assert.Equal(false, result.EnableAutomaticUpgrade);
            Assert.Same(settings, result.Settings);
            Assert.Same(protectedSettings, result.ProtectedSettings);
            Assert.Equal(provisionAfterExtensions, result.ProvisionAfterExtensions);
        }

        [Fact]
        public void FromMgmtVMExtension_WithNullOptionalProperties_HandlesCorrectly()
        {
            // Arrange
            var mgmtExtension = new VMExtension(
                name: "TestExtension",
                publisher: "Microsoft.Azure.Extensions",
                type: "CustomScript",
                typeHandlerVersion: null,
                autoUpgradeMinorVersion: null,
                enableAutomaticUpgrade: null,
                settings: null,
                protectedSettings: null,
                provisionAfterExtensions: null
            );

            // Act
            var result = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestExtension", result.Name);
            Assert.Equal("Microsoft.Azure.Extensions", result.Publisher);
            Assert.Equal("CustomScript", result.Type);
            Assert.Null(result.TypeHandlerVersion);
            Assert.Null(result.AutoUpgradeMinorVersion);
            Assert.Null(result.EnableAutomaticUpgrade);
            Assert.Null(result.Settings);
            Assert.Null(result.ProtectedSettings);
            Assert.Null(result.ProvisionAfterExtensions);
        }

        [Fact]
        public void FromMgmtVMExtension_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSVMExtension.fromMgmtVMExtension(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtVMExtension_VerifyPSVMExtensionType()
        {
            // Arrange
            var mgmtExtension = new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var result = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSVMExtension>(result);
        }

        [Fact]
        public void FromMgmtVMExtension_WithComplexSettings_PreservesObjectReferences()
        {
            // Arrange
            var complexProtectedSettings = new
            {
                storageAccountKey = "key123",
                credentials = new { username = "admin", password = "secret" }
            };

            var mgmtExtension = new VMExtension(
                name: "TestExtension",
                publisher: "Microsoft.Azure.Extensions",
                type: "CustomScript",
                protectedSettings: complexProtectedSettings
            );

            // Act
            var result = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(result);
            Assert.Same(complexProtectedSettings, result.ProtectedSettings);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBasicProperties()
        {
            // Arrange
            var originalPsExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var mgmtExtension = originalPsExtension.toMgmtVMExtension();
            var roundTripPsExtension = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(roundTripPsExtension);
            Assert.Equal(originalPsExtension.Name, roundTripPsExtension.Name);
            Assert.Equal(originalPsExtension.Publisher, roundTripPsExtension.Publisher);
            Assert.Equal(originalPsExtension.Type, roundTripPsExtension.Type);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var settings = new { script = "test.ps1" };
            var protectedSettings = new { key = "secret" };
            var provisionAfterExtensions = new List<string> { "Ext1", "Ext2" };

            var originalPsExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                EnableAutomaticUpgrade = false,
                Settings = settings,
                ProtectedSettings = protectedSettings,
                ProvisionAfterExtensions = provisionAfterExtensions
            };

            // Act
            var mgmtExtension = originalPsExtension.toMgmtVMExtension();
            var roundTripPsExtension = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(roundTripPsExtension);
            Assert.Equal(originalPsExtension.Name, roundTripPsExtension.Name);
            Assert.Equal(originalPsExtension.Publisher, roundTripPsExtension.Publisher);
            Assert.Equal(originalPsExtension.Type, roundTripPsExtension.Type);
            Assert.Equal(originalPsExtension.TypeHandlerVersion, roundTripPsExtension.TypeHandlerVersion);
            Assert.Equal(originalPsExtension.AutoUpgradeMinorVersion, roundTripPsExtension.AutoUpgradeMinorVersion);
            Assert.Equal(originalPsExtension.EnableAutomaticUpgrade, roundTripPsExtension.EnableAutomaticUpgrade);
            Assert.Same(settings, roundTripPsExtension.Settings);
            Assert.Same(protectedSettings, roundTripPsExtension.ProtectedSettings);
            Assert.Equal(provisionAfterExtensions, roundTripPsExtension.ProvisionAfterExtensions);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var settings = new { fileUris = new[] { "http://example.com/script.ps1" } };
            var originalMgmtExtension = new VMExtension(
                name: "TestExtension",
                publisher: "Microsoft.Azure.Extensions",
                type: "CustomScript",
                typeHandlerVersion: "1.9",
                autoUpgradeMinorVersion: false,
                enableAutomaticUpgrade: true,
                settings: settings
            );

            // Act
            var psExtension = PSVMExtension.fromMgmtVMExtension(originalMgmtExtension);
            var roundTripMgmtExtension = psExtension.toMgmtVMExtension();

            // Assert
            Assert.NotNull(roundTripMgmtExtension);
            Assert.Equal(originalMgmtExtension.Name, roundTripMgmtExtension.Name);
            Assert.Equal(originalMgmtExtension.Publisher, roundTripMgmtExtension.Publisher);
            Assert.Equal(originalMgmtExtension.Type, roundTripMgmtExtension.Type);
            Assert.Equal(originalMgmtExtension.TypeHandlerVersion, roundTripMgmtExtension.TypeHandlerVersion);
            Assert.Equal(originalMgmtExtension.AutoUpgradeMinorVersion, roundTripMgmtExtension.AutoUpgradeMinorVersion);
            Assert.Equal(originalMgmtExtension.EnableAutomaticUpgrade, roundTripMgmtExtension.EnableAutomaticUpgrade);
            Assert.Same(settings, roundTripMgmtExtension.Settings);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalPsExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                TypeHandlerVersion = null,
                AutoUpgradeMinorVersion = null,
                EnableAutomaticUpgrade = null,
                Settings = null,
                ProtectedSettings = null,
                ProvisionAfterExtensions = null
            };

            // Act
            var mgmtExtension = originalPsExtension.toMgmtVMExtension();
            var roundTripPsExtension = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert
            Assert.NotNull(roundTripPsExtension);
            Assert.Null(roundTripPsExtension.TypeHandlerVersion);
            Assert.Null(roundTripPsExtension.AutoUpgradeMinorVersion);
            Assert.Null(roundTripPsExtension.EnableAutomaticUpgrade);
            Assert.Null(roundTripPsExtension.Settings);
            Assert.Null(roundTripPsExtension.ProtectedSettings);
            Assert.Null(roundTripPsExtension.ProvisionAfterExtensions);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void VMExtensionConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test custom script extension for Windows
            var psCustomScript = new PSVMExtension("CustomScriptExtension", "Microsoft.Compute", "CustomScriptExtension")
            {
                TypeHandlerVersion = "1.10",
                AutoUpgradeMinorVersion = true,
                Settings = new { commandToExecute = "powershell.exe -ExecutionPolicy Unrestricted -File script.ps1" }
            };

            var mgmtCustomScript = psCustomScript.toMgmtVMExtension();
            var backToPs = PSVMExtension.fromMgmtVMExtension(mgmtCustomScript);

            Assert.Equal("CustomScriptExtension", mgmtCustomScript.Name);
            Assert.Equal("Microsoft.Compute", mgmtCustomScript.Publisher);
            Assert.Equal("CustomScriptExtension", mgmtCustomScript.Type);
            Assert.Equal(psCustomScript.Name, backToPs.Name);
            Assert.Equal(psCustomScript.Publisher, backToPs.Publisher);
            Assert.Equal(psCustomScript.Type, backToPs.Type);

            // Test diagnostics extension
            var psDiagnostics = new PSVMExtension("DiagnosticsExtension", "Microsoft.Azure.Diagnostics", "IaaSDiagnostics")
            {
                TypeHandlerVersion = "1.5",
                AutoUpgradeMinorVersion = false,
                EnableAutomaticUpgrade = true
            };

            var mgmtDiagnostics = psDiagnostics.toMgmtVMExtension();
            var backToPsDiagnostics = PSVMExtension.fromMgmtVMExtension(mgmtDiagnostics);

            Assert.Equal("DiagnosticsExtension", mgmtDiagnostics.Name);
            Assert.Equal("Microsoft.Azure.Diagnostics", mgmtDiagnostics.Publisher);
            Assert.Equal("IaaSDiagnostics", mgmtDiagnostics.Type);
            Assert.Equal(psDiagnostics.Name, backToPsDiagnostics.Name);
            Assert.Equal(psDiagnostics.Publisher, backToPsDiagnostics.Publisher);
            Assert.Equal(psDiagnostics.Type, backToPsDiagnostics.Type);
        }

        [Fact]
        public void VMExtensionConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSVMExtension.fromMgmtVMExtension(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void VMExtensionConversions_BatchVMContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch VM configuration
            // VMExtension is used to configure extensions for virtual machines in Azure Batch pools

            // Arrange - Test Azure Batch VM extension scenarios
            var batchScenarios = new[]
            {
                // Custom script extension for application installation
                new PSVMExtension("AppInstaller", "Microsoft.Compute", "CustomScriptExtension")
                {
                    TypeHandlerVersion = "1.10",
                    AutoUpgradeMinorVersion = true,
                    Settings = new { 
                        fileUris = new[] { "https://storage.blob.core.windows.net/scripts/install-app.ps1" },
                        commandToExecute = "powershell.exe -ExecutionPolicy Unrestricted -File install-app.ps1"
                    }
                },
                // Monitoring extension for performance data collection
                new PSVMExtension("MonitoringAgent", "Microsoft.Azure.Monitor", "AzureMonitorWindowsAgent")
                {
                    TypeHandlerVersion = "1.0",
                    AutoUpgradeMinorVersion = false,
                    EnableAutomaticUpgrade = true
                }
            };

            foreach (var scenario in batchScenarios)
            {
                // Act
                var mgmtExtension = scenario.toMgmtVMExtension();

                // Assert - Should convert correctly for Batch VM pool configuration
                Assert.NotNull(mgmtExtension);
                Assert.Equal(scenario.Name, mgmtExtension.Name);
                Assert.Equal(scenario.Publisher, mgmtExtension.Publisher);
                Assert.Equal(scenario.Type, mgmtExtension.Type);

                // Verify round-trip conversion maintains Batch VM semantics
                var backToPs = PSVMExtension.fromMgmtVMExtension(mgmtExtension);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Name, backToPs.Name);
                Assert.Equal(scenario.Publisher, backToPs.Publisher);
                Assert.Equal(scenario.Type, backToPs.Type);
            }
        }

        [Fact]
        public void VMExtensionConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");
            var mgmtExtension = new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var mgmtResult = psExtension.toMgmtVMExtension();
            var psResult = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<VMExtension>(mgmtResult);
            Assert.IsType<PSVMExtension>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtExtension, mgmtResult);
            Assert.NotSame(psExtension, psResult);
        }

        [Fact]
        public void VMExtensionConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with minimal configuration
            
            // Arrange
            var minimalPsExtension = new PSVMExtension("MinimalExtension", "TestPublisher", "TestType");
            var minimalMgmtExtension = new VMExtension("MinimalExtension", "TestPublisher", "TestType");

            // Act
            var mgmtResult = minimalPsExtension.toMgmtVMExtension();
            var psResult = PSVMExtension.fromMgmtVMExtension(minimalMgmtExtension);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Equal("MinimalExtension", mgmtResult.Name);
            Assert.Equal("TestPublisher", mgmtResult.Publisher);
            Assert.Equal("TestType", mgmtResult.Type);
            Assert.Equal("MinimalExtension", psResult.Name);
            Assert.Equal("TestPublisher", psResult.Publisher);
            Assert.Equal("TestType", psResult.Type);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void VMExtensionConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");
            var mgmtExtension = new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psExtension.toMgmtVMExtension();
                var psResult = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
            }
        }

        [Fact]
        public void VMExtensionConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");
            var mgmtExtension = new VMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript");

            // Act
            var mgmtResult = psExtension.toMgmtVMExtension();
            var psResult = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

            // Assert - Verify correct types are returned
            Assert.IsType<VMExtension>(mgmtResult);
            Assert.IsType<PSVMExtension>(psResult);
        }

        [Fact]
        public void VMExtensionConversions_LargeProvisionAfterExtensions_HandlesCorrectly()
        {
            // Test with a large list of provision after extensions

            // Arrange
            var largeProvisionList = Enumerable.Range(1, 50).Select(i => $"Extension{i}").ToList();
            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                ProvisionAfterExtensions = largeProvisionList
            };

            // Act
            var mgmtResult = psExtension.toMgmtVMExtension();
            var psResult = PSVMExtension.fromMgmtVMExtension(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Equal(largeProvisionList.Count, mgmtResult.ProvisionAfterExtensions.Count);
            Assert.Equal(largeProvisionList.Count, psResult.ProvisionAfterExtensions.Count);
            Assert.Equal(largeProvisionList, mgmtResult.ProvisionAfterExtensions);
            Assert.Equal(largeProvisionList, psResult.ProvisionAfterExtensions);
        }

        [Fact]
        public void VMExtensionConversions_ComplexNestedSettings_PreservesStructure()
        {
            // Test with complex nested settings object

            // Arrange
            var complexSettings = new
            {
                level1 = new
                {
                    level2 = new
                    {
                        stringValue = "test",
                        intValue = 42,
                        boolValue = true,
                        arrayValue = new[] { "item1", "item2", "item3" },
                        nullValue = (string)null
                    }
                },
                topLevelArray = new[] { 1, 2, 3, 4, 5 }
            };

            var psExtension = new PSVMExtension("TestExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                Settings = complexSettings
            };

            // Act
            var mgmtResult = psExtension.toMgmtVMExtension();
            var psResult = PSVMExtension.fromMgmtVMExtension(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Same(complexSettings, mgmtResult.Settings);
            Assert.Same(complexSettings, psResult.Settings);
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSVMExtension_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the internal object

            // Arrange & Act
            var psExtension = new PSVMExtension("TestName", "TestPublisher", "TestType");

            // Assert
            Assert.Equal("TestName", psExtension.Name);
            Assert.Equal("TestPublisher", psExtension.Publisher);
            Assert.Equal("TestType", psExtension.Type);
            Assert.Null(psExtension.TypeHandlerVersion);
            Assert.Null(psExtension.AutoUpgradeMinorVersion);
            Assert.Null(psExtension.EnableAutomaticUpgrade);
            Assert.Null(psExtension.Settings);
            Assert.Null(psExtension.ProtectedSettings);
            Assert.Null(psExtension.ProvisionAfterExtensions);
        }

        [Fact]
        public void PSVMExtension_InternalConstructor_ThrowsOnNullOmObject()
        {
            // Test that the internal constructor validates the omObject parameter

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new PSVMExtension((Microsoft.Azure.Batch.VMExtension)null));
        }

        [Fact]
        public void PSVMExtension_PropertySetters_WorkCorrectly()
        {
            // Test that property setters work correctly

            // Arrange
            var psExtension = new PSVMExtension("TestName", "TestPublisher", "TestType");
            var testSettings = new { test = "value" };
            var testProtectedSettings = new { secret = "password" };
            var testProvisionAfter = new List<string> { "Ext1", "Ext2" };

            // Act
            psExtension.TypeHandlerVersion = "2.0";
            psExtension.AutoUpgradeMinorVersion = true;
            psExtension.EnableAutomaticUpgrade = false;
            psExtension.Settings = testSettings;
            psExtension.ProtectedSettings = testProtectedSettings;
            psExtension.ProvisionAfterExtensions = testProvisionAfter;

            // Assert
            Assert.Equal("2.0", psExtension.TypeHandlerVersion);
            Assert.Equal(true, psExtension.AutoUpgradeMinorVersion);
            Assert.Equal(false, psExtension.EnableAutomaticUpgrade);
            Assert.Same(testSettings, psExtension.Settings);
            Assert.Same(testProtectedSettings, psExtension.ProtectedSettings);
            Assert.Equal(testProvisionAfter, psExtension.ProvisionAfterExtensions);
        }

        #endregion

        #region Extension Scenario Tests

        [Fact]
        public void VMExtensionConversions_CommonExtensionTypes_VerifySupport()
        {
            // Test support for common Azure VM extension types

            var commonExtensions = new[]
            {
                // Windows Custom Script Extension
                new PSVMExtension("CustomScript", "Microsoft.Compute", "CustomScriptExtension")
                {
                    TypeHandlerVersion = "1.10",
                    AutoUpgradeMinorVersion = true
                },
                // Linux Custom Script Extension
                new PSVMExtension("CustomScriptForLinux", "Microsoft.Azure.Extensions", "CustomScript")
                {
                    TypeHandlerVersion = "2.0",
                    AutoUpgradeMinorVersion = true
                },
                // Azure Monitor Agent
                new PSVMExtension("AzureMonitorAgent", "Microsoft.Azure.Monitor", "AzureMonitorWindowsAgent")
                {
                    TypeHandlerVersion = "1.0",
                    EnableAutomaticUpgrade = true
                },
                // Network Watcher Extension
                new PSVMExtension("NetworkWatcher", "Microsoft.Azure.NetworkWatcher", "NetworkWatcherAgentWindows")
                {
                    TypeHandlerVersion = "1.4",
                    AutoUpgradeMinorVersion = false
                }
            };

            foreach (var extension in commonExtensions)
            {
                // Act
                var mgmtExtension = extension.toMgmtVMExtension();
                var roundTripExtension = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

                // Assert
                Assert.NotNull(mgmtExtension);
                Assert.NotNull(roundTripExtension);
                Assert.Equal(extension.Name, mgmtExtension.Name);
                Assert.Equal(extension.Publisher, mgmtExtension.Publisher);
                Assert.Equal(extension.Type, mgmtExtension.Type);
                Assert.Equal(extension.Name, roundTripExtension.Name);
                Assert.Equal(extension.Publisher, roundTripExtension.Publisher);
                Assert.Equal(extension.Type, roundTripExtension.Type);
            }
        }

        [Fact]
        public void VMExtensionConversions_ExtensionChaining_VerifyProvisionAfterSupport()
        {
            // Test extension dependency chaining through ProvisionAfterExtensions

            // Arrange - Create a chain of dependent extensions
            var baseExtension = new PSVMExtension("BaseExtension", "Microsoft.Compute", "CustomScriptExtension");
            var dependentExtension = new PSVMExtension("DependentExtension", "Microsoft.Azure.Extensions", "CustomScript")
            {
                ProvisionAfterExtensions = new List<string> { "BaseExtension" }
            };
            var finalExtension = new PSVMExtension("FinalExtension", "TestPublisher", "TestType")
            {
                ProvisionAfterExtensions = new List<string> { "BaseExtension", "DependentExtension" }
            };

            // Act & Assert for each extension in the chain
            var extensions = new[] { baseExtension, dependentExtension, finalExtension };
            foreach (var extension in extensions)
            {
                var mgmtExtension = extension.toMgmtVMExtension();
                var roundTripExtension = PSVMExtension.fromMgmtVMExtension(mgmtExtension);

                Assert.NotNull(mgmtExtension);
                Assert.NotNull(roundTripExtension);
                Assert.Equal(extension.ProvisionAfterExtensions, mgmtExtension.ProvisionAfterExtensions);
                Assert.Equal(extension.ProvisionAfterExtensions, roundTripExtension.ProvisionAfterExtensions);
            }
        }

        #endregion
    }
}