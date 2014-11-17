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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Service.Gateway;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Get, "AzureVNetGateway"), OutputType(typeof(VirtualNetworkGatewayContext))]
    public class GetAzureVNetGatewayCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Virtual network name.")]
        public string VNetName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            this.ExecuteClientActionNewSM(
                null,
                this.CommandRuntime.ToString(),
                () => this.NetworkClient.Gateways.Get(this.VNetName),
                (operation, operationResponse) => new VirtualNetworkGatewayContext
                {
                    OperationId          = operation.Id,
                    OperationStatus      = operation.Status.ToString(),
                    OperationDescription = this.CommandRuntime.ToString(),
                    LastEventData        = (operationResponse.LastEvent != null) ? operationResponse.LastEvent.Data : null,
                    LastEventMessage     = (operationResponse.LastEvent != null) ? operationResponse.LastEvent.Message : null,
                    LastEventID          = GetEventId(operationResponse.LastEvent),
                    LastEventTimeStamp   = (operationResponse.LastEvent != null) ? (DateTime?)operationResponse.LastEvent.Timestamp : null,
                    State                = (ProvisioningState)Enum.Parse(typeof(ProvisioningState), operationResponse.State, true),
                    VIPAddress           = operationResponse.VipAddress != null ? operationResponse.VipAddress.ToString() : null
                });
        }

        private int GetEventId(Management.Network.Models.GatewayEvent gatewayEvent)
        {
            int val = -1;
            if (gatewayEvent != null)
            {
                int.TryParse(gatewayEvent.Id, out val);
            }

            return val;
        }
    }
}