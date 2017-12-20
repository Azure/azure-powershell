// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectToSourceSqlServerTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToSourceSqlServerTaskCmdlet : TaskCmdlet
    {
        public ConnectToSourceSqlServerTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToSourceSqlServerTaskProperties properties = new ConnectToSourceSqlServerTaskProperties();

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
