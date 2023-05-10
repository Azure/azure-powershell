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

using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Cmdlet
{
    public class SqlManagedInstanceAdvancedDataSecurityCmdletBase : AzureSqlCmdletBase<ManagedInstanceAdvancedDataSecurityPolicyModel, SqlAdvancedDataSecurityAdapter>
    {
        protected const string UseParentResourceParameterSet = "UseParentResourceParameterSet";

        /// <summary>
        /// Server resource
        /// </summary>
        [Parameter(ParameterSetName = UseParentResourceParameterSet,
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The managed instance object to use with Advanced Data Security policy operation ")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the name of the database managed instance to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database managed instance name.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ManagedInstanceAdvancedDataSecurityPolicyModel GetEntity()
        {
            string resourceGroupName = ResourceGroupName;
            string managedInstanceName = InstanceName;

            if (string.Equals(this.ParameterSetName, UseParentResourceParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                managedInstanceName = InputObject.ManagedInstanceName;
            }

            return new ManagedInstanceAdvancedDataSecurityPolicyModel()
            {
                ResourceGroupName = resourceGroupName,
                ManagedInstanceName = managedInstanceName
            };
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlAdvancedDataSecurityAdapter InitModelAdapter()
        {
            return new SqlAdvancedDataSecurityAdapter(DefaultProfile.DefaultContext);
        }
    }
}
