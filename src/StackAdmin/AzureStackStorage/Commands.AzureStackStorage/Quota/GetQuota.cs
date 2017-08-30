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
    /// Gets a list of all Storage quota resources in the specified location.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminQuota)]
    [Alias("Get-ACSQuota")]
    public sealed class GetQuota : AdminCmdlet
    {
        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Location { get; set; }

        /// <summary>
        /// Quota Name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void Execute()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                Name = base.ParseNameForQuota(Name);
                QuotaGetResponse response = Client.Quotas.Get(Location, Name);
                WriteObject(new QuotaResponse(response.Quota));
            }
            else
            {
                QuotaListResponse response = Client.Quotas.List(Location);

                WriteObject(response.Quotas.Select(q => new QuotaResponse(q)), true);
            }
        }
    }
}
