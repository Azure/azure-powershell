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
