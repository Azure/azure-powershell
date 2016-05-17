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
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchPoolUsageMetrics), OutputType(typeof(PSPoolUsageMetrics))]
    public class GetBatchPoolUsageMetrics : BatchObjectModelCmdletBase
    {
        [Parameter]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            ListPoolUsageOptions options = new ListPoolUsageOptions(this.BatchContext, this.AdditionalBehaviors)
            {
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                Filter = this.Filter,
            };

            foreach (PSPoolUsageMetrics poolUsageMetrics in BatchClient.ListPoolUsageMetrics(options))
            {
                WriteObject(poolUsageMetrics);
            }
        }
    }
}
