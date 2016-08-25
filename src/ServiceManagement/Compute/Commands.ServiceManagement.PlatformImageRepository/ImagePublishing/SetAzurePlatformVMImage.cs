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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ImagePublishing
{
    [Cmdlet(VerbsCommon.Set, "AzurePlatformVMImage", DefaultParameterSetName = ReplicateParameterSetName), OutputType(typeof(ManagementOperationContext))]
    public class SetAzurePlatformVMImage : ServiceManagementBaseCmdlet
    {
        private const string ReplicateParameterSetName = "Replicate";
        private const string ShareParameterSetName = "Share";

        private bool isVMImage;
        private bool isOSImage;

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ReplicateParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the image in the image library.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ShareParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the image in the image library.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ReplicateParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the locations that image will be replicated.")]
        [ValidateNotNullOrEmpty]
        public string[] ReplicaLocations { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ShareParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the sharing permission of replicated image.")]
        [ValidateSet("Public", "Private", "MSDN", "EA")]
        public string Permission { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ReplicateParameterSetName), ValidateNotNullOrEmpty]
        public ComputeImageConfig ComputeImageConfig { get; set; }

        [Parameter(ParameterSetName = ReplicateParameterSetName), ValidateNotNullOrEmpty]
        public MarketplaceImageConfig MarketplaceImageConfig { get; set; }

        public void SetAzurePlatformVMImageProcess()
        {
            var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
            isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
            isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

            if (isOSImage && isVMImage)
            {
                WriteErrorWithTimestamp(
                    string.Format(ServiceManagement.Properties.Resources.DuplicateNamesFoundInBothVMAndOSImages, this.ImageName));
            }

            if (this.ParameterSpecified("ReplicaLocations"))
            {
                ProcessReplicateImageParameterSet();
            }
            else if (this.ParameterSpecified("Permission"))
            {
                ProcessShareImageParameterSet();
            }
        }

        private bool ParameterSpecified(string parameterName)
        {
            return this.MyInvocation.BoundParameters.ContainsKey(parameterName);
        }

        private void ProcessShareImageParameterSet()
        {
            if (isVMImage)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineVMImages.GetDetails(this.ImageName);
                        return this.ComputeClient.VirtualMachineVMImages.Share(this.ImageName, this.Permission);
                    });
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineOSImages.GetDetails(this.ImageName);
                        return this.ComputeClient.VirtualMachineOSImages.Share(this.ImageName, this.Permission);
                    });
            }
        }

        private void ProcessReplicateImageParameterSet()
        {
            if (isVMImage)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineVMImages.GetDetails(this.ImageName);
                        ValidateTargetLocations();
                        return this.ComputeClient.VirtualMachineVMImages.Replicate(
                            this.ImageName,
                            new Management.Compute.Models.VirtualMachineVMImageReplicateParameters
                            {
                                TargetLocations = this.ReplicaLocations == null ? null : this.ReplicaLocations.ToList(),
                                ComputeImageAttributes = new ComputeImageAttributes
                                {
                                    Offer = this.ComputeImageConfig.Offer,
                                    Sku = this.ComputeImageConfig.Sku,
                                    Version = this.ComputeImageConfig.Version
                                },
                                MarketplaceImageAttributes = this.MarketplaceImageConfig == null ? null : new MarketplaceImageAttributes
                                {
                                    Plan = new Plan
                                    {
                                        Name = this.MarketplaceImageConfig.PlanName,
                                        Product = this.MarketplaceImageConfig.Product,
                                        Publisher = this.MarketplaceImageConfig.Publisher
                                    },
                                    PublisherId = this.MarketplaceImageConfig.PublisherId
                                }
                            });
                    });
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineOSImages.Get(this.ImageName);
                        ValidateTargetLocations();
                        return this.ComputeClient.VirtualMachineOSImages.Replicate(this.ImageName, new Management.Compute.Models.VirtualMachineOSImageReplicateParameters
                            {
                                TargetLocations = this.ReplicaLocations == null ? null : this.ReplicaLocations.ToList(),
                                ComputeImageAttributes = new ComputeImageAttributes
                                {
                                    Offer = this.ComputeImageConfig.Offer,
                                    Sku = this.ComputeImageConfig.Sku,
                                    Version = this.ComputeImageConfig.Version
                                },
                                MarketplaceImageAttributes = this.MarketplaceImageConfig == null ? null : new MarketplaceImageAttributes
                                {
                                    Plan = new Plan
                                    {
                                        Name = this.MarketplaceImageConfig.PlanName,
                                        Product = this.MarketplaceImageConfig.Product,
                                        Publisher = this.MarketplaceImageConfig.Publisher
                                    },
                                    PublisherId = this.MarketplaceImageConfig.PublisherId
                                }
                            });
                    });
            }
        }

        private void ValidateTargetLocations()
        {
            var locations = this.ManagementClient.Locations.List();
            if (this.ReplicaLocations != null)
            {
                var invalidValues = ReplicaLocations.Except(locations.Select(l => l.Name), StringComparer.OrdinalIgnoreCase).ToList();

                if (invalidValues.Any())
                {
                    var validValuesMessage = string.Format(Resources.SetAzurePlatformVMImage_Valid_Values, String.Join(", ", locations.Select(l => "'" + l.Name + "'")));
                    var invalidValuesMessage = string.Format(Resources.SetAzurePlatformVMImage_Invalid_Values, String.Join(", ", invalidValues.Select(l => "'" + l + "'")));

                    throw new ArgumentOutOfRangeException("Location", String.Format(Resources.SetAzurePlatformVMImage_Expected_Found, validValuesMessage, invalidValuesMessage));
                }
            }
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.SetAzurePlatformVMImageProcess();
        }
    }
}
