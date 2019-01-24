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
using Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class MongoDbConnectionInfoCmdlet : ConnectionInfoCmdlet
    {
        private readonly string connectionString = "connectionString";
        private readonly string server = "serverName";
        private readonly string port = "port";
        private readonly string useSSL = "useSSL";

        public MongoDbConnectionInfoCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(connectionString, typeof(string), "MongoDb Connection string, ignored if server parameter is provided instead", false);
            this.SimpleParam(server, typeof(string), "MongoDb server name, if set it will overwrite connection string", false);
            this.SimpleParam(port, typeof(int), "MongoDb port number", false);
            this.SimpleParam(useSSL, typeof(SwitchParameter), "Whether to use SSL in the connection", false);
            this.SimpleParam(loginCredential, typeof(PSCredential), "Login credentials", false);
        }

        public override object ProcessConnectionInfoCmdlet()
        {
            var connectionInfo = new Models.MongoDbConnectionInfo();

            if (MyInvocation.BoundParameters.ContainsKey(connectionString))
            {
                connectionInfo.ConnectionString = MyInvocation.BoundParameters[connectionString] as string;
            }

            if (MyInvocation.BoundParameters.ContainsKey(server))
            {
                connectionInfo.ServerName = MyInvocation.BoundParameters[server] as string;
            }

            if (MyInvocation.BoundParameters.ContainsKey(port))
            {
                connectionInfo.Port = MyInvocation.BoundParameters[port] as int?;
            }

            if (MyInvocation.BoundParameters.ContainsKey(useSSL))
            {
                connectionInfo.UseSSL = (SwitchParameter)MyInvocation.BoundParameters[useSSL];
            }

            if (MyInvocation.BoundParameters.ContainsKey(loginCredential))
            {
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[loginCredential];
                connectionInfo.UserName = cred.UserName;
                connectionInfo.Password = Decrypt(cred.Password);
            }

            connectionInfo.ConstructConnectionString();

            return connectionInfo;
        }
    }
}
