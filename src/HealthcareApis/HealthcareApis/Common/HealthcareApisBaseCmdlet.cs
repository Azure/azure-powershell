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

using Microsoft.Azure.Commands.HealthcareApisFhirService.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApisFhirService.Common
{
    public abstract class HealthcareApisBaseCmdlet : AzureRMCmdlet
    {
        private HealthcareApisManagementClientWrapper _healthcareApisManagementClientWrapper;

        protected const string HealthcareApisAccountNounStr = "AzHealthcareApisAccount";
        protected const string HealthcareApisAccountConfigNounStr = HealthcareApisAccountNounStr + "Config";
        protected const string HealthcareApisAccountAuthenticationConfigNounStr = HealthcareApisAccountNounStr + "AuthenticationConfig";
        protected const string HealthcareApisAccountCosmosDbConfigNounStr = HealthcareApisAccountNounStr + "AuthenticationConfig";
        protected const string HealthcareApisAccountCorsConfigNounStr = HealthcareApisAccountNounStr + "AuthenticationConfig";
        protected const string HealthcareApisAccountAccessPoliciesConfigNounStr = HealthcareApisAccountNounStr + "AccessPOliciesConfig";

        protected const string HealthcareApisAccountNameAlias = "HealthcareApisAccountName";
        protected const string AccountNameAlias = "AccountName";

        protected const string TagsAlias = "Tags";

        protected const string ResourceProviderName = "Microsoft.HealthcareApis";
        protected const string ResourceTypeName = "accounts";

        public IHealthcareApisManagementClient HealthcareApisClient
        {
            get
            {
                if (_healthcareApisManagementClientWrapper == null)
                {
                    _healthcareApisManagementClientWrapper = new HealthcareApisManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                _healthcareApisManagementClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                _healthcareApisManagementClientWrapper.ErrorLogger = WriteErrorWithTimestamp;

                return _healthcareApisManagementClientWrapper.HealthcareApisManagementClient;
            }

            set { _healthcareApisManagementClientWrapper = new HealthcareApisManagementClientWrapper(value); }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        public string AccessPolicyID
        {
            get
            {
                ActiveDirectoryClient _activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.DefaultContext);
                ADObjectFilterOptions _options = new ADObjectFilterOptions()
                {
                    Id = DefaultProfile.DefaultContext.Account.Id
                };

                return _activeDirectoryClient.GetObjectId(_options).ToString();
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
            catch (ErrorDetailsException ex)
            {
                throw new PSInvalidOperationException(ex.Message, ex);
            }
        }

        protected void WriteHealthcareApisAccount(ServicesDescription healthcareApisAccount)
        {
            if (healthcareApisAccount != null)
            {
                WriteObject(HealthcareApisFhirService.Models.PSFhirAccount.Create(healthcareApisAccount));
            }
        }

        protected void WriteHealthcareApisAccountList(
          IEnumerable<ServicesDescription> healthcareApisAccounts)
        {
            List<PSFhirAccount> output = new List<PSFhirAccount>();
            if (healthcareApisAccounts != null)
            {
                healthcareApisAccounts.ForEach(
                    healthcareApisAccount => output.Add(PSFhirAccount.Create(healthcareApisAccount)));
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
