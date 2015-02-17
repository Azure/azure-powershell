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
using Microsoft.WindowsAzure.Commands.Common;
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
        /// IPv4Address for controller 0, should be used only with Data0 interface
        /// </summary>
        [Parameter(Position = 2, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageController0IPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress Controller0IPv4Address { get; set; }
        
        /// <summary>
        /// IPv4Address for controller 1, should be used only with Data0 interface
        /// </summary>
        [Parameter(Position = 3, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageController1IPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress Controller1IPv4Address { get; set; }
        
        /// <summary>
        /// Interface alias of interface for which settings are being supplied. A value 
        /// from Data0 to Data5
        /// </summary>
        [Parameter(Mandatory=true, Position = 9, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageInterfaceAlias)]
        [ValidateSetAttribute(new string[] { "Data0", "Data1", "Data2", "Data3", "Data4", "Data5" })] 
        public string InterfaceAlias { get; set; }

        /// <summary>
        /// IPv4 Address for the net interface
        /// </summary>
        [Parameter(Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress IPv4Address { get; set; }
        
        /// <summary>
        /// IPv4 Address of gateway
        /// </summary>
        [Parameter(Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Gateway)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress IPv4Gateway { get; set; }
        
        /// <summary>
        /// IPv4 netmask for this interface
        /// </summary>
        [Parameter(Position = 8, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Netmask)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress IPv4Netmask { get; set; }
        
        /// <summary>
        /// IPv4 net mask for interface
        /// </summary>
        [Parameter(Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv6Gateway)]
        [ValidateNotNullOrEmptyAttribute]
        public IPAddress IPv6Gateway { get; set; }
        
        /// <summary>
        /// IPv6 Prefix for the net interface
        /// </summary>
        [Parameter(Position = 7, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv6Prefix)]
        [ValidateNotNullOrEmptyAttribute]
        public string IPv6Prefix { get; set; }
        
        /// <summary>
        /// Whether the net interface is cloud enabled/disabled
        /// </summary>
        [Parameter(Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIsCloudEnabled)]
        [ValidateNotNullOrEmptyAttribute]
        public bool? IsCloudEnabled { get; set; }
        
        /// <summary>
        /// Whether the net interface is iscsi enabled/disabled
        /// </summary>
        [Parameter(Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIsIscsiEnabled)]
        [ValidateNotNullOrEmptyAttribute]
        public bool? IsIscsiEnabled { get; set; }
                
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                var netConfig = new NetworkConfig
                {
                    IsIscsiEnabled = IsIscsiEnabled,
                    IsCloudEnabled = IsCloudEnabled,
                    Controller0IPv4Address = Controller0IPv4Address,
                    Controller1IPv4Address = Controller1IPv4Address,
                    IPv6Gateway = IPv6Gateway,
                    IPv4Gateway = IPv4Gateway,
                    IPv4Address = IPv4Address,
                    IPv6Prefix = IPv6Prefix,
                    IPv4Netmask = IPv4Netmask,
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
    }
}

