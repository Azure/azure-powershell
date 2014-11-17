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
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.ManagedCache.Models;
using Microsoft.Azure.Management.ManagedCache;
using Microsoft.Azure.Management.ManagedCache.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ManagedCache
{
    class PSCacheClient
    {
        private const string CacheResourceType = "Caching";
        private const string CacheServiceReadyState = "Active";

        private ManagedCacheClient client;
        public PSCacheClient(AzureSubscription currentSubscription)
        {
            client = AzureSession.ClientFactory.CreateClient<ManagedCacheClient>(currentSubscription, AzureEnvironment.Endpoint.ServiceManagement);
        }
        public PSCacheClient() { }

        public Action<string> ProgressRecorder { get; set; }

        public List<RegionsResponse.Region> GetLocations()
        {
            return new List<RegionsResponse.Region>(client.CacheServices.ListRegions().Regions);
        }

        public CloudServiceResource CreateCacheService (
            string subscriptionID,
            string cacheServiceName, 
            string location,
            CacheServiceSkuType sku, 
            string memorySize)
        {
            WriteProgress(Properties.Resources.InitializingCacheParameters);
            CacheServiceCreateParameters param = InitializeParameters(location, sku, memorySize);

            WriteProgress(Properties.Resources.CreatingPrerequisites);
            string cloudServiceName = EnsureCloudServiceExists(subscriptionID, location);

            WriteProgress(Properties.Resources.VerifyingCacheServiceName);
            if (!(client.CacheServices.CheckNameAvailability(cloudServiceName,cacheServiceName).Available))
            {
                throw new ArgumentException(Properties.Resources.CacheServiceNameUnavailable);
            }

            CloudServiceResource cacheResource = ProvisionCacheService(cloudServiceName, cacheServiceName, param, true);

            return cacheResource;
        }

        private CloudServiceResource ProvisionCacheService(string cloudServiceName, 
            string cacheServiceName, 
            CacheServiceCreateParameters param, 
            bool createOrUpdate)
        {
            if (createOrUpdate)
            {
                WriteProgress(Properties.Resources.CreatingCacheService);
            }
            else
            {
                WriteProgress(Properties.Resources.UpdatingCacheService);
            }
            client.CacheServices.CreateCacheService(cloudServiceName, cacheServiceName, param);

            WriteProgress(Properties.Resources.WaitForCacheServiceReady);
            CloudServiceResource cacheResource = WaitForProvisionDone(cacheServiceName, cloudServiceName);
            return cacheResource;
        }

        public CloudServiceResource UpdateCacheService(string cacheServiceName, CacheServiceSkuType sku, string memory,
            Action<bool, string, string, string, Action> ConfirmAction, bool force)
        {
            CloudServiceListResponse listResponse = client.CloudServices.List();
            CloudServiceResource cacheResource = null;
            string cloudServiceName = null;
            foreach (CloudServiceListResponse.CloudService cloudService in listResponse)
            {
                cacheResource = cloudService.Resources.FirstOrDefault(
                    p => { return p.Name.Equals(cacheServiceName) && IsCachingResource(p.Type); });
                if (cacheResource != null)
                {
                    cloudServiceName = cloudService.Name;
                    break;
                }
            }
            
            if (cacheResource==null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.CacheServiceNotExisting, cacheServiceName));
            }

            CacheSkuCountConvert convert = new CacheSkuCountConvert(sku);
            CacheServiceSkuType existingSkuType = cacheResource.IntrinsicSettingsSection.CacheServiceInputSection.SkuType;
            int existingSkuCount = cacheResource.IntrinsicSettingsSection.CacheServiceInputSection.SkuCount;
            int newSkuCount = convert.ToSkuCount(memory);
            if (existingSkuType == sku && existingSkuCount == newSkuCount)
            {
                WriteProgress("No update is needed as there is no change");
                return cacheResource;
            }

            //We will prompt only if there is data loss
            string promptMessage = GetPromptMessgaeIfThereIsDataLoss(existingSkuType, sku, existingSkuCount, newSkuCount);
            if (string.IsNullOrEmpty(promptMessage))
            {
                force = true;
            }
            ConfirmAction(
               force,
               string.Format(Properties.Resources.UpdatingCacheService),
               promptMessage,
               cacheServiceName,
               () =>
               {
                    cacheResource.IntrinsicSettingsSection.CacheServiceInputSection.SkuCount = convert.ToSkuCount(memory);
                    cacheResource.IntrinsicSettingsSection.CacheServiceInputSection.SkuType = sku;
                    CacheServiceCreateParameters param = new CacheServiceCreateParameters();
                    param.IntrinsicSettingsSection = cacheResource.IntrinsicSettingsSection;
                    param.ETag = cacheResource.ETag;
                    cacheResource = ProvisionCacheService(cloudServiceName, cacheResource.Name, param, false);
               });
            return cacheResource;
        }

        private static bool IsCachingResource(string resourceType)
        {
            return string.Compare(resourceType, CacheResourceType, StringComparison.OrdinalIgnoreCase) == 0;
        }

        private string GetPromptMessgaeIfThereIsDataLoss(CacheServiceSkuType existingSkuType, 
            CacheServiceSkuType newSkuType, 
            int existingSkuCount, 
            int newSkuCount)
        {
            string promptMsg = string.Empty;
            if (existingSkuType != newSkuType)
            {
                promptMsg = Properties.Resources.PromptOnCachePlanChange;
            }
            else if (existingSkuCount > newSkuCount)
            {
                promptMsg = Properties.Resources.PromptOnCacheMemoryReduce;
            }
            return promptMsg;
        }

        private static CacheServiceCreateParameters InitializeParameters(string location, CacheServiceSkuType sku, string memorySize)
        {
            CacheServiceCreateParameters param = new CacheServiceCreateParameters();
            IntrinsicSettings settings = new IntrinsicSettings();
            IntrinsicSettings.CacheServiceInput input = new IntrinsicSettings.CacheServiceInput();
            settings.CacheServiceInputSection = input;
            param.Settings = settings;

            const int CacheMemoryObjectSize = 1024;
            Models.CacheSkuCountConvert convert = new Models.CacheSkuCountConvert(sku);
            input.Location = location;
            input.SkuCount = convert.ToSkuCount(memorySize);
            input.ServiceVersion = "1.0.0";
            input.ObjectSizeInBytes = CacheMemoryObjectSize;
            input.SkuType = sku;
            return param;
        }

        private CloudServiceResource WaitForProvisionDone(string cacheServiceName, string cloudServiceName)
        {
            CloudServiceResource cacheResource = null;
            //Service state goes through Creating/Updating to Active. We only care about active
            int waitInMinutes = 30;
            while (waitInMinutes > 0)
            {
                cacheResource = GetCacheService(cloudServiceName, cacheServiceName);
                if (CacheServiceReadyState.Equals(cacheResource.SubState, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    const int milliSecondPerMinute = 60000;
                    TestMockSupport.Delay(milliSecondPerMinute);
                    waitInMinutes--;
                }
            }

            if (waitInMinutes < 0)
            {
                throw new InvalidOperationException(Properties.Resources.TimeoutWaitForCacheServiceReady);
            }
            return cacheResource;
        }

        public string NormalizeCacheServiceName(string cacheServiceName)
        {
            //Cache serice can only take lower case. We help people to get it right
            cacheServiceName = cacheServiceName.ToLower();

            //Now check length (6~20) and pattern
            int length = cacheServiceName.Length;
            if (length < 6 || length > 20 || !Regex.IsMatch(cacheServiceName,"^[a-zA-Z][a-zA-Z0-9]*$"))
            {
                throw new ArgumentException(Properties.Resources.InvalidCacheServiceName);
            }

            return cacheServiceName;
        }

        public void DeleteCacheService(string cacheServiceName)
        {
            string cloudServiceName = GetAssociatedCloudServiceName(cacheServiceName);
            if (string.IsNullOrEmpty(cloudServiceName))
            {
                string error = string.Format(Properties.Resources.CacheServiceNotExisting, cacheServiceName);
                throw new ArgumentException(error);
            }
            client.CacheServices.Delete(cloudServiceName, cacheServiceName);
        }

        private string EnsureCloudServiceExists(string subscriptionId,  string location)
        {
            string cloudServiceName = GetCloudServiceName(subscriptionId, location);

            if (!CloudServiceExists(cloudServiceName))
            {
                CloudServiceCreateParameters parameters = new CloudServiceCreateParameters();
                parameters.GeoRegion = location;
                parameters.Description = cloudServiceName;
                parameters.Label = cloudServiceName;
                OperationResponse response = client.CloudServices.Create(cloudServiceName, parameters);
            }
            return cloudServiceName;
        }

        public List<PSCacheService> GetCacheServices(string cacheServiceName)
        {
            List<PSCacheService> services = new List<PSCacheService>();
            CloudServiceListResponse listResponse = client.CloudServices.List(); 
            foreach (CloudServiceListResponse.CloudService cloudService in listResponse)
            {
                foreach(CloudServiceResource resource in cloudService.Resources)
                {
                    if (IsCachingResource(resource.Type))
                    {
                        bool nameMatched = string.IsNullOrEmpty(cacheServiceName)
                            || cacheServiceName.Equals(resource.Name, StringComparison.OrdinalIgnoreCase);

                        //'unknown' is a bad caching entry due to service internal error, 
                        // that we should not display; otherwise, it will screw up the displaying for missing some important fields.   
                        if (nameMatched && string.Compare(resource.State, "Unknown",  StringComparison.OrdinalIgnoreCase)!=0)
                        {
                            services.Add(new PSCacheService(resource));
                        }
                    }
                }
            }
            return services;
        }

        public CachingKeysResponse RegenerateAccessKeys(string cacheServiceName, string keyType)
        {
            RegenerateKeysParameters param = new RegenerateKeysParameters();
            string cloudServiceName = GetAssociatedCloudServiceName(cacheServiceName);
            param.KeyType = keyType;
            return client.CacheServices.RegenerateKeys(cloudServiceName, cacheServiceName, param);
        }

        public CachingKeysResponse GetAccessKeys(string cacheServiceName)
        {
            RegenerateKeysParameters param = new RegenerateKeysParameters();
            string cloudServiceName = GetAssociatedCloudServiceName(cacheServiceName);
            return client.CacheServices.GetKeys(cloudServiceName, cacheServiceName);
        }

        private string GetAssociatedCloudServiceName(string cacheServiceName)
        {
            CloudServiceListResponse listResponse = client.CloudServices.List();
            foreach (CloudServiceListResponse.CloudService cloudService in listResponse)
            {
                CloudServiceResource matched = cloudService.Resources.FirstOrDefault(
                   resource => {
                       return IsCachingResource(resource.Type) 
                        && cacheServiceName.Equals(resource.Name, StringComparison.OrdinalIgnoreCase);
                   });

                if (matched!=null)
                {
                    return cloudService.Name;
                }
            }
            return null;
        }

        private CloudServiceResource GetCacheService(string cloudServiceName, string cacheServiceName)
        {
            CloudServiceGetResponse response = client.CloudServices.Get(cloudServiceName);
            CloudServiceResource cacheResource = response.Resources.FirstOrDefault((r) => 
            {
                return IsCachingResource(r.Type) && r.Name.Equals(cacheServiceName, StringComparison.OrdinalIgnoreCase);
            });
            return cacheResource;
        }

        private bool CloudServiceExists(string cloudServiceName)
        {
            try
            {
                CloudServiceGetResponse response = client.CloudServices.Get(cloudServiceName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw ex;
            }
            return true;
        }

        private void WriteProgress(string progress)
        {
            if (ProgressRecorder!=null)
            {
                ProgressRecorder(progress);
            }
        }

        /// <summary>
        /// The following logic was ported from Azure Cache management portal. It is critical to maintain the 
        /// parity. Do not modify unless you understand the consequence.
        /// </summary>
        private string GetCloudServiceName(string subscriptionId, string region)
        {
            string hashedSubId = string.Empty;
            string extensionPrefix = CacheResourceType;
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                hashedSubId = Base32NoPaddingEncode(sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes(subscriptionId)));
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}-{2}", extensionPrefix, hashedSubId, region.Replace(' ', '-'));
        }

        private string Base32NoPaddingEncode(byte[] data)
        {
            const string Base32StandardAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

            StringBuilder result = new StringBuilder(Math.Max((int)Math.Ceiling(data.Length * 8 / 5.0), 1));

            byte[] emptyBuffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] workingBuffer = new byte[8];

            // Process input 5 bytes at a time
            for (int i = 0; i < data.Length; i += 5)
            {
                int bytes = Math.Min(data.Length - i, 5);
                Array.Copy(emptyBuffer, workingBuffer, emptyBuffer.Length);
                Array.Copy(data, i, workingBuffer, workingBuffer.Length - (bytes + 1), bytes);
                Array.Reverse(workingBuffer);
                ulong val = BitConverter.ToUInt64(workingBuffer, 0);

                for (int bitOffset = ((bytes + 1) * 8) - 5; bitOffset > 3; bitOffset -= 5)
                {
                    result.Append(Base32StandardAlphabet[(int)((val >> bitOffset) & 0x1f)]);
                }
            }

            return result.ToString();
        } 
    }
}
