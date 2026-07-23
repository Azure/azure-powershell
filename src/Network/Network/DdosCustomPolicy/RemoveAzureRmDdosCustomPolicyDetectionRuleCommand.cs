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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicyDetectionRule", SupportsShouldProcess = true), OutputType(typeof(PSDdosCustomPolicy))]
    public partial class RemoveAzureRmDdosCustomPolicyDetectionRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The DDoS custom policy object containing detection rules.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the detection rule to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!ShouldProcess(this.DdosCustomPolicy.Name, string.Format("Remove DDoS custom policy detection rule '{0}'", this.Name)))
            {
                WriteObject(this.DdosCustomPolicy, true);
                return;
            }

            if (this.DdosCustomPolicy.DetectionRules == null || this.DdosCustomPolicy.DetectionRules.Count == 0)
            {
                WriteObject(this.DdosCustomPolicy);
                return;
            }

            // Find the detection rule by Name (Find - removes one match)
            var ruleToRemove = this.DdosCustomPolicy.DetectionRules.Find(
                r => string.Equals(r.Name, this.Name, StringComparison.OrdinalIgnoreCase));

            if (ruleToRemove != null)
            {
                this.DdosCustomPolicy.DetectionRules.Remove(ruleToRemove);
            }

            // Null out the collection if empty
            if (this.DdosCustomPolicy.DetectionRules.Count == 0)
            {
                this.DdosCustomPolicy.DetectionRules = null;
            }

            WriteObject(this.DdosCustomPolicy, true);
        }
    }
}
