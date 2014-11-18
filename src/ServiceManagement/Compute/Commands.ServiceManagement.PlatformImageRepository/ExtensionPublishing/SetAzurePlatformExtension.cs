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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Set a Platform Extension Image.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        AzureVMPlatformExtensionCommandNoun),
    OutputType(
        typeof(ManagementOperationContext))]
    public class SetAzurePlatformExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMPlatformExtensionCommandNoun = "AzurePlatformExtension";
        protected const string PublicModeStr = "Public";
        protected const string InternalModeStr = "Internal";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Image Name.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Label.")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Sample Config.")]
        [ValidateNotNullOrEmpty]
        public string SampleConfig { get; set; }

        [Parameter(
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Eula Link.")]
        [ValidateNotNullOrEmpty]
        public Uri Eula { get; set; }

        [Parameter(
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Privacy Link.")]
        [ValidateNotNullOrEmpty]
        public Uri PrivacyUri { get; set; }

        [Parameter(
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Homepage Link.")]
        [ValidateNotNullOrEmpty]
        public Uri HomepageUri { get; set; }

        [Parameter(
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Mode.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(PublicModeStr, InternalModeStr)]
        public string ExtensionMode { get; set; }

        [Parameter(
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher Name.")]
        [ValidateNotNullOrEmpty]
        public string CompanyName { get; set; }

        public bool? BlockRoleUponFailure { get; set; }

        public bool? DisallowMajorVersionUpgrade { get; set; }

        public bool? IsJsonExtension { get; set; }

        public bool? IsInternalExtension { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementPlatformImageRepositoryProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => 
                {
                    var vmExtension = this.ComputeClient.VirtualMachineExtensions
                                          .ListVersions(this.Publisher, this.ExtensionName)
                                          .FirstOrDefault(e => e.Version.Equals(this.Version));

                    var serviceExtn = this.ComputeClient.HostedServices
                                          .ListExtensionVersions(this.Publisher, this.ExtensionName)
                                          .FirstOrDefault(e => e.Version.Equals(this.Version));

                    if (vmExtension != null)
                    {
                        IsJsonExtension = vmExtension.IsJsonExtension;
                        IsInternalExtension = vmExtension.IsJsonExtension;
                        DisallowMajorVersionUpgrade = vmExtension.DisallowMajorVersionUpgrade;
                    }
                    else if (serviceExtn != null)
                    {
                        IsJsonExtension = serviceExtn.IsJsonExtension;
                        IsInternalExtension = serviceExtn.IsJsonExtension;
                        BlockRoleUponFailure = serviceExtn.BlockRoleUponFailure;
                    }

                    this.IsInternalExtension = string.Equals(this.ExtensionMode, PublicModeStr) ? false
                                             : string.Equals(this.ExtensionMode, InternalModeStr) ? true
                                             : true;

                    var parameters = Mapper.Map<ExtensionImageUpdateParameters>(this);

                    return this.ComputeClient.ExtensionImages.Update(parameters);
                });
        }
    }
}
