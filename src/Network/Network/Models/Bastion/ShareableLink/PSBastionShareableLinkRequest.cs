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

namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSBastionShareableLinkRequest
    {
        public PSBastionShareableLinkRequest()
        {
        }

        public PSBastionShareableLinkRequest(List<string> vmIds = default)
        {
            this.VmIds = new List<PSBastionShareableLink>();
            if (vmIds != null && vmIds.Count > 0)
            {
                this.VmIds.AddRange(vmIds.Select(vmId => new PSBastionShareableLink(vmId)));
            }
        }

        [Ps1Xml(Label = "Bastion Shareable Links", Target = ViewControl.List)]
        public List<PSBastionShareableLink> VmIds { get; set; }

        public BastionShareableLinkListRequest ToSdkObject()
        {
            List<BastionShareableLink> bslList = new List<BastionShareableLink>();
            bslList.AddRange(this.VmIds.Select(psBsl => psBsl.ToSdkObject()));
            return new BastionShareableLinkListRequest(bslList);
        }
    }
}
