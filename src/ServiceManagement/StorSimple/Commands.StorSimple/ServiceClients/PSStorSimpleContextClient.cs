﻿using System;
using System.Linq;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple;
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    using Properties;

    public partial class PSStorSimpleClient
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
            if (String.IsNullOrEmpty(StorSimpleContext.ResourceId)
                || String.IsNullOrEmpty(StorSimpleContext.ResourceName)
                || String.IsNullOrEmpty(StorSimpleContext.ResourceType))
                return null;
            else
            {
                return new StorSimpleResourceContext(StorSimpleContext.ResourceId, StorSimpleContext.ResourceName,
                    StorSimpleContext.StampId, StorSimpleContext.CloudServiceName, StorSimpleContext.ResourceProviderNameSpace,
                    StorSimpleContext.ResourceType, StorSimpleContext.KeyManager);
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


