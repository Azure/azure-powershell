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
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.KeyVault;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using System.ComponentModel;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public enum ResourceTypeName
    {
        Vault = 0,
        Hsm = 1
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1
    }

    public enum NetworkRuleAction
    {
        Allow,
        Deny
    }

    public class VaultManagementClient
    {
        public readonly string VaultsResourceType = "Microsoft.KeyVault/vaults";
        public readonly string ManagedHsmResourceType = "Microsoft.KeyVault/managedHSMs";
        
        public VaultManagementClient(IAzureContext context)
        {
            KeyVaultManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
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

        #region Vault-related METHODS
        /// <summary>
        /// Create a new vault
        /// </summary>
        /// <param name="parameters">vault creation parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <param name="networkRuleSet">the network rule set of the vault</param>
        /// <returns></returns>
        public PSKeyVault CreateNewVault(VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null, PSKeyVaultNetworkRuleSet networkRuleSet = null)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(parameters.Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(parameters.Location))
                throw new ArgumentNullException("parameters.Location");

            var properties = new VaultProperties();

            if (parameters.CreateMode != CreateMode.Recover)
            {
                if (string.IsNullOrWhiteSpace(parameters.SkuFamilyName))
                    throw new ArgumentNullException("parameters.SkuFamilyName");
                if (parameters.TenantId == Guid.Empty)
                    throw new ArgumentException("parameters.TenantId");
                if (!string.IsNullOrWhiteSpace(parameters.SkuName))
                {
                    if (Enum.TryParse(parameters.SkuName, true, out SkuName skuName))
                    {
                        properties.Sku = new Sku(skuName);
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException("parameters.SkuName");
                    }
                }
                properties.EnabledForDeployment = parameters.EnabledForDeployment;
                properties.EnabledForTemplateDeployment = parameters.EnabledForTemplateDeployment;
                properties.EnabledForDiskEncryption = parameters.EnabledForDiskEncryption;
                properties.EnableSoftDelete = parameters.EnableSoftDelete;
                properties.EnablePurgeProtection = parameters.EnablePurgeProtection;
                properties.EnableRbacAuthorization = parameters.EnableRbacAuthorization;
                properties.SoftDeleteRetentionInDays = parameters.SoftDeleteRetentionInDays;
                properties.TenantId = parameters.TenantId;
                properties.VaultUri = "";
                properties.AccessPolicies = (parameters.AccessPolicy != null) ? new[] { parameters.AccessPolicy } : new AccessPolicyEntry[] { };

                properties.NetworkAcls = parameters.NetworkAcls;
                properties.PublicNetworkAccess = parameters.PublicNetworkAccess;
                if (networkRuleSet != null)
                {
                    UpdateVaultNetworkRuleSetProperties(properties, networkRuleSet);
                }
            }
            else
            {
                properties.CreateMode = CreateMode.Recover;
            }

            var response = KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: parameters.ResourceGroupName,
                vaultName: parameters.Name,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = parameters.Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                    Properties = properties
                });

            return new PSKeyVault(response, graphClient);
        }

        /// <summary>
        /// Get an existing vault. Returns null if vault is not found.
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved vault</returns>
        public PSKeyVault GetVault(string vaultName, string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                var response = KeyVaultManagementClient.Vaults.Get(resourceGroupName, vaultName);

                return new PSKeyVault(response, graphClient);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Update an existing vault. Only EnablePurgeProtection, EnableRbacAuthorization and Tags can be updated currently.
        /// </summary>
        /// <param name="existingVault">the existing vault</param>
        /// <param name="updatedParamater">updated paramater</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated vault</returns>
        public PSKeyVault UpdateVault(
            PSKeyVault existingVault,
            VaultCreationOrUpdateParameters updatedParamater,
            IMicrosoftGraphClient graphClient = null)
        {
            if (existingVault == null)
                throw new ArgumentNullException("existingVault");
            if (existingVault.OriginalVault == null)
                throw new ArgumentNullException("existingVault.OriginalVault");

            //Update the vault properties in the object received from server
            var properties = existingVault.OriginalVault.Properties;

            if (!(properties.EnablePurgeProtection.HasValue && properties.EnablePurgeProtection.Value)
                && updatedParamater.EnablePurgeProtection.HasValue
                && updatedParamater.EnablePurgeProtection.Value)
                properties.EnablePurgeProtection = updatedParamater.EnablePurgeProtection;

            properties.EnableRbacAuthorization = updatedParamater.EnableRbacAuthorization;
            properties.PublicNetworkAccess = string.IsNullOrEmpty(updatedParamater.PublicNetworkAccess)? 
                existingVault.PublicNetworkAccess : updatedParamater.PublicNetworkAccess;

            var response = KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: existingVault.ResourceGroupName,
                vaultName: existingVault.VaultName,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = existingVault.Location,
                    Properties = properties,
                    Tags = TagsConversionHelper.CreateTagDictionary(updatedParamater.Tags, validate: true)
                }
                );
            return new PSKeyVault(response, graphClient);
        }

        /// <summary>
        /// Update an existing vault. Only EnabledForDeployment and AccessPolicies can be updated currently.
        /// </summary>
        /// <param name="existingVault">the existing vault</param>
        /// <param name="updatedPolicies">the update access policies</param>
        /// <param name="updatedEnabledForDeployment">enabled for deployment</param>
        /// <param name="updatedEnabledForTemplateDeployment">enabled for template deployment</param>
        /// <param name="updatedEnabledForDiskEncryption">enabled for disk encryption</param>
        /// <param name="updatedSoftDeleteSwitch">enabled for soft delete</param>
        /// <param name="updatedPurgeProtectionSwitch">enabled for purge protection</param>
        /// <param name="updatedRbacAuthorization">enabled for rbac authorization</param>
        /// <param name="softDeleteRetentionInDays">soft delete retention period (days)</param>
        /// <param name="updatedNetworkAcls">updated network rule set</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated vault</returns>
        public PSKeyVault UpdateVault(
            PSKeyVault existingVault,
            PSKeyVaultAccessPolicy[] updatedPolicies,
            bool? updatedEnabledForDeployment,
            bool? updatedEnabledForTemplateDeployment,
            bool? updatedEnabledForDiskEncryption,
            bool? updatedSoftDeleteSwitch,
            bool? updatedPurgeProtectionSwitch,
            bool? updatedRbacAuthorization,
            int? softDeleteRetentionInDays,
            PSKeyVaultNetworkRuleSet updatedNetworkAcls,
            IMicrosoftGraphClient graphClient = null)
        {
            if (existingVault == null)
                throw new ArgumentNullException("existingVault");
            if (existingVault.OriginalVault == null)
                throw new ArgumentNullException("existingVault.OriginalVault");

            //Update the vault properties in the object received from server
            //Only access policies and EnabledForDeployment can be changed
            var properties = existingVault.OriginalVault.Properties;
            properties.EnabledForDeployment = updatedEnabledForDeployment;
            properties.EnabledForTemplateDeployment = updatedEnabledForTemplateDeployment;
            properties.EnabledForDiskEncryption = updatedEnabledForDiskEncryption;
            properties.SoftDeleteRetentionInDays = softDeleteRetentionInDays;

            // soft delete flags can only be applied if they enable their respective behaviors
            // and if different from the current corresponding properties on the vault.
            if (!(properties.EnableSoftDelete.HasValue && properties.EnableSoftDelete.Value)
                && updatedSoftDeleteSwitch.HasValue
                && updatedSoftDeleteSwitch.Value)
                properties.EnableSoftDelete = updatedSoftDeleteSwitch;

            if (!(properties.EnablePurgeProtection.HasValue && properties.EnablePurgeProtection.Value)
                && updatedPurgeProtectionSwitch.HasValue
                && updatedPurgeProtectionSwitch.Value)
                properties.EnablePurgeProtection = updatedPurgeProtectionSwitch;

            // Update EnableRbacAuthorization when specified, otherwise stay current value
            properties.EnableRbacAuthorization = updatedRbacAuthorization;

            properties.AccessPolicies = (updatedPolicies == null) ?
                new List<AccessPolicyEntry>() :
                updatedPolicies.Select(a => new AccessPolicyEntry
                {
                    TenantId = a.TenantId,
                    ObjectId = a.ObjectId,
                    ApplicationId = a.ApplicationId,
                    Permissions = new Permissions
                    {
                        Keys = a.PermissionsToKeys.ToArray(),
                        Secrets = a.PermissionsToSecrets.ToArray(),
                        Certificates = a.PermissionsToCertificates.ToArray(),
                        Storage = a.PermissionsToStorage.ToArray(),
                    }
                }).ToList();

            UpdateVaultNetworkRuleSetProperties(properties, updatedNetworkAcls);

            var response = KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: existingVault.ResourceGroupName,
                vaultName: existingVault.VaultName,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = existingVault.Location,
                    Properties = properties,
                    Tags = TagsConversionHelper.CreateTagDictionary(existingVault.Tags, validate: true)
                }
                );
            return new PSKeyVault(response, graphClient);
        }

        /// <summary>
        /// Delete an existing vault. Throws if vault is not found.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        public void DeleteVault(string vaultName, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                KeyVaultManagementClient.Vaults.Delete(resourceGroupName, vaultName);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NoContent || ce.Response.StatusCode == HttpStatusCode.NotFound)
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, vaultName, resourceGroupName));
                throw;
            }
        }

        /// <summary>
        /// Purge a deleted vault. Throws if vault is not found.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="location"></param>
        public void PurgeVault(string vaultName, string location)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                KeyVaultManagementClient.Vaults.PurgeDeleted(vaultName, location);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NoContent || ce.Response.StatusCode == HttpStatusCode.NotFound)
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.DeletedVaultNotFound, vaultName, location));
                throw;
            }
        }

        /// <summary>
        /// Gets a deleted vault.
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="location">resource group name</param>
        /// <returns>the retrieved deleted vault. Null if vault is not found.</returns>
        public PSDeletedKeyVault GetDeletedVault(string vaultName, string location)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                var response = KeyVaultManagementClient.Vaults.GetDeleted(vaultName, location);

                return new PSDeletedKeyVault(response);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Lists deleted vault in a subscription.
        /// </summary>
        /// <returns>the retrieved deleted vault</returns>
        public List<PSDeletedKeyVault> ListDeletedVaults()
        {
            var deletedVaults = new List<PSDeletedKeyVault>();

            var response = KeyVaultManagementClient.Vaults.ListDeleted();

            foreach (var deletedVault in response)
            {
                deletedVaults.Add(new PSDeletedKeyVault(deletedVault));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.Vaults.ListDeletedNext(response.NextPageLink);

                foreach (var deletedVault in response)
                {
                    deletedVaults.Add(new PSDeletedKeyVault(deletedVault));
                }
            }

            return deletedVaults;
        }

        #endregion

        #region Managedhsm-related METHOD

        /// <summary>
        /// Create a Managed HSM pool
        /// </summary>
        /// <param name="parameters">vault creation parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns></returns>
        public PSManagedHsm CreateNewManagedHsm(VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(parameters.Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(parameters.Location))
                throw new ArgumentNullException("parameters.Location");
            if (parameters.Administrator.Length == 0)
                throw new ArgumentNullException("parameters.Administrator");

            var properties = new ManagedHsmProperties();
            var managedHsmSku = new ManagedHsmSku();

            if (parameters.CreateMode != CreateMode.Recover)
            {
                if (string.IsNullOrWhiteSpace(parameters.SkuFamilyName))
                    throw new ArgumentNullException("parameters.SkuFamilyName");
                if (parameters.TenantId == Guid.Empty)
                    throw new ArgumentException("parameters.TenantId");
                if (!string.IsNullOrWhiteSpace(parameters.SkuName))
                {
                    if (Enum.TryParse(parameters.SkuName, true, out ManagedHsmSkuName skuName))
                    {
                        managedHsmSku.Name = skuName;
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException("parameters.SkuName");
                    }
                }
                properties.TenantId = parameters.TenantId;
                properties.InitialAdminObjectIds = parameters.Administrator;
                properties.EnableSoftDelete = parameters.EnableSoftDelete;
                properties.SoftDeleteRetentionInDays = parameters.SoftDeleteRetentionInDays;
                properties.EnablePurgeProtection = parameters.EnablePurgeProtection;
                properties.NetworkAcls = parameters.MhsmNetworkAcls;
                properties.PublicNetworkAccess = parameters.PublicNetworkAccess;
                if (PublicNetworkAccess.Disabled.ToString().Equals(parameters.PublicNetworkAccess))
                {
                    properties.NetworkAcls.DefaultAction = NetworkRuleAction.Deny.ToString();
                }

            }
            else
            {
                properties.CreateMode = CreateMode.Recover;
            }

            var response = KeyVaultManagementClient.ManagedHsms.CreateOrUpdate(
                resourceGroupName: parameters.ResourceGroupName,
                name: parameters.Name,
                parameters: new ManagedHsm
                {
                    Location = parameters.Location,
                    Sku = managedHsmSku,
                    Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                    Properties = properties
                });

            return new PSManagedHsm(response, graphClient);
        }

        /// <summary>
        /// Get an existing managed HSM. Returns null if managed HSM is not found.
        /// </summary>
        /// <param name="managedHsmName">managed HSM name</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved Managed HSM</returns>
        public PSManagedHsm GetManagedHsm(string managedHsmName, string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                var response = KeyVaultManagementClient.ManagedHsms.Get(resourceGroupName, managedHsmName);

                return new PSManagedHsm(response, graphClient);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                return null;
            }
        }

        public PSDeletedManagedHsm GetDeletedManagedHsm(string managedHsmName, string location)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException("HsmName");
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException("Location");

            try
            {
                var response = KeyVaultManagementClient.ManagedHsms.GetDeleted(managedHsmName, location);

                return new PSDeletedManagedHsm(response);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                return null;
            }
        }


        /// <summary>
        /// List all existing Managed HSMs.
        /// </summary>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved Managed HSM</returns>
        public List<PSManagedHsm> ListManagedHsms(string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            return resourceGroupName == null ? ListManagedHsmsBySubscription(graphClient) :
                ListManagedHsmsByResourceGroup(resourceGroupName, graphClient);
        }

        private List<PSManagedHsm> ListManagedHsmsByResourceGroup(string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            List<PSManagedHsm> managedHsms = new List<PSManagedHsm>();
            IPage<ManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            foreach (var managedHsm in response)
            {
                managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListByResourceGroupNextAsync(response.NextPageLink).GetAwaiter().GetResult();

                foreach (var managedHsm in response)
                {
                    managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
                }
            }

            return managedHsms;
        }

        private List<PSManagedHsm> ListManagedHsmsBySubscription(IMicrosoftGraphClient graphClient = null)
        {
            List<PSManagedHsm> managedHsms = new List<PSManagedHsm>();
            IPage<ManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListBySubscriptionAsync().GetAwaiter().GetResult();

            foreach (var managedHsm in response)
            {
                managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListBySubscriptionNextAsync(response.NextPageLink).GetAwaiter().GetResult();

                foreach (var managedHsm in response)
                {
                    managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
                }
            }

            return managedHsms;
        }

        public List<PSDeletedManagedHsm> ListDeletedManagedHsms()
        {
            List<PSDeletedManagedHsm> deletedManagedHsms = new List<PSDeletedManagedHsm>();
            IPage<DeletedManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListDeleted();

            foreach (var deletedManagedHsm in response)
            {
                deletedManagedHsms.Add(new PSDeletedManagedHsm(deletedManagedHsm));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListDeletedNext(response.NextPageLink);

                foreach (var deletedManagedHsm in response)
                {
                    deletedManagedHsms.Add(new PSDeletedManagedHsm(deletedManagedHsm));
                }
            }

            return deletedManagedHsms;
        }
       
        /// <summary>
        /// Update an existing Managed HSM.
        /// </summary>
        /// <param name="existingManagedHsm">existing Managed HSM</param>
        /// <param name="parameters">HSM update parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated Managed HSM</returns>
        public PSManagedHsm UpdateManagedHsm(PSManagedHsm existingManagedHsm, VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null)
        {
            if (existingManagedHsm == null)
                throw new ArgumentNullException("existingManagedHsm");
            if (existingManagedHsm.OriginalManagedHsm == null)
                throw new ArgumentNullException("existingManagedHsm.OriginalManagedHsm");

            //Update the vault properties in the object received from server
            var properties = existingManagedHsm.OriginalManagedHsm.Properties;
            properties.EnablePurgeProtection = parameters.EnablePurgeProtection;
            if (!string.IsNullOrEmpty(parameters.PublicNetworkAccess))
            {
                properties.PublicNetworkAccess = parameters.PublicNetworkAccess;
                properties.NetworkAcls.DefaultAction = PublicNetworkAccess.Enabled.ToString().Equals(parameters.PublicNetworkAccess) ? 
                    NetworkRuleAction.Allow.ToString() : NetworkRuleAction.Deny.ToString();
            }
            var response = KeyVaultManagementClient.ManagedHsms.Update(
                resourceGroupName: existingManagedHsm.ResourceGroupName,
                name: existingManagedHsm.Name,
                parameters: new ManagedHsm
                {
                    Location = existingManagedHsm.Location,
                    Sku = new ManagedHsmSku
                    {
                        Name = (ManagedHsmSkuName)Enum.Parse(typeof(ManagedHsmSkuName), existingManagedHsm.Sku)
                    },
                    Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                    Properties = properties
                });

            return new PSManagedHsm(response, graphClient);
        }

        /// <summary>
        /// Delete an existing Managed HSM.
        /// </summary>
        /// <param name="managedHsm"></param>
        /// <param name="resourceGroupName"></param>
        public void DeleteManagedHsm(string managedHsm, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(managedHsm))
                throw new ArgumentNullException("managedHsm");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                KeyVaultManagementClient.ManagedHsms.Delete(resourceGroupName, managedHsm);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                // there's a known issue that the long running delete operation will
                // finally throws an not found exception,
                // we'll just ignore it
            }
        }

        /// <summary>
        /// Purge a deleted Managed HSM. Throws if Managed HSM is not found.
        /// </summary>
        /// <param name="managedHsmName"></param>
        /// <param name="location"></param>
        public void PurgeManagedHsm(string managedHsmName, string location)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                KeyVaultManagementClient.ManagedHsms.PurgeDeleted(managedHsmName, location);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException() || ce.IsNoContentException())
            {
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.DeletedManagedHsmNotFound, managedHsmName, location));
            }
        }

        #endregion

        #region HELP_METHODS
        /// <summary>
        /// Update vault network rule set
        /// </summary>
        /// <param name="vaultProperties">Vault property</param>
        /// <param name="psRuleSet">Network rule set input</param>
        private static void UpdateVaultNetworkRuleSetProperties(VaultProperties vaultProperties, PSKeyVaultNetworkRuleSet psRuleSet)
        {
            if (vaultProperties == null)
                return;

            var updatedRuleSet = new NetworkRuleSet();       // It contains default settings
            if (psRuleSet != null)
            {
                updatedRuleSet.DefaultAction = psRuleSet.DefaultAction.ToString();
                updatedRuleSet.Bypass = psRuleSet.Bypass.ToString();

                if (psRuleSet.IpAddressRanges != null && psRuleSet.IpAddressRanges.Count > 0)
                {
                    updatedRuleSet.IpRules = psRuleSet.IpAddressRanges.Select(ipAddress => new IPRule { Value = ipAddress }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.IpRules = new List<IPRule>();
                }

                if (psRuleSet.VirtualNetworkResourceIds != null && psRuleSet.VirtualNetworkResourceIds.Count > 0)
                {
                    updatedRuleSet.VirtualNetworkRules = psRuleSet.VirtualNetworkResourceIds.Select(resourceId => new VirtualNetworkRule { Id = resourceId }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.VirtualNetworkRules = new List<VirtualNetworkRule>();
                }
            }

            vaultProperties.NetworkAcls = updatedRuleSet;
        }
        #endregion
    }
}
