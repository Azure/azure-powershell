using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Exceptions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish
{
    public class DscExtensionPublishCmdletCommonBase : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        //Publish
        private const string CreateArchiveParameterSetName = "CreateArchive";
        private const string UploadArchiveParameterSetName = "UploadArchive";
        private readonly List<string> _temporaryFilesToDelete = new List<string>();
        private readonly List<string> _temporaryDirectoriesToDelete = new List<string>();

        public void ValidatePsVersion()
        {
            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.AddScript("$PSVersionTable.PSVersion.Major");
                int major = powershell.Invoke<int>().FirstOrDefault();
                if (major < DscExtensionCmdletConstants.MinMajorPowerShellVersion)
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new InvalidOperationException(
                                string.Format(
                                CultureInfo.CurrentUICulture,
                                Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionRequiredPsVersion,
                                DscExtensionCmdletConstants.MinMajorPowerShellVersion,
                                major)),
                            "InvalidPowerShellVersion",
                            ErrorCategory.InvalidOperation,
                            null));
                }
            }
        }

        public void ValidateConfigurationPath(String configurationPath, String paramaterSetName)
        {
            if (!File.Exists(configurationPath))
            {
                ThrowInvalidArgumentError(
                    Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileNotExist,
                    configurationPath);
            }

            var configurationFileExtension = Path.GetExtension(configurationPath);

            if (paramaterSetName == UploadArchiveParameterSetName)
            {
                if (!DscExtensionCmdletConstants.UploadArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileInvalidExtension, configurationPath);
                }
            }
            else if (paramaterSetName == CreateArchiveParameterSetName)
            {
                if (!DscExtensionCmdletConstants.CreateArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionCreateArchiveConfigFileInvalidExtension, configurationPath);
                }
            }
        }

        public void ValidateConfigurationDataPath(String configurationDataPath)
        {
            if (!File.Exists(configurationDataPath))
            {
                ThrowInvalidArgumentError(
                    Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscCannotFindConfigurationDataFile,
                    configurationDataPath);
            }
            if (string.Compare(
                Path.GetExtension(configurationDataPath),
                ".psd1",
                StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                ThrowInvalidArgumentError(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscInvalidConfigurationDataFile);
            }
        }

        public string CreateConfigurationArchive(
            String configurationPath,
            String configurationDataPath,
            String[] additionalPath,
            String configurationArchivePath,
            Boolean force,
            Boolean skipDependencyDetection,
            String parameterSetName)
        {
            var metadata = new Dictionary<string, object>();
            // Create a temporary directory for uploaded zip file
            var tempZipFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            WriteVerbose(String.Format(
                CultureInfo.CurrentUICulture,
                Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionTempFolderVerbose,
                tempZipFolder));
            Directory.CreateDirectory(tempZipFolder);
            _temporaryDirectoriesToDelete.Add(tempZipFolder);

            // Copy Configuration
            var configurationName = Path.GetFileName(configurationPath);
            var configurationDestination = Path.Combine(tempZipFolder, configurationName);
            CopyFileToZipFolder(configurationPath, configurationDestination);

            //copy configuration data if available
            if (configurationDataPath != null)
            {
                var configurationDataName = Path.GetFileName(configurationDataPath);
                var configurationDataDestination = Path.Combine(tempZipFolder, configurationDataName);
                metadata.Add("ConfigurationData", configurationDataName);
                CopyFileToZipFolder(configurationDataPath, configurationDataDestination);
            }

            //copy additional content if available
            if (additionalPath != null && additionalPath.Length > 0)
            {
                var additionalContentMetadata = new List<string>();
                foreach (var contentPath in additionalPath)
                {
                    CopyAdditionalContent(contentPath, tempZipFolder, additionalContentMetadata);
                }
                metadata.Add("AdditionalContent", additionalContentMetadata);
            }

            //Copy required modules when -SkipDependencyDetection switch is not present
            if (!skipDependencyDetection)
            {
                var metadataModules = CopyRequiredModules(configurationPath, tempZipFolder);
                if (metadataModules != null)
                {
                    metadata.Add("Modules", metadataModules);
                }
            }

            //copy metadata info

            var metadataJson = JsonConvert.SerializeObject(metadata);
            const string metadataFileName = "dscmetadata.json";
            var metadataDestPath = Path.Combine(tempZipFolder, metadataFileName);
            File.WriteAllText(metadataDestPath, metadataJson);

            //
            // Zip the directory
            //
            string archive;
            if (parameterSetName == CreateArchiveParameterSetName)
            {
                archive = configurationArchivePath;

                if (!force && File.Exists(archive))
                {
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new UnauthorizedAccessException(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscArchiveAlreadyExists, archive)),
                            "FileAlreadyExists",
                            ErrorCategory.PermissionDenied,
                            null));
                }
            }
            else
            {
                string tempArchiveFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionTempFolderVerbose, tempArchiveFolder));
                Directory.CreateDirectory(tempArchiveFolder);
                _temporaryDirectoriesToDelete.Add(tempArchiveFolder);
                archive = Path.Combine(tempArchiveFolder, configurationName + DscExtensionCmdletConstants.ZipFileExtension);
                _temporaryFilesToDelete.Add(archive);
            }

            if (File.Exists(archive))
            {
                File.Delete(archive);
            }

            ZipFile.CreateFromDirectory(tempZipFolder, archive);

            return archive;
        }

        /// <summary>
        /// Publish the configuration and its modules
        /// </summary>
        public void PublishConfiguration(
            String configurationPath,
            String configurationDataPath,
            String[] additionalPath,
            String outputArchivePath,
            String storageEndpointSuffix,
            String containerName,
            String parameterSetName,
            Boolean force,
            Boolean skipDependencyDetection,
            StorageCredentials storageCredentials,
            Boolean passThru = true)
        {
            if (parameterSetName == CreateArchiveParameterSetName)
            {
                ConfirmAction(
                    true,
                    string.Empty,
                    Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscCreateArchiveAction,
                    outputArchivePath, () => CreateConfigurationArchive(
                        configurationPath,
                        configurationDataPath,
                        additionalPath,
                        outputArchivePath,
                        force,
                        skipDependencyDetection,
                        parameterSetName));
            }
            else
            {
                var archivePath = string.Compare(
                    Path.GetExtension(configurationPath),
                    DscExtensionCmdletConstants.ZipFileExtension,
                    StringComparison.OrdinalIgnoreCase) == 0
                    ? configurationPath
                    : CreateConfigurationArchive(
                        configurationPath,
                        configurationDataPath,
                        additionalPath,
                        outputArchivePath,
                        force,
                        skipDependencyDetection,
                        parameterSetName);

                UploadConfigurationArchive(storageCredentials, storageEndpointSuffix, containerName, archivePath, force, passThru);
            }
        }

        private List<string> CopyRequiredModules(String configurationPath, String tempZipFolder)
        {
            WriteVerbose(
                    String.Format(
                        CultureInfo.CurrentUICulture,
                        Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscParsingConfiguration,
                        configurationPath));

            var requiredModules = GetRequiredModules(configurationPath);
            var metadataModules = new List<string>();

            foreach (var module in requiredModules)
            {
                metadataModules.Add(module.Key);
                using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                {
                    // Wrapping script in a function to prevent script injection via $module variable.
                    powershell.AddScript(
                        @"function Copy-Module([string]$moduleName, [string]$moduleVersion, [string]$tempZipFolder) 
                        {
                            if([String]::IsNullOrEmpty($moduleVersion))
                            {
                                $module = Get-Module -List -Name $moduleName                                
                            }
                            else
                            {
                                $module = (Get-Module -List -Name $moduleName) | Where-Object{$_.Version -eq $moduleVersion}
                            }
                            
                            $moduleFolder = Split-Path $module.Path
                            Copy-Item -Recurse -Path $moduleFolder -Destination ""$tempZipFolder\$($module.Name)""
                        }"
                            );
                    powershell.Invoke();
                    powershell.Commands.Clear();
                    powershell.AddCommand("Copy-Module")
                        .AddParameter("moduleName", module.Key)
                        .AddParameter("moduleVersion", module.Value)
                        .AddParameter("tempZipFolder", tempZipFolder);
                    WriteVerbose(String.Format(
                        CultureInfo.CurrentUICulture,
                            Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionCopyModuleVerbose,
                            module,
                            tempZipFolder));
                    powershell.Invoke();
                }
            }

            return metadataModules;
        }

        private void CopyAdditionalContent(String additionalPath, String tempZipFolder, List<string> additionalContentMetadata)
        {
            try
            {
                if (PathIsAFile(additionalPath))
                {
                    var additionalFileName = Path.GetFileName(additionalPath);
                    var additionalFileDestination = Path.Combine(tempZipFolder, additionalFileName);
                    additionalContentMetadata.Add(additionalFileName);
                    CopyFileToZipFolder(additionalPath, additionalFileDestination);
                }
                else
                {
                    var dir = new DirectoryInfo(additionalPath);
                    if (!dir.Exists)
                    {
                        ThrowInvalidArgumentError(
                        Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionDirectoryNotExist,
                        dir);
                    }

                    var dirName = dir.Name;
                    additionalContentMetadata.Add(dirName);
                    var dirDestination = Path.Combine(tempZipFolder, dirName);

                    CopyDirectory(dirDestination, dir);
                }
            }
            catch (Exception)
            {
                ThrowInvalidArgumentError(
                    Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionAdditionalContentPathNotExist,
                    additionalPath);
            }
        }

        private void CopyDirectory(String destDirPath, DirectoryInfo dir)
        {
            //if the destination directory does not exist create it
            if (!Directory.Exists(destDirPath))
            {
                Directory.CreateDirectory(destDirPath);
            }

            //get the files in the directory and copy them to the tempzipfolder location
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var temppath = Path.Combine(destDirPath, file.Name);
                file.CopyTo(temppath, true);
            }

            //copy subdirectories
            var dirs = dir.GetDirectories();
            foreach (var subdir in dirs)
            {
                var temppath = Path.Combine(destDirPath, subdir.Name);
                CopyDirectory(temppath, subdir);
            }
        }

        private Dictionary<string, string> GetRequiredModules(String configurationPath)
        {
            ConfigurationParseResult parseResult = null;
            try
            {
                parseResult = ConfigurationParsingHelper.ParseConfiguration(configurationPath);
            }
            catch (GetDscResourceException e)
            {
                ThrowTerminatingError(
                    new ErrorRecord(e, "CannotAccessDscResource", ErrorCategory.PermissionDenied, null));
            }

            if (parseResult.Errors.Any())
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new ParseException(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionStorageParserErrors,
                                configurationPath,
                                String.Join("\n", parseResult.Errors.Select(error => error.ToString())))),
                        "DscConfigurationParseError",
                        ErrorCategory.ParserError,
                        null));
            }

            var requiredModules = parseResult.RequiredModules;
            //Since LCM always uses the latest module there is no need to copy PSDesiredStateConfiguration
            if (requiredModules.ContainsKey("PSDesiredStateConfiguration"))
            {
                requiredModules.Remove("PSDesiredStateConfiguration");
            }

            WriteVerbose(String.Format(
                CultureInfo.CurrentUICulture,
                Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionRequiredModulesVerbose,
                String.Join(", ", requiredModules)));

            return requiredModules;
        }

        private void UploadConfigurationArchive(
            StorageCredentials storageCredentials,
            String storageEndpointSuffix,
            String containerName,
            String archivePath,
            Boolean force,
            Boolean passThru)
        {
            CloudBlockBlob modulesBlob =
                GetBlobReference(storageCredentials, storageEndpointSuffix, containerName, archivePath);

            ConfirmAction(
                true,
                string.Empty,
                string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscUploadToBlobStorageAction, archivePath),
                modulesBlob.Uri.AbsoluteUri, () =>
                {
                    if (!force && modulesBlob.Exists())
                    {
                        ThrowTerminatingError(
                            new ErrorRecord(
                                new UnauthorizedAccessException(
                                    string.Format(
                                        CultureInfo.CurrentUICulture,
                                        Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscStorageBlobAlreadyExists, modulesBlob.Uri.AbsoluteUri)),
                                "StorageBlobAlreadyExists",
                                ErrorCategory.PermissionDenied,
                                null));
                    }

                    modulesBlob.UploadFromFile(archivePath, FileMode.Open);

                    WriteVerbose(string.Format(
                        CultureInfo.CurrentUICulture,
                        Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionArchiveUploadedMessage, modulesBlob.Uri.AbsoluteUri));

                    if (passThru)
                    {
                        WriteObject(modulesBlob.Uri.AbsoluteUri);
                    }
                });
        }

        private void CopyFileToZipFolder(String source, string destination)
        {
            WriteVerbose(String.Format(
                CultureInfo.CurrentUICulture,
                Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionCopyFileVerbose,
                source,
                destination));
            File.Copy(source, destination);
        }

        private Boolean PathIsAFile(String path)
        {
            var attributes = File.GetAttributes(path);
            return !attributes.HasFlag(FileAttributes.Directory);
        }

        public void DeleteTemporaryFiles()
        {
            foreach (var file in _temporaryFilesToDelete)
            {
                try
                {
                    DeleteFile(file);
                    WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionDeletedFileMessage, file));
                }
                catch (Exception e)
                {
                    WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionDeleteErrorMessage, file, e.Message));
                }
            }
            foreach (var directory in _temporaryDirectoriesToDelete)
            {
                try
                {
                    DeleteDirectory(directory);
                    WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionDeletedFileMessage, directory));
                }
                catch (Exception e)
                {
                    WriteVerbose(string.Format(CultureInfo.CurrentUICulture, Microsoft.Azure.Commands.Compute.Properties.Resources.PublishVMDscExtensionDeleteErrorMessage, directory, e.Message));
                }
            }
        }

        private CloudBlockBlob GetBlobReference(
            StorageCredentials storageCredentials, String storageEndpointSuffix, String containerName, String archivePath)
        {
            var storageAccount = new CloudStorageAccount(storageCredentials, storageEndpointSuffix, true);
            var blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer containerReference = blobClient.GetContainerReference(containerName);
            containerReference.CreateIfNotExists();

            var blobName = Path.GetFileName(archivePath);

            return containerReference.GetBlockBlobReference(blobName);
        }

        protected void ThrowInvalidArgumentError(String format, params object[] args)
        {
            ThrowTerminatingError(
                new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.CurrentUICulture, format, args)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
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
        /// Turns off the ReadOnly attribute from the given file and then attempts to delete it
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
        /// Recursively turns off the ReadOnly attribute from the given directory and then attemps to delete it
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
