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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using PSKeyVaultModels = Microsoft.Azure.Commands.KeyVault.Models;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;
using Hyak.Common;

namespace Microsoft.Azure.Commands.KeyVault
{
    public class KeyVaultManagementCmdletBase : AzureRMCmdlet
    {
        public KeyVaultManagementCmdletBase()
        {

        }

        private PSKeyVaultModels.VaultManagementClient _keyVaultManagementClient;
        public PSKeyVaultModels.VaultManagementClient KeyVaultManagementClient
        {
            get
            {
                if (this._keyVaultManagementClient == null)
                {
                    this._keyVaultManagementClient = new PSKeyVaultModels.VaultManagementClient(DefaultContext);
                }
                return this._keyVaultManagementClient;
            }

            set { this._keyVaultManagementClient = value; }
        }


        private ActiveDirectoryClient _activeDirectoryClient;
        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient == null)
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultContext);
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

        private PSResourceManagerModels.ResourcesClient _resourcesClient;
        public PSResourceManagerModels.ResourcesClient ResourcesClient
        {
            get
            {
                this._resourcesClient = new PSResourceManagerModels.ResourcesClient(DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                return _resourcesClient;
            }

            set { this._resourcesClient = value;  }
        }

        protected List<PSKeyVaultModels.PSVaultIdentityItem> ListVaults(string resourceGroupName, Hashtable tag)
        {
            IResourceManagementClient armClient = this.ResourcesClient.ResourceManagementClient;

            PSTagValuePair tagValuePair = new PSTagValuePair();
            if (tag != null)
            {
                tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException(PSKeyVaultProperties.Resources.InvalidTagFormat);
                }
            }
            ResourceListResult listResult = armClient.Resources.List(new ResourceListParameters
            {
                ResourceGroupName = resourceGroupName,
                ResourceType = tag == null ? KeyVaultManagementClient.VaultsResourceType : null,
                TagName = tagValuePair.Name,
                TagValue = tagValuePair.Value                
            });

            List<PSKeyVaultModels.PSVaultIdentityItem> vaults = new List<PSKeyVaultModels.PSVaultIdentityItem>();
            if (listResult.Resources != null)
            {
                vaults.AddRange(listResult.Resources.Where(r => r.Type.Equals(KeyVaultManagementClient.VaultsResourceType, StringComparison.OrdinalIgnoreCase))
                    .Select(r => new PSKeyVaultModels.PSVaultIdentityItem(r)));
            }

            while (!string.IsNullOrEmpty(listResult.NextLink))
            {
                listResult = armClient.Resources.ListNext(listResult.NextLink);
                if (listResult.Resources != null)
                {
                    vaults.AddRange(listResult.Resources.Select(r => new PSKeyVaultModels.PSVaultIdentityItem(r)));
                }
            }

            return vaults;
        }         

        protected string GetResourceGroupName(string vaultName)
        {
            string rg = null;
            var resourcesByName = this.ResourcesClient.FilterResources(new PSResourceManagerModels.FilterResourcesOptions()
                {
                    ResourceType = KeyVaultManagementClient.VaultsResourceType                     
                });

            if (resourcesByName != null && resourcesByName.Count > 0)            
            {
                var vault = resourcesByName.FirstOrDefault(r => r.Name.Equals(vaultName, StringComparison.OrdinalIgnoreCase));
                if (vault != null)                
                    rg = new PSResourceManagerModels.ResourceIdentifier(vault.Id).ResourceGroupName;                                                    
            }

            return rg;
        }

        // See if we can list resources in current subscription and find a vault with matching name.
        // If some other subscription has a vault by this name, we cannot list it here, but the Key Vault service will
        // reject any attempts to create one by this name even if we tried.
        //
        // We are intentionally not looking up the vault name in a specific resource group here. If the vault did
        // exist in that resource group, we would end up having the Key Vault service decrypt the vault for us.
        // This is a heavy operation and not required here.
        //
        // An alternate implementation that checks for the vault name globally would be to construct a vault 
        // URL with the given name and attempt checking DNS entries for it.
        protected bool VaultExistsInCurrentSubscription(string name)
        {
            return GetResourceGroupName(name) != null;
        }

        protected Guid GetTenantId()
        {
            if (DefaultContext.Tenant == null || DefaultContext.Tenant.Id == Guid.Empty)
            {
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.InvalidAzureEnvironment);
            }

            return DefaultContext.Tenant.Id;
        }

        protected Guid GetCurrentUsersObjectId()
        {
            if (DefaultContext.Subscription == null)
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.InvalidSelectedSubscription);

            if (DefaultContext.Account == null)
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.NoDefaultUserAccount);


            return GetObjectId(
                    upn: DefaultContext.Account.Id,
                    objectId: Guid.Empty,
                    spn: null
                    );
        }

        protected Guid GetObjectId(Guid objectId, string upn, string spn)
        {
            var filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = upn,
                    SPN = spn,                    
                    Paging = true,
                };

            var exceptionMessage = string.Empty;
            PSADObject obj = null;
            try
            {
                obj = ActiveDirectoryClient.GetADObject(filter);

                if (obj == null && !string.IsNullOrWhiteSpace(upn))
                {
                    filter = new ADObjectFilterOptions()
                    {
                        Mail = upn,
                        Paging = true,
                    };
                    obj = ActiveDirectoryClient.GetADObject(filter);
                }
            }
            catch (CloudException ex)
            {
                // There is a bug/feature in the Azure Active Directory client in PowerShell that it does not show any exception when
                // calling graph unless it is trying to list groups. For the filter that we set, only if the mail and paging is set 
                // in Fairfax environment we get the following exception.
                exceptionMessage = string.Format("Error: {0}", ex.Message);
            }

            if (obj != null)
                return obj.Id;

            // In the Fairfax environment the Graph access token does not have a correct audiance
            // and this scenario is broken. So, we cannot verify that the object ID belongs to the user directory.
            // User can define their own environment, thereby we only compare key vault DNS suffix.
            // TODO: replace "vault.usgovcloudapi.net" with AzureEnvironmentConstants.USGovernmentKeyVaultDnsSuffix when the environment variable is added.
            // TODO: Remove this if condition when the issue with graph API is fixed.
            if (string.Compare(DefaultContext.Environment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix], "vault.usgovcloudapi.net", true) == 0)
            {
                if (objectId != Guid.Empty)
                    return objectId;
                else throw new NotSupportedException(string.Format(PSKeyVaultProperties.Resources.ADObjectIDRetrievalFailed, exceptionMessage));
            }

            throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.ADObjectNotFound, filter.ActiveFilter, ActiveDirectoryClient.GraphClient.TenantID));
        }

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
        protected readonly string DefaultSkuFamily = "A";
        protected readonly string DefaultSkuName = "Standard";
    }
}
