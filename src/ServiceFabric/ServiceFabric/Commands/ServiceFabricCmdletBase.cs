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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Action = System.Action;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json.Linq;
using System.Threading;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Newtonsoft.Json;
using SFResource = Microsoft.Azure.Management.ServiceFabric.Models.Resource;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricCmdletBase : ServiceFabricCommonCmdletBase
    {
        internal static int NewCreatedKeyVaultWaitTimeInSec = 15;

        #region TEST
        internal static bool RunningTest = false;
        internal static string TestThumbprint = string.Empty;
        internal static string TestCommonNameCACert = string.Empty;
        internal static string TestCommonNameAppCert = string.Empty;
        internal static string TestThumbprintAppCert = string.Empty;
        internal static bool TestAppCert = false;
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
        private Lazy<ServiceFabricManagementClient> sfrpClient;
        private Lazy<IComputeManagementClient> computeClient;
        private Lazy<IKeyVaultManagementClient> keyVaultManageClient;
        private Lazy<GraphRbacManagementClient> graphClient;
        private Lazy<IKeyVaultClient> keyVaultClient;

        internal ServiceFabricManagementClient SFRPClient
        {
            get { return sfrpClient.Value; }
            set { sfrpClient = new Lazy<ServiceFabricManagementClient>(() => value); }
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

        public ServiceFabricCmdletBase() : base()
        {
            InitializeAzureRmClients();
        }

        private void InitializeAzureRmClients()
        {
            this.sfrpClient = new Lazy<ServiceFabricManagementClient>(() =>
            {
                var armClient = AzureSession.Instance.ClientFactory.
                CreateArmClient<ServiceFabricManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager);
                return armClient;
            });

            this.computeClient = new Lazy<IComputeManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            this.keyVaultManageClient = new Lazy<IKeyVaultManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));

            this.keyVaultClient = new Lazy<IKeyVaultClient>(() =>
            new KeyVaultClient(AuthenticationCallback));

            this.graphClient = new Lazy<GraphRbacManagementClient>(() =>
             AzureSession.Instance.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                DefaultContext, AzureEnvironment.Endpoint.Graph));
        }

        #endregion

        #region VMSS 

        protected VirtualMachineScaleSet GetVmss(string name, string clusterId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new PSArgumentNullException("Invalid vmss name");
            }

            var vmssPages = ComputeClient.VirtualMachineScaleSets.List(ResourceGroupName);
            if (vmssPages == null || !vmssPages.Any())
            {
                throw new PSArgumentException(string.Format(
                    ServiceFabricProperties.Resources.NoVMSSFoundInRG,
                    this.ResourceGroupName));
            }

            do
            {
                if (!vmssPages.Any())
                {
                    break;
                }

                foreach (var vmss in vmssPages)
                {
                    VirtualMachineScaleSetExtension sfExtension;
                    if (TryGetFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile?.Extensions, out sfExtension))
                    {
                        if (string.Equals(GetClusterIdFromExtension(sfExtension), clusterId, StringComparison.OrdinalIgnoreCase))
                        {
                            WriteVerboseWithTimestamp(string.Format("GetVmss: Found vmss {0} that corresponds to cluster id {1}", vmss.Id, clusterId));
                            string nodeTypeRef = GetNodeTypeRefFromExtension(sfExtension);
                            if (string.Equals(nodeTypeRef, name, StringComparison.OrdinalIgnoreCase))
                            {
                                return vmss;
                            }
                        }
                    }
                }
            } while (!string.IsNullOrEmpty(vmssPages.NextPageLink) &&
                     (vmssPages = this.ComputeClient.VirtualMachineScaleSets.ListNext(vmssPages.NextPageLink)) != null);

            throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindVMSS,
                        name));
        }

        public bool TryGetFabricVmExt(IList<VirtualMachineScaleSetExtension> extensions, out VirtualMachineScaleSetExtension sfExtension)
        {
            if (extensions == null)
            {
                sfExtension = null;
                return false;
            }

            sfExtension = extensions.FirstOrDefault(ext => IsSFExtension(ext));
            return sfExtension != null;
        }

        public string GetClusterIdFromExtension(VirtualMachineScaleSetExtension sfExtension)
        {
            string clusterEndpoint = GetSettingFromExtension(sfExtension, "clusterEndpoint");
            string id = clusterEndpoint?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            return id;
        }

        public string GetNodeTypeRefFromExtension(VirtualMachineScaleSetExtension sfExtension)
        {
            return GetSettingFromExtension(sfExtension, "nodeTypeRef");
        }

        public string GetDurabilityLevelFromExtension(VirtualMachineScaleSetExtension sfExtension)
        {
            return GetSettingFromExtension(sfExtension, "durabilityLevel");
        }

        internal string GetSettingFromExtension(VirtualMachineScaleSetExtension sfExtension, string settingName)
        {
            JObject extSettings = sfExtension.Settings as JObject;
            return (string)extSettings.SelectToken(settingName);
        }

        #endregion

        #region Key Vault 

        protected Vault TryGetKeyVault(string keyVaultResouceGroupName, string vaultName)
        {
            if (string.IsNullOrWhiteSpace(keyVaultResouceGroupName))
            {
                throw new PSArgumentException(keyVaultResouceGroupName);
            }

            if (string.IsNullOrWhiteSpace(vaultName))
            {
                throw new PSArgumentException(vaultName);
            }

            return SafeGetResource(() => KeyVaultManageClient.Vaults.Get(
                keyVaultResouceGroupName,
                vaultName),
                false);
        }

        protected Vault TryGetKeyVault(string secretIdentifier)
        {
            var host = new Uri(secretIdentifier).Host;
            var vaultName = host.Split('.')[0];
            var keyVaultRgName = GetResourceGroupName(vaultName);
            if (string.IsNullOrWhiteSpace(keyVaultRgName))
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentUICulture,
                        ServiceFabricProperties.Resources.CannotFindVaultFromSecretId,
                        vaultName,
                        secretIdentifier));
            }

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
                    Sku = new Azure.Commands.Common.KeyVault.Version2016_10_1.Models.Sku
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

        protected CertificateBundle ImportCertificateToAzureKeyVault(string keyVaultName, string certificateName, string pfxFilePath, SecureString password, out string thumbprint, out string commonName)
        {
            var keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(pfxFilePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(
                    string.Format(ServiceFabricProperties.Resources.FileNotExist, pfxFilePath));
            }

            var cert = new X509Certificate2(pfxFilePath, password);
            thumbprint = cert.Thumbprint;
            commonName = cert.GetNameInfo(X509NameType.SimpleName, false);

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

            WriteVerboseWithTimestamp(string.Format("Certificate imported Azure KeyVault {0}", certificateBundle.Id));

            return certificateBundle;
        }

        protected string GetCurrentUserObjectId()
        {
            GraphClient.TenantID = GetTenantId(DefaultContext).ToString();

            try
            {
                var user = GraphClient.Users.List(
                    new Rest.Azure.OData.ODataQuery<User>(
                        string.Format("$filter=userPrincipalName eq '{0}'", DefaultContext.Account.Id)
                        )).FirstOrDefault();

                return user?.ObjectId;
            }
            catch (GraphErrorException)
            {
                var user = GraphClient.ServicePrincipals.List(
                    new Rest.Azure.OData.ODataQuery<ServicePrincipal>(
                        string.Format("$filter=servicePrincipalNames/any(c: c eq '{0}')", DefaultContext.Account.Id))
                    ).FirstOrDefault();

                return user?.ObjectId;
            }
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

        protected T StartRequestAndWait<T>(Func<Task<AzureOperationResponse<T>>> requestAction, Func<string> getResourceCurrentStatus) where T : class
        {
            var progress = new ProgressRecord(0, string.Format("Request for {0} in progress", typeof(T).Name), "Starting...");
            WriteProgress(progress);
            AzureOperationResponse<T> beginRequestResponse = null;
            AzureOperationResponse<T> result = null;
            string armCorrelationId = string.Empty;
            var tokenSource = new CancellationTokenSource();
            try
            {
                var requestTask = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        beginRequestResponse = requestAction().GetAwaiter().GetResult();
                        result = this.SFRPClient.GetPutOrPatchOperationResultAsync(beginRequestResponse, null, default(CancellationToken)).GetAwaiter().GetResult();
                    }
                    finally
                    {
                        tokenSource.Cancel();
                    }
                });

                bool correlationPrinted = false;
                while (!tokenSource.IsCancellationRequested)
                {
                    tokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));

                    if (!RunningTest)
                    {
                        if (!correlationPrinted && beginRequestResponse != null)
                        {
                            WriteVerboseWithTimestamp(string.Format(
                                "Begin request ARM correlationId: '{0}' response: '{1}'",
                                beginRequestResponse.RequestId,
                                beginRequestResponse.Response.StatusCode));
                            correlationPrinted = true;
                        }

                        string progressMessage = getResourceCurrentStatus();
                        WriteVerboseWithTimestamp(progressMessage);
                        progress.StatusDescription = progressMessage;
                        WriteProgress(progress);
                    }
                }

                if (requestTask.IsFaulted)
                {
                    string errorMessage = "Begin request operation failed";
                    if (beginRequestResponse != null)
                    {
                        errorMessage = string.Format(
                            "Operation Failed. Begin request with ARM correlationId: '{0}' response: '{1}'",
                            beginRequestResponse.RequestId,
                            beginRequestResponse.Response.StatusCode);
                        
                    }

                    WriteErrorWithTimestamp(errorMessage);
                    throw requestTask.Exception;
                }
            }
            catch (Exception e)
            {
                PrintSdkExceptionDetail(e);
                throw;
            }
            
            return result?.Body;
        }

        private bool IsSFExtension(VirtualMachineScaleSetExtension vmssExt)
        {
            return vmssExt.Type.Equals(Constants.ServiceFabricWindowsNodeExtName, StringComparison.OrdinalIgnoreCase)
                   || vmssExt.Type.Equals(Constants.ServiceFabricLinuxNodeExtName, StringComparison.OrdinalIgnoreCase)
                   || (vmssExt.Type.Contains(Constants.ServiceFabricExtNamePrefix) && vmssExt.Type.Contains(Constants.ServiceFabricExtNameSuffix));
        }
        #endregion

        #region deployment helper
        private const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";

        protected void CheckValidationResult(DeploymentValidateResult validateResult)
        {
            if (validateResult.Error != null)
            {
                if (validateResult.Error.Details != null)
                {
                    foreach (var error in validateResult.Error.Details)
                    {
                        var ex = new Exception(
                            string.Format(ErrorFormat, error.Code, error.Message));
                        WriteError(
                            new ErrorRecord(
                                ex,
                                string.Empty,
                                ErrorCategory.NotSpecified,
                                null));

                        if (error.Details != null && error.Details.Count > 0)
                        {
                            foreach (var innerError in error.Details)
                            {
                                DisplayInnerDetailErrorMessage(innerError);
                            }
                        }
                    }
                }
                else
                {
                    var ex = new Exception(
                           string.Format(ErrorFormat, validateResult.Error.Code, validateResult.Error.Message));
                    WriteError(
                           new ErrorRecord(
                               ex,
                               string.Empty,
                               ErrorCategory.NotSpecified,
                               null));
                }

                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.DeploymentFailed);
            }
        }

        protected Deployment CreateBasicDeployment(DeploymentMode deploymentMode, string templateFilePath, string parameterFilePath, string debugSetting = null, JObject parameters = null)
        {
            var deployment = new Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = deploymentMode
                }
            };

            if (!string.IsNullOrEmpty(debugSetting))
            {
                deployment.Properties.DebugSetting = new DebugSetting()
                {
                    DetailLevel = debugSetting
                };
            }

            JObject templateJObject;

            if (!TryParseJson(templateFilePath, out templateJObject))
            {
                throw new PSArgumentException(Properties.Resources.InvalidTemplateFile);
            }

            deployment.Properties.Template = templateJObject;

            if (parameters == null)
            {
                JObject parameterJObject;

                if (!TryParseJson(parameterFilePath, out parameterJObject))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidTemplateParameterFile);
                }

                if (parameterJObject["parameters"] == null)
                {
                    throw new PSArgumentException(Properties.Resources.InvalidTemplateParameterFile);
                }

                deployment.Properties.Parameters = parameterJObject["parameters"];
            }
            else
            {
                deployment.Properties.Parameters = parameters;
            }

            return deployment;
        }

        protected void SetParameter(ref JObject parameters, string parameterName, int value)
        {
            var token = parameters.Children().SingleOrDefault(
                    j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

            if (token != null)
            {
                token.First()["value"] = value;
            }
            else
            {
                parameters.Add(parameterName, value);
            }
        }

        protected void SetParameter(ref JObject parameters, string parameterName, string value)
        {
            if (value != null)
            {
                var token = parameters.Children().SingleOrDefault(
                        j => ((JProperty)j).Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));

                if (token != null && token.Any())
                {
                    token.First()["value"] = value;
                }
                else
                {
                    parameters.Add(parameterName, value);
                }
            }
        }

        protected string TranslateToParameterName(string parameter, string templateFilePath)
        {
            var parameterArray = parameter.Split(
                new char[] { '[', ']', '(', ')', '\'' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parameterArray.Count() <= 1)
            {
                return parameter;
            }

            if (parameterArray[0].Equals("variables", StringComparison.OrdinalIgnoreCase))
            {
                JObject jObject;
                if (!TryParseJson(templateFilePath, out jObject))
                {
                    throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidTemplateFile);
                }

                var variables = jObject.SelectToken("variables", true);
                return TranslateToParameterName(variables[parameterArray[1]].ToString(), templateFilePath);
            }
            else
            {
                return parameterArray[1];
            }
        }

        protected bool TryParseJson(string filePath, out JObject jObject)
        {
            var content = FileUtilities.DataStore.ReadFileAsText(filePath);
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new PSArgumentException(content);
            }

            try
            {
                jObject = JObject.Parse(content);
                return true;
            }
            catch (JsonReaderException)
            {
                jObject = null;
                return false;
            }
        }

        private void DisplayInnerDetailErrorMessage(ResourceManagementErrorWithDetails error)
        {
            var ex = new Exception(string.Format(ErrorFormat, error.Code, error.Message));
            WriteError(
               new ErrorRecord(
                   ex,
                   string.Empty,
                   ErrorCategory.NotSpecified,
                   null));

            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    DisplayInnerDetailErrorMessage(innerError);
                }
            }
        }
        #endregion
    }
}
