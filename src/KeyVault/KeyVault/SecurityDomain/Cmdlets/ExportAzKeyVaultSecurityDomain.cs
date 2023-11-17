using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [Cmdlet(VerbsData.Export, ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVault + "SecurityDomain", SupportsShouldProcess = true, DefaultParameterSetName = ByName)]
    [OutputType(typeof(bool))]
    public class ExportAzKeyVaultSecurityDomain: SecurityDomainCmdlet
    {
        protected const string ByName = "ByName";
        protected const string ByInputObject = "ByInputObject";
        // protected const string ByResourceId = "ByResourceID";

        [Parameter(HelpMessage = "Name of the managed HSM.", Mandatory = true, ParameterSetName = ByName)]
        [Alias("HsmName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Object representing a managed HSM.", Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSKeyVaultIdentityItem InputObject { get; set; }

        [Parameter(HelpMessage = "Paths to the certificates that are used to encrypt the security domain data.", Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string[] Certificates { get; set; }

        [Parameter(HelpMessage = "Specify the path where security domain data will be downloaded to.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(HelpMessage = "Specify whether to overwrite existing file.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "When specified, a boolean will be returned when cmdlet succeeds.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(HelpMessage = "The minimum number of shares required to decrypt the security domain for recovery.", Mandatory = true)]
        [ValidateRange(Common.Constants.MinQuorum, Common.Constants.MaxQuorum)]
        public int Quorum { get; set; }

        public override void DoExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                Name = InputObject.VaultName;
            }
            ValidateParameters();

            var certificates = Certificates.Select(path => new X509Certificate2(ResolveUserPath(path)));

            if (ShouldProcess($"managed HSM {Name}", $"download encrypted security domain data to '{OutputPath}'"))
            {
                OutputPath = ResolveUserPath(OutputPath);
                var securityDomain = Client.DownloadSecurityDomain(Name, certificates, Quorum, CancellationToken);
                if (!AzureSession.Instance.DataStore.FileExists(OutputPath) || Force || ShouldContinue(string.Format(Resources.FileOverwriteMessage, OutputPath), Resources.FileOverwriteCaption))
                {
                    AzureSession.Instance.DataStore.WriteFile(OutputPath, securityDomain);
                    WriteDebug($"Security domain data of managed HSM '{Name}' downloaded to '{OutputPath}'.");
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }

        private void ValidateParameters()
        {
            if (Certificates.Length < Common.Constants.MinCert || Certificates.Length > Common.Constants.MaxCert)
            {
                throw new ArgumentException(string.Format(Resources.HsmCertRangeWarning, Common.Constants.MinCert, Common.Constants.MaxCert));
            }
        }
    }
}
