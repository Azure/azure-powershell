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
using System.Threading;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Get the Garbage Collection job status
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminOnDemandGcStatus)]
    public sealed class GetOnDemandGcStatus : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// JobId of the Gabage Collection Job
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string JobId { get; set; }

        protected override void Execute()
        {
            OnDemandGcResponse response = Client.Farms.GetOnDemandGcStatus(ResourceGroupName, FarmName, JobId);

            this.WriteVerbose(String.Format("Reclaim Space Job result returned {0}", response.StatusCode));
            String GcStatus = (response.StatusCode == System.Net.HttpStatusCode.Accepted) ? "Reclaim Space Job InProgress": "Reclaim Space Job Completed";

            this.WriteObject(GcStatus, true);
        }
    }
}
