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

using Microsoft.Azure.Commands.Sql.DataMasking.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataMasking.Cmdlet
{
    /// <summary>
    /// Returns the data masking policy of a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseDataMaskingPolicy", SupportsShouldProcess = true), OutputType(typeof(DatabaseDataMaskingPolicyModel))]
    public class GetAzureSqlDatabaseDataMaskingPolicy : SqlDatabaseDataMaskingPolicyCmdletBase
    {
        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override DatabaseDataMaskingPolicyModel PersistChanges(DatabaseDataMaskingPolicyModel model)
        {
            return null;
        }
    }
}
