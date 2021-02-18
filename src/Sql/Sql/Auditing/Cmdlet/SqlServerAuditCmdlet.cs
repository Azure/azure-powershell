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
using Microsoft.Azure.Commands.Sql.Server.Model;
<<<<<<< HEAD
using System;
=======
using Microsoft.Azure.Management.Sql.Models;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
<<<<<<< HEAD
    public class SqlServerAuditCmdlet : AzureSqlCmdletBase<ServerAuditModel, SqlAuditAdapter>
=======
    public abstract class SqlServerAuditCmdlet<ServerAuditPolicyType, ServerAuditModelType, ServerAuditAdapterType> : AzureSqlCmdletBase<ServerAuditModelType, ServerAuditAdapterType>
        where ServerAuditPolicyType : ProxyResource 
        where ServerAuditModelType : ServerDevOpsAuditModel, new()
        where ServerAuditAdapterType : SqlAuditAdapter<ServerAuditPolicyType, ServerAuditModelType>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.ServerParameterSetName,
            Mandatory = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ServerParameterSetName,
            Mandatory = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ServerObjectParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlServerModel ServerObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

<<<<<<< HEAD
        protected override ServerAuditModel GetEntity()
=======
        protected override ServerAuditModelType GetEntity()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            if (ServerObject != null)
            {
                ResourceGroupName = ServerObject.ResourceGroupName;
                ServerName = ServerObject.ServerName;
            }

<<<<<<< HEAD
            ServerAuditModel model = new ServerAuditModel()
=======
            ServerAuditModelType model = new ServerAuditModelType()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName
            };

            ModelAdapter.GetAuditingSettings(ResourceGroupName, ServerName, model);
            return model;
        }
<<<<<<< HEAD

        protected override SqlAuditAdapter InitModelAdapter()
        {
            return new SqlAuditAdapter(DefaultProfile.DefaultContext);
        }
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
