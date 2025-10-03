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
using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Management.Batch.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsContainerHostBatchBindMountsTests
    {
        #region toMgmtContainerHostBatchBindMounts Tests

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_WithSingleMount_ReturnsCorrectMapping()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Shared", result[0].Source);
            Assert.Equal(false, result[0].IsReadOnly);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_WithMultipleMounts_ReturnsCorrectMapping()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                },
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Startup",
                    IsReadOnly = true
                },
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "VfsMounts",
                    IsReadOnly = false
                }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            
            Assert.Equal("Shared", result[0].Source);
            Assert.Equal(false, result[0].IsReadOnly);
            
            Assert.Equal("Startup", result[1].Source);
            Assert.Equal(true, result[1].IsReadOnly);
            
            Assert.Equal("VfsMounts", result[2].Source);
            Assert.Equal(false, result[2].IsReadOnly);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_WithNullList_ReturnsNull()
        {
            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_WithEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>();

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("Shared", true)]
        [InlineData("Startup", false)]
        [InlineData("VfsMounts", true)]
        [InlineData("Task", false)]
        [InlineData("JobPrep", true)]
        [InlineData("Applications", false)]
        public void ToMgmtContainerHostBatchBindMounts_AllValidSources_ReturnsCorrectMapping(string source, bool isReadOnly)
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = source,
                    IsReadOnly = isReadOnly
                }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(source, result[0].Source);
            Assert.Equal(isReadOnly, result[0].IsReadOnly);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_WithNullSourceAndNullIsReadOnly_PreservesNullValues()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = null,
                    IsReadOnly = null
                }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Null(result[0].Source);
            Assert.Null(result[0].IsReadOnly);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_AlwaysCreatesNewList()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                }
            };

            // Act
            var result1 = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
            var result2 = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
            Assert.NotSame(result1[0], result2[0]);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_VerifyManagementType()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Task",
                    IsReadOnly = true
                }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IList<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>>(result);
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>(result[0]);
        }

        [Fact]
        public void ToMgmtContainerHostBatchBindMounts_PreservesOrder()
        {
            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "First", IsReadOnly = false },
                new PSContainerHostBatchBindMountEntry { Source = "Second", IsReadOnly = true },
                new PSContainerHostBatchBindMountEntry { Source = "Third", IsReadOnly = false }
            };

            // Act
            var result = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("First", result[0].Source);
            Assert.Equal("Second", result[1].Source);
            Assert.Equal("Third", result[2].Source);
        }

        #endregion

        #region fromMgmtContainerHostBatchBindMounts Tests

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_WithSingleMount_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Shared", result[0].Source);
            Assert.Equal(false, result[0].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_WithMultipleMounts_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Startup",
                    IsReadOnly = true
                },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Applications",
                    IsReadOnly = false
                }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            
            Assert.Equal("Shared", result[0].Source);
            Assert.Equal(false, result[0].IsReadOnly);
            
            Assert.Equal("Startup", result[1].Source);
            Assert.Equal(true, result[1].IsReadOnly);
            
            Assert.Equal("Applications", result[2].Source);
            Assert.Equal(false, result[2].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_WithNullList_ReturnsNull()
        {
            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_WithEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>();

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("Shared", true)]
        [InlineData("Startup", false)]
        [InlineData("VfsMounts", true)]
        [InlineData("Task", false)]
        [InlineData("JobPrep", true)]
        [InlineData("Applications", false)]
        public void FromMgmtContainerHostBatchBindMounts_AllValidSources_ReturnsCorrectMapping(string source, bool isReadOnly)
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = source,
                    IsReadOnly = isReadOnly
                }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(source, result[0].Source);
            Assert.Equal(isReadOnly, result[0].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_WithNullSourceAndNullIsReadOnly_PreservesNullValues()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = null,
                    IsReadOnly = null
                }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Null(result[0].Source);
            Assert.Null(result[0].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Task",
                    IsReadOnly = true
                }
            };

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Task", result[0].Source);
            Assert.Equal(true, result[0].IsReadOnly);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_AlwaysCreatesNewList()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                }
            };

            // Act
            var result1 = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);
            var result2 = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
            Assert.NotSame(result1[0], result2[0]);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_VerifyPSType()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "JobPrep",
                    IsReadOnly = true
                }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IList<PSContainerHostBatchBindMountEntry>>(result);
            Assert.IsType<PSContainerHostBatchBindMountEntry>(result[0]);
        }

        [Fact]
        public void FromMgmtContainerHostBatchBindMounts_PreservesOrder()
        {
            // Arrange
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry { Source = "First", IsReadOnly = false },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry { Source = "Second", IsReadOnly = true },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry { Source = "Third", IsReadOnly = false }
            };

            // Act
            var result = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("First", result[0].Source);
            Assert.Equal("Second", result[1].Source);
            Assert.Equal("Third", result[2].Source);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Shared",
                    IsReadOnly = false
                },
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Startup",
                    IsReadOnly = true
                },
                new PSContainerHostBatchBindMountEntry
                {
                    Source = "Task",
                    IsReadOnly = false
                }
            };

            // Act
            var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(originalPsBindMounts);
            var roundTripPsBindMounts = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(roundTripPsBindMounts);
            Assert.Equal(originalPsBindMounts.Count, roundTripPsBindMounts.Count);

            for (int i = 0; i < originalPsBindMounts.Count; i++)
            {
                Assert.Equal(originalPsBindMounts[i].Source, roundTripPsBindMounts[i].Source);
                Assert.Equal(originalPsBindMounts[i].IsReadOnly, roundTripPsBindMounts[i].IsReadOnly);
            }
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = null,
                    IsReadOnly = null
                }
            };

            // Act
            var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(originalPsBindMounts);
            var roundTripPsBindMounts = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(roundTripPsBindMounts);
            Assert.Single(roundTripPsBindMounts);
            Assert.Null(roundTripPsBindMounts[0].Source);
            Assert.Null(roundTripPsBindMounts[0].IsReadOnly);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyList()
        {
            // Arrange
            var originalPsBindMounts = new List<PSContainerHostBatchBindMountEntry>();

            // Act
            var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(originalPsBindMounts);
            var roundTripPsBindMounts = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(roundTripPsBindMounts);
            Assert.Empty(roundTripPsBindMounts);
        }

        [Theory]
        [InlineData("Shared", true)]
        [InlineData("Startup", false)]
        [InlineData("VfsMounts", true)]
        [InlineData("Task", false)]
        [InlineData("JobPrep", true)]
        [InlineData("Applications", false)]
        public void RoundTripConversion_AllValidSources_PreservesOriginalValue(string source, bool isReadOnly)
        {
            // Arrange
            var originalPsBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry
                {
                    Source = source,
                    IsReadOnly = isReadOnly
                }
            };

            // Act
            var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(originalPsBindMounts);
            var roundTripPsBindMounts = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(roundTripPsBindMounts);
            Assert.Single(roundTripPsBindMounts);
            Assert.Equal(source, roundTripPsBindMounts[0].Source);
            Assert.Equal(isReadOnly, roundTripPsBindMounts[0].IsReadOnly);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "VfsMounts",
                    IsReadOnly = true
                },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry
                {
                    Source = "Applications",
                    IsReadOnly = false
                }
            };

            // Act
            var psBindMounts = Utils.Utils.fromMgmtContainerHostBatchBindMounts(originalMgmtBindMounts);
            var roundTripMgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

            // Assert
            Assert.NotNull(roundTripMgmtBindMounts);
            Assert.Equal(originalMgmtBindMounts.Count, roundTripMgmtBindMounts.Count);

            for (int i = 0; i < originalMgmtBindMounts.Count; i++)
            {
                Assert.Equal(originalMgmtBindMounts[i].Source, roundTripMgmtBindMounts[i].Source);
                Assert.Equal(originalMgmtBindMounts[i].IsReadOnly, roundTripMgmtBindMounts[i].IsReadOnly);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ContainerHostBatchBindMountsConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic container bind mount scenarios
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                // Shared directory for data exchange between tasks
                new PSContainerHostBatchBindMountEntry { Source = "Shared", IsReadOnly = false },
                // Startup scripts mounted as read-only
                new PSContainerHostBatchBindMountEntry { Source = "Startup", IsReadOnly = true },
                // VFS mounts for special file system access
                new PSContainerHostBatchBindMountEntry { Source = "VfsMounts", IsReadOnly = false },
                // Task working directory
                new PSContainerHostBatchBindMountEntry { Source = "Task", IsReadOnly = false },
                // Job preparation artifacts
                new PSContainerHostBatchBindMountEntry { Source = "JobPrep", IsReadOnly = true },
                // Application binaries
                new PSContainerHostBatchBindMountEntry { Source = "Applications", IsReadOnly = true }
            };

            // Act
            var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
            var backToPs = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert
            Assert.NotNull(mgmtBindMounts);
            Assert.Equal(6, mgmtBindMounts.Count);
            Assert.NotNull(backToPs);
            Assert.Equal(6, backToPs.Count);

            // Verify semantic meaning is preserved
            for (int i = 0; i < psBindMounts.Count; i++)
            {
                Assert.Equal(psBindMounts[i].Source, mgmtBindMounts[i].Source);
                Assert.Equal(psBindMounts[i].IsReadOnly, mgmtBindMounts[i].IsReadOnly);
                Assert.Equal(psBindMounts[i].Source, backToPs[i].Source);
                Assert.Equal(psBindMounts[i].IsReadOnly, backToPs[i].IsReadOnly);
            }
        }

        [Fact]
        public void ContainerHostBatchBindMountsConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNullToMgmt = Utils.Utils.toMgmtContainerHostBatchBindMounts(null);
            var resultFromNullFromMgmt = Utils.Utils.fromMgmtContainerHostBatchBindMounts(null);

            // Assert
            Assert.Null(resultFromNullToMgmt);
            Assert.Null(resultFromNullFromMgmt);
        }

        [Fact]
        public void ContainerHostBatchBindMountsConversions_BatchContainerContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch container configuration
            // ContainerHostBatchBindMountEntry is used to mount host paths into container tasks

            // Arrange - Test with realistic Batch container scenarios
            var containerScenarios = new[]
            {
                // Data processing scenario
                new { Source = "Shared", IsReadOnly = false, Description = "Shared data directory for task coordination" },
                // Application deployment scenario  
                new { Source = "Applications", IsReadOnly = true, Description = "Read-only application binaries" },
                // Task execution scenario
                new { Source = "Task", IsReadOnly = false, Description = "Task working directory with read/write access" },
                // Job preparation scenario
                new { Source = "JobPrep", IsReadOnly = true, Description = "Job preparation artifacts as read-only" },
                // Startup configuration scenario
                new { Source = "Startup", IsReadOnly = true, Description = "Startup scripts and configuration" },
                // VFS scenario
                new { Source = "VfsMounts", IsReadOnly = false, Description = "Virtual file system mounts" }
            };

            foreach (var scenario in containerScenarios)
            {
                // Arrange
                var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
                {
                    new PSContainerHostBatchBindMountEntry
                    {
                        Source = scenario.Source,
                        IsReadOnly = scenario.IsReadOnly
                    }
                };

                // Act
                var mgmtBindMounts = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);

                // Assert - Should convert correctly for Batch container configuration
                Assert.NotNull(mgmtBindMounts);
                Assert.Single(mgmtBindMounts);
                Assert.Equal(scenario.Source, mgmtBindMounts[0].Source);
                Assert.Equal(scenario.IsReadOnly, mgmtBindMounts[0].IsReadOnly);

                // Verify round-trip conversion maintains container bind mount semantics
                var backToPs = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);
                Assert.NotNull(backToPs);
                Assert.Single(backToPs);
                Assert.Equal(scenario.Source, backToPs[0].Source);
                Assert.Equal(scenario.IsReadOnly, backToPs[0].IsReadOnly);
            }
        }

        [Fact]
        public void ContainerHostBatchBindMountsConversions_CollectionHandling_VerifyBehavior()
        {
            // This test verifies that the conversion methods handle collections appropriately

            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
            {
                new PSContainerHostBatchBindMountEntry { Source = "First", IsReadOnly = false },
                new PSContainerHostBatchBindMountEntry { Source = "Second", IsReadOnly = true },
                new PSContainerHostBatchBindMountEntry { Source = "Third", IsReadOnly = false }
            };

            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>
            {
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry { Source = "Alpha", IsReadOnly = true },
                new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry { Source = "Beta", IsReadOnly = false }
            };

            // Act
            var mgmtResult = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
            var psResult = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

            // Assert - Verify proper collection handling
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsAssignableFrom<IList<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>>(mgmtResult);
            Assert.IsAssignableFrom<IList<PSContainerHostBatchBindMountEntry>>(psResult);

            // Verify collections are independent
            Assert.NotSame(psBindMounts, mgmtResult);
            Assert.NotSame(mgmtBindMounts, psResult);

            // Verify counts and order
            Assert.Equal(3, mgmtResult.Count);
            Assert.Equal(2, psResult.Count);
            Assert.Equal("First", mgmtResult[0].Source);
            Assert.Equal("Alpha", psResult[0].Source);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ContainerHostBatchBindMountsConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with larger collections

            // Arrange - Create a larger collection
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>();
            var mgmtBindMounts = new List<Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry>();
            
            for (int i = 0; i < 100; i++)
            {
                psBindMounts.Add(new PSContainerHostBatchBindMountEntry 
                { 
                    Source = $"Source{i}", 
                    IsReadOnly = i % 2 == 0 
                });
                
                mgmtBindMounts.Add(new Microsoft.Azure.Management.Batch.Models.ContainerHostBatchBindMountEntry 
                { 
                    Source = $"MgmtSource{i}", 
                    IsReadOnly = i % 3 == 0 
                });
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                var mgmtResult = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
                var psResult = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtBindMounts);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(100, mgmtResult.Count);
                Assert.Equal(100, psResult.Count);
            }
        }

        [Fact]
        public void ContainerHostBatchBindMountsConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testBindMounts = new[]
            {
                // Standard sources
                new { Source = "Shared", IsReadOnly = (bool?)false },
                new { Source = "Startup", IsReadOnly = (bool?)true },
                new { Source = "VfsMounts", IsReadOnly = (bool?)false },
                new { Source = "Task", IsReadOnly = (bool?)true },
                new { Source = "JobPrep", IsReadOnly = (bool?)false },
                new { Source = "Applications", IsReadOnly = (bool?)true },
                // Edge cases
                new { Source = "", IsReadOnly = (bool?)false },
                new { Source = (string)null, IsReadOnly = (bool?)null },
                new { Source = "   ", IsReadOnly = (bool?)true }, // Whitespace
                new { Source = "VeryLongSourceNameForTestingPurposes", IsReadOnly = (bool?)false }
            };

            foreach (var testMount in testBindMounts)
            {
                // Arrange
                var psBindMounts = new List<PSContainerHostBatchBindMountEntry>
                {
                    new PSContainerHostBatchBindMountEntry
                    {
                        Source = testMount.Source,
                        IsReadOnly = testMount.IsReadOnly
                    }
                };

                // Act
                var mgmtResult = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
                var roundTripResult = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Single(mgmtResult);
                Assert.Single(roundTripResult);
                Assert.Equal(testMount.Source, mgmtResult[0].Source);
                Assert.Equal(testMount.IsReadOnly, mgmtResult[0].IsReadOnly);
                Assert.Equal(testMount.Source, roundTripResult[0].Source);
                Assert.Equal(testMount.IsReadOnly, roundTripResult[0].IsReadOnly);
            }
        }

        [Fact]
        public void ContainerHostBatchBindMountsConversions_LargeCollection_PreservesAllEntries()
        {
            // Test with a moderately large collection to ensure all entries are processed

            // Arrange
            var psBindMounts = new List<PSContainerHostBatchBindMountEntry>();
            for (int i = 0; i < 50; i++)
            {
                psBindMounts.Add(new PSContainerHostBatchBindMountEntry
                {
                    Source = $"Source{i}",
                    IsReadOnly = i % 2 == 0
                });
            }

            // Act
            var mgmtResult = Utils.Utils.toMgmtContainerHostBatchBindMounts(psBindMounts);
            var roundTripResult = Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(roundTripResult);
            Assert.Equal(50, mgmtResult.Count);
            Assert.Equal(50, roundTripResult.Count);

            // Verify all entries are correctly converted
            for (int i = 0; i < 50; i++)
            {
                Assert.Equal($"Source{i}", mgmtResult[i].Source);
                Assert.Equal(i % 2 == 0, mgmtResult[i].IsReadOnly);
                Assert.Equal($"Source{i}", roundTripResult[i].Source);
                Assert.Equal(i % 2 == 0, roundTripResult[i].IsReadOnly);
            }
        }

        #endregion
    }
}