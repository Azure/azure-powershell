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
        protected override bool RequiresRiskAcknowledgement => string.Equals(PolicyType, "Locked", StringComparison.OrdinalIgnoreCase);
        protected override string RiskAcknowledgement => "Applying or extending Locked retention cannot be undone before expiry. Continue?";
        protected override string PolicyAction => "Set snapshot immutability policy";

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                GetSnapshotIdentity(out string resourceGroupName, out string snapshotName);
                string policyType = string.Equals(PolicyType, "Unlocked", StringComparison.OrdinalIgnoreCase) ? "Unlocked" : "Locked";

                Snapshot currentSnapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
                ValidateSnapshotAccessState(currentSnapshot.SnapshotAccessState);
                SnapshotImmutabilityPolicyRules.ValidateSet(currentSnapshot.ImmutabilityPolicy, policyType, DurationInDays);

                if (policyType == "Unlocked")
                {
                    SnapshotsClient.UpdateImmutabilityPolicy(
                        resourceGroupName, snapshotName, new ImmutabilityPolicyData(DurationInDays, policyType));
                }
                else
                {
                    try
                    {
                        SnapshotsClient.UpdateImmutabilityPolicyLock(
                            resourceGroupName, snapshotName, new ImmutabilityPolicyLockData(DurationInDays, policyType));
                    }
                    catch (CloudException exception) when (
                        exception.Response != null && exception.Response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new UnauthorizedAccessException(
                            "Setting a Locked snapshot immutability policy requires Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action.",
                            exception);
                    }
                }

                Snapshot persistedSnapshot = VerifySnapshotPolicy(resourceGroupName, snapshotName,
                    policy => SnapshotImmutabilityPolicyRules.MatchesSet(currentSnapshot.ImmutabilityPolicy,
                        policy, policyType, DurationInDays));

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
        public int DurationInDays { get; set; }
    }
}
