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

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// SQL Server Extension's public settings
    /// </summary>
    public class SqlServerPublicSettings
    {
        /// <summary>
        /// Auto patching settings
        /// </summary>
        public AutoPatchingSettings AutoPatchingSettings { get; set; }

        /// <summary>
        /// Auto-backup settings
        /// </summary>
        public AutoBackupSettings AutoBackupSettings { get; set; }

        /// <summary>
        /// AkV settings
        /// </summary>
        public KeyVaultCredentialSettings KeyVaultCredentialSettings { get; set; }

        /// <summary>
        /// Auto-telemetry settings
        /// </summary>
        public AutoTelemetrySettings AutoTelemetrySettings { get; set; }
    }
}
