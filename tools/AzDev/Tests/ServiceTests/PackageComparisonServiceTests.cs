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

using System.Collections.Generic;
using System.Linq;
using AzDev.Models.Dep;
using AzDev.Services;
using AzDev.Services.Assembly;
using AzDev.Services.Dep;
using Moq;

namespace AzDev.Tests.ServiceTests
{
    public class PackageComparisonServiceTests
    {
        [Fact]
        public void ComparePackageDependencies_DetectsVersionChange()
        {
            // Arrange
            var mockNugetService = new Mock<INugetService>();

            // Mock old version dependencies
            mockNugetService.Setup(x => x.GetPackageDependencies("Azure.Core", "1.47.3", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "System.ClientModel", Version = "1.6.1" },
                    new PackageDep { Id = "System.Text.Json", Version = "8.0.6" }
                });

            // Mock new version dependencies
            mockNugetService.Setup(x => x.GetPackageDependencies("Azure.Core", "1.50.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "System.ClientModel", Version = "1.8.0" },
                    new PackageDep { Id = "System.Text.Json", Version = "8.0.6" }
                });

            // Mock System.ClientModel dependencies (for recursive comparison)
            mockNugetService.Setup(x => x.GetPackageDependencies("System.ClientModel", "1.6.1", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "System.Text.Json", Version = "8.0.6" }
                });

            mockNugetService.Setup(x => x.GetPackageDependencies("System.ClientModel", "1.8.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "System.Text.Json", Version = "8.0.6" }
                });

            var service = new DefaultDepComparisonService(mockNugetService.Object, NoopLogger.Instance);

            // Act
            var differences = service.ComparePackageDependencies(
                "Azure.Core",
                "1.47.3",
                "1.50.0",
                "netstandard2.0").ToList();

            // Assert
            Assert.NotEmpty(differences);
            var systemClientModelChange = differences.FirstOrDefault(d => d.DepName == "System.ClientModel");
            Assert.NotNull(systemClientModelChange);
            Assert.Equal("Azure.Core", systemClientModelChange.ParentDep);
            Assert.Equal("1.6.1", systemClientModelChange.OldVersion);
            Assert.Equal("1.8.0", systemClientModelChange.NewVersion);

            // Verify INugetService was called
            mockNugetService.Verify(x => x.GetPackageDependencies("Azure.Core", "1.47.3", "netstandard2.0"), Times.Once);
            mockNugetService.Verify(x => x.GetPackageDependencies("Azure.Core", "1.50.0", "netstandard2.0"), Times.Once);
        }

        [Fact]
        public void ComparePackageDependencies_DetectsAddedDependency()
        {
            // Arrange
            var mockNugetService = new Mock<INugetService>();

            mockNugetService.Setup(x => x.GetPackageDependencies("TestPackage", "1.0.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "Dependency1", Version = "1.0.0" }
                });

            mockNugetService.Setup(x => x.GetPackageDependencies("TestPackage", "2.0.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "Dependency1", Version = "1.0.0" },
                    new PackageDep { Id = "Dependency2", Version = "2.0.0" }
                });

            var service = new DefaultDepComparisonService(mockNugetService.Object, NoopLogger.Instance);

            // Act
            var differences = service.ComparePackageDependencies(
                "TestPackage",
                "1.0.0",
                "2.0.0",
                "netstandard2.0").ToList();

            // Assert
            var addedDep = differences.FirstOrDefault(d => d.DepName == "Dependency2");
            Assert.NotNull(addedDep);
            Assert.Null(addedDep.OldVersion);
            Assert.Equal("2.0.0", addedDep.NewVersion);
            Assert.Equal("TestPackage", addedDep.ParentDep);
        }

        [Fact]
        public void ComparePackageDependencies_DetectsRemovedDependency()
        {
            // Arrange
            var mockNugetService = new Mock<INugetService>();

            mockNugetService.Setup(x => x.GetPackageDependencies("TestPackage", "1.0.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "Dependency1", Version = "1.0.0" },
                    new PackageDep { Id = "Dependency2", Version = "2.0.0" }
                });

            mockNugetService.Setup(x => x.GetPackageDependencies("TestPackage", "2.0.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "Dependency1", Version = "1.0.0" }
                });

            var service = new DefaultDepComparisonService(mockNugetService.Object, NoopLogger.Instance);

            // Act
            var differences = service.ComparePackageDependencies(
                "TestPackage",
                "1.0.0",
                "2.0.0",
                "netstandard2.0").ToList();

            // Assert
            var removedDep = differences.FirstOrDefault(d => d.DepName == "Dependency2");
            Assert.NotNull(removedDep);
            Assert.Equal("2.0.0", removedDep.OldVersion);
            Assert.Null(removedDep.NewVersion);
            Assert.Equal("TestPackage", removedDep.ParentDep);
        }

        [Fact]
        public void ComparePackageDependencies_SameVersions_ReturnsEmpty()
        {
            // Arrange
            var mockNugetService = new Mock<INugetService>();

            mockNugetService.Setup(x => x.GetPackageDependencies("TestPackage", "1.0.0", "netstandard2.0"))
                .Returns(new List<PackageDep>
                {
                    new PackageDep { Id = "Dependency1", Version = "1.0.0" }
                });

            var service = new DefaultDepComparisonService(mockNugetService.Object, NoopLogger.Instance);

            // Act
            var differences = service.ComparePackageDependencies(
                "TestPackage",
                "1.0.0",
                "1.0.0",
                "netstandard2.0").ToList();

            // Assert
            Assert.Empty(differences);
        }
    }
}
