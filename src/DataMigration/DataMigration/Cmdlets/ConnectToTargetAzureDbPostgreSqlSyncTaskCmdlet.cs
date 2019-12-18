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
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToTargetAzureDbPostgreSqlSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        public ConnectToTargetAzureDbPostgreSqlSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToTargetAzureDbForPostgreSqlSyncTaskProperties properties = new ConnectToTargetAzureDbForPostgreSqlSyncTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                properties.Input = new ConnectToTargetAzureDbForPostgreSqlSyncTaskInput();
                properties.Input.TargetConnectionInfo = (PostgreSqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.TargetConnectionInfo.UserName = cred.UserName;
                properties.Input.TargetConnectionInfo.Password = Decrypt(cred.Password);
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
