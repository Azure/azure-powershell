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

namespace Microsoft.Azure.Commands.Sftp.Models
{
    /// <summary>
    /// Encapsulates authentication file paths.
    /// </summary>
    public class AuthenticationFiles
    {
        public string PublicKeyFile { get; set; }
        public string PrivateKeyFile { get; set; }
        public string CertFile { get; set; }

        public AuthenticationFiles(string publicKeyFile = null, string privateKeyFile = null, string certFile = null)
        {
            PublicKeyFile = ExpandAndGetAbsolutePath(publicKeyFile);
            PrivateKeyFile = ExpandAndGetAbsolutePath(privateKeyFile);
            CertFile = ExpandAndGetAbsolutePath(certFile);
        }

        private static string ExpandAndGetAbsolutePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            // Expand user path (~)
            if (path.StartsWith("~"))
            {
                string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                path = path.Replace("~", homeDirectory);
            }

            return Path.GetFullPath(path);
        }

        public override string ToString()
        {
            return $"AuthenticationFiles(PublicKey: {PublicKeyFile ?? "null"}, " +
                   $"PrivateKey: {PrivateKeyFile ?? "null"}, " +
                   $"Certificate: {CertFile ?? "null"})";
        }
    }
}
