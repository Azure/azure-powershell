using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Properties;
using System;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [Cmdlet(VerbsData.Backup, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmSecurityDomain", SupportsShouldProcess = true, DefaultParameterSetName = ByName)]
    [OutputType(typeof(bool))]
    public class BackupSecurityDomain: SecurityDomainCmdlet
    {
        [Parameter(HelpMessage = "Paths to the certificates that are used to encrypt the security domain data.", Mandatory = true)]
        public string[] Certificates { get; set; }

        [Parameter(HelpMessage = "Specify the path where security domain data will be downloaded to.", Mandatory = true)]
        public string OutputPath { get; set; }

        [Parameter(HelpMessage = "Specify whether to overwrite existing file.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "When specified, a boolean will be returned when cmdlet succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdletCore()
        {
            if (Certificates?.Length < 3 || Certificates?.Length > 10) // todo: check
            {
                throw new ArgumentException($"Number of {nameof(Certificates)} should be between 3 and 10"); // todo: resource string; check
            }

            var certificates = Certificates.Select(path => new X509Certificate2(path));

            if (ShouldProcess($"managed HSM {Name}", $"download encrypted security domain data to '{OutputPath}'"))
            {
                var securityDomain = Client.DownloadSecurityDomainAsync(Name, certificates, 2).ConfigureAwait(false).GetAwaiter().GetResult(); // todo: remove required?
                if (!AzureSession.Instance.DataStore.FileExists(OutputPath) || Force || ShouldContinue(string.Format(Resources.FileOverwriteMessage, OutputPath), Resources.FileOverwriteCaption))
                {
                    AzureSession.Instance.DataStore.WriteFile(OutputPath, securityDomain);
                    WriteVerbose($"Security domain data of managed HSM '{Name}' downloaded to '{OutputPath}'.");
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
