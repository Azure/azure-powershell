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
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus.Notifications;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.ServiceBus
{
    using ServiceBusNamespaceDescription = Management.ServiceBus.Models.NamespaceDescription;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Hyak.Common;

    public class ServiceBusClientExtensions
    {
        private string subscriptionId;

        public AzureSubscription Subscription { get; set; }

        public ServiceBusManagementClient ServiceBusClient { get; internal set; }

        public const string NamespaceACSConnectionStringKeyName = "ACSOwnerKey";

        public const string NamespaceSASConnectionStringKeyName = "RootManageSharedAccessKey";

        public const int SleepDuration = 5000;

        private ServiceBusNamespace TryGetNamespace(string name)
        {
            try
            {
                return ServiceBusClient.Namespaces.Get(name).Namespace;
            }
            catch (CloudException)
            {
                // The namespace does not exist.
                return null;
            }
        }

        private ExtendedServiceBusNamespace GetExtendedServiceBusNamespace(string name)
        {
            ServiceBusNamespace sbNamespace = TryGetNamespace(name);

            if (sbNamespace != null &&
                sbNamespace.Status.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                IList<ServiceBusNamespaceDescription> descriptions = ServiceBusClient.Namespaces
                    .GetNamespaceDescription(name)
                    .NamespaceDescriptions;

                return new ExtendedServiceBusNamespace(sbNamespace, descriptions);
            }

            return null;
        }

        private NamespaceManager CreateNamespaceManager(string namespaceName)
        {
            return NamespaceManager.CreateFromConnectionString(GetConnectionString(
                namespaceName,
                NamespaceACSConnectionStringKeyName));
        }

        private ExtendedAuthorizationRule CreateExtendedAuthorizationRule(
            AuthorizationRule rule,
            string namespaceName)
        {
            string connectionString = string.Empty;

            if (IsActiveNamespace(namespaceName))
            {
                connectionString = GetConnectionString(namespaceName, rule.KeyName);
            }

            return new ExtendedAuthorizationRule()
            {
                Rule = rule,
                Name = rule.KeyName,
                Namespace = namespaceName,
                Permission = rule.Rights.ToList(),
                ConnectionString = connectionString
            };
        }

        private bool IsActiveNamespace(string name)
        {
            return ServiceBusClient.Namespaces.Get(name).Namespace.Status
                .Equals("Active", StringComparison.OrdinalIgnoreCase);
        }

        private ExtendedAuthorizationRule CreateExtendedAuthorizationRule(
            AuthorizationRule rule,
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType)
        {
            return new ExtendedAuthorizationRule()
            {
                Rule = rule,
                Name = rule.KeyName,
                Permission = rule.Rights.ToList(),
                ConnectionString = GetConnectionString(namespaceName, entityName, entityType, rule.KeyName),
                Namespace = namespaceName,
                EntityName = entityName,
                EntityType = entityType
            };
        }

        private List<ExtendedAuthorizationRule> FilterAuthorizationRules(AuthorizationRuleFilterOption options)
        {
            List<ExtendedAuthorizationRule> rules = GetAuthorizationRulesToFilter(options);
            List<ExtendedAuthorizationRule> result = new List<ExtendedAuthorizationRule>();

            if (!string.IsNullOrEmpty(options.Name))
            {
                result.Add(rules.FirstOrDefault(r => r.Name.Equals(options.Name,StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                List<ExtendedAuthorizationRule> permissionMatch = new List<ExtendedAuthorizationRule>();
                List<ExtendedAuthorizationRule> ruleTypeMatch = new List<ExtendedAuthorizationRule>();

                if (options.Permission != null && options.Permission.Count > 0)
                {
                    permissionMatch
                    .AddRange(
                    rules.FindAll(r => r.Permission.OrderBy(a => a).SequenceEqual(options.Permission.OrderBy(a => a))));
                }

                if (options.AuthorizationType != null && options.AuthorizationType.Count > 0)
                {
                    ruleTypeMatch.AddRange(
                        rules.FindAll(r => r.Rule.ClaimType.Any(t => options.AuthorizationType.Any(m => m.Equals(t)))));
                }

                result = permissionMatch.Count > 0 ? permissionMatch : rules;
                result = ruleTypeMatch.Count> 0 ? result.Union(ruleTypeMatch).ToList() : result;
            }

            return result == null ? new List<ExtendedAuthorizationRule>() : result;
        }

        private List<ExtendedAuthorizationRule> GetAuthorizationRulesToFilter(AuthorizationRuleFilterOption options)
        {
            if (!string.IsNullOrEmpty(options.EntityName))
            {
                return GetAuthorizationRuleCore(
                    options.Namespace,
                    options.EntityName,
                    options.EntityType,
                    r => true);
            }
            else if (options.EntityTypes != null && options.EntityTypes.Count > 0)
            {
                NamespaceManager namespaceManager = CreateNamespaceManager(options.Namespace);
                List<ExtendedAuthorizationRule> rules = new List<ExtendedAuthorizationRule>();
                options.EntityTypes = options.EntityTypes.Distinct().ToList();
                
                foreach (ServiceBusEntityType type in options.EntityTypes)
                {
                    switch (type)
                    {
                        case ServiceBusEntityType.Queue:
                            rules.AddRange(namespaceManager.GetQueues()
                                .SelectMany(e => e.Authorization
                                    .Select(r => CreateExtendedAuthorizationRule(
                                        r,
                                        options.Namespace,
                                        e.Path,
                                        ServiceBusEntityType.Queue))));
                            break;

                        case ServiceBusEntityType.Topic:
                            rules.AddRange(namespaceManager.GetTopics()
                                .SelectMany(e => e.Authorization
                                    .Select(r => CreateExtendedAuthorizationRule(
                                        r,
                                        options.Namespace,
                                        e.Path,
                                        ServiceBusEntityType.Topic))));
                            break;

                        case ServiceBusEntityType.Relay:
                            rules.AddRange(namespaceManager.GetRelaysAsync().Result
                                .SelectMany(e => e.Authorization
                                    .Select(r => CreateExtendedAuthorizationRule(
                                        r,
                                        options.Namespace,
                                        e.Path,
                                        ServiceBusEntityType.Relay))));
                            break;

                        case ServiceBusEntityType.NotificationHub:
                            rules.AddRange(namespaceManager.GetNotificationHubs()
                                .SelectMany(e => e.Authorization
                                    .Select(r => CreateExtendedAuthorizationRule(
                                        r,
                                        options.Namespace,
                                        e.Path,
                                        ServiceBusEntityType.NotificationHub))));
                            break;

                        default: throw new InvalidOperationException();
                    }
                }

                return rules;
            }
            else
            {
                return ServiceBusClient.Namespaces.ListAuthorizationRules(options.Namespace)
                    .AuthorizationRules
                    .Select(ar => ar.ToSharedAccessAuthorizationRule())
                    .Select(r => CreateExtendedAuthorizationRule(r, options.Namespace))
                    .ToList();
            }
        }

        private List<ExtendedAuthorizationRule> GetAuthorizationRuleCore(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            Predicate<AuthorizationRule> match)
        {
            NamespaceManager namespaceManager = CreateNamespaceManager(namespaceName);
            List<AuthorizationRule> rules = null;

            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    rules = namespaceManager.GetQueue(entityName).Authorization.GetRules(match);
                    break;

                case ServiceBusEntityType.Topic:
                    rules = namespaceManager.GetTopic(entityName).Authorization.GetRules(match);
                    break;

                case ServiceBusEntityType.Relay:
                    rules = namespaceManager.GetRelayAsync(entityName).Result.Authorization.GetRules(match);
                    break;

                case ServiceBusEntityType.NotificationHub:
                    rules = namespaceManager.GetNotificationHub(entityName).Authorization.GetRules(match);
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return rules.Select(r => CreateExtendedAuthorizationRule(
                r,
                namespaceName,
                entityName,
                entityType)).ToList();
        }

        /// <summary>
        /// Parameterless constructs for mocking framework.
        /// </summary>
        public ServiceBusClientExtensions()
        {

        }

        /// <summary>
        /// Creates new instance from ServiceBusClientExtensions
        /// </summary>
        /// <param name="subscription"></param>
        public ServiceBusClientExtensions(AzureSMProfile profile)
        {
            if (profile.Context.Subscription == null)
            {
                throw new ArgumentException(Resources.InvalidDefaultSubscription);
            }

            subscriptionId = profile.Context.Subscription.Id.ToString();
            Subscription = profile.Context.Subscription;
            ServiceBusClient = AzureSession.ClientFactory.CreateClient<ServiceBusManagementClient>(profile, profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        /// <summary>
        /// Gets the connection string with the given name.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="keyName">The connection string key name</param>
        /// <returns>The connection string value</returns>
        public virtual string GetConnectionString(string namespaceName, string keyName)
        {
            List<ServiceBusConnectionDetail> connectionStrings = GetConnectionString(namespaceName);
            ServiceBusConnectionDetail connectionString = connectionStrings.Find(c => c.KeyName.Equals(
                keyName,
                StringComparison.OrdinalIgnoreCase));

            return connectionString.ConnectionString;
        }

        /// <summary>
        /// Gets the connection string with the given name for the entity.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="entityType"></param>
        /// <param name="keyName">The connection string key name</param>
        /// <param name="entityName"></param>
        /// <returns>The connection string value</returns>
        public virtual string GetConnectionString(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            string keyName)
        {
            List<ServiceBusConnectionDetail> connectionStrings = GetConnectionString(namespaceName, entityName, entityType);
            ServiceBusConnectionDetail connectionString = connectionStrings.Find(c => c.KeyName.Equals(
                keyName,
                StringComparison.OrdinalIgnoreCase));

            return connectionString.ConnectionString;
        }

        /// <summary>
        /// Gets available connection strings for the specified entity.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="entityName">The entity name</param>
        /// <param name="entityType">The entity type</param>
        /// <returns>List of all available connection strings</returns>
        public virtual List<ServiceBusConnectionDetail> GetConnectionString(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType)
        {
            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    return ServiceBusClient.Queues.GetConnectionDetails(namespaceName, entityName).ConnectionDetails
                        .ToList();

                case ServiceBusEntityType.Topic:
                    return ServiceBusClient.Topics.GetConnectionDetails(namespaceName, entityName).ConnectionDetails
                        .ToList();

                case ServiceBusEntityType.Relay:
                    return ServiceBusClient.Relays.GetConnectionDetails(namespaceName, entityName).ConnectionDetails
                        .ToList();

                case ServiceBusEntityType.NotificationHub:
                    return ServiceBusClient.NotificationHubs.GetConnectionDetails(namespaceName, entityName)
                        .ConnectionDetails
                        .ToList();

                default:
                    throw new Exception(string.Format(Resources.ServiceBusEntityTypeNotFound, entityType.ToString()));
            }
            
        }

        /// <summary>
        /// Gets all the available connection strings for given namespace.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <returns>List of connection strings</returns>
        public virtual List<ServiceBusConnectionDetail> GetConnectionString(string namespaceName)
        {
            return ServiceBusClient.Namespaces.GetNamespaceDescription(namespaceName).NamespaceDescriptions
                .Select(d => d.ToServiceBusConnectionDetail())
                .ToList();

        }

        /// <summary>
        /// Creates shared access signature authorization for the service bus namespace. This authorization works on
        /// public Microsoft Azure environments and Windows Azure Pack on prim as well.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        /// <param name="primaryKey">The SAS primary key. It'll be generated if empty</param>
        /// <param name="secondaryKey">The SAS secondary key</param>
        /// <param name="permissions">Set of permissions given to the rule</param>
        /// <returns>The created Shared Access Signature authorization rule</returns>
        public virtual ExtendedAuthorizationRule CreateSharedAccessAuthorization(
            string namespaceName,
            string ruleName,
            string primaryKey,
            string secondaryKey,
            params AccessRights[] permissions)
        {
            SharedAccessAuthorizationRule rule = new SharedAccessAuthorizationRule(
                ruleName,
                string.IsNullOrEmpty(primaryKey) ? SharedAccessAuthorizationRule.GenerateRandomKey() : primaryKey,
                secondaryKey,
                permissions);

            rule = ServiceBusClient.Namespaces.CreateAuthorizationRule(
                namespaceName,
                rule.ToServiceBusSharedAccessAuthorizationRule())
                .AuthorizationRule.ToSharedAccessAuthorizationRule();
            
            return CreateExtendedAuthorizationRule(rule, namespaceName);
        }

        /// <summary>
        /// Creates shared access signature authorization for the service bus entity. This authorization works on
        /// public Microsoft Azure environments and Windows Azure Pack on prim as well.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="entityName">The fully qualified service bus entity name</param>
        /// <param name="entityType">The service bus entity type (e.g. Queue)</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        /// <param name="primaryKey">The SAS primary key. It'll be generated if empty</param>
        /// <param name="secondaryKey">The SAS secondary key</param>
        /// <param name="permissions">Set of permissions given to the rule</param>
        /// <returns>The created Shared Access Signature authorization rule</returns>
        public virtual ExtendedAuthorizationRule CreateSharedAccessAuthorization(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            string ruleName,
            string primaryKey,
            string secondaryKey,
            params AccessRights[] permissions)
        {
            // Create the SAS authorization rule
            SharedAccessAuthorizationRule rule = new SharedAccessAuthorizationRule(
                ruleName,
                string.IsNullOrEmpty(primaryKey) ? SharedAccessAuthorizationRule.GenerateRandomKey() : primaryKey,
                secondaryKey,
                permissions);

            // Create namespace manager
            NamespaceManager namespaceManager = CreateNamespaceManager(namespaceName);

            // Add the SAS rule and update the entity
            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    QueueDescription queue = namespaceManager.GetQueue(entityName);
                    queue.Authorization.Add(rule);
                    namespaceManager.UpdateQueue(queue);
                    break;

                case ServiceBusEntityType.Topic:
                    TopicDescription topic = namespaceManager.GetTopic(entityName);
                    topic.Authorization.Add(rule);
                    namespaceManager.UpdateTopic(topic);
                    break;

                case ServiceBusEntityType.Relay:
                    RelayDescription relay = namespaceManager.GetRelayAsync(entityName).Result;
                    relay.Authorization.Add(rule);
                    namespaceManager.UpdateRelayAsync(relay).Wait();
                    break;

                case ServiceBusEntityType.NotificationHub:
                    NotificationHubDescription notificationHub = namespaceManager.GetNotificationHub(entityName);
                    notificationHub.Authorization.Add(rule);
                    namespaceManager.UpdateNotificationHub(notificationHub);
                    break;

                default:
                    throw new Exception(string.Format(Resources.ServiceBusEntityTypeNotFound, entityType.ToString()));
            }
            
            return CreateExtendedAuthorizationRule(rule, namespaceName, entityName, entityType);
        }

        /// <summary>
        /// Creates new service bus queue in the given name.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="name">The queue name</param>
        /// <returns>The queue description object</returns>
        public virtual QueueDescription CreateQueue(string namespaceName, string name)
        {
            return CreateNamespaceManager(namespaceName).CreateQueue(name);
        }

        /// <summary>
        /// Creates new service bus topic in the given name.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="name">The topic name</param>
        /// <returns>The topic description object</returns>
        public virtual TopicDescription CreateTopic(string namespaceName, string name)
        {
            return CreateNamespaceManager(namespaceName).CreateTopic(name);
        }

        /// <summary>
        /// Creates new service bus relay in the given name.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="name">The relay name</param>
        /// <param name="type">The relay type</param>
        /// <returns>The relay description object</returns>
        public virtual RelayDescription CreateRelay(string namespaceName, string name, RelayType type)
        {
            return CreateNamespaceManager(namespaceName).CreateRelayAsync(name, type).Result;
        }

        /// <summary>
        /// Creates new service bus notification hub in the given name.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="name">The notification hub name</param>
        /// <returns>The notification hub description object</returns>
        public virtual NotificationHubDescription CreateNotificationHub(string namespaceName, string name)
        {
            NotificationHubDescription description = new NotificationHubDescription(name);
            return CreateNamespaceManager(namespaceName).CreateNotificationHub(description);
        }

        /// <summary>
        /// Updates shared access signature authorization for the service bus namespace. This authorization works on
        /// public Microsoft Azure environments and Windows Azure Pack on prim as well.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        /// <param name="primaryKey">The SAS primary key. It'll be generated if empty</param>
        /// <param name="secondaryKey">The SAS secondary key</param>
        /// <param name="permissions">Set of permissions given to the rule</param>
        /// <returns>The created Shared Access Signature authorization rule</returns>
        public virtual ExtendedAuthorizationRule UpdateSharedAccessAuthorization(
            string namespaceName,
            string ruleName,
            string primaryKey,
            string secondaryKey,
            params AccessRights[] permissions)
        {
            ExtendedAuthorizationRule oldRule = GetAuthorizationRule(namespaceName, ruleName);
            if (null == oldRule)
            {
                throw new ArgumentException(Resources.ServiceBusAuthorizationRuleNotFound);
            }

            SharedAccessAuthorizationRule rule = (SharedAccessAuthorizationRule)oldRule.Rule;

            // Update the rule
            rule.Rights = permissions ?? rule.Rights;
            rule.PrimaryKey = string.IsNullOrEmpty(primaryKey) ? rule.PrimaryKey : primaryKey;
            rule.SecondaryKey = string.IsNullOrEmpty(secondaryKey) ? rule.SecondaryKey : secondaryKey;

            // In case that there's nothing to update then assume user asks for primary key renewal
            if (permissions == null && string.IsNullOrEmpty(secondaryKey) && string.IsNullOrEmpty(primaryKey))
            {
                rule.PrimaryKey = SharedAccessAuthorizationRule.GenerateRandomKey();
            }

            rule = ServiceBusClient.Namespaces.UpdateAuthorizationRule(
                namespaceName,
                rule.ToServiceBusSharedAccessAuthorizationRule())
                .AuthorizationRule.ToSharedAccessAuthorizationRule();

            return CreateExtendedAuthorizationRule(rule, namespaceName);
        }

        /// <summary>
        /// Updates shared access signature authorization for the service bus entity. This authorization works on
        /// public Microsoft Azure environments and Windows Azure Pack on prim as well.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="entityName">The fully qualified service bus entity name</param>
        /// <param name="entityType">The service bus entity type (e.g. Queue)</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        /// <param name="primaryKey">The SAS primary key. It'll be generated if empty</param>
        /// <param name="secondaryKey">The SAS secondary key</param>
        /// <param name="permissions">Set of permissions given to the rule</param>
        /// <returns>The created Shared Access Signature authorization rule</returns>
        public virtual ExtendedAuthorizationRule UpdateSharedAccessAuthorization(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            string ruleName,
            string primaryKey,
            string secondaryKey,
            params AccessRights[] permissions)
        {
            bool removed = false;
            ExtendedAuthorizationRule rule = GetAuthorizationRule( namespaceName, entityName, entityType, ruleName);
            if (null == rule)
            {
                throw new ArgumentException(Resources.ServiceBusAuthorizationRuleNotFound);
            }

            SharedAccessAuthorizationRule oldRule = (SharedAccessAuthorizationRule)rule.Rule;

            SharedAccessAuthorizationRule newRule = new SharedAccessAuthorizationRule(
                ruleName,
                string.IsNullOrEmpty(primaryKey) ? SharedAccessAuthorizationRule.GenerateRandomKey() : primaryKey,
                secondaryKey,
                permissions ?? oldRule.Rights);

            // Create namespace manager
            NamespaceManager namespaceManager = CreateNamespaceManager(namespaceName);

            // Add the SAS rule and update the entity
            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    QueueDescription queue = namespaceManager.GetQueue(entityName);
                    removed = queue.Authorization.Remove(oldRule);
                    Debug.Assert(removed);
                    queue.Authorization.Add(newRule);
                    namespaceManager.UpdateQueue(queue);
                    break;

                case ServiceBusEntityType.Topic:
                    TopicDescription topic = namespaceManager.GetTopic(entityName);
                    removed = topic.Authorization.Remove(oldRule);
                    Debug.Assert(removed);
                    topic.Authorization.Add(newRule);
                    namespaceManager.UpdateTopic(topic);
                    break;

                case ServiceBusEntityType.Relay:
                    RelayDescription relay = namespaceManager.GetRelayAsync(entityName).Result;
                    removed = relay.Authorization.Remove(oldRule);
                    Debug.Assert(removed);
                    relay.Authorization.Add(newRule);
                    namespaceManager.UpdateRelayAsync(relay).Wait();
                    break;

                case ServiceBusEntityType.NotificationHub:
                    NotificationHubDescription notificationHub = namespaceManager.GetNotificationHub(entityName);
                    removed = notificationHub.Authorization.Remove(oldRule);
                    Debug.Assert(removed);
                    notificationHub.Authorization.Add(newRule);
                    namespaceManager.UpdateNotificationHub(notificationHub);
                    break;

                default:
                    throw new Exception(string.Format(Resources.ServiceBusEntityTypeNotFound, entityType.ToString()));
            }

            return CreateExtendedAuthorizationRule(newRule, namespaceName, entityName, entityType);
        }

        /// <summary>
        /// Removes set of authorization rules that matches filter options.
        /// </summary>
        /// <param name="options">The filter options</param>
        public virtual void RemoveAuthorizationRule(AuthorizationRuleFilterOption options)
        {
            List<ExtendedAuthorizationRule> rules = GetAuthorizationRule(options);

            foreach (ExtendedAuthorizationRule rule in rules)
            {
                if (null == rule)
                {
                    throw new ArgumentException(Resources.ServiceBusAuthorizationRuleNotFound);
                }
                else if (!string.IsNullOrEmpty(rule.EntityName))
                {
                    RemoveAuthorizationRule(rule.Namespace, rule.EntityName, rule.EntityType, rule.Name);
                }
                else
                {
                    RemoveAuthorizationRule(rule.Namespace, rule.Name);
                }
            }
        }

        /// <summary>
        /// Removes shared access signature authorization for the service bus namespace.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        public virtual void RemoveAuthorizationRule(string namespaceName, string ruleName)
        {
            ServiceBusClient.Namespaces.DeleteAuthorizationRule(namespaceName, ruleName);
        }

        /// <summary>
        /// Removed shared access signature authorization for the service bus entity.
        /// </summary>
        /// <param name="namespaceName">The service bus namespace name</param>
        /// <param name="entityName">The fully qualified service bus entity name</param>
        /// <param name="entityType">The service bus entity type (e.g. Queue)</param>
        /// <param name="ruleName">The SAS authorization rule name</param>
        public virtual void RemoveAuthorizationRule(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            string ruleName)
        {
            bool removed = false;
            SharedAccessAuthorizationRule rule = (SharedAccessAuthorizationRule)GetAuthorizationRule(
                namespaceName,
                entityName,
                entityType,
                ruleName).Rule;

            // Create namespace manager
            NamespaceManager namespaceManager = CreateNamespaceManager(namespaceName);

            // Add the SAS rule and update the entity
            switch (entityType)
            {
                case ServiceBusEntityType.Queue:
                    QueueDescription queue = namespaceManager.GetQueue(entityName);
                    removed = queue.Authorization.Remove(rule);
                    Debug.Assert(removed);
                    namespaceManager.UpdateQueue(queue);
                    break;

                case ServiceBusEntityType.Topic:
                    TopicDescription topic = namespaceManager.GetTopic(entityName);
                    removed = topic.Authorization.Remove(rule);
                    Debug.Assert(removed);
                    namespaceManager.UpdateTopic(topic);
                    break;

                case ServiceBusEntityType.Relay:
                    RelayDescription relay = namespaceManager.GetRelayAsync(entityName).Result;
                    removed = relay.Authorization.Remove(rule);
                    Debug.Assert(removed);
                    namespaceManager.UpdateRelayAsync(relay).Wait();
                    break;

                case ServiceBusEntityType.NotificationHub:
                    NotificationHubDescription notificationHub = namespaceManager.GetNotificationHub(entityName);
                    removed = notificationHub.Authorization.Remove(rule);
                    Debug.Assert(removed);
                    namespaceManager.UpdateNotificationHub(notificationHub);
                    break;

                default:
                    throw new Exception(string.Format(Resources.ServiceBusEntityTypeNotFound, entityType.ToString()));
            }
        }

        /// <summary>
        /// Gets authorization rules based on the passed filter options.
        /// </summary>
        /// <param name="filterOptions">The filter options</param>
        /// <returns>The filtered authorization rules</returns>
        public List<ExtendedAuthorizationRule> GetAuthorizationRule(AuthorizationRuleFilterOption filterOptions)
        {
            return FilterAuthorizationRules(filterOptions);
        }

        /// <summary>
        /// Gets the authorization rule with the specified name in the namespace level.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="ruleName">The rule name</param>
        /// <returns>The authorization rule that matches the specified name</returns>
        public virtual ExtendedAuthorizationRule GetAuthorizationRule(
            string namespaceName,
            string ruleName)
        {
            AuthorizationRuleFilterOption options = new AuthorizationRuleFilterOption()
            {
                Namespace = namespaceName,
                Name = ruleName
            };

            return FilterAuthorizationRules(options).FirstOrDefault();
        }

        /// <summary>
        /// Gets the authorization rule with the specified name in the entity level.
        /// </summary>
        /// <param name="namespaceName">The namespace name</param>
        /// <param name="entityName">The entity name</param>
        /// <param name="entityType">The entity type</param>
        /// <param name="ruleName">The rule name</param>
        /// <returns>The authorization rule that matches the specified name</returns>
        public virtual ExtendedAuthorizationRule GetAuthorizationRule(
            string namespaceName,
            string entityName,
            ServiceBusEntityType entityType,
            string ruleName)
        {
            AuthorizationRuleFilterOption options = new AuthorizationRuleFilterOption()
            {
                Namespace = namespaceName,
                Name = ruleName,
                EntityName = entityName,
                EntityType = entityType
            };

            return FilterAuthorizationRules(options).FirstOrDefault();
        }

        public virtual List<ServiceBusLocation> GetServiceBusRegions()
        {
            return ServiceBusClient.GetServiceBusRegions().Regions.ToList();
        }

        public virtual ExtendedServiceBusNamespace GetNamespace(string name)
        {
            if (!Regex.IsMatch(name, ServiceBusConstants.NamespaceNamePattern))
            {
                throw new ArgumentException(string.Format(Resources.InvalidNamespaceName, name), "Name");
            }

            return GetExtendedServiceBusNamespace(name);
        }

        public virtual List<ExtendedServiceBusNamespace> GetNamespace()
        {
            return ServiceBusClient.Namespaces.List().Namespaces.
                Select(s => GetExtendedServiceBusNamespace(s.Name))
                .Where(s => s != null)
                .ToList();
        }

        public virtual bool IsAvailableNamespace(string name)
        {
            return ServiceBusClient.Namespaces.CheckAvailability(name).IsAvailable;
        }

        public virtual string GetDefaultLocation()
        {
            return ServiceBusClient.GetServiceBusRegions().Regions.First().Code;
        }

        public virtual bool NamespaceExists(string name)
        {
            return GetNamespace().Exists(ns => ns.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public virtual ExtendedServiceBusNamespace CreateNamespace(string name, string location, NamespaceType type, bool createACSNamespace = false)
        {
            location = string.IsNullOrEmpty(location) ? GetDefaultLocation() : location;

            if (!Regex.IsMatch(name, ServiceBusConstants.NamespaceNamePattern))
            {
                throw new ArgumentException(string.Format(Resources.InvalidNamespaceName, name), "Name");
            }

            ServiceBusClient.Namespaces.CreateNamespace(name, new ServiceBusNamespaceCreateParameters { Region = location, CreateACSNamespace = createACSNamespace, NamespaceType = type});

            // Wait until the namespace is activated
            while (!IsActiveNamespace(name))
            {
                Thread.Sleep(SleepDuration);
            }

            return GetExtendedServiceBusNamespace(name);
        }

        public virtual bool RemoveNamespace(string name)
        {
            ServiceBusClient.Namespaces.Delete(name);

            return true;
        }
    }

    public enum ServiceBusEntityType
    {
        Queue,
        Topic,
        Relay,
        NotificationHub
    }

    public enum AuthorizationType
    {
        SharedAccessAuthorization,
        WindowsAuthorization
    }

    static public class ServiceBusClientExtensionMethods
    {
        static public ServiceBusSharedAccessAuthorizationRule ToServiceBusSharedAccessAuthorizationRule(
            this SharedAccessAuthorizationRule rule)
        {
            List<AccessRight> rights = new List<AccessRight>();

            if (rule.Rights.Contains(AccessRights.Listen))
            {
                rights.Add(AccessRight.Listen);
            }

            if (rule.Rights.Contains(AccessRights.Manage))
            {
                rights.Add(AccessRight.Manage);
            }

            if (rule.Rights.Contains(AccessRights.Send))
            {
                rights.Add(AccessRight.Send);
            }

            return new ServiceBusSharedAccessAuthorizationRule()
            {
                ClaimType = rule.ClaimType,
                ClaimValue = rule.ClaimValue,
                CreatedTime = rule.CreatedTime,
                KeyName = rule.KeyName,
                ModifiedTime = rule.ModifiedTime,
                PrimaryKey = rule.PrimaryKey,
                Revision = (int)rule.Revision,
                Rights = rights,
                SecondaryKey = rule.SecondaryKey
            };
        }

        static public SharedAccessAuthorizationRule ToSharedAccessAuthorizationRule(
            this ServiceBusSharedAccessAuthorizationRule sbRule)
        {
            List<AccessRights> rights = new List<AccessRights>();

            if (sbRule.Rights.Contains(AccessRight.Listen))
            {
                rights.Add(AccessRights.Listen);
            }

            if (sbRule.Rights.Contains(AccessRight.Manage))
            {
                rights.Add(AccessRights.Manage);
            }

            if (sbRule.Rights.Contains(AccessRight.Send))
            {
                rights.Add(AccessRights.Send);
            }

            var sasRule = new SharedAccessAuthorizationRule(sbRule.KeyName, sbRule.PrimaryKey, sbRule.SecondaryKey, rights);
            sasRule.Revision = sbRule.Revision;
            return sasRule;
        }

        static public ServiceBusConnectionDetail ToServiceBusConnectionDetail(this ServiceBusNamespaceDescription namespaceDesc)
        {
            return new ServiceBusConnectionDetail()
            {
                AuthorizationType = namespaceDesc.AuthorizationType,
                ConnectionString = namespaceDesc.ConnectionString,
                KeyName = namespaceDesc.KeyName,
                Rights = namespaceDesc.Rights
            };
        }
    }
}
