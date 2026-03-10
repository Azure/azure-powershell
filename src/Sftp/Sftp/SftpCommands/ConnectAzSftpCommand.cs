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
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.SftpCommands
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
        [Parameter(Mandatory = true, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Path to SSH certificate file for authentication. Must be generated with New-AzSftpCertificate or compatible Microsoft Entra certificate.")]
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

        [Parameter(Mandatory = true, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Username for a local user configured on the storage account. When specified, uses local user authentication instead of Microsoft Entra.")]
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

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Buffer size in bytes for SFTP file transfers. Default: 262144 (256 KB).")]
        [Parameter(Mandatory = false, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Buffer size in bytes for SFTP file transfers. Default: 262144 (256 KB).")]
        [Parameter(Mandatory = false, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Buffer size in bytes for SFTP file transfers. Default: 262144 (256 KB).")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Buffer size in bytes for SFTP file transfers. Default: 262144 (256 KB).")]
        [ValidateRange(1, int.MaxValue)]
        public int BufferSizeInBytes { get; set; } = SftpConstants.DefaultBufferSizeBytes;

        [Parameter(Mandatory = false, ParameterSetName = DefaultParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = CertificateAuthParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = PublicKeyAuthParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [Parameter(Mandatory = false, ParameterSetName = LocalUserAuthParameterSet, HelpMessage = "Custom storage account endpoint suffix. Default: Uses endpoint based on Azure environment (e.g., blob.core.windows.net).")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountEndpoint { get; set; }

        protected override void ProcessRecord()
        {
            WriteDebug($"[Connect-AzSftp] Starting SFTP connection");
            WriteDebug($"[Connect-AzSftp] Target storage account: '{StorageAccount}'");
            WriteDebug($"[Connect-AzSftp] Parameter set: '{ParameterSetName}'");
            WriteDebug($"[Connect-AzSftp] Buffer size: {BufferSizeInBytes} bytes ({BufferSizeInBytes / 1024} KB)");
            if (!string.IsNullOrEmpty(StorageAccountEndpoint))
            {
                WriteDebug($"[Connect-AzSftp] Custom endpoint: '{StorageAccountEndpoint}'");
            }

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
                    // Microsoft Entra authentication (automatic certificate generation)
                    if (string.IsNullOrEmpty(CertificateFile) && string.IsNullOrEmpty(PublicKeyFile) && string.IsNullOrEmpty(PrivateKeyFile))
                    {
                        WriteVerbose("[Auth] Fully managed mode: No credentials provided, will generate temporary certificate using Microsoft Entra authentication");
                        autoGenerateCert = true;
                        deleteCert = true;
                        deleteKeys = true;
                        credentialsFolder = Path.Combine(Path.GetTempPath(), $"aadsftp{Guid.NewGuid():N}");
                        Directory.CreateDirectory(credentialsFolder);
                        WriteDebug($"[Auth] Temporary credentials folder created: '{credentialsFolder}'");
                    }
                    else if (!string.IsNullOrEmpty(CertificateFile))
                    {
                        WriteVerbose($"[Auth] Using provided certificate file: '{CertificateFile}'");
                        // Certificate file provided, don't auto-generate
                        autoGenerateCert = false;
                    }
                    else
                    {
                        WriteVerbose("[Auth] Using provided SSH keys for Microsoft Entra certificate generation");
                        if (!string.IsNullOrEmpty(PrivateKeyFile))
                        {
                            WriteDebug($"[Auth] Private key file: '{PrivateKeyFile}'");
                        }
                        if (!string.IsNullOrEmpty(PublicKeyFile))
                        {
                            WriteDebug($"[Auth] Public key file: '{PublicKeyFile}'");
                        }
                        autoGenerateCert = true;
                        deleteCert = true;
                    }

                    try
                    {
                        var profile = DefaultContext;
                        if (profile?.Subscription == null)
                        {
                            throw new AzPSInvalidOperationException(
                                "No active Azure subscription found. Microsoft Entra authentication requires an active Azure session. " +
                                "Please run 'Connect-AzAccount' to sign in to your Azure account before using this cmdlet.");
                        }
                        WriteDebug($"[Auth] Azure context found - Subscription: '{profile.Subscription.Name}' ({profile.Subscription.Id})");
                    }
                    catch (AzPSInvalidOperationException)
                    {
                        if (!string.IsNullOrEmpty(credentialsFolder) && Directory.Exists(credentialsFolder))
                        {
                            WriteDebug($"[Cleanup] Removing temporary credentials folder due to authentication error");
                            Directory.Delete(credentialsFolder, true);
                        }
                        throw;
                    }

                    Host.UI.WriteLine(ConsoleColor.Blue, Host.UI.RawUI.BackgroundColor,
                                    autoGenerateCert ? "Generating temporary credentials using Microsoft Entra authentication..."
                                                    : "Using provided certificate for authentication...");
                    break;

                case CertificateAuthParameterSet:
                    WriteVerbose($"[Auth] Certificate authentication mode - using provided certificate and private key");
                    if (!File.Exists(CertificateFile))
                    {
                        throw new AzPSIOException(
                            $"Certificate file not found: '{CertificateFile}'. " +
                            "Please verify the file path is correct. You can generate a new certificate using 'New-AzSftpCertificate'.");
                    }
                    if (!File.Exists(PrivateKeyFile))
                    {
                        throw new AzPSIOException(
                            $"Private key file not found: '{PrivateKeyFile}'. " +
                            "The private key must correspond to the certificate's public key. " +
                            "You can generate a new key pair and certificate using 'New-AzSftpCertificate'.");
                    }
                    WriteDebug($"[Auth] Certificate file: '{CertificateFile}'");
                    WriteDebug($"[Auth] Private key file: '{PrivateKeyFile}'");
                    autoGenerateCert = false;
                    break;

                case PublicKeyAuthParameterSet:
                    WriteVerbose($"[Auth] Public key authentication mode - using provided public key");
                    if (!File.Exists(PublicKeyFile))
                    {
                        throw new AzPSIOException(
                            $"Public key file not found: '{PublicKeyFile}'. " +
                            "Please verify the file path is correct. The public key must be configured on the storage account's local user.");
                    }
                    WriteDebug($"[Auth] Public key file: '{PublicKeyFile}'");
                    break;

                case LocalUserAuthParameterSet:
                    WriteVerbose($"[Auth] Local user authentication mode for user: '{LocalUser}'");
                    // For local user authentication, we can optionally use private key or fall back to interactive
                    if (!string.IsNullOrEmpty(PrivateKeyFile) && !File.Exists(PrivateKeyFile))
                    {
                        throw new AzPSIOException(
                            $"Private key file not found: '{PrivateKeyFile}'. " +
                            "For local user authentication, either provide a valid private key file or omit the parameter for password authentication.");
                    }
                    if (!string.IsNullOrEmpty(PrivateKeyFile))
                    {
                        WriteDebug($"[Auth] Using private key file: '{PrivateKeyFile}'");
                    }
                    else
                    {
                        WriteDebug($"[Auth] No private key provided - will use password authentication if required");
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
                    WriteVerbose("[CertGen] Generating SSH key pair and certificate...");
                    var (pubKey, privKey, delKeys) = FileUtils.CheckOrCreatePublicPrivateFiles(
                        PublicKeyFile, PrivateKeyFile, credentialsFolder, SshClientFolder);
                    PublicKeyFile = pubKey;
                    PrivateKeyFile = privKey;

                    WriteDebug($"[CertGen] SSH keys ready - Public: '{PublicKeyFile}', Private: '{PrivateKeyFile}'");

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
                        throw new AzPSInvalidOperationException(
                            "Unable to determine certificate path - no SSH key files are available. " +
                            "Please provide either a public key file (-PublicKeyFile) or a private key file (-PrivateKeyFile).");
                    }

                    WriteDebug($"[CertGen] Certificate will be created at: '{certPath}'");
                    WriteVerbose("[CertGen] Requesting certificate from Microsoft Entra...");

                    var (cert, certUsername) = FileUtils.GetAndWriteCertificate(DefaultContext, PublicKeyFile, certPath, SshClientFolder, CmdletCancellationToken);

                    CertificateFile = cert;
                    user = certUsername;

                    WriteDebug($"[CertGen] Certificate successfully created: '{CertificateFile}'");
                    WriteDebug($"[CertGen] Certificate principal: '{user}'");

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
                        throw new AzPSIOException(
                            $"Public key file not found: '{PublicKeyFile}'. " +
                            "Please verify the file path exists and is accessible.");
                    }

                    // For public key auth, we need to determine the username from the storage account configuration
                    // This is more complex and may require additional API calls or configuration
                    WriteWarning(
                        "Public key authentication requires: (1) A corresponding private key file, and " +
                        "(2) The public key to be configured on the storage account's local user. " +
                        "Consider using Microsoft Entra authentication for a simpler setup.");

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
                    WriteDebug("[Auth] Using provided certificate file for authentication");
                    if (!File.Exists(CertificateFile))
                    {
                        throw new AzPSIOException(
                            $"Certificate file not found: '{CertificateFile}'. " +
                            "Please verify the file path is correct and the file exists.");
                    }

                    WriteVerbose($"[Auth] Extracting principals from certificate: '{CertificateFile}'");
                    var principals = SftpUtils.GetSshCertPrincipals(CertificateFile, SshClientFolder);
                    if (principals.Count == 0)
                    {
                        throw new AzPSInvalidOperationException(
                            $"No principals found in certificate '{CertificateFile}'. " +
                            "The certificate may be invalid or corrupted. Please generate a new certificate using 'New-AzSftpCertificate'.");
                    }
                    user = principals[0].ToLower();

                    WriteDebug($"[Auth] Certificate principal extracted: '{user}'");

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
                    yesWithoutPrompt: false,
                    bufferSizeBytes: BufferSizeInBytes
                );

                sftpSession.LocalUser = user;
                sftpSession.ResolveConnectionInfo();

                WriteDebug($"[Session] Connection details:");
                WriteDebug($"[Session]   Storage Account: '{sftpSession.StorageAccount}'");
                WriteDebug($"[Session]   Username: '{sftpSession.Username}'");
                WriteDebug($"[Session]   Local User: '{sftpSession.LocalUser}'");
                WriteDebug($"[Session]   Host: '{sftpSession.Host}'");
                WriteDebug($"[Session]   Port: {sftpSession.Port}");
                WriteDebug($"[Session]   Buffer Size: {BufferSizeInBytes} bytes");
                if (!string.IsNullOrEmpty(sftpSession.CertFile))
                {
                    WriteDebug($"[Session]   Certificate: '{sftpSession.CertFile}'");
                }
                if (!string.IsNullOrEmpty(sftpSession.PrivateKeyFile))
                {
                    WriteDebug($"[Session]   Private Key: '{sftpSession.PrivateKeyFile}'");
                }

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
                WriteVerbose("[SFTP] Starting SFTP client process...");
                var process = DoSftpOp(sftpSession, SftpUtils.StartSftpConnection);
                // Wait for the SFTP process to complete before cleaning up credentials
                if (process != null)
                {
                    WriteDebug($"[SFTP] SFTP process started (PID: {process.Id})");
                    WriteDebug($"[SFTP] Waiting for SFTP session to complete before cleanup...");
                    process.WaitForExit();
                    // Wait up to 5 minutes (300,000 ms) for the process to exit
                    bool exited = process.WaitForExit(300000);
                    if (!exited)
                    {
                        WriteWarning(
                            $"SFTP process (PID: {process.Id}) did not exit within 5 minutes. " +
                            "Credential cleanup will proceed, but the SFTP process may still be running. " +
                            "You may need to manually terminate the process.");
                    }
                    else
                    {
                        WriteDebug($"[SFTP] SFTP process exited with code: {process.ExitCode}");
                        WriteVerbose("[Cleanup] SFTP session ended, cleaning up temporary credentials...");
                    }
                    CleanupCredentials(deleteKeys, deleteCert, credentialsFolder, CertificateFile, PrivateKeyFile, PublicKeyFile);
                }
                WriteObject(process);
            }
            catch (Exception ex)
            {
                WriteDebug($"[Error] SFTP connection failed: {ex.GetType().Name}: {ex.Message}");
                if (ex.InnerException != null)
                {
                    WriteDebug($"[Error] Inner exception: {ex.InnerException.Message}");
                }
                if (deleteKeys || deleteCert)
                {
                    WriteDebug($"[Cleanup] Cleaning up temporary credentials after error");
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
                    WriteDebug($"[Cleanup] Deleting temporary certificate: '{certFile}'");
                    FileUtils.DeleteFile(certFile);
                }

                if (deleteKeys)
                {
                    var keyFiles = new[]
                    {
                        (privateKeyFile, "private key"),
                        (publicKeyFile, "public key")
                    };

                    foreach (var (keyFile, keyType) in keyFiles)
                    {
                        if (!string.IsNullOrEmpty(keyFile) && File.Exists(keyFile))
                        {
                            WriteDebug($"[Cleanup] Deleting temporary {keyType}: '{keyFile}'");
                            FileUtils.DeleteFile(keyFile);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(credentialsFolder) && Directory.Exists(credentialsFolder))
                {
                    WriteDebug($"[Cleanup] Removing temporary credentials folder: '{credentialsFolder}'");
                    Directory.Delete(credentialsFolder, true);
                }

                WriteDebug("[Cleanup] Credential cleanup completed");
            }
            catch (IOException ex)
            {
                WriteWarning(
                    $"Failed to clean up temporary credentials: {ex.Message}. " +
                    "You may need to manually delete temporary files from the temp directory.");
            }
        }

        private string GetStorageEndpointSuffix()
        {
            // Use custom endpoint suffix if provided
            if (!string.IsNullOrWhiteSpace(StorageAccountEndpoint))
            {
                var normalizedSuffix = StorageAccountEndpoint.Trim();

                // Remove any leading dots so that values like ".blob.core.windows.net" are accepted
                normalizedSuffix = normalizedSuffix.TrimStart('.');

                // Reject values that look like full URLs or contain paths, since we only expect a DNS suffix
                if (normalizedSuffix.IndexOf("://", StringComparison.Ordinal) >= 0 ||
                    normalizedSuffix.IndexOf("/", StringComparison.Ordinal) >= 0)
                {
                    throw new PSArgumentException(
                        "StorageAccountEndpoint must be a DNS suffix such as 'blob.core.windows.net' and must not contain a scheme or path.");
                }

                if (string.IsNullOrEmpty(normalizedSuffix))
                {
                    throw new PSArgumentException("StorageAccountEndpoint cannot be empty.");
                }

                return normalizedSuffix;
            }

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