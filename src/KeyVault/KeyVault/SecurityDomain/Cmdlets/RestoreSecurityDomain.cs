using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmSecurityDomain", SupportsShouldProcess = true, DefaultParameterSetName = ByName)]
    [OutputType(typeof(bool))]
    public class RestoreSecurityDomain : SecurityDomainCmdlet
    {
        [Parameter(HelpMessage = "Information about the keys that are used to decrypt the security domain data. See examples for how it is constructed.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public KeyPath[] Keys { get; set; }

        [Parameter(HelpMessage = "Specify the path to the encrypted security domain data.", Mandatory = true)]
        [Alias("Path")]
        [ValidateNotNullOrEmpty]
        public string SecurityDomainPath { get; set; }

        [Parameter(HelpMessage = "When specified, a boolean will be returned when cmdlet succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void DoExecuteCmdlet()
        {
            ValidateParameters();
            if (ShouldProcess($"managed HSM {Name}", $"restore security domain data from file \"{SecurityDomainPath}\""))
            {
                Keys = Keys.Select(key => new KeyPath() {
                    PublicKey = this.ResolveUserPath(key.PublicKey),
                    PrivateKey = this.ResolveUserPath(key.PrivateKey)
                    }).ToArray();
                var securityDomain = LoadSdFromFile(ResolveUserPath(SecurityDomainPath));
                var rawSecurityDomain = Client.DecryptSecurityDomain(securityDomain, Keys);
                var exchangeKey = Client.DownloadSecurityDomainExchangeKey(Name);
                var encryptedSecurityDomain = Client.EncryptForRestore(rawSecurityDomain, exchangeKey);
                Client.RestoreSecurityDomain(Name, encryptedSecurityDomain);

                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }

        private void ValidateParameters()
        {
            if (Keys.Length < 2)
            {
                throw new ArgumentException(string.Format(Resources.RestoreSecurityDomainNotEnoughKey, Common.Constants.MinQuorum));
            }
            if (Keys.Any(key => string.IsNullOrEmpty(key.PublicKey) || string.IsNullOrEmpty(key.PrivateKey)))
            {
                throw new ArgumentException(Resources.RestoreSecurityDomainBadKey);
            }
        }

        private SecurityDomainData LoadSdFromFile(string path)
        {
            try
            {
                string content = Utils.FileToString(path);
                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new ArgumentException(nameof(SecurityDomainPath));
                }
                return JsonConvert.DeserializeObject<SecurityDomainData>(content);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(Resources.LoadSecurityDomainFileFailed, path), ex);
            }
        }
    }
}
