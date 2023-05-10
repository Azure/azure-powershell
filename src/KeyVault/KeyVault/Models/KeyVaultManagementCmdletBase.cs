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
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Paging;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CertPerms = Microsoft.Azure.Management.KeyVault.Models.CertificatePermissions;
using KeyPerms = Microsoft.Azure.Management.KeyVault.Models.KeyPermissions;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using SecretPerms = Microsoft.Azure.Management.KeyVault.Models.SecretPermissions;
using StoragePerms = Microsoft.Azure.Management.KeyVault.Models.StoragePermissions;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.DirectoryObjects;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.KeyVault
{
    [SupportsSubscriptionId]
    public class KeyVaultManagementCmdletBase : AzureRMCmdlet
    {
        private VaultManagementClient _keyVaultManagementClient;
        private DataServiceCredential _dataServiceCredential;
        public VaultManagementClient KeyVaultManagementClient
        {
            get
            {
                return _keyVaultManagementClient ?? (_keyVaultManagementClient = new VaultManagementClient(DefaultContext));
            }

            set { _keyVaultManagementClient = value; }
        }


        private IMicrosoftGraphClient _graphClient;
        public IMicrosoftGraphClient GraphClient
        {
            get
            {
                if (_graphClient != null) return _graphClient;

                _dataServiceCredential = new DataServiceCredential(AzureSession.Instance.AuthenticationFactory, DefaultProfile.DefaultContext, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl);
                try
                {
                    _graphClient = AzureSession.Instance.ClientFactory.CreateArmClient<MicrosoftGraphClient>(DefaultContext, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl);
                    (_graphClient as MicrosoftGraphClient).TenantID = DefaultContext.Tenant.Id.ToString();
                }
                catch
                {
                    _graphClient = null;
                }
                return _graphClient;
            }

            set { _graphClient = value; }
        }

        private ResourceManagementClient _resourceClient;
        public ResourceManagementClient ResourceClient
        {
            get
            {
                return _resourceClient ?? (_resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }

            set { _resourceClient = value; }
        }

        protected List<T> FilterByTag<T>(List<T> listResult, Hashtable tag) where T : PSKeyVaultIdentityItem
        {
            var tagValuePair = new PSTagValuePair();
            if (tag != null && tag.Count > 0)
            {
                tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException(PSKeyVaultProperties.Resources.InvalidTagFormat);
                }
            }

            if (!string.IsNullOrEmpty(tagValuePair.Name))
            {
                listResult = listResult.Where(r => r.Tags?.Keys != null && r.Tags.ConvertToDictionary().Keys.Any(k => string.Equals(k, tagValuePair.Name, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            if (!string.IsNullOrEmpty(tagValuePair.Value))
            {
                listResult = listResult.Where(r => r.Tags?.Values != null && r.Tags.ConvertToDictionary().Values.Any(v => string.Equals(v, tagValuePair.Value, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            return listResult;
        }

        protected T FilterByTag<T>(T vault, Hashtable tag) where T : PSKeyVaultIdentityItem
        {
            return FilterByTag(new List<T> { vault }, tag).FirstOrDefault();
        }

        protected List<PSKeyVaultIdentityItem> ListVaults(string resourceGroupName, Hashtable tag, ResourceTypeName? resourceTypeName = ResourceTypeName.Vault)
        {
            var vaults = new List<PSKeyVaultIdentityItem>();

            // List all kinds of vault resources
            if (resourceTypeName == null)
            {
                vaults.AddRange(ListVaults(resourceGroupName, tag, ResourceTypeName.Vault));
                vaults.AddRange(ListVaults(resourceGroupName, tag, ResourceTypeName.Hsm));
                return vaults;
            }

            var resourceType = resourceTypeName.Equals(ResourceTypeName.Hsm) ?
                KeyVaultManagementClient.ManagedHsmResourceType : KeyVaultManagementClient.VaultsResourceType;

            IEnumerable<PSKeyVaultIdentityItem> listResult = ListPagable(resourceGroupName,
                new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                    r => r.ResourceType == resourceType));

            if (listResult != null)
            {
                vaults.AddRange(listResult);
            }

            vaults = FilterByTag(vaults, tag);

            return vaults;
        }

        IEnumerable<PSKeyVaultIdentityItem> ListPagable(string resourceGroupName, Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null)
        {
            string nextPageLink = null;
            var results = new List<PSKeyVaultIdentityItem>();
            do
            {
                var response = ShouldListByResourceGroup(resourceGroupName, null) ?
                    ListByResourceGroup(resourceGroupName, filter, nextPageLink) :
                    ListResources(filter, nextPageLink);
                results.AddRange(response.Select(r => new PSKeyVaultIdentityItem(r)));
                nextPageLink = response?.NextPageLink;
            } while (!string.IsNullOrEmpty(nextPageLink));
            return results;
        }

        public virtual Rest.Azure.IPage<GenericResource> ListResources(
            Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null, 
            string NextPageLink = null)
        {
            IResourceManagementClient armClient = ResourceClient;
            return string.IsNullOrEmpty(NextPageLink) ? 
                armClient.Resources.List(filter) : 
                armClient.Resources.ListNext(NextPageLink);
        }

        private Rest.Azure.IPage<GenericResource> ListByResourceGroup(
            string resourceGroupName,
            Rest.Azure.OData.ODataQuery<GenericResourceFilter> filter = null,
            string NextPageLink = null)
        {
            IResourceManagementClient armClient = ResourceClient;
            return string.IsNullOrEmpty(NextPageLink) ? 
                armClient.ResourceGroups.ListResources(resourceGroupName, filter) :
                armClient.ResourceGroups.ListResourcesNext(NextPageLink);
        }

        protected string GetResourceGroupName(string name, bool isHsm = false)
        {
            var resourcesByName = ResourceClient.FilterResources(new FilterResourcesOptions
            {
                ResourceType = isHsm ? KeyVaultManagementClient.ManagedHsmResourceType : KeyVaultManagementClient.VaultsResourceType
            });

            string rg = null;
            if (resourcesByName != null && resourcesByName.Count > 0)
            {
                var vault = resourcesByName.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (vault != null)
                {
                    rg = new ResourceIdentifier(vault.Id).ResourceGroupName;
                }
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
        protected bool VaultExistsInCurrentSubscription(string name, bool isHsm = false)
        {
            return GetResourceGroupName(name, isHsm) != null;
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
                objectId = GraphClient.Users.GetMyProfile()?.Id;
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
            if (string.IsNullOrWhiteSpace(upn)) return null;
            var user = GraphClient.Users.GetUser(upn);
            string objId = null;
            if (user != null)
            {
                objId = user.Id.ToString();
            }
            return objId;
        }

        private string GetObjectIdBySpn(string spn)
        {
            if (string.IsNullOrWhiteSpace(spn)) return null;

            string filter = ODataHelper.FormatFilterString<MicrosoftGraphServicePrincipal>(s => s.ServicePrincipalNames.Contains(spn));
            var servicePrincipal = GraphClient.ServicePrincipals.ListServicePrincipal(filter: filter).Value.SingleOrDefault();
            var objId = servicePrincipal?.Id.ToString();
            return objId;
        }

        private string GetObjectIdByEmail(string email)
        {
            // In ADFS, Graph cannot handle this particular combination of filters.
            if (DefaultProfile.DefaultContext.Environment.OnPremise || string.IsNullOrWhiteSpace(email)) return null;

            string objId = null;
            string filter = ODataHelper.FormatFilterString<MicrosoftGraphUser>(s => s.Mail == email);
            var users = GraphClient.Users.ListUser(filter: filter).Value;
            if (users != null)
            {
                ThrowIfMultipleObjectIds(users, email);
                var user = users.FirstOrDefault();
                objId = user?.Id.ToString();
            }
            return objId;
        }

        private bool ValidateObjectId(string objId)
        {
            if (string.IsNullOrWhiteSpace(objId)) return false;
            try
            {
                return GraphClient.DirectoryObjects.GetDirectoryObject(objId) != null;
            }
            catch (Exception ex)
            {
                WriteWarning(Resources.ADGraphPermissionWarning);
                throw ex;
            }
        }

        protected string GetObjectId(string objectId, string upn, string email, string spn)
        {
            string objId = null;
            var objectFilter = objectId ?? upn ?? email ?? spn ?? string.Empty;

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

        private static bool IsValidGUid(string stringGuid)
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
            // In AAD, object IDs must be parsable as Guids.
            return DefaultProfile.DefaultContext.Environment.OnPremise || IsValidGUid(objectId);
        }

        // All but purge
        protected readonly string[] DefaultPermissionsToKeys =
        {
            KeyPerms.All
        };

        protected readonly string[] DefaultPermissionsToSecrets =
        {
            SecretPerms.All
        };

        protected readonly string[] DefaultPermissionsToCertificates =
        {
            CertPerms.All
        };

        protected readonly string[] DefaultPermissionsToStorage =
        {
            StoragePerms.All
        };

        protected readonly string DefaultSkuFamily = "A";
        protected readonly string DefaultSkuName = "Standard";

        protected readonly string DefaultManagedHsmSkuFamily = "b";
        protected readonly string DefaultManagedHsmSkuName = "Standard_B1";
    }
}
