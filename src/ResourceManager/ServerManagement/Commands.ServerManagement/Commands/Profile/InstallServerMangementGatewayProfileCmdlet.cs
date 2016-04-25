// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using Base;
    using Utility;

    [Cmdlet(VerbsLifecycle.Install, "AzureRmServerManagementGatewayProfile")]
    public class InstallServerManagementGatewayProfileCmdlet : ServerManagementCmdlet
    {
        // Installs a gateway profile into the correct location

        protected static bool IsAdmin
        {
            get
            {
                try
                {
                    return ((Func<bool>) (() =>
                        new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)))();
                }
                catch
                {
                }
                return default(bool);
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "The JSON file to read the profile from.", ValueFromPipeline = true,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public FileInfo InputFile { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerbose($"Checking for administrative permissions");
            if (!IsAdmin)
            {
                throw new InvalidOperationException("Installation of the profile requires Administrator privileges.");
            }

            base.ExecuteCmdlet();

            WriteVerbose($"Reading text from file {InputFile.FullName}");
            var profile = File.ReadAllText(InputFile.FullName);
            WriteVerbose($"Profile read:\r\n{profile}");


            WriteVerbose($"Encrypting profile.");
            var encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(profile),
                null,
                DataProtectionScope.LocalMachine);

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "ManagementGateway");
            WriteVerbose($"Ensuring destination folder {path}.");
            Directory.CreateDirectory(path);

            WriteVerbose($"Writing encrypted profile to {path}\\GatewayProfile.json");
            File.WriteAllBytes(Path.Combine(path, "GatewayProfile.json"), encrypted);

            WriteVerbose($"Successfully written encrypted profile.");
        }
    }
}