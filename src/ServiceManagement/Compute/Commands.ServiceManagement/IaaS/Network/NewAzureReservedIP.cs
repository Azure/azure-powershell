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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.New, ReservedIPConstants.CmdletNoun, DefaultParameterSetName = ReserveNewIPParamSet), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureReservedIPCmdlet : ServiceManagementBaseCmdlet
    {
        protected const string ReserveNewIPParamSet = "CreateNewReservedIP";
        protected const string ReserveInUseIPUsingSlotParamSet = "CreateInUseReservedIPUsingSlot";
        protected const string ReserveInUseIPParamSet = "CreateInUseReservedIP";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveNewIPParamSet, HelpMessage = "Reserved IP Name.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPUsingSlotParamSet, HelpMessage = "Reserved IP Name.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPParamSet, HelpMessage = "Reserved IP Name.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveNewIPParamSet, HelpMessage = "Reserved IP Label.")]
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPUsingSlotParamSet, HelpMessage = "Reserved IP Label.")]
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPParamSet, HelpMessage = "Reserved IP Label.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveNewIPParamSet, HelpMessage = "Location Name.")]
        [Parameter(Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPUsingSlotParamSet, HelpMessage = "Location Name.")]
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ReserveInUseIPParamSet, HelpMessage = "Location Name.")]
        [ValidateNotNullOrEmpty]
        public string Location
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    var parameters = new NetworkReservedIPCreateParameters
                    {
                        Name           = this.ReservedIPName,
                        Label          = this.Label,
                        Location       = this.Location
                    };

                    return this.NetworkClient.ReservedIPs.Create(parameters);
                });
        }
    }
}
