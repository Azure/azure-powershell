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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{

    [Cmdlet(
        VerbsCommon.Set,
        DscExtensionCmdletCommonBase.VirtualMachineDscExtensionCmdletNoun, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(IPersistentVM))]
    public class SetAzureVMDscExtension : VirtualMachineExtensionCmdletBase
    {
        /// <summary>
        /// The Extension Reference Name
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The Extension Reference Name")]
        [ValidateNotNullOrEmpty]
        public override string ReferenceName { get; set; }

        /// <summary>
        /// A hashtable specifying the arguments to the ConfigurationFunction. The keys 
        /// correspond to the parameter names and the values to the parameter values.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable specifying the arguments to the ConfigurationFunction")]
        [ValidateNotNullOrEmpty]
        public Hashtable ConfigurationArgument { get; set; }

        /// <summary>
        /// Path to a .psd1 file that specifies the data for the Configuration. This 
        /// file must contain a hashtable with the items described in 
        /// http://technet.microsoft.com/en-us/library/dn249925.aspx.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to a .psd1 file that specifies the data for the Configuration")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationDataPath { get; set; }

        /// <summary>
        /// The name of the configuration archive that was previously uploaded by 
        /// Publish-AzureVMDSCConfiguration. This parameter must specify only the name 
        /// of the file, without any path.
        /// A null value or empty string indicate that the VM extension should install DSC,
        /// but not start any configuration
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The name of the configuration file that was previously uploaded by Publish-AzureVMDSCConfiguration")]
        [AllowEmptyString]
        [AllowNull]
        public string ConfigurationArchive { get; set; }

        /// <summary>
        /// Name of the configuration that will be invoked by the DSC Extension. The value of this parameter should be the name of one of the configurations 
        /// contained within the file specified by ConfigurationArchive.
        /// 
        /// If omitted, this parameter will default to the name of the file given by the ConfigurationArchive parameter, excluding any extension, for example if 
        /// ConfigurationArchive is "SalesWebSite.ps1", the default value for ConfigurationName will be "SalesWebSite".
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the configuration that will be invoked by the DSC Extension")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Name of the Azure Storage Container where the configuration script is located.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = " Name of the Azure Storage Container where the configuration script is located")]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        /// <summary>
        /// By default Set-AzureVMDscExtension will not overwrite any existing blobs. Use -Force to overwrite them.
        /// </summary>
        [Parameter(HelpMessage = "Use this parameter to overwrite any existing blobs")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// The Azure Storage Context that provides the security settings used to access the configuration script. This context should provide read access to the 
        /// container specified by ContainerName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The Azure Storage Context that provides the security settings used to access the configuration script")
        ]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext { get; set; }

        /// <summary>
        /// The specific version of the DSC extension that Set-AzureVMDSCExtension will 
        /// apply the settings to. If not given, it will default to "1.*"
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the DSC extension that Set-AzureVMDSCExtension will apply the settings to")]
        [ValidateNotNullOrEmpty]
        public override string Version { get; set; }

        /// <summary>
        /// The DNS endpoint suffix for all storage services, e.g. "core.windows.net".
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The Storage Endpoint Suffix.")]
        [ValidateNotNullOrEmpty]
        public string StorageEndpointSuffix { get; set; }

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

        /// <summary>
        /// Credentials used to access Azure Storage
        /// </summary>
        private StorageCredentials _storageCredentials;

        /// <summary>
        /// Class represent info about uploaded Configuration.
        /// </summary>
        private class ConfigurationUris
        {
            public string SasToken { get; set; }
            public string DataBlobUri { get; set; }
            public string ModulesUrl { get; set; }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }

        internal void ExecuteCommand()
        {
            extensionName = DscExtensionCmdletConstants.ExtensionPublishedName;
            publisherName = DscExtensionCmdletConstants.ExtensionPublishedNamespace;

            ValidateParameters();

            CreateConfiguration();

            ConfirmAction(
                true,
                string.Empty,
                string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.AzureVMDscApplyConfigurationAction,
                    ConfigurationName),
                "VM",
                () =>
                    {
                        RemovePredicateExtensions();
                        AddResourceExtension();
                    });

            WriteObject(VM);
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();

            //
            // Validate parameters
            //
            if (string.IsNullOrEmpty(ConfigurationArchive))
            {
                if (ConfigurationName != null || ConfigurationArgument != null
                    || ConfigurationDataPath != null)
                {
                    this.ThrowInvalidArgumentError(Resources.AzureVMDscNullArchiveNoConfiguragionParameters);
                }
                if (StorageContext != null || ContainerName != null || StorageEndpointSuffix != null)
                {
                    this.ThrowInvalidArgumentError(Resources.AzureVMDscNullArchiveNoStorageParameters);
                }
            }
            else
            {
                if (string.Compare(
                    Path.GetFileName(ConfigurationArchive),
                    ConfigurationArchive,
                    StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    this.ThrowInvalidArgumentError(Resources.AzureVMDscConfigurationDataFileShouldNotIncludePath);
                }

                if (ConfigurationDataPath != null)
                {
                    ConfigurationDataPath = GetUnresolvedProviderPathFromPSPath(ConfigurationDataPath);

                    if (!File.Exists(ConfigurationDataPath))
                    {
                        this.ThrowInvalidArgumentError(
                            Resources.AzureVMDscCannotFindConfigurationDataFile,
                            ConfigurationDataPath);
                    }
                    if (string.Compare(
                        Path.GetExtension(ConfigurationDataPath),
                        ".psd1",
                        StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        this.ThrowInvalidArgumentError(Resources.AzureVMDscInvalidConfigurationDataFile);
                    }
                }

                _storageCredentials = this.GetStorageCredentials(StorageContext);

                if (ConfigurationName == null)
                {
                    ConfigurationName = Path.GetFileNameWithoutExtension(ConfigurationArchive);
                }

                if (ContainerName == null)
                {
                    ContainerName = DscExtensionCmdletConstants.DefaultContainerName;
                }

                if (StorageEndpointSuffix == null)
                {
                    StorageEndpointSuffix =
                        Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix);
                }
            }

            if (Version == null)
            {
                Version = DscExtensionCmdletCommonBase.DefaultExtensionVersion;
            }

            if (ReferenceName == null)
            {
                ReferenceName = DscExtensionCmdletConstants.ExtensionPublishedName;
            }
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
            var storageAccount = string.IsNullOrEmpty(StorageEndpointSuffix)
                                     ? new CloudStorageAccount(_storageCredentials, true)
                                     : new CloudStorageAccount(
                                           _storageCredentials,
                                           StorageEndpointSuffix,
                                           true);

            var blobClient = storageAccount.CreateCloudBlobClient();

            var containerReference = blobClient.GetContainerReference(ContainerName);

            //
            // Get a reference to the configuration blob and create a SAS token to access it
            //
            var blobAccessPolicy = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime =
                    DateTime.UtcNow.AddHours(2),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Delete
            };

            var configurationBlobName = ConfigurationArchive;
            var configurationBlobReference = containerReference.GetBlockBlobReference(configurationBlobName);
            var configurationBlobSasToken = configurationBlobReference.GetSharedAccessSignature(blobAccessPolicy);

            //
            // Upload the configuration data to blob storage and get a SAS token
            //
            string configurationDataBlobUri = null;

            if (ConfigurationDataPath != null)
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
                        Resources.AzureVMDscUploadToBlobStorageAction,
                        ConfigurationDataPath),
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
                                            Resources.AzureVMDscStorageBlobAlreadyExists,
                                            configurationDataBlobName)),
                                    "StorageBlobAlreadyExists",
                                    ErrorCategory.PermissionDenied,
                                    null));
                        }

                        configurationDataBlobReference.UploadFromFile(ConfigurationDataPath, FileMode.Open);

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

        private void CreateConfiguration()
        {
            var publicSettings = new DscExtensionPublicSettings();
            var privateSettings = new DscExtensionPrivateSettings();

            

            if (!string.IsNullOrEmpty(ConfigurationArchive))
            {
                ConfigurationUris configurationUris = UploadConfigurationDataToBlob();

                publicSettings.SasToken = configurationUris.SasToken;
                publicSettings.ModulesUrl = configurationUris.ModulesUrl;
                
                Hashtable privacySetting = new Hashtable();
                privacySetting.Add("DataCollection",DataCollection);
                publicSettings.Privacy = privacySetting;

                publicSettings.ConfigurationFunction = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}\\{1}",
                    Path.GetFileNameWithoutExtension(ConfigurationArchive),
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

            //
            // Define the public and private property bags that will be passed to the extension.
            //
            PublicConfiguration = DscExtensionSettingsSerializer.SerializePublicSettings(publicSettings);
            //
            // PrivateConfuguration contains sensitive data in a plain text.
            //
            PrivateConfiguration = DscExtensionSettingsSerializer.SerializePrivateSettings(privateSettings);
        }
    }
}

