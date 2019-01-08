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
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToSourceSqlServerSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        public ConnectToSourceSqlServerSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToSourceSqlServerSyncTaskProperties properties = new ConnectToSourceSqlServerSyncTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                properties.Input = new ConnectToSourceSqlServerTaskInput();
                properties.Input.SourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.SourceConnectionInfo.UserName = cred.UserName;
                properties.Input.SourceConnectionInfo.Password = Decrypt(cred.Password);
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
