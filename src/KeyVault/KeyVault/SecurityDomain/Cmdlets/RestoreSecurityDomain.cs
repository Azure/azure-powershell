using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmSecurityDomain", SupportsShouldProcess = true, DefaultParameterSetName = ByName)]
    [OutputType(typeof(bool))]
    public class RestoreSecurityDomain : SecurityDomainCmdlet
    {
        [Parameter(HelpMessage = "Information about the keys that are used to decrypt the security domain data.", Mandatory = true)]
        public KeyPath[] Keys { get; set; }

        [Parameter(HelpMessage = "Specify the path to the encrypted security domain data.", Mandatory = true)]
        [Alias("Path")]
        public string SecurityDomainPath { get; set; }

        [Parameter(HelpMessage = "Specify whether to overwrite existing file.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "When specified, a boolean will be returned when cmdlet succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override async Task DoExecuteCmdletAsync()
        {
            ValidateParameters();
            if (ShouldProcess($"managed HSM {Name}", $"restore security domain data from file \"{SecurityDomainPath}\""))
            {
                var securityDomainData = LoadSdFromFileAsync(SecurityDomainPath);
                var exchangeKey = Client.DownloadSecurityDomainExchangeKeyAsync(Name);
                var encryptedSecurityDomain = Client.EncryptSecurityDomainByCert(Keys, await securityDomainData, await exchangeKey);
                if (Client.RestoreSecurityDomainAsync(Name, encryptedSecurityDomain).ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
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

        private async Task<SecurityDomainData> LoadSdFromFileAsync(string path)
        {
            try
            {
                string content = await Utils.FileToStringAsync(path);
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
