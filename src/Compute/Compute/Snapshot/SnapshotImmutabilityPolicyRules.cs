using System;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    internal static class SnapshotImmutabilityPolicyRules
    {
        internal static void ValidateSet(ImmutabilityPolicy currentPolicy, string policyType, int durationDays)
        {
            if (currentPolicy == null || currentPolicy.IsPolicyExpired == true)
            {
                return;
            }

            if (!string.Equals(currentPolicy.Type, "Unlocked", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(currentPolicy.Type, "Locked", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"The existing immutability policy type '{currentPolicy.Type}' is not supported for updates.");
            }

            if (string.Equals(currentPolicy.Type, "Locked", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.Equals(policyType, "Locked", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("An active Locked immutability policy cannot be changed to Unlocked.");
                }

                if (!currentPolicy.ImmutabilityDurationDays.HasValue)
                {
                    throw new InvalidOperationException("The active Locked immutability policy duration could not be read.");
                }

                if (durationDays < currentPolicy.ImmutabilityDurationDays.Value)
                {
                    throw new InvalidOperationException("An active Locked immutability policy duration cannot be shortened.");
                }
            }
        }

        internal static void ValidateRemove(ImmutabilityPolicy currentPolicy)
        {
            if (currentPolicy == null || currentPolicy.IsPolicyExpired != false)
            {
                throw new InvalidOperationException("The snapshot does not have a confirmed active Unlocked immutability policy to remove.");
            }

            if (!string.Equals(currentPolicy.Type, "Unlocked", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Only an active Unlocked immutability policy can be removed.");
            }
        }

        internal static void ValidateSnapshotAccessState(string accessState)
        {
            if (string.Equals(accessState, "Pending", StringComparison.OrdinalIgnoreCase)
                || string.Equals(accessState, "Unknown", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"The snapshot access state '{accessState}' does not allow an immutability policy update.");
            }
        }
    }
}
