using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public enum ThreatDetectionStateType { Enabled, Disabled, New };

    public class PSServerSecurityAlertPolicy
    {
        public PSServerSecurityAlertPolicy(ServerSecurityAlertPolicy policy, string resourceGroupName, string workspaceName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            Enum.TryParse(policy.State.ToString(), true, out ThreatDetectionStateType state);
            this.ThreatDetectionState = state;
            this.NotificationRecipientsEmails = string.Join(";", policy.EmailAddresses.ToArray());
            this.EmailAdmins = policy.EmailAccountAdmins == null ? false : policy.EmailAccountAdmins.Value;
            this.RetentionInDays = (uint)policy.RetentionDays;
            this.ExcludedDetectionTypes = policy.DisabledAlerts.Where(alert => !string.IsNullOrEmpty(alert)).ToArray() ?? new string[] { };
            ModelizeStorageAccount(policy.StorageEndpoint);
        }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public ThreatDetectionStateType ThreatDetectionState { get; internal set; }

        public string NotificationRecipientsEmails { get; internal set; }

        public string StorageAccountName { get; internal set; }

        public bool EmailAdmins { get; internal set; }

        public string[] ExcludedDetectionTypes { get; internal set; }

        public uint? RetentionInDays { get; internal set; }

        private void ModelizeStorageAccount(string storageEndpoint)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                this.StorageAccountName = string.Empty;
                return;
            }
            var accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ? 8 : 7; // https:// or http://
            var accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            this.StorageAccountName = storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex - accountNameStartIndex);
        }
    }
}
