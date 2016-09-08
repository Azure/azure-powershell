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

namespace Microsoft.Azure.Commands.Sql.Auditing.Model
{
    /// <summary>
    /// types of storage keys
    /// </summary>
    public enum StorageKeyKind { Primary, Secondary };

    /// <summary>
    /// The possible states in which an auditing policy may be in
    /// </summary>
    public enum AuditStateType { Enabled, Disabled, New };

    /// <summary>
    /// The base class that defines the core properties of an auditing policy
    /// </summary>
    public abstract class AuditingPolicyModel
    {
        /// <summary>
        /// Gets or sets the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the audit state
        /// </summary>
        public AuditStateType AuditState { get; set; }

        /// <summary>
        /// Gets or sets the storage account name
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the storage key type
        /// </summary>
        public StorageKeyKind StorageKeyType { get; set; }

        /// <summary>
        /// Gets or sets the retention days
        /// </summary>
        public uint? RetentionInDays { get; internal set; }

        public abstract bool IsInUse();
    }
}
