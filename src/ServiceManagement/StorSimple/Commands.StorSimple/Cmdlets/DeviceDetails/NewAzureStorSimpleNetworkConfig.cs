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
using Hyak.Common;
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
        /// Whether the net interface is iscsi enabled/disabled
        /// </summary>
        [Parameter(Mandatory=false, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.IsIscsiEnabled)]
        [ValidateNotNullOrEmpty]
        public bool? EnableIscsi { get; set; }

        /// <summary>
        /// Whether the net interface is cloud enabled/disabled
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.IsCloudEnabled)]
        [ValidateNotNullOrEmpty]
        public bool? EnableCloud { get; set; }
        
        /// <summary>
        /// IPv4Address for controller 0, should be used only with Data0 interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.Controller0IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string Controller0IPv4Address { get; set; }
        
        /// <summary>
        /// IPv4Address for controller 1, should be used only with Data0 interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.Controller1IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string Controller1IPv4Address { get; set; }

        /// <summary>
        /// IPv4 net mask for interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.IPv6Gateway)]
        [ValidateNotNullOrEmpty]
        public string IPv6Gateway { get; set; }

        /// <summary>
        /// IPv4 Address of gateway
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Gateway)]
        [ValidateNotNullOrEmpty]
        public string IPv4Gateway { get; set; }

        /// <summary>
        /// IPv4 Address for the net interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Address)]
        [ValidateNotNullOrEmpty]
        public string IPv4Address { get; set; }

        /// <summary>
        /// IPv6 Prefix for the net interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, HelpMessage = StorSimpleCmdletHelpMessage.IPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public string IPv6Prefix { get; set; }
                
        /// <summary>
        /// IPv4 netmask for this interface
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, HelpMessage = StorSimpleCmdletHelpMessage.IPv4Netmask)]
        [ValidateNotNullOrEmpty]
        public string IPv4Netmask { get; set; }

        /// <summary>
        /// Interface alias of interface for which settings are being supplied. A value 
        /// from Data0 to Data5
        /// </summary>
        [Parameter(Mandatory = true, Position = 9, HelpMessage = StorSimpleCmdletHelpMessage.InterfaceAlias)]
        [ValidateSetAttribute(new string[] { "Data0", "Data1", "Data2", "Data3", "Data4", "Data5" })]
        public string InterfaceAlias { get; set; }
        #endregion

        private IPAddress controller0Address;
        private IPAddress controller1Address;
        private IPAddress ipv4Address;
        private IPAddress ipv4Gateway;
        private IPAddress ipv4Netmask;
        private IPAddress ipv6Gateway;

        public override void ExecuteCmdlet()
        {
            if (!ProcessParameters())
            {
                return;
            }
            try
            {
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
                    InterfaceAlias = (NetInterfaceId)Enum.Parse(typeof(NetInterfaceId), InterfaceAlias)
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

        private bool ProcessParameters(){
            if (!TrySetIPv4Address(Controller0IPv4Address, out controller0Address, "Controller0IPv4Address"))
            {
                return false;
            }
            if (!TrySetIPv4Address(Controller1IPv4Address, out controller1Address, "Controller1IPv4Address"))
            {
                return false;
            }
            if (!TrySetIPv4Address(IPv4Address, out ipv4Address, "IPv4Address"))
            {
                return false;
            }
            if (!TrySetIPv4Address(IPv4Gateway, out ipv4Gateway, "IPv4Gateway"))
            {
                return false;
            }
            if (!TrySetIPv4Address(IPv4Netmask, out ipv4Netmask, "IPv4Netmask"))
            {
                return false;
            }
            if(!TrySetIPv4Address(IPv6Gateway, out ipv6Gateway, "IPv6Gateway"))
            {
                return false;
            }

            // Only EnableCloud, Controller0 and controller1 IP Addresses can be set on Data0
            if (InterfaceAlias == NetInterfaceId.Data0.ToString())
            {
                if(IPv4Address != null && IPv4Gateway != null && IPv4Netmask != null
                    && IPv6Gateway != null && IPv6Prefix != null && EnableCloud != null)
                {
                    WriteVerbose(Resources.NetworkConfigData0AllowedSettings);
                    WriteObject(null);
                    return false;
                }
            }
            // On other interfaces, Controller0 and Controller1 IP Addresses cannot be set
            else
            {
                if (Controller0IPv4Address != null && Controller1IPv4Address != null)
                {
                    WriteVerbose(Resources.NetworkConfigControllerIPsNotAllowedOnOthers);
                    WriteObject(null);
                    return false;
                }
            }

            // Controller0 and Controller1 IP Address cant be set on non Data0 interfaces

            return true;
        }

        /// <summary>
        /// Try to parse an IP Address from the provided string
        /// </summary>
        /// <param name="data">IP Address string</param>
        /// <param name="ipAddress"></param>
        /// <param name="paramName">Name of the param which is being processed (to be used for errors)</param>
        private bool TrySetIPv4Address(string data, out IPAddress ipAddress, string paramName){
            if(data == null){
                ipAddress = null;
                return true;
            }
            try{
                ipAddress = IPAddress.Parse(data);
                return true;
            }
            catch(FormatException){
                ipAddress = null;
                WriteVerbose(string.Format(Resources.InvalidIPAddressProvidedMessage,paramName));
                WriteObject(null);
                return false;
            }
        }
    }
}

