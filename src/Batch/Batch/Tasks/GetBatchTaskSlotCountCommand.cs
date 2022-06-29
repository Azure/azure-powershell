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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchTaskSlotCount", DefaultParameterSetName = Constants.IdParameterSet), OutputType(typeof(PSTaskSlotCounts))]
    public class GetBatchTaskSlotCountCommand : BatchObjectModelCmdletBase
    {
        [Parameter(
            Position = 0,
            ParameterSetName = Constants.IdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the job for which to get task slot counts."
        )]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(
            Position = 0, 
            ParameterSetName = Constants.ParentObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the job that contains tasks that this cmdlet gets. To obtain a **PSCloudJob** object, use the Get-AzBatchJob cmdlet."
        )]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            GetTaskCountsOptions options = new GetTaskCountsOptions(this.BatchContext, this.JobId, this.Job, this.AdditionalBehaviors);

            PSTaskSlotCounts taskSlotCount = BatchClient.GetTaskSlotCounts(options);

            WriteObject(taskSlotCount);
        }
    }
}
