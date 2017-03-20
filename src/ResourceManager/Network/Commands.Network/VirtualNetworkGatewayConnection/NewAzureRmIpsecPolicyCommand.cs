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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmIpsecPolicy"), OutputType(typeof(PSIpsecPolicy))]
    public class NewAzureRmIpsecPolicyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds")]
        [ValidateNotNullOrEmpty]
        public int SALifeTimeSeconds { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB")]
        [ValidateNotNullOrEmpty]
        public int SADataSizeKilobytes { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec encryption algorithm (IKE Phase 1)")]
        [ValidateNotNullOrEmpty]
        public string IpsecEncryption { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec integrity algorithm (IKE Phase 1)")]
        [ValidateNotNullOrEmpty]
        public string IpsecIntegrity { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IKE encryption algorithm (IKE Phase 2)")]
        [ValidateNotNullOrEmpty]
        public string IkeEncryption { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IKE integrity algorithm (IKE Phase 2)")]
        [ValidateNotNullOrEmpty]
        public string IkeIntegrity { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DH Groups used in IKE Phase 1 for initial SA")]
        [ValidateNotNullOrEmpty]
        public string DhGroup { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DH Groups used in IKE Phase 2 for new child SA")]
        [ValidateNotNullOrEmpty]
        public string PfsGroup { get; set; } 

        public override void Execute()
        {
            base.Execute();
            var ipsecPolicy = new PSIpsecPolicy();

            ipsecPolicy.SALifeTimeSeconds = this.SALifeTimeSeconds;
            ipsecPolicy.SADataSizeKilobytes = this.SADataSizeKilobytes;
            ipsecPolicy.IpsecEncryption = this.IpsecEncryption;
            ipsecPolicy.IpsecIntegrity = this.IpsecIntegrity;
            ipsecPolicy.IkeEncryption = this.IkeEncryption;
            ipsecPolicy.IkeIntegrity = this.IkeIntegrity;
            ipsecPolicy.DhGroup = this.DhGroup;
            ipsecPolicy.PfsGroup = this.PfsGroup;

            WriteObject(ipsecPolicy);
        }
    }
}
