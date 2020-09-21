using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

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

        public override void ExecuteCmdletCore()
        {
            ValidateParameters();
            if (ShouldProcess($"managed HSM {Name}", $"restore security domain data from file '{SecurityDomainPath}'"))
            {
                var securityDomainData = LoadFromFile(SecurityDomainPath);
                var exchangeKey = Client.DownloadSecurityDomainExchangeKeyAsync(Name).ConfigureAwait(false).GetAwaiter().GetResult();
                var encryptedSecurityDomain = Client.EncryptSecurityDomainByCert(Keys, securityDomainData, exchangeKey);
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
                // todo: resource string
                throw new ArgumentException(@"There need to be at least 2 keys to decrypt security domain data.");
            }
            if (Keys.Any(key => string.IsNullOrEmpty(key.PublicKey) || string.IsNullOrEmpty(key.PrivateKey)))
            {
                // todo: resource string
                throw new ArgumentException(@"'PublicKey' and 'PrivateKey' are mandatory in each object in 'Keys'");
            }
        }

        private SecurityDomainData LoadFromFile(string path)
        {
            try
            {
                string sec_domain = Utils.FileToString(path);
                return JsonConvert.DeserializeObject<SecurityDomainData>(sec_domain);
            }
            catch (Exception err)
            {
                Console.WriteLine("Cannot load security domain from file");
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
