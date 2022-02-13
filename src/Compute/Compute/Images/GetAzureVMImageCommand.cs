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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMImage")]
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
        [LocationCompleter("Microsoft.Compute/locations/publishers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set the extended location name for EdgeZone. If not set, VM Image will be queried from Azure main region. Otherwise it will be queried from the specified extended location")]
        public string EdgeZone { get; set; }

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

        [Parameter(ParameterSetName = GetVMImageDetailParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = false,
            HelpMessage = "Specifies the maximum number of virtual machine images returned.",
            ValueFromPipelineByPropertyName = true)]
        public int? Top { get; set; }

        [Parameter(ParameterSetName = ListVMImageParamSetName,
            Mandatory = false,
            HelpMessage = "Specifies the order of the results returned. Formatted as an OData query.",
            ValueFromPipelineByPropertyName = true)]
        public string OrderBy { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if ((this.IsParameterBound(c => c.EdgeZone)) && this.EdgeZone != null)
                {
                    if (this.ParameterSetName.Equals(ListVMImageParamSetName) || WildcardPattern.ContainsWildcardCharacters(Version))
                    {
                        var result = this.VirtualMachineImagesEdgeZoneClient.ListWithHttpMessagesAsync(
                            this.Location.Canonicalize(),
                            this.EdgeZone.Canonicalize(),
                            this.PublisherName,
                            this.Offer,
                            this.Skus,
                            top: this.Top,
                            orderby: this.OrderBy
                            ).GetAwaiter().GetResult();

                        var images = from r in result.Body
                                     select new PSVirtualMachineImage
                                     {
                                         RequestId = result.RequestId,
                                         StatusCode = result.Response.StatusCode,
                                         Id = r.Id,
                                         Location = r.Location,
                                         EdgeZone = r.ExtendedLocation.Name,
                                         Version = r.Name,
                                         PublisherName = this.PublisherName,
                                         Offer = this.Offer,
                                         Skus = this.Skus
                                     };

                        WriteObject(SubResourceWildcardFilter(Version, images), true);
                    }
                    else
                    {
                        var response = this.VirtualMachineImagesEdgeZoneClient.GetWithHttpMessagesAsync(
                            this.Location.Canonicalize(),
                            this.EdgeZone,
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
                            EdgeZone = response.Body.ExtendedLocation.Name,
                            Name = response.Body.Name,
                            Version = this.Version,
                            PublisherName = this.PublisherName,
                            Offer = this.Offer,
                            Skus = this.Skus,
                            OSDiskImage = response.Body.OsDiskImage,
                            DataDiskImages = response.Body.DataDiskImages,
                            PurchasePlan = response.Body.Plan,
                            AutomaticOSUpgradeProperties = response.Body.AutomaticOSUpgradeProperties,
                            HyperVGeneration = response.Body.HyperVGeneration
                        };

                        WriteObject(image);
                    }
                }
                else if (this.ParameterSetName.Equals(ListVMImageParamSetName) || WildcardPattern.ContainsWildcardCharacters(Version))
                {
                    var result = this.VirtualMachineImageClient.ListWithHttpMessagesAsync(
                        this.Location.Canonicalize(),
                        this.PublisherName,
                        this.Offer,
                        this.Skus,
                        top: this.Top,
                        orderby: this.OrderBy
                        ).GetAwaiter().GetResult();

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
                                     Skus = this.Skus
                                 };

                    WriteObject(SubResourceWildcardFilter(Version, images), true);
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
                        AutomaticOSUpgradeProperties = response.Body.AutomaticOSUpgradeProperties,
                        HyperVGeneration = response.Body.HyperVGeneration
                    };

                    WriteObject(image);
                }
            });
        }
    }
}
