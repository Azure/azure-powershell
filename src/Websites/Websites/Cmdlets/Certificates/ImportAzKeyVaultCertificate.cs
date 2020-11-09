using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultCertificate")]
    [OutputType(typeof(PSCertificate))]
    public class ImportAzKeyVaultCertificate : WebAppBaseClientCmdLet
    {
        
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the Ketvault.")]
        [ValidateNotNullOrEmpty]
        public string KeyvaultName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Thumbprint of the certificate created in keyvault")]
        [ValidateNotNullOrEmpty]
        public string CertName{ get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the webapp resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the webapp.")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The name of the webapp slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        //[Parameter(Position = 5, Mandatory = true, HelpMessage = "Hostnames associated with web app/slot.")]
        //[ValidateNotNullOrEmpty]
        //public string HostName { get; set; }

        //[Parameter( Position = 6, Mandatory = false, HelpMessage = "Bind the Certificate to WebApp/slot.")]
        //[ValidateNotNullOrEmpty]
        //public SwitchParameter AddCertBinding { get; set; }

        //[Parameter( Position = 7, Mandatory = false, HelpMessage = "Ssl state option. Use either 'SniEnabled' or 'IpBasedEnabled'. Default option is 'SniEnabled'.")]
        //[ValidateNotNullOrEmpty]
        //public SslState? SslState { get; set; }

        public override void ExecuteCmdlet()
        {

            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;
                var serverFarmId = webApp.ServerFarmId;
                
                string keyvaultid;
                keyvaultid = CmdletHelpers.GetKeyVaultCertificates(this.ResourcesClient, this.WebsitesClient, ResourceGroupName, WebAppName, KeyvaultName, CertName);
                if (string.IsNullOrEmpty(keyvaultid))
                {
                    Console.WriteLine("keyvault cannot be found");
                }

                Certificate kvc = null;
                var certificate = new Certificate(
                    location: location,
                    keyVaultId: keyvaultid,
                    password: "",
                    keyVaultSecretName: CertName,
                    serverFarmId: serverFarmId
                    );

                if (this.ShouldProcess(this.WebAppName, string.Format($"Importing keyvault certificate for Web App '{WebAppName}'")))
                {
                    try
                    {
                        kvc = WebsitesClient.CreateCertificate(ResourceGroupName, CertName, certificate);
                    }
                    catch (DefaultErrorResponseException e)
                    {
                        if (e.Response.StatusCode != HttpStatusCode.Conflict)
                        {
                            throw;
                        }
                    }
                }

                //if (AddCertBinding)
                //{
                //    WebsitesClient.UpdateHostNameSslState(ResourceGroupName,
                //                                          WebAppName,
                //                                          Slot,
                //                                          webApp.Location,
                //                                          Hostname, SslState.HasValue ? SslState.Value : Management.WebSites.Models.SslState.SniEnabled,
                //                                          kvc.Thumbprint);
                //}
                WriteObject(kvc);
            }
            
        }
    }
}
