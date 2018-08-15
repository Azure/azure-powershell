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

#if NETSTANDARD
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
#else
using Microsoft.Azure.ActiveDirectory.GraphClient;
#endif
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using PSKeyVaultModels = Microsoft.Azure.Commands.KeyVault.Models;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Rest.Azure;
using KeyPerms = Microsoft.Azure.Management.KeyVault.Models.KeyPermissions;
using SecretPerms = Microsoft.Azure.Management.KeyVault.Models.SecretPermissions;
using CertPerms = Microsoft.Azure.Management.KeyVault.Models.CertificatePermissions;
using StoragePerms = Microsoft.Azure.Management.KeyVault.Models.StoragePermissions;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Paging;

namespace Microsoft.Azure.Commands.KeyVault
{
    public class KeyVaultManagementCmdletBase : AzureRMCmdlet
    {

        private PSKeyVaultModels.VaultManagementClient _keyVaultManagementClient;
        private DataServiceCredential _dataServiceCredential;
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
                    _dataServiceCredential = new DataServiceCredential(AzureSession.Instance.AuthenticationFactory, DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.Graph);
#if NETSTANDARD
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.DefaultContext);
#else
                    _activeDirectoryClient = new ActiveDirectoryClient(new Uri(string.Format("{0}/{1}",
                    DefaultProfile.DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.Graph), _dataServiceCredential.TenantId)),
                    () => Task.FromResult(_dataServiceCredential.GetToken()));
