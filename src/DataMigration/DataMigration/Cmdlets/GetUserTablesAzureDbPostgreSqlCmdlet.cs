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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class GetUserTablesAzureDbPostgreSqlCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SelectedDatabases = "SelectedDatabases";

        public GetUserTablesAzureDbPostgreSqlCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabases, typeof(string[]), "List of PostgreSQL databases for which to collect tables", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            GetUserTablesPostgreSqlTaskProperties properties = new GetUserTablesPostgreSqlTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                properties.Input = new GetUserTablesPostgreSqlTaskInput();
                properties.Input.ConnectionInfo = (PostgreSqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.ConnectionInfo.UserName = cred.UserName;
                properties.Input.ConnectionInfo.Password = Decrypt(cred.Password);
                properties.Input.SelectedDatabases = ((string[])MyInvocation.BoundParameters[SelectedDatabases]).ToList();
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
