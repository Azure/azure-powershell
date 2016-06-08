//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Clients.ActiveDirectory.Internal;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    /// <summary>
    /// Helper for TokenCloudCredentials
    /// </summary>
    public class TokenCloudCredentialsHelper
    {
        private const int Success = 0;
        private static string ProcessExecuteException = "Process executed with exit code {0} and error {1}";
        private static string ProcessExecuteInfo = "Process ececuted with exit code {0} and standard output {1}";
        private static string ProcessExecuteErrorTrace = "Error in process execution: Process exited with code {0} standrad out {1} and standard error {2}";
        private static string NodeAuthenticationArgumentFormat = "index.js -u \"{0}\" -p \"{1}\" -a \"{2}\" -t \"{3}\" token";
        private static string CommandDoesNotExist = " The {0} executable was not found on this system: Please install {0} to continue";
        private static string TokenCreationResourceName = "Microsoft.WindowsAzure.Commands.ScenarioTest.Resources.node-token.zip";
        private static string NodeExe = "nodejs\\node.exe";
        private static string TokenScriptFolder = "node-token";
        private static string JsTokenCodeLocation = Path.GetTempPath();

        /// <summary>
        /// Returns token (requires user input)
        /// </summary>
        /// <returns></returns>
        public static AuthenticationResult GetToken(string authEndpoint, string tenant, string clientId)
        {
            var adalWinFormType = typeof(WebBrowserNavigateErrorEventArgs);
            Trace.WriteLine("Getting a random type from \'Microsoft.IdentityModel.Clients.ActiveDirectory.WindowsForms\' to force it be deployed by mstest");

            AuthenticationResult result = null;
            var thread = new Thread(() =>
            {
                try
                {
                    var context = new AuthenticationContext(Path.Combine(authEndpoint, tenant));

                    result = context.AcquireToken(
                        resource: "https://management.core.windows.net/",
                        clientId: clientId,
                        redirectUri: new Uri("urn:ietf:wg:oauth:2.0:oob"),
                        promptBehavior: PromptBehavior.Auto);
                }
                catch (Exception threadEx)
                {
                    Console.WriteLine(threadEx.Message);
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "AcquireTokenThread";
            thread.Start();
            thread.Join();

            return result;

        }

        /// <summary>
        /// Get an AAD token using user and password credentials against a login authority
        /// </summary>
        /// <param name="user">The username credential.</param>
        /// <param name="password">The password credential.</param>
        /// <param name="authority">The login authority.</param>
        /// <returns></returns>
        public static string GetTokenFromBasicCredentials(string user, string password, string authority = "https://login.windows-ppe.net", string tenant = "common")
        {
            EnsureTokenCreationEnvironment();
            authority = EnsureNoTrailingSlash(authority);
            return GetAADToken(user, password, authority, tenant);

        }

        /// <summary>
        /// Remove trailing slashes from a string
        /// </summary>
        /// <param name="authority">The string to remove slashes from.</param>
        /// <returns>The input string with trailing slashes removed</returns>
        private static string EnsureNoTrailingSlash(string authority)
        {
            StringBuilder returnValue = new StringBuilder(authority);
            if (returnValue.Length > 0)
            {
                while (returnValue[returnValue.Length - 1] == '/')
                {
                    returnValue.Remove(returnValue.Length - 1, 1);
                }
            }

            return returnValue.ToString();
        }

        /// <summary>
        /// Get an aad token given a username, password, and authority
        /// </summary>
        /// <param name="user">The user login credential.</param>
        /// <param name="password">The password login credential.</param>
        /// <param name="authority">The authority to use for login.</param>
        /// <returns>The authentication access token to use for the given user and password for this authority</returns>
        private static string GetAADToken(string user, string password, string authority, string tenant)
        {
            return GetProcessResult(
                GetNodePath(),
                string.Format(NodeAuthenticationArgumentFormat, user, password, authority, tenant),
                (output, exitCode) =>
                    exitCode == Success && !output.Contains("Error"));
        }

        /// <summary>
        /// Get the path of the node executable on this system
        /// </summary>
        /// <returns>The path of the node executable</returns>
        private static string GetNodePath()
        {
            foreach (Environment.SpecialFolder folder in new[] { Environment.SpecialFolder.ProgramFiles, Environment.SpecialFolder.ProgramFilesX86 })
            {
                string testPath = Path.Combine(Environment.GetFolderPath(folder), NodeExe);
                if (File.Exists(testPath))
                {
                    return testPath;
                }
            }

            throw new ArgumentException(string.Format(CommandDoesNotExist, NodeExe));
        }

        /// <summary>
        /// Run the given command and arguments and return the result returned in standard output
        /// </summary>
        /// <param name="path">The path to the command to execute.</param>
        /// <param name="arguments">The arguments to pass to the command.</param>
        /// <param name="IsSuccess">A predicate to tell whether command execution was successful or not.</param>
        /// <returns>The value of standard output for the execution of the command.</returns>
        private static string GetProcessResult(string path, string arguments, Func<string, int, bool> IsSuccess)
        {
            Process executor = null;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(path, arguments);
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.WorkingDirectory = Path.Combine(JsTokenCodeLocation, TokenScriptFolder);
                startInfo.UseShellExecute = false;
                executor = Process.Start(startInfo);
                string returnValue = GetProcessStreamValue(executor.StandardOutput);
                executor.WaitForExit(10000);
                int exitCode = executor.ExitCode;
                TracingAdapter.Information(ProcessExecuteInfo, exitCode, returnValue);
                if (IsSuccess(returnValue, exitCode))
                {
                    return CleanConsoleOutputString(returnValue);
                }
                else
                {
                    string errorValue = GetProcessStreamValue(executor.StandardError);
                    TracingAdapter.Information(ProcessExecuteErrorTrace, exitCode, returnValue, errorValue);
                    throw new Exception(string.Format(ProcessExecuteException, executor.ExitCode, errorValue));
                }
            }
            finally
            {
                if (null != executor)
                {
                    executor.Dispose();
                }
            }
        }

        /// <summary>
        /// Remove unprintable characters from a console output string
        /// </summary>
        /// <param name="returnValue">The string to clean up.</param>
        /// <returns>The input string, with non-printable characters removed.</returns>
        private static string CleanConsoleOutputString(string inString)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char current in inString)
            {
                if (IsPrintableChar(current))
                {
                    builder.Append(current);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Determine if the character is printable
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private static bool IsPrintableChar(char current)
        {
            return !(char.IsControl(current) || char.IsSymbol(current));
        }

        /// <summary>
        /// Convert a stream reader to a string
        /// </summary>
        /// <param name="streamReader">The stream reader to use</param>
        /// <returns>The contents of the stream as a string.</returns>
        private static string GetProcessStreamValue(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        /// <summary>
        /// Ensure that all tools required for token authentication are installed on the server
        /// </summary>
        private static void EnsureTokenCreationEnvironment()
        {
            if (!TokenCreationEnvironmentInitialized())
            {
                string zipFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".zip");
                CopyResourceToFile(TokenCreationResourceName, zipFilePath);
                ExtractZipFile(zipFilePath, JsTokenCodeLocation);
            }

        }

        /// <summary>
        /// Extract the zip file to the current directory
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <param name="outputDir"></param>
        private static void ExtractZipFile(string zipFilePath, string outputDir)
        {
            using (Package package = Package.Open(zipFilePath, FileMode.Open, FileAccess.Read))
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                foreach (PackagePart part in package.GetParts())
                {
                    string target = Path.Combine(outputDir, part.Uri.OriginalString.Replace("/", "\\").Trim(new[] { '\\' }));
                    string parentDirectory = Path.GetDirectoryName(target);
                    Directory.CreateDirectory(parentDirectory);

                    using (Stream source = part.GetStream(FileMode.Open, FileAccess.Read))
                    using (Stream destination = File.OpenWrite(target))
                    {
                        byte[] buffer = new byte[0x1000];
                        int read;
                        while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destination.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }

        private static string CreateFilenameFromUri(Uri uri)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            StringBuilder sb = new StringBuilder(uri.OriginalString.Length);
            foreach (char c in uri.OriginalString)
            {
                sb.Append(Array.IndexOf(invalidChars, c) < 0 ? c : '_');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Copy binary resource to a file
        /// </summary>
        /// <param name="resourceName">The fully qualified name of the resource</param>
        /// <returns>The name of the file it was copied to</returns>
        public static void CopyResourceToFile(string resourceName, string fileName)
        {
            const int ReadSize = 2048;
            Stream resourceStream = null;
            FileStream resourceFileStream = null;
            try
            {
                resourceStream = Assembly.GetExecutingAssembly()
                   .GetManifestResourceStream(resourceName);
                resourceFileStream = new FileStream(fileName, FileMode.Create);
                byte[] buffer = new byte[ReadSize];
                int readBytes = 0;
                while ((readBytes = resourceStream.Read(buffer, 0, ReadSize)) > 0)
                {
                    resourceFileStream.Write(buffer, 0, readBytes);
                }
            }
            finally
            {
                if (resourceFileStream != null)
                {
                    resourceFileStream.Close();
                }

                if (resourceStream != null)
                {
                    resourceStream.Close();
                }
            }
        }

        /// <summary>
        /// Determines if the token creation script exists in the directory
        /// </summary>
        /// <returns>True if the environment has been created, otherwise false</returns>
        private static bool TokenCreationEnvironmentInitialized()
        {
            return Directory.Exists(Path.Combine(JsTokenCodeLocation, TokenScriptFolder));
        }
    }
}
