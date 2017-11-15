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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Servicebus
{
    public class ServiceBusClient
    {
        // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
      //  private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public ServiceBusClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<ServiceBusManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public ServiceBusManagementClient Client
        {
            get;
            private set;
        }

        #region Namespace
        public NamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            SBNamespace response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new NamespaceAttributes(response);
        }

        public IEnumerable<NamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            IEnumerable<NamespaceAttributes> resourceList = response.Select(resource => new NamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<NamespaceAttributes> ListAllNamespaces()
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.List();
            var resourceList = response.Select(resource => new NamespaceAttributes(resource));
            return resourceList;
        }


        public NamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, Dictionary<string, string> tags)
        {
            SBNamespace parameter = new SBNamespace();
            parameter.Location = location;

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            if (skuName != null)
            {
                parameter.Sku = new SBSku();                
                parameter.Sku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);              

            }

            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(response);
        }


        public NamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Dictionary<string, string> tags)
        {

            var parameter = new SBNamespace()
            {
                Location = location
            };

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            SBSku tempSku = new SBSku();



            if (skuName != null)
            {
                tempSku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);
                tempSku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
            }

            if (skuCapacity != null)
            {
                tempSku.Capacity = skuCapacity;
            }

            parameter.Sku = tempSku;

            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new NamespaceAttributes(response);
        }

        public void BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.Delete(resourceGroupName, namespaceName);

        }        

        private static void RetryAfter(NamespaceLongRunningOperation longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                //longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }
        #endregion

        #region NameSpace AuthorizationRules

        public SharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public bool DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return true;
        }

        public ListKeysAttributes GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return new ListKeysAttributes(listKeys);
        }

        public ListKeysAttributes SetRegenerateKeys(string resourceGroupName, string namespaceName, string authRuleName, string regenerateKeys)
        {
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
            else
                regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));

            return new ListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion 


        #region Queues 

        public QueueAttributes CreateUpdateQueue(string resourceGroupName, string namespaceName, string queueName, QueueAttributes queue)
        {
            SBQueue parameters = new SBQueue();

            if(queue.LockDuration != null)
                parameters.LockDuration = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(queue.LockDuration);
            if (queue.AutoDeleteOnIdle != null)
                parameters.AutoDeleteOnIdle = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(queue.AutoDeleteOnIdle);
            if (queue.DefaultMessageTimeToLive != null)
                parameters.DefaultMessageTimeToLive = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(queue.DefaultMessageTimeToLive);
            if (queue.DuplicateDetectionHistoryTimeWindow != null)
                parameters.DuplicateDetectionHistoryTimeWindow = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(queue.DuplicateDetectionHistoryTimeWindow);
            if (queue.DeadLetteringOnMessageExpiration.HasValue)
                parameters.DeadLetteringOnMessageExpiration = queue.DeadLetteringOnMessageExpiration;
            if (queue.EnableExpress.HasValue)
                parameters.EnableExpress = queue.EnableExpress;
            if (queue.EnablePartitioning.HasValue)
                parameters.EnablePartitioning = queue.EnablePartitioning;
            if (queue.MaxDeliveryCount.HasValue)
                parameters.MaxDeliveryCount = queue.MaxDeliveryCount;
            if (queue.MaxSizeInMegabytes.HasValue)
                parameters.MaxSizeInMegabytes = queue.MaxSizeInMegabytes;
            if (queue.RequiresDuplicateDetection.HasValue)
                parameters.RequiresDuplicateDetection = queue.RequiresDuplicateDetection;
            if (queue.RequiresSession.HasValue)
                parameters.RequiresSession = queue.RequiresSession;
            if (queue.Status.HasValue)
                parameters.Status = queue.Status;
        
            SBQueue response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new QueueAttributes(response);
        }

        public QueueAttributes GetQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            SBQueue response = Client.Queues.Get(resourceGroupName, namespaceName, queueName);
            return new QueueAttributes(response);
        }

        public QueueAttributes UpdateQueue(string resourceGroupName, string namespaceName, string queueName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            SBQueue parameters = new SBQueue(){
                
                EnableExpress = enableExpress
               
            };

            var response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new QueueAttributes(response);
        }

        public IEnumerable<QueueAttributes> ListQueues(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<SBQueue> response = Client.Queues.ListByNamespace(resourceGroupName, namespaceName);
            IEnumerable<QueueAttributes> resourceList = response.Select(resource => new QueueAttributes(resource));
            return resourceList;
        }

        public bool DeleteQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            Client.Queues.Delete(resourceGroupName, namespaceName, queueName);
            return true;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Queues.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, queueName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public SharedAccessAuthorizationRuleAttributes GetServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Queues.GetAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Queues.ListAuthorizationRules(resourceGroupName, namespaceName,queueName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            if (string.Equals(SharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Queues.DeleteAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);
            return true;
        }

        public ListKeysAttributes GetQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            var listKeys = Client.Queues.ListKeys(resourceGroupName, namespaceName, queueName, authRuleName);
            return new ListKeysAttributes(listKeys);
        }

        public ListKeysAttributes NewQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName, string regenerateKeys)
        {
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Queues.RegenerateKeys(resourceGroupName, namespaceName, queueName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
            else
                regenerateKeyslistKeys = Client.Queues.RegenerateKeys(resourceGroupName, namespaceName, queueName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));

            return new ListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Queues


        #region Topics 


        public TopicAttributes CreateUpdateTopic(string resourceGroupName, string namespaceName, string topicName, TopicAttributes topic)
        {
            var parameters = new SBTopic();

            if (topic.AutoDeleteOnIdle != null)
                parameters.AutoDeleteOnIdle = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(topic.AutoDeleteOnIdle);
            if (topic.DefaultMessageTimeToLive != null)
                parameters.DefaultMessageTimeToLive = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(topic.DefaultMessageTimeToLive);
            if (topic.DuplicateDetectionHistoryTimeWindow != null)
                parameters.DuplicateDetectionHistoryTimeWindow = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(topic.DuplicateDetectionHistoryTimeWindow);
            if (topic.EnableBatchedOperations != null)
                parameters.EnableBatchedOperations = topic.EnableBatchedOperations;
            if (topic.EnableExpress != null)
                parameters.EnableExpress = topic.EnableExpress;
            if (topic.EnablePartitioning != null)
                parameters.EnablePartitioning = topic.EnablePartitioning;
            if (topic.MaxSizeInMegabytes != null)
                parameters.MaxSizeInMegabytes = topic.MaxSizeInMegabytes;
            if (topic.RequiresDuplicateDetection != null)
                parameters.RequiresDuplicateDetection = topic.RequiresDuplicateDetection;
            if (topic.Status != null)
                parameters.Status = topic.Status;
            if (topic.SupportOrdering != null)
                parameters.SupportOrdering = topic.SupportOrdering;

            var response = Client.Topics.CreateOrUpdate(resourceGroupName, namespaceName, topicName, parameters);
            return new TopicAttributes(response);
        }

        public TopicAttributes GetTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            SBTopic response = Client.Topics.Get(resourceGroupName, namespaceName, topicName);
            return new TopicAttributes(response);
        }

        public TopicAttributes UpdateTopic(string resourceGroupName, string namespaceName, string topicName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            SBTopic parameters = new SBTopic()
            {
                EnableExpress = enableExpress
            };

            var response = Client.Topics.CreateOrUpdate(resourceGroupName, namespaceName, topicName, parameters);
            return new TopicAttributes(response);
        }

        public IEnumerable<TopicAttributes> ListTopics(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<SBTopic> response = Client.Topics.ListByNamespace(resourceGroupName, namespaceName);
            IEnumerable<TopicAttributes> resourceList = response.Select(resource => new TopicAttributes(resource));
            return resourceList;
        }

        public bool DeleteTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            Client.Topics.Delete(resourceGroupName, namespaceName, topicName);
            return true;
        }

        public SharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authorizationRuleName, SharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Topics.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, topicName, authorizationRuleName, parameter1);
            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public SharedAccessAuthorizationRuleAttributes GetServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Topics.GetAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);

            return new SharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<SharedAccessAuthorizationRuleAttributes> ListServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Topics.ListAuthorizationRules(resourceGroupName, namespaceName, topicName);
            IEnumerable<SharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new SharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusTopicAuthorizationRule(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            if (string.Equals(ListKeysAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Topics.DeleteAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);
            return true;
        }

        public ListKeysAttributes GetTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, topicName, authRuleName);
            return new ListKeysAttributes(listKeys);
        }

        public ListKeysAttributes NewTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName, string regenerateKeys)
        {           
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Topics.RegenerateKeys(resourceGroupName, namespaceName, topicName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
            else
                regenerateKeyslistKeys = Client.Topics.RegenerateKeys(resourceGroupName, namespaceName, topicName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));

            return new ListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Topics

        #region Subscription

        public SubscriptionAttributes CreateUpdateSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, SubscriptionAttributes subscription)
        {
            var parameters = new SBSubscription();

            if (subscription.AutoDeleteOnIdle != null)
                parameters.AutoDeleteOnIdle = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(subscription.AutoDeleteOnIdle);
            if (subscription.DefaultMessageTimeToLive != null)
                parameters.DefaultMessageTimeToLive = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(subscription.DefaultMessageTimeToLive);
            if (subscription.LockDuration != null)
                parameters.LockDuration = (TimeSpan?)AzureServiceBusCmdletBase.ParseTimespan(subscription.LockDuration);
            if (subscription.DeadLetteringOnMessageExpiration.HasValue)
                parameters.DeadLetteringOnMessageExpiration = subscription.DeadLetteringOnMessageExpiration;
            if (subscription.EnableBatchedOperations.HasValue)
                parameters.EnableBatchedOperations = subscription.EnableBatchedOperations;
            if (subscription.MaxDeliveryCount.HasValue)
                parameters.MaxDeliveryCount = subscription.MaxDeliveryCount;
            if (subscription.RequiresSession.HasValue)
                parameters.RequiresSession = subscription.RequiresSession;
            if (subscription.Status.HasValue)
                parameters.Status = subscription.Status;
            

            var response = Client.Subscriptions.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, parameters);
            return new SubscriptionAttributes(response);
        }

        public SubscriptionAttributes GetSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            SBSubscription response = Client.Subscriptions.Get(resourceGroupName, namespaceName, topicName, subscriptionName);
            return new SubscriptionAttributes(response);
        }
        
        public IEnumerable<SubscriptionAttributes> ListSubscriptions(string resourceGroupName, string namespaceName, string topicName)
        {
            Rest.Azure.IPage<SBSubscription> response = Client.Subscriptions.ListByTopic(resourceGroupName, namespaceName,topicName);
            IEnumerable<SubscriptionAttributes> resourceList = response.Select(resource => new SubscriptionAttributes(resource));
            return resourceList;
        }

        public bool DeleteSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            Client.Subscriptions.Delete(resourceGroupName, namespaceName, topicName, subscriptionName);
            return true;
        }

        #endregion Subscription



        #region Rules

        public RulesAttributes CreateUpdateRules(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName, RulesAttributes ruleAttributes)
        {
            var parameters = new Rule()
            {
                Action = new Management.ServiceBus.Models.Action(),
                SqlFilter = new SqlFilter() { RequiresPreprocessing = ruleAttributes.SqlFilter.RequiresPreprocessing, SqlExpression = ruleAttributes.SqlFilter.SqlExpression },
                CorrelationFilter = new CorrelationFilter()
                {
                    CorrelationId = ruleAttributes.CorrelationFilter.CorrelationId,
                    MessageId = ruleAttributes.CorrelationFilter.MessageId,
                    To = ruleAttributes.CorrelationFilter.To,
                    ReplyTo = ruleAttributes.CorrelationFilter.ReplyTo,
                    Label = ruleAttributes.CorrelationFilter.Label,
                    SessionId = ruleAttributes.CorrelationFilter.SessionId,
                    ReplyToSessionId = ruleAttributes.CorrelationFilter.ReplyToSessionId,
                    ContentType = ruleAttributes.CorrelationFilter.ContentType,
                    RequiresPreprocessing = ruleAttributes.CorrelationFilter.RequiresPreprocessing,
                }            
             
            };

            var response = Client.Rules.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName, parameters);
            return new RulesAttributes(response);
        }

        public RulesAttributes GetRule(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName)
        {
            Rule response = Client.Rules.Get(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName);
            return new RulesAttributes(response);
        }

        public IEnumerable<RulesAttributes> ListRules(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            Rest.Azure.IPage<Rule> response = Client.Rules.ListBySubscriptions(resourceGroupName, namespaceName, topicName, subscriptionName);
            IEnumerable<RulesAttributes> resourceList = response.Select(resource => new RulesAttributes(resource));
            return resourceList;
        }

        public bool DeleteRule(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName)
        {
            Client.Rules.Delete(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName);
            return true;

        }

        #endregion Rules

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }


        #region Operations
        public IEnumerable<OperationAttributes> GetOperations()
        {
            var response = Client.Operations.List();
            var resourceList = response.Select(resource => new OperationAttributes(resource));
            return resourceList;
        }

        public CheckNameAvailabilityResultAttributes GetCheckNameAvailability(string namespaceName)
        {
            var response = Client.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability(namespaceName));
            return new CheckNameAvailabilityResultAttributes(response);
        }

        #endregion
    }
}
