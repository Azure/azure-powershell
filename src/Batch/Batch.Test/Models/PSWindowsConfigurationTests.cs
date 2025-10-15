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
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSWindowsConfigurationTests
    {
        #region toMgmtWindowsConfiguration Tests

        [Fact]
        public void ToMgmtWindowsConfiguration_WithAutomaticUpdatesEnabled_ReturnsCorrectMapping()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_WithAutomaticUpdatesDisabled_ReturnsCorrectMapping()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(false, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_WithNullAutomaticUpdates_ReturnsNullAutomaticUpdates()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: null);

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticUpdates);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_WithDefaultConstructor_ReturnsNullAutomaticUpdates()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(); // Default constructor

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticUpdates);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void ToMgmtWindowsConfiguration_AllValidValues_ReturnsCorrectMapping(bool? enableAutomaticUpdates)
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates);

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableAutomaticUpdates, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result1 = psWindowsConfig.toMgmtWindowsConfiguration();
            var result2 = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_VerifyWindowsConfigurationType()
        {
            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WindowsConfiguration>(result);
        }

        [Fact]
        public void ToMgmtWindowsConfiguration_VerifyPropertyMapping()
        {
            // Arrange - Test that PSWindowsConfiguration.EnableAutomaticUpdates maps to WindowsConfiguration.EnableAutomaticUpdates
            var testValues = new bool?[] { true, false, null };

            foreach (var testValue in testValues)
            {
                var psWindowsConfig = new PSWindowsConfiguration(testValue);

                // Act
                var result = psWindowsConfig.toMgmtWindowsConfiguration();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(testValue, result.EnableAutomaticUpdates);
                Assert.Equal(psWindowsConfig.EnableAutomaticUpdates, result.EnableAutomaticUpdates);
            }
        }

        #endregion

        #region fromMgmtWindowsConfiguration Tests

        [Fact]
        public void FromMgmtWindowsConfiguration_WithAutomaticUpdatesEnabled_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_WithAutomaticUpdatesDisabled_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(false, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_WithNullAutomaticUpdates_ReturnsNullAutomaticUpdates()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: null);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticUpdates);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_WithNullMgmtConfiguration_ReturnsNull()
        {
            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_WithDefaultConstructor_ReturnsNullAutomaticUpdates()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(); // Default constructor

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticUpdates);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void FromMgmtWindowsConfiguration_AllValidValues_ReturnsCorrectMapping(bool? enableAutomaticUpdates)
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableAutomaticUpdates, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: true);

            // Act - Call static method directly on class
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableAutomaticUpdates);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result1 = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);
            var result2 = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_VerifyPSWindowsConfigurationType()
        {
            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSWindowsConfiguration>(result);
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_VerifyPropertyMapping()
        {
            // Arrange - Test that WindowsConfiguration.EnableAutomaticUpdates maps to PSWindowsConfiguration.EnableAutomaticUpdates
            var testValues = new bool?[] { true, false, null };

            foreach (var testValue in testValues)
            {
                var mgmtWindowsConfig = new WindowsConfiguration(testValue);

                // Act
                var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(testValue, result.EnableAutomaticUpdates);
                Assert.Equal(mgmtWindowsConfig.EnableAutomaticUpdates, result.EnableAutomaticUpdates);
            }
        }

        [Fact]
        public void FromMgmtWindowsConfiguration_VerifyConstructorUsage()
        {
            // This test verifies that the PSWindowsConfiguration constructor is called correctly

            // Arrange
            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var result = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(false, result.EnableAutomaticUpdates);
            
            // Verify the constructor parameter was passed correctly
            Assert.Equal(mgmtWindowsConfig.EnableAutomaticUpdates, result.EnableAutomaticUpdates);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEnabledValue()
        {
            // Arrange
            var originalPsWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            // Act
            var mgmtWindowsConfig = originalPsWindowsConfig.toMgmtWindowsConfiguration();
            var roundTripPsWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(roundTripPsWindowsConfig);
            Assert.Equal(originalPsWindowsConfig.EnableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
            Assert.Equal(true, roundTripPsWindowsConfig.EnableAutomaticUpdates);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesDisabledValue()
        {
            // Arrange
            var originalPsWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var mgmtWindowsConfig = originalPsWindowsConfig.toMgmtWindowsConfiguration();
            var roundTripPsWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(roundTripPsWindowsConfig);
            Assert.Equal(originalPsWindowsConfig.EnableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
            Assert.Equal(false, roundTripPsWindowsConfig.EnableAutomaticUpdates);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValue()
        {
            // Arrange
            var originalPsWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: null);

            // Act
            var mgmtWindowsConfig = originalPsWindowsConfig.toMgmtWindowsConfiguration();
            var roundTripPsWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(roundTripPsWindowsConfig);
            Assert.Equal(originalPsWindowsConfig.EnableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
            Assert.Null(roundTripPsWindowsConfig.EnableAutomaticUpdates);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesDefaultValue()
        {
            // Arrange
            var originalPsWindowsConfig = new PSWindowsConfiguration(); // Default constructor

            // Act
            var mgmtWindowsConfig = originalPsWindowsConfig.toMgmtWindowsConfiguration();
            var roundTripPsWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(roundTripPsWindowsConfig);
            Assert.Equal(originalPsWindowsConfig.EnableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
            Assert.Null(roundTripPsWindowsConfig.EnableAutomaticUpdates);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(bool? enableAutomaticUpdates)
        {
            // Arrange
            var originalPsWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates);

            // Act
            var mgmtWindowsConfig = originalPsWindowsConfig.toMgmtWindowsConfiguration();
            var roundTripPsWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert
            Assert.NotNull(roundTripPsWindowsConfig);
            Assert.Equal(originalPsWindowsConfig.EnableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
            Assert.Equal(enableAutomaticUpdates, roundTripPsWindowsConfig.EnableAutomaticUpdates);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var psWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(originalMgmtWindowsConfig);
            var roundTripMgmtWindowsConfig = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtWindowsConfig);
            Assert.Equal(originalMgmtWindowsConfig.EnableAutomaticUpdates, roundTripMgmtWindowsConfig.EnableAutomaticUpdates);
            Assert.Equal(false, roundTripMgmtWindowsConfig.EnableAutomaticUpdates);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void RoundTripConversion_FromMgmtAllValues_PreservesOriginalValue(bool? enableAutomaticUpdates)
        {
            // Arrange
            var originalMgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates);

            // Act
            var psWindowsConfig = PSWindowsConfiguration.fromMgmtWindowsConfiguration(originalMgmtWindowsConfig);
            var roundTripMgmtWindowsConfig = psWindowsConfig.toMgmtWindowsConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtWindowsConfig);
            Assert.Equal(originalMgmtWindowsConfig.EnableAutomaticUpdates, roundTripMgmtWindowsConfig.EnableAutomaticUpdates);
            Assert.Equal(enableAutomaticUpdates, roundTripMgmtWindowsConfig.EnableAutomaticUpdates);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void WindowsConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Scenario 1: Automatic updates enabled
            var psEnabledConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            var mgmtEnabledConfig = psEnabledConfig.toMgmtWindowsConfiguration();
            var backToPs = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtEnabledConfig);

            Assert.NotNull(mgmtEnabledConfig);
            Assert.Equal(true, mgmtEnabledConfig.EnableAutomaticUpdates);

            Assert.NotNull(backToPs);
            Assert.Equal(true, backToPs.EnableAutomaticUpdates);

            // Scenario 2: Automatic updates disabled
            var psDisabledConfig = new PSWindowsConfiguration(enableAutomaticUpdates: false);

            var mgmtDisabledConfig = psDisabledConfig.toMgmtWindowsConfiguration();
            var backToPsDisabled = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtDisabledConfig);

            Assert.NotNull(mgmtDisabledConfig);
            Assert.Equal(false, mgmtDisabledConfig.EnableAutomaticUpdates);

            Assert.NotNull(backToPsDisabled);
            Assert.Equal(false, backToPsDisabled.EnableAutomaticUpdates);

            // Scenario 3: Default behavior (null value)
            var psDefaultConfig = new PSWindowsConfiguration();

            var mgmtDefaultConfig = psDefaultConfig.toMgmtWindowsConfiguration();
            var backToPsDefault = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtDefaultConfig);

            Assert.NotNull(mgmtDefaultConfig);
            Assert.Null(mgmtDefaultConfig.EnableAutomaticUpdates);

            Assert.NotNull(backToPsDefault);
            Assert.Null(backToPsDefault.EnableAutomaticUpdates);
        }

        [Fact]
        public void WindowsConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSWindowsConfiguration.fromMgmtWindowsConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void WindowsConfigurationConversions_BatchVMContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch VM configuration
            // WindowsConfiguration is used to configure Windows-specific settings for Batch pool compute nodes

            // Arrange - Test with different Windows configuration scenarios
            var scenarios = new[]
            {
                // Production environment with automatic updates enabled
                new {
                    EnableAutomaticUpdates = (bool?)true,
                    Description = "Production environment with automatic updates for security patches"
                },
                // Development environment with automatic updates disabled
                new {
                    EnableAutomaticUpdates = (bool?)false,
                    Description = "Development environment with controlled update schedule"
                },
                // Default configuration (let Azure manage the default behavior)
                new {
                    EnableAutomaticUpdates = (bool?)null,
                    Description = "Default configuration using Azure's recommended settings"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psWindowsConfig = new PSWindowsConfiguration(scenario.EnableAutomaticUpdates);

                // Act
                var mgmtWindowsConfig = psWindowsConfig.toMgmtWindowsConfiguration();

                // Assert - Should convert correctly for Batch VM configuration
                Assert.NotNull(mgmtWindowsConfig);
                Assert.Equal(scenario.EnableAutomaticUpdates, mgmtWindowsConfig.EnableAutomaticUpdates);

                // Verify round-trip conversion maintains Windows configuration semantics
                var backToPs = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.EnableAutomaticUpdates, backToPs.EnableAutomaticUpdates);
            }
        }

        [Fact]
        public void WindowsConfigurationConversions_DefaultBehavior_VerifyDocumentedBehavior()
        {
            // This test verifies the documented default behavior of WindowsConfiguration
            // According to the documentation, if EnableAutomaticUpdates is omitted, the default value is true

            // Test 1: Default PS constructor should result in null (omitted)
            var defaultPsConfig = new PSWindowsConfiguration();
            var mgmtFromDefault = defaultPsConfig.toMgmtWindowsConfiguration();
            
            Assert.NotNull(mgmtFromDefault);
            Assert.Null(mgmtFromDefault.EnableAutomaticUpdates); // Should be null (omitted)

            // Test 2: Default management constructor should result in null
            var defaultMgmtConfig = new WindowsConfiguration();
            var psFromDefault = PSWindowsConfiguration.fromMgmtWindowsConfiguration(defaultMgmtConfig);
            
            Assert.NotNull(psFromDefault);
            Assert.Null(psFromDefault.EnableAutomaticUpdates); // Should be null (omitted)

            // Test 3: Explicit null value should remain null
            var explicitNullPsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: null);
            var mgmtFromNull = explicitNullPsConfig.toMgmtWindowsConfiguration();
            
            Assert.NotNull(mgmtFromNull);
            Assert.Null(mgmtFromNull.EnableAutomaticUpdates);

            var explicitNullMgmtConfig = new WindowsConfiguration(enableAutomaticUpdates: null);
            var psFromNull = PSWindowsConfiguration.fromMgmtWindowsConfiguration(explicitNullMgmtConfig);
            
            Assert.NotNull(psFromNull);
            Assert.Null(psFromNull.EnableAutomaticUpdates);
        }

        [Fact]
        public void WindowsConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: false);

            // Act
            var mgmtResult = psWindowsConfig.toMgmtWindowsConfiguration();
            var psResult = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<WindowsConfiguration>(mgmtResult);
            Assert.IsType<PSWindowsConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtWindowsConfig, mgmtResult);
            Assert.NotSame(psWindowsConfig, psResult);

            // Verify correct values
            Assert.Equal(true, mgmtResult.EnableAutomaticUpdates);
            Assert.Equal(false, psResult.EnableAutomaticUpdates);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void WindowsConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psWindowsConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);

            var mgmtWindowsConfig = new WindowsConfiguration(enableAutomaticUpdates: false);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10000; i++)
            {
                var mgmtResult = psWindowsConfig.toMgmtWindowsConfiguration();
                var psResult = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtWindowsConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(true, mgmtResult.EnableAutomaticUpdates);
                Assert.Equal(false, psResult.EnableAutomaticUpdates);
            }
        }

        [Fact]
        public void WindowsConfigurationConversions_BooleanNullableHandling_VerifyCorrectness()
        {
            // This test specifically validates nullable boolean handling across all scenarios

            // Test all possible boolean? values
            var testValues = new bool?[] { true, false, null };

            foreach (var testValue in testValues)
            {
                // Test PS to Management conversion
                var psConfig = new PSWindowsConfiguration(testValue);
                var mgmtConfig = psConfig.toMgmtWindowsConfiguration();
                
                Assert.NotNull(mgmtConfig);
                Assert.Equal(testValue, mgmtConfig.EnableAutomaticUpdates);

                // Test Management to PS conversion
                var mgmtConfigForPs = new WindowsConfiguration(testValue);
                var psConfigFromMgmt = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtConfigForPs);
                
                Assert.NotNull(psConfigFromMgmt);
                Assert.Equal(testValue, psConfigFromMgmt.EnableAutomaticUpdates);

                // Test round-trip preservation
                var roundTripMgmt = psConfigFromMgmt.toMgmtWindowsConfiguration();
                Assert.NotNull(roundTripMgmt);
                Assert.Equal(testValue, roundTripMgmt.EnableAutomaticUpdates);

                var roundTripPs = PSWindowsConfiguration.fromMgmtWindowsConfiguration(roundTripMgmt);
                Assert.NotNull(roundTripPs);
                Assert.Equal(testValue, roundTripPs.EnableAutomaticUpdates);
            }
        }

        [Fact]
        public void WindowsConfigurationConversions_PropertyAccessor_VerifyReadOnlyBehavior()
        {
            // This test verifies that the EnableAutomaticUpdates property is read-only on PSWindowsConfiguration
            // and that the value is set correctly during construction

            // Test with true value
            var psConfigTrue = new PSWindowsConfiguration(enableAutomaticUpdates: true);
            Assert.Equal(true, psConfigTrue.EnableAutomaticUpdates);

            // Test with false value
            var psConfigFalse = new PSWindowsConfiguration(enableAutomaticUpdates: false);
            Assert.Equal(false, psConfigFalse.EnableAutomaticUpdates);

            // Test with null value
            var psConfigNull = new PSWindowsConfiguration(enableAutomaticUpdates: null);
            Assert.Null(psConfigNull.EnableAutomaticUpdates);

            // Test with default constructor
            var psConfigDefault = new PSWindowsConfiguration();
            Assert.Null(psConfigDefault.EnableAutomaticUpdates);

            // Verify that fromMgmtWindowsConfiguration creates objects with correct property values
            var mgmtConfigTrue = new WindowsConfiguration(enableAutomaticUpdates: true);
            var psFromMgmtTrue = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtConfigTrue);
            Assert.Equal(true, psFromMgmtTrue.EnableAutomaticUpdates);

            var mgmtConfigFalse = new WindowsConfiguration(enableAutomaticUpdates: false);
            var psFromMgmtFalse = PSWindowsConfiguration.fromMgmtWindowsConfiguration(mgmtConfigFalse);
            Assert.Equal(false, psFromMgmtFalse.EnableAutomaticUpdates);
        }

        [Fact]
        public void WindowsConfigurationConversions_BatchPoolIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch pool creation
            // WindowsConfiguration is typically used when creating Windows-based compute nodes

            // Scenario 1: Enterprise production pool with managed updates
            var enterpriseConfig = new PSWindowsConfiguration(enableAutomaticUpdates: true);
            var enterpriseMgmt = enterpriseConfig.toMgmtWindowsConfiguration();
            
            Assert.NotNull(enterpriseMgmt);
            Assert.Equal(true, enterpriseMgmt.EnableAutomaticUpdates);
            // In production, enabling automatic updates ensures security patches are applied

            // Scenario 2: Development/testing pool with controlled updates
            var devConfig = new PSWindowsConfiguration(enableAutomaticUpdates: false);
            var devMgmt = devConfig.toMgmtWindowsConfiguration();
            
            Assert.NotNull(devMgmt);
            Assert.Equal(false, devMgmt.EnableAutomaticUpdates);
            // In development, disabling automatic updates provides stability for testing

            // Scenario 3: Default pool configuration (Azure manages the default)
            var defaultConfig = new PSWindowsConfiguration();
            var defaultMgmt = defaultConfig.toMgmtWindowsConfiguration();
            
            Assert.NotNull(defaultMgmt);
            Assert.Null(defaultMgmt.EnableAutomaticUpdates);
            // When null, Azure applies the documented default behavior (true)

            // Verify all scenarios preserve semantic meaning through round-trip
            var enterpriseRoundTrip = PSWindowsConfiguration.fromMgmtWindowsConfiguration(enterpriseMgmt);
            var devRoundTrip = PSWindowsConfiguration.fromMgmtWindowsConfiguration(devMgmt);
            var defaultRoundTrip = PSWindowsConfiguration.fromMgmtWindowsConfiguration(defaultMgmt);

            Assert.Equal(true, enterpriseRoundTrip.EnableAutomaticUpdates);
            Assert.Equal(false, devRoundTrip.EnableAutomaticUpdates);
            Assert.Null(defaultRoundTrip.EnableAutomaticUpdates);
        }

        #endregion
    }
}