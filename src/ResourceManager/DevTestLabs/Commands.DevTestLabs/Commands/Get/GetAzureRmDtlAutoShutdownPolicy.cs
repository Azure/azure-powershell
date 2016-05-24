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

using Microsoft.Azure.Commands.DevTestLabs.Models;
using Microsoft.Azure.Management.DevTestLabs;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDtlAutoShutdownPolicy",
        HelpUri = Constants.DevTestLabsHelpUri)]
    [OutputType(typeof(PSSchedule))]
    public class GetAzureRmDtlAutoShutdownPolicy : DevTestLabsCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            var schedule = DataServiceClient.Schedule.GetResource(
                ResourceGroupName,
                LabName,
                WellKnownPolicyNames.LabVmsShutdown);

            WriteObject(schedule.DuckType<PSSchedule>());
        }
    }
}
