using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Properties;
using System.Management.Automation;

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
            // ValidateParameters();

            // var certificates = Certificates.Select(path => new X509Certificate2(ResolveUserPath(path)));

            if (ShouldProcess($"managed HSM {Name}", $"download exported key to '{ExchangeKey}'"))
            {
                var exchangeKey = Client.DownloadSecurityDomainExchangeKey(Name, CancellationToken);
                ExchangeKey = ResolveUserPath(ExchangeKey);
                //var securityDomain = Client.DownloadSecurityDomain(Name, certificates, Quorum, CancellationToken);
                if (!AzureSession.Instance.DataStore.FileExists(ExchangeKey) || Force || ShouldContinue(string.Format(Resources.FileOverwriteMessage, ExchangeKey), Resources.FileOverwriteCaption))
                {
                    AzureSession.Instance.DataStore.WriteFile(ExchangeKey, exchangeKey.ToString());
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
