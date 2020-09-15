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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Network.NetworkWatcher
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorProtocolConfigurationObject"),
        OutputType(typeof(PSNetworkWatcherConnectionMonitorTcpConfiguration), ParameterSetName = (new string[] { "TCP" })),
        OutputType(typeof(PSNetworkWatcherConnectionMonitorHttpConfiguration), ParameterSetName = (new string[] { "HTTP" })),
        OutputType(typeof(PSNetworkWatcherConnectionMonitorIcmpConfiguration), ParameterSetName = (new string[] { "ICMP" }))]

    public class NewNetworkWatcherConnectionMonitorProtocolConfigurationObject : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "TCP protocol switch.",
            ParameterSetName = "TCP")]
        public SwitchParameter TcpProtocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "HTTP protocol switch.",
            ParameterSetName = "HTTP")]
        public SwitchParameter HttpProtocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ICMP protocol switch.",
            ParameterSetName = "ICMP")]
        public SwitchParameter IcmpProtocol { get; set; }
          
        [Parameter(
             Mandatory = true,
             HelpMessage = "The port to connect to.",
             ParameterSetName = "TCP")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "The port to connect to.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public ushort? Port { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Value indicating whether path evaluation with trace route should be disabled.",
             ParameterSetName = "TCP")]
        [Parameter(
             Mandatory = false,
             HelpMessage = "Value indicating whether path evaluation with trace route should be disabled.",
             ParameterSetName = "ICMP")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableTraceRoute { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The HTTP method to use.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("GET", "POST")]
        public string Method { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The path component of the URI. For instance, \"/dir1/dir2\".",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The HTTP headers to transmit with the request.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public Hashtable RequestHeader { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "HTTP status codes to consider successful. For instance, \"2xx,301-304,418\".",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public string[] ValidStatusCodeRange { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Value indicating whether HTTPS is preferred over HTTP in cases where the choice is not explicit.",
             ParameterSetName = "HTTP")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter PreferHTTPS { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port behavior. Supported values are None, ListenIfAvailable.",
            ParameterSetName = "TCP")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("None", "ListenIfAvailable")]
        public string DestinationPortBehavior { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorProtocolConfiguration protocolConfiguration;
            if (TcpProtocol.IsPresent)
            {
                protocolConfiguration = new PSNetworkWatcherConnectionMonitorTcpConfiguration()
                {
                    Port = this.Port,
                    DisableTraceRoute = this.DisableTraceRoute.IsPresent,
                    DestinationPortBehavior = this.DestinationPortBehavior
                };
            }
            else if (HttpProtocol.IsPresent)
            {
                protocolConfiguration = new PSNetworkWatcherConnectionMonitorHttpConfiguration()
                {
                    Port = this.Port,
                    Method = this.Method,
                    Path = this.Path,
                    RequestHeaders = this.GetHeaders(),
                    ValidStatusCodeRanges = this.ValidStatusCodeRange?.ToList(),
                    PreferHTTPS = this.PreferHTTPS.IsPresent
                };
            }
            else if (IcmpProtocol.IsPresent)
            {
                protocolConfiguration = new PSNetworkWatcherConnectionMonitorIcmpConfiguration()
                {
                    DisableTraceRoute = this.DisableTraceRoute.IsPresent
                };
            }
            else
            {
                throw new ArgumentException("Parameter set shall be TCP, HTTP, or ICMP");
            }

            this.Validate(protocolConfiguration);

            WriteObject(protocolConfiguration);
        }

        private void Validate(PSNetworkWatcherConnectionMonitorProtocolConfiguration protocolConfiguration)
        {
            ValidateProtocolConfiguration(protocolConfiguration);
        }

        private List<PSHTTPHeader> GetHeaders()
        {
            if (this.RequestHeader == null)
            {
                return null;
            }

            List<PSHTTPHeader> headers = new List<PSHTTPHeader>();
            Dictionary<string, string> requestHeaders = TagsConversionHelper.CreateTagDictionary(this.RequestHeader, validate: false);
            foreach (var pair in requestHeaders)
            {
                if (string.IsNullOrEmpty(pair.Key) || string.IsNullOrEmpty(pair.Value))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidHTTPRequestHeader);
                }

                PSHTTPHeader header = new PSHTTPHeader()
                {
                    Name = pair.Key,
                    Value = pair.Value
                };

                headers.Add(header);
            }

            return headers;
        }
    }
}