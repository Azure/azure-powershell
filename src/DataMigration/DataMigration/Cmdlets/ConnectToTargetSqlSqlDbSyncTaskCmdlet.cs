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

using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToTargetSqlSqlDbSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        public ConnectToTargetSqlSqlDbSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SourceConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToTargetSqlSqlDbSyncTaskProperties properties = new ConnectToTargetSqlSqlDbSyncTaskProperties();

            if ((MyInvocation.BoundParameters.ContainsKey(TargetConnection)) && (MyInvocation.BoundParameters.ContainsKey(SourceConnection)))
            {
                properties.Input = new ConnectToTargetSqlSqlDbSyncTaskInput();

                properties.Input.TargetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential targetCred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                properties.Input.TargetConnectionInfo.UserName = targetCred.UserName;
                properties.Input.TargetConnectionInfo.Password = Decrypt(targetCred.Password);

                properties.Input.SourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential sourceCred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.SourceConnectionInfo.UserName = sourceCred.UserName;
                properties.Input.SourceConnectionInfo.Password = Decrypt(sourceCred.Password);
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
