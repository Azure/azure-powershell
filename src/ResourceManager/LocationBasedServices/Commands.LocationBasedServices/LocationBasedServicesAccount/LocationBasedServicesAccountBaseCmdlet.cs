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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.LocationBasedServices
{
    public abstract class LocationBasedServicesAccountBaseCmdlet : AzureRMCmdlet
    {
        private ClientWrapper locationBasedServicesClientWrapper;

        protected const string LocationBasedServicesAccountNounStr = "AzureRmLocationBasedServicesAccount";
        protected const string LocationBasedServicesAccountKeyNounStr = LocationBasedServicesAccountNounStr + "Key";
        protected const string LocationBasedServicesAccountSkusNounStr = LocationBasedServicesAccountNounStr + "Skus";

        protected const string LocationBasedServicesAccountNameAlias = "LocationBasedServicesAccountName";
        protected const string AccountNameAlias = "AccountName";

        protected const string TagsAlias = "Tags";

        protected const string ResourceProviderName = "Microsoft.LocationBasedServices";
        protected const string ResourceTypeName = "accounts";

        protected struct AccountSkuString 
        {
            internal const string S0 = "S0";
        }
        
        public IClient LocationBasedServicesClient
        {
            get
            {
                if (locationBasedServicesClientWrapper == null)
                {
                    locationBasedServicesClientWrapper = new ClientWrapper(DefaultProfile.DefaultContext);
                }

                locationBasedServicesClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                locationBasedServicesClientWrapper.ErrorLogger = WriteErrorWithTimestamp;

                return locationBasedServicesClientWrapper.LocationBasedServicesManagementClient;
            }

            set { locationBasedServicesClientWrapper = new ClientWrapper(value); }
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
                throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }


        protected void WriteLocationBasedServicesAccount(LocationBasedServicesAccount locationBasedServicesAccount)
        {
            if (locationBasedServicesAccount != null)
            {
                WriteObject(Models.PSLocationBasedServicesAccount.Create(locationBasedServicesAccount));
            }
        }

        protected void WriteLocationBasedServicesAccountList(
            IEnumerable<LocationBasedServicesAccount> locationBasedServicesAccounts)
        {
            List<Models.PSLocationBasedServicesAccount> output = new List<Models.PSLocationBasedServicesAccount>();
            if (locationBasedServicesAccounts != null)
            {
                locationBasedServicesAccounts.ForEach(
                    locationBasedServicesAccount => output.Add(Models.PSLocationBasedServicesAccount.Create(locationBasedServicesAccount)));
            }

            WriteObject(output, true);
        }

        protected bool ValidateAndExtractName(string resourceId, out string resourceGroupName, out string resourceName)
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(resourceId);

            // validate the resource provider type
            if (string.Equals(ResourceProviderName,
                              ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                              System.StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(ResourceTypeName,
                                 ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType),
                                 System.StringComparison.InvariantCultureIgnoreCase))
            {
                resourceGroupName = resourceIdentifier.ResourceGroupName;
                resourceName = resourceIdentifier.ResourceName;
                return true;
            }
            resourceGroupName = null;
            resourceName = null;
            return false;
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
