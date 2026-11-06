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
                || string.Equals(accessState, "Unknown", StringComparison.OrdinalIgnoreCase)
                || string.Equals(accessState, "InstantAccess", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"The snapshot access state '{accessState}' does not allow an immutability policy update.");
            }
        }

        internal static bool MatchesSet(ImmutabilityPolicy previous, ImmutabilityPolicy persisted,
            string policyType, int durationDays)
        {
            if (persisted == null
                || !string.Equals(persisted.Type, policyType, StringComparison.OrdinalIgnoreCase)
                || persisted.ImmutabilityDurationDays != durationDays
                || !persisted.PolicyStartTime.HasValue
                || !persisted.PolicyExpirationTime.HasValue
                || !persisted.IsPolicyExpired.HasValue)
            {
                return false;
            }

            DateTime start = persisted.PolicyStartTime.Value;
            DateTime expiration = persisted.PolicyExpirationTime.Value;
            if (expiration <= start || (expiration - start).TotalDays != durationDays)
            {
                return false;
            }

            bool sameTypeAndNotExpired = previous != null && previous.IsPolicyExpired != true
                && string.Equals(previous.Type, policyType, StringComparison.OrdinalIgnoreCase);
            if (sameTypeAndNotExpired)
            {
                if (!previous.PolicyStartTime.HasValue)
                {
                    return false;
                }

                if (previous.PolicyStartTime.Value == start)
                {
                    return true;
                }

                // A new start is valid only after the preflight policy's expiration.
                return previous.PolicyExpirationTime.HasValue && start >= previous.PolicyExpirationTime.Value;
            }

            // Unlocked-to-Locked transitions and expired-policy replacements require a newer start.
            if (previous?.PolicyStartTime.HasValue == true && start <= previous.PolicyStartTime.Value)
            {
                return false;
            }

            return true;
        }

        internal static bool MatchesRemove(ImmutabilityPolicy persisted)
        {
            return persisted != null
                && string.Equals(persisted.Type, "Unlocked", StringComparison.OrdinalIgnoreCase)
                && persisted.ImmutabilityDurationDays == 0
                && persisted.IsPolicyExpired == true
                && persisted.PolicyStartTime.HasValue
                && persisted.PolicyExpirationTime.HasValue;
        }
    }
}
