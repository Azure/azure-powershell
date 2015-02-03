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
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.Scheduler;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {

        public IEnumerable<ResourceCredentials> GetAllResources()
        {
            var services = cloudServicesClient.CloudServices.List();
            var toReturn = new List<ResourceCredentials>();


            foreach (var service in services)
            {

                if (service.Resources.Count == 0)
                {
                    continue;
                }
                foreach (var resource in service.Resources)
                {
                    if (!(resource.Type.Equals("CiSVault", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        continue;
                    }
                    try
                    {
                        var resCredentials = new ResourceCredentials
                        {
                            CloudServiceName = service.Name,
                            ResourceType = resource.Type,
                            BackendStampId = resource.OutputItems["BackendStampId"],
                            ResourceId = resource.OutputItems["ResourceId"],
                            ResourceName = resource.Name,
                            ResourceNameSpace = resource.Namespace,
                            StampId = resource.OutputItems["StampId"],
                            ResourceState = resource.State
                        };

                        toReturn.Add(resCredentials);
                    }
                    catch (Exception)
                    {
                    }

                }

            }
            Resourcecache.Add("resourceObject", toReturn, ResourceCachetimeoutPolicy);
            return toReturn;
        }

        public ResourceCredentials GetResourceDetails(string resourceName)
        {
            var resCredList = GetAllResources();
            return
                resCredList.FirstOrDefault(
                    resCred => resCred.ResourceName.Equals(resourceName, StringComparison.CurrentCultureIgnoreCase));
        }

        public void SetResourceContext(ResourceCredentials resCred)
        {
            if (resCred == null)
            {
                return;
            }

            StorSimpleContext.ResourceId = resCred.ResourceId;
            StorSimpleContext.StampId = resCred.BackendStampId;
            StorSimpleContext.CloudServiceName = resCred.CloudServiceName;
            StorSimpleContext.ResourceType = resCred.ResourceType;
            StorSimpleContext.ResourceName = resCred.ResourceName;
            StorSimpleContext.ResourceProviderNameSpace = resCred.ResourceNameSpace;
            StorSimpleContext.KeyManager = new StorSimpleKeyManager(resCred.ResourceId);
        }

        public void ResetResourceContext()
        {
            StorSimpleContext.ResourceId = null;
            StorSimpleContext.StampId = null;
            StorSimpleContext.CloudServiceName = null;
            StorSimpleContext.ResourceType = null;
            StorSimpleContext.ResourceName = null;
            StorSimpleContext.ResourceProviderNameSpace = null;
            StorSimpleContext.KeyManager = null;
        }

        public StorSimpleResourceContext GetResourceContext()
        {
            if (string.IsNullOrEmpty(StorSimpleContext.ResourceId)
                || string.IsNullOrEmpty(StorSimpleContext.ResourceName)
                || string.IsNullOrEmpty(StorSimpleContext.ResourceType))
                return null;
            else
            {
                return new StorSimpleResourceContext(StorSimpleContext.ResourceId, StorSimpleContext.ResourceName,
                    StorSimpleContext.StampId, StorSimpleContext.CloudServiceName, StorSimpleContext.ResourceProviderNameSpace,
                    StorSimpleContext.ResourceType, StorSimpleContext.KeyManager);
            }
        }

        /// <summary>
        /// The CIK has to be parsed from the registration key
        /// </summary>
        /// <returns></returns>
        public string ParseCIKFromRegistrationKey(string registrationKey)
        {
            try
            {
                string[] parts = registrationKey.Split(new char[] { ':' });
                return parts[2].Split(new char[] { '#' })[0];
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.IncorrectFormatInRegistrationKey, ex);
            }
        }
    }

    public class StorSimpleResourceContext
    {
        public string ResourceId { get; set; }
        public string StampId { get; set; }
        public string CloudServiceName { get; set; }
        public string ResourceProviderNameSpace { get; set; }
        public string ResourceType { get; set; }
        public string ResourceName { get; set; }
        public StorSimpleKeyManager StorSimpleKeyManager { get; set; }

        public StorSimpleResourceContext(string resourceId, string resourceName, string stampId,
            string cloudServiceName, string resourceProviderNameSpace, string resourceType, StorSimpleKeyManager keyManager)
        {
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.ResourceType = resourceType;
            this.ResourceProviderNameSpace = resourceProviderNameSpace;
            this.StampId = stampId;
            this.CloudServiceName = cloudServiceName;
            this.StorSimpleKeyManager = keyManager;
        }


    }   
}


