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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SqlSensitivityLabelCmdletSuffix,
        DefaultParameterSetName = SqlSensitivityLabelParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveSqlSensitivityLabel : SqlSensitivityLabelCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var policy = RetrieveSqlInformationProtectionPolicy();
            var guidLabelPair = policy?.Labels?.FirstOrDefault(kvp => kvp.Value.DisplayName == DisplayName);
            if (!guidLabelPair.HasValue)
            {
                throw new PSArgumentException(string.Format(Resources.SqlSensitivityLabelNotFoundError, DisplayName));
            }

            policy.InformationTypes.Values.
                Where(it => it.RecommendedLabelId.ToString().Equals(guidLabelPair.Value.Key, System.StringComparison.OrdinalIgnoreCase)).
                ForEach(it => it.RecommendedLabelId = null);
            if (!policy.Labels.Remove(guidLabelPair.Value))
            {
                throw new Exception(string.Format(Resources.SqlSensitivityRemovalFailureError, DisplayName));
            }

            SetInformationProtectionPolicy(policy);
            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
