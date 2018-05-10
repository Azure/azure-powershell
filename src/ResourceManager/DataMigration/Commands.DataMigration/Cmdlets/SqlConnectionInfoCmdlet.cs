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
    public class SqlConnectionInfoCmdlet : ConnectionInfoCmdlet
    {
        private readonly string dataSource = "DataSource";
        private readonly string authType = "AuthType";
        private readonly string encryptConnection = "EncryptConnection";
        private readonly string trustServerCertificate = "TrustServerCertificate";
        private readonly string additionalSettings = "AdditionalSettings";

        public SqlConnectionInfoCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(dataSource, typeof(string), "Gets or sets data source in the format Protocol:MachineName\\SQLServerInstanceName,PortNumber", true);
            this.SimpleParam(authType, typeof(string), "Authentication type to be used for Sql Connection", true,
                "None", "WindowsAuthentication", "SqlAuthentication", "ActiveDirectoryIntegrated", "ActiveDirectoryPassword");
            this.SimpleParam(encryptConnection, typeof(SwitchParameter), "Gets or sets whether to encrypt the connection, Default Value True");
            this.SimpleParam(trustServerCertificate, typeof(SwitchParameter), "Gets or sets whether to trust the server certificate");
            this.SimpleParam(additionalSettings, typeof(string), "Gets or sets additional connection settings");
        }

        public override ConnectionInfo ProcessConnectionInfoCmdlet()
        {
            SqlConnectionInfo connectionInfo = new SqlConnectionInfo
            {
                DataSource = MyInvocation.BoundParameters[dataSource] as string,
                Authentication = MyInvocation.BoundParameters[authType] as string
            };

            if (MyInvocation.BoundParameters.ContainsKey(additionalSettings))
            {
                connectionInfo.AdditionalSettings = MyInvocation.BoundParameters[additionalSettings] as string;
            }

            // Set default value to true
            connectionInfo.EncryptConnection = true;
            if (MyInvocation.BoundParameters.ContainsKey(encryptConnection))
            {
                connectionInfo.EncryptConnection = (SwitchParameter)MyInvocation.BoundParameters[encryptConnection];
            }

            if (MyInvocation.BoundParameters.ContainsKey(trustServerCertificate))
            {
                connectionInfo.TrustServerCertificate = (SwitchParameter)MyInvocation.BoundParameters[trustServerCertificate];
            }

            return connectionInfo;
        }
    }
}
