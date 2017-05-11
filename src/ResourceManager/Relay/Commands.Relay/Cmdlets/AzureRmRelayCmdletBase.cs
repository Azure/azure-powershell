﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Relay;
using Microsoft.Azure.Management.Relay;
using Microsoft.Azure.Management.Relay.Models;
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


namespace Microsoft.Azure.Commands.Relay.Commands
{

    public abstract class AzureRelayCmdletBase : AzureRMCmdlet
    {
        public const string InputFileParameterSetName = "InputFileParameterSet";
        public const string SASRuleParameterSetName = "SASRuleParameterSet";
        public const string RelayParameterSetName = "RelayParameterSet";
        public const string ConsumerGroupParameterSetName = "ConsumerGroupParameterSet";
        public const string RegenerateKeySetName = "RegenerateKeySet";

        protected const string RelayNamespaceVerb = "AzureRmRelayNamespace";
        protected const string RelayNamespaceAuthorizationRuleVerb = "AzureRmRelayNamespaceAuthorizationRule";
        protected const string RelayNamespaceKeyVerb = "AzureRmRelayNamespaceKey";

        protected const string RelayWcfRelayVerb = "AzureRmWcfRelay";
        protected const string RelayWcfRelayAuthorizationRuleVerb = "AzureRmWcfRelayAuthorizationRule";
        protected const string RelayWcfRelayKeyVerb = "AzureRmWcfRelayKey";

        protected const string RelayHybridConnectionVerb = "AzureRmRelayHybridConnection";
        protected const string RelayHybridConnectionAuthorizationRuleVerb = "AzureRmRelayHybridConnectionAuthorizationRule";
        protected const string RelayHybridConnectionKeyVerb = "AzureRmRelayHybridConnectionKey";
        
        //AuthorizationRules
        protected const string RelayAuthorizationRuleVerb = "AzureRmRelayAuthorizationRule";
        protected const string RelayKeyVerb = "AzureRmRelayKey";

        //Parametersets for Authorizationrules
        protected const string NamespaceAuthoRuleParameterSet = "NamespaceAuthorizationRuleSet";
        protected const string WcfRelayAuthoRuleParameterSet = "WcfRelayAuthorizationRuleSet";
        protected const string HybridConnectionAuthoRuleParameterSet = "HybridConnectionAuthorizationRuleSet";
        
        //Parameter sets for InputObjects
        protected const string NamespaceInputObjectParameterSet = "NamespaceInputObjectSet";
        protected const string WcfRelayInputObjectParameterSet = "WcfRelayInputObjectSet";
        protected const string HybridConnectionInputObjectParameterSet = "HybridConnectionInputObjectSet";
        protected const string AuthoRuleInputObjectParameterSet = "AuthoRuleInputObjectSet";

        //Parameter sets for Properties
        protected const string NamespacePropertiesParameterSet = "NamespacePropertiesSet";
        protected const string WcfRelayPropertiesParameterSet = "WcfRelayPropertiesSet";
        protected const string HybridConnectionPropertiesParameterSet = "HybridConnectionPropertiesSet";
        protected const string AuthoRulePropertiesParameterSet = "AuthoRulePropertiesSet";
        
        
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
        private RelayClient  _client;
        
        public RelayClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new RelayClient(DefaultContext);
                }
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        protected T ParseInputFile<T>(string InputFile)
        {
            T parsedObj;
            string path = Directory.GetCurrentDirectory();
            if (!string.IsNullOrEmpty(InputFile))
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,Resources.FileDoesNotExist, fileName));
                }

                try
                {
                    parsedObj = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
                    return parsedObj;
                }
                catch (JsonException)
                {
                    WriteVerbose("Deserializing the input role definition failed.");
                    throw;
                }
            }

            return default(T);
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
