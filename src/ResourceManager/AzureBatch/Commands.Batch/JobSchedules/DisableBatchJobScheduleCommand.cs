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
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsLifecycle.Disable, Constants.AzureBatchJobSchedule)]
    public class DisableBatchJobScheduleCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "The id of the job schedule to disable.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            BatchClient.DisableJobSchedule(this.BatchContext, this.Id, this.AdditionalBehaviors);
        }
    }
}
