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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    public static class Git
    {
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static string GetConfigurationValue(string name)
        {
            return ExecuteGitProcess(string.Format("config --get {0}", name)).Split('\n').FirstOrDefault();
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void SetConfigurationValue(string name, string value)
        {
            ExecuteGitProcess(string.Format("config {0} {1}", name, value));
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void ClearConfigurationValue(string name)
        {
            ExecuteGitProcess(string.Format("config --unset {0}", name));
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static IList<string> GetRemoteRepositories()
        {
            return ExecuteGitProcess("remote").Split('\n');
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void AddRemoteRepository(string name, string url)
        {
            ExecuteGitProcess(string.Format("remote add {0} {1}", name, url));
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void RemoveRemoteRepository(string name)
        {
            ExecuteGitProcess(string.Format("remote rm {0}", name));
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void InitRepository()
        {
            ExecuteGitProcess("init");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static IList<string> GetWorkingTree()
        {
            return ExecuteGitProcess("rev-parse --git-dir").Split('\n');
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static IList<string> GetRemoteUris()
        {
            var remoteUrisLines = ExecuteGitProcess("remote -v").Split('\n');
            List<string> remoteUris = new List<string>();

            foreach (string remoteUriLine in remoteUrisLines)
            {
                if (remoteUriLine.Length > 0)
                {
                    string uri = remoteUriLine.Split('\t')[1].Split(' ')[0];
                    remoteUris.Add(uri);
                }
            }

            return remoteUris.Distinct().ToList();
        }
            
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static string GetUri(string repositoryUri, string siteName, string auth)
        {
            UriBuilder uriBuilder = new UriBuilder(repositoryUri)
            {
                Path = siteName + ".git",
                UserName = auth
            };

            return uriBuilder.Uri.ToString();
        }

        public static bool IsGitRepository()
        {
            var sessionState = new SessionState();
            return Directory.Exists(Path.Combine(sessionState.Path.CurrentFileSystemLocation.Path, ".git"));
        }

        private static string ExecuteGitProcess(string arguments)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.UseShellExecute = false;

                    try
                    {
                        SessionState sessionState = new SessionState();
                        process.StartInfo.WorkingDirectory = sessionState.Path.CurrentFileSystemLocation.Path;
                    }
                    catch (Exception)
                    {
                        // Do nothing
                    }

                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.FileName = "git";
                    process.StartInfo.Arguments = arguments;
                    process.Start();

                    // Read the output stream first and then wait.
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
            }
            catch (Win32Exception)
            {
                throw new Exception(Resources.GitNotFound);
            }
        }
    }
}