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

using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Get, "AzureVNetConnection"), OutputType(typeof(GatewayConnectionContext))]
    public class GetAzureVNetConnectionCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Virtual network name.")]
        public string VNetName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ExecuteClientActionNewSM(
                null,
                this.CommandRuntime.ToString(),
                () => this.NetworkClient.Gateways.ListConnections(this.VNetName),
                (s, r) => r.Connections.Select(c => new GatewayConnectionContext
                {
                    OperationId               = s.Id,
                    OperationDescription      = this.CommandRuntime.ToString(),
                    OperationStatus           = s.Status.ToString(),
                    ConnectivityState         = c.ConnectivityState.ToString(),
                    EgressBytesTransferred    = (ulong)c.EgressBytesTransferred,
                    IngressBytesTransferred   = (ulong)c.IngressBytesTransferred,
                    LastConnectionEstablished = c.LastConnectionEstablished.ToString(),
                    LastEventID               = c.LastEvent != null ? c.LastEvent.Id.ToString() : null,
                    LastEventMessage          = c.LastEvent != null ? c.LastEvent.Message.ToString() : null,
                    LastEventTimeStamp        = c.LastEvent != null ? c.LastEvent.Timestamp.ToString() : null,
                    LocalNetworkSiteName      = c.LocalNetworkSiteName
                }));
        }
    }
}