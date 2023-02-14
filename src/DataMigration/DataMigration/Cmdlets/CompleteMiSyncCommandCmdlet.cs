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

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class CompleteMiSyncCommandCmdlet : CommandCmdlet
    {
        private readonly string DatabaseName = "DatabaseName";

        public CompleteMiSyncCommandCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(DatabaseName, typeof(string), "Gets or sets name of database", true);
        }

        public override CommandProperties ProcessCommandCmdlet()
        {
            MigrateMISyncCompleteCommandProperties properties = new MigrateMISyncCompleteCommandProperties();

            if (MyInvocation.BoundParameters.ContainsKey(DatabaseName))
            {
                properties.Input = new MigrateMISyncCompleteCommandInput();
                properties.Input.SourceDatabaseName = MyInvocation.BoundParameters[DatabaseName] as string;
            }

            return properties;
        }
    }
}
