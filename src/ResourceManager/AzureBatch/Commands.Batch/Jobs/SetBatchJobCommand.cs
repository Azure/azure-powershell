﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchJob"), OutputType(typeof(void))]
    public class SetBatchJobCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The PSCloudJob object with changes to commit to the Batch Service.")]
        [ValidateNotNullOrEmpty]
        public PSCloudJob Job { get; set; }

        public override void ExecuteCmdlet()
        {
            this.BatchClient.UpdateJob(this.BatchContext, this.Job, this.AdditionalBehaviors);
        }
    }
}
