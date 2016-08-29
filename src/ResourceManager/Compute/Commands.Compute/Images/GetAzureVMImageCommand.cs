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
    [Cmdlet(VerbsCommon.Get,
        ProfileNouns.VirtualMachineImage)]
    [OutputType(typeof(PSVirtualMachineImage),
        ParameterSetName = new[] { ListVMImageParamSetName })]
    [OutputType(typeof(PSVirtualMachineImageDetail),
        ParameterSetName = new[] { GetVMImageDetailParamSetName })]
    public class GetAzureVMImageCommand : VirtualMachineImageBaseCmdlet
    {
        protected const string ListVMImageParamSetName = "ListVMImage";
        protected const string GetVMImageDetailParamSetName = "GetVMImageDetail";

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PublisherName { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Offer { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Skus { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            ValueFromPipelineByPropertyName = false),
        ValidateNotNullOrEmpty]
        public string FilterExpression { get; set; }

        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true),
        ValidateNotNullOrEmpty]
        public string Version { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ParameterSetName.Equals(ListVMImageParamSetName))
                {
                    var filter = new ODataQuery<VirtualMachineImageResource>(this.FilterExpression);

                    var result = this.VirtualMachineImageClient.ListWithHttpMessagesAsync(
                        this.Location.Canonicalize(),
                        this.PublisherName,
                        this.Offer,
                        this.Skus,
                        odataQuery: filter).GetAwaiter().GetResult();

                    var images = from r in result.Body
                                 select new PSVirtualMachineImage
                                 {
                                     RequestId = result.RequestId,
                                     StatusCode = result.Response.StatusCode,
                                     Id = r.Id,
                                     Location = r.Location,
                                     Version = r.Name,
                                     PublisherName = this.PublisherName,
                                     Offer = this.Offer,
                                     Skus = this.Skus,
                                     FilterExpression = this.FilterExpression
                                 };

                    WriteObject(images, true);
                }
                else
                {
                    var response = this.VirtualMachineImageClient.GetWithHttpMessagesAsync(
                        this.Location.Canonicalize(),
                        this.PublisherName,
                        this.Offer,
                        this.Skus,
                        version: this.Version).GetAwaiter().GetResult();

                    var image = new PSVirtualMachineImageDetail
                    {
                        RequestId = response.RequestId,
                        StatusCode = response.Response.StatusCode,
                        Id = response.Body.Id,
                        Location = response.Body.Location,
                        Name = response.Body.Name,
                        Version = this.Version,
                        PublisherName = this.PublisherName,
                        Offer = this.Offer,
                        Skus = this.Skus,
                        OSDiskImage = response.Body.OsDiskImage,
                        DataDiskImages = response.Body.DataDiskImages,
                        PurchasePlan = response.Body.Plan,
                    };

                    WriteObject(image);
                }
            });
        }
    }
}
