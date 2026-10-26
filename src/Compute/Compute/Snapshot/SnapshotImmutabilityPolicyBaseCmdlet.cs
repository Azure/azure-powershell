using System;
using System.Text.RegularExpressions;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

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

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
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
