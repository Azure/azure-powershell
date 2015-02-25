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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppResetVpnSharedKey"), OutputType(typeof(VNetOperationStatus))]
    public class GetAzureRemoteAppResetVpnSharedKeyOperation : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Tracking Id returned by ResetVpnSharedKey.")]
        public string TrackingId { get; set; }

        public override void ExecuteCmdlet()
        {
            VNetOperationStatusResult response = CallClient(() => Client.VNet.GetResetVpnSharedKeyOperationStatus(TrackingId), Client.VNet);
            if (response != null)
            {
                WriteObject(response.Status);
            }
        }
    }
}
