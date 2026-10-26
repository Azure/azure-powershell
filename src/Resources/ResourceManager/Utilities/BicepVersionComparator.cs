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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System;

    internal enum BicepVersionConstraintOperator
    {
        Equal,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual
    }

    /// <summary>
    /// A single operator+version component, e.g. ">=0.26.0" (a bare version means "=0.26.0").
    /// Mirrors Bicep.Core.SemanticVersioning.VersionComparator.
    /// </summary>
    internal sealed class BicepVersionComparator
    {
        // Two-character tokens must be tested first so that ">=" is not mistaken for ">"
        // followed by a version starting with "=".
        private static readonly (string Token, BicepVersionConstraintOperator Operator)[] OperatorTokens =
        {
            (">=", BicepVersionConstraintOperator.GreaterThanOrEqual),
            ("<=", BicepVersionConstraintOperator.LessThanOrEqual),
            (">", BicepVersionConstraintOperator.GreaterThan),
            ("<", BicepVersionConstraintOperator.LessThan),
            ("=", BicepVersionConstraintOperator.Equal),
        };

        public BicepVersionConstraintOperator Operator { get; }

        public BicepSemanticVersion Version { get; }

        public BicepVersionComparator(BicepVersionConstraintOperator op, BicepSemanticVersion version)
        {
            Operator = op;
            Version = version;
        }

        /// <summary>
        /// Whether this comparator constrains how low a version may go.
        /// </summary>
        public bool IsLowerBound
            => Operator == BicepVersionConstraintOperator.GreaterThan
                || Operator == BicepVersionConstraintOperator.GreaterThanOrEqual;

        /// <summary>
        /// Whether this comparator constrains how high a version may go.
        /// </summary>
        public bool IsUpperBound
            => Operator == BicepVersionConstraintOperator.LessThan
                || Operator == BicepVersionConstraintOperator.LessThanOrEqual;

        /// <summary>
        /// Whether the bound itself is an accepted version.
        /// </summary>
        public bool IsInclusive
            => Operator != BicepVersionConstraintOperator.GreaterThan
                && Operator != BicepVersionConstraintOperator.LessThan;

        public bool IsSatisfiedBy(BicepSemanticVersion candidate)
        {
            var comparison = candidate.CompareTo(Version);

            switch (Operator)
            {
                case BicepVersionConstraintOperator.Equal:
                    return comparison == 0;
                case BicepVersionConstraintOperator.GreaterThan:
                    return comparison > 0;
                case BicepVersionConstraintOperator.GreaterThanOrEqual:
                    return comparison >= 0;
                case BicepVersionConstraintOperator.LessThan:
                    return comparison < 0;
                case BicepVersionConstraintOperator.LessThanOrEqual:
                    return comparison <= 0;
                default:
                    return false;
            }
        }

        public static bool TryParse(string text, out BicepVersionComparator result)
        {
            result = null;

            var remainder = text.Trim();
            var op = BicepVersionConstraintOperator.Equal;

            foreach (var (token, candidate) in OperatorTokens)
            {
                if (remainder.StartsWith(token, StringComparison.Ordinal))
                {
                    op = candidate;
                    remainder = remainder.Substring(token.Length).TrimStart();
                    break;
                }
            }

            BicepSemanticVersion version;
            if (!BicepSemanticVersion.TryParse(remainder, out version))
            {
                return false;
            }

            result = new BicepVersionComparator(op, version);
            return true;
        }

        public override string ToString()
        {
            switch (Operator)
            {
                case BicepVersionConstraintOperator.GreaterThan:
                    return $">{Version}";
                case BicepVersionConstraintOperator.GreaterThanOrEqual:
                    return $">={Version}";
                case BicepVersionConstraintOperator.LessThan:
                    return $"<{Version}";
                case BicepVersionConstraintOperator.LessThanOrEqual:
                    return $"<={Version}";
                default:
                    // An exact constraint is rendered without an operator, matching the syntax
                    // users are expected to write.
                    return Version.ToString();
            }
        }
    }
}
