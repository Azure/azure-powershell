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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models
{
    /// <summary>
    /// Holds SFTP session information and connection details.
    /// </summary>
    public class SFTPSession
    {
        private ConnectionInfo _connection;
        private AuthenticationFiles _authFiles;
        private SessionConfiguration _config;
        private RuntimeState _runtime;

        public SFTPSession(
            string storageAccount,
            string username = null,
            string host = null,
            int port = 22,
            string publicKeyFile = null,
            string privateKeyFile = null,
            string certFile = null,
            string[] sftpArgs = null,
            string sshClientFolder = null,
            string sshProxyFolder = null,
            string credentialsFolder = null,
            bool yesWithoutPrompt = false,
            int bufferSizeBytes = SftpConstants.DefaultBufferSizeBytes)
        {
            _connection = new ConnectionInfo(storageAccount, username, host, port);
            _authFiles = new AuthenticationFiles(publicKeyFile, privateKeyFile, certFile);
            _config = new SessionConfiguration(sftpArgs, sshClientFolder, sshProxyFolder, credentialsFolder, yesWithoutPrompt);
            _runtime = new RuntimeState();
            BufferSizeBytes = bufferSizeBytes;
        }

        // Connection properties
        public string StorageAccount
        {
            get => _connection.StorageAccount;
            set => _connection.StorageAccount = value;
        }

        public string Username
        {
            get => _connection.Username;
            set => _connection.Username = value;
        }

        public string Host
        {
            get => _connection.Host;
            set => _connection.Host = value;
        }

        public int Port
        {
            get => _connection.Port;
            set => _connection.Port = value;
        }

        // Authentication file properties
        public string PublicKeyFile
        {
            get => _authFiles.PublicKeyFile;
            set => _authFiles.PublicKeyFile = value;
        }

        public string PrivateKeyFile
        {
            get => _authFiles.PrivateKeyFile;
            set => _authFiles.PrivateKeyFile = value;
        }

        public string CertFile
        {
            get => _authFiles.CertFile;
            set => _authFiles.CertFile = value;
        }

        // Configuration properties
        public string[] SftpArgs
        {
            get => _config.SftpArgs;
            set => _config.SftpArgs = value ?? new string[0];
        }

        public string SshClientFolder
        {
            get => _config.SshClientFolder;
            set => _config.SshClientFolder = value;
        }

        public string SshProxyFolder
        {
            get => _config.SshProxyFolder;
            set => _config.SshProxyFolder = value;
        }

        public string CredentialsFolder
        {
            get => _config.CredentialsFolder;
            set => _config.CredentialsFolder = !string.IsNullOrEmpty(value) ? Path.GetFullPath(value) : null;
        }

        public bool YesWithoutPrompt
        {
            get => _config.YesWithoutPrompt;
            set => _config.YesWithoutPrompt = value;
        }

        // Runtime properties
        public bool DeleteCredentials
        {
            get => _runtime.DeleteCredentials;
            set => _runtime.DeleteCredentials = value;
        }

        public string LocalUser
        {
            get => _runtime.LocalUser;
            set => _runtime.LocalUser = value;
        }

        /// <summary>
        /// Buffer size in bytes for SFTP file transfers.
        /// </summary>
        public int BufferSizeBytes { get; set; } = SftpConstants.DefaultBufferSizeBytes;

        /// <summary>
        /// Resolve connection information like hostname and username.
        /// Username format: {storage-account}.{principal-name}
        /// </summary>
        public void ResolveConnectionInfo()
        {
            if (string.IsNullOrEmpty(Host))
            {
                throw new AzPSArgumentException("Host must be set before calling ResolveConnectionInfo()", nameof(Host));
            }

            // Certificate authentication with explicit local user
            if (!string.IsNullOrEmpty(CertFile) && !string.IsNullOrEmpty(LocalUser))
            {
                string localUserPart = LocalUser.Contains('@') ? LocalUser.Split('@')[0] : LocalUser;
                Username = $"{StorageAccount}.{localUserPart}";
            }
            else if (!string.IsNullOrEmpty(CertFile))
            {
                // Certificate authentication - username should be provided by calling code
                if (string.IsNullOrEmpty(Username))
                {
                    Username = StorageAccount;
                }
            }
            else if (string.IsNullOrEmpty(Username))
            {
                // Fallback for other authentication methods
                Username = StorageAccount;
            }
        }

        /// <summary>
        /// Build arguments for SFTP command.
        /// </summary>
        public List<string> BuildArgs()
        {
            var args = new List<string>();

            // Certificate authentication with explicit certificate file option
            if (!string.IsNullOrEmpty(CertFile))
            {
                if (File.Exists(CertFile))
                {
                    args.AddRange(new[] { "-o", $"CertificateFile={CertFile}" });
                }
            }

            // Private key authentication
            if (!string.IsNullOrEmpty(PrivateKeyFile))
            {
                if (File.Exists(PrivateKeyFile))
                {
                    args.AddRange(new[] { "-i", PrivateKeyFile });
                }
            }
            // Public key fallback (when no private key is available)
            else if (!string.IsNullOrEmpty(PublicKeyFile))
            {
                if (File.Exists(PublicKeyFile))
                {
                    args.AddRange(new[] { "-i", PublicKeyFile });
                }
            }

            // When using certificate authentication, add IdentitiesOnly for security
            if (!string.IsNullOrEmpty(CertFile) && File.Exists(CertFile))
            {
                args.AddRange(new[] { "-o", "IdentitiesOnly=yes" });
            }

            // Port option
            if (Port != 22)
            {
                args.AddRange(new[] { "-P", Port.ToString() });
            }

            // Buffer size option (sftp -B flag)
            if (BufferSizeBytes != SftpConstants.DefaultBufferSizeBytes)
            {
                args.AddRange(new[] { "-B", BufferSizeBytes.ToString() });
            }

            return args;
        }

        public string GetHost()
        {
            if (string.IsNullOrEmpty(Host))
            {
                throw new AzPSArgumentException("Host not set. Call ResolveConnectionInfo() first.", nameof(Host));
            }
            return Host;
        }

        public string GetDestination()
        {
            return $"{Username}@{GetHost()}";
        }

        public void ValidateSession()
        {
            if (string.IsNullOrEmpty(StorageAccount))
            {
                throw new AzPSArgumentNullException("StorageAccount", "Storage account name is required.");
            }

            if (string.IsNullOrEmpty(Username))
            {
                throw new AzPSArgumentNullException("Username", "Username is required. Call ResolveConnectionInfo() first.");
            }

            if (string.IsNullOrEmpty(Host))
            {
                throw new AzPSArgumentNullException("Host", "Host is required. Call ResolveConnectionInfo() first.");
            }

            ValidateFile(PublicKeyFile, "Public key");
            ValidateFile(PrivateKeyFile, "Private key");
            ValidateFile(CertFile, "Certificate");
        }

        private static void ValidateFile(string fileAttr, string fileDesc)
        {
            if (!string.IsNullOrEmpty(fileAttr) && !File.Exists(fileAttr))
            {
                throw new AzPSIOException($"{fileDesc} file {fileAttr} not found.");
            }
        }

        public override string ToString()
        {
            return $"SFTPSession(StorageAccount: {StorageAccount}, " +
                   $"Username: {Username ?? "null"}, " +
                   $"Host: {Host ?? "null"}, " +
                   $"Port: {Port})";
        }
    }
}
