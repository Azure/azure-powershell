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
    using Microsoft.Azure.Commands.Common.Exceptions;

    /// <summary>
    /// A parsed 'bicep.version' constraint: an exact version ("0.26.0") or a range (e.g.
    /// ">=0.26.0, &lt;0.30.0"). Mirrors Bicep.Core.SemanticVersioning.VersionRange.
    /// </summary>
    internal class BicepVersionConstraint
    {
        private const char ComparatorSeparator = ',';

        // A range may pair at most one lower bound with one upper bound.
        private const int MaxComparatorCount = 2;

        public BicepVersionComparator LowerBound { get; }

        public BicepVersionComparator UpperBound { get; }

        private BicepVersionConstraint(BicepVersionComparator lowerBound, BicepVersionComparator upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        /// <summary>
        /// Whether this constraint accepts a single version only. An exact version is held as a
        /// pair of inclusive bounds at the same version.
        /// </summary>
        public bool IsExactVersion
            => LowerBound != null && UpperBound != null
                && LowerBound.IsInclusive && UpperBound.IsInclusive
                && LowerBound.Version.CompareTo(UpperBound.Version) == 0;

        /// <summary>
        /// Parses a raw 'bicep.version' constraint string. Throws an
        /// <see cref="AzPSApplicationException"/> with a user-friendly message (including the
        /// originating config file path) if the constraint is malformed.
        /// </summary>
        public static BicepVersionConstraint Parse(string raw, string configFilePath)
        {
            BicepVersionConstraint constraint;
            if (!TryParse(raw, out constraint))
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionConstraintInvalid, raw, configFilePath));
            }

            return constraint;
        }

        public static bool TryParse(string raw, out BicepVersionConstraint result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(raw))
            {
                return false;
            }

            var parts = raw.Split(ComparatorSeparator);
            if (parts.Length > MaxComparatorCount)
            {
                return false;
            }

            BicepVersionComparator lowerBound = null;
            BicepVersionComparator upperBound = null;

            // Assigning by bound (not position) rejects duplicates like ">=1.0.0, >=2.0.0"
            // and makes part order irrelevant.
            foreach (var part in parts)
            {
                BicepVersionComparator comparator;
                if (!BicepVersionComparator.TryParse(part, out comparator))
                {
                    return false;
                }

                if (comparator.Operator == BicepVersionConstraintOperator.Equal)
                {
                    // An exact version occupies both ends , which also
                    // rejects combining it with a bound, e.g. "=1.0.0, <2.0.0".
                    if (lowerBound != null || upperBound != null)
                    {
                        return false;
                    }

                    lowerBound = new BicepVersionComparator(BicepVersionConstraintOperator.GreaterThanOrEqual, comparator.Version);
                    upperBound = new BicepVersionComparator(BicepVersionConstraintOperator.LessThanOrEqual, comparator.Version);
                }
                else if (comparator.IsLowerBound)
                {
                    if (lowerBound != null)
                    {
                        return false;
                    }

                    lowerBound = comparator;
                }
                else
                {
                    if (upperBound != null)
                    {
                        return false;
                    }

                    upperBound = comparator;
                }
            }

            result = new BicepVersionConstraint(lowerBound, upperBound);
            return true;
        }

        /// <summary>
        /// Returns whether the given candidate version satisfies both ends of this range.
        /// </summary>
        public bool IsSatisfiedBy(BicepSemanticVersion candidate)
        {
            if (candidate == null)
            {
                return false;
            }

            return (LowerBound == null || LowerBound.IsSatisfiedBy(candidate))
                && (UpperBound == null || UpperBound.IsSatisfiedBy(candidate));
        }

        /// <summary>
        /// Renders the constraint in its normalized form: an exact version is shown the way a
        /// user would write it, rather than as a pair of bounds.
        /// </summary>
        public override string ToString()
        {
            if (IsExactVersion)
            {
                return LowerBound.Version.ToString();
            }

            if (LowerBound != null && UpperBound != null)
            {
                return $"{LowerBound}{ComparatorSeparator} {UpperBound}";
            }

            return (LowerBound ?? UpperBound).ToString();
        }
    }
}
