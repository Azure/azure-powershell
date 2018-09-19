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
    public class GetUserTableSqlCmdlet : TaskCmdlet
    {
        private readonly string SelectedDatabase = "SelectedDatabase";

        public GetUserTableSqlCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabase, typeof(string[]), "List of database names to collect tables for", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            GetUserTablesSqlTaskProperties properties = new GetUserTablesSqlTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                properties.Input = new GetUserTablesSqlTaskInput();
                properties.Input.ConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.ConnectionInfo.UserName = cred.UserName;
                properties.Input.ConnectionInfo.Password = Decrypt(cred.Password);
                properties.Input.SelectedDatabases = ((string[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
