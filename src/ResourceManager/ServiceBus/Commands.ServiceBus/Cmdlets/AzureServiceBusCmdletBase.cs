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

using Microsoft.Azure.Commands.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{

    public abstract class AzureServiceBusCmdletBase : AzureRMCmdlet
    {
        public const string InputFileParameterSetName = "InputFileParameterSet";
        public const string SASRuleParameterSetName = "SASRuleParameterSet";
        public const string QueueParameterSetName = "QueueParameterSet";
        public const string TopicParameterSetName = "TopicParameterSet";
        public const string SubscriptionParameterSetName = "SubscriptionParameterSet";
        public const string RegenerateKeysSetName = "RegenerateKeysSet";

        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromMinutes(1);
        private Microsoft.Azure.Commands.Servicebus.ServiceBusClient  _client;

        protected const string ServiceBusNamespaceVerb = "AzureRmServiceBusNamespace";

        protected const string ServiceBusNamespaceKeyVerb = "AzureRmServiceBusNamespaceKey";

        protected const string ServiceBusNamespaceAuthorizationRuleVerb = "AzureRmServiceBusNamespaceAuthorizationRule";        

        protected const string ServicebusVerb = "AzureRmServiceBus";

        protected const string ServicebusQueueVerb = "AzureRmServiceBusQueue";
        protected const string ServiceBusQueueAuthorizationRuleVerb = "AzureRmServiceBusQueueAuthorizationRule";
        protected const string ServiceBusQueueKeyVerb = "AzureRmServiceBusQueueKey";

        protected const string ServicebusTopicVerb = "AzureRmServiceBusTopic";
        protected const string ServiceBusTopicAuthorizationRuleVerb = "AzureRmServiceBusTopicAuthorizationRule";
        protected const string ServiceBusTopicKeyVerb = "AzureRmServiceBusTopicKey";

        //AuthorizationRules
        protected const string ServiceBusAuthorizationRuleVerb = "AzureRmServiceBusAuthorizationRule";
        protected const string ServiceBusKeyVerb = "AzureRmServiceBusKey";

        //Parametersets for Authorizationrules
        protected const string NamespaceAuthoRuleParameterSet = "NamespaceAuthorizationRuleSet";
        protected const string QueueAuthoRuleParameterSet = "QueueAuthorizationRuleSet";
        protected const string TopicAuthoRuleParameterSet = "TopicAuthorizationRuleSet";
        protected const string SubscriptionAuthoRuleParameterSet = "SubscriptionAuthorizationRuleSet";

        //Parameter sets for InputObjects
        protected const string NamespaceInputObjectParameterSet = "NamespaceInputObjectSet";
        protected const string QueueInputObjectParameterSet = "QueueInputObjectSet";
        protected const string TopicInputObjectParameterSet = "TopicInputObjectSet";
        protected const string SubscriptionInputObjectParameterSet = "SubscriptionInputObjectSet";
        protected const string AuthoRuleInputObjectParameterSet = "AuthoRuleInputObjectSet";

        //Parameter sets for Properties
        protected const string NamespacePropertiesParameterSet = "NamespacePropertiesSet";
        protected const string QueuePropertiesParameterSet = "QueuePropertiesSet";
        protected const string TopicPropertiesParameterSet = "TopicPropertiesSet";
        protected const string SubscriptionPropertiesParameterSet = "SubscriptionPropertiesSet";
        protected const string AuthoRulePropertiesParameterSet = "AuthoRulePropertiesSet";

        //Alias - used in Cmdlets
        protected const string AliasResourceGroupname = "ResourceGroupName";
        protected const string AliasResourceGroup = "ResourceGroup";
        protected const string AliasNamespaceName = "NamespaceName";
        protected const string AliasQueueName = "QueueName";
        protected const string AliasTopicName = "TopicName";
        protected const string AliasQueueObj = "QueueObj";
        protected const string AliasTopicObj = "TopicObj";
        protected const string AliasAuthorizationRuleName = "AuthorizationRuleName";
        protected const string AliasAuthRuleObj = "AuthRuleObj";
        protected const string AliasSubscriptionName = "SubscriptionName";
        protected const string AliasSubscriptionObj = "SubscriptionObj";


        protected const string ServicebusSubscriptionVerb = "AzureRmServiceBusSubscription";

        protected const string ServicebusRuleVerb = "AzureRmServiceBusRule";

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
        
        protected static AccessRights ParseAccessRights(string rightsName)
        {
            AccessRights returnAccessRights;
            if (!Enum.TryParse<AccessRights>(rightsName, true, out returnAccessRights))
            {
                throw new ArgumentOutOfRangeException("AccessRights");
            }
            return returnAccessRights;
        }
        
        public static SkuName ParseSkuName(string skuName)
        {
            SkuName returnSkuName;
            if (!Enum.TryParse<SkuName>(skuName, true, out returnSkuName))
            {
                throw new ArgumentOutOfRangeException("SkuName");
            }
            return returnSkuName;
        }

        public static SkuTier ParseSkuTier(string skuTier)
        {
            SkuTier returnSkutier;
            if (!Enum.TryParse<SkuTier>(skuTier, true, out returnSkutier))
            {
                throw new ArgumentOutOfRangeException("skuTier");
            }
            return returnSkutier;
        }

        public static TimeSpan ParseTimespan(string strTimespan)
        {
            TimeSpan tspan = new TimeSpan();
            if(strTimespan.Contains("P") || strTimespan.Contains("D") || strTimespan.Contains("T") || strTimespan.Contains("H") || strTimespan.Contains("M") || strTimespan.Contains("M"))
            {
                tspan = XmlConvert.ToTimeSpan(strTimespan);
            }
            else
            {
                tspan = TimeSpan.Parse(strTimespan);
            }
            return tspan;
        }

        public Microsoft.Azure.Commands.Servicebus.ServiceBusClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new Microsoft.Azure.Commands.Servicebus.ServiceBusClient(DefaultContext);
                }
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        protected void ExecuteLongRunningCmdletWrap(Func<NamespaceLongRunningOperation> func)
        {
            try
            {
                var longRunningOperation = func();

                longRunningOperation = WaitForOperationToComplete(longRunningOperation);
                bool success = string.IsNullOrWhiteSpace(longRunningOperation.Error);
                if (!success)
                {
                    WriteErrorWithTimestamp(longRunningOperation.Error);
                }
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.InvalidArgument, null));
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        protected void WriteProgress(NamespaceLongRunningOperation operation)
        {
            WriteProgress(new ProgressRecord(0, operation.OperationName, operation.Status.ToString()));
        }

        protected NamespaceLongRunningOperation WaitForOperationToComplete(NamespaceLongRunningOperation longRunningOperation)
        {
            WriteProgress(longRunningOperation);

            while (longRunningOperation.Status == OperationStatus.InProgress)
            {
                var retryAfter = longRunningOperation.RetryAfter ?? LongRunningOperationDefaultTimeout;

                Thread.Sleep(retryAfter);

                WriteProgress(longRunningOperation);
            }

            return longRunningOperation;
        }

        protected T ParseInputFile<T>(string InputFile)
        {
            T parsedObj;

            if (!string.IsNullOrEmpty(InputFile))
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.FileDoesNotExist, fileName));
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
