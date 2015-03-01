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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.DataMasking
{
    /// <summary>
    /// Sets the data masking policy properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseDataMaskingPolicy"), OutputType(typeof(DatabaseDataMaskingPolicyModel))]
    public class SetAzureSqlDatabaseDataMaskingPolicy : SqlDatabaseDataMaskingPolicyCmdletBase
    {

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the privileged login names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon seperated list of privileged user ids login name")]
        public string PrivilegedLogins { get; set; }

        /// <summary>
        /// Gets or sets the name of the data masking state
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines if data masking is enabled or disabled for this database")]
        [ValidateSet(Constants.Enabled, Constants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string DataMaskingState  { get; set; }

        /// <summary>
        /// Gets or sets the masking level
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines if data masking level")]
        [ValidateSet(Constants.Standard, Constants.Extended, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string MaskingLevel { get; set; }

        protected override bool writeResult() { return PassThru; }

        protected override DatabaseDataMaskingPolicyModel UpdateModel(DatabaseDataMaskingPolicyModel model)
        {
            base.UpdateModel(model);

            if (PrivilegedLogins != null) // empty string here means that the user clears the logins list
            {
                model.PrivilegedLogins = PrivilegedLogins;
            }
            
            if (!string.IsNullOrEmpty(DataMaskingState))
            {
                model.DataMaskingState = (DataMaskingState == Constants.Enabled) ? DataMaskingStateType.Enabled : DataMaskingStateType.Disabled;
            }

            if (!string.IsNullOrEmpty(MaskingLevel))
            {
                model.MaskingLevel = (MaskingLevel == Constants.Standard) ? MaskingLevelType.Standard : MaskingLevelType.Extended;
            }
            return model;
        }
    }
}
