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
    [Cmdlet(VerbsCommon.Get, Constants.AzureBatchJobPrepAndReleaseStatus, DefaultParameterSetName = Constants.IdParameterSet),
        OutputType(typeof(PSJobPreparationAndReleaseTaskExecutionInformation))]
    public class GetBatchJobPreparationAndReleaseTaskStatusCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0,
            ParameterSetName = Constants.IdParameterSet,
            Mandatory = true,
            HelpMessage = "Specifies the ID of the job whose preparation and release tasks should be retrieved. You cannot specify wildcard characters.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(
            Position = 0,
            ParameterSetName = Constants.InputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Specifies a PSCloudJob object that represents the job to get the preparation and release task status from. To obtain a PSCloudJob object, use the Get-AzureBatchJob cmdlet.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob InputObject { get; set; }
        
        [Parameter(HelpMessage = "Specifies an OData filter clause. If you do not specify a filter, this cmdlet returns all job preparation and release task status' for the job.")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(HelpMessage = "Specifies the maximum number of jobs preparation and release task status' to return.")]
        public int MaxCount { get; set; } = Constants.DefaultMaxCount;

        [Parameter(HelpMessage = "Specifies an OData select clause. Specify a value for this parameter to get specific properties rather than all object properties.")]
        [ValidateNotNullOrEmpty]
        public string Select { get; set; }

        [Parameter(HelpMessage = "Specifies an Open Data Protocol (OData) expand clause. Specify a value for this parameter to get associated entities of the main entity that you get.")]
        [ValidateNotNullOrEmpty]
        public string Expand { get; set; }

        public override void ExecuteCmdlet()
        {
            var options = new ListJobPreparationAndReleaseStatusOptions(this.BatchContext, this.AdditionalBehaviors)
            {
                JobId = this.Id,
                Job = this.InputObject,
                Filter = this.Filter,
                Select = this.Select,
                Expand = this.Expand,
                MaxCount = this.MaxCount
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSJobPreparationAndReleaseTaskExecutionInformation jobPrepAndReleaseInfo in BatchClient.ListJobPreparationAndReleaseStatus(options))
            {
                WriteObject(jobPrepAndReleaseInfo);
            }
        }
    }
}
