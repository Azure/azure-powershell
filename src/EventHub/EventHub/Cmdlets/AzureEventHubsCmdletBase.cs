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

using Microsoft.Azure.Commands.Eventhub;
using Microsoft.Azure.Commands.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading;
using System.Text.RegularExpressions;


namespace Microsoft.Azure.Commands.EventHub.Commands
{

    public abstract class AzureEventHubsCmdletBase : AzureRMCmdlet
    {                                                        
        protected const string EventHubNamespaceVerb = "AzureRmEventHubNamespace";
        protected const string EventHubNamespaceAuthorizationRuleVerb = "AzureRmEventHubNamespaceAuthorizationRule";
        protected const string EventHubNamespaceKeyVerb = "AzureRmEventHubNamespaceKey";

        protected const string EventHubVerb = "AzureRmEventHub";
        protected const string EventHubAuthorizationRuleVerb = "AzureRmEventHubAuthorizationRule";
        protected const string EventHubKeyVerb = "AzureRmEventHubKey";

        
        protected const string NewEventHubAuthorizationRuleVerb = "AzureRmEventHubAuthorizationRule";
        protected const string NewEventHubKeyVerb = "AzureRmEventHubKey";

        protected const string ConsumerGroupVerb = "AzureRmEventHubConsumerGroup";

        protected const string EventHubDRConfigurationVerb = "AzureRmEventHubGeoDRConfiguration";
        protected const string EventhubDRConfigurationFailoverVerb = "AzureRmEventHubGeoDRConfigurationFailOver";
        protected const string EventhubDRConfigurationBreakPairingVerb = "AzureRmEventHubGeoDRConfigurationBreakPair";
        
        //Parametersets for Authorizationrules
        protected const string NamespaceAuthoRuleParameterSet = "NamespaceAuthorizationRuleSet";
        protected const string EventhubAuthoRuleParameterSet = "EventhubAuthorizationRuleSet";
        protected const string ConsumergroupAuthoRuleParameterSet = "ConsumergroupAuthorizationRuleSet";
        protected const string AliasAuthoRuleParameterSet = "AliasAuthoRuleSet";
        protected const string AliasCheckNameAvailabilityParameterSet = "AliasCheckNameAvailabilitySet";
        protected const string NamespaceCheckNameAvailabilityParameterSet = "NamespaceCheckNameAvailabilitySet";

        //Parameter sets for InputObjects
        protected const string NamespaceInputObjectParameterSet = "NamespaceInputObjectSet";
        protected const string EventhubInputObjectParameterSet = "EventhubInputObjectSet";
        protected const string ConsumergroupInputObjectParameterSet = "ConsumergroupInputObjectSet";
        protected const string AuthoRuleInputObjectParameterSet = "AuthoRuleInputObjectSet";
        protected const string GeoDRInputObjectParameterSet = "GeoDRConfigurationInputObjectSet";
        protected const string NetwrokruleSetInputObjectParameterSet = "NetwrokruleSetInputObjectSet";
        protected const string VirtualNetworkRuleInputObjectParameterSet = "VirtualNetworkRuleInputObjectParameterSet";
        protected const string IPRuleInputObjectParameterSet = "IPRuleInputObjectParameterSet";
        protected const string ClusterInputObjectParameterSet = "ClusterInputObjectSet";
        protected const string SchemaGroupInputObjectParameterSet = "SchemaGroupInputObjectParameterSet";
        protected const string ApplicationGroupInputObjectParameterSet = "ApplicationGroupInputObjectParameterSet";

        //Parameter sets for ResourceID
        protected const string GeoDRConfigResourceIdParameterSet = "GeoDRConfigResourceIdParameterSet";
        protected const string NamespaceResourceIdParameterSet = "NamespaceResourceIdParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string EventhubResourceIdParameterSet = "EventhubResourceIdParameterSet";
        protected const string ConsumergroupResourceIdParameterSet = "ConsumergroupResourceIdParameterSet";
        protected const string NetworkRuleSetResourceIdParameterSet = "NetworkRuleSetResourceIdParameterSet";
        protected const string ClusterResourceIdParameterSet = "ClusterResourceIdParameterSet";
        protected const string SchemaGroupResourceIdParameterSet = "SchemaGroupResourceIdParameterSet";
        protected const string ApplicationGroupResourceIdParameterSet = "ApplicationGroupResourceIdParameterSet";
        protected const string PrivateEndpointResourceIdParameterSet = "PrivateEndpointResourceIdParameterSet";

        //Parameter sets for Properties
        protected const string NamespacePropertiesParameterSet = "NamespacePropertiesSet";
        protected const string EventhubPropertiesParameterSet = "EventhubPropertiesSet";
        protected const string ConsumergroupPropertiesParameterSet = "ConsumergroupPropertiesSet";
        protected const string GeoDRParameterSet = "GeoDRParameterSet";
        protected const string NetwrokruleSetPropertiesParameterSet = "NetworkRuleSetPropertiesSet";
        protected const string PrivateEndpointPropertiesParameterSet = "PrivateEndpointPropertiesSet";
        protected const string PrivateLinkPropertiesParameterSet = "PrivateLinkPropertiesSet";
        protected const string NetwrokruleSetNamespacePropertiesParameterSet = "NetworkRuleSetNamespacePropertiesSet";
        protected const string VirtualNetworkRulePropertiesParameterSet = "VirtualNetworkRulePropertiesParameterSet";
        protected const string IPRulePropertiesParameterSet = "IPRulePropertiesParameterSet";
        protected const string ApplicationGroupPropertiesParameterSet = "ApplicationGroupPropertiesParameterSet";