#endif
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

        private ResourceManagementClient _resourceClient;
        public ResourceManagementClient ResourceClient
        {
            get
            {
                if (_resourceClient == null)
                {
                    _resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return _resourceClient;
            }

            set { this._resourceClient = value; }
        }

        protected List<PSKeyVaultModels.PSKeyVaultIdentityItem> ListVaults(string resourceGroupName, Hashtable tag)
        {
            IResourceManagementClient armClient = this.ResourceClient;

            PSTagValuePair tagValuePair = new PSTagValuePair();
            if (tag != null && tag.Count > 0)
            {
                tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException(PSKeyVaultProperties.Resources.InvalidTagFormat);
                }
            }
            var listResult = Enumerable.Empty<PSKeyVaultIdentityItem>();
            var resourceType = KeyVaultManagementClient.VaultsResourceType;
            if (resourceGroupName != null)
            {
                listResult = this.ListByResourceGroup(resourceGroupName,
                    new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == resourceType));
            }
            else
            {
                listResult = this.ListResources(
                    new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == resourceType));
            }

            if (!string.IsNullOrEmpty(tagValuePair.Name))
            {
                listResult = listResult.Where(r => r.Tags != null && r.Tags.Keys != null && r.Tags.ConvertToDictionary().Keys.Where(k => string.Equals(k, tagValuePair.Name, StringComparison.OrdinalIgnoreCase)).Any());
            }

            if (!string.IsNullOrEmpty(tagValuePair.Value))
            {
                listResult = listResult.Where(r => r.Tags != null && r.Tags.Values != null && r.Tags.ConvertToDictionary().Values.Where(v => string.Equals(v, tagValuePair.Value, StringComparison.OrdinalIgnoreCase)).Any());
            }

            List<PSKeyVaultModels.PSKeyVaultIdentityItem> vaults = new List<PSKeyVaultModels.PSKeyVaultIdentityItem>();
            if (listResult != null)
            {
                vaults.AddRange(listResult);
            }

            return vaults;
        }

        public virtual IEnumerable<PSKeyVaultIdentityItem> ListResources(Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null, ulong first = ulong.MaxValue, ulong skip = ulong.MinValue)
        {
            IResourceManagementClient armClient = this.ResourceClient;

            return new GenericPageEnumerable<GenericResource>(
                delegate ()
                {
                    return armClient.Resources.List(filter);
                }, armClient.Resources.ListNext, first, skip).Select(r => new PSKeyVaultIdentityItem(r));
        }

        private IEnumerable<PSKeyVaultIdentityItem> ListByResourceGroup(
            string resourceGroupName,
            Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter,
            ulong first = ulong.MaxValue,
            ulong skip = ulong.MinValue)
        {
            IResourceManagementClient armClient = this.ResourceClient;

            return new GenericPageEnumerable<GenericResource>(
                delegate ()
                {
                    return armClient.ResourceGroups.ListResources(resourceGroupName, filter);
                }, armClient.ResourceGroups.ListResourcesNext, first, skip).Select(r => new PSKeyVaultIdentityItem(r));
        }

        protected string GetResourceGroupName(string vaultName)
        {
            string rg = null;
            var resourcesByName = this.ResourceClient.FilterResources(new FilterResourcesOptions()
            {
                ResourceType = KeyVaultManagementClient.VaultsResourceType
            });

            if (resourcesByName != null && resourcesByName.Count > 0)
            {
                var vault = resourcesByName.FirstOrDefault(r => r.Name.Equals(vaultName, StringComparison.OrdinalIgnoreCase));
                if (vault != null)
                    rg = new ResourceIdentifier(vault.Id).ResourceGroupName;
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
            if (DefaultContext.Tenant == null || DefaultContext.Tenant.GetId() == Guid.Empty)
            {
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.InvalidAzureEnvironment);
            }

            return DefaultContext.Tenant.GetId();
        }

        protected string GetCurrentUsersObjectId()
        {
            if (DefaultContext.Subscription == null)
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.InvalidSelectedSubscription);

            if (DefaultContext.Account == null)
                throw new InvalidOperationException(PSKeyVaultProperties.Resources.NoDefaultUserAccount);

            string objectId = null;
            if (DefaultContext.Account.Type == AzureAccount.AccountType.User)
            {
#if NETSTANDARD
                objectId = ActiveDirectoryClient.GetObjectId(new ADObjectFilterOptions {UPN = DefaultContext.Account.Id}).ToString();
#else
                var userFetcher = ActiveDirectoryClient.Me.ToUser();
                var user = userFetcher.ExecuteAsync().Result;
                objectId = user.ObjectId;
#endif
            }

            return objectId;
        }

        private void ThrowIfMultipleObjectIds<AADType>(IEnumerable<AADType> principal, string objectFilter)
        {
            // If there is a second element then there are too many.
            if (principal.ElementAtOrDefault(1) != null)
            {
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.ADObjectAmbiguous, objectFilter,
                (_dataServiceCredential != null) ? _dataServiceCredential.TenantId : string.Empty));
            }
        }

        private string GetObjectIdByUpn(string upn)
        {
            string objId = null;
            if (!string.IsNullOrWhiteSpace(upn))
            {
#if NETSTANDARD
                var user = ActiveDirectoryClient.FilterUsers(new ADObjectFilterOptions() { UPN = upn }).SingleOrDefault();
#else
                var user = ActiveDirectoryClient.Users.Where(u => u.UserPrincipalName.Equals(upn, StringComparison.OrdinalIgnoreCase))
                     .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult().CurrentPage.SingleOrDefault();
#endif
                if (user != null)
                {
#if NETSTANDARD
                    objId = user.Id.ToString();
#else
                    objId = user.ObjectId;
#endif
                }
            }
            return objId;
        }

        private string GetObjectIdBySpn(string spn)
        {
            string objId = null;
            if (!string.IsNullOrWhiteSpace(spn))
            {
#if NETSTANDARD
                var odataQuery = new Rest.Azure.OData.ODataQuery<Graph.RBAC.Version1_6.Models.ServicePrincipal>(s => s.ServicePrincipalNames.Contains(spn));
                var servicePrincipal = ActiveDirectoryClient.FilterServicePrincipals(odataQuery).SingleOrDefault();
                objId = servicePrincipal?.Id.ToString();
#else
                var servicePrincipal = ActiveDirectoryClient.ServicePrincipals.Where(s =>
                    s.ServicePrincipalNames.Any(n => n.Equals(spn, StringComparison.OrdinalIgnoreCase)))
                     .ExecuteAsync().GetAwaiter().GetResult().CurrentPage.SingleOrDefault();
                 objId = servicePrincipal?.ObjectId;
#endif
            }
            return objId;
        }

        private string GetObjectIdByEmail(string email)
        {
            string objId = null;
            // In ADFS, Graph cannot handle this particular combination of filters.
            if (!DefaultProfile.DefaultContext.Environment.OnPremise && !string.IsNullOrWhiteSpace(email))
            {
#if NETSTANDARD
                var users = ActiveDirectoryClient.FilterUsers(new ADObjectFilterOptions() { Mail = email });
                if (users != null)
                {
                    ThrowIfMultipleObjectIds(users, email);
                    var user = users.FirstOrDefault();
                    objId = user?.Id.ToString();
                }
#else
                var users = ActiveDirectoryClient.Users.Where(FilterByEmail(email)).ExecuteAsync().GetAwaiter().GetResult().CurrentPage;
                if (users != null)
                {
                    ThrowIfMultipleObjectIds(users, email);
                    var user = users.FirstOrDefault();
                    objId = user?.ObjectId;
                }
#endif
            }
            return objId;
        }

