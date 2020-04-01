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

using Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SqlSensitivityLabelCmdletSuffix,
        DefaultParameterSetName = SqlSensitivityLabelParameterSet),
        OutputType(typeof(PSSqlSensitivityLabel))]
    public class GetSqlSensitivityLabel : SqlSensitivityLabelCmdlet
    {
        public override void ExecuteCmdlet()
        {
            var policy = RetrieveSqlInformationProtectionPolicy();
            var idLabelPair = policy.Labels?.FirstOrDefault(l => l.Value.DisplayName == DisplayName);
            if (!idLabelPair.HasValue)
            {
                throw new PSArgumentException(string.Format(Resources.SqlSensitivityLabelNotFoundError, DisplayName));
            }

            WriteObject(idLabelPair.Value.ToPSSqlSensitivityLabel(policy), enumerateCollection: true);
        }
    }
}
