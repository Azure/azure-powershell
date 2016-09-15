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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ImagePublishing
{
    [Cmdlet(VerbsCommon.Get, "AzurePlatformVMImage"), OutputType(typeof(OSImageDetailsContext))]
    public class GetAzurePlatformVMImage : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the image in the image library.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
            bool isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
            bool isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

            if (isOSImage || !isVMImage)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineOSImages.GetDetails(this.ImageName),
                    (operation, imageDetails) => imageDetails == null ? null : new OSImageDetailsContext
                    {
                        AffinityGroup = imageDetails.AffinityGroup,
                        Category = imageDetails.Category,
                        Label = imageDetails.Label,
                        Location = imageDetails.Location,
                        MediaLink = imageDetails.MediaLinkUri,
                        ImageName = imageDetails.Name,
                        OS = imageDetails.OperatingSystemType,
                        LogicalSizeInGB = (int)imageDetails.LogicalSizeInGB,
                        Eula = imageDetails.Eula,
                        Description = imageDetails.Description,
                        IconUri = imageDetails.IconUri,
                        ImageFamily = imageDetails.ImageFamily,
                        IsPremium = imageDetails.IsPremium,
                        PrivacyUri = imageDetails.PrivacyUri,
                        PublishedDate = imageDetails.PublishedDate,
                        RecommendedVMSize = imageDetails.RecommendedVMSize,
                        IsCorrupted = imageDetails.IsCorrupted,
                        SmallIconUri = imageDetails.SmallIconUri,
                        PublisherName = imageDetails.PublisherName,
                        Offer = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Offer,
                        Sku = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Sku,
                        Version = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Version,
                        ReplicationProgress = imageDetails.ReplicationProgress.Select(
                                               detail => new ReplicationProgressContext
                                               {
                                                   Location = detail.Location,
                                                   Progress = detail.Progress
                                               }).ToList(),
                        OperationId = operation.RequestId,
                        OperationDescription = CommandRuntime.ToString(),
                        OperationStatus = operation.Status.ToString()
                    });
            }

            if (isVMImage)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineVMImages.GetDetails(this.ImageName),
                    (operation, imageDetails) => imageDetails == null ? null : new VMImageDetailsContext
                    {
                        AffinityGroup = imageDetails.AffinityGroup,
                        Location = imageDetails.Location,
                        Category = imageDetails.Category,
                        Label = imageDetails.Label,
                        ImageName = imageDetails.Name,
                        Eula = imageDetails.Eula,
                        Description = imageDetails.Description,
                        IconUri = imageDetails.IconUri,
                        ImageFamily = imageDetails.ImageFamily,
                        IsPremium = imageDetails.IsPremium,
                        PrivacyUri = imageDetails.PrivacyUri,
                        PublishedDate = imageDetails.PublishedDate,
                        RecommendedVMSize = imageDetails.RecommendedVMSize,
                        IsCorrupted = imageDetails.IsCorrupted,
                        SmallIconUri = imageDetails.SmallIconUri,
                        SharingStatus = imageDetails.SharingStatus,
                        PublisherName = imageDetails.PublisherName,
                        Offer = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Offer,
                        Sku = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Sku,
                        Version = (imageDetails.ComputeImageAttributes == null) ? string.Empty : imageDetails.ComputeImageAttributes.Version,
                        ReplicationProgress = imageDetails.ReplicationProgress.Select(
                                               detail => new ReplicationProgressContext
                                               {
                                                   Location = detail.Location,
                                                   Progress = detail.Progress
                                               }).ToList(),
                        OperationId = operation.RequestId,
                        OperationDescription = CommandRuntime.ToString(),
                        OperationStatus = operation.Status.ToString()
                    });
            }
        }
    }
}
