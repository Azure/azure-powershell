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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.DataMasking
{
    /// <summary>
    /// Removes a data masking rule from a given database
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSqlDatabaseDataMaskingRule", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlDatabaseDataMaskingRule : SqlDatabaseDataMaskingRuleCmdletBase
    {

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(HelpMessage = "Do not confirm on the creation of the firewall rule")]
        public SwitchParameter Force { get; set; }
        
        protected override void SendModel(IEnumerable<DatabaseDataMaskingRuleModel> rules)
        {
            if (!Force.IsPresent && !ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Resources.RemoveDatabaseDataMaskingRuleDescription, RuleId, DatabaseName),
                string.Format(CultureInfo.InvariantCulture, Resources.RemoveDatabaseDataMaskingRuleWarning, RuleId, DatabaseName),
                Resources.ShouldProcessCaption))
            {
                return ;
            }
            ModelAdapter.RemoveDatabaseDataMaskingRule(rules.First(), clientRequestId);
        }

        protected override bool WriteResult() { return PassThru; }
    }
}
