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
using System.Security;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchComputeNodeExtension", DefaultParameterSetName = Constants.IdParameterSet), OutputType(typeof(PSNodeVMExtension))]
    public class GetBatchComputeNodeExtensionCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter(Position = 0, ParameterSetName = Constants.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the pool to which the extension's compute node belongs.")]
        [ValidateNotNullOrEmpty]
        public string PoolId { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.ParentObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The pool to which the extension's compute node belongs.")]
        [ValidateNotNullOrEmpty]
        public PSCloudPool Pool { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the compute node to which the extension belongs.")]
        [Parameter(Position = 1, ParameterSetName = Constants.ParentObjectParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ComputeNodeId { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.IdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the extension to get.")]
        [Parameter(Position = 2, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = Constants.IdParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Select { get; set; }


        [Parameter(ParameterSetName = Constants.IdParameterSet)]
        [Parameter(ParameterSetName = Constants.ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public int MaxCount
        {
            get { return maxCount; }
            set { maxCount = value; }
        }

        protected override void ExecuteCmdletImpl()
        {
            ListComputeNodeExtensionParameters options = new ListComputeNodeExtensionParameters(BatchContext, PoolId, Pool, ComputeNodeId, Name, AdditionalBehaviors)
            {
                Select = Select,
                MaxCount = MaxCount,
            };

            foreach (PSNodeVMExtension extension in BatchClient.ListComputeNodeExtension(options))
            {
                WriteObject(extension);
            }
        }
    }
}
