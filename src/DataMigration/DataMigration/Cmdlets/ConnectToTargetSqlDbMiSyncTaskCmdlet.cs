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
