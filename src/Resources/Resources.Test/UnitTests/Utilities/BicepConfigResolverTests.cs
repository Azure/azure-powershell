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

using System;
using System.IO;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepConfigResolverTests
    {
        /// <summary>
        /// Builds a fresh, OS-appropriate temp-style root directory path for a single test,
        /// so that walking "up" from it (to find or not find a config) is deterministic and
        /// doesn't depend on the real file system.
        /// </summary>
        private static string NewRoot() => Path.Combine(Path.GetTempPath(), "bicep-cfg-" + Guid.NewGuid().ToString("N"));

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindNearestConfigFile_returns_null_when_no_config_exists()
        {
            var dataStoreMock = new Mock<IDataStore>();
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.FindNearestConfigFile(entrypoint).Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindNearestConfigFile_finds_config_in_same_directory()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.FindNearestConfigFile(entrypoint).Should().Be(configPath);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindNearestConfigFile_walks_up_to_parent_directory()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "sub", "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.FindNearestConfigFile(entrypoint).Should().Be(configPath);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_returns_version_from_single_file()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(configPath).Should().Be(">=0.26.0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_returns_null_when_no_file_in_chain_specifies_version()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(configPath).Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_follows_extends_chain_to_find_version()
        {
            var root = NewRoot();
            var leafDir = Path.Combine(root, "leaf");
            var sharedDir = Path.Combine(root, "shared");
            var leafConfig = Path.Combine(leafDir, "bicepconfig.json");
            var sharedConfig = Path.Combine(sharedDir, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(leafConfig)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(sharedConfig)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(leafConfig)).Returns("{ \"extends\": \"../shared/bicepconfig.json\" }");
            dataStoreMock.Setup(x => x.ReadFileAsText(sharedConfig)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(leafConfig).Should().Be(">=0.26.0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_explicit_null_version_falls_through_to_extended_file()
        {
            var root = NewRoot();
            var leafDir = Path.Combine(root, "leaf");
            var sharedDir = Path.Combine(root, "shared");
            var leafConfig = Path.Combine(leafDir, "bicepconfig.json");
            var sharedConfig = Path.Combine(sharedDir, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(leafConfig)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(sharedConfig)).Returns(true);
            // Explicit "version": null in the leaf means "no opinion here" -- it should fall
            // through to the extended (shared) file rather than winning outright.
            dataStoreMock.Setup(x => x.ReadFileAsText(leafConfig)).Returns("{ \"extends\": \"../shared/bicepconfig.json\", \"bicep\": { \"version\": null } }");
            dataStoreMock.Setup(x => x.ReadFileAsText(sharedConfig)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(leafConfig).Should().Be(">=0.26.0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_when_extends_target_is_missing()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"extends\": \"../missing/bicepconfig.json\" }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(configPath))
                .Should().Throw<AzPSApplicationException>().WithMessage("Could not find Bicep configuration file*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_when_extends_chain_has_a_cycle()
        {
            var root = NewRoot();
            var configA = Path.Combine(root, "a", "bicepconfig.json");
            var configB = Path.Combine(root, "b", "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configA)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configB)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configA)).Returns("{ \"extends\": \"../b/bicepconfig.json\" }");
            dataStoreMock.Setup(x => x.ReadFileAsText(configB)).Returns("{ \"extends\": \"../a/bicepconfig.json\" }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(configA))
                .Should().Throw<AzPSApplicationException>().WithMessage("Detected a cycle*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_for_invalid_json()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ this is not valid json");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(configPath))
                .Should().Throw<AzPSApplicationException>().WithMessage("Failed to parse Bicep configuration file*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveEffectiveVersion_returns_null_when_no_config_file_found()
        {
            var dataStoreMock = new Mock<IDataStore>();
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveEffectiveVersion(entrypoint).Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveEffectiveVersion_combines_discovery_and_extends_resolution()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "sub", "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveEffectiveVersion(entrypoint).Should().Be(">=0.26.0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_leaf_version_wins_over_extended_version()
        {
            var root = NewRoot();
            var leafDir = Path.Combine(root, "leaf");
            var sharedDir = Path.Combine(root, "shared");
            var leafConfig = Path.Combine(leafDir, "bicepconfig.json");
            var sharedConfig = Path.Combine(sharedDir, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(leafConfig)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(sharedConfig)).Returns(true);
            // Leaf specifies its own (non-null) version, so it should win outright and the
            // extended (shared) file's version should never even be consulted.
            dataStoreMock.Setup(x => x.ReadFileAsText(leafConfig)).Returns("{ \"extends\": \"../shared/bicepconfig.json\", \"bicep\": { \"version\": \">=0.30.0\" } }");
            dataStoreMock.Setup(x => x.ReadFileAsText(sharedConfig)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(leafConfig).Should().Be(">=0.30.0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_treats_missing_bicep_section_as_no_version()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            // "bicep" section present, but no "version" key inside it at all.
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(configPath).Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_treats_empty_string_extends_as_end_of_chain()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"extends\": \"\" }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(configPath).Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_stops_at_first_version_found_without_reaching_layers_beyond_a_later_empty_extends()
        {
            // Chain: leaf -> middle1 (has a version) -> middle2 (no version, extends: "") -> base.
            // middle1's version must win immediately. middle2's "extends": "" (which would
            // otherwise terminate the chain before ever reaching "base") must never even be
            // consulted, since resolution already stopped one layer earlier at middle1.
            var root = NewRoot();
            var leafConfig = Path.Combine(root, "leaf", "bicepconfig.json");
            var middle1Config = Path.Combine(root, "middle1", "bicepconfig.json");
            var middle2Config = Path.Combine(root, "middle2", "bicepconfig.json");
            var baseConfig = Path.Combine(root, "base", "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(leafConfig)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(middle1Config)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(middle2Config)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(baseConfig)).Returns(true);

            dataStoreMock.Setup(x => x.ReadFileAsText(leafConfig))
                .Returns($"{{ \"extends\": {JsonConvert.ToString(Path.Combine("..", "middle1", "bicepconfig.json"))} }}");
            dataStoreMock.Setup(x => x.ReadFileAsText(middle1Config))
                .Returns($"{{ \"extends\": {JsonConvert.ToString(Path.Combine("..", "middle2", "bicepconfig.json"))}, \"bicep\": {{ \"version\": \">=0.28.0\" }} }}");
            dataStoreMock.Setup(x => x.ReadFileAsText(middle2Config))
                .Returns("{ \"extends\": \"\" }");
            dataStoreMock.Setup(x => x.ReadFileAsText(baseConfig))
                .Returns("{ \"bicep\": { \"version\": \">=0.20.0\" } }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            resolver.ResolveVersionConstraint(leafConfig).Should().Be(">=0.28.0");

            // middle2 and base should never be read, since resolution already stopped at middle1.
            dataStoreMock.Verify(x => x.ReadFileAsText(middle2Config), Times.Never());
            dataStoreMock.Verify(x => x.ReadFileAsText(baseConfig), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_for_direct_self_referencing_extends()
        {
            var root = NewRoot();
            var configPath = Path.Combine(root, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            // A config that (directly or via a relative path trick) extends itself.
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"extends\": \"./bicepconfig.json\" }");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(configPath))
                .Should().Throw<AzPSApplicationException>().WithMessage("Detected a cycle*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_for_absolute_extends_path()
        {
            var root = NewRoot();
            var leafDir = Path.Combine(root, "leaf");
            var sharedDir = Path.Combine(root, "shared");
            var leafConfig = Path.Combine(leafDir, "bicepconfig.json");
            var sharedConfig = Path.Combine(sharedDir, "bicepconfig.json");

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(leafConfig)).Returns(true);
            // "extends" given as a fully-qualified absolute path rather than a relative one.
            // This matches the Bicep compiler's own BCP453 behavior: absolute paths are rejected.
            dataStoreMock.Setup(x => x.ReadFileAsText(leafConfig)).Returns($"{{ \"extends\": {JsonConvert.ToString(sharedConfig)} }}");

            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(leafConfig))
                .Should().Throw<AzPSApplicationException>().WithMessage("*must be a relative path*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolveVersionConstraint_throws_when_extends_chain_exceeds_max_depth()
        {
            var root = NewRoot();
            const int chainLength = 66; // deliberately beyond the resolver's max depth (64), matching Bicep's BCP455 test chain length
            var dataStoreMock = new Mock<IDataStore>();

            string previousConfig = null;
            for (var i = chainLength - 1; i >= 0; i--)
            {
                var dir = Path.Combine(root, $"layer{i}");
                var configPath = Path.Combine(dir, "bicepconfig.json");
                dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);

                var contents = previousConfig == null
                    ? "{ }"
                    : $"{{ \"extends\": {JsonConvert.ToString(Path.Combine("..", $"layer{i + 1}", "bicepconfig.json"))} }}";
                dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns(contents);

                previousConfig = configPath;
            }

            var entryConfig = Path.Combine(root, "layer0", "bicepconfig.json");
            var resolver = new BicepConfigResolver(dataStoreMock.Object);

            FluentActions.Invoking(() => resolver.ResolveVersionConstraint(entryConfig))
                .Should().Throw<AzPSApplicationException>().WithMessage("*exceeds the maximum supported depth*");
        }
    }
}
