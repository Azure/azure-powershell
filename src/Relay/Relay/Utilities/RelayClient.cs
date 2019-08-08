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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Relay.Models;
using Microsoft.Azure.Commands.Relay.Commands;
using Microsoft.Azure.Management.Relay;
using Microsoft.Azure.Management.Relay.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Relay
{
    public class RelayClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public RelayClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<RelayManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public RelayManagementClient Client
        {
            get;
            private set;
        }

        #region Operations
        public IEnumerable<PSOperationAttributes> GetOperations()
        {
            var response = Client.Operations.List();
            var resourceList = response.Select(resource => new PSOperationAttributes(resource));
            return resourceList;
        }

        #endregion


        #region Namespace

        public PSCheckNameAvailabilityResultAttributes GetCheckNameAvailability(string namespaceName)
        {
            var response = Client.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability(namespaceName));
            return new PSCheckNameAvailabilityResultAttributes(response);
        }

        public PSRelayNamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new PSRelayNamespaceAttributes(response);
        }

        public IEnumerable<PSRelayNamespaceAttributes> ListNamespacesByResourceGroup(string resourceGroupName)
        {
            var response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            var resourceList = response.Select(resource => new PSRelayNamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<PSRelayNamespaceAttributes> ListNamespacesBySubscription()
        {
            var response = Client.Namespaces.List();
            var resourceList = response.Select(resource => new PSRelayNamespaceAttributes(resource));
            return resourceList;
        }

        public PSRelayNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, Dictionary<string, string> tags)
        {
            RelayNamespace parameter = new RelayNamespace();
            parameter.Location = location;
            
            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }
            
            var response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSRelayNamespaceAttributes(response);
        }

        public PSRelayNamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, RelayNamespaceAttirbutesUpdateParameter relaynamespace)
        {

            var parameter = new RelayUpdateParameters();
                       

            if (relaynamespace.Tags != null && relaynamespace.Tags.Count() > 0)
            {
                parameter.Tags = new Dictionary<string, string>(relaynamespace.Tags);
            }

            var response = Client.Namespaces.Update(resourceGroupName, namespaceName, parameter);
            return new PSRelayNamespaceAttributes(response);
        }

        public void BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.Delete(resourceGroupName, namespaceName);
        }

        public PSAuthorizationRuleAttributes GetNamespaceAuthorizationRule(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var response = Client.Namespaces.GetAuthorizationRule(resourceGroupName, namespaceName, authRuleName);
            return new PSAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSAuthorizationRuleAttributes> ListNamespaceAuthorizationRules(string resourceGroupName, string namespaceName)
        {
            var response = Client.Namespaces.ListAuthorizationRules(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSAuthorizationRuleAttributes(resource));
            return resourceList;
        }

        public PSAuthorizationRuleAttributes CreateOrUpdateNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authorizationRuleName, PSAuthorizationRuleAttributes parameter)
        {
            var parameter1 = new AuthorizationRule()
            {
                Rights = parameter.Rights.Select(x => Enum.Parse(typeof(AccessRights), x))
                             .Cast<AccessRights?>()
                             .ToList()
            };

            var response = Client.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, authorizationRuleName, parameter1);
            return new PSAuthorizationRuleAttributes(response);
        }

        public void DeleteNamespaceAuthorizationRules(string resourceGroupName, string namespaceName, string authRuleName)
        {
            Client.Namespaces.DeleteAuthorizationRule(resourceGroupName, namespaceName, authRuleName);            
        }

        public PSAuthorizationRuleKeysAttributes GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return new PSAuthorizationRuleKeysAttributes(listKeys);
        }

        public PSAuthorizationRuleKeysAttributes NamespaceRegenerateKeys(string resourceGroupName, string namespaceName, string authRuleName, string regenerateKeys, string keyValue = null)
        {
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey, keyValue));
            else
                regenerateKeyslistKeys = Client.Namespaces.RegenerateKeys(resourceGroupName, namespaceName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey, keyValue));

            return new PSAuthorizationRuleKeysAttributes(regenerateKeyslistKeys);
        }

        #endregion

        #region WcfRelay
        public PSWcfRelayAttributes GetWcfRelay(string resourceGroupName, string namespaceName, string wcfRelayName)
        {
            var response = Client.WCFRelays.Get(resourceGroupName, namespaceName, wcfRelayName);
            return new PSWcfRelayAttributes(response);
        }

        public IEnumerable<PSWcfRelayAttributes> ListAllWcfRelay(string resourceGroupName, string namespaceName)
        {
            var response = Client.WCFRelays.ListByNamespace(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSWcfRelayAttributes(resource));
            return resourceList;
        }

        public PSWcfRelayAttributes CreateOrUpdateWcfRelay(string resourceGroupName, string namespaceName, string wcfRelayName, PSWcfRelayAttributes parameter)
        {
            
            var Parameter1 = new WcfRelay();

            if (!string.IsNullOrEmpty(parameter.RelayType))
                Parameter1.RelayType = (Relaytype?)Enum.Parse(typeof(Relaytype), parameter.RelayType);

            if (parameter.RequiresClientAuthorization.HasValue)
                Parameter1.RequiresClientAuthorization = parameter.RequiresClientAuthorization;

            if (parameter.RequiresTransportSecurity.HasValue)
                Parameter1.RequiresTransportSecurity = parameter.RequiresTransportSecurity;

            if (!string.IsNullOrEmpty(parameter.UserMetadata))
                Parameter1.UserMetadata = parameter.UserMetadata;

            var response = Client.WCFRelays.CreateOrUpdate(resourceGroupName, namespaceName, wcfRelayName, Parameter1);
            return new PSWcfRelayAttributes(response);
        }

        public PSWcfRelayAttributes UpdateWcfRelay(string resourceGroupName, string namespaceName, string wcfRelayName, PSWcfRelayAttributes parameter)
        {

            var Parameter1 = Client.WCFRelays.Get(resourceGroupName, namespaceName, wcfRelayName);
                        
            if (!string.IsNullOrEmpty(parameter.UserMetadata))
                Parameter1.UserMetadata = parameter.UserMetadata;

            var response = Client.WCFRelays.CreateOrUpdate(resourceGroupName, namespaceName, wcfRelayName, Parameter1);
            return new PSWcfRelayAttributes(response);
        }


        public void DeleteWcfRelay(string resourceGroupName, string namespaceName, string wcfRelayName)
        {
            Client.WCFRelays.Delete(resourceGroupName, namespaceName, wcfRelayName);
        }

        public PSAuthorizationRuleAttributes GetWcfRelayAuthorizationRules(string resourceGroupName, string namespaceName, string wcfRelayName, string authRuleName)
        {
            var response = Client.WCFRelays.GetAuthorizationRule(resourceGroupName, namespaceName, wcfRelayName, authRuleName);
            return new PSAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSAuthorizationRuleAttributes> ListWcfRelayAuthorizationRules(string resourceGroupName, string namespaceName, string wcfRelayName)
        {
            var response = Client.WCFRelays.ListAuthorizationRules(resourceGroupName, namespaceName, wcfRelayName);
            var resourceList = response.Select(resource => new PSAuthorizationRuleAttributes(resource));
            return resourceList;
        }

        public PSAuthorizationRuleAttributes CreateOrUpdateWcfRelayAuthorizationRules(string resourceGroupName, string namespaceName, string wcfRelayName, string authorizationRuleName, PSAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new AuthorizationRule()
            {                
                Rights = parameters.Rights.Select(x => Enum.Parse(typeof(AccessRights), x))
                             .Cast<AccessRights?>()
                             .ToList()
            };

            var response = Client.WCFRelays.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, wcfRelayName, authorizationRuleName, parameter1);
            return new PSAuthorizationRuleAttributes(response);
        }

        public void DeleteWcfRelayAuthorizationRules(string resourceGroupName, string namespaceName, string wcfRelayName, string authRuleName)
        {
            Client.WCFRelays.DeleteAuthorizationRule(resourceGroupName, namespaceName, wcfRelayName, authRuleName);            
        }

        public PSAuthorizationRuleKeysAttributes GetWcfRelayListKeys(string resourceGroupName, string namespaceName, string wcfRelayName, string authRuleName)
        {
            var listKeys = Client.WCFRelays.ListKeys(resourceGroupName, namespaceName, wcfRelayName, authRuleName);
            return new PSAuthorizationRuleKeysAttributes(listKeys);
        }

        public PSAuthorizationRuleKeysAttributes WcfRelayRegenerateKeys(string resourceGroupName, string namespaceName, string wcfRelayName, string authRuleName, string regenerateKeys, string keyValue = null)
        {
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.WCFRelays.RegenerateKeys(resourceGroupName, namespaceName, wcfRelayName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey, keyValue));
            else
                regenerateKeyslistKeys = Client.WCFRelays.RegenerateKeys(resourceGroupName, namespaceName, wcfRelayName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey, keyValue));

            return new PSAuthorizationRuleKeysAttributes(regenerateKeyslistKeys);

        }

        #endregion

        #region HybridConnections
        public PSHybridConnectionAttributes GetHybridConnections(string resourceGroupName, string namespaceName, string hybridConnectionsName)
        {
            var response = Client.HybridConnections.Get(resourceGroupName, namespaceName, hybridConnectionsName);
            return new PSHybridConnectionAttributes(response);
        }

        public IEnumerable<PSHybridConnectionAttributes> ListAllHybridConnections(string resourceGroupName, string namespaceName)
        {
            var response = Client.HybridConnections.ListByNamespace(resourceGroupName, namespaceName);
            var resourceList = response.Select(resource => new PSHybridConnectionAttributes(resource));
            return resourceList;
        }

        public PSHybridConnectionAttributes CreateOrUpdateHybridConnections(string resourceGroupName, string namespaceName, string hybridConnectionsName, PSHybridConnectionAttributes parameter)
        {
            var Parameter1 = new HybridConnection();
            

            if (parameter.RequiresClientAuthorization.HasValue)
                Parameter1.RequiresClientAuthorization = parameter.RequiresClientAuthorization;
                       

            if (!string.IsNullOrEmpty(parameter.UserMetadata))
                Parameter1.UserMetadata = parameter.UserMetadata;

            var response = Client.HybridConnections.CreateOrUpdate(resourceGroupName, namespaceName, hybridConnectionsName, Parameter1);
            return new PSHybridConnectionAttributes(response);
        }

        public PSHybridConnectionAttributes UpdateHybridConnections(string resourceGroupName, string namespaceName, string hybridConnectionsName, PSHybridConnectionAttributes parameter)
        {
            //var Parameter1 = Client.HybridConnections.Get(resourceGroupName, namespaceName, hybridConnectionsName);
            var Parameter1 = new HybridConnection();
            if (!string.IsNullOrEmpty(parameter.UserMetadata))
                Parameter1.UserMetadata = parameter.UserMetadata;

            var response = Client.HybridConnections.CreateOrUpdate(resourceGroupName, namespaceName, hybridConnectionsName, Parameter1);
            return new PSHybridConnectionAttributes(response);
        }

        public void DeleteHybridConnections(string resourceGroupName, string namespaceName, string hybridConnectionsName)
        {
            Client.HybridConnections.Delete(resourceGroupName, namespaceName, hybridConnectionsName);
        }

        public PSAuthorizationRuleAttributes GetHybridConnectionsAuthorizationRules(string resourceGroupName, string namespaceName, string hybridConnectionsName, string authRuleName)
        {
            var response = Client.HybridConnections.GetAuthorizationRule(resourceGroupName, namespaceName, hybridConnectionsName, authRuleName);
            return new PSAuthorizationRuleAttributes(response);
        }

        public IEnumerable<PSAuthorizationRuleAttributes> ListHybridConnectionsAuthorizationRules(string resourceGroupName, string namespaceName, string hybridConnectionsName)
        {
            var response = Client.HybridConnections.ListAuthorizationRules(resourceGroupName, namespaceName, hybridConnectionsName);
            var resourceList = response.Select(resource => new PSAuthorizationRuleAttributes(resource));
            return resourceList;
        }

        public PSAuthorizationRuleAttributes CreateOrUpdateHybridConnectionsAuthorizationRules(string resourceGroupName, string namespaceName, string hybridConnectionsName, string authorizationRuleName, PSAuthorizationRuleAttributes parameters)
        {
            var parameter1 = new AuthorizationRule()
            {                
                Rights = parameters.Rights.Select(x => Enum.Parse(typeof(AccessRights), x))
                             .Cast<AccessRights?>()
                             .ToList()
        };


            var response = Client.HybridConnections.CreateOrUpdateAuthorizationRule(resourceGroupName, namespaceName, hybridConnectionsName, authorizationRuleName, parameter1);
            return new PSAuthorizationRuleAttributes(response);
        }

        public void DeleteHybridConnectionsAuthorizationRules(string resourceGroupName, string namespaceName, string hybridConnectionsName, string authRuleName)
        {
            Client.HybridConnections.DeleteAuthorizationRule(resourceGroupName, namespaceName, hybridConnectionsName, authRuleName);            
        }

        public PSAuthorizationRuleKeysAttributes GethybridConnectionsListKeys(string resourceGroupName, string namespaceName, string hybridConnectionsName, string authRuleName)
        {
            var listKeys = Client.WCFRelays.ListKeys(resourceGroupName, namespaceName, hybridConnectionsName, authRuleName);
            return new PSAuthorizationRuleKeysAttributes(listKeys);
        }

        public PSAuthorizationRuleKeysAttributes HybridConnectionsRegenerateKeys(string resourceGroupName, string namespaceName, string hybridConnectionsName, string authRuleName, string regenerateKeys, string keyValue = null)
        {
            AccessKeys regenerateKeyslistKeys;
            if (regenerateKeys == "PrimaryKey")
                regenerateKeyslistKeys = Client.HybridConnections.RegenerateKeys(resourceGroupName, namespaceName, hybridConnectionsName, authRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey, keyValue));
            else
                regenerateKeyslistKeys = Client.HybridConnections.RegenerateKeys(resourceGroupName, namespaceName, hybridConnectionsName, authRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey,keyValue));

            return new PSAuthorizationRuleKeysAttributes(regenerateKeyslistKeys);

        }

        #endregion HybridConnections
    }
}
