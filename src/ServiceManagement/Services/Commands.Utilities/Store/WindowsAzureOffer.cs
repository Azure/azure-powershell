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
using Microsoft.WindowsAzure.Commands.Utilities.MarketplaceServiceReference;

namespace Microsoft.WindowsAzure.Commands.Utilities.Store
{
    public class WindowsAzureOffer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public string IconUrl { get; set; }

        public string MarketplaceDetailUrl { get; set; }

        public string OfferType { get; set; }

        public string ProviderName { get; set; }

        public Guid ProviderId { get; set; }

        public string WebsiteUrl { get; set; }

        public string Country { get; set; }

        public string EulaUrl { get; set; }

        public string PrivacyPolicyUrl { get; set; }

        public string Provider { get; set; }

        public string AddOn { get; set; }

        public bool IsAvailableInAzureStores { get; set; }

        public List<Plan> Plans { get; set; }

        public List<string> Locations { get; set; }

        /// <summary>
        /// Creates new instance from WindowsAzureOffer
        /// </summary>
        /// <param name="offer">The offer details</param>
        /// <param name="plans">The offer plans</param>
        public WindowsAzureOffer(Offer offer, IEnumerable<Plan> plans, IEnumerable<string> locations)
        {
            Id = offer.Id;
            
            Name = offer.Name;
            
            ShortDescription = offer.ShortDescription;
            
            Description = offer.Description;
            
            PublishDate = offer.PublishDate;
            
            IconUrl = offer.IconUrl;
            
            MarketplaceDetailUrl = offer.MarketplaceDetailUrl;
            
            OfferType = offer.OfferType;
            
            ProviderName = offer.ProviderName;
            
            ProviderId = offer.ProviderId;
            
            WebsiteUrl = offer.WebsiteUrl;
            
            Country = offer.Country;
            
            EulaUrl = offer.EulaUrl;
            
            PrivacyPolicyUrl = offer.PrivacyPolicyUrl;
            
            Provider = offer.ProviderIdentifier;

            AddOn = offer.OfferIdentifier;

            IsAvailableInAzureStores = offer.IsAvailableInAzureStores;

            Plans = new List<Plan>(plans);

            Locations = new List<string>(locations);
        }
    }
}
