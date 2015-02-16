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
        /// The following is the definition of the input parameter "Controller0IPv4Address".       
        /// IPv4Address for controller 0, should be used only with Data0 interface
        /// </summary>
        [Parameter(Position = 2, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageController0IPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress Controller0IPv4Address
        {
            get { return this.controller0ipv4address; }
            set { this.controller0ipv4address = value; }
        }
        private System.Net.IPAddress controller0ipv4address;

        /// <summary>
        /// The following is the definition of the input parameter "Controller1IPv4Address".       
        /// IPv4Address for controller 1, should be used only with Data0 interface
        /// </summary>
        [Parameter(Position = 3, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageController1IPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress Controller1IPv4Address
        {
            get { return this.controller1ipv4address; }
            set { this.controller1ipv4address = value; }
        }
        private System.Net.IPAddress controller1ipv4address;

        /// <summary>
        /// The following is the definition of the input parameter "InterfaceAlias".       
        /// Interface alias of interface for which settings are being supplied. A value 
        /// from Data0 to Data5
        /// </summary>
        [Parameter(Mandatory=true, Position = 9, HelpMessage=StorSimpleCmdletHelpMessage.HelpMessageInterfaceAlias)]
        [ValidateSetAttribute(new string[] { "Data0", "Data1", "Data2", "Data3", "Data4", "Data5" })]
        public NetInterfaceId InterfaceAlias
        {
            get { return this.interfacealias; }
            set { this.interfacealias = value; }
        }
        private NetInterfaceId interfacealias;

        /// <summary>
        /// The following is the definition of the input parameter "IPv4Address".       
        /// IPv4 Address for the net interface
        /// </summary>
        [Parameter(Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Address)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress IPv4Address
        {
            get { return this.ipv4address; }
            set { this.ipv4address = value; }
        }
        private System.Net.IPAddress ipv4address;

        /// <summary>
        /// The following is the definition of the input parameter "IPv4Gateway".       
        /// IPv4 Address of gateway
        /// </summary>
        [Parameter(Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Gateway)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress IPv4Gateway
        {
            get { return this.ipv4gateway; }
            set { this.ipv4gateway = value; }
        }
        private System.Net.IPAddress ipv4gateway;

        /// <summary>
        /// The following is the definition of the input parameter "IPv4Netmask".       
        /// IPv4 netmask for this interface
        /// </summary>
        [Parameter(Position = 8, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv4Netmask)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress IPv4Netmask
        {
            get { return this.ipv4netmask; }
            set { this.ipv4netmask = value; }
        }
        private System.Net.IPAddress ipv4netmask;

        /// <summary>
        /// The following is the definition of the input parameter "IPv6Gateway".       
        /// IPv4 net mask for interface
        /// </summary>
        [Parameter(Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv6Gateway)]
        [ValidateNotNullOrEmptyAttribute]
        public System.Net.IPAddress IPv6Gateway
        {
            get { return this.ipv6gateway; }
            set { this.ipv6gateway = value; }
        }
        private System.Net.IPAddress ipv6gateway;

        /// <summary>
        /// The following is the definition of the input parameter "IPv6Prefix".       
        /// IPv6 Prefix for the net interface
        /// </summary>
        [Parameter(Position = 7, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIPv6Prefix)]
        [ValidateNotNullOrEmptyAttribute]
        public string IPv6Prefix
        {
            get { return this.ipv6prefix; }
            set { this.ipv6prefix = value; }
        }
        private string ipv6prefix;

        /// <summary>
        /// The following is the definition of the input parameter "IsCloudEnabled".       
        /// Whether the net interface is cloud enabled/disabled
        /// </summary>
        [Parameter(Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIsCloudEnabled)]
        [ValidateNotNullOrEmptyAttribute]
        public bool? IsCloudEnabled
        {
            get { return this.iscloudenabled; }
            set { this.iscloudenabled = value; }
        }
        private bool? iscloudenabled;

        /// <summary>
        /// The following is the definition of the input parameter "IsIscsiEnabled".       
        /// Whether the net interface is iscsi enabled/disabled
        /// </summary>
        [Parameter(Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageIsIscsiEnabled)]
        [ValidateNotNullOrEmptyAttribute]
        public bool? IsIscsiEnabled
        {
            get { return this.isiscsienabled; }
            set { this.isiscsienabled = value; }
        }
        private bool? isiscsienabled;
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
                    InterfaceAlias = InterfaceAlias
                };

                WriteObject(netConfig);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}

