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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    public abstract class AzureSqlDatabaseGeoBackupPolicyCmdletBase :
        AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel>, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The subscription to operate on</param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.Context);
        }
    }
}
