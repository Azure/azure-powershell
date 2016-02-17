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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC
{
    /// <summary>
    /// Uploads a Desired State Configuration script to Azure blob storage, which 
    /// later can be applied to Azure Virtual Machines using the 
    /// Set-AzureVMDscExtension cmdlet.
    /// </summary>
    [Cmdlet(
        VerbsData.Publish, 
        "AzureVMDscConfiguration", 
        SupportsShouldProcess = true, 
        DefaultParameterSetName = UploadArchiveParameterSetName),
    OutputType(
         typeof(String))]
    public class PublishAzureVMDscConfigurationCommand : DscExtensionPublishCmdletCommonBase
    {
        private const string CreateArchiveParameterSetName = "CreateArchive";
        private const string UploadArchiveParameterSetName = "UploadArchive";

        /// <summary>
        /// Path to a file containing one or more configurations; the file can be a 
        /// PowerShell script (*.ps1) or MOF interface (*.mof).
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a file containing one or more configurations")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationPath { get; set; }

        /// <summary>
        /// Name of the Azure Storage Container the configuration is uploaded to.
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UploadArchiveParameterSetName,
            HelpMessage = "Name of the Azure Storage Container the configuration is uploaded to")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        /// <summary>
        /// By default Publish-AzureVMDscConfiguration will not overwrite any existing blobs. 
        /// Use -Force to overwrite them.
        /// </summary>
        [Parameter(HelpMessage = "By default Publish-AzureVMDscConfiguration will not overwrite any existing blobs")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// The Azure Storage Context that provides the security settings used to upload 
        /// the configuration script to the container specified by ContainerName. This 
        /// context should provide write access to the container.
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UploadArchiveParameterSetName,
            HelpMessage = "The Azure Storage Context that provides the security settings used to upload " +
                          "the configuration script to the container specified by ContainerName")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext { get; set; }

        /// <summary>
        /// Path to a local ZIP file to write the configuration archive to.
        /// When using this parameter, Publish-AzureVMDscConfiguration creates a
        /// local ZIP archive instead of uploading it to blob storage..
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateArchiveParameterSetName,
            HelpMessage = "Path to a local ZIP file to write the configuration archive to.")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationArchivePath { get; set; }

        /// <summary>  
        /// Suffix for the storage end point, e.g. core.windows.net  
        /// </summary>  
        [Parameter(
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = UploadArchiveParameterSetName,
           HelpMessage = "Suffix for the storage end point, e.g. core.windows.net")]
        [ValidateNotNullOrEmpty]
        public string StorageEndpointSuffix { get; set; }

        /// <summary>
        /// Excludes DSC resource dependencies from the configuration archive
        /// </summary>
        [Parameter(HelpMessage = "Excludes DSC resource dependencies from the configuration archive")]
        public SwitchParameter SkipDependencyDetection { get; set; }

        /// <summary>
        ///Path to a .psd1 file that specifies the data for the Configuration. This 
        /// file must contain a hashtable with the items described in 
        /// http://technet.microsoft.com/en-us/library/dn249925.aspx.
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a .psd1 file that specifies the data for the Configuration")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationDataPath { get; set; }

        /// <summary>
        /// Path to a file or a directory to include in  the configuration archive 
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a file or a directory to include in  the configuration archive")]
        [ValidateNotNullOrEmpty]
        public String[] AdditionalPath { get; set; }

        /// <summary>
        /// Outputs the blob url for configuration archive path
        /// </summary>
        [Parameter(HelpMessage = "Outputs the blob url for configuration archive path")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Credentials used to access Azure Storage
        /// </summary>
        private StorageCredentials _storageCredentials;

        protected override void ProcessRecord()
        {
            try
            {
                // Create a cloud context, only in case of upload.
                if (ParameterSetName == UploadArchiveParameterSetName)
                {
                    base.ProcessRecord();
                }

                ExecuteCommand();
            }
            finally
            {
                DeleteTemporaryFiles();
            }
        }

        private void ExecuteCommand()
        {
            //check the PS version
            ValidatePsVersion();

            //validate cmdlet params
            ConfigurationPath = GetUnresolvedProviderPathFromPSPath(ConfigurationPath);

            ValidateConfigurationPath(ConfigurationPath, ParameterSetName);

            if (ConfigurationDataPath != null)
            {
                ConfigurationDataPath = GetUnresolvedProviderPathFromPSPath(ConfigurationDataPath);
                ValidateConfigurationDataPath(ConfigurationDataPath);
            }
            
            if(AdditionalPath != null && AdditionalPath.Length > 0)
            {
                for(var count = 0; count < AdditionalPath.Length; count++)
                {
                    AdditionalPath[count] = GetUnresolvedProviderPathFromPSPath(AdditionalPath[count]);
                }
            }

            switch (ParameterSetName)
            {
                case CreateArchiveParameterSetName:
                    ConfigurationArchivePath = GetUnresolvedProviderPathFromPSPath(ConfigurationArchivePath);
                    break;
                case UploadArchiveParameterSetName:
                    _storageCredentials = this.GetStorageCredentials(StorageContext);
                    if (ContainerName == null)
                    {
                        ContainerName = DscExtensionCmdletConstants.DefaultContainerName;
                    }
                    if (StorageEndpointSuffix == null)
                    {
                        StorageEndpointSuffix =
                            Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix);
                    }
                    break;
            }

            PublishConfiguration(
                ConfigurationPath, 
                ConfigurationDataPath,
                AdditionalPath,
                ConfigurationArchivePath, 
                StorageEndpointSuffix, 
                ContainerName, 
                ParameterSetName,
                Force.IsPresent, 
                SkipDependencyDetection.IsPresent,
                _storageCredentials,
                PassThru.IsPresent
            );
        }
    }
}

