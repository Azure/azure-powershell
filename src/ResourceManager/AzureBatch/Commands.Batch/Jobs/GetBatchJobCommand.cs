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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchJob, DefaultParameterSetName = Constants.ODataFilterParameterSet),
        OutputType(typeof(PSCloudJob))]
    public class GetBatchJobCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string JobScheduleId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSCloudJobSchedule JobSchedule { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Select { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Expand { get; set; }

        public override void ExecuteCmdlet()
        {
            ListJobOptions options = new ListJobOptions(this.BatchContext, this.AdditionalBehaviors)
            {
                JobId = this.Id,
                JobScheduleId = this.JobScheduleId,
                JobSchedule = this.JobSchedule,
                Filter = this.Filter,
                Select = this.Select,
                Expand = this.Expand,
                MaxCount = this.MaxCount
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSCloudJob job in BatchClient.ListJobs(options))
            {
                WriteObject(job);
            }
        }
    }
}
