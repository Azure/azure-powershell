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

using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Cmdlet
{
    /// <summary>
    /// Returns the Advanced Threat Protection policy of a specific server.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerAdvancedDataSecurityPolicy"), OutputType(typeof(ServerAdvancedDataSecurityPolicyModel))]
    [Alias("Get-AzSqlServerAdvancedThreatProtectionPolicy")]
    public class GetAzureSqlServerAdvancedDataSecurityPolicy : SqlServerAdvancedDataSecurityCmdletBase
    {
        /// <summary>
        /// Provides the model element that this cmdlet operates on
        /// </summary>
        /// <returns>A model object</returns>
        protected override ServerAdvancedDataSecurityPolicyModel GetEntity()
        {
            ServerAdvancedDataSecurityPolicyModel model = base.GetEntity();
            return ModelAdapter.GetServerAdvancedDataSecurityPolicy(model.ResourceGroupName, model.ServerName);
        }

        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override ServerAdvancedDataSecurityPolicyModel PersistChanges(ServerAdvancedDataSecurityPolicyModel model)
        {
            return model;
        }
    }
}
