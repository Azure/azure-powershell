﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.AzureStack.Commands
{
    /// <summary>
    /// All the nouns used in cmdlets.
    /// </summary>
    internal static class Nouns
    {
        /// <summary>
        /// The prefix for cmdlet names.
        /// </summary>
        private const string Prefix = "Azs";

        /// <summary>
        /// The noun for operations on Gallery Items.
        /// </summary>
        public const string GalleryItem = Prefix + "GalleryItem";

        /// <summary>
        /// The noun for operations on Resource Provider Manifest.
        /// </summary>
        public const string ResourceProviderManifest = Prefix + "ResourceProviderManifest";

        /// <summary>
        /// The noun for operations on Tenant Subscriptions.
        /// </summary>
        public const string Subscription = Prefix + "Subscription";

        /// <summary>
        /// The noun for operations on Subscriptions as an administrator.
        /// </summary>
        public const string TenantSubscription = Prefix + "TenantSubscription";

        /// <summary>
        /// The noun for operations on Offers.
        /// </summary>
        public const string Offer = Prefix + "Offer";

        /// <summary>
        /// The noun for admin operations on Offers.
        /// </summary>
        public const string ManagedOffer = Prefix + "ManagedOffer";

        /// <summary>
        /// The noun for operations on Plans.
        /// </summary>
        public const string Plan = Prefix + "Plan";

        /// <summary>
        /// The noun for  admin operations on Locations.
        /// </summary>
        public const string Location = Prefix + "Location";

        /// <summary>
        /// The noun for operations on Usage Connection.
        /// </summary>
        public const string UsageConnection = Prefix + "UsageConnection";

        /// <summary>
        /// The noun for operations on tokens.
        /// </summary>
        public const string Token = "AzureStackToken";
    }
}
