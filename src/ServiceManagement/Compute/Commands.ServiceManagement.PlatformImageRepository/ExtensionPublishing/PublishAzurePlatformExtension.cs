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

using AutoMapper;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Publish a Platform Extension Image.
    /// </summary>
    [Cmdlet(
        VerbsData.Publish,
        AzureVMPlatformExtensionCommandNoun),
    OutputType(
        typeof(ManagementOperationContext))]
    public class PublishAzurePlatformExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMPlatformExtensionCommandNoun = "AzurePlatformExtension";
        public bool? IsInternalExtension { get; set; }

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
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Hosting Resources.")]
        [ValidateNotNullOrEmpty]
        public string HostingResources { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Media Link.")]
        [ValidateNotNullOrEmpty]
        public Uri MediaLink { get; set; }

        [Parameter(
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Label.")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Certificate Config.")]
        [ValidateNotNullOrEmpty]
        public ExtensionCertificateConfig CertificateConfig { get; set; }

        [Parameter(
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Endpoint Config.")]
        [ValidateNotNullOrEmpty]
        public ExtensionEndpointConfigSet EndpointConfig { get; set; }

        [Parameter(
            Position = 8,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Public Configuration Schema.")]
        [ValidateNotNullOrEmpty]
        public string PublicConfigurationSchema { get; set; }

        [Parameter(
            Position = 9,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Private Configuration Schema.")]
        [ValidateNotNullOrEmpty]
        public string PrivateConfigurationSchema { get; set; }

        [Parameter(
            Position = 10,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Position = 11,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher's Company Name.")]
        [ValidateNotNullOrEmpty]
        public string CompanyName { get; set; }

        [Parameter(
            Position = 12,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Published Date.")]
        [ValidateNotNullOrEmpty]
        public DateTime? PublishedDate { get; set; }

        [Parameter(
            Position = 13,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Local Resource Config.")]
        [ValidateNotNullOrEmpty]
        public ExtensionLocalResourceConfigSet LocalResourceConfig { get; set; }

        [Parameter(
            Position = 14,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To block the role upon failure.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter BlockRoleUponFailure { get; set; }

        [Parameter(
            Position = 15,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Sample Config.")]
        [ValidateNotNullOrEmpty]
        public string SampleConfig { get; set; }

        [Parameter(
            Position = 16,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Eula Link.")]
        [ValidateNotNullOrEmpty]
        public Uri Eula { get; set; }

        [Parameter(
            Position = 17,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Privacy Link.")]
        [ValidateNotNullOrEmpty]
        public Uri PrivacyUri { get; set; }

        [Parameter(
            Position = 18,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Homepage Link.")]
        [ValidateNotNullOrEmpty]
        public Uri HomepageUri { get; set; }

        [Parameter(
            Position = 19,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Type is XML.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter XmlExtension { get; set; }

        [Parameter(
            Position = 20,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To disallow major version upgrade.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisallowMajorVersionUpgrade { get; set; }

        [Parameter(
            Position = 21,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Supported OS of the Extension")]
        [ValidateNotNullOrEmpty]
        public string SupportedOS { get; set; }

        [Parameter(
           Mandatory = false,
           Position = 22,
           HelpMessage = "Regions of the Extension")]
        public string Regions { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 23,
            HelpMessage = "To force the registration operation.")]
        public SwitchParameter Force { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementPlatformImageRepositoryProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    OperationStatusResponse op = null;

                    bool found = ExtensionExists();
                    var publishCnfm = Resources.ExtensionPublishingConfirmation;
                    var publishCptn = Resources.ExtensionPublishingCaption;
                    var upgradeCnfm = Resources.ExtensionUpgradingConfirmation;
                    var upgradeCptn = Resources.ExtensionUpgradingCaption;

                    this.IsInternalExtension = true;

                    if (found && (this.Force.IsPresent || this.ShouldContinue(upgradeCnfm, upgradeCptn)))
                    {
                        var parameters = Mapper.Map<ExtensionImageUpdateParameters>(this);
                        op = this.ComputeClient.ExtensionImages.Update(parameters);
                    }
                    else if (!found && (this.Force.IsPresent || this.ShouldContinue(publishCnfm, publishCptn)))
                    {
                        var parameters = Mapper.Map<ExtensionImageRegisterParameters>(this);
                        op = this.ComputeClient.ExtensionImages.Register(parameters);
                    }

                    return op;
                });
        }

        private bool ExtensionExists()
        {
            bool found = false;

            try
            {
                var ext = this.ComputeClient.HostedServices
                              .ListExtensionVersions(this.Publisher, this.ExtensionName);

                found |= ext != null && ext.Any();
            }
            catch(Exception ex)
            {
                WriteWarning(ex.ToString());
            }

            try
            {
                var ext = this.ComputeClient.VirtualMachineExtensions
                              .ListVersions(this.Publisher, this.ExtensionName);

                found |= ext != null && ext.Any();
            }
            catch (Exception ex)
            {
                WriteWarning(ex.ToString());
            }

            return found;
        }
    }
}
