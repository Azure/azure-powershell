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
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmIpsecPolicy"), OutputType(typeof(PSIpsecPolicy))]
    public class NewAzureRmIpsecPolicyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds")]
        [ValidateRange(300, 172799)]
        public int SALifeTimeSeconds { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB")]
        [ValidateRange(1024, int.MaxValue)]
        public int SADataSizeKilobytes { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec encryption algorithm (IKE Phase 1)")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IpsecEncryption.None,
            MNM.IpsecEncryption.DES,
            MNM.IpsecEncryption.DES3,
            MNM.IpsecEncryption.AES128,
            MNM.IpsecEncryption.AES192,
            MNM.IpsecEncryption.AES256,
            MNM.IpsecEncryption.GCMAES128,
            MNM.IpsecEncryption.GCMAES192,
            MNM.IpsecEncryption.GCMAES256,
            IgnoreCase = false)]
        public string IpsecEncryption { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IPSec integrity algorithm (IKE Phase 1)")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IpsecIntegrity.MD5,
            MNM.IpsecIntegrity.SHA1,
            MNM.IpsecIntegrity.SHA256,
            MNM.IpsecEncryption.GCMAES128,
            MNM.IpsecEncryption.GCMAES192,
            MNM.IpsecEncryption.GCMAES256,
            IgnoreCase = false)]
        public string IpsecIntegrity { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IKE encryption algorithm (IKE Phase 2)")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IkeEncryption.DES,
            MNM.IkeEncryption.DES3,
            MNM.IkeEncryption.AES128,
            MNM.IkeEncryption.AES192,
            MNM.IkeEncryption.AES256,
            IgnoreCase = false)]
        public string IkeEncryption { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The IKE integrity algorithm (IKE Phase 2)")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IkeIntegrity.MD5,
            MNM.IkeIntegrity.SHA1,
            MNM.IkeIntegrity.SHA256,
            MNM.IkeIntegrity.SHA384,
            IgnoreCase = false)]
        public string IkeIntegrity { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DH Groups used in IKE Phase 1 for initial SA")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.DhGroup.None,
            MNM.DhGroup.DHGroup1,
            MNM.DhGroup.DHGroup14,
            MNM.DhGroup.DHGroup2,
            MNM.DhGroup.DHGroup2048,
            MNM.DhGroup.DHGroup24,
            MNM.DhGroup.ECP256,
            MNM.DhGroup.ECP384,
            IgnoreCase = false)]
        public string DhGroup { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DH Groups used in IKE Phase 2 for new child SA")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.PfsGroup.None,
            MNM.PfsGroup.PFS1,
            MNM.PfsGroup.PFS2,
            MNM.PfsGroup.PFS2048,
            MNM.PfsGroup.PFS24,
            MNM.PfsGroup.ECP256,
            MNM.PfsGroup.ECP384,
            IgnoreCase = false)]
        public string PfsGroup { get; set; } 

        public override void Execute()
        {
            base.Execute();
            var ipsecPolicy = new PSIpsecPolicy();

            // default SA values
            ipsecPolicy.SALifeTimeSeconds = (!this.MyInvocation.BoundParameters.ContainsKey("SALifeTimeSeconds")) ? 27000 : this.SALifeTimeSeconds;
            ipsecPolicy.SADataSizeKilobytes = (!this.MyInvocation.BoundParameters.ContainsKey("SADataSizeKilobytes")) ? 102400000 : this.SADataSizeKilobytes;

            // GCM matching check
            if ((this.IpsecEncryption.Contains("GCM") || this.IpsecIntegrity.Contains("GCM")) && this.IpsecEncryption != this.IpsecIntegrity)
            {
                throw new ArgumentException("IpsecEncryption and IpsecIntegrity must use matching GCM algorithms");
            }

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
