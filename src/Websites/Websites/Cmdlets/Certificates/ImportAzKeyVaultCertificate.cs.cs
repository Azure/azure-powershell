using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you import a keyvault to Webapp
    /// </summary>
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultCertificate")]
    [OutputType(typeof(PSCertificate))]
    public class ImportAzKeyVaultCertificate : WebAppBaseClientCmdLet
    {

        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the Ketvault.")]
        [ValidateNotNullOrEmpty]
        public string KeyvaultName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Thumbprint of the certificate created in keyvault")]
        [ValidateNotNullOrEmpty]
        public string CertName { get; set; }

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

        public override void ExecuteCmdlet()
        {

            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;
                var serverFarmId = webApp.ServerFarmId;

                //string keyvaultid;
                string kvid = string.Empty;
                string kvresourcegrpname = string.Empty;
                var resourcesClient = new ResourceClient(DefaultProfile.DefaultContext);
                //keyvaultid = CmdletHelpers.GetKeyVaultCertificates(this.ResourcesClient, this.WebsitesClient, ResourceGroupName, WebAppName, KeyvaultName, CertName);

                var keyvaultResources = resourcesClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions
                {
                    ResourceType = "Microsoft.KeyVault/Vaults"
                }).ToArray();

                foreach (var kv in keyvaultResources)
                {
                    if (kv.Name == KeyvaultName)
                    {
                        kvid = kv.Id;
                        kvresourcegrpname = kv.ResourceGroupName;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(kvid))
                {
                    kvid = KeyvaultName;
                }
                string keyvaultperm;
                keyvaultperm = CmdletHelpers.CheckServicePrincipalPermissions(this.ResourcesClient, this.KeyvaultClient, this.ActiveDirectoryClient, kvresourcegrpname, KeyvaultName);
                var lnk = "https://azure.github.io/AppService/2016/05/24/Deploying-Azure-Web-App-Certificate-through-Key-Vault.html";
                if (keyvaultperm != "Get")
                {
                    WriteWarning("Unable to verify Key Vault permissions.");
                    WriteWarning("You may need to grant Microsoft.Azure.WebSites service principal the Secret:Get permission");
                    WriteWarning(string.Format("Find more details here: '{0}'", lnk));
                }
                Certificate kvc = null;
                var certificate = new Certificate(
                    location: location,
                    keyVaultId: kvid,
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
                WriteObject(kvc);
            }

        }
    }
}

