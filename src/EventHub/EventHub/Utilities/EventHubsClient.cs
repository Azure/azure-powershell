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
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Management.Automation;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Eventhub
{
    public class EventHubsClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public EventHubsClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<EventHubManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public EventHubManagementClient Client
        {
            get;
            private set;
        }

        #region Namespace
        public PSNamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new PSNamespaceAttributes(response);
        }

        public IEnumerable<PSNamespaceAttributes> ListNamespacesByResourceGroup(string resourceGroupName)
        {
            var response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            var resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<PSNamespaceAttributes> ListNamespacesBySubscription()
        {
            var response = Client.Namespaces.List();
            var resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }

        public PSNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Dictionary<string, string> tags, bool? isAutoInflateEnabled, int? maximumThroughputUnits, bool? isKafkaEnabled)
        {
            EHNamespace parameter = new EHNamespace();
            parameter.Location = location;

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            if (skuName != null)
            {
                parameter.Sku = new Sku
                {
                    Name = skuName,
                    Tier = skuName
                };
            }

            if (skuCapacity.HasValue)
            {
                parameter.Sku.Capacity = skuCapacity;
            }

            if (isAutoInflateEnabled.HasValue)
                parameter.IsAutoInflateEnabled = isAutoInflateEnabled;

            if (maximumThroughputUnits.HasValue)
                parameter.MaximumThroughputUnits = maximumThroughputUnits;

            if (isKafkaEnabled.HasValue)
                parameter.KafkaEnabled = isKafkaEnabled;

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }

        public PSNamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, NamespaceState? state, Dictionary<string, string> tags, bool? isAutoInflateEnabled, int? maximumThroughputUnits)
        {

            var parameter = new EHNamespace()
            {
                Location = location
            };

            Sku tempSku = new Sku();

            if (skuName != null)
            {
                tempSku.Name = skuName;
                tempSku.Tier = skuName;
            }

            if (skuCapacity.HasValue)
            {
                tempSku.Capacity = skuCapacity;
            }

            parameter.Sku = tempSku;

            if (tags != null && tags.Count() > 0)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            if (isAutoInflateEnabled.HasValue)
                parameter.IsAutoInflateEnabled = isAutoInflateEnabled;

            if (maximumThroughputUnits.HasValue)
                parameter.MaximumThroughputUnits = maximumThroughputUnits;

            var response = Client.Namespaces.Update(resourceGroupName, namespaceName, parameter);

            return new PSNamespaceAttributes(response);
        }

        public void BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.Delete(resourceGroupName, namespaceName);
        }

        public PSSharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRule(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));
            return resourceList;
        }

        public PSSharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authorizationRuleName, PSSharedAccessAuthorizationRuleAttributes parameter)
        {
            var parameter1 = new AuthorizationRule()
            {
                Rights = parameter.Rights.ToList()
            };
            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authorizationRuleName, parameter1);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public bool DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            if (string.Equals(PSSharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return true;
        }

        public PSListKeysAttributes GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSListKeysAttributes SetRegenerateKeys(string resourceGroupName, string namespaceName, string authRuleName, string regenerateKeys, string keyValue=null)
        {
            AccessKeys regenerateKeyslistKeys;
            RegenerateAccessKeyParameters regenParam = new RegenerateAccessKeyParameters();

            if (regenerateKeys == "PrimaryKey")
                regenParam.KeyType = KeyType.PrimaryKey;
            else
                regenParam.KeyType = KeyType.SecondaryKey;

            regenParam.Key = keyValue;

            regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, regenParam);

            return new PSListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion

        #region EventHub
        public PSEventHubAttributes GetEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            var response = Client.EventHubs.Get(resourceGroupName, namespaceName, eventHubName);
            return new PSEventHubAttributes(response);
        }

        public IEnumerable<PSEventHubAttributes> ListAllEventHubs(string resourceGroupName, string namespaceName, int? maxCount = null)
        {

            IEnumerable<PSEventHubAttributes> resourceList = Enumerable.Empty<PSEventHubAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {

                case 0:
                    var response = Client.EventHubs.ListByNamespace(resourceGroupName, namespaceName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSEventHubAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        var response1 = Client.EventHubs.ListByNamespace(resourceGroupName, namespaceName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSEventHubAttributes>(response1.Select(resource => new PSEventHubAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    var response2 = Client.EventHubs.ListByNamespace(resourceGroupName, namespaceName);
                    resourceList = response2.Select(resource => new PSEventHubAttributes(resource));
                    break;

            }
            return resourceList;
        }

        public PSEventHubAttributes CreateOrUpdateEventHub(string resourceGroupName, string namespaceName, string eventHubName, PSEventHubAttributes parameter)
        {
            var Parameter1 = new Management.EventHub.Models.Eventhub();

            if (parameter.MessageRetentionInDays.HasValue)
                Parameter1.MessageRetentionInDays = parameter.MessageRetentionInDays;

            if (parameter.PartitionCount.HasValue)
                Parameter1.PartitionCount = parameter.PartitionCount;

            if (parameter.Status.HasValue)
                Parameter1.Status = parameter.Status;

            if (parameter.CaptureDescription != null)
            {
                Parameter1.CaptureDescription = new CaptureDescription();
                Parameter1.CaptureDescription.Destination = new Destination();
                Parameter1.CaptureDescription.Enabled = parameter.CaptureDescription.Enabled;
                Parameter1.CaptureDescription.SkipEmptyArchives = parameter.CaptureDescription.SkipEmptyArchives;
                Parameter1.CaptureDescription.Encoding = (Management.EventHub.Models.EncodingCaptureDescription?)parameter.CaptureDescription.Encoding;
                Parameter1.CaptureDescription.IntervalInSeconds = parameter.CaptureDescription.IntervalInSeconds;
                Parameter1.CaptureDescription.SizeLimitInBytes = parameter.CaptureDescription.SizeLimitInBytes;
                Parameter1.CaptureDescription.Destination.Name = parameter.CaptureDescription.Destination.Name;
                Parameter1.CaptureDescription.Destination.BlobContainer = parameter.CaptureDescription.Destination.BlobContainer;
                Parameter1.CaptureDescription.Destination.ArchiveNameFormat = parameter.CaptureDescription.Destination.ArchiveNameFormat;
                Parameter1.CaptureDescription.Destination.StorageAccountResourceId = parameter.CaptureDescription.Destination.StorageAccountResourceId;
            }

            var response = Client.EventHubs.CreateOrUpdate(resourceGroupName, namespaceName, eventHubName, Parameter1);
            return new PSEventHubAttributes(response);
        }

        public bool DeleteEventHub(string resourceGroupName, string namespaceName, string eventHubName)
        {
            Client.EventHubs.Delete(resourceGroupName, namespaceName, eventHubName);
            return true;
        }

        public PSSharedAccessAuthorizationRuleAttributes GetEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        {
            var response = Client.EventHubs.GetAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authRuleName);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName)
        {
            var response = Client.EventHubs.ListAuthorizationRules(resourceGroupName, namespaceName, eventHubName);
            var resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));
            return resourceList;
        }
                
        public PSSharedAccessAuthorizationRuleAttributes CreateOrUpdateEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, PSSharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new AuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };

            var response = Client.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authorizationRuleName, parameter1);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public bool DeleteEventHubAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        {
            if (string.Equals(PSAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.EventHubs.DeleteAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authRuleName);
            return true;
        }

        public PSListKeysAttributes GetEventHubListKeys(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        {
            var listKeys = Client.EventHubs.ListKeys(resourceGroupName, namespaceName, eventHubName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSListKeysAttributes SetRegenerateKeys(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName, string regenerateKeys, string keyValue = null)
        {

            AccessKeys regenerateKeyslistKeys;
            RegenerateAccessKeyParameters regenParam = new RegenerateAccessKeyParameters();

            if (regenerateKeys == "PrimaryKey")
                regenParam.KeyType = KeyType.PrimaryKey;
            else
                regenParam.KeyType = KeyType.SecondaryKey;

            regenParam.Key = keyValue;

            regenerateKeyslistKeys = Client.EventHubs.RegenerateKeys(resourceGroupName, namespaceName, eventHubName, authRuleName, regenParam);

            return new PSListKeysAttributes(regenerateKeyslistKeys);

        }

        #endregion

        #region DRConfiguration
        public PSEventHubDRConfigurationAttributes GetEventHubDRConfiguration(string resourceGroupName, string namespaceName, string alias)
        {
            var response = Client.DisasterRecoveryConfigs.Get(resourceGroupName, namespaceName, alias);
            return new PSEventHubDRConfigurationAttributes(response);
        }

        public IEnumerable<PSEventHubDRConfigurationAttributes> ListAllEventHubDRConfiguration(string resourceGroupName, string namespaceName)
        {
            var response = Client.DisasterRecoveryConfigs.List(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSEventHubDRConfigurationAttributes(resource));
            return resourceList;
        }

        public PSEventHubDRConfigurationAttributes CreateEventHubDRConfiguration(string resourceGroupName, string namespaceName, string alias, PSEventHubDRConfigurationAttributes parameter)
        {
            var Parameter1 = new Management.EventHub.Models.ArmDisasterRecovery();

            if (!string.IsNullOrEmpty(parameter.PartnerNamespace))
                Parameter1.PartnerNamespace = parameter.PartnerNamespace;

            if (!string.IsNullOrEmpty(parameter.AlternateName))
                Parameter1.AlternateName = parameter.AlternateName;

            var response = Client.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroupName, namespaceName, alias, Parameter1);

            return new PSEventHubDRConfigurationAttributes(response);
        }

        public bool DeleteEventHubDRConfiguration(string resourceGroupName, string namespaceName, string alias)
        {
            Client.DisasterRecoveryConfigs.Delete(resourceGroupName, namespaceName, alias);
            return true;
        }

        public void SetEventHubDRConfigurationBreakPairing(string resourceGroupName, string namespaceName, string alias)
        {
            Client.DisasterRecoveryConfigs.BreakPairing(resourceGroupName, namespaceName, alias);
        }

        public void SetEventHubDRConfigurationFailOver(string resourceGroupName, string namespaceName, string alias)
        {
            Client.DisasterRecoveryConfigs.FailOver(resourceGroupName, namespaceName, alias);
        }

        public PSListKeysAttributes GetAliasListKeys(string resourceGroupName, string namespaceName, string aliasName, string authRuleName)
        {
            var listKeys = Client.DisasterRecoveryConfigs.ListKeys(resourceGroupName, namespaceName, aliasName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSSharedAccessAuthorizationRuleAttributes GetAliasAuthorizationRules(string resourceGroupName, string namespaceName, string aliasName, string authRuleName)
        {
            var response = Client.DisasterRecoveryConfigs.GetAuthorizationRule(resourceGroupName, namespaceName, aliasName, authRuleName);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListAliasAuthorizationRules(string resourceGroupName, string namespaceName, string aliasName)
        {
            var response = Client.DisasterRecoveryConfigs.ListAuthorizationRules(resourceGroupName, namespaceName, aliasName);
            var resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));
            return resourceList;
        }


        #endregion

        #region ConsumerGroup
        public PSConsumerGroupAttributes CreateOrUpdateConsumerGroup(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, PSConsumerGroupAttributes parameter)
        {
            var Parameter1 = new ConsumerGroup()
            {
                UserMetadata = parameter.UserMetadata
            };
            var response = Client.ConsumerGroups.CreateOrUpdate(resourceGroupName, namespaceName, eventHubName, consumerGroupName, Parameter1);
            return new PSConsumerGroupAttributes(response);
        }

        public PSConsumerGroupAttributes GetConsumerGroup(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName)
        {
            var response = Client.ConsumerGroups.Get(resourceGroupName, namespaceName, eventHubName, consumerGroupName);
            return new PSConsumerGroupAttributes(response);
        }

        public IEnumerable<PSConsumerGroupAttributes> ListAllConsumerGroup(string resourceGroupName, string namespaceName, string eventHubName, int? maxCount = null)
        {

            IEnumerable<PSConsumerGroupAttributes> resourceList = Enumerable.Empty<PSConsumerGroupAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {

                case 0:
                    var response = Client.ConsumerGroups.ListByEventHub(resourceGroupName, namespaceName, eventHubName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSConsumerGroupAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        var response1 = Client.ConsumerGroups.ListByEventHub(resourceGroupName, namespaceName, eventHubName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSConsumerGroupAttributes>(response1.Select(resource => new PSConsumerGroupAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    var response2 = Client.ConsumerGroups.ListByEventHub(resourceGroupName, namespaceName, eventHubName);
                    resourceList = response2.Select(resource => new PSConsumerGroupAttributes(resource));
                    break;

            }
            return resourceList;
        }

        public void DeletConsumerGroup(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName)
        {
            try
            {
                Client.ConsumerGroups.Delete(resourceGroupName, namespaceName, eventHubName, consumerGroupName);
            }
            catch (Exception ex)
            {
                string test = ex.Message;
            }

        }


        #endregion ConsumerGroup

        #region CheckNameAvailability
        public PSCheckNameAvailabilityResultAttributes GetCheckNameAvailability(string namespaceName)
        {
            var response = Client.Namespaces.CheckNameAvailability(new CheckNameAvailabilityParameter(namespaceName));
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        public PSCheckNameAvailabilityResultAttributes GetAliasCheckNameAvailability(string resourceGroup, string namespaceName, string aliasName)
        {
            var response = Client.DisasterRecoveryConfigs.CheckNameAvailability(resourceGroup,namespaceName, new CheckNameAvailabilityParameter(aliasName));
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        #endregion

        public static int ReturnmaxCountvalueForSwtich(int? maxcount)
        {
            int returnvalue = -1;

            if (maxcount != null && maxcount <= 100)
                returnvalue = 0;
            if (maxcount != null && maxcount > 100)
                returnvalue = 1;

            return returnvalue;
        }

        public static ErrorRecord WriteErrorforBadrequest(ErrorResponseException ex)
        {
            if (ex != null && !string.IsNullOrEmpty(ex.Response.Content))
            {
                ErrorResponseContent errorExtract = new ErrorResponseContent();
                errorExtract = JsonConvert.DeserializeObject<ErrorResponseContent>(ex.Response.Content);
                if (!string.IsNullOrEmpty(errorExtract.error.message))
                {
                    return new ErrorRecord(ex, errorExtract.error.message, ErrorCategory.OpenError, ex);
                }
                else
                {
                    return new ErrorRecord(ex, ex.Response.Content, ErrorCategory.OpenError, ex);
                }
            }
            else
            {
                Exception emptyEx = new Exception("Response object empty");
                return new ErrorRecord(emptyEx, "Response object was empty", ErrorCategory.OpenError, emptyEx);
            }
        }
    }
}
