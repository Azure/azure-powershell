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

namespace Microsoft.Azure.Commands.KeyVault
{
    public class KeyVaultManagementCmdletBase : AzurePSCmdlet
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
                    this._keyVaultManagementClient = new PSKeyVaultModels.VaultManagementClient(Profile.Context);
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
                    _activeDirectoryClient = new ActiveDirectoryClient(Profile.Context);
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
                this._resourcesClient = new PSResourceManagerModels.ResourcesClient(this.Profile)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                return _resourcesClient;
            }

            set { this._resourcesClient = value;  }
        }

        protected List<PSKeyVaultModels.VaultIdentityItem> ListVaults(string resourceGroupName, Hashtable tag)
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

            List<PSKeyVaultModels.VaultIdentityItem> vaults = new List<PSKeyVaultModels.VaultIdentityItem>();
            if (listResult.Resources != null)
            {
                vaults.AddRange(listResult.Resources.Where(r => r.Type == KeyVaultManagementClient.VaultsResourceType).Select(r => new PSKeyVaultModels.VaultIdentityItem(r)));
            }

            while (!string.IsNullOrEmpty(listResult.NextLink))
            {
                listResult = armClient.Resources.ListNext(listResult.NextLink);
                if (listResult.Resources != null)
                {
                    vaults.AddRange(listResult.Resources.Select(r => new PSKeyVaultModels.VaultIdentityItem(r)));
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
                var vault = resourcesByName.Where(r => r.Name == vaultName).FirstOrDefault();
                if (vault != null)                
                    rg = new PSResourceManagerModels.ResourceIdentifier(vault.Id).ResourceGroupName;                                                    
            }

            return rg;
        }

        protected bool VaultExists(string name, string resourceGroupName)
        {
            //Get meta data using ResourceManagementClient to avoid having KV CP decrypt the vault
            var identifier = new PSResourceManagerModels.ResourceIdentifier()
            {
                ParentResource = null,
                ResourceGroupName = resourceGroupName,
                ResourceName = name,
                ResourceType = this.KeyVaultManagementClient.VaultsResourceType
            }.ToResourceIdentity(this.KeyVaultManagementClient.ApiVersion);

            return this.ResourcesClient.ResourceManagementClient.Resources.CheckExistence(resourceGroupName, identifier).Exists;
        }

        protected Guid GetTenantId()
        {
            var tenantIdStr =
                Profile.Context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants).FirstOrDefault();
            var tenantIdGuid = Guid.Empty;

            if (string.IsNullOrWhiteSpace(tenantIdStr) || !Guid.TryParse(tenantIdStr, out tenantIdGuid))
            {
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.InvalidAzureEnvironment);
            }

            return tenantIdGuid;
        }

        protected Guid GetCurrentUsersObjectId()
        {
            if (Profile.Context.Subscription == null)
                throw new InvalidOperationException(Microsoft.WindowsAzure.Commands.Common.Properties.Resources.InvalidSelectedSubscription);

            if (string.IsNullOrWhiteSpace(Profile.Context.Subscription.Account))
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.NoDefaultUserAccount);

            var account = Profile.Accounts.Values.Where(a => a.Id == Profile.Context.Subscription.Account && a.Type == AzureAccount.AccountType.User).FirstOrDefault();
            if (account == null)
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.NoDefaultUserAccount);

            try
            {
                return GetObjectId(
                    upn: Profile.Context.Subscription.Account,
                    objectId: Guid.Empty,
                    spn: null
                );
            }
            catch
            {
                throw new InvalidOperationException(string.Format(PSKeyVaultProperties.Resources.ADObjectNotFound, Profile.Context.Subscription.Account, ActiveDirectoryClient.GraphClient.TenantID));
            }
        }

        protected Guid GetObjectId(Guid objectId, string upn, string spn)
        {
            var filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = upn,
                    SPN = spn,                    
                    Paging = true,
                };

            var obj = ActiveDirectoryClient.GetADObject(filter);

            if (obj == null && !string.IsNullOrWhiteSpace(upn))
            {
                filter = new ADObjectFilterOptions()
                {
                    Mail = upn,
                    Paging = true,
                };
                obj = ActiveDirectoryClient.GetADObject(filter);
            }

            if (obj != null)
                return obj.Id;
            else
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
