

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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmPublicIpTag", SupportsShouldProcess = true),
        OutputType(typeof(PSPublicIpTag))]
    public class NewAzurePublicIpTagCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpTag type Example:FirstPartyUsage")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "FirstPartyUsage",
            "NetworkDomain",
            IgnoreCase = true)]
        public string IpTagType { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpTag value Example:/Sql")]
        [ValidateNotNullOrEmpty]
        public string Tag { get; set; }

        public override void Execute()
        {
            base.Execute();
            var ipTag = CreatePublicIpTag();
            WriteObject(ipTag);
        }

        private PSPublicIpTag CreatePublicIpTag()
        {
            var ipTag = new PSPublicIpTag();
            ipTag.IpTagType = this.IpTagType;
            ipTag.Tag = this.Tag;
            return ipTag;
        }
    }
}

