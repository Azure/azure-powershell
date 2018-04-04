// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectToTargetSqlDbMiTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToTargetSqlDbMiTaskCmdlet : TaskCmdlet
    {
        public ConnectToTargetSqlDbMiTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToTargetSqlMITaskProperties properties = new ConnectToTargetSqlMITaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                var targetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);
                properties.Input = new ConnectToTargetSqlMITaskInput
                {
                    TargetConnectionInfo = targetConnectionInfo
                };
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}