        protected const string EventhubDefaultParameterSet = "EventhubDefaultSet";

        //Parametersets for Authorizationrules
        protected const string ClusterPropertiesParameterSet = "ClusterPropertiesSet";
        protected const string ClusterGetPropertiesParameterSet = "ClusterGetPropertiesSet";
        protected const string ClusterListPropertiesParameterSet = "ClusterListPropertiesSet";

        //Parametersets for Authorizationrules
        protected const string NamespaceParameterSet = "NamespaceParameterSet";
        protected const string AutoInflateParameterSet = "AutoInflateParameterSet";
        protected const string IdentityUpdateParameterSet = "IdentityUpdateParameterSet";

        //ParameterSets for SchemaGroups
        protected const string NamespaceSchemaGroupParameterSet = "NamespaceSchemaGroupParameterSet";

        //Alias - used in Cmdlets
        protected const string AliasResourceGroup = "ResourceGroup";
        protected const string AliasNamespaceName = "NamespaceName";
        protected const string AliasEventHubName = "EventHubName";
        protected const string AliasConsumerGroupName = "ConsumerGroupName";
        protected const string AliasEventHubObj = "EventHubObj";
        protected const string AliasAuthorizationRuleName = "AuthorizationRuleName";
        protected const string AliasAuthRuleObj = "AuthRuleObj";
        protected const string AliasResourceId = "ResourceId";
        protected const string AliasVirtualNetworkRule = "VirtualNteworkRule";
        protected const string AliasSchemaGroupName = "SchemaGroupName";

        //Access Rights 
        protected const string Manage = "Manage";
        protected const string Send = "Send";
        protected const string Listen = "Listen";

        //Schema Group properties
        protected const string SchemaCompatibilityProperty = "SchemaCompatibility";
        protected const string SchemaTypeProperty = "SchemaType";
        protected const string GroupPropertyProperty = "GroupProperty";


        protected struct SKU
        {
            internal const string Basic = "Basic";
            internal const string Standard = "Standard";
            internal const string Premium = "Premium";
        }

        protected struct MetricIdValues
        {
            internal const string IncomingBytes = "IncomingBytes";
            internal const string OutgoingBytes = "OutgoingBytes";
            internal const string IncomingMessages = "IncomingMessages";
            internal const string OutgoingMessages = "OutgoingMessages";
        }

        protected struct PrivateEndpointConnectionState
        {
            internal const string Pending = "Pending";
            internal const string Approved = "Approved";
            internal const string Rejected = "Rejected";
            internal const string Disconnected = "Disconnected";
        }

        protected struct RegeneKeys
        {
            internal const string PrimaryKey = "PrimaryKey";
            internal const string SecondaryKey = "SecondaryKey";
        }

        protected const string NamespaceURL = "Microsoft.EventHub/namespaces";
        protected const string SchemaGroupURL = "Microsoft.EventHub/namespaces/schemagroups";
        protected const string ApplicationGroupURL = "Microsoft.EventHub/namespaces/applicationgroups";
        protected const string PrivateEndpointURL = "Microsoft.EventHub/namespaces/privateEndpointConnections";

        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromMinutes(1);
        private EventHubsClient  _client;
        
        public EventHubsClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new EventHubsClient(DefaultContext);
                }
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        public ResourceIdentifier GetResourceDetailsFromId(string strResourceId)
        {
            ResourceIdentifier returnResourceIdentifier = new ResourceIdentifier(strResourceId);
            returnResourceIdentifier.ParentResource = Regex.Split(strResourceId, @"/")[8];
            return returnResourceIdentifier;
        }

        #region TagsHelper

        public Dictionary<string, string> ConvertTagsToDictionary(Hashtable tags)
        {
            if (tags != null)
            {
                Dictionary<string, string> tagsDictionary = new Dictionary<string, string>();
                foreach (DictionaryEntry tag in tags)
                {
                    string key = tag.Key as string;
                    if (string.IsNullOrWhiteSpace(key))
                        throw new ArgumentException("Invalid tag name");

                    if (tag.Value != null && !(tag.Value is string))
                        throw new ArgumentException("Tag has invalid value");
                    string value = (tag.Value == null) ? string.Empty : (string)tag.Value;
                    tagsDictionary[key] = value;
                }
                return tagsDictionary;

            }

            return null;
        }

        public Hashtable ConvertTagsToHashtable(IDictionary<string, string> tags)
        {
            if (tags != null)
            {
                Hashtable tagsHashtable = new Hashtable();
                foreach (var tag in tags)
                    tagsHashtable[tag.Key] = tag.Value;

                return tagsHashtable;
            }

            return null;
        }

        #endregion
    }
    public class LocalResourceIdentifier : ResourceIdentifier
    {
        public LocalResourceIdentifier(string strResourceID) : base(strResourceID)
        {
            if (base.ParentResource != null && !(this.ResourceType.Equals("Microsoft.EventHub/namespaces") || this.ResourceType.Equals("Microsoft.ServiceBus/namespaces") || this.ResourceType.Equals("Microsoft.Relay/namespaces")))
            {
                string[] tokens = base.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // for upto 3 Parents 
                switch (tokens.Length)
                {
                    case 2:
                        ParentResource = tokens[1];
                        break;
                    case 4:
                        ParentResource = tokens[1];
                        ParentResource1 = tokens[3];
                        break;
                    case 6:
                        ParentResource = tokens[1];
                        ParentResource1 = tokens[3];
                        ParentResource2 = tokens[5];
                        break;
                    default:
                        throw new Exception("Invalid length of tokens");
                }
            }
        }

        public string ParentResource1 { get; set; }

        public string ParentResource2 { get; set; }

    }

}
