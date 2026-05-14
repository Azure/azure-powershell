using System;
using System.IO;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common
{
    internal static class FileUtils
{
    [DllImport("libc", EntryPoint = "chmod", SetLastError = true)]
    private static extern int NativeChmod(string pathname, uint mode);

    public static void MakeDirsForFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }
        string directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    public static void MkdirP(string folderPath)
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            throw new ArgumentException("Folder path cannot be null or empty.", nameof(folderPath));
        }
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public static void DeleteFile(string filepath, string message = null, bool warning = false)
    {
        if (File.Exists(filepath))
        {
            try
            {
                File.Delete(filepath);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                if (warning && !string.IsNullOrEmpty(message))
                {
                    System.Diagnostics.Debug.WriteLine($"WARNING: {message}");
                }
                else
                {
                    throw new AzPSIOException($"{message ?? "Failed to delete file"}: {ex.Message}", ex);
                }
            }
        }
    }

    public static void DeleteFolder(string folderPath, string message, bool warning = false)
    {
        if (Directory.Exists(folderPath))
        {
            try
            {
                Directory.Delete(folderPath, true);
            }
            catch (IOException ex)
            {
                if (warning && !string.IsNullOrEmpty(message))
                {
                    System.Diagnostics.Debug.WriteLine($"WARNING: {message}");
                }
                else
                {
                    throw new AzPSIOException($"{message}: {ex.Message}", ex);
                }
            }
        }
    }

    public static void WriteToFile(string filepath, string mode, string content, string errorMessage, string encoding = null)
    {
        try
        {
            Encoding enc = Encoding.UTF8;
            if (!string.IsNullOrEmpty(encoding))
            {
                enc = Encoding.GetEncoding(encoding);
            }

            FileMode fileMode = mode == "a" ? FileMode.Append : FileMode.Create;

            using (var stream = new FileStream(filepath, fileMode, FileAccess.Write))
            using (var writer = new StreamWriter(stream, enc))
            {
                writer.Write(content);
            }
        }
        catch (Exception ex)
        {
            throw new AzPSIOException($"{errorMessage}: {ex.Message}", ex);
        }
    }

    public static string GetLineThatContains(string text, string substring)
    {
        foreach (var line in text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (line.Contains(substring))
            {
                return line;
            }
        }
        return null;
    }

    public static string RemoveInvalidCharactersFoldername(string folderName)
    {
        if (string.IsNullOrEmpty(folderName))
        {
            throw new ArgumentException("Folder name cannot be null or empty.", nameof(folderName));
        }

        foreach (var c in SftpConstants.WindowsInvalidFoldernameChars)
        {
            folderName = folderName.Replace(c.ToString(), string.Empty);
        }
        return folderName;
    }
    public static Tuple<string, string, bool> CheckOrCreatePublicPrivateFiles(string publicKeyFile, string privateKeyFile, string credentialsFolder, string sshClientFolder = null)
    {
        bool deleteKeys = false;

        // Check if we need to generate new keys
        bool generateNewKeys = false;
        if (string.IsNullOrEmpty(publicKeyFile) && string.IsNullOrEmpty(privateKeyFile))
        {
            generateNewKeys = true;
            deleteKeys = true;
        }
        else if (!string.IsNullOrEmpty(privateKeyFile) && !File.Exists(privateKeyFile))
        {
            // Private key path specified but file doesn't exist - generate new keys
            generateNewKeys = true;
            deleteKeys = true;
        }

        if (generateNewKeys)
        {
            if (string.IsNullOrEmpty(credentialsFolder))
            {
                if (!string.IsNullOrEmpty(privateKeyFile))
                {
                    // Use the directory of the specified private key file
                    credentialsFolder = Path.GetDirectoryName(privateKeyFile);
                }
                else
                {
                    credentialsFolder = Path.Combine(Path.GetTempPath(), "aadsftp" + Guid.NewGuid().ToString("N").Substring(0, 8));
                }
            }

            if (!Directory.Exists(credentialsFolder))
            {
                Directory.CreateDirectory(credentialsFolder);
            }

            // Set up file paths if not already specified
            if (string.IsNullOrEmpty(privateKeyFile))
            {
                privateKeyFile = Path.Combine(credentialsFolder, SftpConstants.SshPrivateKeyName);
            }
            if (string.IsNullOrEmpty(publicKeyFile))
            {
                publicKeyFile = privateKeyFile + ".pub";
            }

            try
            {
                SftpUtils.CreateSshKeyfile(privateKeyFile, sshClientFolder);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Handle the case where only private key is specified
        if (string.IsNullOrEmpty(publicKeyFile))
        {
            if (!string.IsNullOrEmpty(privateKeyFile))
            {
                publicKeyFile = privateKeyFile + ".pub";
            }
            else
            {
                throw new AzPSArgumentException("Public key file not specified", nameof(publicKeyFile));
            }
        }

        // Check if we need to generate the public key from private key
        if (!string.IsNullOrEmpty(privateKeyFile) && File.Exists(privateKeyFile) && !File.Exists(publicKeyFile))
        {
            // Generate public key from private key
            try
            {
                SftpUtils.GeneratePublicKeyFromPrivate(privateKeyFile, publicKeyFile, sshClientFolder);
            }
            catch (Exception ex)
            {
                throw new AzPSIOException($"Failed to generate public key from private key: {ex.Message}", ex);
            }
        }

        // Now check if files exist after potential generation
        if (!File.Exists(publicKeyFile))
        {
            if (publicKeyFile.EndsWith(".pub") && !string.IsNullOrEmpty(privateKeyFile) && publicKeyFile == privateKeyFile + ".pub")
            {
                throw new AzPSArgumentException($"Public key file {publicKeyFile} not found (derived from private key)", nameof(publicKeyFile));
            }
            throw new AzPSIOException($"Public key file {publicKeyFile} not found");
        }

        if (!string.IsNullOrEmpty(privateKeyFile))
        {
            if (!File.Exists(privateKeyFile))
            {
                throw new AzPSIOException($"Private key file {privateKeyFile} not found");
            }
        }

        if (string.IsNullOrEmpty(privateKeyFile))
        {
            if (publicKeyFile.EndsWith(".pub"))
            {
                string possiblePrivateKey = publicKeyFile.Substring(0, publicKeyFile.Length - 4);
                privateKeyFile = File.Exists(possiblePrivateKey) ? possiblePrivateKey : null;
            }
        }

        return new Tuple<string, string, bool>(publicKeyFile, privateKeyFile, deleteKeys);
    }

    public static Tuple<string, string> GetAndWriteCertificate(IAzureContext context, string publicKeyFile, string certFile, string sshClientFolder, CancellationToken cancellationToken = default)
    {
        certFile = string.IsNullOrEmpty(certFile)
            ? publicKeyFile + SftpConstants.SshCertificateSuffix
            : certFile;

        try
        {
            // Parse public key
            string publicKeyText = File.ReadAllText(publicKeyFile);

            var parser = new RSAParser();
            parser.Parse(publicKeyText);

            var rsaParameters = new RSAParameters
            {
                Exponent = Microsoft.WindowsAzure.Commands.Utilities.Common.Base64UrlHelper.DecodeToBytes(parser.Exponent),
                Modulus = Microsoft.WindowsAzure.Commands.Utilities.Common.Base64UrlHelper.DecodeToBytes(parser.Modulus)
            };

            // Get SSH credential factory
            ISshCredentialFactory factory = null;
            if (!AzureSession.Instance.TryGetComponent<ISshCredentialFactory>(nameof(ISshCredentialFactory), out factory) || factory == null)
            {
                throw new AzPSApplicationException("Cannot load SshCredentialFactory instance from context. Please ensure you are authenticated with Azure PowerShell.");
            }

            // Get SSH credential
            var credential = factory.GetSshCredential(context, rsaParameters);
            if (credential == null)
            {
                throw new AzPSInvalidOperationException("Failed to obtain SSH certificate credential. Please ensure you are properly authenticated with 'Connect-AzAccount'.");
            }

            // Extract credential string
            string credentialString;
            try
            {
                var credentialProperty = credential.GetType().GetProperty("Credential");
                if (credentialProperty == null)
                {
                    throw new AzPSInvalidOperationException("SSH credential object does not have expected Credential property.");
                }
                credentialString = credentialProperty.GetValue(credential) as string;
                if (string.IsNullOrEmpty(credentialString))
                {
                    throw new AzPSInvalidOperationException("SSH credential string is null or empty.");
                }
            }
            catch (Exception ex) when (ex.Message.Contains("User interaction is required") ||
                                      ex.Message.Contains("conditional access policy") ||
                                      ex.Message.Contains("multi-factor authentication"))
            {
                throw new AzPSInvalidOperationException(
                    "Authentication failed. User interaction is required. " +
                    "This may be due to conditional access policy settings such as multi-factor authentication (MFA). ", ex);
            }
            catch (System.Collections.Generic.KeyNotFoundException exception)
            {
                if (context.Account.Type != AzureAccount.AccountType.User)
                {
                    throw new AzPSApplicationException($"Failed to generate AAD certificate. Unsupported account type: {context.Account.Type}. Only User accounts are supported for SSH certificate generation.");
                }
                throw new AzPSApplicationException($"Failed to generate AAD certificate: {exception.Message}. Please ensure you are properly authenticated with 'Connect-AzAccount'.");
            }

            // Write OpenSSH certificate
            const string RsaOpenSshPrefix = "ssh-rsa-cert-v01@openssh.com";
            var certLine = $"{RsaOpenSshPrefix} {credentialString}\n";

            var certDirectory = Path.GetDirectoryName(certFile);
            if (!string.IsNullOrEmpty(certDirectory) && !Directory.Exists(certDirectory))
            {
                Directory.CreateDirectory(certDirectory);
            }

            File.WriteAllText(certFile, certLine, new UTF8Encoding(false));
            SetFilePermissions(certFile, SftpConstants.PublicKeyPermissions);

            // Extract principal from certificate
            var username = SftpUtils.GetSshCertPrincipals(certFile, sshClientFolder)
                .FirstOrDefault()?
                .ToLower();
            if (string.IsNullOrEmpty(username))
            {
                throw new AzPSInvalidOperationException("No principals found in SSH certificate");
            }

            return Tuple.Create(certFile, username);
        }
        catch (AzPSInvalidOperationException)
        {
            throw;
        }
        catch (AzPSApplicationException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AzPSInvalidOperationException(
                $"Certificate generation failed: {ex.Message}. " +
                "Please ensure you are authenticated with 'Connect-AzAccount' and have the necessary permissions.", ex);
        }
    }

    internal static void SetFilePermissions(string filePath, int permissions)
    {
        // Validate filePath before it is used in process arguments or scripts
        SftpUtils.ValidateCommandLineArgument(filePath, nameof(filePath));

        if (!File.Exists(filePath))
        {
            throw new AzPSArgumentException($"File '{filePath}' does not exist", nameof(filePath));
        }

        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var fileInfo = new FileInfo(filePath);
                fileInfo.Attributes = FileAttributes.Normal;

                // Use .NET ACL APIs directly instead of spawning external processes
                // (powershell.exe or icacls.exe) to eliminate command injection risk.
                var fileSecurity = fileInfo.GetAccessControl();
                fileSecurity.SetAccessRuleProtection(true, false);

                // Remove all existing access rules
                foreach (FileSystemAccessRule rule in
                    fileSecurity.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    fileSecurity.RemoveAccessRule(rule);
                }

                var currentUser = WindowsIdentity.GetCurrent().Name;

                if (permissions == SftpConstants.PrivateKeyPermissions)
                {
                    var accessRule = new FileSystemAccessRule(
                        currentUser,
                        FileSystemRights.FullControl,
                        AccessControlType.Allow);
                    fileSecurity.SetAccessRule(accessRule);
                }
                else // 644 octal - public key/certificate
                {
                    var userRule = new FileSystemAccessRule(
                        currentUser,
                        FileSystemRights.FullControl,
                        AccessControlType.Allow);
                    fileSecurity.SetAccessRule(userRule);

                    var authUsersRule = new FileSystemAccessRule(
                        "Authenticated Users",
                        FileSystemRights.Read,
                        AccessControlType.Allow);
                    fileSecurity.SetAccessRule(authUsersRule);
                }

                fileInfo.SetAccessControl(fileSecurity);
            }
            else
            {
                // Use P/Invoke to set Unix file permissions directly instead of
                // spawning a chmod process, to eliminate command injection risk.
                int result = NativeChmod(filePath, (uint)permissions);
                if (result != 0)
                {
                    int errno = Marshal.GetLastWin32Error();
                    throw new AzPSInvalidOperationException(
                        $"Failed to set file permissions on '{filePath}'. chmod error code: {errno}");
                }
            }
        }
        catch (Exception ex) when (!(ex is AzPSArgumentException || ex is AzPSInvalidOperationException))
        {
            throw new AzPSInvalidOperationException(
                $"Failed to set file permissions on '{filePath}': {ex.Message}", ex);
        }
    }
}
}