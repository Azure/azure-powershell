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
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using System.Net;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Create Network config object to be used for Setting and Updating DeviceDetails
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleNetworkConfig"),
     OutputType(typeof (NetworkConfig))]

    public class NewAzureStorSimpleNetworkConfig : StorSimpleCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Interface alias of interface for which settings are being supplied. A value 
        /// from Data0 to Data5
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.InterfaceAlias)]
        [ValidateSetAttribute(new string[] { "Data0", "Data1", "Data2", "Data3", "Data4", "Data5" })]
        public string InterfaceAlias { get; set; }

        /// <summary>
        /// Whether the net interface is iscsi enabled/disabled
        /// </summary>
        [Parameter(Mandatory=false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.IsIscsiEnabled)]
        [ValidateNotNullOrEmpty]
        public bool? EnableIscsi { get; set; }

        /// <summary>
        /// Whether the net interface is cloud enabled/disabled
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.IsCloudEnabled)]
        [ValidateNotNullOrEmpty]
        public bool? EnableCloud { get; set; }
        
        /// <summary>
        /// IPv4Address for controller 0, should be used only with Data0 interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.Controller0IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string Controller0IPv4Address { get; set; }
        
        /// <summary>
        /// IPv4Address for controller 1, should be used only with Data0 interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.Controller1IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string Controller1IPv4Address { get; set; }

        /// <summary>
        /// IPv4 net mask for interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.IPv6Gateway)]
        [ValidateNotNullOrEmpty]
        public string IPv6Gateway { get; set; }

        /// <summary>
        /// IPv4 Address of gateway
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Gateway)]
        [ValidateNotNullOrEmpty]
        public string IPv4Gateway { get; set; }

        /// <summary>
        /// IPv4 Address for the net interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string IPv4Address { get; set; }

        /// <summary>
        /// IPv6 Prefix for the net interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, HelpMessage = StorSimpleCmdletHelpMessage.IPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public string IPv6Prefix { get; set; }
                
        /// <summary>
        /// IPv4 netmask for this interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Netmask)]
        [ValidateNotNullOrEmpty]
        public string IPv4Netmask { get; set; }

        #endregion

        private IPAddress controller0Address;
        private IPAddress controller1Address;
        private IPAddress ipv4Address;
        private IPAddress ipv4Gateway;
        private IPAddress ipv4Netmask;
        private IPAddress ipv6Gateway;
        NetInterfaceId interfaceAlias;

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                var netConfig = new NetworkConfig
                {
                    IsIscsiEnabled = EnableIscsi,
                    IsCloudEnabled = EnableCloud,
                    Controller0IPv4Address = controller0Address,
                    Controller1IPv4Address = controller1Address,
                    IPv6Gateway = ipv6Gateway,
                    IPv4Gateway = ipv4Gateway,
                    IPv4Address = ipv4Address,
                    IPv6Prefix = IPv6Prefix,
                    IPv4Netmask = ipv4Netmask,
                    InterfaceAlias = interfaceAlias
                };

                WriteObject(netConfig);
                WriteVerbose(string.Format(Resources.NewNetworkConfigCreated,InterfaceAlias.ToString()));
                return;
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        private void ProcessParameters(){
            // parse interfaceAlias
            if (!Enum.TryParse<NetInterfaceId>(InterfaceAlias, out interfaceAlias))
            {
                throw new ArgumentException(string.Format(Resources.InvalidInterfaceId, InterfaceAlias));
            }

            // Try and set all the IP address
            TrySetIPAddress(Controller0IPv4Address, out controller0Address, "Controller0IPv4Address");
            TrySetIPAddress(Controller1IPv4Address, out controller1Address, "Controller1IPv4Address");
            TrySetIPAddress(IPv4Address, out ipv4Address, "IPv4Address");
            TrySetIPAddress(IPv4Gateway, out ipv4Gateway, "IPv4Gateway");
            TrySetIPAddress(IPv4Netmask, out ipv4Netmask, "IPv4Netmask");
            TrySetIPAddress(IPv6Gateway, out ipv6Gateway, "IPv6Gateway");

            // Only EnableIscsi, Controller0 and controller1 IP Addresses can be set on Data0
            if (InterfaceAlias == NetInterfaceId.Data0.ToString())
            {
                if(IPv4Address != null || IPv4Gateway != null || IPv4Netmask != null
                    && IPv6Gateway != null || IPv6Prefix != null || EnableCloud != null)
                {
                    throw new ArgumentException(Resources.NetworkConfigData0AllowedSettings);
                }
            }
            // On other interfaces (non-Data0), Controller0 and Controller1 IP Addresses cannot be set
            else
            {
                if (Controller0IPv4Address != null || Controller1IPv4Address != null)
                {
                    throw new ArgumentException(Resources.NetworkConfigControllerIPsNotAllowedOnOthers);
                }
            }
        }
    }
}

