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

using System.Management.Automation;
using Microsoft.Azure.Management.StorageAdmin;

namespace Microsoft.Azure.Commands.AzureStack.Storage
{
    /// <summary>
    ///     SYNTAX
    ///          Sync-StorageAccounts [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-TenantSubscriptionId] {string} 
    /// 
    /// </summary>
    [Cmdlet("Sync", Nouns.AdminStorageAccounts)]
    public sealed class SyncStorageAccounts : AdminCmdlet
    {
        /// <summary>
        /// Tenant Subscription Id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string TenantSubscriptionId { get; set; }

        protected override void Execute()
        {
            var response = Client.StorageAccounts.SyncAll(TenantSubscriptionId);
            WriteObject(response, true);
            WriteWarning(Resources.WaitAfterArmSync);
        }
    }
}
