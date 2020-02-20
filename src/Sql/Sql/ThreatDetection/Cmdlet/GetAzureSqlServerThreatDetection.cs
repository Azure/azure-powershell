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

using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Cmdlet
{
    /// <summary>
    /// Returns the advanced threat protection settings of a specific server.
    /// </summary>
    [GenericBreakingChange("Get-AzSqlServerAdvancedThreatProtectionSettings alias will be removed in an upcoming breaking change release", "3.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerAdvancedThreatProtectionSetting", SupportsShouldProcess = true), OutputType(typeof(ServerThreatDetectionPolicyModel))]
    [Alias("Get-AzSqlServerAdvancedThreatProtectionSettings")]
    public class AzureRmSqlServerThreatDetectionPolicy : SqlServerThreatDetectionCmdletBase
    {
        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override ServerThreatDetectionPolicyModel PersistChanges(ServerThreatDetectionPolicyModel model)
        {
            return null;
        }
    }
}
