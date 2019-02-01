// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectToTargetSqlDbMiSyncTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ConnectToTargetSqlDbMiSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string AadApp = "AzureActiveDirectoryApp";

        public ConnectToTargetSqlDbMiSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(AadApp, typeof(PSAzureActiveDirectoryApp), "Azure Active Directory App", true, false);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            ConnectToTargetSqlMISyncTaskProperties properties = new ConnectToTargetSqlMISyncTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                var targetConnectionInfo = (MiSqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);

                PSAzureActiveDirectoryApp aadAp = (PSAzureActiveDirectoryApp)MyInvocation.BoundParameters[AadApp];

                AzureActiveDirectoryApp app = new AzureActiveDirectoryApp
                {
                    ApplicationId = aadAp.ApplicationId,
                    AppKey = Decrypt(aadAp.AppKey),
                    TenantId = aadAp.TenantId
                };

                properties.Input = new ConnectToTargetSqlMISyncTaskInput
                {
                    TargetConnectionInfo = targetConnectionInfo,
                    AzureApp = app
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
