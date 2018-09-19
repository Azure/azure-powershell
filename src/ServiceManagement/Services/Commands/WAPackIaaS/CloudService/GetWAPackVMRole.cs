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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.Get, "WAPackVMRole", DefaultParameterSetName = WAPackCmdletParameterSets.Empty)]
    public class GetWAPackVMRole : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Name.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole CloudService Name.")]
        [ValidateNotNullOrEmpty]
        public string CloudServiceName
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<VMRole> results = null;
            var vmRoleOperations = new VMRoleOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                var vmRole = vmRoleOperations.Read(this.Name, this.Name);
                results = new List<VMRole>() { vmRole };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromCloudService)
            {
                var vmRole = vmRoleOperations.Read(this.CloudServiceName, this.Name);
                results = new List<VMRole>() { vmRole };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.Empty)
            {
                IEnumerable<Utilities.WAPackIaaS.DataContract.CloudService> cloudServiceResults = null;
                var vmRoles = new List<VMRole>();

                var cloudServiceOperations = new CloudServiceOperations(this.WebClientFactory);
                cloudServiceResults = cloudServiceOperations.Read();

                foreach (var cloudService in cloudServiceResults)
                {
                    vmRoles.AddRange(vmRoleOperations.Read(cloudService.Name));
                }
                results = vmRoles;
            }

            this.GenerateCmdletOutput(results);
        }
    }
}