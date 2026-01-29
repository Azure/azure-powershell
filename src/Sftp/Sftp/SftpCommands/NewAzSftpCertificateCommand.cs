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

using System;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.SftpCommands
{
    /// <summary>
    /// Generate SSH certificate for SFTP authentication using Microsoft Entra
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzSftpCertificate", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSCertificateInfo))]
    public class NewAzSftpCertificateCommand : SftpBaseCmdlet
    {
        #region Constants
        private const string DefaultParameterSet = "Default";
        private const string FromPublicKeyParameterSet = "FromPublicKey";
        private const string FromPrivateKeyParameterSet = "FromPrivateKey";
        private const string LocalUserParameterSet = "LocalUser";
        #endregion
        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "The file path to write the SSH certificate to. If not specified, uses a temporary file.")]
        [Parameter(Mandatory = false, ParameterSetName = FromPublicKeyParameterSet, HelpMessage = "The file path to write the SSH certificate to. If not specified, uses a temporary file.")]
        [Parameter(Mandatory = false, ParameterSetName = FromPrivateKeyParameterSet, HelpMessage = "The file path to write the SSH certificate to. If not specified, uses a temporary file.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserParameterSet, HelpMessage = "The file path to write the SSH certificate to. If not specified, uses a temporary file.")]
        [ValidateNotNullOrEmpty]
        [Alias("OutputFile", "o")]
        public string CertificatePath { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FromPublicKeyParameterSet, HelpMessage = "Path to existing SSH public key file for which to generate a certificate using Microsoft Entra.")]
        [ValidateNotNullOrEmpty]
        [Alias("p")]
        public string PublicKeyFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FromPrivateKeyParameterSet, HelpMessage = "Path to existing SSH private key file. The corresponding public key will be used to generate a certificate using Microsoft Entra.")]
        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Path to existing SSH private key file. If provided, uses the corresponding public key for certificate generation.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserParameterSet, HelpMessage = "Path to existing SSH private key file for local user certificate generation.")]
        [ValidateNotNullOrEmpty]
        [Alias("i")]
        public string PrivateKeyFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = LocalUserParameterSet, HelpMessage = "Username for local user certificate generation. This creates a certificate suitable for local user authentication on storage accounts.")]
        [ValidateNotNullOrEmpty]
        public string LocalUser { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Folder path that contains SSH executables (ssh-keygen, ssh). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = FromPublicKeyParameterSet, HelpMessage = "Folder path that contains SSH executables (ssh-keygen, ssh). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = FromPrivateKeyParameterSet, HelpMessage = "Folder path that contains SSH executables (ssh-keygen, ssh). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserParameterSet, HelpMessage = "Folder path that contains SSH executables (ssh-keygen, ssh). Default: Uses executables from PATH or system default locations.")]
        [ValidateNotNullOrEmpty]
        public string SshClientFolder { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = FromPublicKeyParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = FromPrivateKeyParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountEndpoint { get; set; }

        protected override void ProcessRecord()
        {
            WriteDebug("Starting SFTP certificate generation");

            string target = !string.IsNullOrEmpty(LocalUser) 
                ? $"SSH certificate for local user '{LocalUser}'" 
                : "SSH certificate for Microsoft Entra authentication";

            if (!ShouldProcess(target, 
                              $"Do you want to create {target}?",
                              "New-AzSftpCertificate"))
            {
                return;
            }

            // Expand user paths
            CertificatePath = ExpandUserPath(CertificatePath);
            PublicKeyFile = ExpandUserPath(PublicKeyFile);
            PrivateKeyFile = ExpandUserPath(PrivateKeyFile);
            SshClientFolder = ExpandUserPath(SshClientFolder);

            // If CertificatePath is not provided, use a temporary file
            if (string.IsNullOrEmpty(CertificatePath))
            {
                CertificatePath = Path.Combine(Path.GetTempPath(), "id_rsa-cert.pub");
            }
            else
            {
                // Validate directory for output file
                ValidateDirectoryForFile(CertificatePath);
                CertificatePath = Path.GetFullPath(CertificatePath);
                
                // If CertificatePath is a directory, append default certificate filename
                if (Directory.Exists(CertificatePath) || (!File.Exists(CertificatePath) && !Path.HasExtension(CertificatePath)))
                {
                    CertificatePath = Path.Combine(CertificatePath, "id_rsa-cert.pub");
                    WriteDebug($"Treating as directory, certificate will be written to: {CertificatePath}");
                }
            }

            // Handle different parameter sets for authentication modes
            string currentParameterSet = ParameterSetName;
            WriteDebug($"Using parameter set: {currentParameterSet}");

            // Handle local user authentication differently
            bool isLocalUser = !string.IsNullOrEmpty(LocalUser);
            if (isLocalUser)
            {
                WriteDebug($"Generating certificate for local user: {LocalUser}");
            }

            // Validate SSH client availability
            ValidateSshClient(SshClientFolder);

            if (!string.IsNullOrEmpty(PublicKeyFile))
            {
                PublicKeyFile = Path.GetFullPath(PublicKeyFile);
                WriteDebug($"Using public key file: {PublicKeyFile}");
            }
            
            if (!string.IsNullOrEmpty(PrivateKeyFile))
            {
                PrivateKeyFile = Path.GetFullPath(PrivateKeyFile);
                WriteDebug($"Using private key file: {PrivateKeyFile}");
            }

            if (!string.IsNullOrEmpty(SshClientFolder))
            {
                SshClientFolder = Path.GetFullPath(SshClientFolder);
                WriteDebug($"Using SSH client folder: {SshClientFolder}");
            }

            string keysFolder = null;
            string actualPublicKeyFile = PublicKeyFile;
            string actualPrivateKeyFile = PrivateKeyFile;

            // Handle key pair generation and validation
            if (string.IsNullOrEmpty(PublicKeyFile) && string.IsNullOrEmpty(PrivateKeyFile))
            {
                // Generate key pair in the same directory as the certificate
                keysFolder = Path.GetDirectoryName(CertificatePath);
                WriteDebug($"Will generate key pair in: {keysFolder}");
                
                // Ensure the keys directory exists and is writable
                if (!Directory.Exists(keysFolder))
                {
                    Directory.CreateDirectory(keysFolder);
                }

                actualPrivateKeyFile = Path.Combine(keysFolder, "id_rsa");
                actualPublicKeyFile = Path.Combine(keysFolder, "id_rsa.pub");
            }
            else if (!string.IsNullOrEmpty(PrivateKeyFile) && string.IsNullOrEmpty(PublicKeyFile))
            {
                // Derive public key from private key
                actualPublicKeyFile = PrivateKeyFile + ".pub";
                actualPrivateKeyFile = PrivateKeyFile;
            }
            else if (!string.IsNullOrEmpty(PublicKeyFile))
            {
                actualPublicKeyFile = PublicKeyFile;
                if (string.IsNullOrEmpty(PrivateKeyFile))
                {
                    // Try to find corresponding private key
                    if (PublicKeyFile.EndsWith(".pub"))
                    {
                        string possiblePrivateKey = PublicKeyFile.Substring(0, PublicKeyFile.Length - 4);
                        if (File.Exists(possiblePrivateKey))
                        {
                            actualPrivateKeyFile = possiblePrivateKey;
                        }
                    }
                }
                else
                {
                    actualPrivateKeyFile = PrivateKeyFile;
                }
            }

            try
            {
                // Check for cancellation before starting
                CmdletCancellationToken.ThrowIfCancellationRequested();

                var (pubKeyFile, _, _) = FileUtils.CheckOrCreatePublicPrivateFiles(
                    actualPublicKeyFile, actualPrivateKeyFile, keysFolder, SshClientFolder);
                actualPublicKeyFile = pubKeyFile;

                // Check for cancellation before authentication
                CmdletCancellationToken.ThrowIfCancellationRequested();

                // Use different authentication method for local user vs Microsoft Entra
                string certFile;
                string username;
                
                if (isLocalUser)
                {
                    // For local user, use a different authentication flow or mock the certificate
                    // This would typically integrate with local storage account authentication
                    var (cf, un) = FileUtils.GetAndWriteCertificate(
                        DefaultContext, actualPublicKeyFile, CertificatePath, SshClientFolder, CmdletCancellationToken);
                    certFile = cf;
                    username = LocalUser; // Use the provided local user name
                }
                else
                {
                    // Standard Microsoft Entra authentication
                    var (cf, un) = FileUtils.GetAndWriteCertificate(
                        DefaultContext, actualPublicKeyFile, CertificatePath, SshClientFolder, CmdletCancellationToken);
                    certFile = cf;
                    username = un;
                }

                // Output success message
                try
                {
                    var certTimes = SftpUtils.GetCertificateStartAndEndTimes(certFile, SshClientFolder);
                    if (certTimes != null)
                    {
                        var certExpiration = certTimes.Item2;
                        Host.UI.WriteLine(ConsoleColor.Green, Host.UI.RawUI.BackgroundColor, 
                                        $"SSH certificate saved to: {certFile}");
                        Host.UI.WriteLine(ConsoleColor.Green, Host.UI.RawUI.BackgroundColor, 
                                        $"Certificate is valid until: {certExpiration} (local time)");
                        WriteDebug($"Certificate principal: {username}");
                    }
                    else
                    {
                        Host.UI.WriteLine(ConsoleColor.Green, Host.UI.RawUI.BackgroundColor, 
                                        $"SSH certificate saved to: {certFile}");
                        WriteDebug($"Certificate principal: {username}");
                    }
                }
                catch (Exception ex)
                {
                    WriteDebug($"Couldn't determine certificate validity: {ex.Message}");
                    Host.UI.WriteLine(ConsoleColor.Green, Host.UI.RawUI.BackgroundColor, 
                                    $"SSH certificate saved to: {certFile}");
                }

                // Warning about sensitive key files for security
                if (!string.IsNullOrEmpty(keysFolder))
                {
                    WriteWarning($"Private key saved to: {actualPrivateKeyFile ?? Path.Combine(keysFolder, "id_rsa")}");
                    WriteWarning($"Keep your private key secure and delete it when no longer needed.");
                }

                // Create and return PSCertificateInfo object
                var certInfo = new PSCertificateInfo
                {
                    CertificatePath = certFile,
                    PublicKeyPath = actualPublicKeyFile,
                    PrivateKeyPath = actualPrivateKeyFile,
                    Principal = username,
                    ParameterSet = ParameterSetName,
                    LocalUser = LocalUser
                };

                // Try to get certificate validity information
                try
                {
                    var certTimes = SftpUtils.GetCertificateStartAndEndTimes(certFile, SshClientFolder);
                    if (certTimes != null)
                    {
                        certInfo.ValidFrom = certTimes.Item1;
                        certInfo.ValidUntil = certTimes.Item2;
                    }
                }
                catch (Exception ex)
                {
                    WriteDebug($"Could not determine certificate validity: {ex.Message}");
                }

                WriteObject(certInfo);
            }
            catch (OperationCanceledException)
            {
                WriteWarning("Certificate generation was cancelled.");
                return;
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("SharedTokenCacheCredential authentication failed"))
            {
                WriteDebug($"Authentication failed: {ex.Message}");
                WriteError(new ErrorRecord(
                    ex,
                    "AuthenticationFailed",
                    ErrorCategory.AuthenticationError,
                    CertificatePath));
                WriteWarning("Authentication failed. Try running 'Connect-AzAccount' to refresh your credentials.");
            }
            catch (Exception ex)
            {
                WriteDebug($"Certificate generation failed: {ex.Message}");
                WriteError(new ErrorRecord(
                    ex, 
                    "CertificateGenerationFailed", 
                    ErrorCategory.SecurityError, 
                    CertificatePath));
            }
        }
    }
}
