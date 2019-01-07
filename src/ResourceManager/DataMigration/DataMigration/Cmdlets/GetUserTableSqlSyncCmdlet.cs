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

using Microsoft.Azure.Management.DataMigration.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class GetUserTableSqlSyncCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SelectedSourceDatabases = "SelectedSourceDatabases";
        private readonly string SelectedTargetDatabases = "SelectedTargetDatabases";

        public GetUserTableSqlSyncCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SelectedSourceDatabases, typeof(string[]), "List of source database names to collect tables for", true);
            this.SimpleParam(SelectedTargetDatabases, typeof(string[]), "List of target database names to collect tables for", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            GetUserTablesSqlSyncTaskProperties properties = new GetUserTablesSqlSyncTaskProperties();

            if ((MyInvocation.BoundParameters.ContainsKey(SourceConnection)) && (MyInvocation.BoundParameters.ContainsKey(TargetConnection)))
            {
                properties.Input = new GetUserTablesSqlSyncTaskInput();

                properties.Input.SourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential sourceCred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.SourceConnectionInfo.UserName = sourceCred.UserName;
                properties.Input.SourceConnectionInfo.Password = Decrypt(sourceCred.Password);

                properties.Input.TargetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential targetCred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                properties.Input.TargetConnectionInfo.UserName = targetCred.UserName;
                properties.Input.TargetConnectionInfo.Password = Decrypt(targetCred.Password);

                properties.Input.SelectedSourceDatabases = ((string[])MyInvocation.BoundParameters[SelectedSourceDatabases]).ToList();
                properties.Input.SelectedTargetDatabases = ((string[])MyInvocation.BoundParameters[SelectedTargetDatabases]).ToList();
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
