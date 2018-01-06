// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectToTargetSqlDbTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
    public class ConnectToTargetSqlDbTaskCmdlet : TaskCmdlet
    {
        public ConnectToTargetSqlDbTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToTargetSqlDbTaskProperties properties = new ConnectToTargetSqlDbTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                properties.Input = new ConnectToTargetSqlDbTaskInput();
                properties.Input.TargetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                properties.Input.TargetConnectionInfo.UserName = cred.UserName;
                properties.Input.TargetConnectionInfo.Password = Decrypt(cred.Password);
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
