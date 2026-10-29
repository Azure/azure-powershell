using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SnapshotImmutabilityPolicyTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SnapshotPolicyMappingPreservesNullableAndFutureValues()
        {
            DateTime start = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc);
            var policy = new ImmutabilityPolicy(14, "FuturePolicyType", start, null, null);
            var snapshot = new Snapshot("eastus", immutabilityPolicy: policy);

            PSSnapshot output = ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshot>(snapshot);
            PSSnapshotList listOutput = ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshotList>(snapshot);

            Assert.IsType<PSSnapshotImmutabilityPolicy>(output.ImmutabilityPolicy);
            Assert.Equal(14, output.ImmutabilityPolicy.ImmutabilityDurationDays);
            Assert.Equal("FuturePolicyType", output.ImmutabilityPolicy.Type);
            Assert.Equal(start, output.ImmutabilityPolicy.PolicyStartTime);
            Assert.Null(output.ImmutabilityPolicy.PolicyExpirationTime);
            Assert.Null(output.ImmutabilityPolicy.IsPolicyExpired);
            Assert.Equal("FuturePolicyType", listOutput.ImmutabilityPolicy.Type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SnapshotPolicyIsNotMappedToWritableSnapshotInput()
        {
            var input = new PSSnapshot
            {
                Location = "eastus",
                ImmutabilityPolicy = new PSSnapshotImmutabilityPolicy
                {
                    ImmutabilityDurationDays = 10,
                    Type = "Locked",
                    IsPolicyExpired = false
                }
            };

            Snapshot mapped = ComputeAutomationAutoMapperProfile.Mapper.Map<Snapshot>(input);

            Assert.Null(mapped.ImmutabilityPolicy);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyMutationCommandsUseThreeSeparateIdentitySets()
        {
            string[] expectedSets = { "DefaultParameterSet", "InputObjectParameterSet", "ResourceIdParameterSet" };
            Assert.Equal(expectedSets, GetParameterSets(typeof(SetAzSnapshotImmutabilityPolicy), nameof(SetAzSnapshotImmutabilityPolicy.ResourceGroupName), nameof(SetAzSnapshotImmutabilityPolicy.ResourceId), nameof(SetAzSnapshotImmutabilityPolicy.InputObject)));
            Assert.Equal(expectedSets, GetParameterSets(typeof(RemoveAzSnapshotImmutabilityPolicy), nameof(RemoveAzSnapshotImmutabilityPolicy.ResourceGroupName), nameof(RemoveAzSnapshotImmutabilityPolicy.ResourceId), nameof(RemoveAzSnapshotImmutabilityPolicy.InputObject)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnlockedPolicyCanChangeAndLockedPolicyCannotBeReducedOrDowngraded()
        {
            var unlocked = new ImmutabilityPolicy(14, "Unlocked", isPolicyExpired: false);
            var locked = new ImmutabilityPolicy(14, "Locked", isPolicyExpired: false);

            SnapshotImmutabilityPolicyRules.ValidateSet(unlocked, "Unlocked", 7);
            SnapshotImmutabilityPolicyRules.ValidateSet(unlocked, "Locked", 7);
            SnapshotImmutabilityPolicyRules.ValidateSet(locked, "Locked", 14);
            SnapshotImmutabilityPolicyRules.ValidateSet(locked, "Locked", 21);

            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateSet(locked, "Locked", 7));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateSet(locked, "Unlocked", 21));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateRemove(locked));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OnlyActiveUnlockedPolicyCanBeRemovedAndPendingStatesAreRejected()
        {
            var unlocked = new ImmutabilityPolicy(7, "Unlocked", isPolicyExpired: false);
            var expired = new ImmutabilityPolicy(7, "Unlocked", isPolicyExpired: true);
            var unknownExpiration = new ImmutabilityPolicy(7, "Unlocked");

            SnapshotImmutabilityPolicyRules.ValidateRemove(unlocked);
            SnapshotImmutabilityPolicyRules.ValidateSnapshotAccessState("InstantAccess");

            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateRemove(null));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateRemove(expired));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateRemove(unknownExpiration));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateSnapshotAccessState("Pending"));
            Assert.Throws<InvalidOperationException>(() => SnapshotImmutabilityPolicyRules.ValidateSnapshotAccessState("Unknown"));
        }

        private static string[] GetParameterSets(Type cmdletType, params string[] propertyNames)
        {
            return propertyNames
                .SelectMany(name => cmdletType.GetProperty(name).GetCustomAttributes(typeof(ParameterAttribute), true)
                    .Cast<ParameterAttribute>()
                    .Select(attribute => attribute.ParameterSetName))
                .Distinct()
                .OrderBy(name => name)
                .ToArray();
        }
    }
}
