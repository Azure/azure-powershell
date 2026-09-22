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

using Microsoft.Azure.Management.Compute.Models;
using System;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class CapacityReservationAssignmentHelper
    {
        public const string ConflictErrorMessage = "-CapacityReservationGroupId cannot be used when -DisableCapacityReservationAssignment is set to $true. Omit -CapacityReservationGroupId or set -DisableCapacityReservationAssignment:$false to associate a capacity reservation group.";

        /// <summary>
        /// Validates the mutual exclusion rule for capacity reservation assignment parameters.
        /// </summary>
        /// <param name="capacityReservationGroupId">The capacity reservation group ID value supplied to the cmdlet.</param>
        /// <param name="isCapacityReservationGroupIdBound">Indicates whether the capacity reservation group ID parameter was explicitly bound.</param>
        /// <param name="disableCapacityReservationAssignment">The effective value of the opt-out switch. Explicit false values are allowed with a group ID.</param>
        public static void ValidateCapacityReservationAssignment(string capacityReservationGroupId, bool isCapacityReservationGroupIdBound, bool disableCapacityReservationAssignment)
        {
            if (isCapacityReservationGroupIdBound && capacityReservationGroupId != null && disableCapacityReservationAssignment)
            {
                throw new ArgumentException(ConflictErrorMessage);
            }
        }

        /// <summary>
        /// Creates a capacity reservation profile while preserving whether the capacity reservation group ID was explicitly bound.
        /// </summary>
        /// <param name="capacityReservationGroupId">The capacity reservation group ID value supplied to the cmdlet.</param>
        /// <param name="isCapacityReservationGroupIdBound">Indicates whether the capacity reservation group ID parameter was explicitly bound.</param>
        /// <param name="disableCapacityReservationAssignment">The nullable opt-out value to serialize, or null when the switch was omitted.</param>
        /// <param name="serializeEmptyCapacityReservationGroupForNullId">When true, an explicitly bound null group ID is serialized as an empty subresource for update removal semantics.</param>
        /// <returns>
        /// A profile containing the requested capacity reservation assignment state, or null when no capacity reservation assignment state should be serialized.
        /// </returns>
        public static CapacityReservationProfile CreateCapacityReservationProfile(
            string capacityReservationGroupId,
            bool isCapacityReservationGroupIdBound,
            bool? disableCapacityReservationAssignment,
            bool serializeEmptyCapacityReservationGroupForNullId = true)
        {
            bool serializeCapacityReservationGroup = isCapacityReservationGroupIdBound &&
                (!string.IsNullOrEmpty(capacityReservationGroupId) ||
                    (string.IsNullOrEmpty(capacityReservationGroupId) && serializeEmptyCapacityReservationGroupForNullId));

            if (!serializeCapacityReservationGroup && disableCapacityReservationAssignment == null)
            {
                return null;
            }

            return new CapacityReservationProfile
            {
                CapacityReservationGroup = serializeCapacityReservationGroup ? new SubResource(string.IsNullOrEmpty(capacityReservationGroupId) ? null : capacityReservationGroupId) : null,
                DisableCapacityReservationAssignment = disableCapacityReservationAssignment
            };
        }
    }
}
