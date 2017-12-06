

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
    [Cmdlet(VerbsCommon.New, "AzureRmPublicIpAddressIpTag", SupportsShouldProcess = true),
        OutputType(typeof(PSPublicIpAddressIpTag))]
    public class NewAzurePublicIpAddressIpTagCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpTag type")]
        [ValidateNotNullOrEmpty]
        public virtual string IpTagType { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpTag value")]
        [ValidateNotNullOrEmpty]
        public virtual string Tag { get; set; }


        public override void Execute()
        {
            base.Execute();
            var ipTag = CreatePublicIpAddressIpTag();
            WriteObject(ipTag);
        }

        private PSPublicIpAddressIpTag CreatePublicIpAddressIpTag()
        {
            var ipTag = new PSPublicIpAddressIpTag();
            ipTag.IpTagType = this.IpTagType;
            ipTag.Tag = this.Tag;
            return ipTag;
        }
    }
}

