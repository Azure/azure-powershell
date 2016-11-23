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
                        AzureSession.ClientFactory.CreateArmClient<Management.NotificationHubs.NotificationHubsManagementClient>(
                            _context,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        #region Namespace
        public NamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new NamespaceAttributes(resourceGroupName, response);
        }

        public IEnumerable<NamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            var response = Client.Namespaces.List(resourceGroupName);
            IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resourceGroupName, resource));
            return resourceList;
        }

        public IEnumerable<NamespaceAttributes> ListAllNamespaces()
        {
            var response = Client.Namespaces.ListAll();

            var resourceList = response.Select(resource => new NamespaceAttributes(null, resource));
            return resourceList;
        }

        public NamespaceAttributes CreateNamespace(string resourceGroupName, string namespaceName, string location, Dictionary<string, string> tags)
        {
            var parameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location
            };

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(resourceGroupName, response);
        }

        public NamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, NamespaceState state, bool critical, Dictionary<string, string> tags)
        {
            var parameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location,
                NamespaceType = NamespaceType.NotificationHub,
                Status = ((state == NamespaceState.Disabled) ? state : NamespaceState.Active).ToString(),
                Enabled = (state == NamespaceState.Disabled) ? false : true
            };

            if (critical)
            {
                parameter.Critical = critical;
            }

            if (tags != null && tags.Count() > 0)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(resourceGroupName, response);
        }

        public void DeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.Delete(resourceGroupName, namespaceName);
        }

        public SharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string location, string namespaceName, string authRuleName,
                                List<AccessRights?> rights)
        {
            var parameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Location = location,
                Properties = new SharedAccessAuthorizationRuleProperties()
                {
                    Rights = new List<AccessRights?>(rights)
                }
            };

            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authRuleName, parameter);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }
        
        public void DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
        }

        public ResourceListKeys GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            ResourceListKeys listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return listKeys;
        }

        public ResourceListKeys RegenerateNamespacKeys(string resourceGroupName, string namespaceName, string authRuleName, string policyKeyName)
        {
            ResourceListKeys listKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName,
                new PolicykeyResource()
                {
                    PolicyKey = policyKeyName
                });

            return listKeys;
        }


        #endregion

        #region NotificationHub
        public NotificationHubAttributes GetNotificationHub(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            var response = Client.NotificationHubs.Get(resourceGroupName, namespaceName, notificationHubName);
            return new NotificationHubAttributes(response);
        }

        public NotificationHubAttributes GetNotificationHubPNSCredentials(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            var response = Client.NotificationHubs.GetPnsCredentials(resourceGroupName, namespaceName, notificationHubName);
            return new NotificationHubAttributes(response);
        }

        public IEnumerable<NotificationHubAttributes> ListNotificationHubs(string resourceGroupName, string namespaceName)
        {
            var response = Client.NotificationHubs.List(resourceGroupName, namespaceName);
            IEnumerable<NotificationHubAttributes> resourceList = response.Select(resource => new NotificationHubAttributes(resource));
            return resourceList;
        }

        public NotificationHubAttributes CreateNotificationHub(string resourceGroupName, string namespaceName, NotificationHubAttributes nhAttributes)
        {
            var parameter = new NotificationHubCreateOrUpdateParameters()
            {
                Location = nhAttributes.Location,
                AdmCredential = nhAttributes.AdmCredential,
                ApnsCredential = nhAttributes.ApnsCredential,
                BaiduCredential = nhAttributes.BaiduCredential,
                GcmCredential = nhAttributes.GcmCredential,
                MpnsCredential = nhAttributes.MpnsCredential,
                WnsCredential = nhAttributes.WnsCredential,
                Name = nhAttributes.Name,
                RegistrationTtl = nhAttributes.RegistrationTtl
            };

            if (nhAttributes.Tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(nhAttributes.Tags);
            }
            var response = Client.NotificationHubs.CreateOrUpdate(resourceGroupName, namespaceName, nhAttributes.Name, parameter);
            return new NotificationHubAttributes(response);
        }

        public NotificationHubAttributes UpdateNotificationHub(string resourceGroupName, string namespaceName, NotificationHubAttributes nhAttributes)
        {
            var parameter = new NotificationHubCreateOrUpdateParameters()
            {
                Location = nhAttributes.Location,
                Tags = new Dictionary<string, string>(nhAttributes.Tags),
                AdmCredential = nhAttributes.AdmCredential,
                ApnsCredential = nhAttributes.ApnsCredential,
                BaiduCredential = nhAttributes.BaiduCredential,
                GcmCredential = nhAttributes.GcmCredential,
                MpnsCredential = nhAttributes.MpnsCredential,
                WnsCredential = nhAttributes.WnsCredential,
                Name = nhAttributes.Name,
                RegistrationTtl = nhAttributes.RegistrationTtl
            };

            var response = Client.NotificationHubs.CreateOrUpdate(resourceGroupName, namespaceName, nhAttributes.Name, parameter);
            return new NotificationHubAttributes(response);
        }

        public void DeleteNotificationHub(string resourceGroupName, string namespaceName, string notificationHubName)
        {
            Client.NotificationHubs.Delete(resourceGroupName, namespaceName, notificationHubName);
        }

        public SharedAccessAuthorizationRuleAttributes GetNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            var response = Client.NotificationHubs.GetAuthorizationRule(resourceGroupName, namespaceName,
                                        notificationHubName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName,
                                                    string notificationHubName)
        {
            var response = Client.NotificationHubs.ListAuthorizationRules(resourceGroupName, namespaceName, notificationHubName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNotificationHubAuthorizationRules(string resourceGroupName, string location, string namespaceName,
                                string notificationHubName, string authRuleName,
                                List<AccessRights?> rights)
        {
            var parameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
            {
                Location = location,
                Properties = new SharedAccessAuthorizationRuleProperties()
                {
                    Rights = new List<AccessRights?>(rights),
                }
            };

            var response = Client.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, notificationHubName, authRuleName, parameter);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public void DeleteNotificationHubAuthorizationRules(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            Client.NotificationHubs.DeleteAuthorizationRule(resourceGroupName, namespaceName, notificationHubName, authRuleName);
        }

        public ResourceListKeys GetNotificationHubListKeys(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName)
        {
            ResourceListKeys listKeys = Client.NotificationHubs.ListKeys(resourceGroupName, namespaceName,
                                        notificationHubName, authRuleName);

            return listKeys;
        }

        public ResourceListKeys RegenerateNotificationHubKeys(string resourceGroupName, string namespaceName, string notificationHubName, string authRuleName, string policyKeyName)
        {
            ResourceListKeys listKeys = Client.NotificationHubs.RegenerateKeys(resourceGroupName, namespaceName, notificationHubName, authRuleName,
                new PolicykeyResource()
                {
                    PolicyKey = policyKeyName
                });

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
