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
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure.OData;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachineExtensionImage)]
    [OutputType(typeof(PSVirtualMachineExtensionImage))]
    [OutputType(typeof(PSVirtualMachineExtensionImageDetails))]
    public class GetAzureVMExtensionImageCommand : VirtualMachineExtensionImageBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string PublisherName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter, ValidateNotNullOrEmpty]
        public string FilterExpression { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Version { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (string.IsNullOrEmpty(this.Version))
                {
                    var filter = new ODataQuery<VirtualMachineExtensionImage>(this.FilterExpression);

                    var result = this.VirtualMachineExtensionImageClient.ListVersionsWithHttpMessagesAsync(
                        this.Location.Canonicalize(),
                        this.PublisherName,
                        this.Type,
                        odataQuery: filter).GetAwaiter().GetResult();

                    var images = from r in result.Body
                                 select new PSVirtualMachineExtensionImage
                                 {
                                     RequestId = result.RequestId,
                                     StatusCode = result.Response.StatusCode,
                                     Id = r.Id,
                                     Location = r.Location,
                                     Version = r.Name,
                                     PublisherName = this.PublisherName,
                                     Type = this.Type,
                                     FilterExpression = this.FilterExpression
                                 };

                    WriteObject(images, true);
                }
                else
                {
                    var result = this.VirtualMachineExtensionImageClient.GetWithHttpMessagesAsync(
                        this.Location.Canonicalize(),
                        this.PublisherName,
                        this.Type,
                        this.Version).GetAwaiter().GetResult();


                    var image = new PSVirtualMachineExtensionImageDetails
                    {
                        RequestId = result.RequestId,
                        StatusCode = result.Response.StatusCode,
                        Id = result.Body.Id,
                        Location = result.Body.Location,
                        HandlerSchema = result.Body.HandlerSchema,
                        OperatingSystem = result.Body.OperatingSystem,
                        ComputeRole = result.Body.ComputeRole,
                        SupportsMultipleExtensions = result.Body.SupportsMultipleExtensions,
                        VMScaleSetEnabled = result.Body.VmScaleSetEnabled,
                        Version = result.Body.Name,
                        PublisherName = this.PublisherName,
                        Type = this.Type,
                        FilterExpression = this.FilterExpression
                    };

                    WriteObject(image);
                }
            });
        }
    }
}
