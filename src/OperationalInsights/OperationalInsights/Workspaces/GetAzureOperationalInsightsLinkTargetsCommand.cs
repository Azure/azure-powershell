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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [GenericBreakingChange("Get-AzOperationalInsightsLinkTargets alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsLinkTarget"), OutputType(typeof(PSAccount))]
    [Alias("Get-AzOperationalInsightsLinkTargets")]
    public class GetAzureOperationalInsightsLinkTargetsCommand : OperationalInsightsBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            WriteObject(OperationalInsightsClient.GetLinkTargets(), true);
        }
    }
}
