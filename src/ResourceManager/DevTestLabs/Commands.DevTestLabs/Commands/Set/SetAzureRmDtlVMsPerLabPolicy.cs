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

using Microsoft.Azure.Management.DevTestLabs;
using Microsoft.Azure.Management.DevTestLabs.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDtlVMsPerLabPolicy", HelpUri = Constants.DevTestLabsHelpUri, DefaultParameterSetName = ParameterSetEnable)]
    public class SetAzureRmDtlVMsPerLabPolicy : DtlPolicyCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Maximum number of virtual machines.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 4,
            HelpMessage = "Maximum total number of virtual machines allowed in the lab.")]
        [ValidateNotNullOrEmpty]
        public int MaxVMs { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet()
        {
            var policy = DataServiceClient.Policy.CreateOrUpdateResource(
                ResourceGroupName,
                LabName,
                Constants.Default,
                WellKnownPolicyNames.MaxVmsAllowedPerLab,
                new Policy
                {
                    FactName = PolicyFactName.LabVmCount,
                    Threshold = MaxVMs.ToString(),
                    EvaluatorType = PolicyEvaluatorType.MaxValuePolicy,
                    Status = Enable ? PolicyStatus.Enabled : PolicyStatus.Disabled
                }
                );

            WriteObject(policy);
        }
    }
}
