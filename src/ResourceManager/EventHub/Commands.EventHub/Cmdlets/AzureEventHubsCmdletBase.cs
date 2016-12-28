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
       
        protected const string ConsumerGroupVerb = "AzureRmEventHubConsumerGroup";

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

        protected static Policykey ParsePolicyKey(string policyKeyName)
        {
            Policykey returnPolicyKey;
            if (!Enum.TryParse<Policykey>(policyKeyName, true, out returnPolicyKey))
            {
                throw new ArgumentOutOfRangeException("PolicyKey");
            }
            return returnPolicyKey;
        }

        protected static AccessRights ParseAccessRights(string rightsName)
        {
            AccessRights returnAccessRights;
            if (!Enum.TryParse<AccessRights>(rightsName, true, out returnAccessRights))
            {
                throw new ArgumentOutOfRangeException("AccessRights");
            }
            return returnAccessRights;
        }


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

        protected T ParseInputFile<T>(string InputFile)
        {
            T parsedObj;
            string path = Directory.GetCurrentDirectory();
            if (!string.IsNullOrEmpty(InputFile))
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,Properties.Resources.FileDoesNotExist, fileName));
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
