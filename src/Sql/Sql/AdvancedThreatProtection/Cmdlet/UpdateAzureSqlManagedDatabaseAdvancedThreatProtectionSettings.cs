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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Cmdlet
{
    /// <summary>
    /// Updates the Advanced Threat Protection settings on a specific managed instance.
    /// </summary>
    [Cmdlet("Update", AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseAdvancedThreatProtectionSetting", SupportsShouldProcess = true), OutputType(typeof(ManagedDatabaseAdvancedThreatProtectionSettingsModel))]
    public class UpdateAzureSqlManagedDatabaseAdvancedThreatProtectionSettings : SqlManagedDatabaseAdvancedThreatProtectionSettingsCmdletBase
    {
        /// <summary>
        /// Gets or sets the whether to enabled Advanced Threat Protection.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines whether to enable or disable Advanced Threat Protection")]
        [ValidateNotNullOrEmpty]
        public bool? Enable { get; set; }

        /// <summary>
        ///  Defines whether the Cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out.
        /// </summary>
        /// <returns>True if the model object should be written out; false otherwise.</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation.
        /// </summary>
        /// <param name="model">A model object.</param>
        protected override ManagedDatabaseAdvancedThreatProtectionSettingsModel ApplyUserInputToModel(ManagedDatabaseAdvancedThreatProtectionSettingsModel model)
        {
            base.ApplyUserInputToModel(model);

            model.AdvancedThreatProtectionState =
                Enable.HasValue && Enable.Value ? AdvancedThreatProtectionStateType.Enabled : AdvancedThreatProtectionStateType.Disabled;

            return model;
        }
    }
}
