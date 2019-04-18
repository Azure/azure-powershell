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

using Microsoft.Azure.Commands.Sql.Auditing.Services;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    public abstract class ServerDiagnosticAuditingSettingsModel : ServerBlobAuditingSettingsModel
    {
        [Hidden]
        public override string StorageAccountName { get; set; }

        [Hidden]
        public override StorageKeyKind StorageKeyType { get; set; }

        [Hidden]
        public override uint? RetentionInDays { get; internal set; }

        [Hidden]
        public override Guid StorageAccountSubscriptionId { get; set; }

        protected override bool IsAuditStateDisabled =>
            IsGlobalAuditEnabled == false ||
            IsAzureMonitorTargetEnabled == false ||
            DiagnosticsEnablingAuditCategory == null ||
            DiagnosticsEnablingAuditCategory.Any() == false;

        internal override void PersistChanges(SqlAuditAdapter adapter) => PersistDiagnosticSettingsChanges(adapter);
    }
}
