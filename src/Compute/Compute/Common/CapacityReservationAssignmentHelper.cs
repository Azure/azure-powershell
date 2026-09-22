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
        public const string ConflictErrorMessage = "-CapacityReservationGroupId cannot be used when -DisableCapacityReservationAssignment is set to $true.";

        public static void ValidateCapacityReservationAssignment(string capacityReservationGroupId, bool isCapacityReservationGroupIdBound, bool disableCapacityReservationAssignment)
        {
            if (isCapacityReservationGroupIdBound && capacityReservationGroupId != null && disableCapacityReservationAssignment)
            {
                throw new ArgumentException(ConflictErrorMessage);
            }
        }

        public static CapacityReservationProfile CreateCapacityReservationProfile(string capacityReservationGroupId, bool isCapacityReservationGroupIdBound, bool? disableCapacityReservationAssignment)
        {
            if (!isCapacityReservationGroupIdBound && disableCapacityReservationAssignment == null)
            {
                return null;
            }

            return new CapacityReservationProfile
            {
                CapacityReservationGroup = isCapacityReservationGroupIdBound ? new SubResource(capacityReservationGroupId) : null,
                DisableCapacityReservationAssignment = disableCapacityReservationAssignment
            };
        }
    }
}
