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

        public SBNamespace GetServiceBusNamespace(string resourceGroupName, string namespaceName)
        {
            return Client.Namespaces.Get(resourceGroupName, namespaceName);
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
                //parameter.Sku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);
                //parameter.Sku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
                parameter.Sku.Name = skuName;
                parameter.Sku.Tier = skuName;
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
                //parameter.Identity.Type = FindIdentity(identityType);
                parameter.Identity.Type = identityType;
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


        public PSNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, SBNamespace namespacePayload )
        {
            SBNamespace response =  Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, namespacePayload);
            return new PSNamespaceAttributes(response);
        }




        public List<KeyVaultProperties> MapEncryptionConfig(PSEncryptionConfigAttributes[] EncryptionConfig)
        {

            return EncryptionConfig?.Where(x => x != null)
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

        public Dictionary<string, UserAssignedIdentity> MapIdentityId(string[] IdentityId)
        {
            Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();

            UserAssignedIdentities = IdentityId.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());

            return UserAssignedIdentities;
        }

        public PSQueueAttributes GetQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            SBQueue response = Client.Queues.Get(resourceGroupName, namespaceName, queueName);
            return new PSQueueAttributes(response);
        }

        public PSListKeysAttributes GetQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            var listKeys = Client.Queues.ListKeys(resourceGroupName, namespaceName, queueName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSTopicAttributes GetTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            SBTopic response = Client.Topics.Get(resourceGroupName, namespaceName, topicName);
            return new PSTopicAttributes(response);
        }

        public PSListKeysAttributes GetTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, topicName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public void InvalidArgumentException(string message)
        {
            throw new PSArgumentException(message);
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
                //parameter.Sku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);
                //parameter.Sku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
                parameter.Sku.Name = skuName;
                parameter.Sku.Tier = skuName;
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

                //parameter.Identity.Type = FindIdentity(identityType);
                parameter.Identity.Type = identityType;

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

        //public ManagedServiceIdentityType FindIdentity(string identityType)
        //{
        //    ManagedServiceIdentityType Type = ManagedServiceIdentityType.None;
        //    if (identityType == SystemAssigned)
        //        Type = ManagedServiceIdentityType.SystemAssigned;

        //    else if (identityType == UserAssigned)
        //        Type = ManagedServiceIdentityType.UserAssigned;

        //    else if (identityType == SystemAssignedUserAssigned)
        //        Type = ManagedServiceIdentityType.SystemAssignedUserAssigned;

        //    else if (identityType == None)
        //        Type = ManagedServiceIdentityType.None;

        //    return Type;
        //}

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

        public PSListKeysAttributes GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return new PSListKeysAttributes(listKeys);
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
