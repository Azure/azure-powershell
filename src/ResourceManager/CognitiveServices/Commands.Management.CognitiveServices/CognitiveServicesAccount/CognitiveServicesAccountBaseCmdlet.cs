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

using Microsoft.Azure.Commands.Management.CognitiveServices;
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    public abstract class CognitiveServicesAccountBaseCmdlet : AzureRMCmdlet
    {
        private CognitiveServicesManagementClientWrapper cognitiveServicesClientWrapper;

        protected const string CognitiveServicesAccountNounStr = "AzureRmCognitiveServicesAccount";
        protected const string CognitiveServicesAccountKeyNounStr = CognitiveServicesAccountNounStr + "Key";
        protected const string CognitiveServicesAccountSkusNounStr = CognitiveServicesAccountNounStr + "Skus";

        protected const string CognitiveServicesAccountNameAlias = "CognitiveServicesAccountName";
        protected const string AccountNameAlias = "AccountName";

        protected const string CognitiveServicesAccountTypeAlias = "CognitiveServicesAccountType";
        protected const string AccountTypeAlias = "AccountType";
        protected const string KindAlias = "Kind";

        protected const string TagsAlias = "Tags";
        
        protected struct AccountSkuString 
        {
            internal const string F0 = "F0";
            internal const string P0 = "P0";
            internal const string P1 = "P1";
            internal const string P2 = "P2";
            internal const string S0 = "S0";
            internal const string S1 = "S1";
            internal const string S2 = "S2";
            internal const string S3 = "S3";
            internal const string S4 = "S4";
            internal const string S5 = "S5";
            internal const string S6 = "S6";
        }
        protected struct AccountType
        {
            internal const string Academic = "Academic";
            internal const string BingAutosuggest = "Bing.Autosuggest";
            internal const string BingSearch = "Bing.Search";
            internal const string BingSpeech = "Bing.Speech";
            internal const string BingSpellCheck = "Bing.SpellCheck";
            internal const string ComputerVision = "ComputerVision";
            internal const string ContentModerator = "ContentModerator";
            internal const string Emotion = "Emotion";
            internal const string Face = "Face";
            internal const string LUIS = "LUIS";
            internal const string Recommendations = "Recommendations";
            internal const string SpeakerRecognition = "SpeakerRecognition";
            internal const string Speech = "Speech";
            internal const string SpeechTranslation = "SpeechTranslation";
            internal const string TextAnalytics = "TextAnalytics";
            internal const string TextTranslation = "TextTranslation";
            internal const string WebLM = "WebLM";
        }
        
        public ICognitiveServicesManagementClient CognitiveServicesClient
        {
            get
            {
                if (cognitiveServicesClientWrapper == null)
                {
                    cognitiveServicesClientWrapper = new CognitiveServicesManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                this.cognitiveServicesClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                this.cognitiveServicesClientWrapper.ErrorLogger = WriteErrorWithTimestamp;
                return cognitiveServicesClientWrapper.CognitiveServicesManagementClient;
            }

            set { cognitiveServicesClientWrapper = new CognitiveServicesManagementClientWrapper(value); }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action"></param>
        protected void RunCmdLet(Action action)
        {
            try
            {
                action();
            }
            catch (ErrorException ex)
            {
                throw new PSInvalidOperationException(ex.Body.ErrorProperty.Message, ex);
            }
        }


        protected void WriteCognitiveServicesAccount(
            CognitiveServicesModels.CognitiveServicesAccount cognitiveServicesAccount)
        {
            if (cognitiveServicesAccount != null)
            {
                WriteObject(PSCognitiveServicesAccount.Create(cognitiveServicesAccount));
            }
        }

        protected void WriteCognitiveServicesAccountList(
            IEnumerable<CognitiveServicesModels.CognitiveServicesAccount> cognitiveServicesAccounts)
        {
            List<PSCognitiveServicesAccount> output = new List<PSCognitiveServicesAccount>();
            if (cognitiveServicesAccounts != null)
            {
                cognitiveServicesAccounts.ForEach(cognitiveServicesAccount => output.Add(PSCognitiveServicesAccount.Create(cognitiveServicesAccount)));
            }
            
            WriteObject(output, true);
        }

        protected static class TagsConversionHelper
        {
            public static KeyValuePair<string, string> Create(Hashtable hashtable)
            {
                if (hashtable == null ||
                    !hashtable.ContainsKey("Name"))
                {
                    return new KeyValuePair<string, string>();
                }


                return new KeyValuePair<string, string>(
                    hashtable["Name"].ToString(), 
                    hashtable.ContainsKey("Value") ? hashtable["Value"].ToString() : string.Empty);
            }

            public static Dictionary<string, string> CreateTagDictionary(Hashtable[] hashtableArray)
            {
                Dictionary<string, string> tagDictionary = null;
                if (hashtableArray != null && hashtableArray.Length > 0)
                {
                    tagDictionary = new Dictionary<string, string>();
                    foreach (var tag in hashtableArray)
                    {
                        var tagValuePair = Create(tag);
                        if (!string.IsNullOrEmpty(tagValuePair.Key))
                        {
                            if (tagValuePair.Value != null)
                            {
                                tagDictionary[tagValuePair.Key] = tagValuePair.Value;
                            }
                            else
                            {
                                tagDictionary[tagValuePair.Value] = "";
                            }
                        }
                    }
                }

                return tagDictionary;
            }

            public static Hashtable[] CreateTagHashtable(IDictionary<string, string> dictionary)
            {
                if (dictionary == null)
                {
                    return new Hashtable[0];
                }

                List<Hashtable> tagHashtable = new List<Hashtable>();
                foreach (string key in dictionary.Keys)
                {
                    tagHashtable.Add(new Hashtable
                {
                    {"Name", key},
                    {"Value", dictionary[key]}
                });
                }
                return tagHashtable.ToArray();
            }
        }
    }
}
