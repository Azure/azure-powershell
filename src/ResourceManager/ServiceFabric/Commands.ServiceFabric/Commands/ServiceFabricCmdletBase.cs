// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public virtual string ResourceGroupName { get; set; }

        #region Key Vault 

        protected readonly string[] DefaultPermissionsToKeys =
        {
            "get",
            "create",
            "delete",
            "list",
            "update",
            "import",
            "backup",
            "restore"
        };

        protected readonly string[] DefaultPermissionsToSecrets = { "all" };
        protected readonly string[] DefaultPermissionsToCertificates = { "all" };
        protected readonly string DefaultSkuFamily = "A";
        protected readonly string DefaultSkuName = "Standard";

        #endregion

        #region RM Client
        private Lazy<IServiceFabricManagementClient> sfrpClient;
        private Lazy<IComputeManagementClient> computeClient;
        private Lazy<IKeyVaultManagementClient> keyVaultManageClient;
        private Lazy<IResourceManagementClient> resourcesClient;
        private Lazy<GraphRbacManagementClient> graphClient;
        private Lazy<IKeyVaultClient> keyVaultClient;

        //TODO change all those from public to internal of the clients
        public IServiceFabricManagementClient SFRPClient
        {
            get { return sfrpClient.Value; }
            set { sfrpClient = new Lazy<IServiceFabricManagementClient>(() => value); }
        }

        public IComputeManagementClient ComputeClient
        {
            get { return computeClient.Value; }
            set { computeClient = new Lazy<IComputeManagementClient>(() => value); }
        }

        public IKeyVaultManagementClient KeyVaultManageClient
        {
            get { return keyVaultManageClient.Value; }
            set { keyVaultManageClient = new Lazy<IKeyVaultManagementClient>(() => value); }
        }

        public IResourceManagementClient ResourcesClient
        {
            get { return resourcesClient.Value; }
            set { resourcesClient = new Lazy<IResourceManagementClient>(() => value); }
        }

        public GraphRbacManagementClient GraphClient
        {
            get { return graphClient.Value; }
            set { graphClient = new Lazy<GraphRbacManagementClient>(() => value); }
        }

        public IKeyVaultClient KeyVaultClient
        {
            get { return keyVaultClient.Value; }
            set { keyVaultClient = new Lazy<IKeyVaultClient>(() => value); }
        }

        public ServiceFabricCmdletBase()
        {
            InitializeAzureRmClients();
        }

        private void InitializeAzureRmClients()
        {
            sfrpClient = new Lazy<IServiceFabricManagementClient>(() =>
            {
                var armClient = AzureSession.ClientFactory.
                CreateArmClient<ServiceFabricManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager);
                return armClient;
            });

            computeClient = new Lazy<IComputeManagementClient>(() =>
            AzureSession.ClientFactory.CreateArmClient<ComputeManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager));

            keyVaultManageClient = new Lazy<IKeyVaultManagementClient>(() =>
            AzureSession.ClientFactory.CreateArmClient<KeyVaultManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager));

            resourcesClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager));

            keyVaultClient = new Lazy<IKeyVaultClient>(() => 
            new KeyVaultClient(AuthenticationCallback));

            graphClient = new Lazy<GraphRbacManagementClient>(() =>
             AzureSession.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                DefaultProfile.Context, AzureEnvironment.Endpoint.Graph));          
        }

        #endregion

        #region VMSS 

        protected VirtualMachineScaleSet GetVmss(string name)
        {
            var result = ComputeClient.VirtualMachineScaleSets.List(ResourceGroupName);
            if (result == null || !result.Any())
            {
                throw new PSArgumentException(string.Format(
                    ServiceFabricProperties.Resources.NoneNodeTypeFound,
                    this.ResourceGroupName));
            }

            if (!string.IsNullOrEmpty(name))
            {
                var vmss = result.Where(
                    vm => string.Compare(vm.Name, name, StringComparison.OrdinalIgnoreCase) == 0
                    );

                if (vmss == null || !vmss.Any())
                {
                    throw new PSInvalidOperationException(
                        string.Format(
                            ServiceFabricProperties.Resources.CanNotFindTheNodeType,name));
                }

                return vmss.First();
            }
            else
            {
                return result.First();
            }
        }

        public VirtualMachineScaleSetExtension FindFabricVmExt(
            IList<VirtualMachineScaleSetExtension> extensions)
        {
            var extConfigs = extensions.Where(
                    e => string.Compare(
                        e.Type,
                        "ServiceFabricNode", StringComparison.OrdinalIgnoreCase) == 0);

            if (extConfigs == null || extConfigs.Count() != 1)
            {
                extConfigs = extensions.Where(
                   e => string.Compare(
                       e.Type,
                       "ServiceFabricLinuxNode", StringComparison.OrdinalIgnoreCase) == 0);

                if (extConfigs == null || extConfigs.Count() != 1)
                {
                    throw new PSInvalidOperationException(extConfigs.Count().ToString());
                }
            }

            return extConfigs.First();
        }

        #endregion

        #region Key Vault 

        protected Vault GetKeyVault(
            string keyVaultResouceGroupName,
            string vaultName)
        {
            if (!string.IsNullOrWhiteSpace(vaultName))
            {
                return SafeGetResource(() =>
                 KeyVaultManageClient.Vaults.Get(
                    keyVaultResouceGroupName,
                    vaultName));
            }
            else
            {
                throw new PSArgumentException(vaultName);
            }
        }

        protected Vault GetKeyVault(string secretIdentifier)
        {
            var host = new Uri(secretIdentifier).Host;
            var vaultName = host.Split('.')[0];
            var keyVaultRgName = GetResourceGroupName(vaultName);
            var vault = KeyVaultManageClient.Vaults.Get(keyVaultRgName, vaultName);

            if (vault == null)
            {
                throw new PSInvalidOperationException(
                    string.Format( 
                        ServiceFabricProperties.Resources.CanNotFindVault,
                        vaultName));
            }

            return new Vault(vault.Name, vault.Location, null, vault.Id);
        }

        protected string GetResourceGroupName(string vaultName)
        {
            var resourcesClient = new PSResourceManagerModels.ResourcesClient(DefaultContext)
            {
                VerboseLogger = WriteVerboseWithTimestamp,
                ErrorLogger = WriteErrorWithTimestamp,
                WarningLogger = WriteWarningWithTimestamp
            };
            string rg = null;
            var resourcesByName = resourcesClient.FilterResources(
                new PSResourceManagerModels.FilterResourcesOptions()
                {
                    ResourceType = Constants.KeyVaultType
                });

            if (resourcesByName != null && resourcesByName.Count > 0)
            {
                var vault = resourcesByName.FirstOrDefault(
                    r => r.Name.Equals(vaultName, StringComparison.OrdinalIgnoreCase));
                if (vault != null)
                    rg = new PSResourceManagerModels.ResourceIdentifier(vault.Id).ResourceGroupName;
            }

            return rg;
        }

        protected Vault CreateKeyVault(
            string vaultName,
            string vaultLocation,
            string resouceGroupName)
        {
            var userObjectId = string.Empty;
            AccessPolicyEntry accessPolicy = null;
            try
            {
                userObjectId = GetCurrentUserObjectId();
            }
            catch (Exception e)
            {
                WriteWarning(e.Message);
            }

            if (!string.IsNullOrWhiteSpace(userObjectId))
            {
                accessPolicy = new AccessPolicyEntry()
                {
                    TenantId =  GetTenantId(DefaultContext),
                    ObjectId = userObjectId,
                    Permissions = new Permissions
                    {
                        Keys = DefaultPermissionsToKeys,
                        Secrets = DefaultPermissionsToSecrets,
                        Certificates = DefaultPermissionsToCertificates
                    }
                };
            }

            var keyVaultParameter = new VaultCreateOrUpdateParameters()
            {
                Location = vaultLocation,
                Properties = new VaultProperties
                {
                    Sku = new Management.KeyVault.Models.Sku
                    {
                        Name = SkuName.Standard,
                    },
                    EnabledForDeployment = true,
                    TenantId = GetTenantId(DefaultContext),
                    VaultUri = string.Empty,
                    AccessPolicies = accessPolicy == null ?
                        new AccessPolicyEntry[] { } : 
                        new[] { accessPolicy }
                }
            };

            var vault = KeyVaultManageClient.Vaults.CreateOrUpdate(
                resouceGroupName,
                vaultName,
                keyVaultParameter);

            if (accessPolicy == null)
            {
                WriteWarning(ServiceFabricProperties.Resources.VaultCreatedWithOutAccessPolicy);
            }

            return vault;
        }

        protected Guid GetTenantId(AzureContext context)
        {
            var tenantId = string.Empty;
            if (context.Account == null)
                throw new PSArgumentException("ARM account not found");

            if (context.Account.Type != AzureAccount.AccountType.User &&
                context.Account.Type != AzureAccount.AccountType.ServicePrincipal)
                throw new ArgumentException("Unsupported account type");

            if (context.Subscription != null && context.Account != null)
                tenantId = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                       .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                       .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(tenantId) && context.Tenant != null && context.Tenant.Id != Guid.Empty)
                tenantId = context.Tenant.Id.ToString();

            if (string.IsNullOrEmpty(tenantId))
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CanNotFindTenantId);
            }

            var tenant = Guid.Parse(tenantId);
            return tenant;
        }

        protected Vault EnableKeyVaultForDeployment(
            string keyVaultResouceGroupName,
            string vaultName)
        {
            var keyVault = GetKeyVault(keyVaultResouceGroupName, vaultName);
            keyVault.Properties.EnabledForDeployment = true;

            var vault = KeyVaultManageClient.Vaults.CreateOrUpdate(
               ResourceGroupName,
               vaultName,
               new VaultCreateOrUpdateParameters()
               {
                   Location = keyVault.Location,
                   Properties = keyVault.Properties,
                   Tags = keyVault.Tags
               });

            return vault;
        }

        protected SecretBundle SetAzureKeyVaultSecret(
            string keyVaultName,
            string secretName,
            string pfxFilePath,
            SecureString password
            )
        {
            var keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(pfxFilePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(
                    string.Format(ServiceFabricProperties.Resources.FileNotExist, pfxFilePath));
            }

            var collection = new X509Certificate2Collection();
            var flag = X509KeyStorageFlags.Exportable;
            var contentType = X509ContentType.Pkcs12;

            collection.Import(
                pfxFilePath,
                password.ConvertToString(), 
                flag);

            var clearBytes = collection.Export(contentType);
            var fileContentEncoded = Convert.ToBase64String(clearBytes);
            var secureStr = new SecureString();
            foreach (var c in fileContentEncoded)
            {
                secureStr.AppendChar(c);
            }

            var secretContentType = "application/x-pkcs12";
            var secret = KeyVaultClient.SetSecretAsync(
                CreateVaultUri(keyVaultName).ToString(),
                secretName,
                secureStr.ConvertToString(),
                contentType: secretContentType).GetAwaiter().GetResult();

            return secret;
        }

        protected string GetCurrentUserObjectId()
        {
            GraphClient.TenantID = GetTenantId(DefaultContext).ToString();

            string objectId = null;
            try
            {
                var user = GraphClient.Users.List(
                    new Rest.Azure.OData.ODataQuery<User>(
                        string.Format("$filter=userPrincipalName eq '{0}'" , DefaultContext.Account.Id)
                        )).FirstOrDefault();

                objectId = user.ObjectId;
            }
            catch (GraphErrorException e)
            {
                if (e.Body != null && e.Body.Code == "Authorization_RequestDenied")
                {
                    var user = GraphClient.ServicePrincipals.List(
                        new Rest.Azure.OData.ODataQuery<ServicePrincipal>(
                            string.Format("$filter=servicePrincipalNames/any(c: c eq '{0}')", DefaultContext.Account.Id))
                        ).FirstOrDefault();

                    objectId = user.ObjectId;                  
                }
            }

            return objectId;
        }

        protected Uri CreateVaultUri(string vaultName)
        {
            string suffix = string.Empty;
            if (DefaultContext.Environment.Endpoints.ContainsKey(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix))
            {
                 suffix = DefaultContext.Environment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix];
            }
            else
            {
                suffix = AzureEnvironmentConstants.AzureKeyVaultDnsSuffix;
            }

            var builder = new UriBuilder("https", vaultName + "." + suffix);

            return builder.Uri;
        }

        private Task<string> AuthenticationCallback(
            string authority,
            string resource,
            string scope)
        {
            if (!string.IsNullOrEmpty(resource))
            {
                DefaultContext.Environment.Endpoints
                    [AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId] = resource;
            }

            var tokenCache = AzureSession.TokenCache;
            if (DefaultContext.TokenCache != null && DefaultContext.TokenCache.Length > 0)
            {
                tokenCache = new TokenCache(DefaultContext.TokenCache);
            }

            var accesstoken = AzureSession.AuthenticationFactory.Authenticate(
                DefaultContext.Account,
                DefaultContext.Environment,
                GetTenantId(DefaultContext).ToString(),
                null,
                ShowDialog.Never,
                tokenCache,
                AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            var tokenStr = string.Empty;
            accesstoken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });

            return Task.FromResult(tokenStr);
        }


        protected T SafeGetResource<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Rest.Azure.CloudException ce)
            {
                if (ce.Response != null && ce.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }

                throw;
            }
            catch (Management.ServiceFabric.Models.ErrorModelException e)
            {
                if (e.Body?.Error != null && 
                   (e.Body.Error.Code == "ResourceGroupNotFound" ||
                    e.Body.Error.Code == "ResourceNotFound"))
                {
                    return default(T);
                }

                throw;
            }
        }

        #endregion
    }
}
