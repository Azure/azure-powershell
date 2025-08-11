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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Sftp.Common;
using Microsoft.Azure.Commands.Sftp.Models;

namespace Microsoft.Azure.Commands.Sftp.SftpCommands
{
    /// <summary>
    /// Connect to Azure Storage Account via SFTP with automatic certificate generation if needed
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "AzSftp", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(System.Diagnostics.Process))]
    public class ConnectAzSftpCommand : SftpBaseCmdlet
    {
        #region Constants
        private const string DefaultParameterSet = "Default";
        private const string CertificateAuthParameterSet = "CertificateAuth";
        private const string PublicKeyAuthParameterSet = "PublicKeyAuth";
        private const string LocalUserAuthParameterSet = "LocalUserAuth";
        #endregion

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = DefaultParameterSet, HelpMessage = "Azure Storage Account name for SFTP connection. Must have SFTP enabled.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Azure Storage Account name for SFTP connection. Must have SFTP enabled.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Azure Storage Account name for SFTP connection. Must have SFTP enabled.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Azure Storage Account name for SFTP connection. Must have SFTP enabled.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "SFTP port. If not specified, uses SSH default port (22).")]
        [Parameter(Mandatory = false, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "SFTP port. If not specified, uses SSH default port (22).")]
        [Parameter(Mandatory = false, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "SFTP port. If not specified, uses SSH default port (22).")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "SFTP port. If not specified, uses SSH default port (22).")]
        public int? Port { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Path to SSH certificate file for authentication. If not provided, a certificate will be generated automatically.")]
        [Parameter(Mandatory = true, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Path to SSH certificate file for authentication. Must be generated with New-AzSftpCertificate or compatible Azure AD certificate.")]
        [ValidateNotNullOrEmpty]
        public string CertificateFile { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Path to SSH private key file for authentication. When provided without certificate, a certificate will be generated automatically.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Path to SSH private key file for authentication with local user account.")]
        [Parameter(Mandatory = true, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Path to SSH private key file for authentication. Required when using certificate-based authentication.")]
        [ValidateNotNullOrEmpty]
        public string PrivateKeyFile { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Path to SSH public key file for authentication. When provided without certificate, a certificate will be generated automatically.")]
        [Parameter(Mandatory = true, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Path to SSH public key file for authentication. Used for traditional SSH key authentication when the public key is configured on the storage account.")]
        [ValidateNotNullOrEmpty]
        public string PublicKeyFile { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Username for a local user configured on the storage account. When specified, uses local user authentication instead of Azure AD.")]
        [ValidateNotNullOrEmpty]
        public string LocalUser { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Additional arguments to pass to the SFTP client. Example: \"-v\" for verbose output, \"-b batchfile.txt\" for batch commands.")]
        [Parameter(Mandatory = false, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Additional arguments to pass to the SFTP client. Example: \"-v\" for verbose output, \"-b batchfile.txt\" for batch commands.")]
        [Parameter(Mandatory = false, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Additional arguments to pass to the SFTP client. Example: \"-v\" for verbose output, \"-b batchfile.txt\" for batch commands.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Additional arguments to pass to the SFTP client. Example: \"-v\" for verbose output, \"-b batchfile.txt\" for batch commands.")]
        public string[] SftpArg { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Path to folder containing SSH client executables (ssh, sftp, ssh-keygen). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Path to folder containing SSH client executables (ssh, sftp, ssh-keygen). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Path to folder containing SSH client executables (ssh, sftp, ssh-keygen). Default: Uses executables from PATH or system default locations.")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Path to folder containing SSH client executables (ssh, sftp, ssh-keygen). Default: Uses executables from PATH or system default locations.")]
        [ValidateNotNullOrEmpty]
        public string SshClientFolder { get; set; }

        protected override void ProcessRecord()
        {
            WriteDebug($"Starting SFTP connection to storage account: {StorageAccount}");

            if (!ShouldProcess($"Connect to SFTP storage account '{StorageAccount}'", 
                              $"Do you want to connect to SFTP storage account '{StorageAccount}'?",
                              "Connect-AzSftp"))
            {
                return;
            }

            CertificateFile = ExpandUserPath(CertificateFile);
            PrivateKeyFile = ExpandUserPath(PrivateKeyFile);
            PublicKeyFile = ExpandUserPath(PublicKeyFile);

            ValidateConnectionArgs(StorageAccount, CertificateFile, PublicKeyFile, PrivateKeyFile);

            // Validate SSH client availability
            ValidateSshClient(SshClientFolder);

            bool autoGenerateCert = false;
            bool deleteKeys = false;
            bool deleteCert = false;
            string credentialsFolder = null;
            string username = null;

            // Determine authentication mode based on parameter set
            switch (ParameterSetName)
            {
                case DefaultParameterSet:
                    // Azure AD authentication (automatic certificate generation)
                    if (string.IsNullOrEmpty(CertificateFile) && string.IsNullOrEmpty(PublicKeyFile) && string.IsNullOrEmpty(PrivateKeyFile))
                    {
                        WriteVerbose("Fully managed mode: No credentials provided, using Azure AD authentication");
                        autoGenerateCert = true;
                        deleteCert = true;
                        deleteKeys = true;
                        credentialsFolder = Path.Combine(Path.GetTempPath(), $"aadsftp{Guid.NewGuid():N}");
                        Directory.CreateDirectory(credentialsFolder);
                    }
                    else if (!string.IsNullOrEmpty(CertificateFile))
                    {
                        WriteVerbose("Using provided certificate file for authentication");
                        // Certificate file provided, don't auto-generate
                        autoGenerateCert = false;
                    }
                    else
                    {
                        WriteVerbose("Using provided keys for Azure AD certificate generation");
                        autoGenerateCert = true;
                        deleteCert = true;
                    }

                    try
                    {
                        var profile = DefaultContext;
                        if (profile?.Subscription == null)
                        {
                            throw new AzPSInvalidOperationException("No active Azure subscription found. Please run Connect-AzAccount.");
                        }
                    }
                    catch
                    {
                        if (!string.IsNullOrEmpty(credentialsFolder) && Directory.Exists(credentialsFolder))
                        {
                            Directory.Delete(credentialsFolder, true);
                        }
                        throw;
                    }

                    Host.UI.WriteLine(ConsoleColor.Blue, Host.UI.RawUI.BackgroundColor,
                                    autoGenerateCert ? "Generating temporary credentials using Azure AD authentication..."
                                                    : "Using provided certificate for authentication...");
                    break;

                case CertificateAuthParameterSet:
                    WriteVerbose("Using provided certificate and private key for authentication");
                    if (!File.Exists(CertificateFile))
                    {
                        throw new AzPSIOException($"Certificate file {CertificateFile} not found.");
                    }
                    if (!File.Exists(PrivateKeyFile))
                    {
                        throw new AzPSIOException($"Private key file {PrivateKeyFile} not found.");
                    }
                    autoGenerateCert = false;
                    break;

                case PublicKeyAuthParameterSet:
                    WriteVerbose("Using SSH public key authentication");
                    if (!File.Exists(PublicKeyFile))
                    {
                        throw new AzPSIOException($"Public key file {PublicKeyFile} not found.");
                    }
                    break;

                case LocalUserAuthParameterSet:
                    WriteVerbose($"Using local user authentication for user: {LocalUser}");
                    // For local user authentication, we can optionally use private key or fall back to interactive
                    if (!string.IsNullOrEmpty(PrivateKeyFile) && !File.Exists(PrivateKeyFile))
                    {
                        throw new AzPSIOException($"Private key file {PrivateKeyFile} not found.");
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(CertificateFile) && !string.IsNullOrEmpty(PublicKeyFile))
            {
                WriteWarning("Using certificate file (ignoring public key).");
            }

            try
            {
                string user;

                if (ParameterSetName == LocalUserAuthParameterSet)
                {
                    // Local user authentication - use provided LocalUser
                    user = LocalUser;
                    username = $"{StorageAccount}.{user}";
                }
                else if (autoGenerateCert)
                {
                    var (pubKey, privKey, delKeys) = FileUtils.CheckOrCreatePublicPrivateFiles(
                        PublicKeyFile, PrivateKeyFile, credentialsFolder, SshClientFolder);
                    PublicKeyFile = pubKey;
                    PrivateKeyFile = privKey;

                    WriteDebug($"Generated keys - Public: {PublicKeyFile}, Private: {PrivateKeyFile}");

                    // Generate certificate with proper naming for SSH client discovery
                    // SSH clients automatically look for <private_key>-cert.pub when using -i <private_key>
                    string certPath = null;
                    if (!string.IsNullOrEmpty(privKey))
                    {
                        certPath = privKey + "-cert.pub";
                    }
                    else if (!string.IsNullOrEmpty(pubKey))
                    {
                        // Fallback: derive private key name from public key
                        string baseKeyName = pubKey.EndsWith(".pub") ? pubKey.Substring(0, pubKey.Length - 4) : pubKey;
                        certPath = baseKeyName + "-cert.pub";
                    }
                    else
                    {
                        throw new AzPSInvalidOperationException("Unable to determine certificate path - no key files available");
                    }

                    WriteDebug($"Certificate will be created at: {certPath}");

                    var (cert, certUsername) = FileUtils.GetAndWriteCertificate(DefaultContext, PublicKeyFile, certPath, SshClientFolder, CmdletCancellationToken);

                    CertificateFile = cert;
                    user = certUsername;

                    WriteDebug($"Certificate created: {CertificateFile}, Certificate principal: {user}");

                    // For Azure Storage SFTP with Entra ID authentication (per design document):
                    // Username format: {storage-account}.{principal-name}
                    // For user principals like "degoswami@microsoft.com", extract the username part
                    if (user.Contains("@"))
                    {
                        user = user.Split('@')[0];
                    }
                    username = $"{StorageAccount}.{user}";
                }
                else if (string.IsNullOrEmpty(CertificateFile))
                {
                    // Public key authentication mode
                    if (!File.Exists(PublicKeyFile))
                    {
                        throw new AzPSIOException($"Public key file {PublicKeyFile} not found.");
                    }

                    // For public key auth, we need to determine the username from the storage account configuration
                    // This is more complex and may require additional API calls or configuration
                    WriteWarning("Public key authentication requires the corresponding private key and proper user configuration on the storage account.");

                    // Extract username from key file name or use a default pattern
                    string keyFileName = Path.GetFileNameWithoutExtension(PublicKeyFile);
                    if (keyFileName == "id_rsa" || keyFileName.StartsWith("id_"))
                    {
                        user = "sftpuser"; // Default SFTP user name
                    }
                    else
                    {
                        user = keyFileName;
                    }
                    username = $"{StorageAccount}.{user}";
                }
                else
                {
                    WriteDebug("Using provided certificate file...");
                    if (!File.Exists(CertificateFile))
                    {
                        throw new AzPSIOException($"Certificate file {CertificateFile} not found.");
                    }

                    var principals = SftpUtils.GetSshCertPrincipals(CertificateFile, SshClientFolder);
                    if (principals.Count == 0)
                    {
                        throw new AzPSInvalidOperationException("No principals found in certificate.");
                    }
                    user = principals[0].ToLower();

                    WriteDebug($"Certificate principal found: {user}");

                    // For Azure Storage SFTP with Entra ID authentication (per design document):
                    // Username format: {storage-account}.{principal-name}
                    // For user principals like "degoswami@microsoft.com", extract the username part
                    if (user.Contains("@"))
                    {
                        user = user.Split('@')[0];
                    }
                    username = $"{StorageAccount}.{user}";
                }

                string storageSuffix = GetStorageEndpointSuffix();
                string hostname = $"{StorageAccount}.{storageSuffix}";

                var sftpSession = new SFTPSession(
                    storageAccount: StorageAccount,
                    username: username,
                    host: hostname,
                    port: Port ?? 22,
                    certFile: CertificateFile,
                    privateKeyFile: PrivateKeyFile,
                    sftpArgs: SftpArg,
                    sshClientFolder: SshClientFolder,
                    sshProxyFolder: null,
                    credentialsFolder: credentialsFolder,
                    yesWithoutPrompt: false
                );

                sftpSession.LocalUser = user;
                sftpSession.ResolveConnectionInfo();

                WriteDebug($"Final session details:");
                WriteDebug($"  StorageAccount: {sftpSession.StorageAccount}");
                WriteDebug($"  Username: {sftpSession.Username}");
                WriteDebug($"  LocalUser: {sftpSession.LocalUser}");
                WriteDebug($"  Host: {sftpSession.Host}");
                WriteDebug($"  CertFile: {sftpSession.CertFile}");
                WriteDebug($"  PrivateKeyFile: {sftpSession.PrivateKeyFile}");

                if (Port.HasValue)
                {
                    Host.UI.WriteLine(ConsoleColor.Blue, Host.UI.RawUI.BackgroundColor,
                                    $"Connecting to {sftpSession.Username}@{hostname}:{Port.Value}");
                }
                else
                {
                    Host.UI.WriteLine(ConsoleColor.Blue, Host.UI.RawUI.BackgroundColor,
                                    $"Connecting to {sftpSession.Username}@{hostname}");
                }

                // Start SFTP operation
                var process = DoSftpOp(sftpSession, SftpUtils.StartSftpConnection);
                // Wait for the SFTP process to complete before cleaning up credentials
                if (process != null)
                {
                    WriteDebug($"Waiting for SFTP process (PID: {process.Id}) to exit before cleanup...");
                    process.WaitForExit();
                    WriteDebug($"SFTP process exited (PID: {process.Id}), cleaning up credentials...");
                    CleanupCredentials(deleteKeys, deleteCert, credentialsFolder, CertificateFile, PrivateKeyFile, PublicKeyFile);
                }
                WriteObject(process);
            }
            catch (Exception ex)
            {
                if (deleteKeys || deleteCert)
                {
                    WriteDebug($"An error occurred: {ex.Message}. Cleaning up generated credentials.");
                    CleanupCredentials(deleteKeys, deleteCert, credentialsFolder, CertificateFile, PrivateKeyFile, PublicKeyFile);
                }
                throw;
            }
        }

        private System.Diagnostics.Process DoSftpOp(SFTPSession sftpSession, Func<SFTPSession, System.Diagnostics.Process> opCall)
        {
            sftpSession.ValidateSession();
            return opCall(sftpSession);
        }

        private void CleanupCredentials(bool deleteKeys, bool deleteCert, string credentialsFolder,
            string certFile, string privateKeyFile, string publicKeyFile)
        {
            try
            {
                if (deleteCert && !string.IsNullOrEmpty(certFile) && File.Exists(certFile))
                {
                    WriteDebug($"Deleting generated certificate {certFile}");
                    FileUtils.DeleteFile(certFile);
                }

                if (deleteKeys)
                {
                    var keyFiles = new[]
                    {
                        (privateKeyFile, "private"),
                        (publicKeyFile, "public")
                    };

                    foreach (var (keyFile, keyType) in keyFiles)
                    {
                        if (!string.IsNullOrEmpty(keyFile) && File.Exists(keyFile))
                        {
                            WriteDebug($"Deleting generated {keyType} key {keyFile}");
                            FileUtils.DeleteFile(keyFile);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(credentialsFolder) && Directory.Exists(credentialsFolder))
                {
                    WriteDebug($"Deleting credentials folder {credentialsFolder}");
                    Directory.Delete(credentialsFolder, true);
                }
            }
            catch (IOException ex)
            {
                WriteWarning($"Failed to clean up credentials: {ex.Message}");
            }
        }

        private string GetStorageEndpointSuffix()
        {
            string cloudName = DefaultContext?.Environment?.Name?.ToLower() ?? "azurecloud";

            switch (cloudName)
            {
                case "azurechinacloud":
                    return "blob.core.chinacloudapi.cn";
                case "azureusgovernment":
                    return "blob.core.usgovcloudapi.net";
                default:
                    return "blob.core.windows.net";
            }
        }
    }
}