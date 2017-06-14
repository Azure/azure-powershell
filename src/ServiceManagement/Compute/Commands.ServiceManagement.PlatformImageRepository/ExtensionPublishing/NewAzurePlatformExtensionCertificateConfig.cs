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

using System.Management.Automation;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Create a New Extension Certificate Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        AzurePlatformExtensionCertificateConfigCommandNoun),
    OutputType(
        typeof(ExtensionCertificateConfig))]
    public class NewAzurePlatformExtensionCertificateConfigCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionCertificateConfigCommandNoun = "AzurePlatformExtensionCertificateConfig";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Certificate Store Location.")]
        [ValidateNotNullOrEmpty]
        public string StoreLocation { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Certificate Store Name.")]
        [ValidateNotNullOrEmpty]
        public string StoreName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Certificate Thumbprint Algorithm.")]
        [ValidateNotNullOrEmpty]
        public string ThumbprintAlgorithm { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Certificate Thumbprint Requirement.")]
        public SwitchParameter ThumbprintRequired { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementPlatformImageRepositoryProfile.Initialize();
            WriteObject(Mapper.Map<ExtensionCertificateConfig>(this));
        }
    }
}
