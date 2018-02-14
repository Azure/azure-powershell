// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlConnectionInfoCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

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
            this.SimpleParam(authType, typeof(AuthenticationType), "Authentication type to be used for Sql Connection", true);
            this.SimpleParam(encryptConnection, typeof(SwitchParameter), "Gets or sets whether to encrypt the connection, Default Value True");
            this.SimpleParam(trustServerCertificate, typeof(SwitchParameter), "Gets or sets whether to trust the server certificate");
            this.SimpleParam(additionalSettings, typeof(string), "Gets or sets additional connection settings");
        }

        public override ConnectionInfo ProcessConnectionInfoCmdlet()
        {
            SqlConnectionInfo connectionInfo = new SqlConnectionInfo();
            connectionInfo.DataSource = MyInvocation.BoundParameters[dataSource] as string;
            connectionInfo.Authentication = (AuthenticationType)MyInvocation.BoundParameters[authType];

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
