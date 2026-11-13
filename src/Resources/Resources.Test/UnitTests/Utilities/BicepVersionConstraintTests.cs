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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepVersionConstraintTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("0.26.0")]
        [InlineData(">=0.26.0")]
        [InlineData(">0.26.0")]
        [InlineData("<=0.26.0")]
        [InlineData("<0.26.0")]
        [InlineData("  >= 0.26.0 ")]
        public void Parse_recognizes_each_supported_operator(string raw)
        {
            FluentActions.Invoking(() => BicepVersionConstraint.Parse(raw, "bicepconfig.json")).Should().NotThrow();
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("not-a-version")]
        [InlineData(">=not-a-version")]
        [InlineData("!=0.26.0")]
        [InlineData("~0.26.0")]
        [InlineData("^0.26.0")]
        [InlineData(">=")]
        // A "v" prefix is a GitHub release-tag convention, not valid in a 'bicep.version' config
        // value - matches the Bicep compiler's own strictness.
        [InlineData("v0.26.0")]
        // More than two comparators are not supported.
        [InlineData(">=1.0.0, <2.0.0, <3.0.0")]
        // Empty comparators.
        [InlineData(">=1.0.0,")]
        [InlineData(",<2.0.0")]
        [InlineData(",")]
        // A range must pair at most one lower bound with one upper bound.
        [InlineData(">=1.0.0, >=2.0.0")]
        [InlineData("<1.0.0, <2.0.0")]
        // An exact version cannot be combined with another bound.
        [InlineData("1.0.0, <2.0.0")]
        public void Parse_throws_for_invalid_constraints(string raw)
        {
            FluentActions.Invoking(() => BicepVersionConstraint.Parse(raw, "bicepconfig.json"))
                .Should().Throw<AzPSApplicationException>()
                .WithMessage("*bicepconfig.json*");
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("0.26.0", "0.26.0", true)]
        [InlineData("0.26.0", "0.26.1", false)]
        [InlineData("0.26.0", "0.25.0", false)]
        public void Exact_constraint_only_matches_the_same_version(string constraintRaw, string candidateRaw, bool expected)
        {
            var constraint = BicepVersionConstraint.Parse(constraintRaw, "bicepconfig.json");
            var candidate = BicepSemanticVersion.Parse(candidateRaw);

            constraint.IsExactVersion.Should().BeTrue();
            constraint.IsSatisfiedBy(candidate).Should().Be(expected);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(">=0.26.0", "0.26.0", true)]
        [InlineData(">=0.26.0", "0.30.0", true)]
        [InlineData(">=0.26.0", "0.25.0", false)]
        [InlineData(">0.26.0", "0.26.0", false)]
        [InlineData(">0.26.0", "0.26.1", true)]
        [InlineData("<=0.26.0", "0.26.0", true)]
        [InlineData("<=0.26.0", "0.26.1", false)]
        [InlineData("<0.26.0", "0.25.0", true)]
        [InlineData("<0.26.0", "0.26.0", false)]
        public void Comparison_operators_match_expected_bounds(string constraintRaw, string candidateRaw, bool expected)
        {
            var constraint = BicepVersionConstraint.Parse(constraintRaw, "bicepconfig.json");
            var candidate = BicepSemanticVersion.Parse(candidateRaw);

            constraint.IsSatisfiedBy(candidate).Should().Be(expected);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(">=0.26.0, <0.30.0", "0.26.0", true)]
        [InlineData(">=0.26.0, <0.30.0", "0.29.5", true)]
        [InlineData(">=0.26.0, <0.30.0", "0.30.0", false)]
        [InlineData(">=0.26.0, <0.30.0", "0.25.9", false)]
        [InlineData(">0.26.0, <=0.30.0", "0.26.0", false)]
        [InlineData(">0.26.0, <=0.30.0", "0.30.0", true)]
        public void Range_constraint_requires_both_bounds_to_be_satisfied(string constraintRaw, string candidateRaw, bool expected)
        {
            var constraint = BicepVersionConstraint.Parse(constraintRaw, "bicepconfig.json");
            var candidate = BicepSemanticVersion.Parse(candidateRaw);

            constraint.IsExactVersion.Should().BeFalse();
            constraint.IsSatisfiedBy(candidate).Should().Be(expected);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Range_constraint_order_of_comparators_does_not_matter()
        {
            var lowerFirst = BicepVersionConstraint.Parse(">=0.26.0, <0.30.0", "bicepconfig.json");
            var upperFirst = BicepVersionConstraint.Parse("<0.30.0, >=0.26.0", "bicepconfig.json");

            var candidate = BicepSemanticVersion.Parse("0.28.0");

            lowerFirst.IsSatisfiedBy(candidate).Should().Be(upperFirst.IsSatisfiedBy(candidate));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToString_roundtrips_operator_and_version()
        {
            BicepVersionConstraint.Parse(">=0.26.0", "bicepconfig.json").ToString().Should().Be(">=0.26.0");
            BicepVersionConstraint.Parse("0.26.0", "bicepconfig.json").ToString().Should().Be("0.26.0");
            BicepVersionConstraint.Parse(">=0.26.0, <0.30.0", "bicepconfig.json").ToString().Should().Be(">=0.26.0, <0.30.0");
        }
    }
}
