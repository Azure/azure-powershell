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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.NetworkWatcher
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkWatcherProtocolConfiguration"),
        OutputType(typeof(PSNetworkWatcherProtocolConfiguration))]
    public class NewAzureNetworkWatcherProtocolConfiguration : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "Procotol")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Tcp", "Http", "Https", "Icmp")]
        public string Protocol { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Method")]
        [ValidateNotNullOrEmpty]
        public string Method { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Header")]
        [ValidateNotNullOrEmpty]
        public IDictionary Header { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "ValidStatusCode")]
        [ValidateNotNullOrEmpty]
        public int[] ValidStatusCode { get; set; }

        public override void Execute()
        {
            base.Execute();

            var protocolConfiguration = new PSNetworkWatcherProtocolConfiguration();
            protocolConfiguration.Protocol = this.Protocol;
            protocolConfiguration.Method = this.Method;
            protocolConfiguration.Header = this.Header;
            protocolConfiguration.ValidStatusCode = this.ValidStatusCode;

            WriteObject(protocolConfiguration);
        }
    }
}
