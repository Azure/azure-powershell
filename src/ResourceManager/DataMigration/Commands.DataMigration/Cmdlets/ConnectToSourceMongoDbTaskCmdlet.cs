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
using PSModels = Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToSourceMongoDbTaskCmdlet : TaskCmdlet<PSModels.MongoDbConnectionInfo>
    {
        public ConnectToSourceMongoDbTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(SourceConnection, typeof(PSModels.MongoDbConnectionInfo), "MongoDb Connection Detail ", true);
            this.SimpleParam(SourceCred, typeof(PSCredential), "Credential Detail", false);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            var properties = new ConnectToMongoDbTaskProperties();
            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                var conn = MyInvocation.BoundParameters[SourceConnection] as PSModels.MongoDbConnectionInfo;
                if (MyInvocation.BoundParameters.ContainsKey(SourceCred))
                {
                    PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                    conn.UserName = cred.UserName;
                    conn.Password = Decrypt(cred.Password);
                    conn.ConstructConnectionString();
                }
                properties.Input = new MongoDbConnectionInfo { ConnectionString = conn.ConnectionString };
            }

            return properties;
        }
    }
}
