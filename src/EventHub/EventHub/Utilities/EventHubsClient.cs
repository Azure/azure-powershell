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
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

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

        public const string SystemAssigned = "SystemAssigned";
        public const string UserAssigned = "UserAssigned";
        public const string SystemAssignedUserAssigned = "SystemAssigned, UserAssigned";
        public const string None = "None";

        public const int maxApplicationGroups = 100;

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

        public PSNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Dictionary<string, string> tags, bool isAutoInflateEnabled, int? maximumThroughputUnits, bool isKafkaEnabled, string clusterARMId, bool isZoneRedundant, bool isDisableLocalAuth
            , string identityType, string[] identityId, PSEncryptionConfigAttributes[] encryptionConfigs)
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

            if (clusterARMId != null)
            {
                parameter.ClusterArmId = clusterARMId;
            }

            if (skuCapacity.HasValue)
            {
                parameter.Sku.Capacity = skuCapacity;
            }

            if (isAutoInflateEnabled)
                parameter.IsAutoInflateEnabled = isAutoInflateEnabled;

            if (maximumThroughputUnits.HasValue)
                parameter.MaximumThroughputUnits = maximumThroughputUnits;

            if (isKafkaEnabled)
                parameter.KafkaEnabled = isKafkaEnabled;

            if (isZoneRedundant)
                parameter.ZoneRedundant = isZoneRedundant;

            if (isDisableLocalAuth)
                parameter.DisableLocalAuth = isDisableLocalAuth;

            if (identityType != null)
            {
                parameter.Identity = new Identity();
                parameter.Identity.Type = FindIdentity(identityType);
            }

            if (identityId != null)
            {

                Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();

                UserAssignedIdentities = identityId.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());

                if (parameter.Identity == null)
                {
                    parameter.Identity = new Identity() { UserAssignedIdentities = UserAssignedIdentities };
                }
                else
                {
                    parameter.Identity.UserAssignedIdentities = UserAssignedIdentities;
                }
                if (parameter.Identity.Type == ManagedServiceIdentityType.None || parameter.Identity.Type == ManagedServiceIdentityType.SystemAssigned)
                {
                    throw new Exception("Please change -IdentityType to 'UserAssigned' or 'SystemAssigned, UserAssigned' if you want to add User Assigned Identities");
                }
            }

            if (encryptionConfigs != null)
            {
                if (parameter.Encryption == null)
                {
                    parameter.Encryption = new Encryption() { KeySource = KeySource.MicrosoftKeyVault };
                }

                parameter.Encryption.KeyVaultProperties = new List<KeyVaultProperties>();

                parameter.Encryption.KeyVaultProperties = encryptionConfigs.Where(x => x != null)
                                                                     .Select(x => {
                                                                         KeyVaultProperties kvp = new KeyVaultProperties();

                                                                         if (x.KeyName == null || x.KeyVaultUri == null)
                                                                             throw new Exception("KeyName and KeyVaultUri cannot be null");

                                                                         kvp.KeyName = x.KeyName;

                                                                         kvp.KeyVaultUri = x.KeyVaultUri;

                                                                         kvp.KeyVersion = x?.KeyVersion;

                                                                         if (x.UserAssignedIdentity != null)
                                                                             kvp.Identity = new UserAssignedIdentityProperties(x.UserAssignedIdentity);

                                                                         return kvp;
                                                                     })
                                                                     .ToList();
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }

        // Update Namespace (ResourceGroupName, Name, Location, SkuName, SkuCapacity, tagDictionary, EnableAutoInflate.IsPresent, MaximumThroughputUnits, EnableKafka.IsPresent, ZoneRedundant.IsPresent, Identity.IsPresent, IdentityUserDefined, KeySource, KeyProperties));                    
        public PSNamespaceAttributes BeginUpdateNamespace(string resourceGroupName,
            string namespaceName,
            string location,
            string skuName,
            int? skuCapacity,
            Dictionary<string, string> tags,
            bool isAutoInflateEnabled,
            int? maximumThroughputUnits,
            bool isKafkaEnabled, bool isDisableLocalAuth, 
            string[] identityId, string identityType, PSEncryptionConfigAttributes[] encryptionConfigs)
        {          

            EHNamespace parameter = Client.Namespaces.Get(resourceGroupName, namespaceName);

            if(location != null)
            {
                parameter.Location = location;
            }

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

            if (isAutoInflateEnabled)
                parameter.IsAutoInflateEnabled = isAutoInflateEnabled;

            if (maximumThroughputUnits.HasValue)
                parameter.MaximumThroughputUnits = maximumThroughputUnits;

            if (isKafkaEnabled)
                parameter.KafkaEnabled = isKafkaEnabled;

            if (isDisableLocalAuth)
                parameter.DisableLocalAuth = isDisableLocalAuth;

            if (identityType != null)
            {
                if(parameter.Identity == null)
                {
                    parameter.Identity = new Identity();
                }

                parameter.Identity.Type = FindIdentity(identityType);

                /*if(parameter.Identity.Type == ManagedServiceIdentityType.None || parameter.Identity.Type == ManagedServiceIdentityType.SystemAssigned)
                {
                    parameter.Identity.UserAssignedIdentities = null;
                }*/
            }

            if (identityId != null)
            {
                Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();

                UserAssignedIdentities = identityId.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());

                if (parameter.Identity == null)
                {
                    parameter.Identity = new Identity() { UserAssignedIdentities = UserAssignedIdentities };
                }
                else
                {
                    parameter.Identity.UserAssignedIdentities = UserAssignedIdentities;
                }

                if (identityId.Length == 0)
                {
                    parameter.Identity.UserAssignedIdentities = null;
                }
                else if (parameter.Identity.Type == ManagedServiceIdentityType.None || parameter.Identity.Type == ManagedServiceIdentityType.SystemAssigned)
                {
                    throw new Exception("Please change -IdentityType to UserAssigned or 'SystemAssigned, UserAssigned' if you want to add User Assigned Identities");
                }
            }

            if (encryptionConfigs != null)
            {
                if (parameter.Encryption == null)
                {
                    parameter.Encryption = new Encryption() { KeySource = KeySource.MicrosoftKeyVault };
                }

                parameter.Encryption.KeyVaultProperties = new List<KeyVaultProperties>();

                parameter.Encryption.KeyVaultProperties = encryptionConfigs.Where(x => x != null)
                                                                     .Select(x =>
                                                                     {
                                                                         KeyVaultProperties kvp = new KeyVaultProperties();

                                                                         if (x.KeyName == null || x.KeyVaultUri == null)
                                                                             throw new Exception("KeyName and KeyVaultUri cannot be null");

                                                                         kvp.KeyName = x.KeyName;

                                                                         kvp.KeyVaultUri = x.KeyVaultUri;

                                                                         kvp.KeyVersion = x?.KeyVersion;

                                                                         if (x.UserAssignedIdentity != null)
                                                                             kvp.Identity = new UserAssignedIdentityProperties(x.UserAssignedIdentity);

                                                                         return kvp;
                                                                     })
                                                                     .ToList();
            }

            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }

        public ManagedServiceIdentityType FindIdentity(string identityType)
        {
            ManagedServiceIdentityType Type = ManagedServiceIdentityType.None;
            if (identityType == SystemAssigned)
                Type = ManagedServiceIdentityType.SystemAssigned;

            else if (identityType == UserAssigned)
                Type = ManagedServiceIdentityType.UserAssigned;

            else if (identityType == SystemAssignedUserAssigned)
                Type = ManagedServiceIdentityType.SystemAssignedUserAssigned;

            else if (identityType == None)
                Type = ManagedServiceIdentityType.None;

            return Type;
        }


        public void BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.DeleteAsync(resourceGroupName, namespaceName);
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
            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authorizationRuleName, parameter1.Rights);
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

            regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, regenParam.KeyType, regenParam.Key);

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

        public PSEventHubClusterAttributes CreateOrUpdateEventHubCluster(string resourceGroupName, string clusterName, PSEventHubClusterAttributes parameter)
        {
            var parameterCluster = new Management.EventHub.Models.Cluster();

            parameterCluster.Location = parameter.Location;
            parameterCluster.Sku = new ClusterSku();
            parameterCluster.Sku.Capacity = parameter.Sku.Capacity;
            parameterCluster.Tags = parameter.Tags;

            Management.EventHub.Models.Cluster response = Client.Clusters.CreateOrUpdate(resourceGroupName, clusterName, parameterCluster);
            return new PSEventHubClusterAttributes(response);
        }

        public PSEventHubClusterAttributes UpdateEventHubCluster(string resourceGroupName, string clusterName, PSEventHubClusterAttributes parameter)
        {
            var parameterCluster = new Management.EventHub.Models.Cluster();

            parameterCluster.Location = parameter.Location;
            parameterCluster.Sku = new ClusterSku();
            parameterCluster.Sku.Capacity = parameter.Sku.Capacity;
            parameterCluster.Tags = parameter.Tags;

            Management.EventHub.Models.Cluster response = Client.Clusters.Update(resourceGroupName, clusterName, parameterCluster);
            return new PSEventHubClusterAttributes(response);
        }


        public PSEventHubClusterAttributes GetEventHubCluster(string resourceGroupName, string clusterName)
        {
            Management.EventHub.Models.Cluster response = Client.Clusters.Get(resourceGroupName, clusterName);
            return new PSEventHubClusterAttributes(response);
        }

        public IEnumerable<PSEventHubsAvailableCluster> GetEventHubAvailableClusters()
        {
            var regionListResponse = Client.Clusters.ListAvailableClusterRegion();
            IEnumerable<PSEventHubsAvailableCluster> response = regionListResponse.Value.Select(resource => new PSEventHubsAvailableCluster(resource));
            return response;
        }

        public IEnumerable<PSEventHubClusterAttributes> ListEventHubCluster(string resourceGroupName)
        {
            var listResponse = Client.Clusters.ListByResourceGroup(resourceGroupName);
            var resourceList = listResponse.Select(resource => new PSEventHubClusterAttributes(resource));
            return resourceList;
        }

        public bool DeleteEventHubCluster(string resourceGroupName, string clusterName)
        {
            Client.Clusters.Delete(resourceGroupName, clusterName);
            return true;
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

            var response = Client.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, eventHubName, authorizationRuleName, parameter1.Rights);
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

            regenerateKeyslistKeys = Client.EventHubs.RegenerateKeys(resourceGroupName, namespaceName, eventHubName, authRuleName, regenParam.KeyType, regenParam.Key);

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

            var response = Client.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroupName, namespaceName, alias,Parameter1.PartnerNamespace, Parameter1.AlternateName);

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
            var response = Client.ConsumerGroups.CreateOrUpdate(resourceGroupName, namespaceName, eventHubName, consumerGroupName, Parameter1.UserMetadata);
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
            var response = Client.Namespaces.CheckNameAvailability(namespaceName);
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        public PSCheckNameAvailabilityResultAttributes GetAliasCheckNameAvailability(string resourceGroup, string namespaceName, string aliasName)
        {
            var response = Client.DisasterRecoveryConfigs.CheckNameAvailability(resourceGroup,namespaceName, aliasName);
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        #endregion


        #region NetworkRuleSet
        public PSNetworkRuleSetAttributes GetNetworkRuleSet(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.GetNetworkRuleSet(resourceGroupName, namespaceName);
            return new PSNetworkRuleSetAttributes(response);
        }

        public PSNetworkRuleSetAttributes DeleteNetworkRuleSet(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroupName, namespaceName, new NetworkRuleSet() { DefaultAction = "Allow" });
            return new PSNetworkRuleSetAttributes(response);
        }

        public PSNetworkRuleSetAttributes CreateOrUpdateNetworkRuleSet(string resourceGroupName, string namespaceName, PSNetworkRuleSetAttributes psNetworkRuleSetAttributes)
        {
            NetworkRuleSet networkRuleSet = new NetworkRuleSet();
            networkRuleSet.IpRules = new List<NWRuleSetIpRules>();
            networkRuleSet.VirtualNetworkRules = new List<NWRuleSetVirtualNetworkRules>();

            networkRuleSet.DefaultAction = psNetworkRuleSetAttributes.DefaultAction;
            networkRuleSet.TrustedServiceAccessEnabled = psNetworkRuleSetAttributes.TrustedServiceAccessEnabled;
            networkRuleSet.PublicNetworkAccess = psNetworkRuleSetAttributes.PublicNetworkAccess;

            foreach (PSNWRuleSetIpRulesAttributes psiprules in psNetworkRuleSetAttributes.IpRules)
            {
                networkRuleSet.IpRules.Add(new NWRuleSetIpRules { Action = psiprules.Action, IpMask = psiprules.IpMask });
            }

            foreach (PSNWRuleSetVirtualNetworkRulesAttributes psvisrtualnetworkrules in psNetworkRuleSetAttributes.VirtualNetworkRules)
            {
                networkRuleSet.VirtualNetworkRules.Add(new NWRuleSetVirtualNetworkRules { Subnet = new Subnet { Id = psvisrtualnetworkrules.Subnet.Id }, IgnoreMissingVnetServiceEndpoint = psvisrtualnetworkrules.IgnoreMissingVnetServiceEndpoint });
            }

            var response = Client.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroupName, namespaceName, networkRuleSet);
            return new PSNetworkRuleSetAttributes(response);
        }

        public PSNetworkRuleSetAttributes UpdateNetworkRuleSet(string resourceGroupName, string namespaceName, string publicNetworkAccess, bool? trustedServiceAccessEnabled, string defaultAction, PSNWRuleSetIpRulesAttributes[] iPRule, PSNWRuleSetVirtualNetworkRulesAttributes[] virtualNetworkRule)
        {
            NetworkRuleSet networkRuleSet = Client.Namespaces.GetNetworkRuleSet(resourceGroupName, namespaceName);

            if (networkRuleSet == null)
            {
                networkRuleSet = new NetworkRuleSet();
            }

            if (defaultAction != null)
            {
                networkRuleSet.DefaultAction = defaultAction;
            }

            if (publicNetworkAccess != null)
            {
                networkRuleSet.PublicNetworkAccess = publicNetworkAccess;
            }

            if (trustedServiceAccessEnabled != null)
            {
                networkRuleSet.TrustedServiceAccessEnabled = trustedServiceAccessEnabled;
            }

            if (iPRule != null)
            {
                networkRuleSet.IpRules = new List<NWRuleSetIpRules>();

                foreach (PSNWRuleSetIpRulesAttributes psiprules in iPRule)
                {
                    networkRuleSet.IpRules.Add(new NWRuleSetIpRules { Action = psiprules.Action, IpMask = psiprules.IpMask });
                }
            }

            if (virtualNetworkRule != null)
            {
                networkRuleSet.VirtualNetworkRules = new List<NWRuleSetVirtualNetworkRules>();

                foreach (PSNWRuleSetVirtualNetworkRulesAttributes psvisrtualnetworkrules in virtualNetworkRule)
                {
                    networkRuleSet.VirtualNetworkRules.Add(new NWRuleSetVirtualNetworkRules { Subnet = new Subnet { Id = psvisrtualnetworkrules.Subnet.Id }, IgnoreMissingVnetServiceEndpoint = psvisrtualnetworkrules.IgnoreMissingVnetServiceEndpoint });
                }
            }

            var response = Client.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroupName, namespaceName, networkRuleSet);
            return new PSNetworkRuleSetAttributes(response);

        }

        #endregion

        #region SchemaRegistry
        public IEnumerable<PSEventHubsSchemaRegistryAttributes> ListSchemaGroupByNamespace(string resourceGroupName, string namespaceName)
        {
            var schemaGroups = Client.SchemaRegistry.ListByNamespace(resourceGroupName: resourceGroupName, namespaceName: namespaceName);
            var resourceList = schemaGroups.Select(resource => new PSEventHubsSchemaRegistryAttributes(resource));
            return resourceList;
        }

        public PSEventHubsSchemaRegistryAttributes GetSchemaGroup(string resourceGroupName, string namespaceName, string schemaGroupName)
        {
            var schemaGroup = Client.SchemaRegistry.Get(resourceGroupName: resourceGroupName, namespaceName: namespaceName, schemaGroupName: schemaGroupName);
            return new PSEventHubsSchemaRegistryAttributes(schemaGroup);
        }

        public PSEventHubsSchemaRegistryAttributes BeginCreateNamespaceSchemaGroup(string resourceGroupName, string namespaceName, string schemaGroupName
            , string schemaCompatibility, string schemaType, Hashtable groupProperties)
        {
            SchemaGroup schemaGroup = new SchemaGroup(schemaCompatibility: schemaCompatibility, schemaType: schemaType);
            if (groupProperties != null)
            {
                schemaGroup.GroupProperties = TagsConversionHelper.CreateTagDictionary(groupProperties, validate: true); ;
            }
            var response = Client.SchemaRegistry.CreateOrUpdate(resourceGroupName: resourceGroupName, namespaceName: namespaceName, schemaGroupName: schemaGroupName, parameters: schemaGroup);
            return new PSEventHubsSchemaRegistryAttributes(response);
        }

        public PSEventHubsSchemaRegistryAttributes BeginUpdateNamespaceSchemaGroup(string resourceGroupName, string namespaceName, string schemaGroupName
            , string schemaCompatibility, string schemaType, IDictionary<string, string> groupProperties)
        {
            SchemaGroup parameters = Client.SchemaRegistry.Get(resourceGroupName: resourceGroupName, namespaceName: namespaceName, schemaGroupName: schemaGroupName);

            if (groupProperties != null)
            {
                parameters.GroupProperties = groupProperties;
            }

            if (schemaCompatibility != null)
            {
                parameters.SchemaCompatibility = schemaCompatibility;
            }

            if (schemaType != null)
            {
                parameters.SchemaType = schemaType;
            }

            var response = Client.SchemaRegistry.CreateOrUpdate(resourceGroupName: resourceGroupName, namespaceName: namespaceName, schemaGroupName: schemaGroupName, parameters: parameters);
            return new PSEventHubsSchemaRegistryAttributes(response);
        }

        public bool DeleteNamespaceSchemaGroup(string resourceGroupName, string namespaceName, string schemaGroupName)
        {
            Client.SchemaRegistry.Delete(resourceGroupName: resourceGroupName, namespaceName: namespaceName, schemaGroupName: schemaGroupName);
            return true;
        }


        #endregion

        #region ApplicationGroup

        public PSEventHubApplicationGroupAttributes CreateApplicationGroup(string resourceGroupName, string namespaceName, 
            string appGroupName, string clientAppGroupIdentifier, bool? isEnabled, PSEventHubThrottlingPolicyConfigAttributes[] throttlingPolicy)
        {
            ApplicationGroup appGroup = new ApplicationGroup();

            appGroup.ClientAppGroupIdentifier = clientAppGroupIdentifier;
            
            appGroup.IsEnabled = isEnabled;

            if(throttlingPolicy != null)
            {
                appGroup.Policies = new List<ApplicationGroupPolicy>();

                foreach(var policy in throttlingPolicy)
                {
                    ThrottlingPolicy sdkpolicy = new ThrottlingPolicy()
                    {
                        Name = policy.Name,
                        RateLimitThreshold = policy.RateLimitThreshold,
                        MetricId = policy.MetricId
                    };
                    appGroup.Policies.Add(sdkpolicy);
                }
            }

            var response = Client.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroupName, namespaceName, appGroupName, appGroup);

            return new PSEventHubApplicationGroupAttributes(response);
        }

        public PSEventHubApplicationGroupAttributes UpdateApplicationGroup(string resourceGroupName, string namespaceName,
            string appGroupName, bool? isEnabled, PSEventHubThrottlingPolicyConfigAttributes[] throttlingPolicy)
        {
            var appGroup = Client.ApplicationGroup.Get(resourceGroupName, namespaceName, appGroupName);

            if (isEnabled != null)
            {
                appGroup.IsEnabled = isEnabled;
            }

            if (throttlingPolicy != null)
            {
                appGroup.Policies = new List<ApplicationGroupPolicy>();

                foreach (var policy in throttlingPolicy)
                {
                    ThrottlingPolicy sdkpolicy = new ThrottlingPolicy()
                    {
                        Name = policy.Name,
                        RateLimitThreshold = policy.RateLimitThreshold,
                        MetricId = policy.MetricId
                    };

                    appGroup.Policies.Add(sdkpolicy);
                }
            }

            var response = Client.ApplicationGroup.CreateOrUpdateApplicationGroup(resourceGroupName, namespaceName, appGroupName, appGroup);

            return new PSEventHubApplicationGroupAttributes(response);
        }

        public PSEventHubApplicationGroupAttributes GetApplicationGroup(string resourceGroupName, string namespaceName, 
            string appGroupName)
        {
            var response = Client.ApplicationGroup.Get(resourceGroupName, namespaceName, appGroupName);

            return new PSEventHubApplicationGroupAttributes(response);
        }

        public IEnumerable<PSEventHubApplicationGroupAttributes> ListApplicationGroup(string resourceGroupName, string namespaceName)
        {
            var listOfAppGroups = new List<PSEventHubApplicationGroupAttributes>();

            string nextPageLink = null;

            do
            {
                var fetchAppGroups = new List<PSEventHubApplicationGroupAttributes>();

                if (nextPageLink != null)
                {
                    var result = Client.ApplicationGroup.ListByNamespaceNext(nextPageLink);
                    nextPageLink = result.NextPageLink;
                    fetchAppGroups = result.Select(resource => new PSEventHubApplicationGroupAttributes(resource)).ToList();
                }
                else
                {
                    var result = Client.ApplicationGroup.ListByNamespace(resourceGroupName, namespaceName);
                    nextPageLink = result.NextPageLink;
                    fetchAppGroups = result.Select(resource => new PSEventHubApplicationGroupAttributes(resource)).ToList();
                }
                    
                listOfAppGroups.AddRange(fetchAppGroups);

            } while (nextPageLink != null);
            
            return listOfAppGroups;
        }

        public void DeleteApplicationGroup(string resourceGroupName, string namespaceName, string appGroupName)
        {
            Client.ApplicationGroup.Delete(resourceGroupName, namespaceName, appGroupName);
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

        public static ErrorRecord WriteErrorVirtualNetworkExists(string caller = "Add")
        {
            if (caller.Equals("Add"))
            {
                Exception emptyEx = new Exception("VirtualNetwork already exists");
                return new ErrorRecord(emptyEx, "VirtualNetwork already exists", ErrorCategory.OpenError, emptyEx);
            }
            else {
                Exception emptyEx = new Exception("VirtualNetwork dosen't exists");
                return new ErrorRecord(emptyEx, "VirtualNetwork dosen't exists", ErrorCategory.OpenError, emptyEx);
            }            
        }

        public static ErrorRecord WriteErrorIPRuleExists(string caller = "Add" )
        {
            if (caller.Equals("Add"))
            {
                Exception emptyEx = new Exception("IPRule already exists");
                return new ErrorRecord(emptyEx, "IPRule already exists", ErrorCategory.OpenError, emptyEx);
            }
            else
            {
                Exception emptyEx = new Exception("IPRule dosen't exists");
                return new ErrorRecord(emptyEx, "IPRule dosen't exists", ErrorCategory.OpenError, emptyEx);
            }
        }
    }
}
