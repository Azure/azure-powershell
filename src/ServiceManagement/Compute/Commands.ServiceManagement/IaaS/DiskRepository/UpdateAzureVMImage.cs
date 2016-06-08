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
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.DiskRepository
{
    [Cmdlet(VerbsData.Update, VirtualMachineImageNoun), OutputType(typeof(OSImageContext))]
    public class UpdateAzureVMImage : ServiceManagementBaseCmdlet
    {
        protected const string VirtualMachineImageNoun = "AzureVMImage";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the image in the image library.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Label of the image.")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the End User License Aggreement, recommended value is a URL.")]
        [ValidateNotNullOrEmpty]
        public string Eula { get; set; }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the description of the OS image.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies a value that can be used to group OS images.")]
        [ValidateNotNullOrEmpty]
        public string ImageFamily { get; set; }

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the date when the OS image was added to the image repository.")]
        [ValidateNotNullOrEmpty]
        public DateTime? PublishedDate { get; set; }

        [Parameter(Position = 6, ValueFromPipelineByPropertyName = true, HelpMessage = "Specifies the URI that points to a document that contains the privacy policy related to the OS image.")]
        [ValidateNotNullOrEmpty]
        public Uri PrivacyUri { get; set; }

        [Parameter(Position = 7, ValueFromPipelineByPropertyName = true, HelpMessage = " Specifies the size to use for the virtual machine that is created from the OS image.")]
        [ValidateNotNullOrEmpty]
        public string RecommendedVMSize { get; set; }

        [Parameter(Position = 8, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Disk Configuration Set")]
        [ValidateNotNullOrEmpty]
        public VirtualMachineImageDiskConfigSet DiskConfig { get; set; }

        [Parameter(Position = 9, ValueFromPipelineByPropertyName = true, HelpMessage = "Language.")]
        [ValidateNotNullOrEmpty]
        public string Language { get; set; }

        [Alias("IconUri")]
        [Parameter(Position = 10, ValueFromPipelineByPropertyName = true, HelpMessage = "IconUri.")]
        [ValidateNotNullOrEmpty]
        public string IconName { get; set; }

        [Alias("SmallIconUri")]
        [Parameter(Position = 11, ValueFromPipelineByPropertyName = true, HelpMessage = "SmallIconUri.")]
        [ValidateNotNullOrEmpty]
        public string SmallIconName { get; set; }

        [Parameter(Position = 12, ValueFromPipelineByPropertyName = true, HelpMessage = "DontShowInGui.")]
        public SwitchParameter DontShowInGui { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
            bool isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
            bool isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

            if (isOSImage && isVMImage)
            {
                WriteErrorWithTimestamp(
                    string.Format(Resources.DuplicateNamesFoundInBothVMAndOSImages, this.ImageName));
            }
            else if (isOSImage)
            {
                var parameters = new VirtualMachineOSImageUpdateParameters
                {
                    Label             = this.Label,
                    Eula              = this.Eula,
                    Description       = this.Description,
                    ImageFamily       = this.ImageFamily,
                    PublishedDate     = this.PublishedDate,
                    PrivacyUri        = this.PrivacyUri,
                    RecommendedVMSize = this.RecommendedVMSize,
                    Language          = this.Language,
                    IconUri           = this.IconName,
                    SmallIconUri      = this.SmallIconName,
                    ShowInGui         = this.DontShowInGui.IsPresent ? (bool?)false : null
                };

                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineOSImages.Update(this.ImageName, parameters),
                    (s, response) => this.ContextFactory<VirtualMachineOSImageUpdateResponse, OSImageContext>(response, s));
            }
            else
            {
                var osDiskConfig    = DiskConfig == null ? null : DiskConfig.OSDiskConfiguration;
                var dataDiskConfigs = DiskConfig == null ? null : DiskConfig.DataDiskConfigurations.ToList();

                var parameters = new VirtualMachineVMImageUpdateParameters
                {
                    Label                  = this.Label,
                    Eula                   = this.Eula,
                    Description            = this.Description,
                    ImageFamily            = this.ImageFamily,
                    PublishedDate          = this.PublishedDate,
                    PrivacyUri             = this.PrivacyUri,
                    RecommendedVMSize      = this.RecommendedVMSize,
                    OSDiskConfiguration    = Mapper.Map<OSDiskConfigurationUpdateParameters>(osDiskConfig),
                    DataDiskConfigurations = dataDiskConfigs == null ? null : dataDiskConfigs.Select(d => new DataDiskConfigurationUpdateParameters
                    {
                        HostCaching       = d.HostCaching,
                        LogicalUnitNumber = d.Lun,
                        Name              = d.Name
                    }).ToList(),
                    Language               = this.Language,
                    IconUri                = this.IconName,
                    SmallIconUri           = this.SmallIconName,
                    ShowInGui              = this.DontShowInGui.IsPresent ? (bool?)false : null
                };

                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineVMImages.Update(this.ImageName, parameters));
            }
        }
    }
}