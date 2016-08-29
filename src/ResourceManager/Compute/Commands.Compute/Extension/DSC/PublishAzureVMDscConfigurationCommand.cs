using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// Uploads a Desired State Configuration script to Azure blob storage, which 
    /// later can be applied to Azure Virtual Machines using the 
    /// Set-AzureRmVMDscExtension cmdlet.
    /// </summary>
    [Cmdlet(
        VerbsData.Publish,
        ProfileNouns.VirtualMachineDscConfiguration,
        SupportsShouldProcess = true,
        DefaultParameterSetName = UploadArchiveParameterSetName),
    OutputType(
         typeof(String))]
    public class PublishAzureVMDscConfigurationCommand : DscExtensionPublishCmdletCommonBase
    {
        private const string CreateArchiveParameterSetName = "CreateArchive";
        private const string UploadArchiveParameterSetName = "UploadArchive";

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = UploadArchiveParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group that contains the storage account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Path to a file containing one or more configurations; the file can be a 
        /// PowerShell script (*.ps1) or MOF interface (*.mof).
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
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
            Position = 4,
            ParameterSetName = UploadArchiveParameterSetName,
            HelpMessage = "Name of the Azure Storage Container the configuration is uploaded to")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        /// <summary>
        /// The Azure Storage Account name used to upload the configuration script to the container specified by ContainerName. 
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UploadArchiveParameterSetName,
            HelpMessage = "The Azure Storage Account name used to upload the configuration script to the container " +
                          "specified by ContainerName ")]
        [ValidateNotNullOrEmpty]
        public String StorageAccountName { get; set; }

        /// <summary>
        /// Path to a local ZIP file to write the configuration archive to.
        /// When using this parameter, Publish-AzureRmVMDscConfiguration creates a
        /// local ZIP archive instead of uploading it to blob storage..
        /// </summary>
        [Alias("ConfigurationArchivePath")]
        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateArchiveParameterSetName,
            HelpMessage = "Path to a local ZIP file to write the configuration archive to.")]
        [ValidateNotNullOrEmpty]
        public string OutputArchivePath { get; set; }

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
        /// By default Publish-AzureRmVMDscConfiguration will not overwrite any existing blobs. 
        /// Use -Force to overwrite them.
        /// </summary>
        [Parameter(HelpMessage = "By default Publish-AzureRmVMDscConfiguration will not overwrite any existing blobs")]
        public SwitchParameter Force { get; set; }

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
            HelpMessage = "Path to a .psd1 file that specifies the data for the Configuration. This is added to the configuration " +
                          "archive and then passed to the configuration function. It gets overwritten by the configuration data path " +
                          "provided through the Set-AzureRmVMDscExtension cmdlet")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationDataPath { get; set; }

        /// <summary>
        /// Path to a file or a directory to include in  the configuration archive 
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a file or a directory to include in  the configuration archive. It gets downloaded to the " +
                          "VM along with the configuration")]
        [ValidateNotNullOrEmpty]
        public String[] AdditionalPath { get; set; }

        //Private Variables

        /// <summary>
        /// Credentials used to access Azure Storage
        /// </summary>
        private StorageCredentials _storageCredentials;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            try
            {
                ValidatePsVersion();

                //validate cmdlet params
                ConfigurationPath = GetUnresolvedProviderPathFromPSPath(ConfigurationPath);

                ValidateConfigurationPath(ConfigurationPath, ParameterSetName);

                if (ConfigurationDataPath != null)
                {
                    ConfigurationDataPath = GetUnresolvedProviderPathFromPSPath(ConfigurationDataPath);
                    ValidateConfigurationDataPath(ConfigurationDataPath);
                }

                if (AdditionalPath != null && AdditionalPath.Length > 0)
                {
                    for (var count = 0; count < AdditionalPath.Length; count++)
                    {
                        AdditionalPath[count] = GetUnresolvedProviderPathFromPSPath(AdditionalPath[count]);
                    }
                }

                switch (ParameterSetName)
                {
                    case CreateArchiveParameterSetName:
                        OutputArchivePath = GetUnresolvedProviderPathFromPSPath(OutputArchivePath);
                        break;
                    case UploadArchiveParameterSetName:
                        _storageCredentials = this.GetStorageCredentials(ResourceGroupName, StorageAccountName);
                        if (ContainerName == null)
                        {
                            ContainerName = DscExtensionCmdletConstants.DefaultContainerName;
                        }
                        if (StorageEndpointSuffix == null)
                        {
                            StorageEndpointSuffix =
                                DefaultProfile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix);
                        }
                        break;
                }

                PublishConfiguration(
                    ConfigurationPath,
                    ConfigurationDataPath,
                    AdditionalPath,
                    OutputArchivePath,
                    StorageEndpointSuffix,
                    ContainerName,
                    ParameterSetName,
                    Force.IsPresent,
                    SkipDependencyDetection.IsPresent,
                    _storageCredentials);
            }
            finally
            {
                DeleteTemporaryFiles();
            }
        }
    }
}

