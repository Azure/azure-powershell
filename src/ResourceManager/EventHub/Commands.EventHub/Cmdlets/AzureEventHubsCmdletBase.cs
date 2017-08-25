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
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading;


namespace Microsoft.Azure.Commands.EventHub.Commands
{

    public abstract class AzureEventHubsCmdletBase : AzureRMCmdlet
    {
        public const string InputFileParameterSetName = "InputFileParameterSet";
        public const string SASRuleParameterSetName = "SASRuleParameterSet";
        public const string EventHubParameterSetName = "EventHubParameterSet";
        public const string ConsumerGroupParameterSetName = "ConsumerGroupParameterSet";
        public const string RegenerateKeySetName = "RegenerateKeySet";
                                                        
        protected const string EventHubNamespaceVerb = "AzureRmEventHubNamespace";
        protected const string EventHubNamespaceAuthorizationRuleVerb = "AzureRmEventHubNamespaceAuthorizationRule";
        protected const string EventHubNamespaceKeyVerb = "AzureRmEventHubNamespaceKey";

        protected const string EventHubVerb = "AzureRmEventHub";
        protected const string EventHubAuthorizationRuleVerb = "AzureRmEventHubAuthorizationRule";
        protected const string EventHubKeyVerb = "AzureRmEventHubKey";

        
        protected const string NewEventHubAuthorizationRuleVerb = "AzureRmEventHubAuthorizationRule";
        protected const string NewEventHubKeyVerb = "AzureRmEventHubKey";

        protected const string ConsumerGroupVerb = "AzureRmEventHubConsumerGroup";


        //AuthorizationRules
        //protected const string EventHubAuthorizationRuleVerb = "AzureRmEventHubAuthorizationRule";
        //protected const string EventHubKeyVerb = "AzureRmEventHubKey";

        //Parametersets for Authorizationrules
        protected const string NamespaceAuthoRuleParameterSet = "NamespaceAuthorizationRuleSet";
        protected const string EventhubAuthoRuleParameterSet = "EventhubAuthorizationRuleSet";
        protected const string ConsumergroupAuthoRuleParameterSet = "ConsumergroupAuthorizationRuleSet";

        //Parameter sets for InputObjects
        protected const string NamespaceInputObjectParameterSet = "NamespaceInputObjectSet";
        protected const string EventhubInputObjectParameterSet = "EventhubInputObjectSet";
        protected const string ConsumergroupInputObjectParameterSet = "ConsumergroupInputObjectSet";
        protected const string AuthoRuleInputObjectParameterSet = "AuthoRuleInputObjectSet";

        //Parameter sets for Properties
        protected const string NamespacePropertiesParameterSet = "NamespacePropertiesSet";
        protected const string EventhubPropertiesParameterSet = "EventhubPropertiesSet";
        protected const string ConsumergroupPropertiesParameterSet = "ConsumergroupPropertiesSet";
        protected const string AuthoRulePropertiesParameterSet = "AuthoRulePropertiesSet";

        //Parametersets for Authorizationrules
        protected const string NamespaceParameterSet = "NamespaceParameterSet";
        protected const string AutoInflateParameterSet = "AutoInflateParameterSet";

        //Alias - used in Cmdlets
        protected const string AliasResourceGroup = "ResourceGroup";
        protected const string AliasNamespaceName = "NamespaceName";
        protected const string AliasEventHubName = "EventHubName";
        protected const string AliasConsumerGroupName = "ConsumerGroupName";
        protected const string AliasEventHubObj = "EventHubObj";
        protected const string AliasAuthorizationRuleName = "AuthorizationRuleName";
        protected const string AliasAuthRuleObj = "AuthRuleObj";
        
        protected struct SKU
        {
            internal const string Basic = "Basic";
            internal const string Standard = "Standard";
            internal const string Premium = "Premium";
        }

        protected struct RegeneKeys
        {
            internal const string PrimaryKey = "PrimaryKey";
            internal const string SecondaryKey = "SecondaryKey";
        }

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
}
