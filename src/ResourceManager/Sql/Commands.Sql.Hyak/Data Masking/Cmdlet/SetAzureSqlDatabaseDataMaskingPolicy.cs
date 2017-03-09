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

using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Sets the data masking policy properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseDataMaskingPolicy", SupportsShouldProcess = true), OutputType(typeof(DatabaseDataMaskingPolicyModel))]
    public class SetAzureSqlDatabaseDataMaskingPolicy : SqlDatabaseDataMaskingPolicyCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the privileged login names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of privileged user ids login name")]
        public string PrivilegedLogins { get; set; }

        /// <summary>
        /// Gets or sets the privileged users names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of privileged user ids login name")]
        public string PrivilegedUsers { get; set; }

        /// <summary>
        /// Gets or sets the name of the data masking state
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines if data masking is enabled or disabled for this database")]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string DataMaskingState { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override DatabaseDataMaskingPolicyModel ApplyUserInputToModel(DatabaseDataMaskingPolicyModel model)
        {
            base.ApplyUserInputToModel(model);

            if (PrivilegedLogins != null) // empty string here means that the user clears the logins list
            {
                WriteWarning("The parameter PrivilegedLogins is being deprecated and will be removed in a future release. Use the PrivilegedUsers parameter to provide SQL users excluded from masking.");
                model.PrivilegedUsers = PrivilegedLogins;
            }

            if (PrivilegedUsers != null) // empty string here means that the user clears the users list
            {
                model.PrivilegedUsers = PrivilegedUsers;
            }

            if (!string.IsNullOrEmpty(DataMaskingState))
            {
                model.DataMaskingState = (DataMaskingState == SecurityConstants.Enabled) ? DataMaskingStateType.Enabled : DataMaskingStateType.Disabled;
            }

            return model;
        }
    }
}