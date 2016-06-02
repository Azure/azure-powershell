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
    [Cmdlet(VerbsCommon.Set, Constants.AzureBatchPoolOSVersion)]
    public class SetBatchPoolOSVersionCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "The id of the pool.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The Azure Guest OS version to be installed on the virtual machines in the pool.")]
        [ValidateNotNullOrEmpty]
        public string TargetOSVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            ChangeOSVersionParameters parameters = new ChangeOSVersionParameters(this.BatchContext, this.Id, null,
                this.TargetOSVersion, this.AdditionalBehaviors);
            BatchClient.ChangeOSVersion(parameters);
        }
    }
}
