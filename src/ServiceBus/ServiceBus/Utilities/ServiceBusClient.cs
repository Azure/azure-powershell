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
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using Newtonsoft.Json;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.ServiceBus
{
    public class ServiceBusClient
    {
         // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
       // private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

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

        public const string SystemAssigned = "SystemAssigned";
        public const string UserAssigned = "UserAssigned";
        public const string SystemAssignedUserAssigned = "SystemAssigned, UserAssigned";
        public const string None = "None";

        #region Namespace
        public PSNamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            SBNamespace response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new PSNamespaceAttributes(response);
        }

        public IEnumerable<PSNamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            IEnumerable<PSNamespaceAttributes> resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<PSNamespaceAttributes> ListAllNamespaces()
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.List();
            var resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }


        public PSNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, Dictionary<string, string> tags, bool isZoneRedundant, bool isDisableLocalAuth, string identityType, 
            string[] identityIds, PSEncryptionConfigAttributes[] encryptionconfigs, int? skuCapacity = null)
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
                parameter.Sku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
                if (parameter.Sku.Name == SkuName.Premium && skuCapacity != null)
                {
                    parameter.Sku.Capacity = skuCapacity;
                }
            }
            if(isDisableLocalAuth)
                parameter.DisableLocalAuth = isDisableLocalAuth;

            if(isZoneRedundant)
                parameter.ZoneRedundant = isZoneRedundant;

            if (identityType != null)
            {
                parameter.Identity = new Identity();
                parameter.Identity.Type = FindIdentity(identityType);
            }

            if (identityIds != null)
            {

                Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();

                UserAssignedIdentities = identityIds.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());

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

            if (encryptionconfigs != null)
            {
                if (parameter.Encryption == null)
                {
                    parameter.Encryption = new Encryption() { KeySource = KeySource.MicrosoftKeyVault };
                }

                parameter.Encryption.KeyVaultProperties = new List<KeyVaultProperties>();

                parameter.Encryption.KeyVaultProperties = encryptionconfigs.Where(x => x != null)
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

            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }


        public PSNamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Hashtable tags, bool? isDisableLocalAuth, string identityType,
            string[] identityIds, PSEncryptionConfigAttributes[] encryptionconfigs)
        {

            var parameter = Client.Namespaces.Get(resourceGroupName, namespaceName);

            if (location != null)
                parameter.Location = location;           

            if (tags != null)
            {
                parameter.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true); ;
            }

            if (skuName != null)
            {
                parameter.Sku = new SBSku();
                parameter.Sku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);
                parameter.Sku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
            }

            if (skuCapacity != null)
            {
                if (parameter.Sku == null)
                {
                    parameter.Sku = new SBSku();
                }
                parameter.Sku.Capacity = skuCapacity;
            }

            if (isDisableLocalAuth != null)
                parameter.DisableLocalAuth = isDisableLocalAuth;

            if (identityType != null)
            {
                if (parameter.Identity == null)
                {
                    parameter.Identity = new Identity();
                }

                parameter.Identity.Type = FindIdentity(identityType);

                /*if (parameter.Identity.Type == ManagedServiceIdentityType.None || parameter.Identity.Type == ManagedServiceIdentityType.SystemAssigned)
                {
                    parameter.Identity.UserAssignedIdentities = null;
                }*/
            }

            if (identityIds != null)
            {
                Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                
                UserAssignedIdentities = identityIds.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());
                
                if (parameter.Identity == null)
                {
                    parameter.Identity = new Identity() { UserAssignedIdentities = UserAssignedIdentities };
                }
                else
                {
                    parameter.Identity.UserAssignedIdentities = UserAssignedIdentities;
                }
                if (identityIds.Length == 0)
                {
                    parameter.Identity.UserAssignedIdentities = null;
                }
                else if (parameter.Identity.Type == ManagedServiceIdentityType.None || parameter.Identity.Type == ManagedServiceIdentityType.SystemAssigned)
                {
                    throw new Exception("Please change -IdentityType to UserAssigned or 'SystemAssigned, UserAssigned' if you want to add User Assigned Identities");
                }
            }

            if (encryptionconfigs != null)
            {
                if (parameter.Encryption == null)
                {
                    parameter.Encryption = new Encryption() { KeySource = KeySource.MicrosoftKeyVault };
                }

                parameter.Encryption.KeyVaultProperties = new List<KeyVaultProperties>();

                parameter.Encryption.KeyVaultProperties = encryptionconfigs.Where(x => x != null)
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


            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
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



        public bool BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.DeleteWithHttpMessagesAsync(resourceGroupName, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            return true;
        }        

        private static void RetryAfter(PSNamespaceLongRunningOperation longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                //longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }
        #endregion

        #region PrivateEndpoints

        public PSServiceBusPrivateEndpointConnectionAttributes UpdatePrivateEndpointConnection(string resourceGroupName, string namespaceName, string privateEndpointName, string connectionState, string description = null)
        {
            var privateEndpointConnection = Client.PrivateEndpointConnections.Get(resourceGroupName, namespaceName, privateEndpointName);

            if (connectionState != null)
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Status = connectionState;
            }

            if (description != null)
            {
                privateEndpointConnection.PrivateLinkServiceConnectionState.Description = description;
            }

            privateEndpointConnection = Client.PrivateEndpointConnections.CreateOrUpdate(resourceGroupName, namespaceName, privateEndpointName, privateEndpointConnection);

            return new PSServiceBusPrivateEndpointConnectionAttributes(privateEndpointConnection);

        }

        public PSServiceBusPrivateEndpointConnectionAttributes GetPrivateEndpointConnection(string resourceGroupName, string namespaceName, string privateEndpointName)
        {

            var privateEndpointConnection = Client.PrivateEndpointConnections.Get(resourceGroupName, namespaceName, privateEndpointName);

            return new PSServiceBusPrivateEndpointConnectionAttributes(privateEndpointConnection);

        }

        public IEnumerable<PSServiceBusPrivateEndpointConnectionAttributes> ListPrivateEndpointConnection(string resourceGroupName, string namespaceName)
        {
            var listOfPrivateEndpoints = new List<PSServiceBusPrivateEndpointConnectionAttributes>();

            string nextPageLink = null;

            do
            {
                var pageOfPrivateEndpoints = new List<PSServiceBusPrivateEndpointConnectionAttributes>();

                if (!String.IsNullOrEmpty(nextPageLink))
                {
                    var result = Client.PrivateEndpointConnections.ListNext(nextPageLink);
                    nextPageLink = result.NextPageLink;
                    pageOfPrivateEndpoints = result.Select(resource => new PSServiceBusPrivateEndpointConnectionAttributes(resource)).ToList();
                }
                else
                {
                    var result = Client.PrivateEndpointConnections.List(resourceGroupName, namespaceName);
                    nextPageLink = result.NextPageLink;
                    pageOfPrivateEndpoints = result.Select(resource => new PSServiceBusPrivateEndpointConnectionAttributes(resource)).ToList();
                }

                listOfPrivateEndpoints.AddRange(pageOfPrivateEndpoints);

            } while (!String.IsNullOrEmpty(nextPageLink));

            return listOfPrivateEndpoints;
        }

        public void DeletePrivateEndpointConnection(string resourceGroupName, string namespaceName, string privateEndpointName)
        {
            Client.PrivateEndpointConnections.Delete(resourceGroupName, namespaceName, privateEndpointName);
        }

        public IEnumerable<PSServiceBusPrivateLinkResourceAttributes> GetPrivateLinkResource(string resourceGroupName, string namespaceName)
        {
            var privateLinks = Client.PrivateLinkResources.Get(resourceGroupName, namespaceName).Value.ToList();

            var resourceList = privateLinks.Select(resource => new PSServiceBusPrivateLinkResourceAttributes(resource));

            return resourceList;
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

            networkRuleSet.PublicNetworkAccess = psNetworkRuleSetAttributes.PublicNetworkAccess;

            if(psNetworkRuleSetAttributes.TrustedServiceAccessEnabled != null)
            {
                networkRuleSet.TrustedServiceAccessEnabled = psNetworkRuleSetAttributes.TrustedServiceAccessEnabled;
            }

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
            
            if(networkRuleSet == null)
            {
                networkRuleSet = new NetworkRuleSet();
            }
            
            if(defaultAction != null)
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

            if(virtualNetworkRule != null)
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

        #region NameSpace AuthorizationRules

        public PSSharedAccessAuthorizationRuleAttributes GetNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);

            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            IEnumerable<PSSharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public PSSharedAccessAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authorizationRuleName, PSSharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
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
        
        #region Queues 

        public PSQueueAttributes CreateUpdateQueue(string resourceGroupName, string namespaceName, string queueName, PSQueueAttributes queue)
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
            if (queue.EnableBatchedOperations.HasValue)
                parameters.EnableBatchedOperations = queue.EnableBatchedOperations;
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
            if (!string.IsNullOrEmpty(queue.ForwardDeadLetteredMessagesTo))
                parameters.ForwardDeadLetteredMessagesTo = queue.ForwardDeadLetteredMessagesTo;
            if (!string.IsNullOrEmpty(queue.ForwardTo))
                parameters.ForwardTo = queue.ForwardTo;

            SBQueue response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new PSQueueAttributes(response);
        }

        public PSQueueAttributes GetQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            SBQueue response = Client.Queues.Get(resourceGroupName, namespaceName, queueName);
            return new PSQueueAttributes(response);
        }

        public PSQueueAttributes UpdateQueue(string resourceGroupName, string namespaceName, string queueName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            SBQueue parameters = new SBQueue(){
                
                EnableExpress = enableExpress
               
            };

            var response = Client.Queues.CreateOrUpdate(resourceGroupName, namespaceName, queueName, parameters);
            return new PSQueueAttributes(response);
        }

        public IEnumerable<PSQueueAttributes> ListQueues(string resourceGroupName, string namespaceName, int? maxCount = null)
        {
           
            IEnumerable<PSQueueAttributes> resourceList = Enumerable.Empty<PSQueueAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {

                case 0:
                    Rest.Azure.IPage<SBQueue> response = Client.Queues.ListByNamespace(resourceGroupName, namespaceName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSQueueAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        Rest.Azure.IPage<SBQueue> response1 = Client.Queues.ListByNamespace(resourceGroupName, namespaceName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSQueueAttributes>(response1.Select(resource => new PSQueueAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    Rest.Azure.IPage<SBQueue> response2 = Client.Queues.ListByNamespace(resourceGroupName, namespaceName);
                    resourceList = response2.Select(resource => new PSQueueAttributes(resource));
                    break;

            }
            return resourceList;
        }

        public bool DeleteQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            Client.Queues.Delete(resourceGroupName, namespaceName, queueName);
            return true;
        }

        public PSSharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authorizationRuleName, PSSharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Queues.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, queueName, authorizationRuleName, parameter1);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public PSSharedAccessAuthorizationRuleAttributes GetServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Queues.GetAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);

            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Queues.ListAuthorizationRules(resourceGroupName, namespaceName,queueName);
            IEnumerable<PSSharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusQueueAuthorizationRules(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            if (string.Equals(PSSharedAccessAuthorizationRuleAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Queues.DeleteAuthorizationRule(resourceGroupName, namespaceName, queueName, authRuleName);
            return true;
        }

        public PSListKeysAttributes GetQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            var listKeys = Client.Queues.ListKeys(resourceGroupName, namespaceName, queueName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSListKeysAttributes NewQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName, string regenerateKeys, string keyValue = null)
        {
            AccessKeys regenerateKeyslistKeys;
            RegenerateAccessKeyParameters regenParam = new RegenerateAccessKeyParameters();

            if (regenerateKeys == "PrimaryKey")
                regenParam.KeyType = KeyType.PrimaryKey;
            else
                regenParam.KeyType = KeyType.SecondaryKey;

            regenParam.Key = keyValue;
            
            regenerateKeyslistKeys = Client.Queues.RegenerateKeys(resourceGroupName, namespaceName, queueName, authRuleName, regenParam);

            return new PSListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Queues
        
        #region Topics 


        public PSTopicAttributes CreateUpdateTopic(string resourceGroupName, string namespaceName, string topicName, PSTopicAttributes topic)
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
            return new PSTopicAttributes(response);
        }

        public PSTopicAttributes GetTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            SBTopic response = Client.Topics.Get(resourceGroupName, namespaceName, topicName);
            return new PSTopicAttributes(response);
        }

        public PSTopicAttributes UpdateTopic(string resourceGroupName, string namespaceName, string topicName, string location, bool enableExpress, bool isAnonymousAccessible)
        {
            SBTopic parameters = new SBTopic()
            {
                EnableExpress = enableExpress
            };

            var response = Client.Topics.CreateOrUpdate(resourceGroupName, namespaceName, topicName, parameters);
            return new PSTopicAttributes(response);
        }

        public IEnumerable<PSTopicAttributes> ListTopics(string resourceGroupName, string namespaceName, int? maxCount = null)
        {
            IEnumerable<PSTopicAttributes> resourceList = Enumerable.Empty<PSTopicAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {

                case 0:
                    Rest.Azure.IPage<SBTopic> response = Client.Topics.ListByNamespace(resourceGroupName, namespaceName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSTopicAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        Rest.Azure.IPage<SBTopic> response1 = Client.Topics.ListByNamespace(resourceGroupName, namespaceName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSTopicAttributes>(response1.Select(resource => new PSTopicAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    Rest.Azure.IPage<SBTopic> response2 = Client.Topics.ListByNamespace(resourceGroupName, namespaceName);
                    resourceList = response2.Select(resource => new PSTopicAttributes(resource));
                    break;

            }
            return resourceList;
        }

        public bool DeleteTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            Client.Topics.Delete(resourceGroupName, namespaceName, topicName);
            return true;
        }

        public PSSharedAccessAuthorizationRuleAttributes CreateOrUpdateServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authorizationRuleName, PSSharedAccessAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new SBAuthorizationRule()
            {
                Rights = parameters.Rights.ToList()
            };
            var response = Client.Topics.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, topicName, authorizationRuleName, parameter1);
            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public PSSharedAccessAuthorizationRuleAttributes GetServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            SBAuthorizationRule response = Client.Topics.GetAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);

            return new PSSharedAccessAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSSharedAccessAuthorizationRuleAttributes> ListServiceBusTopicAuthorizationRules(string resourceGroupName, string namespaceName, string topicName)
        {
            Rest.Azure.IPage<SBAuthorizationRule> response = Client.Topics.ListAuthorizationRules(resourceGroupName, namespaceName, topicName);
            IEnumerable<PSSharedAccessAuthorizationRuleAttributes> resourceList = response.Select(resource => new PSSharedAccessAuthorizationRuleAttributes(resource));

            return resourceList;
        }

        public bool DeleteServiceBusTopicAuthorizationRule(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            if (string.Equals(PSListKeysAttributes.DefaultNamespaceAuthorizationRule, authRuleName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            Client.Topics.DeleteAuthorizationRule(resourceGroupName, namespaceName, topicName, authRuleName);
            return true;
        }

        public PSListKeysAttributes GetTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, topicName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSListKeysAttributes NewTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName, string regenerateKeys, string keyValue=null)
        {
            AccessKeys regenerateKeyslistKeys;
            RegenerateAccessKeyParameters regenParam = new RegenerateAccessKeyParameters();

            if (regenerateKeys == "PrimaryKey")
                regenParam.KeyType = KeyType.PrimaryKey;
            else
                regenParam.KeyType = KeyType.SecondaryKey;

            regenParam.Key = keyValue;

            regenerateKeyslistKeys = Client.Topics.RegenerateKeys(resourceGroupName, namespaceName, topicName, authRuleName, regenParam);

            return new PSListKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion Topics

        #region Subscription

        public PSSubscriptionAttributes CreateUpdateSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, PSSubscriptionAttributes subscription)
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
            if (subscription.DeadLetteringOnFilterEvaluationExceptions.HasValue)
                parameters.DeadLetteringOnFilterEvaluationExceptions = subscription.DeadLetteringOnFilterEvaluationExceptions;
            if (subscription.EnableBatchedOperations.HasValue)
                parameters.EnableBatchedOperations = subscription.EnableBatchedOperations;
            if (subscription.MaxDeliveryCount.HasValue)
                parameters.MaxDeliveryCount = subscription.MaxDeliveryCount;
            if (subscription.RequiresSession.HasValue)
                parameters.RequiresSession = subscription.RequiresSession;
            if (subscription.Status.HasValue)
                parameters.Status = subscription.Status;
            if (!string.IsNullOrEmpty(subscription.ForwardTo))
                parameters.ForwardTo = subscription.ForwardTo;
            if (!string.IsNullOrEmpty(subscription.ForwardDeadLetteredMessagesTo))
                parameters.ForwardDeadLetteredMessagesTo = subscription.ForwardDeadLetteredMessagesTo;
            
            var response = Client.Subscriptions.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, parameters);
            return new PSSubscriptionAttributes(response);
        }

        public PSSubscriptionAttributes GetSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            SBSubscription response = Client.Subscriptions.Get(resourceGroupName, namespaceName, topicName, subscriptionName);
            return new PSSubscriptionAttributes(response);
        }

        public IEnumerable<PSSubscriptionAttributes> ListSubscriptions(string resourceGroupName, string namespaceName, string topicName, int? maxCount = null)
        {
            IEnumerable<PSSubscriptionAttributes> resourceList = Enumerable.Empty<PSSubscriptionAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {

                case 0:
                    Rest.Azure.IPage<SBSubscription> response = Client.Subscriptions.ListByTopic(resourceGroupName, namespaceName, topicName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSSubscriptionAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        Rest.Azure.IPage<SBSubscription> response1 = Client.Subscriptions.ListByTopic(resourceGroupName, namespaceName, topicName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSSubscriptionAttributes>(response1.Select(resource => new PSSubscriptionAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    Rest.Azure.IPage<SBSubscription> response2 = Client.Subscriptions.ListByTopic(resourceGroupName, namespaceName, topicName);
                    resourceList = response2.Select(resource => new PSSubscriptionAttributes(resource));
                    break;

            }
            return resourceList;
        }

        public bool DeleteSubscription(string resourceGroupName, string namespaceName, string topicName, string subscriptionName)
        {
            Client.Subscriptions.Delete(resourceGroupName, namespaceName, topicName, subscriptionName);
            return true;
        }

        #endregion Subscription
        
        #region Rules

        public PSRulesAttributes CreateUpdateRules(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName, PSRulesAttributes ruleAttributes)
        {
            var parameters = new Rule();
            parameters.FilterType = ruleAttributes.FilterType;
            parameters.Action = new Management.ServiceBus.Models.Action()
            {
                SqlExpression = ruleAttributes.Action.SqlExpression,
                CompatibilityLevel = ruleAttributes.Action.CompatibilityLevel,
                RequiresPreprocessing = ruleAttributes.Action.RequiresPreprocessing
            };

            if (ruleAttributes.FilterType.ToString().Equals("SqlFilter"))
                parameters.SqlFilter = new SqlFilter() { RequiresPreprocessing = ruleAttributes.SqlFilter.RequiresPreprocessing, SqlExpression = ruleAttributes.SqlFilter.SqlExpression };
            if (ruleAttributes.FilterType.ToString().Equals("CorrelationFilter"))
            {
                parameters.CorrelationFilter = new CorrelationFilter()
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
                    Properties = ruleAttributes.CorrelationFilter.Properties
                };
            }

            var response = Client.Rules.CreateOrUpdate(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName, parameters);
            return new PSRulesAttributes(response);
        }

        public PSRulesAttributes GetRule(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName)
        {
            Rule response = Client.Rules.Get(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName);
            return new PSRulesAttributes(response);
        }

        public IEnumerable<PSRulesAttributes> ListRules(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, int? maxCount = null)
        {
            IEnumerable<PSRulesAttributes> resourceList = Enumerable.Empty<PSRulesAttributes>();
            int? skip = 0;
            switch (ReturnmaxCountvalueForSwtich(maxCount))
            {
                case 0:
                    Rest.Azure.IPage<Rule> response = Client.Rules.ListBySubscriptions(resourceGroupName, namespaceName, topicName, subscriptionName, skip: 0, top: maxCount);
                    resourceList = response.Select(resource => new PSRulesAttributes(resource));
                    break;
                case 1:
                    while (maxCount > 0)
                    {
                        Rest.Azure.IPage<Rule> response1 = Client.Rules.ListBySubscriptions(resourceGroupName, namespaceName, topicName, subscriptionName, skip: skip, top: maxCount);
                        resourceList = resourceList.Concat<PSRulesAttributes>(response1.Select(resource => new PSRulesAttributes(resource)));
                        skip += maxCount > 100 ? 100 : maxCount;
                        maxCount = maxCount - 100;
                    }
                    break;
                default:
                    Rest.Azure.IPage<Rule> response2 = Client.Rules.ListBySubscriptions(resourceGroupName, namespaceName, topicName, subscriptionName);
                    resourceList = response2.Select(resource => new PSRulesAttributes(resource));
                    break;
            }
            return resourceList;
        }

        public bool DeleteRule(string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName)
        {
            Client.Rules.Delete(resourceGroupName, namespaceName, topicName, subscriptionName, ruleName);
            return true;

        }

        #endregion Rules

        #region DRConfiguration
        public PSServiceBusDRConfigurationAttributes GetServiceBusDRConfiguration(string resourceGroupName, string namespaceName, string alias)
        {
            var response = Client.DisasterRecoveryConfigs.Get(resourceGroupName, namespaceName, alias);
            return new PSServiceBusDRConfigurationAttributes(response);
        }

        public IEnumerable<PSServiceBusDRConfigurationAttributes> ListAllServiceBusDRConfiguration(string resourceGroupName, string namespaceName)
        {
            var response = Client.DisasterRecoveryConfigs.List(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSServiceBusDRConfigurationAttributes(resource));
            return resourceList;
        }

        public PSServiceBusDRConfigurationAttributes CreateServiceBusDRConfiguration(string resourceGroupName, string namespaceName, string alias, PSServiceBusDRConfigurationAttributes parameter)
        {
            var Parameter1 = new Management.ServiceBus.Models.ArmDisasterRecovery();

            if (!string.IsNullOrEmpty(parameter.PartnerNamespace))
                Parameter1.PartnerNamespace = parameter.PartnerNamespace;

            if (!string.IsNullOrEmpty(parameter.AlternateName))
                Parameter1.AlternateName = parameter.AlternateName;

            var response = Client.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroupName, namespaceName, alias, Parameter1);
            return new PSServiceBusDRConfigurationAttributes(response);
        }

        public bool DeleteServiceBusDRConfiguration(string resourceGroupName, string namespaceName, string alias)
        {
            Client.DisasterRecoveryConfigs.Delete(resourceGroupName, namespaceName, alias);
            TestMockSupport.Delay(5000);
            return true;
        }

        public void SetServiceBusDRConfigurationBreakPairing(string resourceGroupName, string namespaceName, string alias)
        {
            Client.DisasterRecoveryConfigs.BreakPairing(resourceGroupName, namespaceName, alias);
            TestMockSupport.Delay(5000);
        }

        public void SetServiceBusDRConfigurationFailOver(string resourceGroupName, string namespaceName, string alias)
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

        #region MigrationConfiguration
        public PSServiceBusMigrationConfigurationAttributes GetServiceBusMigrationConfiguration(string resourceGroupName, string namespaceName)
        {
            var response = Client.MigrationConfigs.Get(resourceGroupName, namespaceName);
            return new PSServiceBusMigrationConfigurationAttributes(response);
        }

        public PSServiceBusMigrationConfigurationAttributes StartServiceBusMigrationConfiguration(string resourceGroupName, string namespaceName, PSServiceBusMigrationConfigurationAttributes parameter)
        {
            var Parameter1 = new Management.ServiceBus.Models.MigrationConfigProperties();

            if (!string.IsNullOrEmpty(parameter.PostMigrationName))
                Parameter1.PostMigrationName = parameter.PostMigrationName;

            if (!string.IsNullOrEmpty(parameter.TargetNamespace))
                Parameter1.TargetNamespace = parameter.TargetNamespace;

            var response = Client.MigrationConfigs.BeginCreateAndStartMigration(resourceGroupName, namespaceName, Parameter1);
            return new PSServiceBusMigrationConfigurationAttributes(response);
        }

        public bool DeleteServiceBusMigrationConfiguration(string resourceGroupName, string namespaceName)
        {
            Client.MigrationConfigs.Revert(resourceGroupName, namespaceName);
            TestMockSupport.Delay(5000);
            return true;
        }

        public void SetServiceBusCompleteMigrationConfiguration(string resourceGroupName, string namespaceName)
        {
            Client.MigrationConfigs.CompleteMigration(resourceGroupName, namespaceName);
            TestMockSupport.Delay(5000);
        }

        public void SetServiceBusStartMigrationConfiguration(string resourceGroupName, string namespaceName)
        {
            Client.MigrationConfigs.CompleteMigration(resourceGroupName, namespaceName);
            TestMockSupport.Delay(5000);
        }

        public void SetServiceBusRevertMigrationConfiguration(string resourceGroupName, string namespaceName)
        {
            Client.MigrationConfigs.Revert(resourceGroupName, namespaceName);
            TestMockSupport.Delay(5000);
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

        public static int ReturnmaxCountvalueForSwtich(int? maxcount)
        {
            int returnvalue = -1;

            if (maxcount != null && maxcount <= 100)
                returnvalue = 0;
            if (maxcount != null && maxcount > 100)
                returnvalue = 1;

            return returnvalue;
        }
        
        #region Operations
        public IEnumerable<PSOperationAttributes> GetOperations()
        {
            var response = Client.Operations.List();
            var resourceList = response.Select(resource => new PSOperationAttributes(resource));
            return resourceList;
        }

        public PSCheckNameAvailabilityResultAttributes GetCheckNameAvailability(string namespaceName)
        {
            var response = Client.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability(namespaceName));
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        public PSCheckNameAvailabilityResultAttributes GetAliasCheckNameAvailability(string resourceGroup, string namespaceName, string aliasName)
        {
            var response = Client.DisasterRecoveryConfigs.CheckNameAvailabilityMethod(resourceGroup, namespaceName, new CheckNameAvailability(aliasName));
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        #endregion


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

        public static bool CheckErrorforNotfound(ErrorResponseException ex)
        {
            if (ex != null && !string.IsNullOrEmpty(ex.Response.Content))
            {
                ErrorResponseContent errorExtract = new ErrorResponseContent();
                errorExtract = JsonConvert.DeserializeObject<ErrorResponseContent>(ex.Response.Content);
                if (errorExtract.error.message.ToLower().Contains("not found"))
                {
                    return false;
                }
                else
                {
                    new ErrorRecord(ex, ex.Response.Content, ErrorCategory.OpenError, ex);
                    return true;
                }
            }
            else
            {
                Exception emptyEx = new Exception("Response object empty");
                new ErrorRecord(emptyEx, "Response object was empty", ErrorCategory.OpenError, emptyEx);
                return true;
            }
        }

        public static ErrorRecord WriteErrorVirtualNetworkExists(string caller = "Add")
        {
            if (caller.Equals("Add"))
            {
                Exception emptyEx = new Exception("VirtualNetwork already exists");
                return new ErrorRecord(emptyEx, "VirtualNetwork already exists", ErrorCategory.OpenError, emptyEx);
            }
            else
            {
                Exception emptyEx = new Exception("VirtualNetwork dosen't exists");
                return new ErrorRecord(emptyEx, "VirtualNetwork dosen't exists", ErrorCategory.OpenError, emptyEx);
            }
        }

        public static ErrorRecord WriteErrorIPRuleExists(string caller = "Add")
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
