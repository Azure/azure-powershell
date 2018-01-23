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
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Forces garbage collection of all deleted storage accounts, regardless of the retention period setting. 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, Nouns.AdminOnDemandGc, SupportsShouldProcess = true)]
    [Alias("Clear-ACSStorageAccount")]
    public sealed class ClearDeletedAccounts : AdminCmdletDefaultFarm
    {
        protected override void Execute()
        {
            if (ShouldProcess(
                Resources.OnDemandGcDescription.FormatInvariantCulture(FarmName),
                Resources.OnDemandGcWarning.FormatInvariantCulture(FarmName),
                Resources.ShouldProcessCaption))
            {
                OnDemandGcResponse response = Client.Farms.OnDemandGc(ResourceGroupName, FarmName);

                WriteVerbose(String.Format("response {0}", response.ToString()));
                string jobId;
                ExtractOperationIdFromLocationUri(response.Location, out jobId);
                this.WriteObject(jobId, true);
            }
        }
    }
}
