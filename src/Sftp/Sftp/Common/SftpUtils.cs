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

using System.Runtime.InteropServices;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common
{
    public static class SftpUtils
    {
        private static class NativeMethods
        {
#if WINDOWS
            [DllImport("kernel32.dll")]
            internal static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
#endif
        }

        private const uint CTRL_BREAK_EVENT = 1;

        /// <summary>
        /// Safely generates a console control event if running on Windows.
        /// </summary>
        /// <param name="dwCtrlEvent"></param>
        /// <param name="dwProcessGroupId"></param>
        /// <returns>True if the event was generated, false otherwise.</returns>
        public static bool TryGenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
#if WINDOWS
                return NativeMethods.GenerateConsoleCtrlEvent(dwCtrlEvent, dwProcessGroupId);
#else
                return false;
#endif
            }
            return false;
        }
        // Simple logger for internal debugging
        private static readonly object _logLock = new object();

        private static void LogDebug(string message)
        {
            lock (_logLock)
            {
                System.Diagnostics.Debug.WriteLine($"DEBUG: {message}");
            }
        }

        private static void LogWarning(string message)
        {
            lock (_logLock)
            {
                System.Diagnostics.Debug.WriteLine($"WARNING: {message}");
            }
        }

        private static void LogInfo(string message)
        {
            lock (_logLock)
            {
                System.Diagnostics.Debug.WriteLine($"INFO: {message}");
            }
        }

        public static string[] BuildSftpCommand(SFTPSession opInfo)
        {
            string destination = opInfo.GetDestination();
            var command = new List<string>
        {
            GetSshClientPath("sftp", opInfo.SshClientFolder),
            "-o", "PasswordAuthentication=no",
            "-o", "PubkeyAuthentication=yes",
            "-o", "StrictHostKeyChecking=no",
            "-o", RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "UserKnownHostsFile=NUL" : "UserKnownHostsFile=/dev/null",
            "-o", "PubkeyAcceptedKeyTypes=rsa-sha2-256-cert-v01@openssh.com,rsa-sha2-512-cert-v01@openssh.com,rsa-sha2-256,rsa-sha2-512,ssh-rsa",
            "-o", "PreferredAuthentications=publickey",
            "-o", "LogLevel=ERROR", // Reduce noise in interactive session
            "-o", "ServerAliveInterval=30", // Keep connection alive for Azure Storage
            "-o", "ServerAliveCountMax=3",  // Azure Storage SFTP compatibility
            "-o", "TCPKeepAlive=yes"        // Maintain TCP connection
        };

            // Add certificate-specific options if using certificate authentication
            if (!string.IsNullOrEmpty(opInfo.CertFile))
            {
                // Enable identity file only mode to prevent SSH from trying other keys
                command.AddRange(new[] { "-o", "IdentitiesOnly=yes" });
                LogDebug("Added IdentitiesOnly=yes for certificate authentication");
            }

            var sessionArgs = opInfo.BuildArgs();
            LogDebug($"Session args: {string.Join(" ", sessionArgs)}");
            command.AddRange(sessionArgs);

            if (opInfo.SftpArgs != null)
            {
                LogDebug($"Additional SFTP args: {string.Join(" ", opInfo.SftpArgs)}");
                command.AddRange(opInfo.SftpArgs);
            }

            LogDebug($"Final SFTP command will be: {string.Join(" ", command)} {destination}");
            command.Add(destination);

            return command.ToArray();
        }

        public static void HandleProcessInterruption(Process sftpProcess)
        {
            LogInfo("Connection interrupted by user (KeyboardInterrupt)");
            if (sftpProcess == null || sftpProcess.HasExited)
            {
                return;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                try
                {
                    TryGenerateConsoleCtrlEvent(CTRL_BREAK_EVENT, (uint)sftpProcess.Id);
                }
                catch
                {
                    try
                    {
                        sftpProcess.Kill();
                    }
                    catch { }
                }
            }
            else
            {
                try
                {
                    sftpProcess.Kill();
                }
                catch { }
            }

            try
            {
                sftpProcess.WaitForExit(SftpConstants.ProcessExitTimeoutMs);
            }
            catch { }
        }

        public static Tuple<Process, int?> ExecuteSftpProcess(string[] command, Dictionary<string, string> env = null, ProcessCreationFlags creationFlags = ProcessCreationFlags.None)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = command[0],
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = (creationFlags & ProcessCreationFlags.CREATE_NO_WINDOW) != 0,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            // Build arguments string with proper escaping for .NET Standard 2.0 compatibility
            if (command.Length > 1)
            {
                var arguments = new List<string>();
                foreach (var arg in command.Skip(1))
                {
                    // Escape arguments that contain spaces or special characters
                    if (arg.Contains(" ") || arg.Contains("\"") || arg.Contains("\\"))
                    {
                        arguments.Add($"\"{arg.Replace("\"", "\\\"")}\"");
                    }
                    else
                    {
                        arguments.Add(arg);
                    }
                }
                processInfo.Arguments = string.Join(" ", arguments);
            }

            // Set environment variables if provided
            if (env != null)
            {
                foreach (var kvp in env)
                {
                    processInfo.EnvironmentVariables[kvp.Key] = kvp.Value;
                }
            }

            Process sftpProcess = null;
            try
            {
                sftpProcess = Process.Start(processInfo);

                // Handle Ctrl+C interruption
                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    HandleProcessInterruption(sftpProcess);
                };

                sftpProcess.WaitForExit();
                int returnCode = sftpProcess.ExitCode;

                return new Tuple<Process, int?>(sftpProcess, returnCode);
            }
            catch (Exception)
            {
                // If we failed to start the process (e.g., file not found), return null exit code
                // to indicate the start failure without throwing, matching test expectations.
                HandleProcessInterruption(sftpProcess);
                return new Tuple<Process, int?>(sftpProcess, null);
            }
        }

        public static Tuple<bool, double?, string> AttemptConnection(string[] command, Dictionary<string, string> env, ProcessCreationFlags creationFlags, SFTPSession opInfo, int attemptNum)
        {
            var connectionStartTime = DateTime.UtcNow;

            try
            {
                LogDebug($"Running SFTP command (attempt {attemptNum}): {string.Join(" ", command)}");

                var (sftpProcess, returnCode) = ExecuteSftpProcess(command, env, creationFlags);

                var connectionDuration = (DateTime.UtcNow - connectionStartTime).TotalSeconds;

                // If the process failed to start, ExecuteSftpProcess returns null process and null returnCode.
                // Treat that as a start failure (not a user interruption).
                if (sftpProcess == null && returnCode == null)
                {
                    var startError = "Failed to start SFTP connection: Unable to launch SSH/SFTP client.";
                    LogWarning(startError);
                    return new Tuple<bool, double?, string>(false, connectionDuration, startError);
                }

                // KeyboardInterrupt occurred (process started but returned null exit code)
                if (returnCode == null)
                {
                    return new Tuple<bool, double?, string>(false, connectionDuration, "Connection interrupted by user (KeyboardInterrupt)");
                }

                if (returnCode == 0)
                {
                    LogDebug($"SFTP connection successful in {connectionDuration:F2} seconds");
                    return new Tuple<bool, double?, string>(true, connectionDuration, null);
                }

                var errorMsg = $"SFTP connection failed with return code: {returnCode}";
                LogWarning(errorMsg);
                return new Tuple<bool, double?, string>(false, connectionDuration, errorMsg);
            }
            catch (Exception e)
            {
                var connectionDuration = (DateTime.UtcNow - connectionStartTime).TotalSeconds;
                var errorMsg = $"Failed to start SFTP connection: {e.Message}";
                return new Tuple<bool, double?, string>(false, connectionDuration, errorMsg);
            }
        }

        public static System.Diagnostics.Process StartSftpConnection(SFTPSession opInfo)
        {
            try
            {
                var env = new Dictionary<string, string>(Environment.GetEnvironmentVariables()
                    .Cast<System.Collections.DictionaryEntry>()
                    .ToDictionary(de => de.Key.ToString(), de => de.Value?.ToString() ?? string.Empty));

                const int retryAttemptsAllowed = 2;
                var command = BuildSftpCommand(opInfo);
                LogDebug($"SFTP command: {string.Join(" ", command)}");

                for (int attempt = 0; attempt <= retryAttemptsAllowed; attempt++)
                {
                    try
                    {
                        var processInfo = new ProcessStartInfo
                        {
                            FileName = command[0],
                            UseShellExecute = false, // Need false to set environment variables
                            RedirectStandardOutput = false, // Don't redirect for interactive session
                            RedirectStandardError = false,  // Don't redirect for interactive session
                            RedirectStandardInput = false,  // Don't redirect for interactive session
                            CreateNoWindow = false  // Allow console for interactive session
                        };

                        // Build arguments string - keep it simple like SSH PowerShell does
                        if (command.Length > 1)
                        {
                            processInfo.Arguments = string.Join(" ", command.Skip(1));
                        }

                        // Set environment variables if provided
                        if (env != null)
                        {
                            foreach (var kvp in env)
                            {
                                processInfo.EnvironmentVariables[kvp.Key] = kvp.Value;
                            }
                        }

                        var sftpProcess = Process.Start(processInfo);

                        // Handle Ctrl+C interruption
                        Console.CancelKeyPress += (sender, e) =>
                        {
                            e.Cancel = true;
                            HandleProcessInterruption(sftpProcess);
                        };

                        LogDebug($"SFTP process started successfully (PID: {sftpProcess.Id})");

                        // Monitor for immediate failures that might indicate authentication issues
                        if (!sftpProcess.HasExited)
                        {
                            // Wait a short time to see if the process exits immediately with an error
                            if (sftpProcess.WaitForExit(SftpConstants.QuickExitCheckTimeoutMs))
                            {
                                // Process exited quickly, likely an error
                                LogWarning($"SFTP process exited quickly with code {sftpProcess.ExitCode}.");

                                if (attempt < retryAttemptsAllowed)
                                {
                                    LogDebug($"Connection attempt {attempt + 1} failed, retrying...");
                                    continue;
                                }
                                else
                                {
                                    throw new AzPSApplicationException(
                                        $"SFTP connection failed. Exit code: {sftpProcess.ExitCode}. " +
                                        "Please verify your credentials and that the storage account has SFTP enabled."
                                    );
                                }
                            }
                        }

                        return sftpProcess;
                    }
                    catch (Exception e)
                    {
                        var errorMsg = $"Failed to start SFTP connection: {e.Message}";

                        if (attempt >= retryAttemptsAllowed)
                        {
                            throw new AzPSApplicationException(
                                $"{errorMsg}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                            );
                        }
                        LogWarning($"{errorMsg}. Retrying...");

                        if (attempt < retryAttemptsAllowed)
                        {
                            System.Threading.Thread.Sleep(SftpConstants.RetryDelayMs);
                        }
                    }
                }

                throw new AzPSApplicationException(
                    "Failed to establish SFTP connection after multiple attempts. Please check your network connection, credentials, and that the SFTP server is accessible."
                );
            }
            catch (OperationCanceledException) // Equivalent to KeyboardInterrupt
            {
                LogInfo("SFTP connection interrupted by user");
                return null;
            }
        }

        public static void GeneratePublicKeyFromPrivate(string privateKeyFile, string publicKeyFile, string sshClientFolder = null)
        {
            var sshKeygenPath = GetSshClientPath("ssh-keygen", sshClientFolder);
            var command = new string[] { sshKeygenPath, "-y", "-f", privateKeyFile };
            LogDebug($"Running ssh-keygen command to generate public key: {string.Join(" ", command)}");

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = command[0],
                    Arguments = string.Join(" ", command.Skip(1).Select(arg => $"\"{arg}\"")),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                };

                using (var process = Process.Start(processInfo))
                {
                    var output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        var error = process.StandardError.ReadToEnd();
                        throw new AzPSApplicationException(
                            $"Failed to generate public key from private key. Process exited with code {process.ExitCode}: {error}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                        );
                    }

                    // Write the public key to the specified file
                    File.WriteAllText(publicKeyFile, output.Trim());

                    // Set proper file permissions for the generated public key
                    FileUtils.SetFilePermissions(publicKeyFile, SftpConstants.PublicKeyPermissions);

                    LogDebug($"Successfully generated public key: {publicKeyFile}");
                }
            }
            catch (Exception e) when (!(e is AzPSApplicationException))
            {
                throw new AzPSApplicationException(
                    $"Failed to generate public key from private key with error: {e.Message}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                );
            }
        }

        public static void CreateSshKeyfile(string privateKeyFile, string sshClientFolder = null)
        {
            var sshKeygenPath = GetSshClientPath("ssh-keygen", sshClientFolder);

            // Delete existing key files if they exist
            if (File.Exists(privateKeyFile))
            {
                File.Delete(privateKeyFile);
            }

            string publicKeyFile = privateKeyFile + ".pub";
            if (File.Exists(publicKeyFile))
            {
                File.Delete(publicKeyFile);
            }

            LogDebug($"Creating SSH key pair at: {privateKeyFile}");

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = sshKeygenPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                };

                // Build arguments properly for no passphrase
                // Use separate argument approach which is more reliable
                var argsList = new List<string>
                {
                    "-t", "rsa",
                    "-f", $"\"{privateKeyFile}\"",
                    "-N", "\"\"",  // Empty passphrase
                    "-q"
                };
                
                processInfo.Arguments = string.Join(" ", argsList);
                
                LogDebug($"Running ssh-keygen command: {processInfo.FileName} {processInfo.Arguments}");

                using (var process = Process.Start(processInfo))
                {
                    // Write empty line to stdin in case it still prompts
                    process.StandardInput.WriteLine();
                    process.StandardInput.WriteLine();
                    
                    // Set a timeout to prevent hanging
                    if (!process.WaitForExit(SftpConstants.SshKeygenTimeoutMs))
                    {
                        process.Kill();
                        throw new AzPSApplicationException("SSH key generation timed out after 30 seconds");
                    }

                    // Read both output and error streams for debugging
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();

                    LogDebug($"ssh-keygen exit code: {process.ExitCode}");
                    LogDebug($"ssh-keygen output: {output}");
                    if (!string.IsNullOrEmpty(error))
                    {
                        LogDebug($"ssh-keygen error: {error}");
                    }

                    if (process.ExitCode != 0)
                    {
                        throw new AzPSApplicationException(
                            $"Failed to create ssh key file. Process exited with code {process.ExitCode}: {error}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                        );
                    }

                    // Verify key files were created
                    if (!File.Exists(privateKeyFile) || !File.Exists(publicKeyFile))
                    {
                        LogDebug($"Private key exists: {File.Exists(privateKeyFile)}");
                        LogDebug($"Public key exists: {File.Exists(publicKeyFile)}");

                        // List files in the directory for debugging
                        string directory = Path.GetDirectoryName(privateKeyFile);
                        if (Directory.Exists(directory))
                        {
                            var files = Directory.GetFiles(directory);
                            LogDebug($"Files in directory {directory}: {string.Join(", ", files)}");
                        }
                        else
                        {
                            LogDebug($"Directory does not exist: {directory}");
                        }

                        throw new AzPSApplicationException($"SSH key generation failed - key files were not created. Expected: {privateKeyFile} and {publicKeyFile}");
                    }

                    // Set proper file permissions for the generated keys
                    FileUtils.SetFilePermissions(privateKeyFile, SftpConstants.PrivateKeyPermissions);
                    FileUtils.SetFilePermissions(publicKeyFile, SftpConstants.PublicKeyPermissions);

                    LogDebug($"Successfully created SSH key pair: {privateKeyFile} and {publicKeyFile}");
                }
            }
            catch (Exception e) when (!(e is AzPSApplicationException))
            {
                throw new AzPSApplicationException(
                    $"Failed to create ssh key file with error: {e.Message}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                );
            }
        }

        public static List<string> GetSshCertPrincipals(string certFile, string sshClientFolder = null)
        {
            var info = GetSshCertInfo(certFile, sshClientFolder);
            var principals = new List<string>();
            bool inPrincipal = false;

            foreach (var line in info)
            {
                if (line.Contains(":"))
                {
                    inPrincipal = false;
                }

                if (line.Contains("Principals:"))
                {
                    inPrincipal = true;
                    continue;
                }

                if (inPrincipal)
                {
                    principals.Add(line.Trim());
                }
            }

            return principals;
        }


        public static List<string> GetSshCertInfo(string certFile, string sshClientFolder = null)
        {
            var sshKeygenPath = GetSshClientPath("ssh-keygen", sshClientFolder);
            var command = new string[] { sshKeygenPath, "-L", "-f", certFile };
            LogDebug($"Running ssh-keygen command {string.Join(" ", command)}");

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = command[0],
                    Arguments = string.Join(" ", command.Skip(1).Select(arg => $"\"{arg}\"")),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                };

                using (var process = Process.Start(processInfo))
                {
                    var output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        var error = process.StandardError.ReadToEnd();
                        throw new AzPSApplicationException(
                            $"Failed to get certificate info. Process exited with code {process.ExitCode}: {error}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                        );
                    }

                    return output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
            catch (Exception e) when (!(e is AzPSApplicationException))
            {
                throw new AzPSApplicationException(
                    $"Failed to get certificate info with error: {e.Message}. SSH client not found. Please ensure SSH client is installed and accessible in PATH."
                );
            }
        }

        public static string GetSshClientPath(string sshCommand = "ssh", string sshClientFolder = null)
        {
            if (!string.IsNullOrEmpty(sshClientFolder))
            {
                var clientSshPath = Path.Combine(sshClientFolder, sshCommand);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    clientSshPath += ".exe";
                }

                if (File.Exists(clientSshPath))
                {
                    LogDebug($"Attempting to run {sshCommand} from path {clientSshPath}");
                    return clientSshPath;
                }

                // If caller provided a specific ssh client folder, consider this an error rather than silently
                // falling back to system path. Tests expect an exception when the provided folder is invalid.
                throw new AzPSApplicationException($"Could not find {sshCommand} in provided --ssh-client-folder {sshClientFolder}.");
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return sshCommand;
            }

            // Windows-specific logic
            var architecture = RuntimeInformation.OSArchitecture;

            if (architecture != Architecture.X64 && architecture != Architecture.X86)
            {
                throw new AzPSApplicationException($"Unsupported OS architecture: {architecture} is not currently supported");
            }

            // Determine system path
            bool is64bit = architecture == Architecture.X64;
            bool is32bitProcess = !Environment.Is64BitProcess;
            string sysPath = is64bit && is32bitProcess ? "SysNative" : "System32";

            string systemRoot = Environment.GetEnvironmentVariable("SystemRoot") ?? @"C:\Windows";
            string sshPath = Path.Combine(systemRoot, sysPath, "openSSH", $"{sshCommand}.exe");

            LogDebug($"Process architecture: {(Environment.Is64BitProcess ? "64bit" : "32bit")}");
            LogDebug($"OS architecture: {(is64bit ? "64bit" : "32bit")}");
            LogDebug($"System Root: {systemRoot}");
            LogDebug($"Attempting to run {sshCommand} from path {sshPath}");

            if (!File.Exists(sshPath))
            {
                throw new AzPSApplicationException(
                    $"Could not find {sshCommand}.exe on path {sshPath}. " +
                    "Make sure OpenSSH is installed correctly: " +
                    "https://docs.microsoft.com/en-us/windows-server/administration/openssh/openssh_install_firstuse. " +
                    "Or use --ssh-client-folder to provide folder path with ssh executables.");
            }

            return sshPath;
        }

        [Flags]
        public enum ProcessCreationFlags : uint
        {
            None = 0,
            CREATE_NO_WINDOW = 0x08000000,
            CREATE_NEW_CONSOLE = 0x00000010,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            DETACHED_PROCESS = 0x00000008
        }

        public static Tuple<DateTime, DateTime> GetCertificateStartAndEndTimes(string certFile, string sshClientFolder = null)
        {
            var validityStr = GetSshCertValidity(certFile, sshClientFolder);

            if (!string.IsNullOrEmpty(validityStr) && validityStr.Contains("Valid: from ") && validityStr.Contains(" to "))
            {
                try
                {
                    var timesStr = validityStr.Replace("Valid: from ", "").Split(new[] { " to " }, StringSplitOptions.None);

                    if (timesStr.Length == 2)
                    {
                        // Parse the times - they come from ssh-keygen which uses local time
                        var t0 = DateTime.ParseExact(timesStr[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        var t1 = DateTime.ParseExact(timesStr[1], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                        LogDebug($"Certificate validity: {t0:yyyy-MM-dd HH:mm:ss} to {t1:yyyy-MM-dd HH:mm:ss}");
                        LogDebug($"Current time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                        return new Tuple<DateTime, DateTime>(t0, t1);
                    }
                }
                catch (Exception ex) when (ex is FormatException || ex is ArgumentException || ex is IndexOutOfRangeException)
                {
                    LogDebug($"Failed to parse certificate validity: {ex.Message}");
                    // Invalid date format or parsing error
                    return null;
                }
            }

            return null;
        }

        public static string GetSshCertValidity(string certFile, string sshClientFolder = null)
        {
            if (!string.IsNullOrEmpty(certFile))
            {
                var info = GetSshCertInfo(certFile, sshClientFolder);
                foreach (var line in info)
                {
                    if (line.Contains("Valid:"))
                    {
                        return line.Trim();
                    }
                }
            }
            return null;
        }
    }
}