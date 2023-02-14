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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PacketCaptureScopeConfig"),OutputType(typeof(PSPacketCaptureMachineScope))]
    public class NewPacketCaptureScopeCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Machines to be Included in Scope")]
        public string[] Include { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Machines to be Excluded in Scope")]
        public string[] Exclude { get; set; }

        public override void Execute()
        {
            base.Execute();

            if ((this.Include == null || this.Include.Length == 0) && (this.Exclude == null || this.Exclude.Length == 0))
            {
                throw new ArgumentException("Parameters cannot be all empty to create new Packet Capture Scope.");
            }

            if (this.Include != null && this.Include.Length > 0 && this.Exclude != null && this.Exclude.Length > 0)
            {
                throw new ArgumentException("Packet Capture Scope can either have Include Scope or Exclude Scope, but not both.");
            }

            var packetCaptureScope = new PSPacketCaptureMachineScope();

            List<string> include = new List<string>();
            List<string> exclude = new List<string>();

            if(this.Include != null)
            {
                foreach (string includeInstance in this.Include)
                {
                    include.Add(includeInstance);
                }
            }

            if (this.Exclude != null)
            {
                foreach (string excludeInstance in this.Exclude)
                {
                    exclude.Add(excludeInstance);
                }
            }

            packetCaptureScope.Include = include;
            packetCaptureScope.Exclude = exclude;

            WriteObject(packetCaptureScope);
        }
    }
}
