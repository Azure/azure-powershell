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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSWindowsUserConfigurationTests
    {
        #region ToWindowsUserConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_WithBatchLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.NotNull(mgmtConfig.LoginMode);
            Assert.Equal(LoginMode.Batch, mgmtConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_WithInteractiveLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.NotNull(mgmtConfig.LoginMode);
            Assert.Equal(LoginMode.Interactive, mgmtConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_WithNullLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(loginMode: null);

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Null(mgmtConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_WithDefaultConstructor_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration();

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Null(mgmtConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);

            // Act
            var mgmtConfig1 = psConfig.ToWindowsUserConfiguration();
            var mgmtConfig2 = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig1);
            Assert.NotNull(mgmtConfig2);
            Assert.NotSame(mgmtConfig1, mgmtConfig2);
            Assert.Equal(mgmtConfig1.LoginMode, mgmtConfig2.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_VerifyReturnType()
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.IsType<WindowsUserConfiguration>(mgmtConfig);
            Assert.IsAssignableFrom<WindowsUserConfiguration>(mgmtConfig);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Batch, LoginMode.Batch)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Interactive, LoginMode.Interactive)]
        public void ToWindowsUserConfiguration_AllValidLoginModes_ConvertsCorrectly(
            Microsoft.Azure.Batch.Common.LoginMode psLoginMode,
            LoginMode expectedMgmtLoginMode)
        {
            // Arrange
            var psConfig = new PSWindowsUserConfiguration(loginMode: psLoginMode);

            // Act
            var mgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.NotNull(mgmtConfig.LoginMode);
            Assert.Equal(expectedMgmtLoginMode, mgmtConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToWindowsUserConfiguration_LoginModeSemantics_VerifyCorrectMapping()
        {
            // This test ensures that the login mode semantics are preserved during conversion

            // Arrange & Test Batch mode - LOGON32_LOGON_BATCH for long-running processes
            var psBatchConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);
            var mgmtBatchConfig = psBatchConfig.ToWindowsUserConfiguration();
            
            Assert.NotNull(mgmtBatchConfig.LoginMode);
            Assert.Equal(LoginMode.Batch, mgmtBatchConfig.LoginMode.Value);

            // Arrange & Test Interactive mode - LOGON32_LOGON_INTERACTIVE for applications requiring interactive permissions
            var psInteractiveConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            var mgmtInteractiveConfig = psInteractiveConfig.ToWindowsUserConfiguration();
            
            Assert.NotNull(mgmtInteractiveConfig.LoginMode);
            Assert.Equal(LoginMode.Interactive, mgmtInteractiveConfig.LoginMode.Value);
        }

        #endregion

        #region FromWindowsUserConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSWindowsUserConfiguration.FromWindowsUserConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_WithBatchLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Batch);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.NotNull(psConfig.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, psConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_WithInteractiveLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Interactive);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.NotNull(psConfig.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, psConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_WithNullLoginMode_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(loginMode: null);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Null(psConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_WithDefaultConstructor_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration();

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Null(psConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Batch);

            // Act - Call static method directly on class
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.NotNull(psConfig.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, psConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Interactive);

            // Act
            var psConfig1 = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);
            var psConfig2 = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig1);
            Assert.NotNull(psConfig2);
            Assert.NotSame(psConfig1, psConfig2);
            Assert.Equal(psConfig1.LoginMode, psConfig2.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_VerifyReturnType()
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Batch);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.IsType<PSWindowsUserConfiguration>(psConfig);
            Assert.IsAssignableFrom<PSWindowsUserConfiguration>(psConfig);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(LoginMode.Batch, Microsoft.Azure.Batch.Common.LoginMode.Batch)]
        [InlineData(LoginMode.Interactive, Microsoft.Azure.Batch.Common.LoginMode.Interactive)]
        public void FromWindowsUserConfiguration_AllValidLoginModes_ConvertsCorrectly(
            LoginMode mgmtLoginMode,
            Microsoft.Azure.Batch.Common.LoginMode expectedPsLoginMode)
        {
            // Arrange
            var mgmtConfig = new WindowsUserConfiguration(loginMode: mgmtLoginMode);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.NotNull(psConfig.LoginMode);
            Assert.Equal(expectedPsLoginMode, psConfig.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromWindowsUserConfiguration_LoginModeSemantics_VerifyCorrectMapping()
        {
            // This test ensures that the login mode semantics are preserved during conversion

            // Arrange & Test Batch mode - LOGON32_LOGON_BATCH for long-running processes
            var mgmtBatchConfig = new WindowsUserConfiguration(loginMode: LoginMode.Batch);
            var psBatchConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtBatchConfig);
            
            Assert.NotNull(psBatchConfig.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, psBatchConfig.LoginMode.Value);

            // Arrange & Test Interactive mode - LOGON32_LOGON_INTERACTIVE for applications requiring interactive permissions
            var mgmtInteractiveConfig = new WindowsUserConfiguration(loginMode: LoginMode.Interactive);
            var psInteractiveConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtInteractiveConfig);
            
            Assert.NotNull(psInteractiveConfig.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, psInteractiveConfig.LoginMode.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBatchLoginMode()
        {
            // Arrange
            var originalPsConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);

            // Act
            var mgmtConfig = originalPsConfig.ToWindowsUserConfiguration();
            var roundTripPsConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.LoginMode, roundTripPsConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesInteractiveLoginMode()
        {
            // Arrange
            var originalPsConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);

            // Act
            var mgmtConfig = originalPsConfig.ToWindowsUserConfiguration();
            var roundTripPsConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.LoginMode, roundTripPsConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullLoginMode()
        {
            // Arrange
            var originalPsConfig = new PSWindowsUserConfiguration(loginMode: null);

            // Act
            var mgmtConfig = originalPsConfig.ToWindowsUserConfiguration();
            var roundTripPsConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Null(roundTripPsConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Interactive);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.LoginMode, roundTripMgmtConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesNullProperties()
        {
            // Arrange
            var originalMgmtConfig = new WindowsUserConfiguration(loginMode: null);

            // Act
            var psConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.ToWindowsUserConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Null(roundTripMgmtConfig.LoginMode);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Batch)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Interactive)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.LoginMode originalLoginMode)
        {
            // Arrange
            var originalPsConfig = new PSWindowsUserConfiguration(loginMode: originalLoginMode);

            // Act
            var mgmtConfig = originalPsConfig.ToWindowsUserConfiguration();
            var roundTripPsConfig = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalLoginMode, roundTripPsConfig.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_MultipleScenarios_PreservesSemantics()
        {
            // Arrange - Test various realistic Windows user configurations
            var testScenarios = new[]
            {
                new { 
                    LoginMode = (Microsoft.Azure.Batch.Common.LoginMode?)Microsoft.Azure.Batch.Common.LoginMode.Batch,
                    Description = "Batch login mode for long-running parallel processes"
                },
                new { 
                    LoginMode = (Microsoft.Azure.Batch.Common.LoginMode?)Microsoft.Azure.Batch.Common.LoginMode.Interactive,
                    Description = "Interactive login mode for applications requiring interactive permissions"
                },
                new { 
                    LoginMode = (Microsoft.Azure.Batch.Common.LoginMode?)null,
                    Description = "Default login mode (system default)"
                }
            };

            foreach (var scenario in testScenarios)
            {
                // Act - Round trip conversion starting from PS
                var psConfig = new PSWindowsUserConfiguration(scenario.LoginMode);
                var mgmtFromPs = psConfig.ToWindowsUserConfiguration();
                var backToPs = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtFromPs);

                // Assert PS -> Mgmt -> PS
                Assert.Equal(scenario.LoginMode, backToPs.LoginMode);

                // Act - Round trip conversion starting from Mgmt
                LoginMode? mgmtLoginMode = scenario.LoginMode.HasValue 
                    ? (scenario.LoginMode.Value == Microsoft.Azure.Batch.Common.LoginMode.Batch 
                        ? LoginMode.Batch 
                        : LoginMode.Interactive)
                    : (LoginMode?)null;
                    
                var mgmtConfig = new WindowsUserConfiguration(mgmtLoginMode);
                var psFromMgmt = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);
                var backToMgmt = psFromMgmt.ToWindowsUserConfiguration();

                // Assert Mgmt -> PS -> Mgmt
                Assert.Equal(mgmtLoginMode, backToMgmt.LoginMode);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch Windows user configuration

            // Test Batch login mode semantics - LOGON32_LOGON_BATCH for parallel processing
            var psBatchUser = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);
            var mgmtBatchUser = psBatchUser.ToWindowsUserConfiguration();
            var backToPs = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtBatchUser);

            Assert.NotNull(mgmtBatchUser);
            Assert.NotNull(mgmtBatchUser.LoginMode);
            Assert.Equal(LoginMode.Batch, mgmtBatchUser.LoginMode.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, backToPs.LoginMode.Value);

            // Test Interactive login mode semantics - LOGON32_LOGON_INTERACTIVE for GUI applications
            var psInteractiveUser = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            var mgmtInteractiveUser = psInteractiveUser.ToWindowsUserConfiguration();
            var backToPsInteractive = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtInteractiveUser);

            Assert.NotNull(mgmtInteractiveUser);
            Assert.NotNull(mgmtInteractiveUser.LoginMode);
            Assert.Equal(LoginMode.Interactive, mgmtInteractiveUser.LoginMode.Value);
            Assert.NotNull(backToPsInteractive);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, backToPsInteractive.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSWindowsUserConfiguration.FromWindowsUserConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_BatchWindowsUserContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch Windows user account configuration
            // WindowsUserConfiguration is used to configure Windows-specific user account properties in Azure Batch

            // Arrange - Test with realistic Batch Windows user scenarios
            var windowsUserScenarios = new PSWindowsUserConfiguration[]
            {
                // Batch processing user for long-running parallel workloads
                new PSWindowsUserConfiguration {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch
                    //Description = "Batch login mode recommended for long-running parallel processes"
                },
                // Interactive user for applications requiring GUI or interactive permissions
                new PSWindowsUserConfiguration {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive
                    //Description = "Interactive login mode for applications requiring interactive permissions"
                },
                // Default configuration letting system choose appropriate mode
                new PSWindowsUserConfiguration {
                    LoginMode = (Microsoft.Azure.Batch.Common.LoginMode?)null
                    //Description = "Default system-chosen login mode"
                }
            };

            foreach (var scenario in windowsUserScenarios)
            {
                // Act
                var psWindowsUserConfig = new PSWindowsUserConfiguration(scenario.LoginMode);
                var mgmtWindowsUserConfig = psWindowsUserConfig.ToWindowsUserConfiguration();

                // Assert - Should convert correctly for Batch Windows user account configuration
                Assert.NotNull(mgmtWindowsUserConfig);
                
                if (scenario.LoginMode.HasValue)
                {
                    Assert.NotNull(mgmtWindowsUserConfig.LoginMode);
                    var expectedMgmtMode = scenario.LoginMode.Value == Microsoft.Azure.Batch.Common.LoginMode.Batch
                        ? LoginMode.Batch
                        : LoginMode.Interactive;
                    Assert.Equal(expectedMgmtMode, mgmtWindowsUserConfig.LoginMode.Value);
                }
                else
                {
                    Assert.Null(mgmtWindowsUserConfig.LoginMode);
                }

                // Verify round-trip conversion maintains Batch Windows user semantics
                var backToPs = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtWindowsUserConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.LoginMode, backToPs.LoginMode);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_Win32LoginTypeSemantics_VerifyMapping()
        {
            // Test that the login mode mapping preserves Win32 logon type semantics

            // LOGON32_LOGON_BATCH semantics - optimized for batch processing
            var batchScenarios = new[]
            {
                "Long-running computational tasks",
                "Parallel data processing jobs", 
                "Background service operations",
                "Resource-intensive batch workloads"
            };

            foreach (var batchScenario in batchScenarios)
            {
                var psConfig = new PSWindowsUserConfiguration(Microsoft.Azure.Batch.Common.LoginMode.Batch);
                var mgmtConfig = psConfig.ToWindowsUserConfiguration();
                
                Assert.Equal(LoginMode.Batch, mgmtConfig.LoginMode.Value);
                // Batch mode should be used for scenarios like the current batchScenario
            }

            // LOGON32_LOGON_INTERACTIVE semantics - for GUI and interactive applications
            var interactiveScenarios = new[]
            {
                "Applications requiring GUI components",
                "Interactive desktop applications",
                "Applications needing interactive permissions",
                "Tools requiring user interaction capabilities"
            };

            foreach (var interactiveScenario in interactiveScenarios)
            {
                var psConfig = new PSWindowsUserConfiguration(Microsoft.Azure.Batch.Common.LoginMode.Interactive);
                var mgmtConfig = psConfig.ToWindowsUserConfiguration();
                
                Assert.Equal(LoginMode.Interactive, mgmtConfig.LoginMode.Value);
                // Interactive mode should be used for scenarios like the current interactiveScenario
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSWindowsUserConfiguration(Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            var mgmtConfig = new WindowsUserConfiguration(LoginMode.Batch);

            // Act
            var mgmtResult = psConfig.ToWindowsUserConfiguration();
            var psResult = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<WindowsUserConfiguration>(mgmtResult);
            Assert.IsType<PSWindowsUserConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psConfigs = new PSWindowsUserConfiguration[100];
            var mgmtConfigs = new WindowsUserConfiguration[100];

            for (int i = 0; i < 100; i++)
            {
                var loginMode = i % 3 == 0 ? (Microsoft.Azure.Batch.Common.LoginMode?)null
                    : (i % 2 == 0 ? Microsoft.Azure.Batch.Common.LoginMode.Batch 
                                  : Microsoft.Azure.Batch.Common.LoginMode.Interactive);
                psConfigs[i] = new PSWindowsUserConfiguration(loginMode);

                var mgmtLoginMode = i % 3 == 0 ? (LoginMode?)null
                    : (i % 2 == 0 ? LoginMode.Batch : LoginMode.Interactive);
                mgmtConfigs[i] = new WindowsUserConfiguration(mgmtLoginMode);
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psConfig in psConfigs)
                {
                    var mgmtResult = psConfig.ToWindowsUserConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtConfig in mgmtConfigs)
                {
                    var psResult = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion

        #region Real-world Scenario Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WindowsUserConfigurationConversions_BatchWorkloadScenarios_VerifySemantics()
        {
            // This test validates the conversions work correctly in realistic Azure Batch Windows workload scenarios

            // Arrange - Test scenarios matching actual Azure Batch Windows usage patterns
            var workloadScenarios = new PSWindowsUserConfiguration[]
            {
                // High-performance computing workloads
                new PSWindowsUserConfiguration{
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch
                    //WorkloadType = "High-performance computing (HPC) with parallel processing",
                    //Context = "Scientific simulations, financial modeling, image processing"
                },
                // Desktop application workloads requiring GUI
                new PSWindowsUserConfiguration{
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive
                    //WorkloadType = "Windows desktop applications requiring interactive permissions",
                    //Context = "Legacy Windows applications, GUI tools, applications with interactive components"
                },
                // System default configuration
                new PSWindowsUserConfiguration{
                    LoginMode = (Microsoft.Azure.Batch.Common.LoginMode?)null
                    //WorkloadType = "Standard batch processing with system defaults",
                    //Context = "General-purpose batch jobs where login mode is not critical"
                }
            };

            foreach (var scenario in workloadScenarios)
            {
                // Act - Test conversion in the context of Azure Batch Windows workloads
                var psConfig = new PSWindowsUserConfiguration(scenario.LoginMode);
                var mgmtConfig = psConfig.ToWindowsUserConfiguration();
                var roundTripPs = PSWindowsUserConfiguration.FromWindowsUserConfiguration(mgmtConfig);

                // Assert - Verify workload semantics are preserved
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                if (scenario.LoginMode.HasValue)
                {
                    var expectedMgmtMode = scenario.LoginMode.Value == Microsoft.Azure.Batch.Common.LoginMode.Batch
                        ? LoginMode.Batch
                        : LoginMode.Interactive;
                    
                    Assert.Equal(expectedMgmtMode, mgmtConfig.LoginMode.Value);
                    Assert.Equal(scenario.LoginMode.Value, roundTripPs.LoginMode.Value);

                    // Verify that login mode semantics match workload requirements
                    if (scenario.LoginMode.Value == Microsoft.Azure.Batch.Common.LoginMode.Batch)
                    {
                        Assert.Equal(LoginMode.Batch, mgmtConfig.LoginMode.Value);
                        // Batch mode should be used for HPC and parallel processing workloads
                    }
                    else
                    {
                        Assert.Equal(LoginMode.Interactive, mgmtConfig.LoginMode.Value);
                        // Interactive mode should be used for GUI applications and interactive tools
                    }
                }
                else
                {
                    Assert.Null(mgmtConfig.LoginMode);
                    Assert.Null(roundTripPs.LoginMode);
                    // Null mode allows system to choose appropriate default
                }
            }
        }

        #endregion
    }
}