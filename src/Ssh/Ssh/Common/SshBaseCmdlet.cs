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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common;
using Microsoft.Azure.Commands.Ssh.Properties;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Rest.Azure.OData;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Commands.Ssh

{

    public abstract class SshBaseCmdlet : AzureRMCmdlet
    {

        #region Constants
        protected internal const string InteractiveParameterSet = "Interactive";
        protected internal const string ResourceIdParameterSet = "ResourceId";
        protected internal const string IpAddressParameterSet = "IpAddress";
        #endregion

        #region Fields
        protected internal bool deleteKeys;
        protected internal bool deleteCert;
        protected internal string proxyPath;

        protected internal readonly string[] supportedResourceTypes = {
            "Microsoft.HybridCompute/machines",
            "Microsoft.Compute/virtualMachines",
            "Microsoft.ConnectedVMwarevSphere/virtualMachines",
            "Microsoft.ScVmm/virtualMachines",
            "Microsoft.AzureStackHCI/virtualMachines"};
        #endregion

        #region Properties
        internal IpUtils IpUtils
        {
            get
            {
                if (_ipUtils == null)
                {
                    _ipUtils = new IpUtils(DefaultProfile.DefaultContext);
                }

                return _ipUtils;
            }
        }
        private IpUtils _ipUtils;

        private HybridConnectivityClient HybridConnectivityClient
        {
            get
            {
                if (_hyridConnectivityClient == null)
                {
                    _hyridConnectivityClient = new HybridConnectivityClient(DefaultProfile.DefaultContext);
                }
                return _hyridConnectivityClient;
            }
        }
        private HybridConnectivityClient _hyridConnectivityClient;

        private IEndpointsOperations EndpointsClient
        {
            get
            {
                return HybridConnectivityClient.HybridConectivityManagementClient.Endpoints;
            }
        }

        private ResourceManagementClient ResourceManagementClient
        {
            get
            {
                if (_resourceManagementClient == null)
                {
                    _resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }
                return _resourceManagementClient;
            }
        }
        private ResourceManagementClient _resourceManagementClient;
        #endregion

        #region Parameters
        /// <summary>
        /// The name of the resource group. The name is case insensitive.
        /// </summary>
        [Parameter(
            ParameterSetName = InteractiveParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the target Azure Virtual Machine or Arc Server.
        /// </summary>
        [Parameter(
            ParameterSetName = InteractiveParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [SshResourceNameCompleter(
            new string[] {
                "Microsoft.Compute/virtualMachines",
                "Microsoft.HybridCompute/machines",
                "Microsoft.ConnectedVMwarevSphere/virtualMachines",
                "Microsoft.ScVmm/virtualMachines",
                "Microsoft.AzureStackHCI/virtualMachines"
            },
            "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The IP address of the target Azure Virtual Machine.
        /// </summary>
        [Parameter(
            ParameterSetName = IpAddressParameterSet,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Ip { get; set; }

        /// <summary>
        /// Id of the target Azure Virtual Machine or Arc Server.
        /// </summary>
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SshResourceIdCompleter(
            new string[] {
                "Microsoft.Compute/virtualMachines",
                "Microsoft.HybridCompute/machines",
                "Microsoft.ConnectedVMwarevSphere/virtualMachines",
                "Microsoft.ScVmm/virtualMachines",
                "Microsoft.AzureStackHCI/virtualMachines"
            }
        )]
        public string ResourceId { get; set; }

        /// <summary>
        /// Path to the generated config file.
        /// </summary>
        [Parameter(
            ParameterSetName = InteractiveParameterSet,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = IpAddressParameterSet,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public virtual string ConfigFilePath { get; set; }

        /// <summary>
        /// Path to a Public Key File that will be signed by AAD to create certificate for AAD login.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PublicKeyFile { get; set; }

        /// <summary>
        /// Path to a Private Key File.
        /// Can be used for key based authentication when connecting to a LocalUser
        /// or it can be used in conjuction with a signed public key for AAD Login.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PrivateKeyFile { get; set; }

        /// <summary>
        /// Gets or sets a flag that uses a Private Ip when connecting to an Azure Virtual Machine.
        /// User must have a line of sight to the Private Ip. Will fail if no private ip can be found.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UsePrivateIp { get; set; }

        /// <summary>
        /// Name of a local user in the target machine to connect to.
        /// To connect using AAD certificates, don't use this argument.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string LocalUser { get; set; }

        /// <summary>
        /// Port number to connect to on the remote target host.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Port { get; set; }

        /// <summary>
        /// The Type of the target Azure Resource.
        /// Either Microsoft.Compute/virtualMachines, Microsoft.HybridCompute/machines, Microsoft.ConnectedVMwarevSphere/virtualMachines, Microsoft.ScVmm/virtualMachines, Microsoft.AzureStackHCI/virtualMachines.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [ValidateSet(
            "Microsoft.HybridCompute/machines",
            "Microsoft.Compute/virtualMachines",
            "Microsoft.ConnectedVMwarevSphere/virtualMachines",
            "Microsoft.ScVmm/virtualMachines",
            "Microsoft.AzureStackHCI/virtualMachines"
        )]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Certificate File for authentication when connecting to a Local User account.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CertificateFile { get; set; }

        /// <summary>
        /// Additional SSH arguments.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet, ValueFromRemainingArguments = true)]
        [Parameter(ParameterSetName = IpAddressParameterSet, ValueFromRemainingArguments = true)]
        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromRemainingArguments = true)]
        [ValidateNotNullOrEmpty]
        public virtual string[] SshArgument { get; set; }

        /// <summary>
        /// Overwrite existing ConfigFile
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual SwitchParameter Overwrite { get; set; }

        /// <summary>
        /// Folder where generated keys will be saved.
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string KeysDestinationFolder { get; set; }

        /// <summary>
        /// RDP over SSH
        /// </summary>
        [Parameter(ParameterSetName = InteractiveParameterSet)]
        [Parameter(ParameterSetName = IpAddressParameterSet)]
        [Parameter(ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual SwitchParameter Rdp { get; set; }

        [Parameter(Mandatory = false)]
        public virtual SwitchParameter PassThru { get; set; }

        #endregion

        #region Protected Internal Methods

        protected internal void ValidateParameters()
        {
            if (Rdp && !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new AzPSArgumentException(Resources.RDPOnNonWindowsClient, nameof(Rdp));
            }

                if (CertificateFile != null)
            {
                if (LocalUser == null)
                    WriteWarning(Resources.WarningCertificateWithNoLocalUser);
                else
                    CertificateFile = GetResolvedPath(CertificateFile, nameof(CertificateFile));
            }

            if (PrivateKeyFile != null)
            {
                PrivateKeyFile = GetResolvedPath(PrivateKeyFile, nameof(PrivateKeyFile));
            }

            if (PublicKeyFile != null)
            {
                PublicKeyFile = GetResolvedPath(PublicKeyFile, nameof(PublicKeyFile));
            }

            if (ConfigFilePath != null)
            {
                ConfigFilePath = GetUnresolvedPath(ConfigFilePath, nameof(ConfigFilePath));

                if (Directory.Exists(ConfigFilePath))
                {
                    throw new AzPSArgumentException(String.Format(Resources.ConfigFilePathIsDirectory, ConfigFilePath), nameof(ConfigFilePath));
                }

                string configFolder = Path.GetDirectoryName(ConfigFilePath);
                if (!Directory.Exists(configFolder))
                {
                    throw new AzPSArgumentException(String.Format(Resources.ConfigFolderDoesNotExist, configFolder), nameof(ConfigFilePath));
                }
            }

            if (KeysDestinationFolder != null)
            {
                if (PrivateKeyFile != null || PublicKeyFile != null)
                    throw new AzPSArgumentException(Resources.KeysDestinationFolderWithKeys, nameof(KeysDestinationFolder));
                KeysDestinationFolder = GetUnresolvedPath(KeysDestinationFolder, nameof(KeysDestinationFolder));
            }

        }

        protected internal void SetResourceType()
        {
            if (ParameterSetName.Equals(IpAddressParameterSet))
            {
                ResourceType = "Microsoft.Compute/virtualMachines";
                return;
            }
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                ResourceIdentifier idParser = new ResourceIdentifier(ResourceId);
                ResourceGroupName = idParser.ResourceGroupName;
                Name = idParser.ResourceName;
                ResourceType = idParser.ResourceType;
            }

            var resourcetypefilter = supportedResourceTypes.Select(type => $"resourceType eq '{type}'").ToArray();
            String filter = $"$filter=name eq '{Name}' and ({String.Join(" or ", resourcetypefilter)})";
            ODataQuery<GenericResourceFilter> query = new ODataQuery<GenericResourceFilter>(filter);

            String[] types;
            try
            {
                IPage<GenericResource> resources = ResourceManagementClient.Resources.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName, query).GetAwaiter().GetResult().Body;
                types = resources.Select(resource => resource.Type).ToArray();
            }
            catch (CloudException exception)
            {
                throw new AzPSCloudException(String.Format(Resources.ListResourcesCloudException, ResourceGroupName, exception.Message));
            }
            catch (ArgumentNullException)
            {
                throw new AzPSApplicationException(String.Format(Resources.ListResourcesArgumentNullException, ResourceGroupName));
            }

            if (ResourceType != null)
            {
                if (!types.Contains(ResourceType, StringComparer.CurrentCultureIgnoreCase))
                {
                    throw new AzPSResourceNotFoundCloudException(String.Format(Resources.ResourceNotFoundTypeProvided,Name, ResourceType, ResourceGroupName));
                }
                return;
            }

            if (types.Count() > 1)
            {
                throw new AzPSArgumentException(String.Format(Resources.MultipleResourcesWithSameName, Name, ResourceGroupName), ResourceType);
            }
            else if (types.Count() < 1)
            {
                throw new AzPSResourceNotFoundCloudException(String.Format(Resources.ResourceNotFoundNoTypeProvided, Name, ResourceGroupName));
            }
            ResourceType = types.ElementAt(0);
        }


        protected internal void UpdateProgressBar(
            ProgressRecord record,
            string statusMessage,
            int percentComplete)
        {
            record.PercentComplete = percentComplete;
            record.StatusDescription = statusMessage;
            WriteProgress(record);
        }

        protected internal EndpointAccessResource GetRelayInformation()
        {
            SetResourceId();
            EndpointAccessResource cred;
                
            try
            {
                cred = EndpointsClient.ListCredentials(ResourceId, "default", 3600);
            }
            catch (PowerShell.Ssh.Helpers.HybridConnectivity.Models.ErrorResponseException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    try
                    {
                        EndpointResource endpoint = new EndpointResource("default", ResourceId);
                        EndpointsClient.CreateOrUpdate(ResourceId, "default", endpoint);
                    }
                    catch (PowerShell.Ssh.Helpers.HybridConnectivity.Models.ErrorResponseException createEndpointException)
                    {
                        if (createEndpointException.Response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            throw new AzPSCloudException(Resources.FailedToCreateDefaultEndpointUnauthorized);
                        }
                        throw new AzPSCloudException(String.Format(Resources.FailedToCreateDefaultEndpoint, createEndpointException.Message));
                    }

                    try
                    {
                        cred = EndpointsClient.ListCredentials(ResourceId, "default", 3600);
                    }
                    catch (Exception listCredException)
                    {
                        throw new AzPSCloudException(String.Format(Resources.FailedToListCredentials, listCredException.Message));
                    }

                }
                else
                {
                    throw new AzPSCloudException(String.Format(Resources.FailedToListCredentials, exception.Message));
                }
            }
            return cred;
        }

        protected internal string ConvertEndpointAccessToBase64String(EndpointAccessResource cred)
        {
            if (cred == null) { return null; }

            string relayString = "{\"relay\": {" +
                $"\"namespaceName\": \"{cred.NamespaceName}\", " +
                $"\"namespaceNameSuffix\": \"{cred.NamespaceNameSuffix}\", " +
                $"\"hybridConnectionName\": \"{cred.HybridConnectionName}\", " +
                $"\"accessKey\": \"{cred.AccessKey}\", " +
                $"\"expiresOn\": {cred.ExpiresOn}" +
                "}}";

            var bytes = Encoding.UTF8.GetBytes(relayString);
            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
        }

        protected internal string GetProxyPath()
        {
            string proxyPath = SearchForInstalledProxyPath();
            
            if (String.IsNullOrEmpty(proxyPath))
            {
                Collection<ChoiceDescription> choices = new Collection<ChoiceDescription> { 
                    new ChoiceDescription("N", "No"),
                    new ChoiceDescription("Y", "Yes")
                };

                int userChoice = this.Host.UI.PromptForChoice(
                    caption: Resources.InstallProxyModuleCaption,
                    message: Resources.InstallProxyModuleMessage,
                    choices: choices,
                    defaultChoice: 0);
                if (userChoice == 1)
                {
                    var installationResults = InvokeCommand.InvokeScript(
                        script: "Install-module Az.Ssh.ArcProxy -Repository PsGallery -Scope CurrentUser -MaximumVersion 1.9.9 -AllowClobber",
                        useNewScope: true,
                        writeToPipeline: PipelineResultTypes.Error,
                        input: null,
                        args: null);
                    
                    proxyPath = SearchForInstalledProxyPath();
                }
                
            }

            if (!String.IsNullOrEmpty(proxyPath)) { return proxyPath; }
            
            throw new AzPSApplicationException(Resources.FailedToFindProxyModule);
        }


        protected internal void GetVmIpAddress()
        {
            string _message = "";
            Ip = this.IpUtils.GetIpAddress(Name, ResourceGroupName, UsePrivateIp, out _message);

            if (_message.StartsWith("Unable to find public IP.") && !UsePrivateIp)
            {
                WriteWarning($"{_message}. To avoid this message, use -UsePrivateIp.");
            }

            if (Ip == null)
            {
                string errorMessage = $"Couldn't determine the IP address of {Name} in the Resource Group {ResourceGroupName}.";
                throw new AzPSResourceNotFoundCloudException(errorMessage);
            }
        }

        protected internal void PrepareAadCredentials(string credentialFolder = null)
        {
            deleteCert = true;
            deleteKeys = CheckOrCreatePublicAndPrivateKeyFile(credentialFolder);
            WriteVerbose($"Created Keys {PublicKeyFile} and {PrivateKeyFile}.");
            CertificateFile = GetAndWriteCertificate(PublicKeyFile);
            WriteVerbose($"Created Certificate {CertificateFile}.");
            LocalUser = GetSSHCertPrincipals(CertificateFile)[0];
        }

        protected internal string GetCertificateExpirationTimes()
        {
            string[] certificateInfo = GetSSHCertInfo(this.CertificateFile);
            foreach (string line in certificateInfo)
            {
                if (line.Contains("Valid:"))
                {
                    var validity = Regex.Split(line.Trim().Replace("Valid: from ", ""), " to ");
                    DateTime endDate = DateTime.Parse(validity[1]);
                    return endDate.ToString();
                }

            }
            return null;
        }

        protected internal string GetClientApplicationPath(string command)
        {

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return command;
            }

            command = $"{command}.exe";
            ApplicationInfo appInfo = InvokeCommand.GetCommand(command, CommandTypes.Application) as ApplicationInfo;

            if (appInfo == null)
            {
                if (command.Equals("mstsc.exe"))
                {
                    throw new AzPSApplicationException(Resources.MstscClientNotFound);
                }
                throw new AzPSApplicationException(Resources.OpenSSHClientNotFound);
            }
            
            return appInfo.Path;
        }


        protected internal void DeleteFile(string fileName, string warningMessage = null)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception e)
                {
                    if (warningMessage != null)
                    {
                        WriteWarning(warningMessage + " Error: " + e.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        protected internal void DeleteDirectory(string dirPath, string warningMessage = null)
        {
            if (Directory.Exists(dirPath))
            {
                try
                {
                    Directory.Delete(dirPath);
                }
                catch (Exception e)
                {
                    if (warningMessage != null)
                    {
                        WriteWarning(warningMessage + " Error: " + e.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        protected internal bool IsArc()
        {
            if (ResourceType.Equals("Microsoft.HybridCompute/machines", StringComparison.CurrentCultureIgnoreCase) ||
                ResourceType.Equals("Microsoft.ConnectedVMwarevSphere/virtualMachines", StringComparison.CurrentCultureIgnoreCase) ||
                ResourceType.Equals("Microsoft.ScVmm/virtualMachines", StringComparison.CurrentCultureIgnoreCase) ||
                ResourceType.Equals("Microsoft.AzureStackHCI/virtualMachines", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Private Methods

        private string SearchForInstalledProxyPath()
        {
            var results = InvokeCommand.InvokeScript(
                script: "Get-module -ListAvailable -Name Az.Ssh.ArcProxy");

            foreach (var result in results)
            {
                if (result?.BaseObject is PSModuleInfo moduleInfo)
                {
                    var proxyPath = GetProxyPathInModuleDirectory(moduleInfo.Path);

                    if (moduleInfo.Version >= new Version("2.0.0"))
                    {
                        WriteWarning(String.Format(Resources.UnsuportedVersionProxyModule, moduleInfo.Path, moduleInfo.Version));
                        continue;
                    }

                    if (!File.Exists(proxyPath))
                    {
                        continue;
                    }

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        // does this check even work?
                        if (!SetExecutePermissionForProxyOnLinux(proxyPath))
                        {
                            WriteWarning($"Unable to add Execute permission to SSH Proxy {proxyPath}. The SSH connection will fail if the current user doesn't have permission to execute the SSH proxy file.");
                        }
                    }

                    return proxyPath;
                }

            }
            return null;
        }

        private bool SetExecutePermissionForProxyOnLinux(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    var script = $"chmod +x {path}";
                    var results = InvokeCommand.InvokeScript(
                        script: script,
                        useNewScope: true,
                        writeToPipeline: PipelineResultTypes.Error,
                        input: null,
                        args: null);
                    Console.Write(results);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        private void SetResourceId()
        {
            if (String.IsNullOrEmpty(ResourceId) && ParameterSetName.Equals(InteractiveParameterSet))
            {
                ResourceIdentifier id = new ResourceIdentifier();
                id.ResourceGroupName = ResourceGroupName;
                id.Subscription = DefaultProfile.DefaultContext.Subscription.Id;
                id.ResourceName = Name;
                id.ResourceType = ResourceType;

                ResourceId = id.ToString();
            }
        }


        /* This method gets the full path of items that already exist. It checks if the file exist and fails if it doesn't*/
        private string GetResolvedPath(string path, string paramName)
        {
            if (WildcardPattern.ContainsWildcardCharacters(path))
            {
                throw new AzPSArgumentException($"Wildcard characters are not allowed in {paramName}.", paramName);
            }
            return SessionState.Path.GetResolvedPSPathFromPSPath(path).First().Path;
        }

        /* Gets the full path of files that might not exist yet.*/
        private string GetUnresolvedPath(string path, string paramName)
        {
            if (WildcardPattern.ContainsWildcardCharacters(path))
            {
                throw new AzPSArgumentException($"Wildcard characters are not allowed in {paramName}.", paramName);
            }
            return SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
        }

        private string GetAndWriteCertificate(string publicKeyFile)
        {
            SshCredential certificate = GetAccessToken(publicKeyFile);        
            string token = certificate.Credential;
            string keyDir = Path.GetDirectoryName(publicKeyFile);
            string certpath = Path.Combine(keyDir, "id_rsa.pub-aadcert.pub");
            string cert_contents = "ssh-rsa-cert-v01@openssh.com " + token;

            WriteVerbose($"AAD issued SSH certificate will be written to {certpath}.");
            File.WriteAllText(certpath, cert_contents);

            if (!File.Exists(certpath) || !cert_contents.Equals(File.ReadAllText(certpath)))
            {
                throw new AzPSIOException($"Failed to write AAD issues config to {certpath}.");
            }

            return certpath;
        }

        private SshCredential GetAccessToken(string publicKeyFile)
        {
            string publicKeyText = File.ReadAllText(publicKeyFile);
            RSAParser parser = new RSAParser(publicKeyText);
            var context = DefaultProfile.DefaultContext;
            RSAParameters parameters = new RSAParameters
            {
                Exponent = Base64UrlHelper.DecodeToBytes(parser.Exponent),
                Modulus = Base64UrlHelper.DecodeToBytes(parser.Modulus)
            };
            ISshCredentialFactory factory = null;
            AzureSession.Instance.TryGetComponent<ISshCredentialFactory>(nameof(ISshCredentialFactory), out factory);
            if(factory == null)
            {
                throw new AzPSApplicationException("Cannot load SshCredentialFactory instance from context.");
            }

            SshCredential token = null;

            try
            {
                token = factory.GetSshCredential(context, parameters);
            }
            catch (KeyNotFoundException exception)
            {
                if (context.Account.Type != AzureAccount.AccountType.User)
                {
                    throw new AzPSApplicationException(String.Format(Resources.FailedToAADUnsupportedAccountType, context.Account.Type));
                }

                throw new AzPSApplicationException($"Failed to generate AAD certificate with exception: {exception.Message}.");
            }

            return token;
        }

        private List<string> GetSSHCertPrincipals(string certFile)
        {
            string[] certInfo = GetSSHCertInfo(certFile);
            List<string> principals = new List<string>();
            bool inPrincipals = false;

            foreach (string line in certInfo)
            {
                if (line.Contains(":"))
                {
                    inPrincipals = false;
                }
                if (line.Contains("Principals: "))
                {
                    inPrincipals = true;
                    continue;
                }
                if (inPrincipals)
                {
                    principals.Add(line.Trim());
                }
            }

            if (!principals.Any())
            {
                throw new AzPSInvalidOperationException("Unable to find Principals in generated AAD Certificate.");
            }
            return principals;
        }

        private string[] GetSSHCertInfo(string certFile)
        {
            string sshKeygenPath = GetClientApplicationPath("ssh-keygen");
            string args = $"-L -f \"{certFile}\"";
            WriteDebug("Runnung ssh-keygen command: " + sshKeygenPath + " " + args);
            Process keygen = new Process();
            keygen.StartInfo.FileName = sshKeygenPath;
            keygen.StartInfo.Arguments = args;
            keygen.StartInfo.UseShellExecute = false;
            keygen.StartInfo.RedirectStandardOutput = true;
            keygen.Start();
            string output = keygen.StandardOutput.ReadToEnd();
            keygen.WaitForExit();

            string[] certInfo = output.Split('\n');

            return certInfo;
        }

        private bool CheckOrCreatePublicAndPrivateKeyFile(string credentialFolder=null)
        {
            bool deleteKeys = false;
            if (PublicKeyFile == null && PrivateKeyFile == null)
            {
                deleteKeys = true;
                if (credentialFolder == null)
                {
                    credentialFolder = CreateTempFolder();
                }
                else
                {
                    //create all directories in the path unless they already exist
                    Directory.CreateDirectory(credentialFolder);
                }

                PublicKeyFile = Path.Combine(credentialFolder, "id_rsa.pub");
                PrivateKeyFile = Path.Combine(credentialFolder, "id_rsa");
                CreateSSHKeyfile(PrivateKeyFile);
            }

            if (PublicKeyFile == null)
            {
                if (PrivateKeyFile != null)
                {
                    PublicKeyFile = PrivateKeyFile + ".pub";
                }
                else
                {
                    throw new AzPSArgumentNullException("Public key file not specified.", "PublicKeyFile");
                }
            }

            if (!File.Exists(PublicKeyFile))
            {
                throw new AzPSFileNotFoundException("Public key file not found", PublicKeyFile);
            }

            // The private key is not required as the user may be using a keypair stored in ssh-agent
            if (PrivateKeyFile != null && !File.Exists(PrivateKeyFile))
            {
                throw new AzPSFileNotFoundException("Private key file not found", PrivateKeyFile);
            }

            return deleteKeys;
        }

        private void CreateSSHKeyfile(string privateKeyFile)
        {
            string args = $"-f \"{privateKeyFile}\" -t rsa -q -N \"\"";
            Process keygen = Process.Start(GetClientApplicationPath("ssh-keygen"), args);
            keygen.WaitForExit();
        }


        private string CreateTempFolder()
        {
            string prefix = "aadsshcert";
            var dirnameBuilder = new StringBuilder();
            Random random = new Random();
            string dirname;
            do
            {
                dirnameBuilder.Clear();
                dirnameBuilder.Append(prefix);
                for (int i = 0; i < 8; i++)
                {
                    char randChar = (char)random.Next('a', 'a' + 26);
                    dirnameBuilder.Append(randChar);
                }
                dirname = Path.Combine(Path.GetTempPath(), dirnameBuilder.ToString());
            } while (Directory.Exists(dirname));

            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), dirnameBuilder.ToString()));

            return dirname;
        }

        private string GetProxyPathInModuleDirectory(string modulePath)
        {
            string os;
            string architecture;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = "windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                os = "linux";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                os = "darwin";
            }
            else
            {
                throw new AzPSApplicationException("Operating System not supported.");
            }
            // Environment.Is64BitOperatingSystem?
            if (Environment.Is64BitProcess)
            {
                architecture = "amd64";
            }
            else
            {
                architecture = "386";
            }

            string parentDirectory = Directory.GetParent(modulePath).FullName;
            string proxyPattern = $"sshProxy_{os}_{architecture}_*";

            Regex regex = new Regex(proxyPattern);
            var matches = Directory.EnumerateFiles(parentDirectory).Where(f => regex.IsMatch(f));

            if (matches.Count() > 1)
            {
                throw new AzPSApplicationException($"There are more than one sshProxy file for {os} OS and {architecture} architecture in the {parentDirectory} folder ({string.Join(",", matches.ToArray())}). The Az.Ssh.ArcProxy module installed your machine was modified. Please re-install the Az.Ssh.ArcProxy PowerShell module that can be found in the PowerShell Gallery (https://aka.ms/PowerShellGallery-Az.Ssh.ArcProxy).");
            }

            if (matches.Count() < 1)
            {
                throw new AzPSApplicationException($"Couldn't find the sshProxy file for {os} OS and {architecture} architecture in the {parentDirectory} folder. The Az.Ssh.ArcProxy module installed your machine was modified. Please re-install the Az.Ssh.ArcProxy PowerShell module that can be found in the PowerShell Gallery (https://aka.ms/PowerShellGallery-Az.Ssh.ArcProxy).");
            }

            return matches.First().ToString();
        }
#endregion

    }

}
