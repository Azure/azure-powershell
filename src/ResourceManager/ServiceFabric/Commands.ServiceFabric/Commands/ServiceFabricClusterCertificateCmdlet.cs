﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCertificateCmdlet : ServiceFabricClusterCmdlet
    {
        protected const string ExistingKeyVaultSet = "ByExistingKeyVault";
        protected const string ByNewPfxAndVaultName = "ByNewPfxAndVaultName";
        protected const string ByExistingPfxAndVaultName = "ByExistingPfxAndVaultName";      
        protected const string ByNewPfxAndVaultId = "ByNewPfxAndVaultId";
        protected const string ByExistingPfxSetAndVaultId = "ByExistingPfxSetAndVaultId";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault name")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault resource group name")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultResouceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "Azure key vault resource id")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultResouceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "Azure key vault secret name, if not specified, it will use the new or existing certificate name")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "Azure key vault secret name, if not specified, it will use the new or existing certificate name")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "Azure key vault secret name, if not specified, it will use the new or existing certificate name")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "Azure key vault secret name, if not specified, it will use the new or existing certificate name")]
        [ValidateNotNullOrEmpty]
        public string SecretName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExistingKeyVaultSet,
                   HelpMessage = "The existing Azure key vault secret uri")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }  

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "The existing Pfx file path")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The existing Pfx file path")]
        [ValidateNotNullOrEmpty]
        [Alias("Source")]
        public string PfxSourceFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The destination path of the new Pfx file to be created" )]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The destination path of the new Pfx file to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Destination")]
        public string PfxDestinationFile { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxSetAndVaultId,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByExistingPfxAndVaultName,
                   HelpMessage = "The password of the pfx file")]
        [ValidateNotNullOrEmpty]
        [Alias("Password")]
        public SecureString CertificatPassword { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultId,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ByNewPfxAndVaultName,
                   HelpMessage = "The Dns name of the certificate to be created")]
        [ValidateNotNullOrEmpty]
        [Alias("Dns")]
        public string CertificateDnsName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExistingKeyVaultSet,
                   HelpMessage = "The thumprint for the Azure key vault secret")]
        [ValidateNotNullOrEmpty]
        [Alias("Thumprint")]
        public string CertificateThumprint { get; set; }

        public Lazy<IResourceManagementClient> resourceManagerClient;

        public IResourceManagementClient ResourceManagerClient
        {
            get { return resourceManagerClient.Value; }
        }

        public virtual string KeyVaultResouceGroupLocation
        {
            get
            {
                return ResourceManagerClient.ResourceGroups.Get(this.ResourceGroupName).Location;
            }
        }

        public ServiceFabricClusterCertificateCmdlet()
        {
            resourceManagerClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultProfile.Context,
                AzureEnvironment.Endpoint.ResourceManager));                       
        }

        private KeyValuePair<string, SecureString> CreateSelfSignedCertificate()
        {
            var certOutPutDirectory = Path.GetDirectoryName(this.PfxDestinationFile);
            if (!Directory.Exists(certOutPutDirectory))
            {
                throw new PSArgumentException(string.Format("Invalid directory {0}", certOutPutDirectory));
            }

            var fileName = Path.GetFileName(this.PfxDestinationFile);
            var newCertFilePath = this.PfxDestinationFile;
            if (fileName != null)
            {
                if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    throw new PSArgumentException(string.Format("File name contains invalid chars {0}", fileName));
                }
            }
            else
            {
                throw new PSArgumentException(this.PfxDestinationFile);
            }

            using (var ps = System.Management.Automation.PowerShell.Create())
            {
                ps.Runspace = RunspaceFactory.CreateRunspace();
                ps.Runspace.Open();
                var pipeline = ps.Runspace.CreatePipeline();

                var newSelfSignedCmd = new Command("New-SelfSignedCertificate");
                newSelfSignedCmd.Parameters.Add("CertStoreLocation", "Cert:\\CurrentUser\\My");
                newSelfSignedCmd.Parameters.Add("DnsName", this.CertificateDnsName);
                newSelfSignedCmd.Parameters.Add("Provider", "Microsoft Enhanced Cryptographic Provider v1.0");
                pipeline.Commands.Add(newSelfSignedCmd);

                var exportCertCmd = new Command("Export-PfxCertificate");
                exportCertCmd.Parameters.Add("FilePath", newCertFilePath);
                exportCertCmd.Parameters.Add("Password", this.CertificatPassword);
                pipeline.Commands.Add(exportCertCmd);

                pipeline.Invoke();

                var error = pipeline.Error;

                if (error.Count > 0)
                {
                    var errors = error.ReadToEnd();
                    foreach (var err in errors)
                    {
                        WriteError((ErrorRecord)err);
                    }

                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.FailedToCreateSelfSignedCertificate);
                }

            }

            return new KeyValuePair<string, SecureString>(newCertFilePath, this.CertificatPassword);
        }

        internal CertificateInformation GetOrCreateCertificateInformation()
        {
            if (ParameterSetName != ExistingKeyVaultSet)
            {
                if (!string.IsNullOrWhiteSpace(this.KeyVaultResouceId))
                {
                    ExtractVaultNameAndGroupNameFromId();
                }

                var resourceGroup = SafeGetResource(
                    () => ResourceManagerClient.ResourceGroups.Get(
                        this.KeyVaultResouceGroupName));

                if (resourceGroup == null)
                {
                    ResourceManagerClient.ResourceGroups.CreateOrUpdate(
                        this.KeyVaultResouceGroupName,
                        new ResourceGroup()
                        {
                            Location = this.KeyVaultResouceGroupLocation
                        });
                }               
            }

            switch (ParameterSetName)
            {
                case ByNewPfxAndVaultName:
                case ByNewPfxAndVaultId:
                    {
                        var pfxAndPassword = CreateSelfSignedCertificate();
                        var pfxPath = pfxAndPassword.Key;
                        var password = pfxAndPassword.Value;
                        var thumbprint = new X509Certificate2(pfxPath, password).Thumbprint;

                        Vault vault = null;
                        SecretBundle secretBundle = null;
                        GetKeyVaultReady(out vault, out secretBundle, pfxPath);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = secretBundle.SecretIdentifier.Identifier,
                            Thumbprint = thumbprint
                        };
                    }

                case ByExistingPfxAndVaultName:
                case ByExistingPfxSetAndVaultId:
                    {
                        Vault vault = null;
                        SecretBundle secretBundle = null;
                        GetKeyVaultReady(out vault, out secretBundle, this.PfxSourceFile);
                        var thumbprint = new X509Certificate2(this.PfxSourceFile, this.CertificatPassword).Thumbprint;
                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = secretBundle.SecretIdentifier.Identifier,
                            Thumbprint = thumbprint
                        };
                    }
                case ExistingKeyVaultSet:
                    {
                        var vault = GetKeyVault(this.SecretIdentifier);

                        return new CertificateInformation()
                        {
                            KeyVault = vault,
                            SecretUrl = this.SecretIdentifier,
                            Thumbprint = this.CertificateThumprint
                        };
                    }
            }

            return null;
        }

        void ExtractVaultNameAndGroupNameFromId()
        {
            if (string.IsNullOrWhiteSpace(this.KeyVaultResouceId))
            {
                return;
            }

            var keyVaultId = this.KeyVaultResouceId;
            keyVaultId = keyVaultId.Trim('/');
            var tokens = keyVaultId.Split('/');

            if (tokens.Length != 8)
            {
                throw new PSArgumentException(keyVaultId);
            }

            if (!string.Equals(tokens[0], "subscriptions", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("subscriptions");
            }

            if (!string.Equals(tokens[2], "resourcegroups", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("resourcegroups");
            }

            if (!string.Equals(tokens[4], "providers", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("providers");
            }

            var resourceType = string.Format("{0}/{1}", tokens[5], tokens[6]);
            if (!string.Equals(resourceType, Common.Constants.KeyVaultType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException("resourceType");
            }

            this.KeyVaultName = tokens[7];
            this.KeyVaultResouceGroupName = tokens[3];
        }

        protected void GetKeyVaultReady(
            out Vault vault,
            out SecretBundle secretBundle,
            string pfxPath)
        {
           
            if (string.IsNullOrEmpty(this.SecretName))
            {
                this.SecretName = string.IsNullOrEmpty(this.PfxDestinationFile) ?
                    Path.GetFileNameWithoutExtension(this.PfxSourceFile) :
                    Path.GetFileNameWithoutExtension(this.PfxDestinationFile);
            }

            vault = GetKeyVault(this.KeyVaultResouceGroupName, this.KeyVaultName);

            if (vault == null)
            {
                vault = CreateKeyVault(
                    this.KeyVaultName,
                    this.KeyVaultResouceGroupLocation,
                    this.KeyVaultResouceGroupName);
            }

            secretBundle = SetAzureKeyVaultSecret(
                  this.KeyVaultName,
                  this.SecretName,
                  pfxPath,
                  this.CertificatPassword);
        }
    }
}