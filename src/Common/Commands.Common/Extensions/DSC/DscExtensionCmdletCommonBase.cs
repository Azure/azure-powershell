using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Exceptions;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;


namespace Microsoft.WindowsAzure.Commands.Common.Extension.DSC
{
    public class DscExtensionCmdletCommonBase : PSCmdlet
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
                                Properties.Resources.PublishVMDscExtensionRequiredPsVersion, 
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
                    Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileNotExist,
                    configurationPath);
            }

            var configurationFileExtension = Path.GetExtension(configurationPath);

            if (paramaterSetName == UploadArchiveParameterSetName)
            {
                // Check that ConfigurationPath points to a valid file
                /** TODO: This is repetition. Remove this
                if (!File.Exists(ConfigurationPath))
                {
                    this.ThrowInvalidArgumentError(Resources.PublishVMDscExtensionConfigFileNotFound, ConfigurationPath);
                }
                 **/

                if (!DscExtensionCmdletConstants.UploadArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionUploadArchiveConfigFileInvalidExtension, configurationPath);
                }

                
            }
            else if (paramaterSetName == CreateArchiveParameterSetName)
            {
                if (!DscExtensionCmdletConstants.CreateArchiveAllowedFileExtensions.Contains(Path.GetExtension(configurationFileExtension)))
                {
                    ThrowInvalidArgumentError(Properties.Resources.PublishVMDscExtensionCreateArchiveConfigFileInvalidExtension, configurationPath);
                }
            }
        }

        public string CreateConfigurationArchive(
            String configurationPath,
            String configurationArchivePath,
            Boolean force,
            String parameterSetName)
        {
            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscParsingConfiguration, configurationPath));
            ConfigurationParseResult parseResult = null;
            try
            {
                parseResult = ConfigurationParsingHelper.ParseConfiguration(configurationPath);
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

            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, 
                Properties.Resources.PublishVMDscExtensionRequiredModulesVerbose, String.Join(", ", requiredModules)));

            // Create a temporary directory for uploaded zip file
            var tempZipFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            WriteVerbose(String.Format(CultureInfo.CurrentUICulture, Properties.Resources.PublishVMDscExtensionTempFolderVerbose, tempZipFolder));
            Directory.CreateDirectory(tempZipFolder);
            _temporaryDirectoriesToDelete.Add(tempZipFolder);

            // CopyConfiguration
            var configurationName = Path.GetFileName(configurationPath);
            var configurationDestination = Path.Combine(tempZipFolder, configurationName);
            WriteVerbose(String.Format(
                CultureInfo.CurrentUICulture,
                Properties.Resources.PublishVMDscExtensionCopyFileVerbose,
                configurationPath,
                configurationDestination));
            File.Copy(configurationPath, configurationDestination);

            // CopyRequiredModules
            foreach (var module in requiredModules)
            {
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
            if (parameterSetName == CreateArchiveParameterSetName)
            {
                archive = configurationArchivePath;

                if (!force && File.Exists(archive))
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
            String configurationArchivePath,
            Boolean force,
            StorageCredentials storageCredentials,
            String containerName,
            String parameterSetName)
        {
            if (parameterSetName == CreateArchiveParameterSetName)
            {
                ConfirmAction(
                    true,
                    string.Empty,
                    Properties.Resources.AzureVMDscCreateArchiveAction,
                    configurationArchivePath, () => CreateConfigurationArchive(
                        configurationPath,
                        configurationArchivePath,
                        force,
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
                        configurationArchivePath,
                        force,
                        parameterSetName);

                UploadConfigurationArchive(storageCredentials, containerName, archivePath, force);
            }
        }

        private void UploadConfigurationArchive(
            StorageCredentials storageCredentials, 
            String containerName, 
            String archivePath,
            Boolean force)
        {
            CloudBlockBlob modulesBlob = 
                GetBlobReference(storageCredentials, containerName, archivePath);

            ConfirmAction(
                true,
                string.Empty,
                string.Format(CultureInfo.CurrentUICulture, Properties.Resources.AzureVMDscUploadToBlobStorageAction, archivePath),
                modulesBlob.Uri.AbsoluteUri, () =>
                {
                    if (!force && modulesBlob.Exists())
                    {
                        ThrowTerminatingError(
                            new ErrorRecord(
                                new UnauthorizedAccessException(
                                    string.Format(
                                        CultureInfo.CurrentUICulture, 
                                        Properties.Resources.AzureVMDscStorageBlobAlreadyExists, modulesBlob.Uri.AbsoluteUri)),
                                "StorageBlobAlreadyExists",
                                ErrorCategory.PermissionDenied,
                                null));
                    }

                    modulesBlob.UploadFromFile(archivePath, FileMode.Open);

                    WriteVerbose(string.Format(
                        CultureInfo.CurrentUICulture, 
                        Properties.Resources.PublishVMDscExtensionArchiveUploadedMessage, modulesBlob.Uri.AbsoluteUri));
                });
        }

        public void DeleteTemporaryFiles()
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

        private CloudBlockBlob GetBlobReference(StorageCredentials storageCredentials, String containerName, String archivePath)
        {
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer containerReference = blobClient.GetContainerReference(containerName);
            containerReference.CreateIfNotExists();

            var blobName = Path.GetFileName(archivePath);

            return containerReference.GetBlockBlobReference(blobName);
        }

        /// <summary>
        /// Asks for confirmation before executing the action.
        /// </summary>
        /// <param name="force">Do not ask for confirmation</param>
        /// <param name="actionMessage">Message to describe the action</param>
        /// <param name="processMessage">Message to prompt after the active is performed.</param>
        /// <param name="target">The target name.</param>
        /// <param name="action">The action code</param>
        private void ConfirmAction(bool force, string actionMessage, string processMessage, string target, Action action)
        {
            if (force || ShouldContinue(actionMessage, ""))
            {
                if (ShouldProcess(target, processMessage))
                {
                    action();
                }
            }
        }

        private void ThrowInvalidArgumentError(String format, params object[] args)
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
