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
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools
{
    public class CsEncrypt
    {
        private string _toolPath = null;

        public CsEncrypt(string azureSdkBinDirectory)
        {
            _toolPath = Path.Combine(azureSdkBinDirectory, Resources.CsEncryptExe);
        }
        
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public string CreateCertificate()
        {
            string standardOutput = null;
            string standardError = null;
            Execute(Resources.CsEncryptCreateCertificateArg, out standardOutput, out standardError);

            Match match = Regex.Match(standardOutput, @"^Thumbprint\s*:\s*(.*)$", RegexOptions.Multiline);
            if (!match.Success || match.Groups.Count <= 0)
            {
                throw new InvalidOperationException(string.Format(Resources.CsEncrypt_CreateCertificate_CreationFailed, standardError));
            }
            
            return match.Groups[1].Value;
        }
        
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        private void Execute(string arguments, out string standardOutput, out string standardError)
        {
            ProcessStartInfo pi = new ProcessStartInfo(_toolPath, arguments);
            ProcessHelper.StartAndWaitForProcess(pi, out standardOutput, out standardError);
        }
    }
}
