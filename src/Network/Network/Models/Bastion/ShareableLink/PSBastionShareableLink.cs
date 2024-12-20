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
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSBastionShareableLink
    {
        public PSBastionShareableLink()
        {
        }

        public PSBastionShareableLink(string vmId, string bsl = default, string createdAt = default, string message = default)
        {
            this.VmId = vmId;
            this.Bsl = bsl;
            this.CreatedAt = createdAt;
            this.Message = message;
        }

        public PSBastionShareableLink(BastionShareableLink bsl)
        {
            this.VmId = bsl.VM.Id;
            this.Bsl = bsl.Bsl;
            this.CreatedAt = bsl.CreatedAt;
            this.Message = bsl.Message;
        }

        public PSBastionShareableLink(string vmId)
        {
            this.VmId = vmId;
        }

        [Ps1Xml(Label = "VM ID", Target = ViewControl.List)]
        public string VmId { get; set; }

        [Ps1Xml(Label = "BSL", Target = ViewControl.List)]
        public string Bsl { get; set; }

        [Ps1Xml(Label = "Created At", Target = ViewControl.List)]
        public string CreatedAt { get; set; }

        [Ps1Xml(Label = "Message", Target = ViewControl.List)]
        public string Message { get; set; }

        public BastionShareableLink ToSdkObject()
        {
            return new BastionShareableLink(new VM
            {
                Id = this.VmId
            }, Bsl, CreatedAt, Message);
        }
    }
}
