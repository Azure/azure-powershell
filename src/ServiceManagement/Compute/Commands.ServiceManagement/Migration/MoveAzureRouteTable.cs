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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Network;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    /// <summary>
    /// Migrate ASM Route table to ARM
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureRouteTable", SupportsShouldProcess = true), OutputType(typeof(OperationStatusResponse))]
    public class MoveRouteTableCommand : MoveAzureNetworkResourceBase
    {
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RouteTable name")]
        [ValidateNotNullOrEmpty]
        public string RouteTableName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Validate.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.Routes.ValidateMigration(this.RouteTableName),
                (operation, service) =>
                {
                    var context = MigrationValidateContextHelper.ConvertToContext(operation, service);
                    return context;
                });
            }
            else if (this.Abort.IsPresent)
            {
                if(this.ShouldProcess(string.Format(Resources.MigrateResourceShoudlProcessAction, "Abort", this.RouteTableName), string.Format(Resources.MigrateResourceShoudlProcessTarget, "Abort", this.RouteTableName)))
                {
                    ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.NetworkClient.Routes.AbortMigration(this.RouteTableName));
                }
            }
            else if (this.Commit.IsPresent)
            {
                if (this.ShouldProcess(string.Format(Resources.MigrateResourceShoudlProcessAction, "Commit", this.RouteTableName), string.Format(Resources.MigrateResourceShoudlProcessTarget, "Commit", this.RouteTableName)))
                {
                    ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.NetworkClient.Routes.CommitMigration(this.RouteTableName));
                }
            }
            else
            {
                if (this.ShouldProcess(string.Format(Resources.MigrateResourceShoudlProcessAction, "Prepare", this.RouteTableName), string.Format(Resources.MigrateResourceShoudlProcessTarget, "Prepare", this.RouteTableName)))
                {
                    ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.NetworkClient.Routes.PrepareMigration(this.RouteTableName));
                }
            }
        }
    }
}
