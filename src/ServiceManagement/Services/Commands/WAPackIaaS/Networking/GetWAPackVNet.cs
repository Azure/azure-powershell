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

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.Get, "WAPackVNet", DefaultParameterSetName = WAPackCmdletParameterSets.Empty)]
    public class GetWAPackVNet : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromId, ValueFromPipelineByPropertyName = true, HelpMessage = "VNet ID.")]
        [ValidateNotNullOrEmpty]
        public Guid ID
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipelineByPropertyName = true, HelpMessage = "VNet Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<VMNetwork> results = null;
            var vmNetworkOperations = new VMNetworkOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.Empty)
            {
                results = vmNetworkOperations.Read();
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromId)
            {
                var vmNetwork = vmNetworkOperations.Read(ID);
                results = new List<VMNetwork>() { vmNetwork };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                var filter = new Dictionary<string, string>()
                {
                    {"Name", Name}
                };
                results = vmNetworkOperations.Read(filter);
            }

            this.GenerateCmdletOutput(results);
        }
    }
}