#if !NETSTANDARD
        private Expression<Func<IUser, bool>> FilterByEmail(string email)
        {
            return u => u.Mail.Equals(email, StringComparison.OrdinalIgnoreCase) ||
                u.OtherMails.Any(m => m.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
#endif
        private bool ValidateObjectId(string objId)
        {
            bool isValid = false;
            if (!string.IsNullOrWhiteSpace(objId))
            {
#if NETSTANDARD
                var objectCollection = ActiveDirectoryClient.GetObjectsByObjectId(new List<string> { objId });
#else
                var objectCollection = ActiveDirectoryClient.GetObjectsByObjectIdsAsync(new[] { objId }, new string[] { }).GetAwaiter().GetResult();
#endif
                if (objectCollection.Any())
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        protected string GetObjectId(string objectId, string upn, string email, string spn)
        {
            string objId = null;
            var objectFilter = objectId ?? string.Empty;

            if (!string.IsNullOrEmpty(objectId))
            {
                objId = ValidateObjectId(objectId) ? objectId : null;
            }
            else if (!string.IsNullOrEmpty(upn))
            {
                objId = GetObjectIdByUpn(upn);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                objId = GetObjectIdByEmail(email);
            }
            else if (!string.IsNullOrEmpty(spn))
            {
                objId = GetObjectIdBySpn(spn);
            }

            if (string.IsNullOrWhiteSpace(objId))
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.ADObjectNotFound, objectFilter,
                    (_dataServiceCredential != null) ? _dataServiceCredential.TenantId : string.Empty));

            return objId;
        }

        private bool IsValidGUid(string stringGuid)
        {
            Guid parsedGuid;
            return Guid.TryParse(stringGuid, out parsedGuid);
        }

        /// <summary>
        /// Determines whether or not the given object ID has valid syntax.
        /// This does not validate whether or not the object ID is actually present in the Graph DB.
        /// </summary>
        /// <param name="objectId">The object ID whose syntax is to be validated.</param>
        /// <returns>True iff the given object ID has valid syntax.</returns>
        protected bool IsValidObjectIdSyntax(string objectId)
        {
            if (string.IsNullOrWhiteSpace(objectId))
            {
                return false;
            }

            // In ADFS, object IDs have no additional syntax restrictions.
            if (DefaultProfile.DefaultContext.Environment.OnPremise)
            {
                return true;
            }

            // In AAD, object IDs must be parsable as Guids.
            return IsValidGUid(objectId);
        }

        protected readonly string[] DefaultPermissionsToKeys =
        {
            KeyPerms.Get,
            KeyPerms.Create,
            KeyPerms.Delete,
            KeyPerms.List,
            KeyPerms.Update,
            KeyPerms.Import,
            KeyPerms.Backup,
            KeyPerms.Restore,
            KeyPerms.Recover
        };

        protected readonly string[] DefaultPermissionsToSecrets = 
        {
            SecretPerms.Get,
            SecretPerms.List,
            SecretPerms.Set,
            SecretPerms.Delete,
            SecretPerms.Backup,
            SecretPerms.Restore,
            SecretPerms.Recover
        };

        protected readonly string[] DefaultPermissionsToCertificates =
        {
            CertPerms.Get,
            CertPerms.Delete,
            CertPerms.List,
            CertPerms.Create,
            CertPerms.Import,
            CertPerms.Update,
            CertPerms.Deleteissuers,
            CertPerms.Getissuers,
            CertPerms.Listissuers,
            CertPerms.Managecontacts,
            CertPerms.Manageissuers,
            CertPerms.Setissuers,
            CertPerms.Recover,
            CertPerms.Backup,
            CertPerms.Restore
        };

        protected readonly string[] DefaultPermissionsToStorage = 
        {
            StoragePerms.Delete,
            StoragePerms.Deletesas,
            StoragePerms.Get,
            StoragePerms.Getsas,
            StoragePerms.List,
            StoragePerms.Listsas,
            StoragePerms.Regeneratekey,
            StoragePerms.Set,
            StoragePerms.Setsas,
            StoragePerms.Update,
            StoragePerms.Recover,
            StoragePerms.Backup,
            StoragePerms.Restore
        };

        protected readonly string DefaultSkuFamily = "A";
        protected readonly string DefaultSkuName = "Standard";
    }
}
