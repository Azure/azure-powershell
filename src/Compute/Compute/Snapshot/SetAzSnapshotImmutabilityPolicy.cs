using System;
using System.Net;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SnapshotImmutabilityPolicy",
        DefaultParameterSetName = "DefaultParameterSet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSnapshot))]
    public class SetAzSnapshotImmutabilityPolicy : SnapshotImmutabilityPolicyBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                GetSnapshotIdentity(out string resourceGroupName, out string snapshotName);
                string snapshotId = $"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}";
                string policyType = string.Equals(PolicyType, "Unlocked", StringComparison.OrdinalIgnoreCase) ? "Unlocked" : "Locked";

                if (!ShouldProcess(snapshotId, "Set snapshot immutability policy"))
                {
                    return;
                }

                if (policyType == "Locked" && !Force.IsPresent
                    && !ShouldContinue("Locking an immutability policy prevents reducing or removing it until it expires. Continue?",
                        "Lock snapshot immutability policy"))
                {
                    return;
                }

                Snapshot currentSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                ValidateSnapshotAccessState(currentSnapshot.SnapshotAccessState);
                SnapshotImmutabilityPolicyRules.ValidateSet(currentSnapshot.ImmutabilityPolicy, policyType, DurationDays);

                if (policyType == "Unlocked")
                {
                    SnapshotsClient.UpdateImmutabilityPolicy(
                        resourceGroupName, snapshotName, new ImmutabilityPolicyData(DurationDays, policyType));
                }
                else
                {
                    try
                    {
                        SnapshotsClient.UpdateImmutabilityPolicyLock(
                            resourceGroupName, snapshotName, new ImmutabilityPolicyLockData(DurationDays, policyType));
                    }
                    catch (CloudException exception) when (
                        exception.Response != null && exception.Response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new UnauthorizedAccessException(
                            "Setting a Locked snapshot immutability policy requires Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action.",
                            exception);
                    }
                }

                Snapshot persistedSnapshot;
                try
                {
                    persistedSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                }
                catch (Exception exception)
                {
                    throw new InvalidOperationException(
                        "The immutability policy update may have occurred, but the persisted snapshot state could not be verified.",
                        exception);
                }

                ImmutabilityPolicy persistedPolicy = persistedSnapshot.ImmutabilityPolicy;
                if (persistedPolicy == null
                    || !string.Equals(persistedPolicy.Type, policyType, StringComparison.OrdinalIgnoreCase)
                    || persistedPolicy.ImmutabilityDurationDays != DurationDays
                    || persistedPolicy.IsPolicyExpired == true)
                {
                    throw new InvalidOperationException(
                        "The immutability policy update may have occurred, but the persisted snapshot policy did not match the requested type and duration.");
                }

                WriteObject(ComputeAutomationAutoMapperProfile.Mapper.Map<Snapshot, PSSnapshot>(persistedSnapshot));
            });
        }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true)]
        [ValidateSet("Unlocked", "Locked")]
        public string PolicyType { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true)]
        [ValidateRange(1, int.MaxValue)]
        public int DurationDays { get; set; }
    }
}
