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

using Microsoft.Azure.Commands.PowerBI.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.PowerBI.Models
{
    public class PowerBIClient
    {
        private readonly PowerBIDedicatedManagementClient _client;
        private readonly Guid _subscriptionId;
        private readonly string _currentUser;

        public PowerBIClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.GetId();
            _client = AzureSession.Instance.ClientFactory.CreateArmClient<PowerBIDedicatedManagementClient>(
                context, 
                AzureEnvironment.Endpoint.ResourceManager);
            _currentUser = context.Account.Id;
        }

        public PowerBIClient()
        {
        }

        #region Capacity Related Operations

        public PSPowerBIEmbeddedCapacity CreateOrUpdateCapacity(
            string resourceGroupName, 
            string capacityName,
            string location, 
            string skuName = null,
            Hashtable customTags = null,
            string[] administrator = null,
            PSPowerBIEmbeddedCapacity existingCapacity = null)
         {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            var tags = (customTags != null)
                ? TagsConversionHelper.CreateTagDictionary(customTags, true)
                : null;

            var adminList = new List<string>();

            if (administrator != null && !string.IsNullOrEmpty(administrator[0]))
            {
                adminList.AddRange(administrator.ToList());
                if (adminList.Count == 0)
                {
                    adminList.Add(_currentUser);
                }
            }

            DedicatedCapacity newOrUpdatedCapacity = null;
            if (existingCapacity != null)
            {
                var updateParameters = new DedicatedCapacityUpdateParameters()
                {
                    Sku = skuName == null ? null : GetResourceSkuFromName(skuName),
                    Tags = tags,
                };

                if (adminList.Count > 0)
                {
                    updateParameters.Administration = new DedicatedCapacityAdministrators(adminList);
                }

                newOrUpdatedCapacity = _client.Capacities.Update(resourceGroupName, capacityName, updateParameters);
            }
            else
            {
                newOrUpdatedCapacity = _client.Capacities.Create(
                    resourceGroupName, 
                    capacityName, 
                    new DedicatedCapacity()
                    {
                        Administration = new DedicatedCapacityAdministrators(adminList),
                        Location = location,
                        Sku = GetResourceSkuFromName(skuName),
                        Tags = tags
                    });
            }

            return new PSPowerBIEmbeddedCapacity(newOrUpdatedCapacity);
        }

        public void DeleteCapacity(string resourceGroupName, string capacityName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            _client.Capacities.Delete(resourceGroupName, capacityName);
        }

        public bool TestCapacity(string resourceGroupName, string capacityName, out PSPowerBIEmbeddedCapacity capacity)
        {
            try
            {
                capacity = GetCapacity(resourceGroupName, capacityName);
                return true;
            }
            catch (CloudException ex)
            {
                if ((ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound) || ex.Message.Contains(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, capacityName,
                    _subscriptionId)))
                {
                    capacity = null;
                    return false;
                }

                throw;
            }
        }

        public PSPowerBIEmbeddedCapacity GetCapacity(string resourceGroupName, string capacityName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            return new PSPowerBIEmbeddedCapacity(_client.Capacities.GetDetails(resourceGroupName, capacityName));
        }

        public List<PSPowerBIEmbeddedCapacity> ListCapacities(string resourceGroupName)
        {
            var capacitiesList = new List<PSPowerBIEmbeddedCapacity>();
            var response = string.IsNullOrEmpty(resourceGroupName) ?
                _client.Capacities.List() :
                _client.Capacities.ListByResourceGroup(resourceGroupName);

            response.ToList().ForEach(capacity => capacitiesList.Add(new PSPowerBIEmbeddedCapacity(capacity)));

            return capacitiesList;
        }

        public SkuEnumerationForNewResourceResult ListSkusForNew()
        {
            return _client.Capacities.ListSkus();
        }

        public SkuEnumerationForExistingResourceResult ListSkusForExisting(string resourceGroupName, string capacityName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            return _client.Capacities.ListSkusForCapacity(resourceGroupName, capacityName);
        }

        private string GetResourceGroupByCapacity(string capacityName)
        {
            try
            {
                var acctId =
                    ListCapacities(null)
                        .Find(x => x.Name.Equals(capacityName, StringComparison.InvariantCultureIgnoreCase))
                        .Id;
                var rgStart = acctId.IndexOf("resourceGroups/", StringComparison.InvariantCultureIgnoreCase) +
                              ("resourceGroups/".Length);
                var rgLength = (acctId.IndexOf("/providers/", StringComparison.InvariantCultureIgnoreCase)) - rgStart;
                return acctId.Substring(rgStart, rgLength);
            }
            catch
            {
                throw new CloudException(string.Format(Resources.FailedToDiscoverResourceGroup, capacityName, _subscriptionId));
            }
        }

        private ResourceSku GetResourceSkuFromName(string skuName)
        {
            var tier = skuName.StartsWith("A") ? SkuTier.PBIEAzure : null;
            return new ResourceSku(skuName, tier);
        }

        public void SuspendCapacity(string resourceGroupName, string capacityName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            _client.Capacities.Suspend(resourceGroupName, capacityName);
        }

        public void ResumeCapacity(string resourceGroupName, string capacityName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByCapacity(capacityName);
            }

            _client.Capacities.Resume(resourceGroupName, capacityName);
        }

        #endregion
    }
}