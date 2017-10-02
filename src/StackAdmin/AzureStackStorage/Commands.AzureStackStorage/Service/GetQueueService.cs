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


using Microsoft.AzureStack.AzureConsistentStorage.Commands;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using System.Management.Automation;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets the Queue service properties and settings.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminQueueService)]
    [Alias("Get-ACSQueueService")]
    public sealed class GetQueueService : AdminCmdletDefaultFarm
    {
        protected override void Execute()
        {
            QueueServiceGetResponse result = Client.QueueService.Get(ResourceGroupName, FarmName);
            WriteObject(new QueueServiceResponse(result.Resource));
        }
    }
}