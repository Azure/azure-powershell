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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;


namespace Microsoft.Azure.Commands.Network.NetworkWatcher
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorProtocolConfigurationObject"),
        OutputType(typeof(PSConnectionMonitorTcpConfiguration), ParameterSetName = (new string[] { "TCP" })),
        OutputType(typeof(PSConnectionMonitorHttpConfiguration), ParameterSetName = (new string[] { "HTTP" })),
        OutputType(typeof(PSConnectionMonitorIcmpConfiguration), ParameterSetName = (new string[] { "ICMP" }))]

    public class NewNetworkWatcherConnectionMonitorProtocolConfigurationObject : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocol.",
            ParameterSetName = "TCP")]
        public SwitchParameter TcpProtocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocol.",
            ParameterSetName = "HTTP")]
        public SwitchParameter HttpProtocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocol.",
            ParameterSetName = "ICMP")]
        public SwitchParameter IcmpProtocol { get; set; }
          
        [Parameter(
             Mandatory = true,
             HelpMessage = "The port.",
             ParameterSetName = "TCP")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The port.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public short? Port { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Disable traceRoute.",
             ParameterSetName = "TCP")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "Disable traceRoute.",
             ParameterSetName = "ICMP")]
        [ValidateNotNullOrEmpty]
        public bool DisableTraceRoute { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The method.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public string Method { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The path.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The request header.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public Dictionary<string, string> RequestHeader { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The list of valid status code range.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public List<String> ValidStatusCodeRange { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Whether to prefer HTTPS or not.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public bool PreferHTTPS { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            if (TcpProtocol.IsPresent)
            {
                PSConnectionMonitorTcpConfiguration TcpConfiguration = new PSConnectionMonitorTcpConfiguration()
                {
                    Port = this.Port,
                    DisableTraceRoute = this.DisableTraceRoute
                };

                WriteObject(TcpConfiguration);
            }
            else if (HttpProtocol.IsPresent)
            {
                PSConnectionMonitorHttpConfiguration HttpConfiguration = new PSConnectionMonitorHttpConfiguration()
                {
                    Port = this.Port,
                    Method = this.Method,
                    Path = this.Path,
                    RequestHeaders = this.RequestHeader,
                    ValidStatusCodeRanges = this.ValidStatusCodeRange,
                    PreferHTTPS = this.PreferHTTPS
                };

                WriteObject(HttpConfiguration);
            }
            else if (IcmpProtocol.IsPresent)
            {
                PSConnectionMonitorIcmpConfiguration IcmpConfiguration = new PSConnectionMonitorIcmpConfiguration()
                {
                    DisableTraceRoute = this.DisableTraceRoute
                };

                WriteObject(IcmpConfiguration);
            }
            else
            {
                throw new ArgumentException("Parameter set shall be TCP, HTTP, or ICMP");
            }
        }

        public bool Validate()
        {
            if (TcpProtocol.IsPresent)
            {
                if (this.Port == 0)
                {
                    throw new ArgumentException("Port can not be zero for TCP configuration");
                }
            }
            else if (HttpProtocol.IsPresent)
            {
            }
            else if (IcmpProtocol.IsPresent)
            {
            }
            else
            {
                throw new ArgumentException("Only TCP, HTTP, or ICMP are supported");
            }

            return true;
        }
    }
}
