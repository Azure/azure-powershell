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

using FluentAssertions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepSemanticVersionTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("0.26.0", 0, 26, 0)]
        [InlineData("1.2.3", 1, 2, 3)]
        [InlineData("1.2", 1, 2, 0)]
        [InlineData("1", 1, 0, 0)]
        public void TryParse_parses_valid_versions(string input, int major, int minor, int patch)
        {
            BicepSemanticVersion.TryParse(input, out var version).Should().BeTrue();
            version.Major.Should().Be(major);
            version.Minor.Should().Be(minor);
            version.Patch.Should().Be(patch);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("not-a-version")]
        [InlineData("1.2.3.4")]
        [InlineData("01.2.3")]
        [InlineData("1.2.3-preview")]
        [InlineData("1.2.3+buildmeta")]
        // A "v" prefix (GitHub release-tag style) is not valid here - the Bicep compiler's own
        // SemanticVersion doesn't accept it either, since 'bicep.version' config values never
        // use it. Tag-specific "v"-stripping happens only in BicepInstaller.TryParseReleaseTag.
        [InlineData("v0.26.0")]
        [InlineData("V0.26.0")]
        public void TryParse_fails_for_invalid_versions(string input)
        {
            BicepSemanticVersion.TryParse(input, out var version).Should().BeFalse();
            version.Should().BeNull();
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("1.0.0", "2.0.0", -1)]
        [InlineData("2.0.0", "1.0.0", 1)]
        [InlineData("1.2.0", "1.10.0", -1)]
        [InlineData("1.0.0", "1.0.0", 0)]
        [InlineData("1.2", "1.2.0", 0)]
        [InlineData("1", "1.0.0", 0)]
        public void CompareTo_orders_versions_per_major_minor_patch(string a, string b, int expectedSign)
        {
            var versionA = BicepSemanticVersion.Parse(a);
            var versionB = BicepSemanticVersion.Parse(b);

            System.Math.Sign(versionA.CompareTo(versionB)).Should().Be(expectedSign);
        }
    }
}
