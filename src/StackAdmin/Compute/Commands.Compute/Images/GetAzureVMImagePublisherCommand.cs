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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachineImagePublisher)]
    [OutputType(typeof(PSVirtualMachineImagePublisher))]
    public class GetAzureVMImagePublisherCommand : VirtualMachineImageBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var result = this.VirtualMachineImageClient.ListPublishersWithHttpMessagesAsync(
                    this.Location.Canonicalize()).GetAwaiter().GetResult();

                var images = from r in result.Body
                             select new PSVirtualMachineImagePublisher
                             {
                                 RequestId = result.RequestId,
                                 StatusCode = result.Response.StatusCode,
                                 Id = r.Id,
                                 Location = r.Location,
                                 PublisherName = r.Name
                             };

                WriteObject(images, true);
            });
        }
    }
}
