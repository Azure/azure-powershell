using System;
using System.Text.RegularExpressions;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public abstract class SnapshotImmutabilityPolicyBaseCmdlet : ComputeAutomationBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        private static readonly Regex SnapshotResourceIdPattern = new Regex(
            @"^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft\.Compute/snapshots/(?<snapshotName>[^/]+)$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        protected abstract bool RequiresRiskAcknowledgement { get; }
        protected abstract string RiskAcknowledgement { get; }
        protected abstract string PolicyAction { get; }

        protected override void ProcessRecord()
        {
            GetSnapshotIdentity(out string resourceGroupName, out string snapshotName);
            string snapshotId = $"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}";

            // The standard job dispatcher runs ExecuteCmdlet on a worker; prompts belong here.
            ConfirmAction(Force.IsPresent, RiskAcknowledgement, PolicyAction, snapshotId,
                () => base.ProcessRecord(), () => RequiresRiskAcknowledgement);
        }

        protected Snapshot VerifySnapshotPolicy(string resourceGroupName, string snapshotName,
            Func<ImmutabilityPolicy, bool> matches)
        {
            Snapshot snapshot;
            try
            {
                snapshot = SnapshotsClient.Get(resourceGroupName, snapshotName);
            }
            catch (Exception exception)
            {
                ThrowPolicyVerificationError(resourceGroupName, snapshotName, exception);
                throw;
            }

            if (snapshot == null || !matches(snapshot.ImmutabilityPolicy))
            {
                ThrowPolicyVerificationError(resourceGroupName, snapshotName, null);
            }

            return snapshot;
        }

        private void ThrowPolicyVerificationError(string resourceGroupName, string snapshotName, Exception innerException)
        {
            string snapshotId = $"/subscriptions/{DefaultContext.Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/snapshots/{snapshotName}";
            var exception = new InvalidOperationException(
                $"The immutability policy change for snapshot '{snapshotId}' may have been applied, but its persisted state could not be verified. "
                + $"Inspect (Get-AzSnapshot -ResourceGroupName '{resourceGroupName}' -SnapshotName '{snapshotName}').ImmutabilityPolicy before retrying. "
                + "No rollback or automatic reapplication was attempted.", innerException);
            ThrowTerminatingError(new ErrorRecord(exception, "SnapshotImmutabilityPolicyVerificationFailed",
                ErrorCategory.InvalidResult, snapshotId));
        }

        protected void GetSnapshotIdentity(out string resourceGroupName, out string snapshotName)
        {
            if (ParameterSetName == DefaultParameterSet)
            {
                resourceGroupName = ResourceGroupName;
                snapshotName = SnapshotName;
                return;
            }

            string resourceId = ParameterSetName == InputObjectParameterSet ? InputObject?.Id : ResourceId;
            Match match = SnapshotResourceIdPattern.Match(resourceId ?? string.Empty);
            if (!match.Success)
            {
                throw new InvalidOperationException("The resource ID must identify a Microsoft.Compute/snapshots resource.");
            }

            if (!string.Equals(match.Groups["subscriptionId"].Value, DefaultContext.Subscription.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("The snapshot resource ID must belong to the current subscription context.");
            }

            resourceGroupName = match.Groups["resourceGroupName"].Value;
            snapshotName = match.Groups["snapshotName"].Value;
        }

        protected static void ValidateSnapshotAccessState(string accessState)
        {
            SnapshotImmutabilityPolicyRules.ValidateSnapshotAccessState(accessState);
        }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Position = 0, Mandatory = true)]
        [ResourceNameCompleter("Microsoft.Compute/snapshots", "ResourceGroupName")]
        [Alias("SnapshotName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected string SnapshotName => Name;

        [Parameter(ParameterSetName = ResourceIdParameterSet, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = InputObjectParameterSet, Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSSnapshot InputObject { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
