using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you import a keyvault to Webapp
    /// </summary>
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppKeyVaultCertificate", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCertificate))]
    public class ImportAzWebAppKeyVaultCertificate : WebAppBaseClientCmdLet
    {
        const string ParameterSet1Name = "S1";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the keyvault or Id of the KeyVault.")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true, HelpMessage = "KeyVaultCertName of the certificate created in keyvault")]
        [ValidateNotNullOrEmpty]
        public string CertName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = true, HelpMessage = "The name of the webapp resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "The name of the webapp.")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "The name of the webapp slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                string kvId = string.Empty, kvRgName = string.Empty, kvSubscriptionId = string.Empty;
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;
                var serverFarmId = webApp.ServerFarmId;
                var keyvaultResources = this.ResourcesClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions
                {
                    ResourceType = "Microsoft.KeyVault/Vaults"
                }).ToArray();

                foreach (var kv in keyvaultResources)
                {
                    if (kv.Name == KeyVaultName)
                    {
                        kvId = kv.Id;
                        kvRgName = kv.ResourceGroupName;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(kvId))
                {
                    kvId = KeyVaultName;
                    if (CmdletHelpers.IsValidAKVResourceId(kvId))
                    {
                        var details = CmdletHelpers.GetResourceDetailsFromResourceId(kvId);
                        kvRgName = details.ResourceGroupName;
                        KeyVaultName = details.ResourceName;
                        kvSubscriptionId = details.Subscription;
                    }
                    else //default to AppService RG 
                    {
                        kvRgName = ResourceGroupName;
                    }
                }
                var kvpermission = CmdletHelpers.CheckServicePrincipalPermissions(this.ResourcesClient, this.KeyvaultClient, kvRgName, KeyVaultName, kvSubscriptionId);
                var lnk = "https://azure.github.io/AppService/2016/05/24/Deploying-Azure-Web-App-Certificate-through-Key-Vault.html";
                if (kvpermission.ToLower() != "get")
                {
                    WriteWarning("Unable to verify Key Vault permissions.");
                    WriteWarning("You may need to grant Microsoft.Azure.WebSites service principal the Secret:Get permission");
                    WriteWarning(string.Format("Find more details here: '{0}'", lnk));
                }

                Certificate kvc = null;
                var certificate = new Certificate(
                    location: location,
                    keyVaultId: kvId,
                    password: "",
                    keyVaultSecretName: CertName,
                    serverFarmId: serverFarmId
                    );

                if (this.ShouldProcess(this.WebAppName, string.Format($"Importing keyvault certificate for Web App '{WebAppName}'")))
                {
                    try
                    {
                        kvc = WebsitesClient.CreateCertificate(ResourceGroupName, ResourceGroupName+'-'+KeyVaultName + '-'+CertName, certificate);
                    }
                    catch (DefaultErrorResponseException e)
                    {
                        if (e.Response.StatusCode != HttpStatusCode.Conflict)
                        {
                            throw e;
                        }
                    }
                }
                WriteObject(new PSCertificate(kvc));
            }

        }
    }
}
