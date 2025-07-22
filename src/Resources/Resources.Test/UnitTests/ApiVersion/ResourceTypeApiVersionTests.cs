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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.ApiVersion
{
    public class ResourceTypeApiVersionTests
    {
        private readonly MethodInfo _getAvailableApiVersionsMethod;
        private readonly MethodInfo _selectApiVersionMethod;

        public ResourceTypeApiVersionTests()
        {
            _getAvailableApiVersionsMethod = typeof(ApiVersionHelper).GetMethod("GetAvailableApiVersions", BindingFlags.NonPublic | BindingFlags.Static);
            _selectApiVersionMethod = typeof(ApiVersionHelper).GetMethod("SelectApiVersion", BindingFlags.NonPublic | BindingFlags.Static);
        }

        private string InvokeDetermineApiVersion(IEnumerable<Provider> providers, string resourceType, bool pre)
        {
            var availableApiVersions = (string[])_getAvailableApiVersionsMethod.Invoke(null, new object[] { providers, resourceType });
            return (string)_selectApiVersionMethod.Invoke(null, new object[] { availableApiVersions, pre });
        }

        private static ProviderResourceType CreateResourceType(
            string resourceType,
            IList<string> apiVersions = null,
            string defaultApiVersion = null)
        {
            return new ProviderResourceType(
                resourceType,
                null, null, null,
                apiVersions,
                defaultApiVersion,
                null, null, null
            );
        }

        private static Provider CreateProvider(IList<ProviderResourceType> resourceTypes)
        {
            return new Provider(null, "TestResourceProvider", null, null, resourceTypes, null);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsDefaultApiVersion_WithSingleResourceType()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    "2021-10-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "TestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "TestResourceType", true);

            // Assert
            Assert.Equal("2021-10-01", resultStable);
            Assert.Equal("2021-10-01", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsDefaultApiVersion_WithMultiResourceTypes()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "validTestResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    "2023-10-01"
                ),
                CreateResourceType(
                    "ValidTestResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    "2021-11-01"
                ),
                CreateResourceType(
                    "ValidTestResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    ""
                ),
                CreateResourceType(
                    "InvalidTestResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    "2024-04-01"
                )
            };

            var providers = new List<Provider>
            {
                CreateProvider(resourceTypes)
            };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "ValidTestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "ValidTestResourceType", true);

            // Assert
            Assert.Equal("2023-10-01", resultStable);
            Assert.Equal("2023-10-01", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsLatestApiVersion_WhenDefaultVersionNotFound()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2024-12-01-preview", "2021-05-01", "2022-09-01", "2024-11-01" },
                    null
                ),
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2024-11-01-beta", "2023-05-01", "2021-10-01", "2024-11-01" },
                    ""
                ),
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2024-11-01-preview", "2024-11-01-privatepreview", "2018-01-01", "2024-04-01" },
                    "  "
                )
            };

            var providers = new List<Provider>
            {
                CreateProvider(resourceTypes)
            };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "TestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "TestResourceType", true);

            // Assert
            Assert.Equal("2024-11-01", resultStable);
            Assert.Equal("2024-12-01-preview", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsDefaultConstant_WhenBothDefaultVersionAndApiVersionsNotFound()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType("TestResourceType")
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "TestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "TestResourceType", true);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, resultStable);
            Assert.Equal(Constants.DefaultApiVersion, resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsDefaultConstant_WhenBothCurrentAndTopLevelResourceTypesNotFound()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "AnotherResourceType",
                    new List<string> { "2022-01-01" },
                    "2022-01-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "ParentResourceType/ChildResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "ParentResourceType/ChildResourceType", true);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, resultStable);
            Assert.Equal(Constants.DefaultApiVersion, resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FallsBackToTopLevelResourceType_WhenResourceTypeNotFound()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "ParentResourceType",
                    new List<string> { "2020-01-01", "2021-01-01", "2022-01-01" },
                    "2024-01-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "ParentResourceType/ChildResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "ParentResourceType/ChildResourceType", true);

            // Assert
            Assert.Equal("2024-01-01", resultStable);
            Assert.Equal("2024-01-01", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FallsBackToPreviewVersion_WhenStableVersionsNotFound()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2023-11-01-preview", "2024-06-01-preview", "2019-05-01-preview", "2024-06-01-beta", "2022-01-01-privatepreview" }
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "TestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "TestResourceType", true);

            // Assert
            Assert.Equal("2024-06-01-preview", resultStable);
            Assert.Equal("2024-06-01-preview", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesEmptyProviders()
        {
            // Arrange
            var providers = new List<Provider>();

            // Act
            var result = InvokeDetermineApiVersion(providers, "TestResourceType", false);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesNullResourceTypes()
        {
            // Arrange
            var providers = new List<Provider> { CreateProvider(null) };

            // Act
            var result = InvokeDetermineApiVersion(providers, "TestResourceType", false);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesNullOrWhitespaceResourceTypeNames()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    null,
                    new List<string> { "2020-01-01", "2021-01-01" },
                    "2021-01-01"
                ),
                CreateResourceType(
                    "",
                    new List<string> { "2021-01-01" },
                    "2021-01-01"
                ),
                CreateResourceType(
                    "   ",
                    new List<string> { "2021-01-01" },
                    "2021-01-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var result = InvokeDetermineApiVersion(providers, "TestResourceType", false);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesNullOrEmptyApiVersions()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    null
                ),
                CreateResourceType(
                    "TestResourceType",
                    new List<string>()
                ),
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var result = InvokeDetermineApiVersion(providers, "TestResourceType", false);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesWhitespaceApiVersions()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2025-01-01", "", "2025-04-01-preview", "2024-11-01", "    ", null, "2022-08-01" }
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultStable = InvokeDetermineApiVersion(providers, "TestResourceType", false);
            var resultPreview = InvokeDetermineApiVersion(providers, "TestResourceType", true);

            // Assert
            Assert.Equal("2025-01-01", resultStable);
            Assert.Equal("2025-04-01-preview", resultPreview);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesNullOrWhitespaceResourceTypeParam()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "TestResourceType",
                    new List<string> { "2020-01-01", "2022-01-01" },
                    "2021-01-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var resultNull = InvokeDetermineApiVersion(providers, null, false);
            var resultEmpty = InvokeDetermineApiVersion(providers, "", false);
            var resultWhitespace = InvokeDetermineApiVersion(providers, "   ", false);

            // Assert
            Assert.Equal(Constants.DefaultApiVersion, resultNull);
            Assert.Equal(Constants.DefaultApiVersion, resultEmpty);
            Assert.Equal(Constants.DefaultApiVersion, resultWhitespace);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesMultiProvidersWithMultiResourceType()
        {
            // Arrange
            var resourceTypes1 = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "CommonResourceType",
                    new List<string> { "2020-01-01" },
                    "2020-03-01"
                ),
                CreateResourceType(
                    "commonResourceTYPE",
                    new List<string> { "2021-01-01" },
                    "2021-03-01"
                )
            };

            var resourceTypes2 = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "commonResourceType",
                    new List<string> { "2022-01-01" },
                    "2024-05-01"
                ),
                CreateResourceType(
                    "commonResourcetype",
                    new List<string> { "2022-01-01-preview" },
                    "2023-01-01"
                )
            };

            var providers = new List<Provider>
            {
                CreateProvider(resourceTypes1),
                CreateProvider(resourceTypes2)
            };

            // Act
            var result = InvokeDetermineApiVersion(providers, "commonresourcetype", false);

            // Assert
            Assert.Equal("2024-05-01", result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesCaseSensitivityInResourceType()
        {
            // Arrange
            var resourceTypes = new List<ProviderResourceType>
            {
                CreateResourceType(
                    "CaSeSenSItiveType",
                    new List<string> { "2022-01-01" },
                    "2022-01-01"
                )
            };

            var providers = new List<Provider> { CreateProvider(resourceTypes) };

            // Act
            var result = InvokeDetermineApiVersion(providers, "casesensitivetype", false);

            // Assert
            Assert.Equal("2022-01-01", result);
        }
    }
}
