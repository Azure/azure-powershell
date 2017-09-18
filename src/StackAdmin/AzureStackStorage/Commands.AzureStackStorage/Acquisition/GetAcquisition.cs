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


using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{

    /// <summary>
    /// Lists page blob acquisitions.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminAcquisition)]
    [Alias("Get-ACSAcquisition")]
    public sealed class GetAdminAcquisition : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Tenant Subscription Id to filter 
        /// </summary>
        [Parameter(Mandatory = false)]
        public string TenantSubscriptionId { get; set; }

        /// <summary>
        /// Storage account to filter
        /// </summary>
        [Parameter(Mandatory = false)]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Containers to Filter
        /// </summary>
        [Parameter(Mandatory = false)]
        public string Container { get; set; }

        protected override void Execute()
        {
            string filter = Tools.GenerateAcquisitionQueryFilterString(TenantSubscriptionId, StorageAccountName, Container);
            var result = Client.Acquisitions.List(ResourceGroupName, FarmName, filter);
            WriteObject(result.Acquisitions.Select(_ => new AcquisitionResponse(_)), true);
        }
    }
}