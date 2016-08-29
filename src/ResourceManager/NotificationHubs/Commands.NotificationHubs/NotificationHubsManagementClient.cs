//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.NotificationHubs.Models;
using Microsoft.Azure.Management.NotificationHubs;
using Microsoft.Azure.Management.NotificationHubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.NotificationHubs
{

    public class NotificationHubsManagementClient
    {
        private readonly AzureContext _context;

        private Management.NotificationHubs.NotificationHubsManagementClient _client;

        public NotificationHubsManagementClient(AzureContext azureContext)
        {
            if (azureContext == null)
            {
                throw new ArgumentNullException("azureContext");
            }

            _context = azureContext;
        }

        private INotificationHubsManagementClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client =
                        AzureSession.ClientFactory.CreateClient<Management.NotificationHubs.NotificationHubsManagementClient>(
                            _context,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        #region Namespace
        public NamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            NamespaceGetResponse response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new NamespaceAttributes(resourceGroupName, response.Value);
        }

        public IEnumerable<NamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            NamespaceListResponse response = Client.Namespaces.List(resourceGroupName);
            IEnumerable<NamespaceAttributes> resourceList = response.Value.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            return resourceList;
        }

        public IEnumerable<NamespaceAttributes> ListAllNamespaces()
        {
            NamespaceListResponse response = Client.Namespaces.ListAll();

            var resourceList = response.Value.Select(resource => new NamespaceAttributes(null, resource));
            return resourceList;
        }

        public NamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, Dictionary<string, string> tags)
        {
            var parameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location,
                Properties = new NamespaceProperties()
                {
                    NamespaceType = NamespaceType.NotificationHub
                }
            };

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(resourceGroupName, response.Value);
        }
        public NamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, NamespaceState state, bool critical, Dictionary<string, string> tags)
        {
            var parameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location,
                Properties = new NamespaceProperties()
                {
                    NamespaceType = NamespaceType.NotificationHub,
                    Status = ((state == NamespaceState.Disabled) ? state : NamespaceState.Active).ToString(),
                    Enabled = (state == NamespaceState.Disabled) ? false : true
                }
            };

            if (critical)
            {
                parameter.Properties.Critical = critical;
            }

            if (tags != null && tags.Count() > 0)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(resourceGroupName, response.Value);
        }

        public NamespaceLongRunningOperation BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            NamespaceLongRunningResponse response = Client.Namespaces.Delete(resourceGroupName, namespaceName);
            RetryAfter(response, Client.LongRunningOperationInitialTimeout);

            return NamespaceLongRunningOperation.CreateLongRunningOperation(NamespaceLongRunningOperation.DeleteOperation, response);
        }

        internal NamespaceLongRunningOperation GetLongRunningOperationStatus(NamespaceLongRunningOperation longRunningOperation)
        {
            var response = Client.Namespaces.GetLongRunningOperationStatus(longRunningOperation.OperationLink);

            RetryAfter(response, Client.LongRunningOperationInitialTimeout);
            var result = NamespaceLongRunningOperation.CreateLongRunningOperation(longRunningOperation.OperationName, response as NamespaceLongRunningResponse);

            return result;
        }

        private static void RetryAfter(LongRunningOperationResponse longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }

        public SharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            SharedAccessAuthorizationRuleGetResponse response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response.Value);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            SharedAccessAuthorizationRuleListResponse response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Value.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName,
                                List<AccessRights> rights, string primarykey, string secondaryKey = null)
        {
            var parameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Name = authRuleName,
                Properties = new SharedAccessAuthorizationRuleProperties()
                {
                    KeyName = authRuleName,
                    Rights = new List<AccessRights>(rights),
                    PrimaryKey = primarykey,
                    ClaimType = SharedAccessAuthorizationRuleAttributes.DefaultClaimType,
                    ClaimValue = SharedAccessAuthorizationRuleAttributes.DefaultClaimValue
                }
            };

            parameter.Properties.SecondaryKey = string.IsNullOrEmpty(secondaryKey) ? GenerateRandomKey() : secondaryKey;

            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authRuleName, parameter);
            return new SharedAccessAuthorizationRuleAttributes(response.Value);
        }

        public bool DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            var response = Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return true;
        }

        public ResourceListKeys GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            ResourceListKeys listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return listKeys;
        }

        #endregion

        #region NotificationHub
        public NotificationHubAttributes GetNotificationHub(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            NotificationHubGetResponse response = Client.NotificationHubs.Get(resourceGroupName, namespaceName, notificationHubName);
            return new NotificationHubAttributes(response.Value);
        }

        public NotificationHubAttributes GetNotificationHubPNSCredentials(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            NotificationHubGetResponse response = Client.NotificationHubs.GetPnsCredentials(resourceGroupName, namespaceName, notificationHubName);
            return new NotificationHubAttributes(response.Value);
        }

        public IEnumerable<NotificationHubAttributes> ListNotificationHubs(string resourceGroupName, string namespaceName)
        {
            NotificationHubListResponse response = Client.NotificationHubs.List(resourceGroupName, namespaceName);
            IEnumerable<NotificationHubAttributes> resourceList = response.Value.Select(resource => new NotificationHubAttributes(resource));
            return resourceList;
        }

        public NotificationHubAttributes CreateNotificationHub(string resourceGroupName, string namespaceName, NotificationHubAttributes nhAttributes)
        {
            var parameter = new NotificationHubCreateOrUpdateParameters()
            {
                Location = nhAttributes.Location,
                Properties = new NotificationHubProperties()
                {
                    AdmCredential = nhAttributes.AdmCredential,
                    ApnsCredential = nhAttributes.ApnsCredential,
                    BaiduCredential = nhAttributes.BaiduCredential,
                    GcmCredential = nhAttributes.GcmCredential,
                    MpnsCredential = nhAttributes.MpnsCredential,
                    WnsCredential = nhAttributes.WnsCredential,
                    Name = nhAttributes.Name,
                    RegistrationTtl = nhAttributes.RegistrationTtl
                }
            };

            if (nhAttributes.Tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(nhAttributes.Tags);
            }
            var response = Client.NotificationHubs.Create(resourceGroupName, namespaceName, nhAttributes.Name, parameter);
            return new NotificationHubAttributes(response.Value);
        }

        public NotificationHubAttributes UpdateNotificationHub(string resourceGroupName, string namespaceName, NotificationHubAttributes nhAttributes)
        {
            var parameter = new NotificationHubCreateOrUpdateParameters()
            {
                Location = nhAttributes.Location,
                Tags = new Dictionary<string, string>(nhAttributes.Tags),
                Properties = new NotificationHubProperties()
                {
                    AdmCredential = nhAttributes.AdmCredential,
                    ApnsCredential = nhAttributes.ApnsCredential,
                    BaiduCredential = nhAttributes.BaiduCredential,
                    GcmCredential = nhAttributes.GcmCredential,
                    MpnsCredential = nhAttributes.MpnsCredential,
                    WnsCredential = nhAttributes.WnsCredential,
                    Name = nhAttributes.Name,
                    RegistrationTtl = nhAttributes.RegistrationTtl
                }
            };

            var response = Client.NotificationHubs.Update(resourceGroupName, namespaceName, nhAttributes.Name, parameter);
            return new NotificationHubAttributes(response.Value);
        }

        public bool DeleteNotificationHub(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            var response = Client.NotificationHubs.Delete(resourceGroupName, namespaceName, notificationHubName);
            return true;
        }

        public SharedAccessAuthorizationRuleAttributes GetNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            SharedAccessAuthorizationRuleGetResponse response = Client.NotificationHubs.GetAuthorizationRule(resourceGroupName, namespaceName,
                                        notificationHubName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response.Value);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName,
                                                    string notificationHubName)
        {
            SharedAccessAuthorizationRuleListResponse response = Client.NotificationHubs.ListAuthorizationRules(resourceGroupName, namespaceName, notificationHubName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Value.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName,
                                string notificationHubName, string authRuleName,
                                List<AccessRights> rights, string primarykey, string secondaryKey)
        {
            var parameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Name = authRuleName,
                Properties = new SharedAccessAuthorizationRuleProperties()
                {
                    KeyName = authRuleName,
                    Rights = new List<AccessRights>(rights),
                    PrimaryKey = primarykey,
                    ClaimType = SharedAccessAuthorizationRuleAttributes.DefaultClaimType,
                    ClaimValue = SharedAccessAuthorizationRuleAttributes.DefaultClaimValue
                }
            };

            parameter.Properties.SecondaryKey = string.IsNullOrEmpty(secondaryKey) ? GenerateRandomKey() : secondaryKey;

            var response = Client.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, notificationHubName, authRuleName, parameter);
            return new SharedAccessAuthorizationRuleAttributes(response.Value);
        }

        public bool DeleteNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            var response = Client.NotificationHubs.DeleteAuthorizationRule(resourceGroupName, namespaceName, notificationHubName, authRuleName);
            return true;
        }

        public ResourceListKeys GetNotificationHubListKeys(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            ResourceListKeys listKeys = Client.NotificationHubs.ListKeys(resourceGroupName, namespaceName,
                                        notificationHubName, authRuleName);

            return listKeys;
        }

        #endregion

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }
    }
}
