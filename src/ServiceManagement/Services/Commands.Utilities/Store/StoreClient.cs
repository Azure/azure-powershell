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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.MarketplaceServiceReference;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Store;
using Microsoft.WindowsAzure.Management.Store.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.Store
{
    using Resource = Management.Store.Models.CloudServiceListResponse.CloudService.AddOnResource;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Commands.Common.Authentication;

    public class StoreClient
    {
        private const string DataMarketResourceProviderNamespace = "DataMarket";

        private const string AppService = "AzureDevService";

        private const string StoreServicePrefix = "Azure-Stores";

        private StoreManagementClient storeClient;

        private ComputeManagementClient computeClient { get; set; }

        private ManagementClient managementClient { get; set; }

        private string subscriptionId;

        private List<CloudServiceListResponse.CloudService> GetStoreCloudServices()
        {
            List<CloudServiceListResponse.CloudService> cloudServices = new List<CloudServiceListResponse.CloudService>(storeClient.CloudServices.List().CloudServices);
            List<CloudServiceListResponse.CloudService> storeServices = cloudServices.FindAll(
                c => CultureInfo.CurrentCulture.CompareInfo.IsPrefix(c.Name, StoreServicePrefix));

            return storeServices;
        }

        private string GetCloudServiceName(string subscriptionId, string region)
        {
            string hashedSubId = string.Empty;
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                hashedSubId = Base32NoPaddingEncode(sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes(subscriptionId)));
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}-{1}-{2}", StoreServicePrefix, hashedSubId, region.Replace(' ', '-'));
        }

        private string Base32NoPaddingEncode(byte[] data)
        {
            const string base32StandardAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

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
                    result.Append(base32StandardAlphabet[(int)((val >> bitOffset) & 0x1f)]);
                }
            }

            return result.ToString();
        }

        private string CreateCloudServiceIfNotExists(string location)
        {
            string cloudServiceName = GetCloudServiceName(subscriptionId, location);
            CloudServiceCreateParameters cloudService = new CloudServiceCreateParameters()
            {
                Name = cloudServiceName,
                Label = cloudServiceName,
                Description = string.Format(Resources.CloudServiceDescription, location),
                GeoRegion = location
            };
            try
            {
                storeClient.CloudServices.Create(cloudService);
            }
            catch (Exception)
            {
                // The CloudService is already created, ignore exception.
            }

            return cloudServiceName;
        }

        private bool IsDataService(string type)
        {
            return type.Equals(WindowsAzureAddOn.DataType, StringComparison.OrdinalIgnoreCase);
        }

        public MarketplaceClient MarketplaceClient { get; set; }

        /// <summary>
        /// Parameterless constructor added for mocking framework.
        /// </summary>
        public StoreClient()
        {

        }

        /// <summary>
        /// Creates new instance from the store client.
        /// </summary>
        /// <param name="subscription">The Microsoft Azure subscription</param>
        public StoreClient(AzureSMProfile profile, AzureSubscription subscription)
            : this(
                subscription,
                AzureSession.ClientFactory.CreateClient<ComputeManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement),
                AzureSession.ClientFactory.CreateClient<StoreManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement),
                new MarketplaceClient(),
                AzureSession.ClientFactory.CreateClient<ManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement)) { }

        public StoreClient(
            AzureSubscription subscription,
            ComputeManagementClient compute,
            StoreManagementClient store,
            MarketplaceClient marketplace,
            ManagementClient management)
        {
            this.subscriptionId = subscription.Id.ToString();

            computeClient = compute;
            storeClient = store;
            MarketplaceClient = marketplace;
            managementClient = management;
        }

        /// <summary>
        /// Gets add ons based on the passed filter.
        /// </summary>
        /// <param name="searchOptions">The add on search options</param>
        /// <returns>The list of filtered add ons</returns>
        public virtual List<WindowsAzureAddOn> GetAddOn(AddOnSearchOptions searchOptions = null)
        {
            List<WindowsAzureAddOn> addOns = new List<WindowsAzureAddOn>();
            List<CloudServiceListResponse.CloudService> storeServices = GetStoreCloudServices();

            foreach (CloudServiceListResponse.CloudService storeService in storeServices)
            {
                if (GeneralUtilities.TryEquals(searchOptions.GeoRegion, storeService.GeoRegion))
                {
                    foreach (Resource resource in storeService.Resources)
                    {
                        if (GeneralUtilities.TryEquals(searchOptions.Name, resource.Name) &&
                            GeneralUtilities.TryEquals(searchOptions.Provider, resource.Namespace))
                        {
                            addOns.Add(new WindowsAzureAddOn(resource, storeService.GeoRegion, storeService.Name));
                        }
                    }
                }
            }

            return addOns;
        }

        /// <summary>
        /// Removes given Add-On
        /// </summary>
        /// <param name="name">The add-on name</param>
        public virtual void RemoveAddOn(string name)
        {
            List<WindowsAzureAddOn> addOns = GetAddOn(new AddOnSearchOptions(name, null, null));

            if (addOns.Count != 1)
            {
                throw new Exception(string.Format(Resources.AddOnNotFound, name));
            }

            WindowsAzureAddOn addon = addOns[0];
            string type;
            string cloudService;
            string addonId;
            addonId = GetResourceInformation(addon.AddOn, addon.Location, out type, out cloudService);

            storeClient.AddOns.Delete(cloudService, type, addonId, name);
        }

        public virtual void NewAddOn(
            string name,
            string addon,
            string plan,
            string location,
            string promotionCode)
        {
            string type;
            string cloudServiceName;
            addon = GetResourceInformation(addon, location, out type, out cloudServiceName);

            AddOnCreateParameters parameters = new AddOnCreateParameters()
            {
                Plan = plan,
                Type = type,
                PromotionCode = promotionCode
            };
            try
            {
                storeClient.AddOns.Create(cloudServiceName, addon, name, parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals(Resources.FirstPurchaseErrorMessage, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(Resources.FirstPurchaseMessage);
                }
            }
        }

        private string GetResourceInformation(string addon, string location, out string type, out string cloudService)
        {
            Offer offer = MarketplaceClient.GetOffer(addon);
            type = offer.OfferType;
            string provider = offer.ProviderIdentifier;
            cloudService = CreateCloudServiceIfNotExists(location);
            type = IsDataService(type) ? DataMarketResourceProviderNamespace : provider;

            if (type.Equals(DataMarketResourceProviderNamespace, StringComparison.OrdinalIgnoreCase))
            {
                addon = string.Format("{0}-{1}", provider, addon);
            }
            return addon;
        }

        /// <summary>
        /// Gets confirmation message for the given operation.
        /// </summary>
        /// <param name="operation">The operation type</param>
        /// <param name="addon">The add-on id</param>
        /// <param name="plan">The plan id</param>
        /// <returns>The confirmation message</returns>
        public virtual string GetConfirmationMessage(OperationType operation, string addon = null, string plan = null)
        {
            Offer offer = null;
            bool microsoftOffer = false;
            string addOnUrl = null;
            string message = null;

            if (!string.IsNullOrEmpty(plan))
            {
                offer = MarketplaceClient.GetOffer(addon);

                if (offer == null)
                {
                    throw new Exception(string.Format(Resources.AddOnNotFound, addon));
                }

                if (!MarketplaceClient.IsKnownProvider(offer.ProviderId))
                {
                    throw new Exception(string.Format(Resources.UnknownProviderMessage, offer.ProviderId));
                }

                microsoftOffer = MarketplaceClient.IsMicrosoftOffer(offer);
                addOnUrl = string.Format(Resources.AddOnUrl, offer.Id);
            }

            switch (operation)
            {
                case OperationType.New:
                    message = microsoftOffer ? Resources.NewMicrosoftAddOnMessage :
                        Resources.NewNonMicrosoftAddOnMessage;
                    break;
                case OperationType.Set:
                    message = microsoftOffer ? Resources.SetMicrosoftAddOnMessage :
                        Resources.SetNonMicrosoftAddOnMessage;
                    break;
                case OperationType.Remove:
                    message = Resources.RemoveAddOnMessage;
                    break;
                default:
                    throw new Exception();
            }

            if (!string.IsNullOrEmpty(addOnUrl) && !string.IsNullOrEmpty(plan) && offer != null)
            {
                return string.Format(message, addOnUrl, plan, offer.ProviderIdentifier);
            }

            return message;
        }

        /// <summary>
        /// Tries to get an add-on using it's name.
        /// </summary>
        /// <param name="name">The add-on name</param>
        /// <param name="addon">The add-on instance. Will be null if not found</param>
        /// <returns>Boolean if the add-on is found, false otherwise</returns>
        public virtual bool TryGetAddOn(string name, out WindowsAzureAddOn addon)
        {
            List<WindowsAzureAddOn> addons = GetAddOn(new AddOnSearchOptions(name, null, null));

            if (addons.Count == 1)
            {
                addon = addons[0];
                return true;
            }

            addon = null;
            return false;
        }

        /// <summary>
        /// Updates an add-on plan.
        /// </summary>
        /// <param name="name">The add-on name</param>
        /// <param name="plan">The add-on new plan id</param>
        /// <param name="promotionCode">The plan promotion code</param>
        public virtual void UpdateAddOn(string name, string plan, string promotionCode)
        {
            List<WindowsAzureAddOn> addons = GetAddOn(new AddOnSearchOptions(name));
            if (addons.Count != 1)
            {
                throw new Exception(string.Format(Resources.AddOnNotFound, name));
            }

            WindowsAzureAddOn addon = addons[0];

            if (!string.IsNullOrEmpty(promotionCode) && addon.Plan.Equals(plan, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(Resources.PromotionCodeWithCurrentPlanMessage);
            }

            string type;
            string cloudServiceName;
            addon.AddOn = GetResourceInformation(addon.AddOn, addon.Location, out type, out cloudServiceName);

            AddOnUpdateParameters parameters = new AddOnUpdateParameters()
            {
                Plan = plan,
                Type = type,
                PromotionCode = promotionCode
            };
            try
            {
                storeClient.AddOns.Update(cloudServiceName, addon.AddOn, name, parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals(Resources.FirstPurchaseErrorMessage, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(Resources.FirstPurchaseMessage);
                }
            }
        }

        public virtual List<LocationsListResponse.Location> GetLocations()
        {
            return managementClient.Locations.List().Locations.ToList();
        }
    }

    public enum OperationType
    {
        New,
        Set,
        Remove
    }
}
