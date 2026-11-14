using System;
using System.Net;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SnapshotImmutabilityPolicy",
        DefaultParameterSetName = "DefaultParameterSet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSnapshot))]
    public class RemoveAzSnapshotImmutabilityPolicy : SnapshotImmutabilityPolicyBaseCmdlet
    {
        protected override bool RequiresRiskAcknowledgement => true;
        protected override string RiskAcknowledgement => "This administrative action ends Unlocked snapshot protection without deleting the snapshot. Continue?";
        protected override string PolicyAction => "Remove snapshot immutability policy";

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                GetSnapshotIdentity(out string resourceGroupName, out string snapshotName);
                Snapshot currentSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                ValidateSnapshotAccessState(currentSnapshot.SnapshotAccessState);

                SnapshotImmutabilityPolicyRules.ValidateRemove(currentSnapshot.ImmutabilityPolicy);

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

                Snapshot persistedSnapshot = VerifySnapshotPolicy(resourceGroupName, snapshotName,
                    SnapshotImmutabilityPolicyRules.MatchesRemove);

                WriteObject(ComputeAutomationAutoMapperProfile.Mapper.Map<Snapshot, PSSnapshot>(persistedSnapshot));
            });
        }
    }
}
