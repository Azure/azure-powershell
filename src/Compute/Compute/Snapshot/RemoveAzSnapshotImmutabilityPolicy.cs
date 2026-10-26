using System;
using System.Net;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SnapshotImmutabilityPolicy",
        DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSnapshot))]
    public class RemoveAzSnapshotImmutabilityPolicy : SnapshotImmutabilityPolicyBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                GetSnapshotIdentity(out string resourceGroupName, out string snapshotName);
                string snapshotId = $"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}";

                if (!ShouldProcess(snapshotId, "Remove snapshot immutability policy"))
                {
                    return;
                }

                if (!Force.IsPresent
                    && !ShouldContinue("Removing an Unlocked immutability policy expires snapshot protection. Continue?",
                        "Remove snapshot immutability policy"))
                {
                    return;
                }

                Snapshot currentSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                ValidateSnapshotAccessState(currentSnapshot.SnapshotAccessState);

                ImmutabilityPolicy currentPolicy = currentSnapshot.ImmutabilityPolicy;
                if (currentPolicy == null || currentPolicy.IsPolicyExpired == true)
                {
                    throw new InvalidOperationException("The snapshot does not have an active Unlocked immutability policy to remove.");
                }

                if (!string.Equals(currentPolicy.Type, "Unlocked", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Only an active Unlocked immutability policy can be removed.");
                }

                try
                {
                    SnapshotsClient.UpdateImmutabilityPolicyLock(
                        resourceGroupName, snapshotName, new ImmutabilityPolicyLockData(0, "Unlocked"));
                }
                catch (CloudException exception) when (
                    exception.Response != null && exception.Response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException(
                        "Removing an Unlocked snapshot immutability policy requires Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action.",
                        exception);
                }

                Snapshot persistedSnapshot;
                try
                {
                    persistedSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                }
                catch (Exception exception)
                {
                    throw new InvalidOperationException(
                        "The immutability policy removal may have occurred, but the persisted snapshot state could not be verified.",
                        exception);
                }

                ImmutabilityPolicy persistedPolicy = persistedSnapshot.ImmutabilityPolicy;
                if (persistedPolicy == null
                    || !string.Equals(persistedPolicy.Type, "Unlocked", StringComparison.OrdinalIgnoreCase)
                    || persistedPolicy.ImmutabilityDurationDays != 0
                    || persistedPolicy.IsPolicyExpired != true)
                {
                    throw new InvalidOperationException(
                        "The immutability policy removal may have occurred, but the persisted snapshot policy was not confirmed as expired.");
                }

                WriteObject(ComputeAutomationAutoMapperProfile.Mapper.Map<Snapshot, PSSnapshot>(persistedSnapshot));
            });
        }
    }
}
