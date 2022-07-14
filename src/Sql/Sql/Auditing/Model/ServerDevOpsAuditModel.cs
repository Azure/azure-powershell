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

using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public enum AuditStateType { Enabled, Disabled };

    public class ServerDevOpsAuditModel
    {
        public string ResourceGroupName { get; set; }

        public string ServerName { get; set; }

        public AuditStateType BlobStorageTargetState { get; set; }

        public string StorageAccountResourceId { get; set; }

        public AuditStateType EventHubTargetState { get; set; }

        public string EventHubName { get; set; }

        public string EventHubAuthorizationRuleResourceId { get; set; }

        public AuditStateType LogAnalyticsTargetState { get; set; }

        public string WorkspaceResourceId { get; set; }

        [Hidden]
        internal bool? IsAzureMonitorTargetEnabled { get; set; }

        [Hidden]
        internal IList<DiagnosticSettingsResource> DiagnosticsEnablingAuditCategory { get; set; }

        [Hidden]
        internal string NextDiagnosticSettingsName { get; set; }

        public bool? IsManagedIdentityInUse { get; set; }
    }
}
