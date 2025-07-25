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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Auditing;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool + SynapseConstants.AdvancedThreatProtectionSetting,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSqlPoolSecurityAlertPolicy))]
    public class UpdateAzureSynapseSqlPoolAdvancedThreatProtectionSetting : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        public PSSynapseSqlPool InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.NotificationRecipientsEmails)]
        [Alias("NotificationRecipientsEmails")]
        public string NotificationRecipientsEmail { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EmailAdmins)]
        [Alias("EmailAdmins")]
        [ValidateNotNullOrEmpty]
        public bool? EmailAdmin { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ExcludedDetectionType)]
        [PSArgumentCompleter(SynapseConstants.DetectionType.None,
            SynapseConstants.DetectionType.Sql_Injection,
            SynapseConstants.DetectionType.Sql_Injection_Vulnerability,
            SynapseConstants.DetectionType.Unsafe_Action,
            SynapseConstants.DetectionType.Data_Exfiltration,
            SynapseConstants.DetectionType.Access_Anomaly)]
        public string[] ExcludedDetectionType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.RetentionInDays)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; internal set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            SqlPoolSecurityAlertPolicy policy = SynapseAnalyticsClient.GetSqlPoolThreatDetectionPolicy(this.ResourceGroupName, this.WorkspaceName, this.Name);

            policy.State = SecurityAlertPolicyState.Enabled;

            if (this.IsParameterBound(c => c.NotificationRecipientsEmail))
            {
                policy.EmailAddresses = this.NotificationRecipientsEmail.Split(';').Where(mail => !string.IsNullOrEmpty(mail)).ToList();
            }

            if (this.IsParameterBound(c => c.EmailAdmin))
            {
                policy.EmailAccountAdmins = this.EmailAdmin;
            }

            if (this.IsParameterBound(c => c.ExcludedDetectionType))
            {
                policy.DisabledAlerts = Utils.ProcessExcludedDetectionTypes(this.ExcludedDetectionType);
            }

            if (this.IsParameterBound(c => c.RetentionInDays))
            {
                policy.RetentionDays = Convert.ToInt32(this.RetentionInDays);
            }

            if (this.IsParameterBound(c => c.StorageAccountName))
            {
                policy.StorageEndpoint = string.Format("https://{0}.blob.{1}", this.StorageAccountName,
                    DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
            }

            if (!string.IsNullOrEmpty(policy.StorageEndpoint))
            {
                policy.StorageAccountAccessKey = SynapseAnalyticsClient.GetStorageKeys(policy.StorageEndpoint)[StorageKeyKind.Primary];
            }
            else
            {
                policy.StorageEndpoint = null;
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSqlPoolThreatProtectionSetting, this.Name, this.WorkspaceName)))
            {
                var result = new PSSqlPoolSecurityAlertPolicy(SynapseAnalyticsClient.SetSqlPoolThreatDetectionPolicy(this.ResourceGroupName, this.WorkspaceName, this.Name, policy),
                    this.ResourceGroupName, this.WorkspaceName, this.Name);
                WriteObject(result);
            }
        }
    }
}
