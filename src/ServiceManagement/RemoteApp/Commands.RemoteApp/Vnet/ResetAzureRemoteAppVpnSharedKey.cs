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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Reset, "AzureRemoteAppVpnSharedKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High), OutputType(typeof(VNet))]
    public class ResetAzureRemoteAppVpnSharedKey : VNetDeprecated
    {
        [Parameter(Mandatory = true,
           Position = 0,
           ValueFromPipeline = true,
           HelpMessage = "RemoteApp virtual network name.")]
        [ValidatePattern(VNetNameValidatorString)]
        public string VNetName { get; set; }

        public override void ExecuteCmdlet()
        {
            OperationResultWithTrackingId response = null;
            string description = String.Format(Commands_RemoteApp.VnetSharedKeyResetConfirmationDescriptionFormat, VNetName);
            string warning = Commands_RemoteApp.GenericAreYouSureQuestion;
            string caption = Commands_RemoteApp.VnetSharedKeyResetCaptionMessage;

            if (ShouldProcess(description, warning, caption))
            {
                response = CallClient(() => Client.VNet.ResetVpnSharedKey(VNetName), Client.VNet);
            }

            if (response != null)
            {
                VNetOperationStatusResult operationStatus = null;
                int maxRetries = 600; // 5 minutes?
                // wait for the reset key operation to succeed to get the new key
                do
                {
                    System.Threading.Thread.Sleep(5000); //wait a while before the next check
                    operationStatus = CallClient(() => Client.VNet.GetResetVpnSharedKeyOperationStatus(response.TrackingId), Client.VNet);

                }
                while (operationStatus.Status != VNetOperationStatus.Failed &&
                    operationStatus.Status != VNetOperationStatus.Success &&
                    --maxRetries > 0);

                if (operationStatus.Status == VNetOperationStatus.Success)
                {
                    VNetResult vnet = CallClient(() => Client.VNet.Get(VNetName, true), Client.VNet);
                    WriteObject(vnet.VNet);
                    WriteVerboseWithTimestamp(Commands_RemoteApp.RequestSuccessful);
                }
                else
                {
                    if (maxRetries > 0)
                    {
                        WriteErrorWithTimestamp(Commands_RemoteApp.RequestFailed);
                    }
                    else
                    {
                        WriteErrorWithTimestamp(Commands_RemoteApp.VNetTimeout);
                    }
                }
            }
        }

    }
}
