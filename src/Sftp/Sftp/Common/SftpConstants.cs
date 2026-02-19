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

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common
{
    /// <summary>
    /// Constants for SFTP operations
    /// </summary>
    public static class SftpConstants
    {
        // File system constants
        public const string WindowsInvalidFoldernameChars = "\\/*:<>?\"|";

        // Default ports
        public const int DefaultSshPort = 22;
        public const int DefaultSftpPort = 22;

        // Buffer size for SFTP file transfers
        public const int DefaultBufferSizeBytes = 256 * 1024;  // 256 KB

        // SSH/SFTP client configuration

        // Certificate and key file naming
        public const string SshPrivateKeyName = "id_rsa";
        public const string SshPublicKeyName = "id_rsa.pub";
        public const string SshCertificateSuffix = "-cert.pub";

        // File permissions (octal values converted to decimal)
        public const int PrivateKeyPermissions = 384;  // 600 octal (read/write for owner only)
        public const int PublicKeyPermissions = 420;   // 644 octal (read/write for owner, read for others)

        // Process timeouts (milliseconds)
        public const int ProcessExitTimeoutMs = 5000;        // 5 seconds
        public const int QuickExitCheckTimeoutMs = 2000;     // 2 seconds  
        public const int SshKeygenTimeoutMs = 30000;         // 30 seconds
        public const int RetryDelayMs = 1000;                // 1 second

        // SSH configuration options
        public static readonly string[] DefaultSshOptions = {
            "PasswordAuthentication=no",
            "StrictHostKeyChecking=no",
            "UserKnownHostsFile=/dev/null",
            "PubkeyAcceptedKeyTypes=rsa-sha2-256-cert-v01@openssh.com,rsa-sha2-256",
            "LogLevel=ERROR"
        };

        // Error messages and recommendations
        public const string RecommendationSshClientNotFound = 
            "Ensure OpenSSH is installed correctly.\n" +
            "Alternatively, use -SshClientFolder to provide OpenSSH folder path.";

        public const string RecommendationStorageAccountSftp = 
            "Ensure your Azure Storage Account has SFTP enabled.\n" +
            "Verify your account permissions include Storage Blob Data Contributor or similar.";
    }
}
