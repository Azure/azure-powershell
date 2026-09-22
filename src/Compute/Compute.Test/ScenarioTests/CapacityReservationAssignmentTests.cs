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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class CapacityReservationAssignmentTests
    {
        private static readonly JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCapacityReservationAssignmentAllowsExplicitFalseAndNullRemoval()
        {
            string crgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Compute/capacityReservationGroups/crg";

            CapacityReservationAssignmentHelper.ValidateCapacityReservationAssignment(crgId, true, false);
            CapacityReservationAssignmentHelper.ValidateCapacityReservationAssignment(null, true, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateCapacityReservationAssignmentRejectsTrueWithNonNullId()
        {
            string crgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Compute/capacityReservationGroups/crg";

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                CapacityReservationAssignmentHelper.ValidateCapacityReservationAssignment(crgId, true, true));

            Assert.Equal(CapacityReservationAssignmentHelper.ConflictErrorMessage, exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCapacityReservationProfileSerializesExplicitNullAsEmptySubResource()
        {
            var profile = CapacityReservationAssignmentHelper.CreateCapacityReservationProfile(null, true, true);

            string payload = JsonConvert.SerializeObject(profile, SerializationSettings);

            Assert.Contains(@"""capacityReservationGroup"":{}", payload);
            Assert.Contains(@"""disableCapacityReservationAssignment"":true", payload);
            Assert.DoesNotContain(@"""id"":null", payload);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCapacityReservationProfileCanOmitNullSubResourceOnCreate()
        {
            var profile = CapacityReservationAssignmentHelper.CreateCapacityReservationProfile(
                null,
                true,
                false,
                serializeEmptyCapacityReservationGroupForNullId: false);

            string payload = JsonConvert.SerializeObject(profile, SerializationSettings);

            Assert.DoesNotContain(@"""capacityReservationGroup"":", payload);
            Assert.Contains(@"""disableCapacityReservationAssignment"":false", payload);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmssPatchProfileSerializesCapacityReservation()
        {
            string crgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Compute/capacityReservationGroups/crg";
            var profile = CapacityReservationAssignmentHelper.CreateCapacityReservationProfile(crgId, true, false);
            Type profileType = profile.GetType().Assembly.GetType("Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetUpdateVMProfile");
            Type updateType = profile.GetType().Assembly.GetType("Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetUpdate");
            var updateProfile = Activator.CreateInstance(profileType);
            profileType.GetProperty("CapacityReservation").SetValue(updateProfile, profile);
            var update = Activator.CreateInstance(updateType);
            updateType.GetProperty("VirtualMachineProfile").SetValue(update, updateProfile);

            string payload = JsonConvert.SerializeObject(update, SerializationSettings);

            Assert.Contains(@"""capacityReservation"":", payload);
            Assert.Contains(@"""id"":""" + crgId + @"""", payload);
            Assert.Contains(@"""disableCapacityReservationAssignment"":false", payload);
        }
    }
}
