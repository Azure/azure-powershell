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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmPacketCaptureFilterConfig"),
        OutputType(typeof(PSPacketCaptureFilter))]
    public class NewPacketCaptureFilterCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = false,
             ValueFromPipeline = true,
             HelpMessage = "Procotol")]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Remote IP Address")]
        [ValidateNotNullOrEmpty]
        public string RemoteIPAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local IP Address")]
        [ValidateNotNullOrEmpty]
        public string LocalIPAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local Port")]
        [ValidateNotNullOrEmpty]
        public string LocalPort { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Remote port")]
        [ValidateNotNullOrEmpty]
        public string RemotePort { get; set; }

        public override void Execute()
        {
            base.Execute();

            var packetCaptureFilter = new PSPacketCaptureFilter();
            packetCaptureFilter.Protocol = this.Protocol;
            packetCaptureFilter.RemoteIPAddress = this.RemoteIPAddress;
            packetCaptureFilter.LocalIPAddress = this.LocalIPAddress;
            packetCaptureFilter.RemotePort = this.RemotePort;
            packetCaptureFilter.LocalPort = this.LocalPort;

            WriteObject(packetCaptureFilter);
        }
    }
}
