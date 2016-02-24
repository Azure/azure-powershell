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
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.KeyVault;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class VaultManagementClient
    {
        public VaultManagementClient(AzureContext context)
        {
            KeyVaultManagementClient = AzureSession.ClientFactory.CreateClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public VaultManagementClient()
        { }

        private IKeyVaultManagementClient KeyVaultManagementClient
        {
            get;
            set;
        }
       
        /// <summary>
        /// Create a new vault
        /// </summary>
        /// <param name="parameters">vault creation parameters</param>
        /// <param name="adClient">the active directory client</param>
        /// <returns></returns>
        public PSVault CreateNewVault(VaultCreationParameters parameters, ActiveDirectoryClient adClient = null)
        {            
            if (parameters == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(parameters.VaultName))
                throw new ArgumentNullException("parameters.VaultName");
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(parameters.Location))
                throw new ArgumentNullException("parameters.Location");
            if (string.IsNullOrWhiteSpace(parameters.SkuName))
                throw new ArgumentNullException("parameters.SkuName");
            if (string.IsNullOrWhiteSpace(parameters.SkuFamilyName))
                throw new ArgumentNullException("parameters.SkuFamilyName");
            if (parameters.TenantId == null || parameters.TenantId == Guid.Empty)
                throw new ArgumentException("parameters.TenantId");
            if (parameters.ObjectId == null || parameters.ObjectId == Guid.Empty)
                throw new ArgumentException("parameters.ObjectId");
            
            var response = this.KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: parameters.ResourceGroupName,
                vaultName: parameters.VaultName,

                parameters: new VaultCreateOrUpdateParameters()
                {
                    Location = parameters.Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                    Properties = new VaultProperties
                    {
                        Sku = new Sku
                        {
                            Family = parameters.SkuFamilyName,
                            Name = parameters.SkuName
                        },
                        EnabledForDeployment = parameters.EnabledForDeployment,
                        EnabledForTemplateDeployment = parameters.EnabledForTemplateDeployment,
                        EnabledForDiskEncryption = parameters.EnabledForDiskEncryption,
                        TenantId = parameters.TenantId,
                        VaultUri = "",
                        AccessPolicies = new []
                        {
                            new AccessPolicyEntry
                            {
                                TenantId = parameters.TenantId,
                                ObjectId = parameters.ObjectId,
                                PermissionsToKeys = parameters.PermissionsToKeys,                                    
                                PermissionsToSecrets = parameters.PermissionsToSecrets
                            }
                        }
                    }
                }
                );

            return new PSVault(response.Vault, adClient);
        }

        /// <summary>
        /// Get an existing vault. Returns null if vault is not found.
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="adClient">the active directory client</param>
        /// <returns>the retrieved vault</returns>
        public PSVault GetVault(string vaultName, string resourceGroupName, ActiveDirectoryClient adClient = null)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                var response = this.KeyVaultManagementClient.Vaults.Get(resourceGroupName, vaultName);

                return new PSVault(response.Vault, adClient);
            }
            catch(CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
        }

        /// <summary>
        /// Update an existing vault. Only EnabledForDeployment and AccessPolicies can be updated currently.
        /// </summary>
        /// <param name="existingVault">the existing vault</param>
        /// <param name="updatedPolicies">the update access policies</param>
        /// <param name="updatedEnabledForDeployment">enabled for deployment</param>
        /// <param name="updatedEnabledForTemplateDeployment">enabled for template deployment</param>
        /// <param name="updatedEnabledForDiskEncryption">enabled for disk encryption</param>
        /// <param name="adClient">the active directory client</param>
        /// <returns>the updated vault</returns>
        public PSVault UpdateVault(PSVault existingVault, PSVaultAccessPolicy[] updatedPolicies, bool updatedEnabledForDeployment,
            bool? updatedEnabledForTemplateDeployment, bool? updatedEnabledForDiskEncryption, ActiveDirectoryClient adClient = null)
        {
            if (existingVault == null)
                throw new ArgumentNullException("existingVault");
            if (existingVault.OriginalVault == null)
                throw new ArgumentNullException("existingVault.OriginalVault");

            //Update the vault properties in the object received from server
            //Only access policies and EnabledForDeployment can be changed
            VaultProperties properties = existingVault.OriginalVault.Properties;
            properties.EnabledForDeployment = updatedEnabledForDeployment;
            properties.EnabledForTemplateDeployment = updatedEnabledForTemplateDeployment;
            properties.EnabledForDiskEncryption = updatedEnabledForDiskEncryption;
            properties.AccessPolicies = (updatedPolicies == null) ? 
                new List<AccessPolicyEntry>() :
                updatedPolicies.Select(a => new AccessPolicyEntry()
                        {
                            TenantId = a.TenantId,
                            ObjectId = a.ObjectId,
                            ApplicationId = a.ApplicationId,
                            PermissionsToKeys = a.PermissionsToKeys.ToArray(),
                            PermissionsToSecrets = a.PermissionsToSecrets.ToArray()
                        }).ToList();

            var response = this.KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: existingVault.ResourceGroupName,
                vaultName: existingVault.VaultName,                
                parameters: new VaultCreateOrUpdateParameters()
                {                                       
                    Location = existingVault.Location,
                    Properties = properties
                }
                );
            return new PSVault(response.Vault, adClient);
        }

        /// <summary>
        /// Delete an existing vault. Throws if vault is not found.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        public void DeletVault(string vaultName, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                this.KeyVaultManagementClient.Vaults.Delete(resourceGroupName, vaultName);                
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NoContent)
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, vaultName, resourceGroupName));
                throw;
            }
        }
       
        public readonly string VaultsResourceType = "Microsoft.KeyVault/vaults";
    }
}
