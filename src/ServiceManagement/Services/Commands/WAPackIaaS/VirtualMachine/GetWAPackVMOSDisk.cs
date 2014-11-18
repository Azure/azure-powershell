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
    [Cmdlet(VerbsCommon.Get, "WAPackVMOSDisk", DefaultParameterSetName = WAPackCmdletParameterSets.Empty)]
    public class GetWAPackVMOSDisk : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromId, ValueFromPipelineByPropertyName = true, HelpMessage = "OSDisk ID.")]
        [ValidateNotNullOrEmpty]
        public Guid ID
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipelineByPropertyName = true, HelpMessage = "OSDisk Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<VirtualHardDisk> results = null;
            var virtualHardDiskOperations = new VirtualHardDiskOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.Empty)
            {
                results = virtualHardDiskOperations.Read();
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromId)
            {
                VirtualHardDisk virtualHardDisk = null;
                virtualHardDisk = virtualHardDiskOperations.Read(ID);
                results = new List<VirtualHardDisk>() { virtualHardDisk };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                results = virtualHardDiskOperations.Read(new Dictionary<string, string>()
                {
                    {"Name", Name}
                });
            }

            this.GenerateCmdletOutput(results);
        }
    }
}
