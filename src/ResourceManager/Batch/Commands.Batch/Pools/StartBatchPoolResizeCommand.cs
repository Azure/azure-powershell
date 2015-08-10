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
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsLifecycle.Start, "AzureBatchPoolResize")]
    public class StartBatchPoolResizeCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The name of the pool to resize.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The number of target dedicated VMs.")]
        [ValidateNotNullOrEmpty]
        public int TargetDedicated { get; set; }

        [Parameter(HelpMessage = "The resize timeout.  If the pool has not reached the target after this time the resize is automatically stopped.")]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ResizeTimeout { get; set; }

        [Parameter(HelpMessage = "The deallocation option associated with this resize.")]
        [ValidateNotNullOrEmpty]
        public TVMDeallocationOption DeallocationOption { get; set; }
        
        public override void ExecuteCmdlet()
        {
            PoolResizeParameters parameters = new PoolResizeParameters(this.BatchContext, this.Name, null, this.AdditionalBehaviors)
            {
                TargetDedicated = this.TargetDedicated,
                ResizeTimeout = this.ResizeTimeout,
                DeallocationOption = this.DeallocationOption
            };

            BatchClient.ResizePool(parameters);
        }
    }
}
