using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models;
using Newtonsoft.Json;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Cmdlets
{
    [Cmdlet(VerbsData.Initialize, ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVault + "SecurityDomainRecovery", SupportsShouldProcess = true, DefaultParameterSetName = ByName)]
    [OutputType(typeof(bool))]
    public class InitSecurityDomainRecovery : SecurityDomainCmdlet
    {
        [Parameter(HelpMessage = "Local file path to store the exported key.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ExchangeKey { get; set; }

        [Parameter(HelpMessage = "Specify whether to overwrite existing file.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "When specified, a boolean will be returned when cmdlet succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void DoExecuteCmdlet()
        {
            if (ShouldProcess($"managed HSM {Name}", $"download exported key to '{ExchangeKey}'"))
            {
                var exchangeKey = Client.DownloadSecurityDomainExchangeKeyAsPem(Name, CancellationToken);
                ExchangeKey = ResolveUserPath(ExchangeKey);

                if (!AzureSession.Instance.DataStore.FileExists(ExchangeKey) || Force || ShouldContinue(string.Format(Resources.FileOverwriteMessage, ExchangeKey), Resources.FileOverwriteCaption))
                {
                    AzureSession.Instance.DataStore.WriteFile(ExchangeKey, exchangeKey);
                    WriteDebug($"Security domain data of managed HSM '{Name}' downloaded to '{ExchangeKey}'.");
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            }
        }

    }
}
