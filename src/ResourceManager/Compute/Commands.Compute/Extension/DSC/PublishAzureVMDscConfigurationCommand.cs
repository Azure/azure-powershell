using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    /// <summary>
    /// Uploads a Desired State Configuration script to Azure blob storage, which 
    /// later can be applied to Azure Virtual Machines using the 
    /// Set-AzureVMDscExtension cmdlet.
    /// </summary>
    [Cmdlet(
        VerbsData.Publish,
        ProfileNouns.VirtualMachineDscConfiguration, 
        SupportsShouldProcess = true, 
        DefaultParameterSetName = UploadArchiveParameterSetName)]
    public class PublishAzureVMDscConfigurationCommand : VirtualMachineDscExtensionBaseCmdlet
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
        /// When using this parameter, Publish-AzureVMDscConfiguration creates a
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
        /// By default Publish-AzureVMDscConfiguration will not overwrite any existing blobs. 
        /// Use -Force to overwrite them.
        /// </summary>
        [Parameter(HelpMessage = "By default Publish-AzureVMDscConfiguration will not overwrite any existing blobs")]
        public SwitchParameter Force { get; set; }


        //Private Variables

        /// <summary>
        /// Credentials used to access Azure Storage
        /// </summary>
        private StorageCredentials _storageCredentials;

        private const string Ps1FileExtension = ".ps1";
        private const string Psm1FileExtension = ".psm1";
        private const string ZipFileExtension = ".zip";

        private static readonly HashSet<String> UploadArchiveAllowedFileExtensions = 
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension, ZipFileExtension };
        private static readonly HashSet<String> CreateArchiveAllowedFileExtensions = 
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension };

        private const int MinMajorPowerShellVersion = 4;

        private readonly List<string> _temporaryFilesToDelete = new List<string>();
        private readonly List<string> _temporaryDirectoriesToDelete = new List<string>();

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            try
            {
                ValidatePsVersion();
                ValidateParameters();
                PublishConfiguration();
            }
            finally
            {
                foreach (var file in _temporaryFilesToDelete)
                {
                    try
                    {
                        DeleteFile(file);
                        WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionDeletedFileMessage, file));
                    }
                    catch (Exception e)
                    {
                        WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionDeleteErrorMessage, file, e.Message));
                    }
                }
                foreach (var directory in _temporaryDirectoriesToDelete)
                {
                    try
                    {
                        DeleteDirectory(directory);
                        WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionDeletedFileMessage, directory));
                    }
                    catch (Exception e)
                    {
                        WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionDeleteErrorMessage, directory, e.Message));
                    }
                }
            }
        }

        protected void ValidatePsVersion()
        {
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.AddScript("$PSVersionTable.PSVersion.Major");
                int major = powershell.Invoke<int>().FirstOrDefault();
                if (major < MinMajorPowerShellVersion)
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new InvalidOperationException(
                                string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionRequiredPsVersion, MinMajorPowerShellVersion, major)),
                            "InvalidPowerShellVersion",
                            ErrorCategory.InvalidOperation,
                            null));
                }
            }
        }

        protected void ValidateParameters()
        {
            ConfigurationPath = GetUnresolvedProviderPathFromPSPath(ConfigurationPath);
            if (!File.Exists(ConfigurationPath))
            {
                ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileNotExist, ConfigurationPath);
            }

            var configurationFileExtension = Path.GetExtension(ConfigurationPath);

            if (ParameterSetName == UploadArchiveParameterSetName)
            {
                // Check that ConfigurationPath points to a valid file
                if (!File.Exists(ConfigurationPath))
                {
                    ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionConfigFileNotFound, ConfigurationPath);
                }
                if (!UploadArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileInvalidExtension, ConfigurationPath);
                }

                _storageCredentials = GetStorageCredentials(ResourceGroupName, StorageAccountName);

                if (ContainerName == null)
                {
                    ContainerName = DefaultContainerName;
                }
            }
            else if (ParameterSetName == CreateArchiveParameterSetName)
            {
                if (!CreateArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionCreateArchiveConfigFileInvalidExtension, ConfigurationPath);
                }

                OutputArchivePath = GetUnresolvedProviderPathFromPSPath(OutputArchivePath);
            }
        }

        /// <summary>
        /// Publish the configuration and its modules
        /// </summary>
        protected void PublishConfiguration()
        {
            if (ParameterSetName == CreateArchiveParameterSetName)
            {
                ConfirmAction(true, string.Empty, Properties.Resources.AzureVMDscCreateArchiveAction, OutputArchivePath, () => CreateConfigurationArchive());
            }
            else
            {
                var archivePath = string.Compare(Path.GetExtension(ConfigurationPath), ZipFileExtension, StringComparison.OrdinalIgnoreCase) == 0 ?
                    ConfigurationPath
                    :
                    CreateConfigurationArchive();

                UploadConfigurationArchive(archivePath);
            }
        }

        //Private Methods
        private string CreateConfigurationArchive()
        {
            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscParsingConfiguration, ConfigurationPath));
            ConfigurationParseResult parseResult = null;
            try
            {
                parseResult = ConfigurationParsingHelper.ParseConfiguration(ConfigurationPath);
            }
            catch (GetDscResourceException e)
            {
                ThrowTerminatingError(new ErrorRecord(e, "CannotAccessDscResource", ErrorCategory.PermissionDenied, null));
            }

            if (parseResult.Errors.Any())
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new ParseException(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Properties.Resources.PublishVMDscExtensionStorageParserErrors,
                                ConfigurationPath,
                                String.Join("\n", parseResult.Errors.Select(error => error.ToString())))),
                        "DscConfigurationParseError",
                        ErrorCategory.ParserError,
                        null));
            }
            List<string> requiredModules = parseResult.RequiredModules;
            //Since LCM always uses the latest module there is no need to copy PSDesiredStateConfiguration
            if (requiredModules.Contains("PSDesiredStateConfiguration"))
            {
                requiredModules.Remove("PSDesiredStateConfiguration");
            }

            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionRequiredModulesVerbose, String.Join(", ", requiredModules)));

            // Create a temporary directory for uploaded zip file
            string tempZipFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionTempFolderVerbose, tempZipFolder));
            Directory.CreateDirectory(tempZipFolder);
            _temporaryDirectoriesToDelete.Add(tempZipFolder);

            // CopyConfiguration
            var configurationName = Path.GetFileName(ConfigurationPath);
            var configurationDestination = Path.Combine(tempZipFolder, configurationName);
            WriteVerbose(String.Format(
                CultureInfo.CurrentUICulture,
                Properties.Resources.PublishVMDscExtensionCopyFileVerbose,
                ConfigurationPath,
                configurationDestination));
            File.Copy(ConfigurationPath, configurationDestination);

            // CopyRequiredModules
            foreach (var module in requiredModules)
            {
                using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                {
                    // Wrapping script in a function to prevent script injection via $module variable.
                    powershell.AddScript(
                        @"function Copy-Module([string]$module, [string]$tempZipFolder) 
                        {
                            $mi = Get-Module -List -Name $module;
                            $moduleFolder = Split-Path $mi.Path;
                            Copy-Item -Recurse -Path $moduleFolder -Destination ""$tempZipFolder\$($mi.Name)""
                        }"
                        );
                    powershell.Invoke();
                    powershell.Commands.Clear();
                    powershell.AddCommand("Copy-Module")
                        .AddParameter("module", module)
                        .AddParameter("tempZipFolder", tempZipFolder);
                    WriteVerbose(String.Format(
                        CultureInfo.CurrentUICulture,
                        Properties.Resources.PublishVMDscExtensionCopyModuleVerbose,
                        module,
                        tempZipFolder));
                    powershell.Invoke();
                }
            }

            //
            // Zip the directory
            //
            string archive;

            if (ParameterSetName == CreateArchiveParameterSetName)
            {
                archive = OutputArchivePath;

                if (!Force && File.Exists(archive))
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new UnauthorizedAccessException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscArchiveAlreadyExists, archive)),
                            "FileAlreadyExists",
                            ErrorCategory.PermissionDenied,
                            null));
                }
            }
            else
            {
                string tempArchiveFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionTempFolderVerbose, tempArchiveFolder));
                Directory.CreateDirectory(tempArchiveFolder);
                _temporaryDirectoriesToDelete.Add(tempArchiveFolder);
                archive = Path.Combine(tempArchiveFolder, configurationName + ZipFileExtension);
                _temporaryFilesToDelete.Add(archive);
            }

            if (File.Exists(archive))
            {
                File.Delete(archive);
            }

            ZipFile.CreateFromDirectory(tempZipFolder, archive);
            return archive;
        }

        private void UploadConfigurationArchive(string archivePath)
        {
            CloudBlobContainer cloudBlobContainer = GetStorageContainer();

            var blobName = Path.GetFileName(archivePath);

            CloudBlockBlob modulesBlob = cloudBlobContainer.GetBlockBlobReference(blobName);

            ConfirmAction(true, string.Empty, string.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscUploadToBlobStorageAction, archivePath), modulesBlob.Uri.AbsoluteUri, () =>
            {
                if (!Force && modulesBlob.Exists())
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new UnauthorizedAccessException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscStorageBlobAlreadyExists, modulesBlob.Uri.AbsoluteUri)),
                            "StorageBlobAlreadyExists",
                            ErrorCategory.PermissionDenied,
                            null));
                }

                modulesBlob.UploadFromFile(archivePath, FileMode.Open);

                WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionArchiveUploadedMessage, modulesBlob.Uri.AbsoluteUri));
            });
        }

        private CloudBlobContainer GetStorageContainer()
        {
            var storageAccount = new CloudStorageAccount(_storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer containerReference = blobClient.GetContainerReference(ContainerName);
            containerReference.CreateIfNotExists();
            return containerReference;
        }

        private static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (UnauthorizedAccessException)
            {
                // the exception may have occurred due to a read-only file
                DeleteReadOnlyFile(path);
            }
        }

        /// <summary>
        /// Turns off the ReadOnly attribute from the given file and then attempt to delete it
        /// </summary>
        private static void DeleteReadOnlyFile(string path)
        {
            var attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) != 0)
            {
                File.SetAttributes(path, attributes & ~FileAttributes.ReadOnly);
            }

            File.Delete(path);
        }

        private static void DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                // the exception may have occurred due to a read-only file or directory
                DeleteReadOnlyDirectory(path);
            }
        }

        /// <summary>
        /// Recusively turns off the ReadOnly attribute from the given directory and then attemps to delete it
        /// </summary>
        private static void DeleteReadOnlyDirectory(string path)
        {
            var directory = new DirectoryInfo(path);

            foreach (var child in directory.GetDirectories())
            {
                DeleteReadOnlyDirectory(child.FullName);
            }

            foreach (var child in directory.GetFiles())
            {
                DeleteReadOnlyFile(child.FullName);
            }

            if ((directory.Attributes & FileAttributes.ReadOnly) != 0)
            {
                directory.Attributes &= ~FileAttributes.ReadOnly;
            }

            directory.Delete();
        }
    }
}
