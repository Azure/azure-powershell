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
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute.Models;


namespace Microsoft.Azure.Commands.Ssh
{

    public abstract class SshBaseCmdlet : AzureRMCmdlet
    {

        #region Constants
        // Version and checksum values of the proxy are hardcoded for now only for the initial preview.
        // Moving forward we will ship the proxy as part of the module, and this will be deprecated.
        private const string clientProxyStorageUrl = "https://sshproxysa.blob.core.windows.net";
        private const string clientProxyRelease = "release01-11-21";
        private const string clientProxyVersion = "1.3.017634";

        private const string sshproxy_windows_amd64_sha256_hash = "E345920FBBD1073F36DF78C619F646FD22CEFFE2B47391558969856C4FEC1F2F";
        private const string sshproxy_windows_386_sha256_hash = "24AFD216D75D165B526F9B5AC8DD775E128F8963DA4D7FAE7B009139A784C5E2";
        private const string sshproxy_linux_amd64_sha256_hash = "09AF191870C0E79AC9536D8655C3116DB70F131B85DE4BAF0BAE0346C33EE3DD";
        private const string sshproxy_linux_386_sha256_hash = "E63BE773426109C35891F88B1A460FFDF722731BEAD727954D7724BFCE386CAD";
        private const string sshproxy_darwin_amd64_sha256_hash = "7A020E92C2E515F1FCF952CDC32931DA38069C3153CFCFD078E054966295E48A";

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
            var context = DefaultProfile.DefaultContext;
            if (LocalUser == null && context.Account.Type == AzureAccount.AccountType.ServicePrincipal)
            {
                throw new AzPSArgumentException(Resources.AADLoginForServicePrincipal, nameof(LocalUser));
            }

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
                        throw new AzPSCloudException(String.Format(Resources.FailedToCreateDefaultEndpoint, createEndpointException));
                    }

                    try
                    {
                        cred = EndpointsClient.ListCredentials(ResourceId, "default", 3600);
                    }
                    catch (Exception listCredException)
                    {
                        throw new AzPSCloudException(String.Format(Resources.FailedToListCredentials, listCredException));
                    }

                }
                else
                {
                    throw new AzPSCloudException(String.Format(Resources.FailedToListCredentials, exception));
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

        protected internal string GetInstalledProxyModulePath()
        {
            var results = InvokeCommand.InvokeScript(
                script: "(Get-module -ListAvailable -Name Az.Ssh.ArcProxy).Path");

            foreach (var result in results)
            {
                if (result?.BaseObject is string tempPath)
                {
                    string proxyPath = GetProxyPath(tempPath);

                    if (!File.Exists(proxyPath) || !ValidateSshProxy(proxyPath))
                    {
                        continue;
                    }

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        if (!SetExecutePermissionForProxyOnLinux(proxyPath))
                        {
                            WriteWarning($"Unable to add Execute permission to SSH Proxy {proxyPath}. The SSH connection will fail if the current user doesn't have permission to execute the SSH proxy file.");
                        }
                    }

                    return proxyPath;
                }
            }


            System.Collections.ObjectModel.Collection<ChoiceDescription> choices = new System.Collections.ObjectModel.Collection<ChoiceDescription> { new ChoiceDescription("N"), new ChoiceDescription("Y") };
            int userChoice = this.Host.UI.PromptForChoice(
                caption:$"You currently don't have the required Az.Ssh.ArcProxy module installed in this machine. Would you like us to attempt to install this module for the current user?",
                message: "You must have the Az.Ssh.Proxy PowerShell module installed in the client machine in order to connect to Azure Arc resources. You can find the module in the PowerShell Gallery <Link>.",
                choices: choices,
                defaultChoice: 0);
            if (userChoice == 1)
            {
                var installationResults = InvokeCommand.InvokeScript(
                    script: "Install-module blabl -Repository PsGallery -Scope CurrentUser");
            }

            throw new AzPSApplicationException("Failed to find the module Az.Ssh.ArcProxy installed in this machine. You must have the Az.Ssh.Proxy PowerShell module installed in the client machine in order to connect to Azure Arc resources. You can find the module in the PowerShell Gallery <Link>.");
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

        protected internal bool SetExecutePermissionForProxyOnLinux(string path)
        {
            string cmd = $"chmod +x {path}";
            try
            {
                using (Process p = Process.Start("/bin/bash", $"-c \"{cmd}\""))
                {
                    p.WaitForExit();
                    return p.ExitCode == 0;
                }

            }
            catch
            {
                return false;
            }
        }

        private void SetResourceId()
        {
            if (ResourceId == null)
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
            var token = factory.GetSshCredential(context, parameters);
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

        private string GetProxyPath(string modulePath)
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

            string proxyName = $"sshProxy_{os}_{architecture}_{clientProxyVersion}";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                proxyName += ".exe";
            }

            string parentDirectory = Directory.GetParent(modulePath).FullName;

            return Path.Combine(parentDirectory, proxyName);
        }

        private bool ValidateSshProxy(string path)
        
        {
            string hashString;
            using (var sha256 = SHA256.Create())
            {
                using (var filestream = File.OpenRead(path))
                {
                    var hash = sha256.ComputeHash(filestream);
                    hashString = BitConverter.ToString(hash).Replace("-", "");
                }
            }

            string filename = Path.GetFileName(path);
            bool isValid = false;

            switch (filename)
            {
                case "sshProxy_windows_386_1_3_017634.exe":
                    isValid = hashString.Equals(sshproxy_windows_386_sha256_hash);
                    break;
                case "sshProxy_windows_amd64_1_3_017634.exe":
                    isValid = hashString.Equals(sshproxy_windows_amd64_sha256_hash);
                    break;
                case "sshProxy_linux_386_1_3_017634":
                    isValid = hashString.Equals(sshproxy_linux_386_sha256_hash);
                    break;
                case "sshProxy_linux_amd64_1_3_017634":
                    isValid = hashString.Equals(sshproxy_linux_amd64_sha256_hash);
                    break;
                case "sshProxy_darwin_amd64_1_3_017634":
                    isValid = hashString.Equals(sshproxy_darwin_amd64_sha256_hash);
                    break;
            }

            return isValid;
        }
#endregion

    }

}
