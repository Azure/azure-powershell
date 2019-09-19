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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class MigrateSsisTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SsisMigrationInfo = "SsisMigrationInfo";

        public MigrateSsisTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SourceConnectionInfoParam(true);
            this.SimpleParam(SsisMigrationInfo, typeof(SsisMigrationInfo), "SSIS Migration Info");
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            SqlConnectionInfo targetConnectionInfo = null;
            SqlConnectionInfo sourceConnectionInfo = null;
            SsisMigrationInfo ssisMigrationInfo = null;

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                targetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                sourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                sourceConnectionInfo.UserName = cred.UserName;
                sourceConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SsisMigrationInfo))
            {
                ssisMigrationInfo = (SsisMigrationInfo)MyInvocation.BoundParameters[SsisMigrationInfo];
            }
            else
            {
                ssisMigrationInfo = new SsisMigrationInfo
                {
                    SsisStoreType = SsisStoreType.SsisCatalog,
                    ProjectOverwriteOption = SsisMigrationOverwriteOption.Ignore,
                    EnvironmentOverwriteOption = SsisMigrationOverwriteOption.Ignore
                };
            }

            var properties = new MigrateSsisTaskProperties
            {
                Input = new MigrateSsisTaskInput
                {
                    TargetConnectionInfo = targetConnectionInfo,
                    SourceConnectionInfo = sourceConnectionInfo,
                    SsisMigrationInfo = ssisMigrationInfo
                }
            };

            return properties;
        }
    }
}