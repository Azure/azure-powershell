using System;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Microsoft.Azure.Commands.ServerManagement.Utility;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    [Cmdlet(VerbsLifecycle.Install, "AzureRmServerManagementGatewayProfile")]
    public class InstallServerManagementGatewayProfileCmdlet : ServerManagementCmdlet
    {
        // Installs a gateway profile into the correct location

        protected static bool IsAdmin
        {
            get
            {
                return Extensions.Safe( () => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator));
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "The name of the gateway to delete.", ValueFromPipeline = true)]
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
            var encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(profile), null,
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