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
    [Cmdlet(VerbsLifecycle.Enable, Constants.AzureBatchAutoScale)]
    public class EnableBatchAutoScaleCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "The id of the pool to enable automatic scaling on.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 1)]
        [ValidateNotNullOrEmpty]
        public string AutoScaleFormula { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? AutoScaleEvaluationInterval { get; set; }

        public override void ExecuteCmdlet()
        {
            EnableAutoScaleParameters parameters = new EnableAutoScaleParameters(this.BatchContext, this.Id,
                pool: null, additionalBehaviors: this.AdditionalBehaviors)
            {
                AutoScaleFormula = this.AutoScaleFormula,
                AutoScaleEvaluationInterval = this.AutoScaleEvaluationInterval
            };

            BatchClient.EnableAutoScale(parameters);
        }
    }
}
