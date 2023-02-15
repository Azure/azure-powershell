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
            var listOfNamespaces = new List<PSNamespaceAttributes>();

            string nextPageLink = null;

            do
            {
                var pageOfNamespaces = new List<PSNamespaceAttributes>();

                if (!String.IsNullOrEmpty(nextPageLink))
                {
                    var result = Client.Namespaces.ListByResourceGroupNext(nextPageLink);
                    nextPageLink = result.NextPageLink;
                    pageOfNamespaces = result.Select(resource => new PSNamespaceAttributes(resource)).ToList();
                }
                else
                {
                    var result = Client.Namespaces.ListByResourceGroup(resourceGroupName);
                    nextPageLink = result.NextPageLink;
                    pageOfNamespaces = result.Select(resource => new PSNamespaceAttributes(resource)).ToList();
                }

                listOfNamespaces.AddRange(pageOfNamespaces);

            } while (!String.IsNullOrEmpty(nextPageLink));

            return listOfNamespaces;
        }

        public IEnumerable<PSNamespaceAttributes> ListNamespacesBySubscription()
        {
            var listOfNamespaces = new List<PSNamespaceAttributes>();

            string nextPageLink = null;

            do
            {
                var pageOfNamespaces = new List<PSNamespaceAttributes>();

                if (!String.IsNullOrEmpty(nextPageLink))
                {
                    var result = Client.Namespaces.ListNext(nextPageLink);
                    nextPageLink = result.NextPageLink;
                    pageOfNamespaces = result.Select(resource => new PSNamespaceAttributes(resource)).ToList();
                }
                else
                {
                    var result = Client.Namespaces.List();
                    nextPageLink = result.NextPageLink;
                    pageOfNamespaces = result.Select(resource => new PSNamespaceAttributes(resource)).ToList();
                }

                listOfNamespaces.AddRange(pageOfNamespaces);

            } while (!String.IsNullOrEmpty(nextPageLink));

            return listOfNamespaces;
        }

        public PSNamespaceAttributes SendNamespaceCreateOrUpdateRequest(string resourceGroupName, string namespaceName, EHNamespace namespacePayload)
        {
            EHNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, namespacePayload);
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

        public Dictionary<string, UserAssignedIdentity> MapIdentityId(string[] IdentityId)
        {
            Dictionary<string, UserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();

            UserAssignedIdentities = IdentityId.Where(id => id != null).ToDictionary(id => id, id => new UserAssignedIdentity());

            return UserAssignedIdentities;
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

        public void InvalidArgumentException(string message)
        {
            throw new PSArgumentException(message);
        }

        public EHNamespace GetEventHubNamespace(string resourceGroupName, string namespaceName)
        {
            return Client.Namespaces.Get(resourceGroupName, namespaceName);
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

        public PSListKeysAttributes SetRegenerateKeys(string resourceGroupName, string namespaceName, string authRuleName, string regenerateKeys, string keyValue = null)
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

        #endregion

        public PSListKeysAttributes GetEventHubListKeys(string resourceGroupName, string namespaceName, string eventHubName, string authRuleName)
        {
            var listKeys = Client.EventHubs.ListKeys(resourceGroupName, namespaceName, eventHubName, authRuleName);
            return new PSListKeysAttributes(listKeys);
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
