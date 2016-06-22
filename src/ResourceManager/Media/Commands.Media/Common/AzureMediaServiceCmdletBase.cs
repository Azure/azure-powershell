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

using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Media;

namespace Microsoft.Azure.Commands.Media.Common
{
    /// <summary>
    /// Base class of Azure media services cmdlets
    /// </summary>
    public class AzureMediaServiceCmdletBase : AzureRMCmdlet
    {
        private IAzureMediaServices _azureMediaServices;

        protected const string DefaultApiVersion = "2015-10-01";
        protected const string MediaServicesNounStr = "AzureRmMediaServices";
        protected const string MediaServiceNounStr = "AzureRmMediaService";
        protected const string MediaServiceType = "Microsoft.Media/mediaservices";
        protected const string StorageProvider = "Microsoft.Storage";
        protected const string MediaServiceKeysNounStr = "AzureRmMediaServiceKeys";
        protected const string MediaServiceKeyNounStr = "AzureRmMediaServiceKey";
        protected const string MediaServiceStorageKeysNounStr = "AzureRmMediaServiceStorageKeys";
        protected const string MediaServiceAccountNamePattern = @"^[a-z0-9]+$";
        protected const int MediaServiceAccountNameMinLength = 3;
        protected const int MediaServiceAccountNameMaxLength = 26;

        /// <summary>
        /// Get the media service client 
        /// </summary>
        protected IAzureMediaServices AzureMediaServicesClient
        {
            get
            {
                return _azureMediaServices ??
                       (_azureMediaServices = AzureSession.ClientFactory.CreateArmClient<AzureMediaServices>(DefaultProfile.Context, 
                       AzureEnvironment.Endpoint.ResourceManager));
            }
        }

        /// <summary>
        /// The Subcription Id of the current context
        /// </summary>
        protected string SubscriptionId
        {
            get { return DefaultProfile.Context.Subscription.Id.ToString(); }
        }

        /// <summary>
        /// The Subcription Name of the current context
        /// </summary>
        protected string SubscrptionName
        {
            get { return DefaultProfile.Context.Subscription.Name; }
        }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Api Version
        /// 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Api Version")]
        [ValidateSet(DefaultApiVersion)]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Set Api Version
        /// </summary>
        protected void SetApiVersion()
        {
            if (string.IsNullOrEmpty(ApiVersion))
            {
                ApiVersion = DefaultApiVersion;
            }
        }

        /// <summary>
        /// Construct the storage account id
        /// </summary>
        /// <param name="storageAccountName"></param>
        /// <returns></returns>
        protected string GetStorageAccountId(string storageAccountName)
        {
            return string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/{2}/storageAccounts/{3}",
                SubscriptionId, ResourceGroupName, StorageProvider, storageAccountName);
        }
    }
}
