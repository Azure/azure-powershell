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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.New, "WAPackVMRole", DefaultParameterSetName = WAPackCmdletParameterSets.QuickCreate)]
    public class NewWAPackVMRole : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.QuickCreate, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Name.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.QuickCreate, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Label.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole Label.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.QuickCreate, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole ResourceDefinition.")]
        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole ResourceDefinition.")]
        [ValidateNotNullOrEmpty]
        public VMRoleResourceDefinition ResourceDefinition
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromCloudService, ValueFromPipelineByPropertyName = true, HelpMessage = "VMRole CloudService.")]
        [ValidateNotNullOrEmpty]
        public Utilities.WAPackIaaS.DataContract.CloudService CloudService
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            Guid? vmRolejobId = Guid.Empty;
            VMRole createdVmRole = null;
            IEnumerable<VMRole> results = null;

            var vmRoleOperations = new VMRoleOperations(this.WebClientFactory);
            var newVMRole = new VMRole()
            {
                Name = this.Name,
                Label = this.Label,
                ResourceDefinition = this.ResourceDefinition,
                InstanceView = null,
                ResourceConfiguration = null,
                ProvisioningState = null,
                Substate = null,
            };

            if (this.ParameterSetName == WAPackCmdletParameterSets.QuickCreate)
            {
                var cloudService = new Utilities.WAPackIaaS.DataContract.CloudService()
                {
                    Name = this.Name,
                    Label = this.Label
                };

                Guid? cloudServiceJobId = Guid.Empty;
                var cloudServiceOperations = new CloudServiceOperations(this.WebClientFactory);
                cloudServiceOperations.Create(cloudService, out cloudServiceJobId);
                WaitForJobCompletion(cloudServiceJobId);

                try
                {
                    createdVmRole = vmRoleOperations.Create(this.Name, newVMRole, out vmRolejobId);
                    WaitForJobCompletion(vmRolejobId);

                    var vmRole = vmRoleOperations.Read(this.Name, this.Name);
                    results = new List<VMRole>() { vmRole };
                }
                catch (Exception)
                {
                    cloudServiceOperations.Delete(this.Name, out cloudServiceJobId);
                    WaitForJobCompletion(cloudServiceJobId);
                    throw;
                }
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromCloudService)
            {
                createdVmRole = vmRoleOperations.Create(this.CloudService.Name, newVMRole, out vmRolejobId);
                WaitForJobCompletion(vmRolejobId);

                var vmRole = vmRoleOperations.Read(this.CloudService.Name, this.Name);
                results = new List<VMRole>() { vmRole };
            }

            this.GenerateCmdletOutput(results);
        }
    }
}
