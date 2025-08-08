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

namespace Microsoft.Azure.Commands.Sftp.Models
{
    /// <summary>
    /// Encapsulates session configuration options.
    /// </summary>
    public class SessionConfiguration
    {
        public string[] SftpArgs { get; set; }
        public string SshClientFolder { get; set; }
        public string SshProxyFolder { get; set; }
        public string CredentialsFolder { get; set; }
        public bool YesWithoutPrompt { get; set; }
        
        public SessionConfiguration(
            string[] sftpArgs = null,
            string sshClientFolder = null,
            string sshProxyFolder = null,
            string credentialsFolder = null,
            bool yesWithoutPrompt = false)
        {
            SftpArgs = sftpArgs ?? new string[0];
            SshClientFolder = GetAbsolutePath(sshClientFolder);
            SshProxyFolder = GetAbsolutePath(sshProxyFolder);
            CredentialsFolder = GetAbsolutePath(credentialsFolder);
            YesWithoutPrompt = yesWithoutPrompt;
        }

        private static string GetAbsolutePath(string path)
        {
            return string.IsNullOrEmpty(path) ? null : Path.GetFullPath(path);
        }

        public override string ToString()
        {
            return $"SessionConfiguration(SftpArgs: [{string.Join(", ", SftpArgs)}], " +
                   $"SshClientFolder: {SshClientFolder ?? "null"}, " +
                   $"SshProxyFolder: {SshProxyFolder ?? "null"}, " +
                   $"CredentialsFolder: {CredentialsFolder ?? "null"}, " +
                   $"YesWithoutPrompt: {YesWithoutPrompt})";
        }
    }
}