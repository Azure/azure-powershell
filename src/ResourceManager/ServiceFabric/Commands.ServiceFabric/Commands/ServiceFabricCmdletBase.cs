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
using System.Text;
using System.Threading.Tasks;
using Action = System.Action;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricCmdletBase : AzureRMCmdlet
    {
        private const int NewCreatedKeyVaultWaitTimeInSec = 15;

        internal static int WriteVerboseIntervalInSec = 20;

        #region TEST
        internal static bool RunningTest = false;
        internal static string TestThumbprint = string.Empty;
        #endregion

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public virtual string ResourceGroupName { get; set; }

        #region Key Vault Property 

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

        internal IServiceFabricManagementClient SFRPClient
        {
            get { return sfrpClient.Value; }
            set { sfrpClient = new Lazy<IServiceFabricManagementClient>(() => value); }
        }

        internal IComputeManagementClient ComputeClient
        {
            get { return computeClient.Value; }
            set { computeClient = new Lazy<IComputeManagementClient>(() => value); }
        }

        internal IKeyVaultManagementClient KeyVaultManageClient
        {
            get { return keyVaultManageClient.Value; }
            set { keyVaultManageClient = new Lazy<IKeyVaultManagementClient>(() => value); }
        }

        internal IResourceManagementClient ResourcesClient
        {
            get { return resourcesClient.Value; }
            set { resourcesClient = new Lazy<IResourceManagementClient>(() => value); }
        }

        internal GraphRbacManagementClient GraphClient
        {
            get { return graphClient.Value; }
            set { graphClient = new Lazy<GraphRbacManagementClient>(() => value); }
        }

        internal IKeyVaultClient KeyVaultClient
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
                var armClient = AzureSession.Instance.ClientFactory.
                CreateArmClient<ServiceFabricManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager);
                return armClient;
            });

            computeClient = new Lazy<IComputeManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            keyVaultManageClient = new Lazy<IKeyVaultManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            resourcesClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            keyVaultClient = new Lazy<IKeyVaultClient>(() =>
            new KeyVaultClient(AuthenticationCallback));

            graphClient = new Lazy<GraphRbacManagementClient>(() =>
             AzureSession.Instance.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                DefaultContext, AzureEnvironment.Endpoint.Graph));
        }

        #endregion

        #region VMSS 

        protected VirtualMachineScaleSet GetVmss(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new PSArgumentNullException("Invalid vmss name");
            }

            var result = ComputeClient.VirtualMachineScaleSets.List(ResourceGroupName);
            if (result == null || !result.Any())
            {
                throw new PSArgumentException(string.Format(
                    ServiceFabricProperties.Resources.NoneNodeTypeFound,
                    this.ResourceGroupName));
            }

            var vmss = result.FirstOrDefault(
                vm => vm.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (vmss == null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType, name));
            }

            return vmss;
        }

        public VirtualMachineScaleSetExtension FindFabricVmExt(IList<VirtualMachineScaleSetExtension> extensions)
        {
            var extConfigs = extensions.Where(
                    e =>e.Type.Equals(
                       Constants.ServiceFabricWindowsNodeExtName, StringComparison.OrdinalIgnoreCase));

            if (!extConfigs.Any())
            {
                extConfigs = extensions.Where(
                   e => e.Type.Equals(Constants.ServiceFabricLinuxNodeExtName, StringComparison.OrdinalIgnoreCase));

                if (!extConfigs.Any())
                {
                    throw new PSInvalidOperationException(extConfigs.Count().ToString());
                }
            }

            return extConfigs.First();
        }

        #endregion

        #region Key Vault 

        protected Vault TryGetKeyVault(string keyVaultResouceGroupName, string vaultName)
        {
            if (!string.IsNullOrWhiteSpace(vaultName))
            {
                return SafeGetResource(() => KeyVaultManageClient.Vaults.Get(
                    keyVaultResouceGroupName,
                    vaultName),
                    false);
            }
            else
            {
                throw new PSArgumentException(vaultName);
            }
        }

        protected Vault TryGetKeyVault(string secretIdentifier)
        {
            var host = new Uri(secretIdentifier).Host;
            var vaultName = host.Split('.')[0];
            var keyVaultRgName = GetResourceGroupName(vaultName);
            return TryGetKeyVault(keyVaultRgName, vaultName);
        }

        protected string GetResourceGroupName(string vaultName)
        {
            string rg = null;
            var resourcesByName = this.ResourcesClient.FilterResources(
                new FilterResourcesOptions()
                {
                    ResourceType = Constants.KeyVaultType
                });

            if (resourcesByName != null && resourcesByName.Count > 0)
            {
                var vault = resourcesByName.FirstOrDefault(
                    r => r.Name.Equals(vaultName, StringComparison.OrdinalIgnoreCase));
                if (vault != null)
                {
                    rg = new ResourceIdentifier(vault.Id).ResourceGroupName;
                }
            }

            return rg;
        }

        protected Vault CreateKeyVault(string clusterName, string vaultName, string vaultLocation, string resouceGroupName)
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
                    TenantId = GetTenantId(DefaultContext),
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
                },
                Tags = new Dictionary<string, string>()
                {
                    { "clusterName",clusterName },
                    { "resourceType" ,Constants.ServieFabricTag }
                }
            };

            var vault = KeyVaultManageClient.Vaults.CreateOrUpdate(
                resouceGroupName,
                vaultName,
                keyVaultParameter);

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(NewCreatedKeyVaultWaitTimeInSec));

            if (accessPolicy == null)
            {
                WriteWarning(ServiceFabricProperties.Resources.VaultCreatedWithOutAccessPolicy);
            }

            return vault;
        }

        protected Guid GetTenantId(IAzureContext context)
        {
            var tenantId = string.Empty;
            if (context.Account == null)
            {
                throw new PSArgumentException("ARM account not found");
            }

            if (context.Account.Type != AzureAccount.AccountType.User &&
                context.Account.Type != AzureAccount.AccountType.ServicePrincipal)
            {
                throw new PSArgumentException("Unsupported account type");
            }

            if (context.Subscription != null && context.Account != null)
            {
                tenantId = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                    .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                    .FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(tenantId) && context.Tenant != null && context.Tenant.GetId() != Guid.Empty)
            {
                tenantId = context.Tenant.Id.ToString();
            }

            if (string.IsNullOrEmpty(tenantId))
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CannotFindTenantId);
            }

            var tenant = Guid.Parse(tenantId);
            return tenant;
        }

        protected Vault EnableKeyVaultForDeployment(string keyVaultResouceGroupName, string vaultName)
        {
            var keyVault = TryGetKeyVault(keyVaultResouceGroupName, vaultName);
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

        protected CertificateBundle ImportCertificateToAzureKeyVault(string keyVaultName, string certificateName, string pfxFilePath, SecureString password, out string thumbprint)
        {
            var keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(pfxFilePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(
                    string.Format(ServiceFabricProperties.Resources.FileNotExist, pfxFilePath));
            }

            thumbprint = new X509Certificate2(pfxFilePath, password).Thumbprint;

            var collection = new X509Certificate2Collection();
            var flag = X509KeyStorageFlags.Exportable;
            var contentType = X509ContentType.Pfx;

            var clearPassword = password == null ? string.Empty : password.ConvertToString();
            collection.Import(pfxFilePath, clearPassword, flag);

            var clearBytes = collection.Export(contentType, clearPassword);
            if (clearBytes == null || clearBytes.Count() == 0)
            {
                throw new PSArgumentException("Invalid pfx");
            }

            var fileContentEncoded = Convert.ToBase64String(clearBytes);

            WriteVerboseWithTimestamp(string.Format("Importing certificate to Azure KeyVault {0}", certificateName));
            var certificateBundle = this.KeyVaultClient.ImportCertificateAsync(
                CreateVaultUri(keyVaultName).ToString(),
                certificateName,
                fileContentEncoded,
                clearPassword,
                new CertificatePolicy
                {
                    SecretProperties = new SecretProperties
                    {
                        ContentType = Constants.SecretContentType
                    }
                }
                ).GetAwaiter().GetResult();

            WriteVerboseWithTimestamp(string.Format("Certificate imported Azure KeyVault {0}", certificateBundle.CertificateIdentifier));

            return certificateBundle;
        }

        protected string GetCurrentUserObjectId()
        {
            GraphClient.TenantID = GetTenantId(DefaultContext).ToString();

            string objectId = null;
            try
            {
                var user = GraphClient.Users.List(
                    new Rest.Azure.OData.ODataQuery<User>(
                        string.Format("$filter=userPrincipalName eq '{0}'", DefaultContext.Account.Id)
                        )).FirstOrDefault();

                if (user == null)
                {
                    return null;
                }

                objectId = user.ObjectId;
            }
            catch (GraphErrorException)
            {
                var user = GraphClient.ServicePrincipals.List(
                    new Rest.Azure.OData.ODataQuery<ServicePrincipal>(
                        string.Format("$filter=servicePrincipalNames/any(c: c eq '{0}')", DefaultContext.Account.Id))
                    ).FirstOrDefault();

                if (user == null)
                {
                    return null;
                }

                objectId = user.ObjectId;  
            }

            return objectId;
        }

        protected Uri CreateVaultUri(string vaultName)
        {
            string suffix = string.Empty;
            if (!string.IsNullOrEmpty(DefaultContext.Environment.AzureKeyVaultDnsSuffix))
            {
                suffix = DefaultContext.Environment.AzureKeyVaultDnsSuffix;
            }
            else
            {
                suffix = AzureEnvironmentConstants.AzureKeyVaultDnsSuffix;
            }

            var builder = new UriBuilder("https", vaultName + "." + suffix);

            return builder.Uri;
        }

        private Task<string> AuthenticationCallback(string authority, string resource, string scope)
        {
            var accesstoken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                DefaultContext.Account,
                DefaultContext.Environment,
                GetTenantId(DefaultContext).ToString(),
                null,
                ShowDialog.Never,
                null,
                AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            var tokenStr = string.Empty;
            accesstoken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });

            return Task.FromResult(tokenStr);
        }

        #endregion

        #region Helper     

        protected T SafeGetResource<T>(Func<T> action, bool ingoreAllError)
        {
            try
            {
                return action();
            }
            catch (CloudException ce)
            {
                if (ce.Response != null && ce.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }

                if (ingoreAllError)
                {
                    WriteWarning(ce.ToString());
                    return default(T);
                }

                throw;
            }
            catch (ErrorModelException e)
            {
                if (e.Body?.Error != null &&
                    (e.Body.Error.Code.Equals("ResourceGroupNotFound", StringComparison.OrdinalIgnoreCase) ||
                     e.Body.Error.Code.Equals("ResourceNotFound", StringComparison.OrdinalIgnoreCase)||
                     e.Body.Error.Code.Equals("NotFound", StringComparison.OrdinalIgnoreCase)))
                {
                    return default(T);
                }

                if (ingoreAllError)
                {
                    WriteWarning(e.ToString());
                    return default(T);
                }

                throw;
            }
            catch (Exception e)
            {
                if (ingoreAllError)
                {
                    WriteWarning(e.ToString());
                    return default(T);
                }

                throw;
            }
        }

        protected void PrintDetailIfThrow(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                PrintSdkExceptionDetail(exception);

                throw;
            }
        }

        protected void PrintSdkExceptionDetail(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            while (!(exception is CloudException || exception is ErrorModelException) && exception.InnerException != null)
            {
                exception = exception.InnerException;
            }
          
            if (exception is CloudException)
            {
                var cloudException = (CloudException)exception;
                if (cloudException.Body != null)
                {
                    var cloudErrorMessage = GetCloudErrorMessage(cloudException.Body);
                    var ex = new Exception(cloudErrorMessage);
                    WriteError(
                        new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }

            if (exception is ErrorModelException)
            {
                var errorModelException = (ErrorModelException)exception;
                if (errorModelException.Body != null)
                {
                    var cloudErrorMessage = GetErrorModelErrorMessage(errorModelException.Body);
                    var ex = new Exception(cloudErrorMessage);
                    WriteError(
                        new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
        }

        private string GetCloudErrorMessage(CloudError error)
        {
            if (error == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            if (error.Details != null)
            {
                foreach (var detail in error.Details)
                {
                    sb.Append(GetCloudErrorMessage(detail));
                }                                        
            }

            var message = string.Format(
                "Code:{0}, Message:{1} ,Details: {3}{2}",  
                error.Code,                      
                error.Message,         
                Environment.NewLine,  
                sb);

            return message;
        }

        private string GetErrorModelErrorMessage(ErrorModel error)
        {
            if (error == null || error.Error == null)
            {
                return string.Empty;
            }

            var message = string.Format(
                "Code:{0}, Message:{1}{2}",
                error.Error.Code,
                error.Error.Message,
                Environment.NewLine);

            return message;
        }
        #endregion
    }
}
