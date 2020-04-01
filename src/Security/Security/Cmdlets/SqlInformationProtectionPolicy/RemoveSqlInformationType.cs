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

using Microsoft.Azure.Commands.Security.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SqlInformationTypeCmdletSuffix,
        DefaultParameterSetName = SqlInformationTypeParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveSqlInformationType : SqlInformationTypeCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var policy = RetrieveSqlInformationProtectionPolicy();
            var guidInformationTypePair = policy.InformationTypes?.FirstOrDefault(kvp => kvp.Value.DisplayName == DisplayName);
            if (!guidInformationTypePair.HasValue)
            {
                throw new PSArgumentException(string.Format(Resources.SqlInformationTypeNotFoundError, DisplayName));
            }

            if (!policy.InformationTypes.Remove(guidInformationTypePair.Value))
            {
                throw new Exception(string.Format(Resources.SqlInformationTypeRemovalFailureError, DisplayName));
            }

            SetInformationProtectionPolicy(policy);
            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
