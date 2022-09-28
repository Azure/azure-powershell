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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Managed Instance Advanced Threat Protection Cmdlets
    /// </summary>
    public abstract class SqlManagedInstanceAdvancedThreatProtectionSettingsCmdletBase : AzureSqlCmdletBase<ManagedInstanceAdvancedThreatProtectionSettingsModel, AdvancedThreatProtectionSettingsAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database managed instance to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Managed Instance name.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ManagedInstanceAdvancedThreatProtectionSettingsModel GetEntity()
        {
            return ModelAdapter.GetManagedInstanceAdvancedThreatProtectionSettings(ResourceGroupName, InstanceName);
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override AdvancedThreatProtectionSettingsAdapter InitModelAdapter()
        {
            return new AdvancedThreatProtectionSettingsAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override ManagedInstanceAdvancedThreatProtectionSettingsModel PersistChanges(ManagedInstanceAdvancedThreatProtectionSettingsModel model)
        {
            ModelAdapter.SetManagedInstanceAdvancedThreatProtectionSettings(model);
            return model;
        }
    }
}
