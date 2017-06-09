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

using System.Linq;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets the storage properties and settings for a specified region/farm.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminFarm)]
    [Alias("Get-ACSFarm")]
    public sealed class GetAdminFarm : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Name of the Farm to get
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (string.IsNullOrEmpty(Name) == false)
            {
                FarmGetResponse response = Client.Farms.Get(ResourceGroupName, Name);
                WriteObject(new FarmResponse(response.Farm));
            }
            else
            {
                FarmListResponse response = Client.Farms.List(ResourceGroupName);
                WriteObject(response.Farms.Select(_=>new FarmResponse(_)), true);
            }
        }
    }
}
