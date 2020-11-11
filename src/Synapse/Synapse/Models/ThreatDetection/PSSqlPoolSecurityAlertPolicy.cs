using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlPoolSecurityAlertPolicy : PSServerSecurityAlertPolicy
    {
        public PSSqlPoolSecurityAlertPolicy(SqlPoolSecurityAlertPolicy policy, string resourceGroupName,
            string workspaceName, string sqlPoolName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.SqlPoolName = sqlPoolName;
            Enum.TryParse(policy.State.ToString(), true, out ThreatDetectionStateType state);
            this.ThreatDetectionState = state;
            this.NotificationRecipientsEmails = string.Join(";", policy.EmailAddresses.ToArray());
            this.EmailAdmins = policy.EmailAccountAdmins == null ? false : policy.EmailAccountAdmins.Value;
            this.RetentionInDays = (uint)policy.RetentionDays;
            this.ExcludedDetectionTypes = policy.DisabledAlerts.Where(alert => !string.IsNullOrEmpty(alert)).ToArray() ?? new string[] { };
            ModelizeStorageAccount(policy.StorageEndpoint);
        }

        public string SqlPoolName { get; set; }
    }
}
