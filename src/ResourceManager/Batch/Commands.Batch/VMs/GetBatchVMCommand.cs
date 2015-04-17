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
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchVM", DefaultParameterSetName = Constants.ODataFilterParameterSet), OutputType(typeof(PSVM))]
    public class GetBatchVMCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the pool.")]
        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the vm to retrieve from the pool.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The PSCloudPool object representing the pool which contains the vms.")]
        [ValidateNotNullOrEmpty]
        public PSCloudPool Pool { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "The OData filter clause to use when querying for vms.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(ParameterSetName = Constants.ODataFilterParameterSet, HelpMessage = "The maximum number of vms to return.")]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        public override void ExecuteCmdlet()
        {
            ListVMOptions options = new ListVMOptions()
            {
                Context = this.BatchContext,
                PoolName = this.PoolName,
                VMName = this.Name,
                Pool = this.Pool,
                Filter = this.Filter,
                MaxCount = this.MaxCount,
                AdditionalBehaviors = this.AdditionalBehaviors
            };

            // The enumerator will internally query the service in chunks. Using WriteObject with the enumerate flag will enumerate
            // the entire collection first and then write the items out one by one in a single group.  Using foreach, we can take 
            // advantage of the enumerator's behavior and write output to the pipeline in bursts.
            foreach (PSVM workItem in BatchClient.ListVMs(options))
            {
                WriteObject(workItem);
            }
        }
    }
}
