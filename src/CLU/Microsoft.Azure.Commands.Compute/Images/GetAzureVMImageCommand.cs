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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get,
        ProfileNouns.VirtualMachineImage)]
    [OutputType(typeof(PSVirtualMachineImage),
        ParameterSetName = new [] {ListVMImageParamSetName})]
    [OutputType(typeof(PSVirtualMachineImageDetail),
        ParameterSetName = new [] {GetVMImageDetailParamSetName})]
    [CliCommandAlias("vm image ls")]
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

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteClientAction(() =>
            {
                if (this.ParameterSetName.Equals(ListVMImageParamSetName))
                {
                    // TODO : FilterExpression
                    var result = this.VirtualMachineImageClient.List(Location.Canonicalize(), PublisherName, Offer, Skus, null);

                    /*var images = from r in result
                                 select new PSVirtualMachineImage
                                 {
                                     Id = r.Id,
                                     Location = r.Location,
                                     Version = r.Name,
                                     PublisherName = this.PublisherName,
                                     Offer = this.Offer,
                                     Skus = this.Skus,
                                     FilterExpression = this.FilterExpression
                                 };

                    WriteObject(images, true);*/
                    WriteObject(result, true);
                }
                else
                {
                    var result = this.VirtualMachineImageClient.Get(Location.Canonicalize(), PublisherName, Offer, Skus, Version);

                    /*var image = new PSVirtualMachineImageDetail
                    {
                        Id = result.Id,
                        Location = result.Location,
                        Name = result.Name,
                        Version = result.Name,
                        PublisherName = this.PublisherName,
                        Offer = this.Offer,
                        Skus = this.Skus,
                        OSDiskImage = result.OsDiskImage,
                        DataDiskImages = result.DataDiskImages,
                        PurchasePlan = result.Plan,
                    };

                    WriteObject(image);*/
                    WriteObject(result);
                }
            });
        }
    }
}
