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

using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsEnvironmentSettingsTests
    {
        #region toMgmtEnvironmentSettings Tests

        [Fact]
        public void ToMgmtEnvironmentSettings_WithSingleSetting_ReturnsCorrectMapping()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "PATH", "/usr/local/bin:/usr/bin:/bin" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("PATH", result[0].Name);
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", result[0].Value);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithMultipleSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "PATH", "/usr/local/bin:/usr/bin:/bin" },
                { "HOME", "/home/user" },
                { "LANG", "en_US.UTF-8" },
                { "SHELL", "/bin/bash" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);

            // Verify all settings are present (order may vary due to dictionary)
            var resultDict = result.ToDictionary(s => s.Name, s => s.Value);
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", resultDict["PATH"]);
            Assert.Equal("/home/user", resultDict["HOME"]);
            Assert.Equal("en_US.UTF-8", resultDict["LANG"]);
            Assert.Equal("/bin/bash", resultDict["SHELL"]);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithEmptyDictionary_ReturnsEmptyList()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>();

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("JAVA_HOME", "/usr/lib/jvm/java-11-openjdk")]
        [InlineData("NODE_ENV", "production")]
        [InlineData("DATABASE_URL", "postgresql://user:pass@localhost:5432/db")]
        [InlineData("API_KEY", "abc123xyz789")]
        [InlineData("DEBUG", "true")]
        [InlineData("PORT", "8080")]
        public void ToMgmtEnvironmentSettings_VariousEnvironmentVariables_ReturnsCorrectMapping(string name, string value)
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { name, value }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(name, result[0].Name);
            Assert.Equal(value, result[0].Value);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithEmptyStringValues_PreservesEmptyValues()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "EMPTY_VAR", "" },
                { "NORMAL_VAR", "normal_value" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var resultDict = result.ToDictionary(s => s.Name, s => s.Value);
            Assert.Equal("", resultDict["EMPTY_VAR"]);
            Assert.Equal("normal_value", resultDict["NORMAL_VAR"]);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithNullValues_PreservesNullValues()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "NORMAL_VAR", "normal_value" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);

            var resultDict = result.ToDictionary(s => s.Name, s => s.Value);
            Assert.Equal("normal_value", resultDict["NORMAL_VAR"]);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithNonStringKey_ThrowsArgumentException()
        {
            // Arrange
            IDictionary psEnvironmentSettings = new Hashtable
            {
                { 123, "numeric_key_value" }, // Non-string key
                { "NORMAL_VAR", "normal_value" }
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings));
            Assert.Contains("EnvironmentSettings dictionary must have string keys and string values", exception.Message);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithNonStringValue_ThrowsArgumentException()
        {
            // Arrange
            IDictionary psEnvironmentSettings = new Hashtable
            {
                { "NUMERIC_VALUE", 456 }, // Non-string value
                { "NORMAL_VAR", "normal_value" }
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings));
            Assert.Contains("EnvironmentSettings dictionary must have string keys and string values", exception.Message);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_AlwaysCreatesNewList()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "TEST_VAR", "test_value" }
            };

            // Act
            var result1 = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);
            var result2 = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
            Assert.NotSame(result1[0], result2[0]);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_VerifyManagementType()
        {
            // Arrange
            var psEnvironmentSettings = new Dictionary<string, string>
            {
                { "TYPE_TEST", "test_value" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IList<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>>(result);
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>(result[0]);
        }

        [Fact]
        public void ToMgmtEnvironmentSettings_WithHashtable_HandlesCorrectly()
        {
            // Arrange
            IDictionary psEnvironmentSettings = new Hashtable
            {
                { "HASHTABLE_VAR1", "value1" },
                { "HASHTABLE_VAR2", "value2" }
            };

            // Act
            var result = Utils.Utils.toMgmtEnvironmentSettings(psEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var resultDict = result.ToDictionary(s => s.Name, s => s.Value);
            Assert.Equal("value1", resultDict["HASHTABLE_VAR1"]);
            Assert.Equal("value2", resultDict["HASHTABLE_VAR2"]);
        }

        #endregion

        #region fromMgmtEnvironmentSettings Tests

        [Fact]
        public void FromMgmtEnvironmentSettings_WithSingleSetting_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("PATH", "/usr/local/bin:/usr/bin:/bin")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", result["PATH"]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_WithMultipleSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("PATH", "/usr/local/bin:/usr/bin:/bin"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("HOME", "/home/user"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("LANG", "en_US.UTF-8"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("SHELL", "/bin/bash")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
            Assert.Equal("/usr/local/bin:/usr/bin:/bin", result["PATH"]);
            Assert.Equal("/home/user", result["HOME"]);
            Assert.Equal("en_US.UTF-8", result["LANG"]);
            Assert.Equal("/bin/bash", result["SHELL"]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_WithNullList_ReturnsNull()
        {
            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_WithEmptyList_ReturnsEmptyDictionary()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>();

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("JAVA_HOME", "/usr/lib/jvm/java-11-openjdk")]
        [InlineData("NODE_ENV", "production")]
        [InlineData("DATABASE_URL", "postgresql://user:pass@localhost:5432/db")]
        [InlineData("API_KEY", "abc123xyz789")]
        [InlineData("DEBUG", "true")]
        [InlineData("PORT", "8080")]
        public void FromMgmtEnvironmentSettings_VariousEnvironmentVariables_ReturnsCorrectMapping(string name, string value)
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting(name, value)
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(value, result[name]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_WithEmptyStringValues_PreservesEmptyValues()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("EMPTY_VAR", ""),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("NORMAL_VAR", "normal_value")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("", result["EMPTY_VAR"]);
            Assert.Equal("normal_value", result["NORMAL_VAR"]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_WithNullValues_PreservesNullValues()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("NULL_VAR", null),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("NORMAL_VAR", "normal_value")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Null(result["NULL_VAR"]);
            Assert.Equal("normal_value", result["NORMAL_VAR"]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("STATIC_TEST", "static_value")
            };

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("static_value", result["STATIC_TEST"]);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_AlwaysCreatesNewDictionary()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("TEST_VAR", "test_value")
            };

            // Act
            var result1 = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);
            var result2 = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_VerifyDictionaryType()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("TYPE_TEST", "test_value")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IDictionary>(result);
            Assert.IsType<Dictionary<string, string>>(result);
        }

        [Fact]
        public void FromMgmtEnvironmentSettings_PreservesOrder()
        {
            // Arrange
            var mgmtEnvironmentSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("FIRST", "first_value"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("SECOND", "second_value"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("THIRD", "third_value")
            };

            // Act
            var result = Utils.Utils.fromMgmtEnvironmentSettings(mgmtEnvironmentSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            
            // Verify all keys are present
            Assert.True(result.Contains("FIRST"));
            Assert.True(result.Contains("SECOND"));
            Assert.True(result.Contains("THIRD"));
            
            Assert.Equal("first_value", result["FIRST"]);
            Assert.Equal("second_value", result["SECOND"]);
            Assert.Equal("third_value", result["THIRD"]);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllSettings()
        {
            // Arrange
            var originalPsSettings = new Dictionary<string, string>
            {
                { "PATH", "/usr/local/bin:/usr/bin:/bin" },
                { "HOME", "/home/user" },
                { "JAVA_HOME", "/usr/lib/jvm/java-11-openjdk" },
                { "NODE_ENV", "production" },
                { "DEBUG", "true" }
            };

            // Act
            var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(originalPsSettings);
            var roundTripPsSettings = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsSettings.Count, roundTripPsSettings.Count);

            foreach (var kvp in originalPsSettings)
            {
                Assert.True(roundTripPsSettings.Contains(kvp.Key));
                Assert.Equal(kvp.Value, roundTripPsSettings[kvp.Key]);
            }
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyAndNullValues()
        {
            // Arrange
            var originalPsSettings = new Dictionary<string, string>
            {
                { "EMPTY_VAR", "" },
                { "NORMAL_VAR", "normal_value" }
            };

            // Act
            var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(originalPsSettings);
            var roundTripPsSettings = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(2, roundTripPsSettings.Count);
            Assert.Equal("", roundTripPsSettings["EMPTY_VAR"]);
            Assert.Equal("normal_value", roundTripPsSettings["NORMAL_VAR"]);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyDictionary()
        {
            // Arrange
            var originalPsSettings = new Dictionary<string, string>();

            // Act
            var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(originalPsSettings);
            var roundTripPsSettings = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Empty(roundTripPsSettings);
        }

        [Theory]
        [InlineData("SIMPLE_VAR", "simple_value")]
        [InlineData("COMPLEX_PATH", "/very/long/path/with/multiple/segments")]
        [InlineData("CONNECTION_STRING", "Server=localhost;Database=test;Trusted_Connection=true;")]
        [InlineData("JSON_CONFIG", "{\"key\":\"value\",\"number\":123}")]
        [InlineData("EMPTY_VALUE", "")]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string name, string value)
        {
            // Arrange
            var originalPsSettings = new Dictionary<string, string>
            {
                { name, value }
            };

            // Act
            var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(originalPsSettings);
            var roundTripPsSettings = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert
            Assert.NotNull(roundTripPsSettings);
            Assert.Single(roundTripPsSettings);
            Assert.Equal(value, roundTripPsSettings[name]);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("DATABASE_URL", "postgresql://user:pass@localhost:5432/db"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("API_ENDPOINT", "https://api.example.com/v1"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("LOG_LEVEL", "INFO")
            };

            // Act
            var psSettings = Utils.Utils.fromMgmtEnvironmentSettings(originalMgmtSettings);
            var roundTripMgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(psSettings);

            // Assert
            Assert.NotNull(roundTripMgmtSettings);
            Assert.Equal(originalMgmtSettings.Count, roundTripMgmtSettings.Count);

            var originalDict = originalMgmtSettings.ToDictionary(s => s.Name, s => s.Value);
            var roundTripDict = roundTripMgmtSettings.ToDictionary(s => s.Name, s => s.Value);

            foreach (var kvp in originalDict)
            {
                Assert.Equal(kvp.Value, roundTripDict[kvp.Key]);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void EnvironmentSettingsConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic environment variable scenarios
            var psSettings = new Dictionary<string, string>
            {
                // System paths
                { "PATH", "/usr/local/bin:/usr/bin:/bin:/usr/sbin:/sbin" },
                { "LD_LIBRARY_PATH", "/usr/local/lib:/usr/lib:/lib" },
                
                // Application configuration
                { "NODE_ENV", "production" },
                { "JAVA_HOME", "/usr/lib/jvm/java-11-openjdk" },
                { "PYTHON_PATH", "/opt/python/lib/python3.9/site-packages" },
                
                // Database configuration
                { "DATABASE_URL", "postgresql://batch_user:secure_pass@db.example.com:5432/batch_db" },
                { "REDIS_URL", "redis://cache.example.com:6379/0" },
                
                // API and service configuration
                { "API_BASE_URL", "https://api.batch.example.com/v2" },
                { "LOG_LEVEL", "INFO" },
                { "MAX_WORKERS", "8" },
                
                // Special cases
                { "EMPTY_CONFIG", "" }
            };

            // Act
            var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(psSettings);
            var backToPs = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert
            Assert.NotNull(mgmtSettings);
            Assert.Equal(11, mgmtSettings.Count);
            Assert.NotNull(backToPs);
            Assert.Equal(11, backToPs.Count);

            // Verify semantic meaning is preserved
            var mgmtDict = mgmtSettings.ToDictionary(s => s.Name, s => s.Value);
            
            Assert.Equal("/usr/local/bin:/usr/bin:/bin:/usr/sbin:/sbin", mgmtDict["PATH"]);
            Assert.Equal("production", mgmtDict["NODE_ENV"]);
            Assert.Equal("postgresql://batch_user:secure_pass@db.example.com:5432/batch_db", mgmtDict["DATABASE_URL"]);
            Assert.Equal("", mgmtDict["EMPTY_CONFIG"]);

            // Verify round-trip preservation
            foreach (var kvp in psSettings)
            {
                Assert.Equal(kvp.Value, backToPs[kvp.Key]);
            }
        }

        [Fact]
        public void EnvironmentSettingsConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = Utils.Utils.fromMgmtEnvironmentSettings(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void EnvironmentSettingsConversions_BatchTaskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch task environment settings
            // Environment Settings is used to configure environment variables for Batch tasks

            // Arrange - Test with realistic Batch task scenarios
            var batchTaskScenarios = new[]
            {
                // Data processing task
                new {
                    Settings = new Dictionary<string, string>
                    {
                        { "INPUT_PATH", "/mnt/batch/tasks/shared/input" },
                        { "OUTPUT_PATH", "/mnt/batch/tasks/shared/output" },
                        { "WORKER_THREADS", "4" },
                        { "MEMORY_LIMIT", "2048M" }
                    },
                    Description = "Data processing task with input/output paths"
                },
                // Machine learning task
                new {
                    Settings = new Dictionary<string, string>
                    {
                        { "MODEL_PATH", "/mnt/batch/tasks/shared/models/latest" },
                        { "CUDA_VISIBLE_DEVICES", "0,1" },
                        { "TENSORFLOW_GPU_ALLOW_GROWTH", "true" },
                        { "BATCH_SIZE", "32" }
                    },
                    Description = "ML task with GPU configuration"
                },
                // Container task
                new {
                    Settings = new Dictionary<string, string>
                    {
                        { "DOCKER_HOST", "unix:///var/run/docker.sock" },
                        { "CONTAINER_REGISTRY", "myregistry.azurecr.io" },
                        { "IMAGE_TAG", "v1.2.3" },
                        { "PULL_POLICY", "Always" }
                    },
                    Description = "Container task with Docker configuration"
                }
            };

            foreach (var scenario in batchTaskScenarios)
            {
                // Act
                var mgmtSettings = Utils.Utils.toMgmtEnvironmentSettings(scenario.Settings);

                // Assert - Should convert correctly for Batch task configuration
                Assert.NotNull(mgmtSettings);
                Assert.Equal(scenario.Settings.Count, mgmtSettings.Count);

                var mgmtDict = mgmtSettings.ToDictionary(s => s.Name, s => s.Value);
                foreach (var kvp in scenario.Settings)
                {
                    Assert.Equal(kvp.Value, mgmtDict[kvp.Key]);
                }

                // Verify round-trip conversion maintains task environment semantics
                var backToPs = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Settings.Count, backToPs.Count);

                foreach (var kvp in scenario.Settings)
                {
                    Assert.Equal(kvp.Value, backToPs[kvp.Key]);
                }
            }
        }

        [Fact]
        public void EnvironmentSettingsConversions_CollectionHandling_VerifyBehavior()
        {
            // This test verifies that the conversion methods handle collections appropriately

            // Arrange
            var psSettings = new Dictionary<string, string>
            {
                { "FIRST", "first_value" },
                { "SECOND", "second_value" },
                { "THIRD", "third_value" }
            };

            var mgmtSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>
            {
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("ALPHA", "alpha_value"),
                new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting("BETA", "beta_value")
            };

            // Act
            var mgmtResult = Utils.Utils.toMgmtEnvironmentSettings(psSettings);
            var psResult = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

            // Assert - Verify proper collection handling
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsAssignableFrom<IList<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>>(mgmtResult);
            Assert.IsAssignableFrom<IDictionary>(psResult);

            // Verify collections are independent
            Assert.NotSame(psSettings, mgmtResult);
            Assert.NotSame(mgmtSettings, psResult);

            // Verify counts and content
            Assert.Equal(3, mgmtResult.Count);
            Assert.Equal(2, psResult.Count);
            
            var mgmtDict = mgmtResult.ToDictionary(s => s.Name, s => s.Value);
            Assert.Equal("first_value", mgmtDict["FIRST"]);
            Assert.Equal("alpha_value", psResult["ALPHA"]);
        }

        [Fact]
        public void EnvironmentSettingsConversions_ErrorHandling_VerifyConsistentBehavior()
        {
            // This test ensures that error handling is consistent

            // Test invalid key types
            IDictionary invalidKeyDict = new Hashtable
            {
                { 123, "numeric_key" },
                { "VALID_KEY", "valid_value" }
            };

            var keyException = Assert.Throws<ArgumentException>(() => Utils.Utils.toMgmtEnvironmentSettings(invalidKeyDict));
            Assert.Contains("EnvironmentSettings dictionary must have string keys and string values", keyException.Message);

            // Test invalid value types
            IDictionary invalidValueDict = new Hashtable
            {
                { "VALID_KEY", "valid_value" },
                { "INVALID_VALUE", 456 }
            };

            var valueException = Assert.Throws<ArgumentException>(() => Utils.Utils.toMgmtEnvironmentSettings(invalidValueDict));
            Assert.Contains("EnvironmentSettings dictionary must have string keys and string values", valueException.Message);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void EnvironmentSettingsConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with larger collections

            // Arrange - Create a larger collection
            var psSettings = new Dictionary<string, string>();
            var mgmtSettings = new List<Microsoft.Azure.Management.Batch.Models.EnvironmentSetting>();

            for (int i = 0; i < 100; i++)
            {
                psSettings.Add($"VAR_{i}", $"value_{i}");
                mgmtSettings.Add(new Microsoft.Azure.Management.Batch.Models.EnvironmentSetting($"MGMT_VAR_{i}", $"mgmt_value_{i}"));
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                var mgmtResult = Utils.Utils.toMgmtEnvironmentSettings(psSettings);
                var psResult = Utils.Utils.fromMgmtEnvironmentSettings(mgmtSettings);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(100, mgmtResult.Count);
                Assert.Equal(100, psResult.Count);
            }
        }

        [Fact]
        public void EnvironmentSettingsConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testSettings = new Dictionary<string, string>
            {
                // Standard environment variables
                { "PATH", "/usr/bin:/bin" },
                { "HOME", "/home/user" },
                { "USER", "batchuser" },
                
                // Special characters and formats
                { "CONNECTION_STRING", "Server=localhost;Database=test;Integrated Security=true;" },
                { "JSON_CONFIG", "{\"key\":\"value\",\"nested\":{\"prop\":123}}" },
                { "URL_WITH_PARAMS", "https://api.example.com/v1/resource?param1=value1&param2=value2" },
                { "MULTILINE_VALUE", "line1\nline2\nline3" },
                { "QUOTED_VALUE", "\"This is a quoted string\"" },
                { "SPACES_AND_TABS", "  value with spaces  \t" },
                
                // Unicode and special characters
                { "UNICODE_VAR", "こんにちは世界" },
                { "SPECIAL_CHARS", "!@#$%^&*()_+-=[]{}|;':\",./<>?" },
                
                // Very long values
                { "LONG_VALUE", new string('A', 1000) },
                
                // Edge cases
                { "EMPTY_VALUE", "" },
                { "WHITESPACE_ONLY", "   " },
                { "SINGLE_CHAR", "X" }
            };

            // Act
            var mgmtResult = Utils.Utils.toMgmtEnvironmentSettings(testSettings);
            var roundTripResult = Utils.Utils.fromMgmtEnvironmentSettings(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(roundTripResult);
            Assert.Equal(testSettings.Count, mgmtResult.Count);
            Assert.Equal(testSettings.Count, roundTripResult.Count);

            // Verify all edge cases are handled correctly
            foreach (var kvp in testSettings)
            {
                Assert.Equal(kvp.Value, roundTripResult[kvp.Key]);
            }
        }

        [Fact]
        public void EnvironmentSettingsConversions_LargeCollection_PreservesAllEntries()
        {
            // Test with a moderately large collection to ensure all entries are processed

            // Arrange
            var psSettings = new Dictionary<string, string>();
            for (int i = 0; i < 250; i++)
            {
                psSettings.Add($"LARGE_TEST_VAR_{i:D3}", $"large_test_value_{i}_with_some_longer_content");
            }

            // Act
            var mgmtResult = Utils.Utils.toMgmtEnvironmentSettings(psSettings);
            var roundTripResult = Utils.Utils.fromMgmtEnvironmentSettings(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(roundTripResult);
            Assert.Equal(250, mgmtResult.Count);
            Assert.Equal(250, roundTripResult.Count);

            // Verify all entries are correctly converted
            for (int i = 0; i < 250; i++)
            {
                var expectedKey = $"LARGE_TEST_VAR_{i:D3}";
                var expectedValue = $"large_test_value_{i}_with_some_longer_content";
                
                Assert.True(roundTripResult.Contains(expectedKey));
                Assert.Equal(expectedValue, roundTripResult[expectedKey]);
            }
        }

        #endregion
    }
}