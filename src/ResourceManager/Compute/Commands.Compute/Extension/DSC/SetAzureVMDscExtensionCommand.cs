using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineDscExtension,
        SupportsShouldProcess = true,
        DefaultParameterSetName = AzureBlobDscExtensionParamSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMDscExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        protected const string AzureBlobDscExtensionParamSet = "AzureBlobDscExtension";

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The name of the resource group that contains the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the virtual machine where dsc extension handler would be installed.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the ARM resource that represents the extension. This is defaulted to 'Microsoft.Powershell.DSC'")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The name of the configuration archive that was previously uploaded by 
        /// Publish-AzureRmVMDSCConfiguration. This parameter must specify only the name 
        /// of the file, without any path.
        /// A null value or empty string indicate that the VM extension should install DSC,
        /// but not start any configuration
        /// </summary>
        [Alias("ConfigurationArchiveBlob")]
        [Parameter(
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureBlobDscExtensionParamSet,
            HelpMessage = "The name of the configuration file that was previously uploaded by Publish-AzureRmVMDSCConfiguration")]
        [AllowEmptyString]
        [AllowNull]
        public string ArchiveBlobName { get; set; }

        /// <summary>
        /// The Azure Storage Account name used to upload the configuration script to the container specified by ArchiveContainerName. 
        /// </summary>
        [Alias("StorageAccountName")]
        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureBlobDscExtensionParamSet,
            HelpMessage = "The Azure Storage Account name used to download the ArchiveBlobName")]
        [ValidateNotNullOrEmpty]
        public String ArchiveStorageAccountName { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = AzureBlobDscExtensionParamSet,
           HelpMessage = "The name of the resource group that contains the storage account containing the configuration archive. " +
                         "This param is optional if storage account and virtual machine both exists in the same resource group name, " +
                         "specified by ResourceGroupName param.")]
        [ValidateNotNullOrEmpty]
        public string ArchiveResourceGroupName { get; set; }

        /// <summary>
        /// The DNS endpoint suffix for all storage services, e.g. "core.windows.net".
        /// </summary>
        [Alias("StorageEndpointSuffix")]
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureBlobDscExtensionParamSet,
            HelpMessage = "The Storage Endpoint Suffix.")]
        [ValidateNotNullOrEmpty]
        public string ArchiveStorageEndpointSuffix { get; set; }

        /// <summary>
        /// Name of the Azure Storage Container where the configuration script is located.
        /// </summary>
        [Alias("ContainerName")]
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AzureBlobDscExtensionParamSet,
            HelpMessage = "Name of the Azure Storage Container where the configuration archive is located")]
        [ValidateNotNullOrEmpty]
        public string ArchiveContainerName { get; set; }

        /// <summary>
        /// Name of the configuration that will be invoked by the DSC Extension. The value of this parameter should be the name of one of the configurations 
        /// contained within the file specified by ArchiveBlobName.
        /// 
        /// If omitted, this parameter will default to the name of the file given by the ArchiveBlobName parameter, excluding any extension, for example if 
        /// ArchiveBlobName is "SalesWebSite.ps1", the default value for ConfigurationName will be "SalesWebSite".
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the configuration that will be invoked by the DSC Extension")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationName { get; set; }

        /// <summary>
        /// A hashtable specifying the arguments to the ConfigurationFunction. The keys 
        /// correspond to the parameter names and the values to the parameter values.
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable specifying the arguments to the ConfigurationFunction")]
        [ValidateNotNullOrEmpty]
        public Hashtable ConfigurationArgument { get; set; }

        /// <summary>
        /// Path to a .psd1 file that specifies the data for the Configuration. This 
        /// file must contain a hashtable with the items described in 
        /// http://technet.microsoft.com/en-us/library/dn249925.aspx.
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a .psd1 file that specifies the data for the Configuration")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationData { get; set; }

        /// <summary>
        /// The specific version of the DSC extension that Set-AzureRmVMDSCExtension will 
        /// apply the settings to. 
        /// </summary>
        [Alias("HandlerVersion")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the DSC extension that Set-AzureRmVMDSCExtension will apply the settings to. " +
                          "Allowed format N.N")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        /// <summary>
        /// By default Set-AzureRmVMDscExtension will not overwrite any existing blobs. Use -Force to overwrite them.
        /// </summary>
        [Parameter(
            HelpMessage = "Use this parameter to overwrite any existing blobs")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the resource.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// We install the extension handler version specified by the version param. By default extension handler is not autoupdated. 
        /// Use -AutoUpdate to enable auto update of extension handler to the latest version as and when it is available. 
        /// </summary>
        [Parameter(
            HelpMessage = "Extension handler gets auto updated to the latest version if this switch is present.")]
        public SwitchParameter AutoUpdate { get; set; }

        /// <summary>
        /// Specifies the version of the Windows Management Framework (WMF) to install 
        /// on the VM.
        ///
        /// The DSC Azure Extension depends on DSC features that are only available in 
        /// the WMF updates. This parameter specifies which version of the update to 
        /// install on the VM. The possible values are "4.0","5.0" ,"5.1PP" and "latest".  
        /// 
        /// A value of "4.0" will install WMF 4.0 Update packages 
        /// (https://support.microsoft.com/en-us/kb/3119938) on Windows 8.1 or Windows Server 
        /// 2012 R2, or  
        /// (https://support.microsoft.com/en-us/kb/3109118) on Windows Server 2008 R2 
        /// and on other versions of Windows if newer version is not already installed.
        /// 
        /// A value of "5.0" will install the latest release of WMF 5.0 
        /// (https://www.microsoft.com/en-us/download/details.aspx?id=50395).
        /// 
        /// A value of "5.1PP" will install the WMF 5.1 preview
        /// (https://www.microsoft.com/en-us/download/details.aspx?id=53347).
        /// 
        /// A value of "latest" will install the latest WMF, currently WMF 5.0
        /// 
        /// The default value is "latest"
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateSetAttribute(new[] { "4.0", "5.0", "5.1PP", "latest" })]
        public string WmfVersion { get; set; }

        /// <summary>
        /// The Extension Data Collection state
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enables or Disables Data Collection in the extension.  It is enabled if it is not specified.  " +
            "The value is persisted in the extension between calls.")
        ]
        [ValidateSet("Enable", "Disable")]
        [AllowNull]
        public string DataCollection { get; set; }

        //Private Variables
        private const string VersionRegexExpr = @"^(([0-9])\.)\d+$";

        /// <summary>
        /// Credentials used to access Azure Storage
        /// </summary>
        private StorageCredentials _storageCredentials;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ValidateParameters();

            CreateConfiguration();
        }

        //Private Methods
        private void ValidateParameters()
        {
            if (string.IsNullOrEmpty(ArchiveBlobName))
            {
                if (ConfigurationName != null || ConfigurationArgument != null
                    || ConfigurationData != null)
                {
                    this.ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscNullArchiveNoConfiguragionParameters);
                }
                if (ArchiveContainerName != null || ArchiveStorageEndpointSuffix != null)
                {
                    this.ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscNullArchiveNoStorageParameters);
                }
            }
            else
            {
                if (string.Compare(
                    Path.GetFileName(ArchiveBlobName),
                    ArchiveBlobName,
                    StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    this.ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscConfigurationDataFileShouldNotIncludePath);
                }

                if (ConfigurationData != null)
                {
                    ConfigurationData = GetUnresolvedProviderPathFromPSPath(ConfigurationData);

                    if (!File.Exists(ConfigurationData))
                    {
                        this.ThrowInvalidArgumentError(
                            Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscCannotFindConfigurationDataFile,
                            ConfigurationData);
                    }
                    if (string.Compare(
                        Path.GetExtension(ConfigurationData),
                        ".psd1",
                        StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        this.ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscInvalidConfigurationDataFile);
                    }
                }

                if (ArchiveResourceGroupName == null)
                {
                    ArchiveResourceGroupName = ResourceGroupName;
                }

                _storageCredentials = this.GetStorageCredentials(ArchiveResourceGroupName, ArchiveStorageAccountName);

                if (ConfigurationName == null)
                {
                    ConfigurationName = Path.GetFileNameWithoutExtension(ArchiveBlobName);
                }

                if (ArchiveContainerName == null)
                {
                    ArchiveContainerName = DscExtensionCmdletConstants.DefaultContainerName;
                }

                if (ArchiveStorageEndpointSuffix == null)
                {
                    ArchiveStorageEndpointSuffix =
                        DefaultProfile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix);
                }

                if (!(Regex.Match(Version, VersionRegexExpr).Success))
                {
                    this.ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscExtensionInvalidVersion);
                }
            }
        }

        private void CreateConfiguration()
        {
            var publicSettings = new DscExtensionPublicSettings();
            var privateSettings = new DscExtensionPrivateSettings();

            if (!string.IsNullOrEmpty(ArchiveBlobName))
            {
                ConfigurationUris configurationUris = UploadConfigurationDataToBlob();

                publicSettings.SasToken = configurationUris.SasToken;
                publicSettings.ModulesUrl = configurationUris.ModulesUrl;

                Hashtable privacySetting = new Hashtable();
                privacySetting.Add("DataCollection", DataCollection);
                publicSettings.Privacy = privacySetting;

                publicSettings.ConfigurationFunction = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}\\{1}",
                    Path.GetFileNameWithoutExtension(ArchiveBlobName),
                    ConfigurationName);
                Tuple<DscExtensionPublicSettings.Property[], Hashtable> settings =
                    DscExtensionSettingsSerializer.SeparatePrivateItems(ConfigurationArgument);
                publicSettings.Properties = settings.Item1;
                privateSettings.Items = settings.Item2;

                privateSettings.DataBlobUri = configurationUris.DataBlobUri;

                if (!string.IsNullOrEmpty(WmfVersion))
                {
                    publicSettings.WmfVersion = WmfVersion;
                }
            }

            if (string.IsNullOrEmpty(this.Location))
            {
                this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
            }

            var parameters = new VirtualMachineExtension
            {
                Location = this.Location,
                Publisher = DscExtensionCmdletConstants.ExtensionPublishedNamespace,
                VirtualMachineExtensionType = DscExtensionCmdletConstants.ExtensionPublishedName,
                TypeHandlerVersion = Version,
                // Define the public and private property bags that will be passed to the extension.
                Settings = publicSettings,
                //PrivateConfuguration contains sensitive data in a plain text
                ProtectedSettings = privateSettings,
                AutoUpgradeMinorVersion = AutoUpdate.IsPresent
            };

            //Add retry logic due to CRP service restart known issue CRP bug: 3564713
            var count = 1;
            Rest.Azure.AzureOperationResponse<VirtualMachineExtension> op = null;

            while (true)
            {
                try
                {
                    op = VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                        ResourceGroupName,
                        VMName,
                        Name ?? DscExtensionCmdletConstants.ExtensionPublishedNamespace + "." + DscExtensionCmdletConstants.ExtensionPublishedName,
                        parameters).GetAwaiter().GetResult();

                    break;
                }
                catch (Rest.Azure.CloudException ex)
                {
                    var errorReturned = JsonConvert.DeserializeObject<PSComputeLongRunningOperation>(
                        ex.Response.Content);

                    if ("Failed".Equals(errorReturned.Status)
                        && errorReturned.Error != null && "InternalExecutionError".Equals(errorReturned.Error.Code))
                    {
                        count++;
                        if (count <= 2)
                        {
                            continue;
                        }
                    }

                    ThrowTerminatingError(new ErrorRecord(ex, "InvalidResult", ErrorCategory.InvalidResult, null));
                }
            }

            var result = Mapper.Map<PSAzureOperationResponse>(op);
            WriteObject(result);
        }

        /// <summary>
        /// Uploading configuration data to blob storage.
        /// </summary>
        /// <returns>ConfigurationUris collection that represent artifacts of uploading</returns>
        private ConfigurationUris UploadConfigurationDataToBlob()
        {
            //
            // Get a reference to the container in blob storage
            //
            var storageAccount = new CloudStorageAccount(_storageCredentials, ArchiveStorageEndpointSuffix, true);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var containerReference = blobClient.GetContainerReference(ArchiveContainerName);

            //
            // Get a reference to the configuration blob and create a SAS token to access it
            //
            var blobAccessPolicy = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime =
                    DateTime.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Delete
            };

            var configurationBlobName = ArchiveBlobName;
            var configurationBlobReference = containerReference.GetBlockBlobReference(configurationBlobName);
            var configurationBlobSasToken = configurationBlobReference.GetSharedAccessSignature(blobAccessPolicy);

            //
            // Upload the configuration data to blob storage and get a SAS token
            //
            string configurationDataBlobUri = null;

            if (ConfigurationData != null)
            {
                var guid = Guid.NewGuid();
                // there may be multiple VMs using the same configuration

                var configurationDataBlobName = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}-{1}.psd1",
                    ConfigurationName,
                    guid);

                var configurationDataBlobReference =
                    containerReference.GetBlockBlobReference(configurationDataBlobName);

                ConfirmAction(
                    true,
                    string.Empty,
                    string.Format(
                        CultureInfo.CurrentUICulture,
                        Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscUploadToBlobStorageAction,
                        ConfigurationData),
                    configurationDataBlobReference.Uri.AbsoluteUri,
                    () =>
                    {
                        if (!Force && configurationDataBlobReference.Exists())
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(
                                    new UnauthorizedAccessException(
                                        string.Format(
                                            CultureInfo.CurrentUICulture,
                                            Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscStorageBlobAlreadyExists,
                                            configurationDataBlobName)),
                                    "StorageBlobAlreadyExists",
                                    ErrorCategory.PermissionDenied,
                                    null));
                        }

                        configurationDataBlobReference.UploadFromFile(ConfigurationData, FileMode.Open);

                        var configurationDataBlobSasToken =
                            configurationDataBlobReference.GetSharedAccessSignature(blobAccessPolicy);

                        configurationDataBlobUri =
                            configurationDataBlobReference.StorageUri.PrimaryUri.AbsoluteUri
                            + configurationDataBlobSasToken;
                    });
            }
            return new ConfigurationUris
            {
                ModulesUrl = configurationBlobReference.StorageUri.PrimaryUri.AbsoluteUri,
                SasToken = configurationBlobSasToken,
                DataBlobUri = configurationDataBlobUri
            };
        }

        /// <summary>
        /// Class represent info about uploaded Configuration.
        /// </summary>
        private class ConfigurationUris
        {
            public string SasToken { get; set; }
            public string DataBlobUri { get; set; }
            public string ModulesUrl { get; set; }
        }
    }
}

