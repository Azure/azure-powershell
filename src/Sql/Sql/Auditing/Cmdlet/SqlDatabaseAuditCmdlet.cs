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
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
<<<<<<< HEAD
using System;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
<<<<<<< HEAD
    public class SqlDatabaseAuditCmdlet : AzureSqlDatabaseCmdletBase<DatabaseAuditModel, SqlAuditAdapter>
=======
    public class SqlDatabaseAuditCmdlet : AzureSqlDatabaseCmdletBase<DatabaseAuditModel, SqlDatabaseAuditAdapter>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSetName,
            Mandatory = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSetName,
            Mandatory = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSetName,
            Mandatory = true,
            Position = 2,
            HelpMessage = AuditingHelpMessages.DatabaseNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public override string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.DatabaseInputObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlDatabaseModel DatabaseObject { get; set; }

        protected override DatabaseAuditModel GetEntity()
        {
            if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                ServerName = DatabaseObject.ServerName;
                DatabaseName = DatabaseObject.DatabaseName;
            }

            DatabaseAuditModel model = new DatabaseAuditModel
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName
            };

<<<<<<< HEAD
            ModelAdapter.GetAuditingSettings(ResourceGroupName, ServerName, DatabaseName, model);
            return model;
        }

        protected override SqlAuditAdapter InitModelAdapter()
        {
            return new SqlAuditAdapter(DefaultProfile.DefaultContext);
=======
            ModelAdapter.DatabaseName = DatabaseName;
            ModelAdapter.GetAuditingSettings(ResourceGroupName, ServerName, model);

            return model;
        }

        protected override SqlDatabaseAuditAdapter InitModelAdapter()
        {
            return new SqlDatabaseAuditAdapter(DefaultProfile.DefaultContext, DatabaseName);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
