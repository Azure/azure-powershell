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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.Threading;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common
{
    /// <summary>
    /// Base class for all SFTP cmdlets
    /// </summary>
    public abstract class SftpBaseCmdlet : AzureRMCmdlet
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Gets the cancellation token for long-running operations
        /// </summary>
        protected CancellationToken CmdletCancellationToken { get; private set; }

        protected override void BeginProcessing()
        {
            CmdletCancellationToken = cancellationTokenSource.Token;
            base.BeginProcessing();
            WriteVerbose("Initializing SFTP cmdlet");
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteVerbose("SFTP cmdlet execution completed");
        }

        /// <summary>
        /// Called when the cmdlet is interrupted (Ctrl+C)
        /// </summary>
        protected override void StopProcessing()
        {
            WriteVerbose("SFTP cmdlet cancellation requested");
            cancellationTokenSource.Cancel();
            base.StopProcessing();
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cancellationTokenSource?.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Validate SSH client availability
        /// </summary>
        /// <param name="sshClientFolder">Optional folder containing SSH executables</param>
        protected void ValidateSshClient(string sshClientFolder = null)
        {
            WriteVerbose("Validating SSH client availability");
            
            try
            {
                GetSshClientPath("ssh", sshClientFolder);
                GetSshClientPath("sftp", sshClientFolder);
                GetSshClientPath("ssh-keygen", sshClientFolder);
            }
            catch (Exception ex)
            {
                throw new AzPSInvalidOperationException(
                    $"SSH client validation failed: {ex.Message}. " +
                    SftpConstants.RecommendationSshClientNotFound);
            }
        }

        /// <summary>
        /// Get the path to an SSH client executable
        /// </summary>
        /// <param name="executable">The SSH executable name (ssh, sftp, ssh-keygen)</param>
        /// <param name="sshClientFolder">Optional folder containing SSH executables</param>
        /// <returns>Full path to the executable</returns>
        protected string GetSshClientPath(string executable, string sshClientFolder = null)
        {
            WriteDebug($"Looking for SSH executable: {executable}");

            // If SSH client folder is specified, try that first
            if (!string.IsNullOrEmpty(sshClientFolder))
            {
                string sshPath = Path.Combine(sshClientFolder, executable);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    sshPath += ".exe";
                }

                if (File.Exists(sshPath))
                {
                    WriteDebug($"Found {executable} at: {sshPath}");
                    return sshPath;
                }

                WriteWarning($"Could not find {executable} in provided SSH client folder {sshClientFolder}. " +
                           "Attempting to get pre-installed OpenSSH.");
            }

            // For non-Windows platforms, return the executable name (let PATH resolve it)
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return executable;
            }

            // Windows-specific logic
            return GetWindowsSshClientPath(executable);
        }

        /// <summary>
        /// Get SSH client path on Windows systems
        /// </summary>
        /// <param name="executable">The SSH executable name</param>
        /// <returns>Full path to the executable on Windows</returns>
        private string GetWindowsSshClientPath(string executable)
        {
            string machine = RuntimeInformation.OSArchitecture.ToString();
            WriteDebug($"OS Architecture: {machine}");

            if (!machine.Contains("X64") && !machine.Contains("X86") && !machine.Contains("Arm"))
            {
                throw new AzPSInvalidOperationException($"Unsupported OS architecture: {machine}");
            }

            // Determine system path based on architecture
            bool is64BitOS = RuntimeInformation.OSArchitecture == Architecture.X64 || 
                           RuntimeInformation.OSArchitecture == Architecture.Arm64;
            bool is32BitProcess = RuntimeInformation.ProcessArchitecture == Architecture.X86;
            
            string sysPath = (is64BitOS && is32BitProcess) ? "SysNative" : "System32";

            string systemRoot = Environment.GetEnvironmentVariable("SystemRoot") ?? @"C:\Windows";
            string sshPath = Path.Combine(systemRoot, sysPath, "OpenSSH", $"{executable}.exe");

            WriteDebug($"Process architecture: {RuntimeInformation.ProcessArchitecture}");
            WriteDebug($"OS architecture: {RuntimeInformation.OSArchitecture}");
            WriteDebug($"System Root: {systemRoot}");
            WriteDebug($"Attempting to find {executable} at: {sshPath}");

            if (!File.Exists(sshPath))
            {
                throw new AzPSInvalidOperationException(
                    $"Could not find {executable}.exe at {sshPath}. " +
                    "Make sure OpenSSH is installed correctly: " +
                    "https://docs.microsoft.com/en-us/windows-server/administration/openssh/openssh_install_firstuse. " +
                    "Or use -SshClientFolder to provide folder path with SSH executables.");
            }

            WriteDebug($"Found {executable} at: {sshPath}");
            return sshPath;
        }

        /// <summary>
        /// Expand user path (handle ~ for home directory)
        /// </summary>
        /// <param name="path">Path that might contain ~</param>
        /// <returns>Expanded path</returns>
        protected string ExpandUserPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            if (path.StartsWith("~"))
            {
                string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                path = Path.Combine(
                    homeDirectory,
                    path.Substring(1).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                );
            }

            return path;
        }

        /// <summary>
        /// Validate that required files exist
        /// </summary>
        /// <param name="filePath">File path to validate</param>
        /// <param name="fileType">Type of file for error messages</param>
        protected void ValidateFileExists(string filePath, string fileType)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string expandedPath = ExpandUserPath(filePath);
            if (!File.Exists(expandedPath))
            {
                throw new AzPSIOException($"{fileType} file {filePath} not found.");
            }
        }

        /// <summary>
        /// Validate that a directory exists for the given file path
        /// </summary>
        /// <param name="filePath">File path whose directory should be validated</param>
        protected void ValidateDirectoryForFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string directory = Path.GetDirectoryName(ExpandUserPath(filePath));
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                throw new AzPSIOException($"Directory {directory} doesn't exist");
            }
        }

        /// <summary>
        /// Validate SFTP connection arguments
        /// </summary>
        /// <param name="storageAccount">Storage account name</param>
        /// <param name="certFile">Certificate file path</param>
        /// <param name="publicKeyFile">Public key file path</param>
        /// <param name="privateKeyFile">Private key file path</param>
        protected void ValidateConnectionArgs(string storageAccount, string certFile, string publicKeyFile, string privateKeyFile)
        {
            if (string.IsNullOrWhiteSpace(storageAccount))
            {
                throw new AzPSArgumentException("Storage account name is required.", nameof(storageAccount));
            }

            var filesToCheck = new[]
            {
                (certFile, "Certificate"),
                (publicKeyFile, "Public key"),
                (privateKeyFile, "Private key")
            };

            foreach (var (filePath, fileType) in filesToCheck)
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    ValidateFileExists(filePath, fileType);
                }
            }
        }
    }
}
