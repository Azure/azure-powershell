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

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    [Cmdlet(VerbsCommon.Get, "WAPackCloudVMRoleSizeProfile", DefaultParameterSetName = WAPackCmdletParameterSets.Empty)]
    public class GetWAPackClodVMRoleSizeProfile : IaaSCmdletBase
    {
        
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipelineByPropertyName = true, HelpMessage = "CloudVMRoleSizeProfile Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<VMRoleSizeProfile> results = null;
            var VMRoleSizeProfileOperations = new VMRoleSizeProfileOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.Empty)
            {
                results = VMRoleSizeProfileOperations.Read();
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                results = VMRoleSizeProfileOperations.Read(new Dictionary<string, string>()
                {
                    {"Name", Name}
                });
            }

            this.GenerateCmdletOutput(results);
        }
    }
}