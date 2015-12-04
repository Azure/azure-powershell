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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppVNet"), OutputType(typeof(VNetResult))]
    public class GetAzureRemoteAppVNet : VNetDeprecated
    {
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "RemoteApp virtual network name. Wildcards are permitted.")]
        [ValidatePattern(VNetNameValidatorStringWithWildCards)]
        public string VNetName { get; set; }

        [Parameter(Mandatory = false,
                Position = 1,
                HelpMessage = "Specify to include the shared VPN key in the output.")]
        public SwitchParameter IncludeSharedKey { get; set; }

        private bool GetVNet(string VNet)
        {
            VNetResult response = null;
            bool found = false;

            WriteVerboseWithTimestamp("Getting the VNet.");

            response = CallClient(() => Client.VNet.Get(VNet, IncludeSharedKey), Client.VNet);
            if (response != null)
            {
                WriteObject(response.VNet);
                found = true;
            }
            return found;
        }

        private bool GetVNetList(bool showAllVirtualNetworks, string VNet)
        {
            VNetListResult response = null;
            bool found = false;

            if (showAllVirtualNetworks)
            {
                WriteVerboseWithTimestamp("Getting all VNets.");
            }
            else if (UseWildcard)
            {
                WriteVerboseWithTimestamp("Getting the matching VNets for {0}.", VNet);
            }

            response = CallClient(() => Client.VNet.List(), Client.VNet);
            if (response != null)
            {
                foreach (VNet vNet in response.VNetList)
                {
                    if (showAllVirtualNetworks || (UseWildcard && Wildcard.IsMatch(vNet.Name)))
                    {
                        WriteObject(vNet);
                        found = true;
                    }
                }
            }
            return found;
        }

        public override void ExecuteCmdlet()
        {
            bool showAllVirtualNetworks = String.IsNullOrWhiteSpace(VNetName);
            bool found = false;

            if (showAllVirtualNetworks == false)
            {
                CreateWildcardPattern(VNetName);
            }

            if (ExactMatch)
            {
                found = GetVNet(VNetName);
                if (!found)
                {
                    WriteErrorWithTimestamp("No VNet found matching: " + VNetName);
                }
            }
            else
            {
                if (IncludeSharedKey)
                {
                    ErrorRecord er = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                         "You must specify an existing unique virtual network name in order to get the shared VPN key.",
                                            String.Empty,
                                            Client.VNet,
                                            ErrorCategory.InvalidOperation
                    );
                    WriteError(er);
                }
                else
                {
                    found = GetVNetList(showAllVirtualNetworks, VNetName);
                }
            }

            if (!found)
            {
                WriteVerboseWithTimestamp(String.Format("Virtual network name: {0} not found.", VNetName));
            }
        }
    }
}


